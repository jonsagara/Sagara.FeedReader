using System.Text;
using Sagara.FeedReader.Tests.Unit.Fakes;
using Xunit;

namespace Sagara.FeedReader.Tests.Unit;

public class FeedParserTests
{
    // Declared encoding is ISO-8859-1, so parsing it requires re-reading the stream with that encoding.
    private const string Iso88591FeedPath = "Feeds/Rss20ISO88591Intranet30.xml";
    private const string Iso88591FirstItemTitle = "SVART MÅNAD - DÖDSOLYCKA i Vetlanda";

    private const string MinimalRss20 = "<rss version=\"2.0\"><channel><title>Minimal</title></channel></rss>";


    #region Encoding

    [Fact]
    public async Task GetEncodingFromXmlFragment_UTF8()
    {
        using var feedContentStream = File.OpenRead(@"Feeds/Rss20MicrosoftBotFramework.xml");
        var feed = await FeedParser.ParseAsync(feedContentStream, TestContext.Current.CancellationToken);

        Assert.NotNull(feed);
    }

    [Fact]
    public async Task GetEncodingFromXmlFragment_UTF16()
    {
        using var feedContentStream = File.OpenRead(@"Feeds/Rss20MicrosoftBotFrameworkUTF16.xml");
        var feed = await FeedParser.ParseAsync(feedContentStream, TestContext.Current.CancellationToken);

        Assert.NotNull(feed);
    }

    #endregion


    #region Stream handling

    [Fact]
    public async Task ParseAsync_NonSeekableStream_Parses()
    {
        using var stream = new NonSeekableStream(File.OpenRead(@"Feeds/Rss20MicrosoftBotFramework.xml"));

        var feed = await FeedParser.ParseAsync(stream, TestContext.Current.CancellationToken);

        Assert.False(string.IsNullOrEmpty(feed.Title));
        Assert.NotEmpty(feed.Items);
    }

    [Fact]
    public async Task ParseAsync_NonSeekableStreamWithNonUtf8Encoding_RereadsWithDeclaredEncoding()
    {
        using var stream = new NonSeekableStream(File.OpenRead(Iso88591FeedPath));

        var feed = await FeedParser.ParseAsync(stream, TestContext.Current.CancellationToken);

        Assert.Equal(Iso88591FirstItemTitle, feed.Items.First().Title);
    }

    [Fact]
    public async Task ParseAsync_StreamNotAtStart_ReadsFromCurrentPosition()
    {
        using var stream = CreateStreamWithPrefix(File.ReadAllBytes(@"Feeds/Rss20MicrosoftBotFramework.xml"), out var feedStartPosition);
        stream.Position = feedStartPosition;

        var feed = await FeedParser.ParseAsync(stream, TestContext.Current.CancellationToken);

        Assert.False(string.IsNullOrEmpty(feed.Title));
    }

    [Fact]
    public async Task ParseAsync_StreamNotAtStartWithNonUtf8Encoding_RereadsFromStartPosition()
    {
        using var stream = CreateStreamWithPrefix(File.ReadAllBytes(Iso88591FeedPath), out var feedStartPosition);
        stream.Position = feedStartPosition;

        var feed = await FeedParser.ParseAsync(stream, TestContext.Current.CancellationToken);

        Assert.Equal(Iso88591FirstItemTitle, feed.Items.First().Title);
    }

    [Fact]
    public async Task ParseAsync_DoesNotDisposeStream()
    {
        using var stream = File.OpenRead(@"Feeds/Rss20MicrosoftBotFramework.xml");

        await FeedParser.ParseAsync(stream, TestContext.Current.CancellationToken);

        Assert.True(stream.CanRead);
    }

    #endregion


    #region Invalid content

    [Theory]
    [InlineData("")]
    [InlineData("   \r\n\t ")]
    public async Task EmptyContent_ThrowsInvalidXml(string content)
    {
        await AssertParseFailsAsync(content, FeedReaderErrorKind.InvalidXml);
    }

    [Theory]
    [InlineData("<rss version=\"2.0\"><channel><title>Unclosed</channel></rss>")]
    [InlineData("this is not xml")]
    [InlineData("{\"version\": \"https://jsonfeed.org/version/1.1\"}")]
    public async Task MalformedXml_ThrowsInvalidXml(string content)
    {
        var ex = await AssertParseFailsAsync(content, FeedReaderErrorKind.InvalidXml);

        Assert.IsType<System.Xml.XmlException>(ex.InnerException);
    }

