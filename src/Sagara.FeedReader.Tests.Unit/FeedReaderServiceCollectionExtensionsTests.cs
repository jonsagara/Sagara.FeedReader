using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.IO;
using Polly;
using Sagara.FeedReader.Configuration;
using Sagara.FeedReader.Tests.Unit.Fakes;
using Xunit;

namespace Sagara.FeedReader.Tests.Unit;

// NOTE: there is deliberately no `using Sagara.FeedReader.Extensions;` in this file. AddFeedReaderServices lives in the
//   Microsoft.Extensions.DependencyInjection namespace, so it must be callable without it.

public class FeedReaderServiceCollectionExtensionsTests
{
    private const string FeedUrl = "https://example.com/feed.xml";

    private static CancellationToken CancellationToken => TestContext.Current.CancellationToken;


    #region Registration

    [Fact]
    public void Defaults_ResolveFeedReader()
    {
        using var serviceProvider = new ServiceCollection()
            .AddFeedReaderServices()
            .BuildServiceProvider();

        Assert.IsType<FeedReader>(serviceProvider.GetRequiredService<IFeedReader>());
    }

    [Fact]
    public void ConfigureOverload_ResolvesFeedReader()
    {
        using var serviceProvider = new ServiceCollection()
            .AddFeedReaderServices(options => options.MaxResponseBytes = 1024)
            .BuildServiceProvider();

        Assert.IsType<FeedReader>(serviceProvider.GetRequiredService<IFeedReader>());
    }

    [Fact]
    public void NullArguments_Throw()
    {
        Assert.Throws<ArgumentNullException>("services", () => FeedReaderServiceCollectionExtensions.AddFeedReaderServices(null!));
        Assert.Throws<ArgumentNullException>("services", () => FeedReaderServiceCollectionExtensions.AddFeedReaderServices(null!, _ => { }));
        Assert.Throws<ArgumentNullException>("configure", () => new ServiceCollection().AddFeedReaderServices((Action<FeedReaderOptions>)null!));
    }

    #endregion


    #region Options flow through to FeedReader

