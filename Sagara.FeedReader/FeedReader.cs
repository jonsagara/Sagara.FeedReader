namespace Sagara.FeedReader;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sagara.FeedReader.Html;
using Sagara.FeedReader.Http;
using Sagara.FeedReader.Parser;

/// <summary>
/// The static FeedReader class allows to read feeds from a given url. Use it to parse a feed 
/// from an url <see cref="ReadAsync(string, string?, CancellationToken)"/>, a file <see cref="ReadFromFile(string)"/> 
/// or <see cref="ReadFromFileAsync(string, CancellationToken)"/>, or a 
/// string <see cref="ReadFromString(string)"/>. If the feed url is not known, <see cref="GetFeedUrlsFromPageAsync(string, CancellationToken)"/> 
/// returns all feed links on a given page.
/// </summary>
/// <example>
/// var links = FeedReader.ParseFeedUrlsFromHtml("https://codehollow.com");
/// var firstLink = links.First();
/// var feed = FeedReader.Read(firstLink.Url);
/// Console.WriteLine(feed.Title);
/// </example>
public static class FeedReader
{
    /// <summary>
    /// Opens a webpage and reads all feed urls from it (link rel="alternate" type="application/...")
    /// </summary>
    /// <param name="pageUrl">the url of the page</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <returns>a list of links including the type and title, an empty list if no links are found</returns>
    /// <example>FeedReader.GetFeedUrlsFromUrl("codehollow.com"); // returns a list of all available feeds at
    /// https://codehollow.com </example>
    public static async Task<IReadOnlyCollection<HtmlFeedLink>> GetFeedUrlsFromPageAsync(string pageUrl, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(pageUrl);

        var absolutePageUrl = Helpers.GetAbsoluteUrl(pageUrl);

        var htmlContent = await Helpers
            .DownloadAsync(
                url: absolutePageUrl,
                cancellationToken: cancellationToken
            )
            .ConfigureAwait(false);

        return HtmlHelper.ParseFeedUrlsFromHtml(htmlContent);
    }

    /// <summary>
    /// Reads a feed from an url. The url must be a feed. Use <see cref="GetFeedUrlsFromPageAsync(string, CancellationToken)"/> 
    /// to parse the feeds from a url which is not a feed.
    /// </summary>
    /// <param name="feedUrl">the url to a feed</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <param name="userAgent">override built-in user-agent header</param>
    /// <returns>parsed feed</returns>
    public static async Task<Feed> ReadAsync(string feedUrl, string? userAgent = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(feedUrl);

        var absoluteFeedUrl = Helpers.GetAbsoluteUrl(feedUrl);

        var feedContent = await HttpClientHelper
            .DownloadBytesAsync(
                url: absoluteFeedUrl,
                userAgent: userAgent,
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);

        return FeedParser.GetFeedFromBytes(feedContent);
    }

    /// <summary>
    /// Reads a feed from a file.
    /// </summary>
    /// <param name="filePath">The path to the feed file</param>
    /// <returns>Parsed feed</returns>
    public static Feed ReadFromFile(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);

        var feedContent = File.ReadAllBytes(filePath);
        return FeedParser.GetFeedFromBytes(feedContent);
    }

    /// <summary>
    /// Reads a feed from a file.
    /// </summary>
    /// <param name="filePath">the path to the feed file</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <returns>parsed feed</returns>
    public static async Task<Feed> ReadFromFileAsync(string filePath, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(filePath);

        byte[] result = await File.ReadAllBytesAsync(filePath, cancellationToken).ConfigureAwait(false);
        return FeedParser.GetFeedFromBytes(result);
    }

    /// <summary>
    /// Reads a feed contained in the string argument <paramref name="feedContent" />.
    /// </summary>
    /// <param name="feedContent">The feed content (xml).</param>
    /// <returns>The parsed feed.</returns>
    public static Feed ReadFromString(string feedContent)
    {
        ArgumentNullException.ThrowIfNull(feedContent);

        return FeedParser.GetFeedFromString(feedContent);
    }
}
