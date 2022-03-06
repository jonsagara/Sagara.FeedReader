namespace CodeHollow.FeedReader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CodeHollow.FeedReader.Extensions;
using Parser;

/// <summary>
/// The static FeedReader class which allows to read feeds from a given url. Use it to parse a feed 
/// from an url <see cref="ReadAsync(string, bool, string?, CancellationToken)"/>, a file <see cref="ReadFromFile(string)"/> 
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
    /// Returns the absolute url of a link on a page. If you got the feed links via
    /// GetFeedUrlsFromUrl(url) and the url is relative, you can use this method to get the full url.
    /// </summary>
    /// <param name="pageUrl">the original url to the page</param>
    /// <param name="feedLink">a referenced feed (link)</param>
    /// <returns>a feed link</returns>
    /// <example>GetAbsoluteFeedUrl("codehollow.com", myRelativeFeedLink);</example>
    public static HtmlFeedLink GetAbsoluteFeedUrl(string pageUrl, HtmlFeedLink feedLink)
    {
        ArgumentNullException.ThrowIfNull(pageUrl);
        ArgumentNullException.ThrowIfNull(feedLink);
        ArgumentNullException.ThrowIfNull(feedLink.Url);

        string tmpUrl = feedLink.Url.HtmlDecode()!;
        pageUrl = GetAbsoluteUrl(pageUrl);

        if (tmpUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
            || tmpUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            return feedLink;
        }

        if (tmpUrl.StartsWith("//", StringComparison.OrdinalIgnoreCase)) // special case
        {
            tmpUrl = "http:" + tmpUrl;
        }

        if (Uri.TryCreate(tmpUrl, UriKind.RelativeOrAbsolute, out Uri? finalUri))
        {
            if (finalUri.IsAbsoluteUri)
            {
                return new HtmlFeedLink(feedLink.Title.HtmlDecode(), finalUri.ToString(), feedLink.FeedType);
            }
            else if (Uri.TryCreate(pageUrl + '/' + tmpUrl.TrimStart('/'), UriKind.Absolute, out finalUri))
            {
                return new HtmlFeedLink(feedLink.Title.HtmlDecode(), finalUri.ToString(), feedLink.FeedType);
            }
        }

        throw new UrlNotFoundException($"Could not get the absolute url out of {pageUrl} and {feedLink.Url}");
    }

    /// <summary>
    /// Opens a webpage and reads all feed urls from it (link rel="alternate" type="application/...")
    /// </summary>
    /// <param name="url">the url of the page</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <param name="autoRedirect">autoredirect if page is moved permanently</param>
    /// <returns>a list of links including the type and title, an empty list if no links are found</returns>
    /// <example>FeedReader.GetFeedUrlsFromUrl("codehollow.com"); // returns a list of all available feeds at
    /// https://codehollow.com </example>
    public static async Task<IEnumerable<HtmlFeedLink>> GetFeedUrlsFromUrlAsync(string url, bool autoRedirect = true, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        url = GetAbsoluteUrl(url);
        string pageContent = await Helpers.DownloadAsync(url, autoRedirect: autoRedirect, cancellationToken: cancellationToken).ConfigureAwait(false);
        var links = ParseFeedUrlsFromHtml(pageContent);
        return links;
    }

    /// <summary>
    /// Opens a webpage and reads all feed urls from it (link rel="alternate" type="application/...")
    /// </summary>
    /// <param name="url">the url of the page</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <returns>a list of links, an empty list if no links are found</returns>
    public static async Task<IReadOnlyCollection<string>> ParseFeedUrlsAsStringAsync(string url, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        return (await GetFeedUrlsFromUrlAsync(url, cancellationToken: cancellationToken).ConfigureAwait(false))
            .Select(x => x.Url)
            .ToArray();
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
        return Helpers.ParseFeedUrlsFromHtml(htmlContent);
    }

    /// <summary>
    /// Reads a feed from an url. the url must be a feed. Use <see cref="ParseFeedUrlsAsStringAsync(string, CancellationToken)"/> 
    /// to parse the feeds from a url which is not a feed.
    /// </summary>
    /// <param name="url">the url to a feed</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <param name="autoRedirect">autoredirect if page is moved permanently</param>
    /// <param name="userAgent">override built-in user-agent header</param>
    /// <returns>parsed feed</returns>
    public static async Task<Feed> ReadAsync(string url, bool autoRedirect = true, string? userAgent = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        var feedContent = await Helpers.DownloadBytesAsync(GetAbsoluteUrl(url), autoRedirect: autoRedirect, userAgent: userAgent, cancellationToken: cancellationToken).ConfigureAwait(false);
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
    /// reads a feed from the <paramref name="feedContent" />
    /// </summary>
    /// <param name="feedContent">the feed content (xml)</param>
    /// <returns>parsed feed</returns>
    public static Feed ReadFromString(string feedContent)
    {
        ArgumentNullException.ThrowIfNull(feedContent);

        return FeedParser.GetFeedFromString(feedContent);
    }

    /// <summary>
    /// reads a feed from the bytearray <paramref name="feedContent"/>
    /// This could be useful if some special encoding is used.
    /// </summary>
    /// <param name="feedContent"></param>
    /// <returns></returns>
    public static Feed ReadFromByteArray(byte[] feedContent)
    {
        ArgumentNullException.ThrowIfNull(feedContent);

        return FeedParser.GetFeedFromBytes(feedContent);
    }


    //
    // Private methods
    //

    /// <summary>
    /// Takes a url (with or without http) and returns the full url.
    /// </summary>
    /// <param name="url">Url with or without http.</param>
    /// <returns>Tull url</returns>
    /// <example>GetUrl("codehollow.com"); => returns https://codehollow.com</example>
    private static string GetAbsoluteUrl(string url)
        => new UriBuilder(url).Uri.ToString();
}
