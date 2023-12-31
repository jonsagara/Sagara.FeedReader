﻿namespace Sagara.FeedReader.Modules.ApplePodcasts;

/// <summary>
/// Extension methods that further parse the feed XML for iTunes-specific content.
/// </summary>
public static class iTunesExtensions
{
    /// <summary>
    /// Reads Apple Podcast show elements from a <c>channel</c> (RSS 2.0) or <c>feed</c> (Atom) element.
    /// </summary>
    /// <param name="feed">The parsed RSS 2.0 or Atom <see cref="Feed" />.</param>
    public static iTunesChannel GetiTunesChannel(this Feed feed)
    {
        ArgumentNullException.ThrowIfNull(feed);

        return new iTunesChannel(feed.SpecificFeed!.ChannelOrFeedElement!);
    }

    /// <summary>
    /// Reads Apple Podcast episode elements content from a <c>item</c> (RSS 2.0) or <c>entry</c> (Atom) element.
    /// </summary>
    /// <param name="item">The parsed RSS 2.0 or Atom <see cref="FeedItem"/>.</param>
    public static iTunesItem GetiTunesItem(this FeedItem item)
    {
        ArgumentNullException.ThrowIfNull(item);

        return new iTunesItem(item.SpecificItem!.ItemOrEntryElement!);
    }
}
