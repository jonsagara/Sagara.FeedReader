using System.Xml.Linq;
using Sagara.FeedReader.Feeds;

namespace Sagara.FeedReader.Parser;

internal abstract class AbstractXmlFeedParser
{
    public abstract BaseFeed Parse(string feedXml, XDocument feedDoc);
}