    [Theory]
    [InlineData("<foo><bar/></foo>")]
    [InlineData("<?xml version=\"1.0\"?><opml version=\"2.0\"><body/></opml>")]
    public async Task UnknownRootElement_ThrowsUnsupportedFeedType(string content)
    {
        await AssertParseFailsAsync(content, FeedReaderErrorKind.UnsupportedFeedType);
    }

    [Theory]
    [InlineData("<rss version=\"2.0\"/>")]
    [InlineData("<rss version=\"0.91\"/>")]
    [InlineData("<rss version=\"0.92\"/>")]
    [InlineData("<rss version=\"2.0\" xmlns:media=\"http://search.yahoo.com/mrss/\"/>")]
    [InlineData("<rdf:RDF xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\"/>")]
    public async Task SupportedRootWithoutChannel_ThrowsParseError(string content)
    {
        var ex = await AssertParseFailsAsync(content, FeedReaderErrorKind.ParseError);

        Assert.Contains("<channel>", ex.Message, StringComparison.Ordinal);
    }

    [Fact]
    public async Task ParseErrorMessage_DoesNotIncludeFeedContent()
    {
        // These messages used to embed the entire feed, which could be megabytes.
        var ex = await AssertParseFailsAsync("<rss version=\"2.0\"><notachannel>MARKER_FROM_FEED_CONTENT</notachannel></rss>", FeedReaderErrorKind.ParseError);

        Assert.DoesNotContain("MARKER_FROM_FEED_CONTENT", ex.Message, StringComparison.Ordinal);
    }

    #endregion


    #region TryParse

    [Fact]
    public void TryParse_ValidFeed_ReturnsSuccess()
    {
        var result = FeedParser.TryParse(MinimalRss20);

        Assert.True(result.IsSuccess);
        Assert.Equal("Minimal", result.Value.Title);
        Assert.Null(result.Error);
        Assert.Null(result.StatusCode);
        Assert.Null(result.FinalUri);
    }

    [Fact]
    public async Task TryParseAsync_ValidFeed_ReturnsSuccess()
    {
        using var stream = File.OpenRead(Iso88591FeedPath);

        var result = await FeedParser.TryParseAsync(stream, TestContext.Current.CancellationToken);

        Assert.True(result.IsSuccess);
        Assert.Equal(Iso88591FirstItemTitle, result.Value.Items.First().Title);
    }

