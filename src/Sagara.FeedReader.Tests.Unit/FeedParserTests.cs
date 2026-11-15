using System.Text;
using Sagara.FeedReader.Parser;
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
        var feed = await FeedParser.GetFeedFromStreamAsync(feedContentStream, TestContext.Current.CancellationToken);

        Assert.NotNull(feed);
    }

    [Fact]
    public async Task GetEncodingFromXmlFragment_UTF16()
    {
        using var feedContentStream = File.OpenRead(@"Feeds/Rss20MicrosoftBotFrameworkUTF16.xml");
        var feed = await FeedParser.GetFeedFromStreamAsync(feedContentStream, TestContext.Current.CancellationToken);

        Assert.NotNull(feed);
    }

    #endregion


    #region Stream handling

    [Fact]
    public async Task GetFeedFromStreamAsync_NonSeekableStream_Parses()
    {
        using var stream = new NonSeekableStream(File.OpenRead(@"Feeds/Rss20MicrosoftBotFramework.xml"));

        var feed = await FeedParser.GetFeedFromStreamAsync(stream, TestContext.Current.CancellationToken);

        Assert.False(string.IsNullOrEmpty(feed.Title));
        Assert.NotEmpty(feed.Items);
    }

    [Fact]
    public async Task GetFeedFromStreamAsync_NonSeekableStreamWithNonUtf8Encoding_RereadsWithDeclaredEncoding()
    {
        using var stream = new NonSeekableStream(File.OpenRead(Iso88591FeedPath));

        var feed = await FeedParser.GetFeedFromStreamAsync(stream, TestContext.Current.CancellationToken);

        Assert.Equal(Iso88591FirstItemTitle, feed.Items.First().Title);
    }

    [Fact]
    public async Task GetFeedFromStreamAsync_StreamNotAtStart_ReadsFromCurrentPosition()
    {
        using var stream = CreateStreamWithPrefix(File.ReadAllBytes(@"Feeds/Rss20MicrosoftBotFramework.xml"), out var feedStartPosition);
        stream.Position = feedStartPosition;

        var feed = await FeedParser.GetFeedFromStreamAsync(stream, TestContext.Current.CancellationToken);

        Assert.False(string.IsNullOrEmpty(feed.Title));
    }

    [Fact]
    public async Task GetFeedFromStreamAsync_StreamNotAtStartWithNonUtf8Encoding_RereadsFromStartPosition()
    {
        using var stream = CreateStreamWithPrefix(File.ReadAllBytes(Iso88591FeedPath), out var feedStartPosition);
        stream.Position = feedStartPosition;

        var feed = await FeedParser.GetFeedFromStreamAsync(stream, TestContext.Current.CancellationToken);

        Assert.Equal(Iso88591FirstItemTitle, feed.Items.First().Title);
    }

    [Fact]
    public async Task GetFeedFromStreamAsync_DoesNotDisposeStream()
    {
        using var stream = File.OpenRead(@"Feeds/Rss20MicrosoftBotFramework.xml");

        await FeedParser.GetFeedFromStreamAsync(stream, TestContext.Current.CancellationToken);

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
        var feed = FeedParser.GetFeedFromString(
            "<rss version=\"2.0\"><channel><title>Feed</title><item><description><![CDATA[<html><body>Hi</body></html>]]></description></item></channel></rss>");

        Assert.Equal("Feed", feed.Title);
    }

    #endregion


    #region Lenient parsing

    [Fact]
    public void RssWithoutVersionAttribute_ParsesAsRss()
    {
        var feed = FeedParser.GetFeedFromString("<rss><channel><title>No version</title><item><title>Item 1</title></item></channel></rss>");

        Assert.Equal("No version", feed.Title);
        Assert.Equal("Item 1", Assert.Single(feed.Items).Title);
    }

    #endregion


    #region Arguments and cancellation

    [Fact]
    public async Task GetFeedFromStreamAsync_NullStream_ThrowsArgumentNullException()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => FeedParser.GetFeedFromStreamAsync(null!, TestContext.Current.CancellationToken));
    }

    [Fact]
    public void GetFeedFromString_NullString_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => FeedParser.GetFeedFromString(null!));
    }

    [Fact]
    public async Task GetFeedFromStreamAsync_CancelledToken_ThrowsOperationCanceledException()
    {
        using var stream = ToStream(MinimalRss20);

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => FeedParser.GetFeedFromStreamAsync(stream, new CancellationToken(canceled: true)));
    }

    [Fact]
    public async Task GetFeedFromStreamAsync_NonSeekableStreamWithCancelledToken_ThrowsOperationCanceledException()
    {
        using var stream = new NonSeekableStream(ToStream(MinimalRss20));

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => FeedParser.GetFeedFromStreamAsync(stream, new CancellationToken(canceled: true)));
    }

    #endregion


    //
    // Helpers
    //

    /// <summary>
    /// Assert that both the string and the stream entry points fail with the expected kind.
    /// </summary>
    private static async Task<FeedParseException> AssertParseFailsAsync(string content, FeedReaderErrorKind expectedKind)
    {
        var stringEx = Assert.Throws<FeedParseException>(() => FeedParser.GetFeedFromString(content));
        Assert.Equal(expectedKind, stringEx.Kind);

        using var stream = ToStream(content);
        var streamEx = await Assert.ThrowsAsync<FeedParseException>(() => FeedParser.GetFeedFromStreamAsync(stream, TestContext.Current.CancellationToken));
        Assert.Equal(expectedKind, streamEx.Kind);

        return streamEx;
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
