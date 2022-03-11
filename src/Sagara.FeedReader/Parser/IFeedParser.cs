using Sagara.FeedReader.Feeds;

namespace Sagara.FeedReader.Parser;

internal interface IFeedParser
{
    BaseFeed Parse(string feedXml);
}
