using Sagara.FeedReader.Html;
using Sagara.FeedReader.Http;

namespace Sagara.FeedReader;

/// <summary>
/// Downloads and parses feeds from URLs. Use <see cref="ReadFromUrlAsync(string, string?, CancellationToken)"/> to read
/// a feed from its URL. If the feed URL is not known, <see cref="GetFeedUrlsFromPageAsync(string, CancellationToken)"/>
/// returns all feed links on a given page.
/// </summary>
/// <remarks>
/// To parse a feed from content you already have, such as a file or a string, use <see cref="FeedParser"/>.
/// </remarks>
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
    /// <param name="userAgent">override built-in user-agent header</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>parsed feed</returns>
    public async Task<Feed> ReadFromUrlAsync(string feedUrl, string? userAgent = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(feedUrl);

        var absoluteUrl = Helpers.GetAbsoluteUrl(feedUrl);

        using var feedContentStream = await _httpClientService
            .DownloadStreamAsync(url: absoluteUrl, userAgent: userAgent, cancellationToken)
            .ConfigureAwait(false);

        return await FeedParser.ParseAsync(feedContentStream, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Opens a webpage and reads all feed urls from link tags within it (&lt;link rel="alternate" type="application/..." /&gt;).
    /// </summary>
    /// <param name="pageUrl">the url of the page</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A list of links including the type and title, an empty list if no links are found</returns>
    public async Task<IReadOnlyCollection<HtmlFeedLink>> GetFeedUrlsFromPageAsync(string pageUrl, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(pageUrl);

        var absolutePageUrl = Helpers.GetAbsoluteUrl(pageUrl);

        var pageHtml = await _httpClientService
            .DownloadStringAsync(url: absolutePageUrl, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return HtmlHelper.ParseFeedUrlsFromHtml(pageHtml);
    }
}
