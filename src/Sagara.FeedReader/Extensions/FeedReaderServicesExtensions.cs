﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.IO;
using Sagara.FeedReader.Http;

namespace Sagara.FeedReader.Extensions;

/// <summary>
/// Extension methods for configuring FeedReader DI services.
/// </summary>
public static class FeedReaderServicesExtensions
{
    /// <summary>
    /// Add services required by the instance-based API of FeedReader.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddFeedReaderServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        
        // Configure the HttpClient used by the instance-based FeedReader.
        services.AddHttpClient(FeedReaderHttpClientConfiguration.HttpClientName)
            .ConfigurePrimaryHttpMessageHandler(FeedReaderHttpClientConfiguration.CreateHttpClientHandler)
            .AddTransientHttpErrorPolicy(FeedReaderHttpClientConfiguration.BuildWaitAndRetryPolicy);
        
        // Used to store downloaded streams of bytes. Instead of creating new MemoryStreams all the time, grab them
        //   from a pool.
        services.AddSingleton<RecyclableMemoryStreamManager>();

        // FeedReader services.
        services.Scan(scan => scan
            .FromAssemblyOf<IFeedReaderService>()
            .AddClasses(classes => classes.AssignableTo<IFeedReaderService>())
            .AsSelf()
            .WithScopedLifetime());

        return services;
    }
}