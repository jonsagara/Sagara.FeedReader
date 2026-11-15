namespace Sagara.FeedReader;

/// <summary>
/// Downloads and parses feeds from URLs, and finds the feeds a web page links to.
/// </summary>
/// <remarks>
/// <para>Register the default implementation with <c>services.AddFeedReaderServices()</c>, then inject <see cref="IFeedReader"/>.</para>
/// <para>Methods return a <see cref="FeedReaderResult{T}"/> instead of throwing when a request fails or the content can't
/// be parsed. They throw only for invalid arguments, and <see cref="OperationCanceledException"/> when the caller's
/// cancellation token is cancelled.</para>
/// </remarks>
public interface IFeedReader
{
    /// <summary>
    /// Download and parse the feed at <paramref name="feedUrl"/>. The URL must point to a feed, not an HTML page; use
    /// <see cref="GetFeedUrlsFromPageAsync(string, string?, CancellationToken)"/> to find a page's feeds.
    /// </summary>
    /// <param name="feedUrl">The absolute http or https URL of the feed, e.g., https://example.com/feed.xml.</param>
    /// <param name="userAgent">The User-Agent header for this request. If null, <see cref="Configuration.FeedReaderOptions.DefaultUserAgent"/> is used.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A successful result with the parsed feed, or a failed result that says why.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="feedUrl"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="feedUrl"/> is not an absolute http or https URL.</exception>
    /// <exception cref="OperationCanceledException"><paramref name="cancellationToken"/> was cancelled.</exception>
    Task<FeedReaderResult<Feed>> GetFeedAsync(string feedUrl, string? userAgent = null, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetFeedAsync(string, string?, CancellationToken)"/>
    /// <param name="feedUri">The absolute http or https URI of the feed.</param>
    /// <param name="userAgent">The User-Agent header for this request. If null, <see cref="Configuration.FeedReaderOptions.DefaultUserAgent"/> is used.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <exception cref="ArgumentNullException"><paramref name="feedUri"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="feedUri"/> is not an absolute http or https URI.</exception>
    /// <exception cref="OperationCanceledException"><paramref name="cancellationToken"/> was cancelled.</exception>
    Task<FeedReaderResult<Feed>> GetFeedAsync(Uri feedUri, string? userAgent = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Download the web page at <paramref name="pageUrl"/> and return the feeds it links to with
    /// &lt;link rel="alternate" type="application/rss+xml" /&gt; or type="application/atom+xml" tags.
    /// </summary>
    /// <remarks>
    /// Relative links are resolved against the page's final URL after redirects, so every returned URL is absolute.
    /// </remarks>
    /// <param name="pageUrl">The absolute http or https URL of the page, e.g., https://example.com/.</param>
    /// <param name="userAgent">The User-Agent header for this request. If null, <see cref="Configuration.FeedReaderOptions.DefaultUserAgent"/> is used.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A successful result with the feed links (empty if the page has none), or a failed result that says why.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="pageUrl"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="pageUrl"/> is not an absolute http or https URL.</exception>
    /// <exception cref="OperationCanceledException"><paramref name="cancellationToken"/> was cancelled.</exception>
    Task<FeedReaderResult<IReadOnlyCollection<HtmlFeedLink>>> GetFeedUrlsFromPageAsync(string pageUrl, string? userAgent = null, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetFeedUrlsFromPageAsync(string, string?, CancellationToken)"/>
    /// <param name="pageUri">The absolute http or https URI of the page.</param>
    /// <param name="userAgent">The User-Agent header for this request. If null, <see cref="Configuration.FeedReaderOptions.DefaultUserAgent"/> is used.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <exception cref="ArgumentNullException"><paramref name="pageUri"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="pageUri"/> is not an absolute http or https URI.</exception>
    /// <exception cref="OperationCanceledException"><paramref name="cancellationToken"/> was cancelled.</exception>
    Task<FeedReaderResult<IReadOnlyCollection<HtmlFeedLink>>> GetFeedUrlsFromPageAsync(Uri pageUri, string? userAgent = null, CancellationToken cancellationToken = default);
}
