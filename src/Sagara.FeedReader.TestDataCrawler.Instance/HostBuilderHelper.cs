using Sagara.FeedReader.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IO;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.TestDataCrawler.Instance;

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
        services.AddFeedReaderServices();

        services.AddScoped<FeedProcessor>();
    }
}
