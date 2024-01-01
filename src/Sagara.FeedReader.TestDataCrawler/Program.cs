using Microsoft.Extensions.DependencyInjection;
using Sagara.FeedReader;
using Sagara.FeedReader.TestDataCrawler;

try
{
    var host = HostBuilderHelper.BuildHost(args);

    using (var serviceScope = host.Services.CreateScope())
    {
        var services = serviceScope.ServiceProvider;
        var feedReaderSvc = services.GetRequiredService<FeedReader>();
        var feedProcessor = services.GetRequiredService<FeedProcessor>();

        // Get all feed URLs from the file.
        var rawFeedUrls = File.ReadAllLines("feeds.txt");

        // Ensure the output folder exists.
        var outputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CrawledFeeds");
        Directory.CreateDirectory(outputFolder);

        // Process each feed. Feeds may have more than one URL.
        await Parallel.ForEachAsync<string>(
            rawFeedUrls,
            async (rawFeedUrl, cancellationToken) =>
            {
                try
                {
                    await feedProcessor.ReadFeedAsync(rawFeedUrl, outputFolder);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine();
                    Console.Error.WriteLine($"Unhandled exception for feed '{rawFeedUrl}': {ex}");
                }
            }
            );
    }

    Console.WriteLine("Done.");

    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Host terminated unexpectedly: {ex}");

    return 1;
}
