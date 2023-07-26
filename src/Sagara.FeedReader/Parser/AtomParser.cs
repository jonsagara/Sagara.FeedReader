﻿namespace Sagara.FeedReader.Parser;

using System.Xml.Linq;
using Feeds;

internal sealed class AtomParser : AbstractXmlFeedParser
{
    public override BaseFeed Parse(string feedXml, XDocument feedDoc)
    {
        ArgumentNullException.ThrowIfNull(feedXml);
        ArgumentNullException.ThrowIfNull(feedDoc);

        // There has to be a root element, or else XDocument.Parse would have thrown.
        return new AtomFeed(feedXml, feedDoc.Root!);
    }
}