    [Fact]
    public async Task ConfigureOverload_AppliesMaxResponseBytes()
    {
        using var serviceProvider = BuildServiceProvider(
            services => services.AddFeedReaderServices(options => options.MaxResponseBytes = 10),
            FakeHttpMessageHandler.Ok());

        var result = await serviceProvider.GetRequiredService<IFeedReader>().GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.ResponseTooLarge, result.Error.Kind);
    }

    [Fact]
    public async Task OptionsOverload_AppliesMaxResponseBytes()
    {
        using var serviceProvider = BuildServiceProvider(
            services => services.AddFeedReaderServices(new FeedReaderOptions { MaxResponseBytes = 10 }),
            FakeHttpMessageHandler.Ok());

        var result = await serviceProvider.GetRequiredService<IFeedReader>().GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.ResponseTooLarge, result.Error.Kind);
    }

    [Fact]
    public async Task DefaultUserAgent_IsSentUnlessARequestOverridesIt()
    {
        var handler = FakeHttpMessageHandler.Ok();
        using var serviceProvider = BuildServiceProvider(
            services => services.AddFeedReaderServices(options => options.DefaultUserAgent = "MyFeedBot/1.0"),
            handler);
        var feedReader = serviceProvider.GetRequiredService<IFeedReader>();

        await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);
        await feedReader.GetFeedAsync(FeedUrl, userAgent: "PerRequest/2.0", cancellationToken: CancellationToken);

        Assert.Equal(new[] { "MyFeedBot/1.0", "PerRequest/2.0" }, handler.Requests.Select(r => r.Headers.UserAgent.ToString()));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task BlankDefaultUserAgent_FallsBackToBuiltInUserAgent(string? defaultUserAgent)
    {
        var handler = FakeHttpMessageHandler.Ok();
        using var serviceProvider = BuildServiceProvider(
            services => services.AddFeedReaderServices(options => options.DefaultUserAgent = defaultUserAgent),
            handler);

        await serviceProvider.GetRequiredService<IFeedReader>().GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.StartsWith("Mozilla/5.0", Assert.Single(handler.Requests).Headers.UserAgent.ToString(), StringComparison.Ordinal);
    }

    #endregion


    #region Resilience pipeline

    [Fact]
    public async Task DefaultResilienceHandler_RetriesTransientFailureOnce()
    {
        var handler = RespondWithStatusSequence(HttpStatusCode.ServiceUnavailable, HttpStatusCode.OK);
        using var serviceProvider = BuildServiceProvider(services => services.AddFeedReaderServices(), handler);

        var result = await serviceProvider.GetRequiredService<IFeedReader>().GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.True(result.IsSuccess, result.Error?.Message);
        Assert.Equal(2, handler.Requests.Count);
    }

    [Fact]
    public async Task CustomResilienceHandler_ReplacesDefault()
    {
        var handler = RespondWithStatusSequence(HttpStatusCode.ServiceUnavailable, HttpStatusCode.ServiceUnavailable, HttpStatusCode.OK);
        using var serviceProvider = BuildServiceProvider(
            services => services.AddFeedReaderServices(options => options.ResilienceHandler = (pipeline, _) => pipeline.AddRetry(new HttpRetryStrategyOptions
            {
                MaxRetryAttempts = 2,
                Delay = TimeSpan.Zero,
                BackoffType = DelayBackoffType.Constant,
            })),
            handler);

        var result = await serviceProvider.GetRequiredService<IFeedReader>().GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.True(result.IsSuccess, result.Error?.Message);
        Assert.Equal(3, handler.Requests.Count);
    }

    #endregion


    #region RecyclableMemoryStreamManager registration

    [Fact]
    public void Defaults_RegisterSingletonStreamManager()
    {
        using var serviceProvider = new ServiceCollection()
            .AddFeedReaderServices()
            .BuildServiceProvider();

        var first = serviceProvider.GetRequiredService<RecyclableMemoryStreamManager>();
        var second = serviceProvider.GetRequiredService<RecyclableMemoryStreamManager>();

        Assert.Same(first, second);
    }

    [Fact]
    public void ExistingStreamManager_IsKept()
    {
        var callersStreamManager = new RecyclableMemoryStreamManager();

        using var serviceProvider = new ServiceCollection()
            .AddSingleton(callersStreamManager)
            .AddFeedReaderServices()
            .BuildServiceProvider();

        Assert.Same(callersStreamManager, serviceProvider.GetRequiredService<RecyclableMemoryStreamManager>());
    }

    [Fact]
    public void SuppressedRegistration_DoesNotRegisterStreamManager()
    {
        using var serviceProvider = new ServiceCollection()
            .AddFeedReaderServices(options => options.SuppressRecyclableMemoryStreamManagerRegistration = true)
            .BuildServiceProvider();

        Assert.Null(serviceProvider.GetService<RecyclableMemoryStreamManager>());
        Assert.Throws<InvalidOperationException>(() => serviceProvider.GetRequiredService<IFeedReader>());
    }

    [Fact]
    public void SuppressedRegistration_UsesStreamManagerRegisteredLater()
    {
        var callersStreamManager = new RecyclableMemoryStreamManager();

        using var serviceProvider = new ServiceCollection()
            .AddFeedReaderServices(options => options.SuppressRecyclableMemoryStreamManagerRegistration = true)
            .AddSingleton(callersStreamManager)
            .BuildServiceProvider();

        Assert.Same(callersStreamManager, serviceProvider.GetRequiredService<RecyclableMemoryStreamManager>());
        Assert.IsType<FeedReader>(serviceProvider.GetRequiredService<IFeedReader>());
    }

    #endregion


    //
    // Helpers
    //

    /// <summary>
    /// Register services, then swap FeedReader's primary HTTP handler for <paramref name="handler"/>. Everything else,
    /// including the resilience pipeline, is the real registration.
    /// </summary>
    private static ServiceProvider BuildServiceProvider(Action<IServiceCollection> register, HttpMessageHandler handler)
    {
        var services = new ServiceCollection();
        register(services);

        // Handler builder actions run in order, so this replaces the HttpClientHandler that AddFeedReaderServices configured.
        services.AddHttpClient(ResilienceHelper.HttpClientName)
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        return services.BuildServiceProvider();
    }

    /// <summary>
    /// Respond with each status code in turn, repeating the last one. 200 responses carry a feed.
    /// </summary>
    private static FakeHttpMessageHandler RespondWithStatusSequence(params HttpStatusCode[] statusCodes)
    {
        var requestCount = 0;

        return new FakeHttpMessageHandler(_ =>
        {
            var statusCode = statusCodes[Math.Min(requestCount++, statusCodes.Length - 1)];

            return new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(statusCode == HttpStatusCode.OK ? FakeHttpMessageHandler.MinimalRss20 : string.Empty),
            };
        });
    }
}
