namespace CodeHollow.FeedReader.Parser;

using System.Xml.Linq;
using CodeHollow.FeedReader.Extensions;
using Feeds;

internal class Rss092Parser : AbstractXmlFeedParser
{
    public override BaseFeed Parse(string feedXml, XDocument feedDoc)
    {
        var rss = feedDoc.Root;
        var channel = rss.GetElement("channel");
        Rss092Feed feed = new Rss092Feed(feedXml, channel);
        return feed;
    }
}
