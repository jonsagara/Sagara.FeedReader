﻿using System.Text.RegularExpressions;
using Sagara.FeedReader.Http;

namespace Sagara.FeedReader.TestDataCrawler;

public partial class FeedProcessor
{
    [GeneratedRegex(pattern: "[^a-z]*", options: RegexOptions.IgnoreCase)]
    private static partial Regex NonEnglishLetters();

    private readonly FeedReader _feedReaderSvc;
    private readonly HttpClientService _httpClientSvc;

    public FeedProcessor(FeedReader feedReaderSvc, HttpClientService httpClientSvc)
    {
        _feedReaderSvc = feedReaderSvc;
        _httpClientSvc = httpClientSvc;
    }

    /// <summary>
    /// Download the content of an individual feed.
    /// </summary>
    public async Task ReadFeedAsync(string rawFeedUrl, string outputFolder)
    {
        var feedLinks = await _feedReaderSvc.GetFeedUrlsFromPageAsync(rawFeedUrl);

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
                var content = await _httpClientSvc.DownloadStringAsync(feedLink.Url);

                // Keep only English characters for the file we're about to write out.
                title = NonEnglishLetters().Replace(title, "");
                var outputFilePath = Path.Combine(outputFolder, $"{title}_{Guid.NewGuid()}.xml");
                File.WriteAllText(outputFilePath, content);

                // Progress indicator.
                Console.Write("+");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"{fileFeedLink.Title} - {fileFeedLink.Url}: {ex}");
            }
        }
    }
}
