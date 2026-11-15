using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;
using Microsoft.IO;
using Microsoft.Net.Http.Headers;
using Polly.Timeout;
using Sagara.FeedReader.Configuration;
using Sagara.FeedReader.Html;
using Sagara.FeedReader.Http;

namespace Sagara.FeedReader;

/// <summary>
/// The default <see cref="IFeedReader"/>: downloads and parses feeds from URLs, and finds the feeds a web page links to.
/// </summary>
/// <remarks>
/// <para>Register it with <c>services.AddFeedReaderServices()</c> and inject <see cref="IFeedReader"/>. To use it without
/// dependency injection, pass it an <see cref="HttpClient"/> configured the way you want (e.g., with automatic decompression).</para>
/// <para>To parse a feed from content you already have, such as a file or a string, use <see cref="FeedParser"/>.</para>
/// </remarks>
public sealed class FeedReader : IFeedReader
{
    private const int CopyBufferSize = 81_920;

    private readonly HttpClient _httpClient;
    private readonly RecyclableMemoryStreamManager _streamManager;
    private readonly long _maxResponseBytes;
    private readonly string _defaultUserAgent;

    /// <summary>
    /// Initializes a new <see cref="FeedReader"/>.
    /// </summary>
    /// <param name="httpClient">The HttpClient used to make requests. Its <see cref="HttpClient.Timeout"/> applies to the
    /// whole download, including reading the response body.</param>
    /// <param name="streamManager">Provides pooled memory streams for buffering responses.</param>
    /// <param name="options">Optional. Only <see cref="FeedReaderOptions.MaxResponseBytes"/> and <see cref="FeedReaderOptions.DefaultUserAgent"/>
    /// are used here; the other options configure the HttpClient registered by <c>AddFeedReaderServices</c>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="httpClient"/> or <paramref name="streamManager"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><see cref="FeedReaderOptions.MaxResponseBytes"/> is not positive.</exception>
    public FeedReader(HttpClient httpClient, RecyclableMemoryStreamManager streamManager, FeedReaderOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(streamManager);

        var maxResponseBytes = options?.MaxResponseBytes ?? FeedReaderOptions.DefaultMaxResponseBytes;
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxResponseBytes, $"{nameof(options)}.{nameof(FeedReaderOptions.MaxResponseBytes)}");

