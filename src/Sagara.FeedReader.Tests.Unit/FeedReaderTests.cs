using System.Net;
using System.Text;
using Microsoft.IO;
using Polly.Timeout;
using Sagara.FeedReader.Configuration;
using Sagara.FeedReader.Tests.Unit.Fakes;
using Xunit;

namespace Sagara.FeedReader.Tests.Unit;

public class FeedReaderTests
{
    private const string FeedUrl = "https://example.com/feed.xml";
    private const string PageUrl = "https://example.com/blog/post";

    private static CancellationToken CancellationToken => TestContext.Current.CancellationToken;


    #region GetFeedAsync: success

    [Fact]
    public async Task GetFeedAsync_Ok_ReturnsFeedWithStatusCodeAndFinalUri()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Ok());

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.True(result.IsSuccess, result.Error?.Message);
        Assert.Equal("Fake feed", result.Value.Title);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(new Uri(FeedUrl), result.FinalUri);
    }

    [Fact]
    public async Task GetFeedAsync_UriOverload_ReturnsFeed()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Ok());

        var result = await feedReader.GetFeedAsync(new Uri(FeedUrl), cancellationToken: CancellationToken);

        Assert.True(result.IsSuccess, result.Error?.Message);
    }

    [Fact]
    public async Task GetFeedAsync_Redirected_FinalUriIsRedirectTarget()
    {
        var redirectTarget = new Uri("https://feeds.example.net/moved.xml");
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.OkAfterRedirectTo(redirectTarget));

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.True(result.IsSuccess, result.Error?.Message);
        Assert.Equal(redirectTarget, result.FinalUri);
    }

    [Fact]
    public async Task GetFeedAsync_FeedServedAsTextHtml_StillParses()
    {
        // Misconfigured servers often serve feeds as text/html, so the content decides, not the Content-Type.
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Ok(mediaType: "text/html"));

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.True(result.IsSuccess, result.Error?.Message);
    }

    [Fact]
    public async Task GetFeedAsync_Iso88591Feed_DecodesDeclaredEncoding()
    {
        var feedBytes = await File.ReadAllBytesAsync("Feeds/Rss20ISO88591Intranet30.xml", CancellationToken);
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.OkWithContent(() => new ByteArrayContent(feedBytes)));

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.True(result.IsSuccess, result.Error?.Message);
        Assert.Equal("SVART MÅNAD - DÖDSOLYCKA i Vetlanda", result.Value.Items.First().Title);
    }

    #endregion


    #region GetFeedAsync: HTTP and content failures

    [Theory]
    [InlineData(HttpStatusCode.NotFound)]
    [InlineData(HttpStatusCode.Forbidden)]
    [InlineData(HttpStatusCode.Gone)]
    [InlineData(HttpStatusCode.InternalServerError)]
    public async Task GetFeedAsync_NonSuccessStatus_ReturnsHttpError(HttpStatusCode statusCode)
    {
        // A body that would parse as a feed, to prove the status code is checked before parsing.
        var handler = new FakeHttpMessageHandler(_ => new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(FakeHttpMessageHandler.MinimalRss20),
        });
        var feedReader = CreateFeedReader(handler);

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.HttpError, result.Error.Kind);
        Assert.Contains(((int)statusCode).ToString(System.Globalization.CultureInfo.InvariantCulture), result.Error.Message, StringComparison.Ordinal);
        Assert.Equal(statusCode, result.StatusCode);
        Assert.Equal(new Uri(FeedUrl), result.FinalUri);
    }

    [Fact]
    public async Task GetFeedAsync_HtmlPage_ReturnsNotAFeed()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Ok("<!doctype html><html><body>Hi</body></html>", "text/html"));

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.NotAFeed, result.Error.Kind);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(new Uri(FeedUrl), result.FinalUri);
    }

    [Fact]
    public async Task GetFeedAsync_MalformedXml_ReturnsInvalidXml()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Ok("<rss version=\"2.0\"><channel>"));

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.InvalidXml, result.Error.Kind);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task GetFeedAsync_RequestFails_ReturnsNetworkError()
    {
        var exception = new HttpRequestException("No such host is known.");
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Throws(exception));

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.NetworkError, result.Error.Kind);
        Assert.Same(exception, result.Error.Exception);
        Assert.Null(result.StatusCode);
        Assert.Null(result.FinalUri);
    }

    [Fact]
    public async Task GetFeedAsync_ConnectionDropsWhileReadingBody_ReturnsNetworkError()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.OkWithContent(() => new StreamContent(new ThrowingStream(new IOException("Connection reset.")))));

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.NetworkError, result.Error.Kind);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    #endregion


    #region GetFeedAsync: timeouts and cancellation

    [Fact]
    public async Task GetFeedAsync_NoResponseBeforeHttpClientTimeout_ReturnsTimeout()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Hangs(), timeout: TimeSpan.FromMilliseconds(100));

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.Timeout, result.Error.Kind);
        Assert.Null(result.StatusCode);
    }

    [Fact]
    public async Task GetFeedAsync_BodyStallsAfterHeaders_ReturnsTimeout()
    {
        // HttpClient.Timeout alone wouldn't catch this, because headers arrive promptly.
        var feedReader = CreateFeedReader(
            FakeHttpMessageHandler.OkWithContent(() => new StreamContent(new HangingStream("<rss version=\"2.0\">"u8.ToArray()))),
            timeout: TimeSpan.FromMilliseconds(200));

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.Timeout, result.Error.Kind);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(new Uri(FeedUrl), result.FinalUri);
    }

    [Fact]
    public async Task GetFeedAsync_PollyTimeoutRejected_ReturnsTimeout()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Throws(new TimeoutRejectedException()));

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.Timeout, result.Error.Kind);
    }

    [Fact]
    public async Task GetFeedAsync_CallerCancelsWhileWaiting_Throws()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Hangs(), timeout: Timeout.InfiniteTimeSpan);
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(CancellationToken);
        cts.CancelAfter(TimeSpan.FromMilliseconds(100));

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => feedReader.GetFeedAsync(FeedUrl, cancellationToken: cts.Token));
    }

    [Fact]
    public async Task GetFeedAsync_CallerCancelsWhileReadingBody_Throws()
    {
        var feedReader = CreateFeedReader(
            FakeHttpMessageHandler.OkWithContent(() => new StreamContent(new HangingStream("<rss"u8.ToArray()))),
            timeout: Timeout.InfiniteTimeSpan);
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(CancellationToken);
        cts.CancelAfter(TimeSpan.FromMilliseconds(100));

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => feedReader.GetFeedAsync(FeedUrl, cancellationToken: cts.Token));
    }

    [Fact]
    public async Task GetFeedAsync_AlreadyCancelled_Throws()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Ok());

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => feedReader.GetFeedAsync(FeedUrl, cancellationToken: new CancellationToken(canceled: true)));
    }

    #endregion


    #region GetFeedAsync: size limit

    [Fact]
    public async Task GetFeedAsync_ContentLengthOverLimit_ReturnsResponseTooLargeWithoutReadingBody()
    {
        var content = new TrackingContent(new string('x', 200));
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.OkWithContent(() => content), maxResponseBytes: 100);

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.ResponseTooLarge, result.Error.Kind);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.False(content.WasRead);
    }

    [Fact]
    public async Task GetFeedAsync_NoContentLengthAndBodyOverLimit_ReturnsResponseTooLarge()
    {
        // A non-seekable stream gives StreamContent no Content-Length, so the limit must be enforced while reading.
        var feedReader = CreateFeedReader(
            FakeHttpMessageHandler.OkWithContent(() => new StreamContent(new NonSeekableStream(new MemoryStream(new byte[200])))),
            maxResponseBytes: 100);

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.ResponseTooLarge, result.Error.Kind);
    }

    [Fact]
    public async Task GetFeedAsync_BodyExactlyAtLimit_Succeeds()
    {
        var feedBytes = Encoding.UTF8.GetBytes(FakeHttpMessageHandler.MinimalRss20);
        var feedReader = CreateFeedReader(
            FakeHttpMessageHandler.OkWithContent(() => new StreamContent(new NonSeekableStream(new MemoryStream(feedBytes)))),
            maxResponseBytes: feedBytes.Length);

        var result = await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        Assert.True(result.IsSuccess, result.Error?.Message);
    }

    #endregion


    #region Request shape

    // Percent-encoded characters that change a URL's meaning if decoded before the request is sent.
    public static TheoryData<string> UrlsWithEncodedCharacters => new()
    {
        "https://example.com/feed?q=a%26b",             // & would split the query value into two parameters
        "https://example.com/feed?q=a%2Bb",             // + would become a space
        "https://example.com/feed?redirect=%2Fother",   // / in a query value
        "https://example.com/feed?q=a%3Db",             // = would split the key/value pair
        "https://example.com/feed?q=50%25",             // a literal percent sign
        "https://example.com/feed?q=a+b",               // a literal + would become a space
        "https://example.com/path%2Fwith%2Fslashes/feed",
    };

    [Theory]
    [MemberData(nameof(UrlsWithEncodedCharacters))]
    public async Task GetFeedAsync_PreservesEncodedCharacters(string url)
    {
        var handler = FakeHttpMessageHandler.Ok();
        var feedReader = CreateFeedReader(handler);

        await feedReader.GetFeedAsync(url, cancellationToken: CancellationToken);

        var request = Assert.Single(handler.Requests);
        Assert.Equal(url, request.RequestUri!.AbsoluteUri);
    }

    [Theory]
    [MemberData(nameof(UrlsWithEncodedCharacters))]
    public async Task GetFeedUrlsFromPageAsync_PreservesEncodedCharacters(string url)
    {
        var handler = FakeHttpMessageHandler.Ok("<html></html>", "text/html");
        var feedReader = CreateFeedReader(handler);

        await feedReader.GetFeedUrlsFromPageAsync(url, cancellationToken: CancellationToken);

        var request = Assert.Single(handler.Requests);
        Assert.Equal(url, request.RequestUri!.AbsoluteUri);
    }

    [Fact]
    public async Task Requests_SendAcceptAndDefaultUserAgentHeaders()
    {
        var handler = FakeHttpMessageHandler.Ok();
        var feedReader = CreateFeedReader(handler);

        await feedReader.GetFeedAsync(FeedUrl, cancellationToken: CancellationToken);

        var request = Assert.Single(handler.Requests);
        Assert.Contains("application/xml", request.Headers.Accept.ToString(), StringComparison.Ordinal);
        Assert.Contains("Mozilla/5.0", request.Headers.UserAgent.ToString(), StringComparison.Ordinal);
    }

    [Fact]
    public async Task Requests_UserAgentOverride_IsSent()
    {
        var handler = FakeHttpMessageHandler.Ok("<html></html>", "text/html");
        var feedReader = CreateFeedReader(handler);

        await feedReader.GetFeedAsync(FeedUrl, userAgent: "MyFeedBot/1.0", cancellationToken: CancellationToken);
        await feedReader.GetFeedUrlsFromPageAsync(PageUrl, userAgent: "MyFeedBot/2.0", cancellationToken: CancellationToken);

        Assert.Equal(new[] { "MyFeedBot/1.0", "MyFeedBot/2.0" }, handler.Requests.Select(r => r.Headers.UserAgent.ToString()));
    }

    #endregion


    #region URL validation

    [Theory]
    [InlineData("example.com/feed.xml")]
    [InlineData("www.example.com")]
    [InlineData("example.com:8080/feed")]
    [InlineData("/feed.xml")]
    [InlineData("feed.xml")]
    [InlineData("ftp://example.com/feed.xml")]
    [InlineData("file:///c:/feeds/feed.xml")]
    [InlineData("mailto:someone@example.com")]
    [InlineData("")]
    [InlineData("   ")]
    public void InvalidUrlString_ThrowsArgumentException(string url)
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Ok());

        Assert.Throws<ArgumentException>("feedUrl", () => { _ = feedReader.GetFeedAsync(url, cancellationToken: CancellationToken); });
        Assert.Throws<ArgumentException>("pageUrl", () => { _ = feedReader.GetFeedUrlsFromPageAsync(url, cancellationToken: CancellationToken); });
    }

    [Fact]
    public void NullUrlString_ThrowsArgumentNullException()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Ok());

        Assert.Throws<ArgumentNullException>("feedUrl", () => { _ = feedReader.GetFeedAsync((string)null!, cancellationToken: CancellationToken); });
        Assert.Throws<ArgumentNullException>("pageUrl", () => { _ = feedReader.GetFeedUrlsFromPageAsync((string)null!, cancellationToken: CancellationToken); });
    }

    [Theory]
    [InlineData("/feed.xml", UriKind.Relative)]
    [InlineData("ftp://example.com/feed.xml", UriKind.Absolute)]
    public async Task InvalidUri_ThrowsArgumentException(string uriString, UriKind uriKind)
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Ok());
        var uri = new Uri(uriString, uriKind);

        await Assert.ThrowsAsync<ArgumentException>("feedUri", () => feedReader.GetFeedAsync(uri, cancellationToken: CancellationToken));
        await Assert.ThrowsAsync<ArgumentException>("pageUri", () => feedReader.GetFeedUrlsFromPageAsync(uri, cancellationToken: CancellationToken));
    }

    [Fact]
    public async Task NullUri_ThrowsArgumentNullException()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Ok());

        await Assert.ThrowsAsync<ArgumentNullException>("feedUri", () => feedReader.GetFeedAsync((Uri)null!, cancellationToken: CancellationToken));
        await Assert.ThrowsAsync<ArgumentNullException>("pageUri", () => feedReader.GetFeedUrlsFromPageAsync((Uri)null!, cancellationToken: CancellationToken));
    }

    [Theory]
    [InlineData("http://example.com/feed.xml")]
    [InlineData("HTTPS://EXAMPLE.COM/feed.xml")]
    [InlineData("https://example.com:8443/feed.xml")]
    [InlineData("https://xn--bcher-kva.example/feed")]
    public async Task ValidUrlString_IsAccepted(string url)
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Ok());

        var result = await feedReader.GetFeedAsync(url, cancellationToken: CancellationToken);

        Assert.True(result.IsSuccess, result.Error?.Message);
    }

    #endregion


    #region GetFeedUrlsFromPageAsync

    [Fact]
    public async Task GetFeedUrlsFromPageAsync_ResolvesRelativeLinksAgainstFinalUri()
    {
        const string html = """
            <html><head>
            <link rel="alternate" type="application/rss+xml" title="Root relative" href="/feed.xml">
            <link rel="alternate" type="application/atom+xml" title="Scheme relative" href="//cdn.example.net/atom.xml">
            <link rel="alternate" type="application/rss+xml" title="Path relative" href="comments/feed">
            <link rel="alternate" type="application/rss+xml" title="Absolute" href="https://other.example.org/rss">
            <link rel="alternate" type="application/rss+xml" title="Encoded &amp; query" href="/feed?a=1&amp;b=2">
            </head></html>
            """;
        var finalUri = new Uri("https://www.example.com/blog/post/");
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.OkAfterRedirectTo(finalUri, html, "text/html"));

        var result = await feedReader.GetFeedUrlsFromPageAsync(PageUrl, cancellationToken: CancellationToken);

        Assert.True(result.IsSuccess, result.Error?.Message);
        Assert.Equal(finalUri, result.FinalUri);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        (string?, string, FeedType)[] expectedLinks =
            [
                ("Root relative", "https://www.example.com/feed.xml", FeedType.Rss),
                ("Scheme relative", "https://cdn.example.net/atom.xml", FeedType.Atom),
                ("Path relative", "https://www.example.com/blog/post/comments/feed", FeedType.Rss),
                ("Absolute", "https://other.example.org/rss", FeedType.Rss),
                ("Encoded & query", "https://www.example.com/feed?a=1&b=2", FeedType.Rss),
            ];
        Assert.Equal(expectedLinks, result.Value.Select(l => (l.Title, l.Url, l.FeedType)));
    }

    [Fact]
    public async Task GetFeedUrlsFromPageAsync_PageWithoutFeedLinks_ReturnsEmptySuccess()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Ok("<html><head><title>No feeds</title></head></html>", "text/html"));

        var result = await feedReader.GetFeedUrlsFromPageAsync(PageUrl, cancellationToken: CancellationToken);

        Assert.True(result.IsSuccess, result.Error?.Message);
        Assert.Empty(result.Value);
    }

    [Fact]
    public async Task GetFeedUrlsFromPageAsync_NonSuccessStatus_ReturnsHttpError()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Respond(HttpStatusCode.Forbidden, "<html>Access denied</html>"));

        var result = await feedReader.GetFeedUrlsFromPageAsync(PageUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.HttpError, result.Error.Kind);
        Assert.Equal(HttpStatusCode.Forbidden, result.StatusCode);
    }

    [Fact]
    public async Task GetFeedUrlsFromPageAsync_RequestFails_ReturnsNetworkError()
    {
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Throws(new HttpRequestException("Connection refused.")));

        var result = await feedReader.GetFeedUrlsFromPageAsync(PageUrl, cancellationToken: CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.NetworkError, result.Error.Kind);
    }

    [Fact]
    public async Task GetFeedUrlsFromPageAsync_UsesContentTypeCharset()
    {
        const string html = "<html><head><link rel=\"alternate\" type=\"application/rss+xml\" title=\"Café Ñoño\" href=\"/feed\"></head></html>";
        var feedReader = CreateFeedReader(FakeHttpMessageHandler.Ok(html, "text/html", Encoding.Latin1));

        var result = await feedReader.GetFeedUrlsFromPageAsync(PageUrl, cancellationToken: CancellationToken);

        Assert.True(result.IsSuccess, result.Error?.Message);
        Assert.Equal("Café Ñoño", Assert.Single(result.Value).Title);
    }

    #endregion


    #region Construction

    [Fact]
    public void Constructor_NonPositiveMaxResponseBytes_Throws()
    {
        using var httpClient = new HttpClient(FakeHttpMessageHandler.Ok());

        Assert.Throws<ArgumentOutOfRangeException>(() => new FeedReader(httpClient, new RecyclableMemoryStreamManager(), new FeedReaderOptions { MaxResponseBytes = 0 }));
    }

    [Fact]
    public void Constructor_NullArguments_Throw()
    {
        using var httpClient = new HttpClient(FakeHttpMessageHandler.Ok());

        Assert.Throws<ArgumentNullException>("httpClient", () => new FeedReader(null!, new RecyclableMemoryStreamManager()));
        Assert.Throws<ArgumentNullException>("streamManager", () => new FeedReader(httpClient, null!));
    }

    #endregion


    //
    // Helpers
    //

    private static FeedReader CreateFeedReader(HttpMessageHandler handler, TimeSpan? timeout = null, long? maxResponseBytes = null)
    {
        var httpClient = new HttpClient(handler);
        if (timeout is not null)
        {
            httpClient.Timeout = timeout.Value;
        }

        var options = new FeedReaderOptions();
        if (maxResponseBytes is not null)
        {
            options.MaxResponseBytes = maxResponseBytes.Value;
        }

        return new FeedReader(httpClient, new RecyclableMemoryStreamManager(), options);
    }

    /// <summary>
    /// Content with a Content-Length that records whether its body was ever read.
    /// </summary>
    private sealed class TrackingContent : HttpContent
    {
        private readonly byte[] _bytes;

        public bool WasRead { get; private set; }

        public TrackingContent(string body)
        {
            _bytes = Encoding.UTF8.GetBytes(body);
            Headers.ContentLength = _bytes.Length;
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
        {
            WasRead = true;
            return stream.WriteAsync(_bytes, 0, _bytes.Length);
        }

        protected override Task<Stream> CreateContentReadStreamAsync()
        {
            WasRead = true;
            return Task.FromResult<Stream>(new MemoryStream(_bytes));
        }

        protected override bool TryComputeLength(out long length)
        {
            length = _bytes.Length;
            return true;
        }
    }

    /// <summary>
    /// A response body whose reads always fail, like a connection that drops mid-response.
    /// </summary>
    private sealed class ThrowingStream(Exception exception) : Stream
    {
        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();
        public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }

        public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default) => ValueTask.FromException<int>(exception);
        public override int Read(byte[] buffer, int offset, int count) => throw exception;
        public override void Flush() { }
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
    }
}
