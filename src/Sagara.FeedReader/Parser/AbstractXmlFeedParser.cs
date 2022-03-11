namespace Sagara.FeedReader.Parser;

using System.Xml.Linq;
using Feeds;

internal abstract class AbstractXmlFeedParser : IFeedParser
{
    public BaseFeed Parse(string feedXml)
    {
        XDocument feedDoc = XDocument.Parse(feedXml);

        return this.Parse(feedXml, feedDoc);
    }

    public abstract BaseFeed Parse(string feedXml, XDocument feedDoc);
}
