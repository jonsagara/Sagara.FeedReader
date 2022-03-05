using CodeHollow.FeedReader.TestDataCrawler;

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
                await FeedProcessor.ReadFeedAsync(rawFeedUrl, outputFolder);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unhandled exception for feed '{rawFeedUrl}': {ex}");
            }
        }
    );
