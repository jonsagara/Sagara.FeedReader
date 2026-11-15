using System.Net;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IO;
using Sagara.FeedReader;
using Sagara.FeedReader.Configuration;

// In this namespace, like Microsoft's own AddXxx extensions, so that callers don't need an extra using directive.
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for registering <see cref="IFeedReader"/> with dependency injection.
/// </summary>
public static class FeedReaderServiceCollectionExtensions
{
    /// <summary>
    /// Register <see cref="IFeedReader"/>, its HttpClient, and the RecyclableMemoryStreamManager it uses.
    /// </summary>
    /// <example>
    /// <code>
    /// services.AddFeedReaderServices(options =>
    /// {
    ///     options.MaxResponseBytes = 5 * 1024 * 1024;
    ///     options.DefaultUserAgent = "MyFeedBot/1.0 (+https://example.com/bot)";
    /// });
    /// </code>
    /// </example>
    /// <param name="services">The service collection to add the services to.</param>
    /// <param name="configure">Configures the options.</param>
    /// <returns>The service collection, for chaining.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="services"/> or <paramref name="configure"/> is null.</exception>
    public static IServiceCollection AddFeedReaderServices(this IServiceCollection services, Action<FeedReaderOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configure);

        var options = new FeedReaderOptions();
        configure(options);

        return InternalAddFeedReaderServices(services, options);
    }

    /// <summary>
    /// Register <see cref="IFeedReader"/>, its HttpClient, and the RecyclableMemoryStreamManager it uses.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    /// <param name="options">Optional. Configures FeedReader's HttpClient, RecyclableMemoryStreamManager, and download limits.
    /// If null, the defaults are used.</param>
    /// <returns>The service collection, for chaining.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="services"/> is null.</exception>
    public static IServiceCollection AddFeedReaderServices(this IServiceCollection services, FeedReaderOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        return InternalAddFeedReaderServices(services, options ?? new FeedReaderOptions());
    }


    //
    // Private methods
    //

    private static IServiceCollection InternalAddFeedReaderServices(IServiceCollection services, FeedReaderOptions options)
    {
        //
        // Configure the HttpClient used by FeedReader.
        //

        var resilienceHandler = options.ResilienceHandler ?? ResilienceHelper.DefaultResilienceHandler;

        // Register FeedReader as a typed client for IFeedReader. The factory passes it the caller's options without
        //   registering FeedReaderOptions itself as a service.
        services.AddHttpClient<IFeedReader, FeedReader>(
                ResilienceHelper.HttpClientName,
                (httpClient, serviceProvider) => new FeedReader(httpClient, serviceProvider.GetRequiredService<RecyclableMemoryStreamManager>(), options))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                CheckCertificateRevocationList = true,
                Proxy = options.Proxy,
            })
            .AddResilienceHandler(pipelineName: $"{ResilienceHelper.HttpClientName} pipeline", configure: resilienceHandler);


        //
        // If not suppressed, register a RecyclableMemoryStreamManager. TryAdd so that one the caller already
        //   registered is kept.
        //

        if (!options.SuppressRecyclableMemoryStreamManagerRegistration)
        {
            var streamManagerOptions = options.RecyclableMemoryStreamManagerOptions ?? RecyclableMemoryStreamManagerHelper.GetDefaultRecyclableMemoryStreamManagerOptions();

            services.TryAddSingleton(_ => new RecyclableMemoryStreamManager(streamManagerOptions));
        }

        return services;
    }
}
