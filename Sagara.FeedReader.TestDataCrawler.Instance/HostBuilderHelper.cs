using CodeHollow.FeedReader.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IO;

namespace CodeHollow.FeedReader.TestDataCrawler.Instance;

public static class HostBuilderHelper
{
    public static IHost BuildHost(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        return new HostBuilder()
            .ConfigureServices(ConfigureServices)
            .UseConsoleLifetime()
            .Build();
    }


    //
    // Private methods
    //

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
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

        services.AddScoped<FeedProcessor>();
    }
}
