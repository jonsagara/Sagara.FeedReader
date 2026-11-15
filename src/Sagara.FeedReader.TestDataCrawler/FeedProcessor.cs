using System.Text.RegularExpressions;

namespace Sagara.FeedReader.TestDataCrawler;

public partial class FeedProcessor
{
    [GeneratedRegex(pattern: "[^a-z]*", options: RegexOptions.IgnoreCase)]
    private static partial Regex NonEnglishLetters();

    private readonly IFeedReader _feedReaderSvc;

    public FeedProcessor(IFeedReader feedReaderSvc)
    {
        _feedReaderSvc = feedReaderSvc;
    }

    /// <summary>
    /// Download the content of an individual feed.
    /// </summary>
    public async Task ReadFeedAsync(string rawFeedUrl, string outputFolder)
    {
        var pageResult = await _feedReaderSvc.GetFeedUrlsFromPageAsync(rawFeedUrl);
        if (!pageResult.IsSuccess)
        {
            Console.WriteLine();
            Console.WriteLine($"{rawFeedUrl}: [{pageResult.Error.Kind}] {pageResult.Error.Message}");
            return;
        }

        // Feed link URLs are already absolute.
        foreach (var feedLink in pageResult.Value)
        {
            string? title = feedLink.Title;
            if (string.IsNullOrEmpty(title))
            {
                // No feed title. Use the URL.
                title = rawFeedUrl
                    .Replace("https", "")
                    .Replace("http", "")
                    .Replace("www.", "");
            }

            // Fetch and parse the feed, so that we only save content that is actually a feed.
            var feedResult = await _feedReaderSvc.GetFeedAsync(feedLink.Url);
            if (!feedResult.IsSuccess)
            {
                Console.WriteLine();
                Console.WriteLine($"{feedLink.Title} - {feedLink.Url}: [{feedResult.Error.Kind}] {feedResult.Error.Message}");
                continue;
            }

            // Keep only English characters for the file we're about to write out.
            title = NonEnglishLetters().Replace(title, "");
            var outputFilePath = Path.Combine(outputFolder, $"{title}_{Guid.NewGuid()}.xml");
            await File.WriteAllTextAsync(outputFilePath, feedResult.Value.OriginalFeedXml);

            // Progress indicator.
            Console.Write("+");
        }
    }
}
