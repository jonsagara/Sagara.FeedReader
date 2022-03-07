using System.Text.RegularExpressions;

namespace CodeHollow.FeedReader.TestDataCrawler;

public static class FeedProcessor
{
    private static readonly Regex _nonEnglishLetters = new Regex("[^a-z]*", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    /// <summary>
    /// Download the content of an individual feed.
    /// </summary>
    public static async Task ReadFeedAsync(string rawFeedUrl, string outputFolder)
    {
        var feedLinks = await FeedReader.GetFeedUrlsFromUrlAsync(rawFeedUrl);

        foreach (var fileFeedLink in feedLinks)
        {
            try
            {
                string? title = fileFeedLink.Title;
                if (string.IsNullOrEmpty(title))
                {
                    // No feed title. Use the URL.
                    title = rawFeedUrl
                        .Replace("https", "")
                        .Replace("http", "")
                        .Replace("www.", "");
                }

                // Ensure we have an absolute URL before trying to getch its contents.
                var feedLink = Helpers.GetAbsoluteFeedUrl(rawFeedUrl, fileFeedLink);

                // Fetch the feed's contents.
                var content = await Helpers.DownloadAsync(feedLink.Url);

                // Keep only English characters for the file we're about to write out.
                title = _nonEnglishLetters.Replace(title, "");
                var outputFilePath = Path.Combine(outputFolder, $"{title}_{Guid.NewGuid()}.xml");
                File.WriteAllText(outputFilePath, content);

                // Progress indicator.
                Console.Write("+");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{fileFeedLink.Title} - {fileFeedLink.Url}: {ex}");
            }
        }
    }
}
