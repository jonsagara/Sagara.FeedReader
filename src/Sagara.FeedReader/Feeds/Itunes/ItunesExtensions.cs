namespace Sagara.FeedReader.Feeds.Itunes;

/// <summary>
/// Extension methods that further parse the feed XML for iTunes-specific content.
/// </summary>
public static class ItunesExtensions
{
    /// <summary>
    /// Reads iTunes content from a <c>channel</c> (RSS 2.0) or <c>feed</c> (Atom) element.
    /// </summary>
    /// <param name="feed">The parsed RSS 2.0 or Atom <see cref="Feed" />.</param>
    public static ItunesChannel GetItunesChannel(this Feed feed)
    {
        ArgumentNullException.ThrowIfNull(feed);

        return new ItunesChannel(feed.SpecificFeed!.ChannelOrFeedElement!);
    }

    /// <summary>
    /// Reads iTunes content from a <c>item</c> (RSS 2.0) or <c>entry</c> (Atom) element.
    /// </summary>
    /// <param name="item">The parsed RSS 2.0 or Atom <see cref="FeedItem"/>.</param>
    public static ItunesItem GetItunesItem(this FeedItem item)
    {
        ArgumentNullException.ThrowIfNull(item);

        return new ItunesItem(item.SpecificItem!.ItemOrEntryElement!);
    }
}
