using CodeHollow.FeedReader.Html;
using CodeHollow.FeedReader.Http;
using CodeHollow.FeedReader.Parser;

namespace CodeHollow.FeedReader;

/// <summary>
/// The FeedReader class allows to read feeds from a given url. Use it to parse a feed 
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
public class FeedReaderService : IFeedReaderService
{
    private readonly HttpClientService _httpClientService;

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="httpClientService"></param>
    public FeedReaderService(HttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }


    /// <summary>
    /// Reads a feed from an url. the url must be a feed. Use <see cref="ParseFeedUrlsAsStringAsync(string, CancellationToken)"/> 
    /// to parse the feeds from a url which is not a feed.
    /// </summary>
    /// <param name="url">the url to a feed</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <param name="userAgent">override built-in user-agent header</param>
    /// <returns>parsed feed</returns>
    public async Task<Feed> ReadAsync(string url, string? userAgent = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        var absoluteUrl = Helpers.GetAbsoluteUrl(url);

        var feedContentStream = await _httpClientService.DownloadStreamAsync(
            url: absoluteUrl,
            userAgent: userAgent,
            cancellationToken: cancellationToken
            )
            .ConfigureAwait(false);

        return await ReadFromMemoryStreamAsync(feedContentStream);
    }

    /// <summary>
    /// Instance API. Opens a webpage and reads all feed urls from it (link rel="alternate" type="application/...")
    /// </summary>
    /// <param name="url">the url of the page</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <returns>a list of links including the type and title, an empty list if no links are found</returns>
    /// <example>FeedReader.GetFeedUrlsFromUrl("codehollow.com"); // returns a list of all available feeds at
    /// https://codehollow.com </example>
    public async Task<IReadOnlyCollection<HtmlFeedLink>> GetFeedUrlsFromUrlAsync(string url, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        url = Helpers.GetAbsoluteUrl(url);
        string pageContent = await Helpers.DownloadAsync(url, cancellationToken: cancellationToken).ConfigureAwait(false);
        var links = HtmlHelper.ParseFeedUrlsFromHtml(pageContent);
        return links;
    }

    /// <summary>
    /// reads a feed from the bytearray <paramref name="feedContentStream"/>
    /// This could be useful if some special encoding is used.
    /// </summary>
    /// <param name="feedContentStream">The feed content as a MemoryStream.</param>
    /// <returns>The parsed feed.</returns>
    public static async Task<Feed> ReadFromMemoryStreamAsync(MemoryStream feedContentStream)
    {
        ArgumentNullException.ThrowIfNull(feedContentStream);

        return await FeedParser.GetFeedFromMemoryStreamAsync(feedContentStream);
    }
}