    [Fact]
    public void TryParse_NullString_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => FeedParser.TryParse(null!));
    }

    [Fact]
    public async Task TryParseAsync_NullStream_ThrowsArgumentNullException()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => FeedParser.TryParseAsync(null!, TestContext.Current.CancellationToken));
    }

    [Fact]
    public async Task TryParseAsync_CancelledToken_ThrowsOperationCanceledException()
    {
        using var stream = ToStream(MinimalRss20);

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => FeedParser.TryParseAsync(stream, new CancellationToken(canceled: true)));
    }

    #endregion


    #region HTML content

    [Theory]
    // HTML5 doctype, not well-formed XML (what https://apod.nasa.gov/apod.rss now redirects to).
    [InlineData("<!doctype html>\n<html lang=\"en-US\"><head><meta charset=\"UTF-8\"></head><body><br></body></html>")]
    // XML declaration + XHTML doctype, not well-formed (what https://blog.adobe.com/feed.xml returns with its 404).
    [InlineData("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\n<html><body><hr></body></html>")]
    // Comment before the root element.
    [InlineData("<!-- generated -->\n<html><body><p>Hi</p></body></html>")]
    // Well-formed XHTML with no doctype, which gets past the quick check and is caught by the root element check.
    [InlineData("<?xml version=\"1.0\"?><x:html xmlns:x=\"http://www.w3.org/1999/xhtml\"><x:body/></x:html>")]
    public async Task HtmlContent_ThrowsNotAFeed(string content)
    {
        await AssertParseFailsAsync(content, FeedReaderErrorKind.NotAFeed);
    }

    [Theory]
    [InlineData("Html/codehollow.html")]
    [InlineData("Html/heise.html")]
    [InlineData("Html/japantimes.html")]
    [InlineData("Html/orf.html")]
    [InlineData("Html/stackoverflow.html")]
    [InlineData("Html/stadtfeuerwehrweiz.html")]
    [InlineData("Html/theverge.html")]
    public async Task RealHtmlPages_ThrowNotAFeed(string path)
    {
        await AssertParseFailsAsync(File.ReadAllText(path), FeedReaderErrorKind.NotAFeed);
    }

    [Fact]
    public void FeedMentioningHtmlInItsContent_IsNotMistakenForHtml()
    {
        var feed = FeedParser.Parse(
            "<rss version=\"2.0\"><channel><title>Feed</title><item><description><![CDATA[<html><body>Hi</body></html>]]></description></item></channel></rss>");

        Assert.Equal("Feed", feed.Title);
    }

    #endregion


    #region Lenient parsing

    [Fact]
    public void RssWithoutVersionAttribute_ParsesAsRss()
    {
        var feed = FeedParser.Parse("<rss><channel><title>No version</title><item><title>Item 1</title></item></channel></rss>");

        Assert.Equal("No version", feed.Title);
        Assert.Equal("Item 1", Assert.Single(feed.Items).Title);
    }

    #endregion


    #region Arguments and cancellation

    [Fact]
    public async Task ParseAsync_NullStream_ThrowsArgumentNullException()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => FeedParser.ParseAsync(null!, TestContext.Current.CancellationToken));
    }

    [Fact]
    public void Parse_NullString_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => FeedParser.Parse(null!));
    }

    [Fact]
    public async Task ParseAsync_CancelledToken_ThrowsOperationCanceledException()
    {
        using var stream = ToStream(MinimalRss20);

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => FeedParser.ParseAsync(stream, new CancellationToken(canceled: true)));
    }

    [Fact]
    public async Task ParseAsync_NonSeekableStreamWithCancelledToken_ThrowsOperationCanceledException()
    {
        using var stream = new NonSeekableStream(ToStream(MinimalRss20));

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => FeedParser.ParseAsync(stream, new CancellationToken(canceled: true)));
    }

    #endregion


    //
    // Helpers
    //

    /// <summary>
    /// Assert that all four entry points fail with the expected kind: Parse and ParseAsync throw, and
    /// TryParse and TryParseAsync return a failed result.
    /// </summary>
    private static async Task<FeedParseException> AssertParseFailsAsync(string content, FeedReaderErrorKind expectedKind)
    {
        var stringEx = Assert.Throws<FeedParseException>(() => FeedParser.Parse(content));
        Assert.Equal(expectedKind, stringEx.Kind);

        using var stream = ToStream(content);
        var streamEx = await Assert.ThrowsAsync<FeedParseException>(() => FeedParser.ParseAsync(stream, TestContext.Current.CancellationToken));
        Assert.Equal(expectedKind, streamEx.Kind);

        AssertFailedResult(FeedParser.TryParse(content), expectedKind);

        using var tryStream = ToStream(content);
        AssertFailedResult(await FeedParser.TryParseAsync(tryStream, TestContext.Current.CancellationToken), expectedKind);

        return streamEx;
    }

    private static void AssertFailedResult(FeedReaderResult<Feed> result, FeedReaderErrorKind expectedKind)
    {
        Assert.False(result.IsSuccess);
        Assert.Null(result.Value);
        Assert.Equal(expectedKind, result.Error.Kind);
        Assert.False(string.IsNullOrEmpty(result.Error.Message));

        var exception = Assert.IsType<FeedParseException>(result.Error.Exception);
        Assert.Equal(expectedKind, exception.Kind);

        Assert.Null(result.StatusCode);
        Assert.Null(result.FinalUri);
    }

    private static MemoryStream ToStream(string content)
        => new(Encoding.UTF8.GetBytes(content));

    /// <summary>
    /// Returns a stream containing some junk bytes followed by <paramref name="feedBytes"/>.
    /// </summary>
    private static MemoryStream CreateStreamWithPrefix(byte[] feedBytes, out long feedStartPosition)
    {
        var prefix = "JUNK BEFORE THE FEED THAT MUST NOT BE READ"u8.ToArray();
        feedStartPosition = prefix.Length;

        var stream = new MemoryStream();
        stream.Write(prefix);
        stream.Write(feedBytes);

        return stream;
    }
}
