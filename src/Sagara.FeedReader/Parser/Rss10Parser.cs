using System.Xml.Linq;
using Sagara.FeedReader.Extensions;
using Sagara.FeedReader.Feeds;

namespace Sagara.FeedReader.Parser;

internal sealed class Rss10Parser : AbstractXmlFeedParser
{
    public override BaseFeed Parse(string feedXml, XDocument feedDoc)
    {
        ArgumentNullException.ThrowIfNull(feedXml);
        ArgumentNullException.ThrowIfNull(feedDoc);

        // There has to be a root element, or else XDocument.Parse would have thrown.
        var rdf = feedDoc.Root!;

        // Ensure there is a channel element. It doesn't make sense to try to parse an RSS feed
        //   without one.
        var channel = rdf.GetElement("channel");
        if (channel is null)
        {
            throw new FeedParseException(FeedReaderErrorKind.ParseError, $"The feed does not contain a <channel> element, so it cannot be parsed as {nameof(Rss10Feed)}.");
        }

        return new Rss10Feed(feedXml, feedDoc, channel);
    }
}
