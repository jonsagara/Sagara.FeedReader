using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Benchmarks.Harnesses;

// 2024-01-01: Removed the static API.

//[SimpleJob(RuntimeMoniker.Net60)]
//[MemoryDiagnoser]
//public class StaticVsInstance
//{
//    private readonly FeedReaderService _feedReaderSvc;

//    public StaticVsInstance()
//    {
//        var host = new HostBuilder()
//            .ConfigureServices(ConfigureServices)
//            .Build();

//        var serviceScope = host.Services.CreateScope();
//        _feedReaderSvc = serviceScope.ServiceProvider.GetRequiredService<FeedReaderService>();
//    }

//    [Benchmark(Baseline = true)]
//    public async Task<Feed> StaticReadFromFileAsync()
//    {
//        return await FeedReader.ReadFromFileAsync("Feeds/Rss20MicrosoftBotFramework.xml");
//    }

//    [Benchmark]
//    public async Task<Feed> InstanceReadFromFileAsync()
//    {
//        // This is a static method, but it differs from the original static FeedReader API.
//        //   It parses a stream instead of a byte[].
//        return await FeedReaderService.ReadFromFileAsync("Feeds/Rss20MicrosoftBotFramework.xml");
//    }


//    //
//    // Private methods
//    //

//    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
//    {
//        services.AddFeedReaderServices();
//    }
//}
