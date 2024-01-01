using Sagara.FeedReader.Html;
using Sagara.FeedReader.Http;
using Sagara.FeedReader.Parser;

namespace Sagara.FeedReader;

/// <summary>
/// The FeedReader class allows to read feeds from a given url. Use it to parse a feed 
/// from an url <see cref="ReadAsync(string, string?, CancellationToken)"/>, a file <see cref="ReadFromFileAsync(string)"/>, 
/// or a string <see cref="ReadFromString(string)"/>. If the feed url is not known, <see cref="GetFeedUrlsFromPageAsync(string, CancellationToken)"/> 
/// returns all feed links on a given page.
/// </summary>
/// <example>
/// var links = FeedReader.ParseFeedUrlsFromHtml("https://codehollow.com");
/// var firstLink = links.First();
/// var feed = FeedReader.Read(firstLink.Url);
/// Console.WriteLine(feed.Title);
/// </example>
public class FeedReader : IFeedReaderService
{
    private readonly HttpClientService _httpClientService;

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="httpClientService"></param>
    public FeedReader(HttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }


    /// <summary>
    /// Reads a feed from an url. The url MUST be a feed, and not an HTML page URL.
    /// </summary>
    /// <remarks>
    /// Use <see cref="GetFeedUrlsFromPageAsync(string, CancellationToken)"/> to parse the feeds from a url which is not a feed.
    /// </remarks>
    /// <param name="feedUrl">The url to a feed</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <param name="userAgent">override built-in user-agent header</param>
    /// <returns>parsed feed</returns>
    public async Task<Feed> ReadAsync(string feedUrl, string? userAgent = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(feedUrl);

        var absoluteUrl = Helpers.GetAbsoluteUrl(feedUrl);

        using var feedContentStream = await _httpClientService
            .DownloadStreamAsync(
                url: absoluteUrl,
                userAgent: userAgent,
                cancellationToken: cancellationToken
            )
            .ConfigureAwait(false);

        return await ReadFromStreamAsync(feedContentStream).ConfigureAwait(false);
    }

    /// <summary>
    /// Reads a feed from the Stream <paramref name="feedContentStream"/>
    /// This could be useful if some special encoding is used.
    /// </summary>
    /// <remarks>Marked as static because it doesn't rely on HttpClient to get the desired data.</remarks>
    /// <param name="feedContentStream">The feed content as a Stream.</param>
    /// <returns>The parsed feed.</returns>
    public static async Task<Feed> ReadFromStreamAsync(Stream feedContentStream)
    {
        ArgumentNullException.ThrowIfNull(feedContentStream);

        return await FeedParser
            .GetFeedFromStreamAsync(feedContentStream)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Reads a feed from a file.
    /// </summary>
    /// <remarks>Marked as static because it doesn't rely on HttpClient to get the desired data.</remarks>
    /// <param name="filePath">the path to the feed file</param>
    /// <returns>parsed feed</returns>
    public static async Task<Feed> ReadFromFileAsync(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);

        using var fileStream = File.OpenRead(filePath);

        return await FeedParser
            .GetFeedFromStreamAsync(fileStream)
            .ConfigureAwait(false);
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
    /// Opens a webpage and reads all feed urls from link tags within it (&lt;link rel="alternate" type="application/..." /&gt;).
    /// </summary>
    /// <param name="pageUrl">the url of the page</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <returns>A list of links including the type and title, an empty list if no links are found</returns>
    public async Task<IReadOnlyCollection<HtmlFeedLink>> GetFeedUrlsFromPageAsync(string pageUrl, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(pageUrl);

        var absolutePageUrl = Helpers.GetAbsoluteUrl(pageUrl);

        var pageHtml = await _httpClientService
            .DownloadStringAsync(
                url: absolutePageUrl,
                cancellationToken: cancellationToken
            )
            .ConfigureAwait(false);

        return HtmlHelper.ParseFeedUrlsFromHtml(pageHtml);
    }
}
