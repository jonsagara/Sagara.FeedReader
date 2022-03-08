using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using CodeHollow.FeedReader.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IO;

namespace CodeHollow.FeedReader.Benchmarks.Harnesses;

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
        return await _feedReaderSvc.ReadFromFileAsync("Feeds/Rss20MicrosoftBotFranework.xml");
    }


    //
    // Private methods
    //

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddHttpClient(FeedReaderHttpClientConfiguration.HttpClientName)
            .ConfigurePrimaryHttpMessageHandler(FeedReaderHttpClientConfiguration.CreateHttpClientHandler)
            .AddTransientHttpErrorPolicy(FeedReaderHttpClientConfiguration.BuildWaitAndRetryPolicy);

        services.AddSingleton<RecyclableMemoryStreamManager>();

        // FeedReader services.
        services.Scan(scan => scan
            .FromAssemblyOf<IFeedReaderService>()
            .AddClasses(classes => classes.AssignableTo<IFeedReaderService>())
            .AsSelf()
            .WithScopedLifetime());
    }
}
