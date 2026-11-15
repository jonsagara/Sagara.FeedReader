using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IO;
using Sagara.FeedReader.Configuration;

namespace Sagara.FeedReader.Extensions;

/// <summary>
/// Extension methods for configuring FeedReader DI services.
/// </summary>
public static class FeedReaderExtensions
{
    /// <summary>
    /// Add and configure services required by FeedReader.
    /// </summary>
    /// <remarks>
    /// NOTE: this only applies to the instance-based API.
    /// </remarks>
    /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
    /// <param name="options">Optional. Used to allow the caller to configure FeedReader's HttpClient and RecyclableMemoryStreamManager dependencies.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddFeedReaderServices(this IServiceCollection services, FeedReaderOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        // If the caller didn't pass any options, use our defaults.
        options ??= new FeedReaderOptions
        {
            SuppressRecyclableMemoryStreamManagerRegistration = false,
            RecyclableMemoryStreamManagerOptions = RecyclableMemoryStreamManagerHelper.GetDefaultRecyclableMemoryStreamManagerOptions(),

            ResilienceHandler = ResilienceHelper.DefaultResilienceHandler,
            Proxy = null,
        };

        return InternalAddFeedReaderServices(services, options);
    }


    //
    // Private methods
    //

    private static IServiceCollection InternalAddFeedReaderServices(IServiceCollection services, FeedReaderOptions options)
    {
        //
        // Configure the HttpClient used by FeedReader.
        //

        options.ResilienceHandler ??= ResilienceHelper.DefaultResilienceHandler;

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
            .AddResilienceHandler(pipelineName: $"{ResilienceHelper.HttpClientName} pipeline", configure: options.ResilienceHandler);


        //
        // If not suppressed, configure the RecyclableMemoryStreamManager.
        //

        if (!options.SuppressRecyclableMemoryStreamManagerRegistration)
        {
            options.RecyclableMemoryStreamManagerOptions ??= RecyclableMemoryStreamManagerHelper.GetDefaultRecyclableMemoryStreamManagerOptions();

            services.AddSingleton(_ => new RecyclableMemoryStreamManager(options.RecyclableMemoryStreamManagerOptions));
        }

        return services;
    }
}
