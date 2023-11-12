﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.IO;
using Sagara.FeedReader.Http;

namespace Sagara.FeedReader.Tests.Instance.Fixtures;

public class HostFixture : IDisposable
{
    private readonly IHost _host;
    public IServiceScope ServiceScope { get; }

    public HostFixture()
    {
        _host = new HostBuilder()
            .ConfigureServices(ConfigureServices)
            .Build();

        ServiceScope = _host.Services.CreateScope();
    }

    public void Dispose()
    {
        ServiceScope.Dispose();
        _host.Dispose();
    }


    //
    // Private methods
    //

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddHttpClient(NamedHttpClients.FeedReader.Name)
            .ConfigurePrimaryHttpMessageHandler(FeedReaderHttpClientConfiguration.CreateHttpClientHandler)
            .AddResilienceHandler(
                pipelineName: $"{NamedHttpClients.FeedReader.Name} pipeline",
                pipelineBuilder => FeedReaderHttpClientConfiguration.ConfigureRetryAndWaitWithExponentialBackoffStrategy(pipelineBuilder, httpClientName: NamedHttpClients.FeedReader.Name, maxRetryAttempts: NamedHttpClients.FeedReader.MaxRetryAttempts)
                );

        services.AddSingleton<RecyclableMemoryStreamManager>();

        // FeedReader services.
        services.Scan(scan => scan
            .FromAssemblyOf<IFeedReaderService>()
            .AddClasses(classes => classes.AssignableTo<IFeedReaderService>())
            .AsSelf()
            .WithScopedLifetime());
    }
}