        _httpClient = httpClient;
        _streamManager = streamManager;
        _maxResponseBytes = maxResponseBytes;
        _defaultUserAgent = string.IsNullOrWhiteSpace(options?.DefaultUserAgent)
            ? FeedReaderHttpRequestHeaderValues.DefaultUserAgent
            : options.DefaultUserAgent;
    }


    /// <inheritdoc/>
    public Task<FeedReaderResult<Feed>> GetFeedAsync(string feedUrl, string? userAgent = null, CancellationToken cancellationToken = default)
        => GetFeedAsync(ToHttpUri(feedUrl, nameof(feedUrl)), userAgent, cancellationToken);

    /// <inheritdoc/>
    public async Task<FeedReaderResult<Feed>> GetFeedAsync(Uri feedUri, string? userAgent = null, CancellationToken cancellationToken = default)
    {
        ThrowIfNotHttpUri(feedUri, nameof(feedUri));

        var download = await DownloadAsync(feedUri, userAgent, cancellationToken).ConfigureAwait(false);
        if (download.HasError)
        {
            return FeedReaderResult.Failure<Feed>(download.Error, download.StatusCode, download.FinalUri);
        }

        await using (download.Content.ConfigureAwait(false))
        {
            var parseResult = await FeedParser.TryParseAsync(download.Content, cancellationToken).ConfigureAwait(false);

            return parseResult.IsSuccess
                ? FeedReaderResult.Success(parseResult.Value, download.StatusCode, download.FinalUri)
                : FeedReaderResult.Failure<Feed>(parseResult.Error, download.StatusCode, download.FinalUri);
        }
    }

    /// <inheritdoc/>
    public Task<FeedReaderResult<IReadOnlyCollection<HtmlFeedLink>>> GetFeedUrlsFromPageAsync(string pageUrl, string? userAgent = null, CancellationToken cancellationToken = default)
        => GetFeedUrlsFromPageAsync(ToHttpUri(pageUrl, nameof(pageUrl)), userAgent, cancellationToken);

    /// <inheritdoc/>
    public async Task<FeedReaderResult<IReadOnlyCollection<HtmlFeedLink>>> GetFeedUrlsFromPageAsync(Uri pageUri, string? userAgent = null, CancellationToken cancellationToken = default)
    {
        ThrowIfNotHttpUri(pageUri, nameof(pageUri));

        var download = await DownloadAsync(pageUri, userAgent, cancellationToken).ConfigureAwait(false);
        if (download.HasError)
        {
            return FeedReaderResult.Failure<IReadOnlyCollection<HtmlFeedLink>>(download.Error, download.StatusCode, download.FinalUri);
        }

        string pageHtml;
        await using (download.Content.ConfigureAwait(false))
        {
            using var reader = new StreamReader(download.Content, download.Encoding ?? Encoding.UTF8, detectEncodingFromByteOrderMarks: true, leaveOpen: true);
            pageHtml = await reader.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
        }

        var feedLinks = HtmlHelper.ParseFeedUrlsFromHtml(pageHtml, download.FinalUri);

        return FeedReaderResult.Success(feedLinks, download.StatusCode, download.FinalUri);
    }


    //
    // Private methods
    //

    /// <summary>
    /// Download the content at <paramref name="uri"/> into a pooled memory stream, or return why that failed.
    /// </summary>
    private async Task<Download> DownloadAsync(Uri uri, string? userAgent, CancellationToken cancellationToken)
    {
        // With ResponseHeadersRead, HttpClient.Timeout stops applying once the headers arrive. Apply it to the whole
        //   download so that a server that trickles out the body can't hang us forever.
        using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeoutCts.CancelAfter(_httpClient.Timeout);

        HttpStatusCode? statusCode = null;
        Uri? finalUri = null;
        RecyclableMemoryStream? content = null;

        try
        {
            using var request = CreateRequestMessage(uri, userAgent);
            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, timeoutCts.Token).ConfigureAwait(false);

            statusCode = response.StatusCode;
            finalUri = response.RequestMessage?.RequestUri ?? uri;

            if (!response.IsSuccessStatusCode)
            {
                return Download.Failed(
                    new FeedReaderError(FeedReaderErrorKind.HttpError, $"The server returned {(int)response.StatusCode} {response.ReasonPhrase}."),
                    statusCode, finalUri);
            }

            if (response.Content.Headers.ContentLength > _maxResponseBytes)
            {
                return Download.Failed(CreateResponseTooLargeError(), statusCode, finalUri);
            }

            content = _streamManager.GetStream(nameof(DownloadAsync));

            var responseStream = await response.Content.ReadAsStreamAsync(timeoutCts.Token).ConfigureAwait(false);
            await using (responseStream.ConfigureAwait(false))
            {
                if (!await CopyWithLimitAsync(responseStream, content, timeoutCts.Token).ConfigureAwait(false))
                {
                    return Download.Failed(CreateResponseTooLargeError(), statusCode, finalUri);
                }
            }

            content.Position = 0L;

            var succeeded = Download.Succeeded(content, GetEncoding(response), statusCode.Value, finalUri);

            // The caller owns the stream now.
            content = null;

            return succeeded;
        }
        catch (OperationCanceledException ex) when (!cancellationToken.IsCancellationRequested)
        {
            // The caller didn't cancel, so either HttpClient.Timeout or our whole-download timeout expired.
            return Download.Failed(CreateTimeoutError(ex), statusCode, finalUri);
        }
        catch (TimeoutRejectedException ex)
        {
            // A Polly timeout strategy in a caller-configured resilience pipeline expired.
            return Download.Failed(CreateTimeoutError(ex), statusCode, finalUri);
        }
        catch (HttpRequestException ex)
        {
            return Download.Failed(new FeedReaderError(FeedReaderErrorKind.NetworkError, $"The request failed: {ex.Message}", ex), statusCode, finalUri);
        }
        catch (IOException ex)
        {
            // E.g., the connection was closed while reading the response body.
            return Download.Failed(new FeedReaderError(FeedReaderErrorKind.NetworkError, $"Reading the response failed: {ex.Message}", ex), statusCode, finalUri);
        }
        finally
        {
            if (content is not null)
            {
                await content.DisposeAsync().ConfigureAwait(false);
            }
        }
    }

    /// <summary>
    /// Copy <paramref name="source"/> to <paramref name="destination"/>, stopping early if it exceeds the size limit.
    /// </summary>
    /// <returns>True if the whole source was copied; false if it was larger than the limit.</returns>
    private async Task<bool> CopyWithLimitAsync(Stream source, Stream destination, CancellationToken cancellationToken)
    {
        var buffer = ArrayPool<byte>.Shared.Rent(CopyBufferSize);
        try
        {
            long totalBytes = 0L;
            int bytesRead;

            while ((bytesRead = await source.ReadAsync(buffer.AsMemory(), cancellationToken).ConfigureAwait(false)) > 0)
            {
                totalBytes += bytesRead;
                if (totalBytes > _maxResponseBytes)
                {
                    return false;
                }

                await destination.WriteAsync(buffer.AsMemory(0, bytesRead), cancellationToken).ConfigureAwait(false);
            }

            return true;
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    private FeedReaderError CreateResponseTooLargeError()
        => new(FeedReaderErrorKind.ResponseTooLarge, $"The response is larger than the maximum of {_maxResponseBytes:N0} bytes.");

    private FeedReaderError CreateTimeoutError(Exception ex)
        => new(FeedReaderErrorKind.Timeout, $"The request timed out after {_httpClient.Timeout}.", ex);

    /// <summary>
    /// Create the <see cref="HttpRequestMessage"/> used to request a feed or page.
    /// </summary>
    private HttpRequestMessage CreateRequestMessage(Uri uri, string? userAgent)
    {
        // NOTE: Do not URL-decode the url. It changes the meaning of encoded characters, e.g., %26 in
        //   a query string value becomes &, which splits the value into two parameters.
        HttpRequestMessage requestMsg = new(HttpMethod.Get, uri);

        requestMsg.Headers.TryAddWithoutValidation(HeaderNames.Accept, FeedReaderHttpRequestHeaderValues.Accept);
        requestMsg.Headers.TryAddWithoutValidation(HeaderNames.UserAgent, userAgent ?? _defaultUserAgent);

        return requestMsg;
    }

    /// <summary>
    /// The encoding named by the response's Content-Type charset, or null if there is none or it's not recognized.
    /// </summary>
    private static Encoding? GetEncoding(HttpResponseMessage response)
    {
        var charset = response.Content.Headers.ContentType?.CharSet?.Trim('"', '\'', ' ');
        if (string.IsNullOrEmpty(charset))
        {
            return null;
        }

        try
        {
            return Encoding.GetEncoding(charset);
        }
        catch (ArgumentException)
        {
            return null;
        }
    }

    /// <summary>
    /// Parse <paramref name="url"/> as an absolute http or https URI.
    /// </summary>
    private static Uri ToHttpUri(string url, string paramName)
    {
        ArgumentNullException.ThrowIfNull(url, paramName);

        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || !IsHttpOrHttps(uri))
        {
            throw new ArgumentException($"'{url}' is not an absolute http or https URL. Include the scheme, e.g., https://example.com/feed.xml.", paramName);
        }

        return uri;
    }

    private static void ThrowIfNotHttpUri(Uri uri, string paramName)
    {
        ArgumentNullException.ThrowIfNull(uri, paramName);

        if (!uri.IsAbsoluteUri || !IsHttpOrHttps(uri))
        {
            throw new ArgumentException($"'{uri}' is not an absolute http or https URI.", paramName);
        }
    }

    internal static bool IsHttpOrHttps(Uri uri)
        => uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps;


    /// <summary>
    /// The outcome of a download: either content to read, or an error.
    /// </summary>
    private sealed class Download
    {
        [MemberNotNullWhen(true, nameof(Error))]
        [MemberNotNullWhen(false, nameof(Content), nameof(FinalUri))]
        public bool HasError => Error is not null;

        public RecyclableMemoryStream? Content { get; private init; }
        public Encoding? Encoding { get; private init; }
        public FeedReaderError? Error { get; private init; }
        public HttpStatusCode? StatusCode { get; private init; }
        public Uri? FinalUri { get; private init; }

        public static Download Succeeded(RecyclableMemoryStream content, Encoding? encoding, HttpStatusCode statusCode, Uri finalUri)
            => new() { Content = content, Encoding = encoding, StatusCode = statusCode, FinalUri = finalUri };

        public static Download Failed(FeedReaderError error, HttpStatusCode? statusCode, Uri? finalUri)
            => new() { Error = error, StatusCode = statusCode, FinalUri = finalUri };
    }
}
