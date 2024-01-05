using Sagara.FeedReader.Parser;
using Xunit;

namespace Sagara.FeedReader.Tests.Unit;

public class FeedParserTests
{
    [Fact]
    public async Task GetEncodingFromXmlFragment_UTF8()
    {
        using var feedContentStream = File.OpenRead(@"Feeds/Rss20MicrosoftBotFramework.xml");
        var feed = await FeedParser.GetFeedFromStreamAsync(feedContentStream);

        Assert.NotNull(feed);
    }

    [Fact]
    public async Task GetEncodingFromXmlFragment_UTF16()
    {
        using var feedContentStream = File.OpenRead(@"Feeds/Rss20MicrosoftBotFrameworkUTF16.xml");
        var feed = await FeedParser.GetFeedFromStreamAsync(feedContentStream);

        Assert.NotNull(feed);
    }
}
