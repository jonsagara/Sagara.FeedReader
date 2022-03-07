namespace CodeHollow.FeedReader;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CodeHollow.FeedReader.Html;
using CodeHollow.FeedReader.Http;
using Parser;

/// <summary>
/// The static FeedReader class allows to read feeds from a given url. Use it to parse a feed 
/// from an url <see cref="ReadAsync(string, string?, CancellationToken)"/>, a file <see cref="ReadFromFile(string)"/> 
/// or <see cref="ReadFromFileAsync(string, CancellationToken)"/>, a byte array <see cref="ReadFromByteArray(byte[])"/> or a 
/// string <see cref="ReadFromString(string)"/>. If the feed url is not known, <see cref="ParseFeedUrlsFromHtml(string)"/> 
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
    /// Static API. Opens a webpage and reads all feed urls from it (link rel="alternate" type="application/...")
    /// </summary>
    /// <param name="url">the url of the page</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <returns>a list of links including the type and title, an empty list if no links are found</returns>
    /// <example>FeedReader.GetFeedUrlsFromUrl("codehollow.com"); // returns a list of all available feeds at
    /// https://codehollow.com </example>
    public static async Task<IReadOnlyCollection<HtmlFeedLink>> GetFeedUrlsFromUrlAsync(string url, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        url = Helpers.GetAbsoluteUrl(url);
        string pageContent = await Helpers.DownloadAsync(url, cancellationToken: cancellationToken).ConfigureAwait(false);
        var links = ParseFeedUrlsFromHtml(pageContent);
        return links;
    }

    /// <summary>
    /// Parses RSS links from html page and returns all links
    /// </summary>
    /// <param name="htmlContent">the content of the html page</param>
    /// <returns>all RSS/feed links</returns>
    public static IReadOnlyCollection<HtmlFeedLink> ParseFeedUrlsFromHtml(string htmlContent)
    {
        ArgumentNullException.ThrowIfNull(htmlContent);

        // left the method here for downward compatibility
        return HtmlHelper.ParseFeedUrlsFromHtml(htmlContent);
    }

    /// <summary>
    /// Reads a feed from an url. the url must be a feed. Use <see cref="GetFeedUrlsFromUrlAsync(string, CancellationToken)"/> 
    /// to parse the feeds from a url which is not a feed.
    /// </summary>
    /// <param name="url">the url to a feed</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <param name="userAgent">override built-in user-agent header</param>
    /// <returns>parsed feed</returns>
    public static async Task<Feed> ReadAsync(string url, string? userAgent = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        var feedContent = await HttpClientHelper.DownloadBytesAsync(Helpers.GetAbsoluteUrl(url), userAgent: userAgent, cancellationToken: cancellationToken).ConfigureAwait(false);
        return ReadFromByteArray(feedContent);
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
        return ReadFromByteArray(feedContent);
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
        return ReadFromByteArray(result);
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

    /// <summary>
    /// reads a feed from the bytearray <paramref name="feedContent"/>
    /// This could be useful if some special encoding is used.
    /// </summary>
    /// <param name="feedContent">The feed content as a byte[].</param>
    /// <returns>The parsed fee.</returns>
    public static Feed ReadFromByteArray(byte[] feedContent)
    {
        ArgumentNullException.ThrowIfNull(feedContent);

        return FeedParser.GetFeedFromBytes(feedContent);
    }
}
