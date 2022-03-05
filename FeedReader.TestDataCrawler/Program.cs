using System.Text.RegularExpressions;
using CodeHollow.FeedReader;

// Get all feed URLs from the file.
var feeds = File.ReadAllLines("feeds.txt");

// Ensure the output folder exists.
var outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
Directory.CreateDirectory(outputFolder);

// Process each feed. Feeds may have more than one URL.
await Parallel.ForEachAsync<string>(
    feeds,
    async (feed, token) =>
        {
            try
            {
                await DoAsync(feed, outputFolder);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unhandled exception for feed '{feed}': {ex}");
            }
        }
    );


/// <summary>
/// Download the content of an individual feed.
/// </summary>
static async Task DoAsync(string url, string outputFolder)
{
    var feedLinks = await FeedReader.GetFeedUrlsFromUrlAsync(url);

    foreach (var fileFeedLink in feedLinks)
    {
        try
        {
            string? title = fileFeedLink.Title;
            if (string.IsNullOrEmpty(title))
            {
                title = url.Replace("https", "").Replace("http", "").Replace("www.", "");
            }

            title = Regex.Replace(title.ToLower(), "[^a-z]*", "");
            var feedLink = FeedReader.GetAbsoluteFeedUrl(url, fileFeedLink);

            var content = await Helpers.DownloadAsync(feedLink.Url);

            var outputFilePath = Path.Combine(outputFolder, title + "_" + Guid.NewGuid().ToString() + ".xml");
            File.WriteAllText(outputFilePath, content);
            Console.Write("+");
        }
        catch (Exception ex)
        {
            Console.WriteLine(fileFeedLink.Title + " - " + fileFeedLink.Url + ": " + ex.ToString());
        }
    }
}

