using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IO;
using Sagara.FeedReader.Configuration;
using Sagara.FeedReader.Http;

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

        if (options is null)
        {
            //
            // The caller didn't pass any options. Use our defaults.
            //

            options = new FeedReaderOptions
            {
                SuppressRecyclableMemoryStreamManagerRegistration = false,
                RecyclableMemoryStreamManagerOptions = RecyclableMemoryStreamManagerHelper.GetDefaultRecyclableMemoryStreamManagerOptions(),

                ResilienceHandler = ResilienceHelper.DefaultResilienceHandler,
            };
        }
        else
        {
            //
            // The caller passed options. Fill in any defaults that they didn't provide.
            //

            if (!options.SuppressRecyclableMemoryStreamManagerRegistration)
            {
                options.RecyclableMemoryStreamManagerOptions ??= RecyclableMemoryStreamManagerHelper.GetDefaultRecyclableMemoryStreamManagerOptions();
            }

            options.ResilienceHandler ??= ResilienceHelper.DefaultResilienceHandler;
        }


        //
        // Configure the HttpClient used by FeedReader.
        //

        services.AddHttpClient(NamedHttpClients.FeedReader.Name)
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                CheckCertificateRevocationList = true,
                Proxy = options?.Proxy,
            })
            .AddResilienceHandler(pipelineName: $"{NamedHttpClients.FeedReader.Name} pipeline", configure: options.ResilienceHandler);


        //
        // If not suppressed, configure the RecyclableMemoryStreamManager.
        //

        if (!options.SuppressRecyclableMemoryStreamManagerRegistration)
        {
            services.AddSingleton(_ => new RecyclableMemoryStreamManager(options.RecyclableMemoryStreamManagerOptions));
        }


        // Register the FeedReader services.
        services.Scan(scan => scan
            .FromAssemblyOf<IFeedReaderService>()
            .AddClasses(classes => classes.AssignableTo<IFeedReaderService>())
            .AsSelf()
            .WithScopedLifetime());

        return services;
    }
}
