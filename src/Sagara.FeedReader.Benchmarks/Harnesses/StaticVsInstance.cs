using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.IO;
using Sagara.FeedReader.Http;

namespace Sagara.FeedReader.Benchmarks.Harnesses;

[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class StaticVsInstance
{
    private readonly FeedReaderService _feedReaderSvc;

    public StaticVsInstance()
    {
        var host = new HostBuilder()
            .ConfigureServices(ConfigureServices)
            .Build();

        var serviceScope = host.Services.CreateScope();
        _feedReaderSvc = serviceScope.ServiceProvider.GetRequiredService<FeedReaderService>();
    }

    [Benchmark(Baseline = true)]
    public async Task<Feed> StaticReadFromFileAsync()
    {
        return await FeedReader.ReadFromFileAsync("Feeds/Rss20MicrosoftBotFranework.xml");
    }

    [Benchmark]
    public async Task<Feed> InstanceReadFromFileAsync()
    {
        // This is a static method, but it differs from the original static FeedReader API.
        //   It parses a stream instead of a byte[].
        return await FeedReaderService.ReadFromFileAsync("Feeds/Rss20MicrosoftBotFranework.xml");
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
