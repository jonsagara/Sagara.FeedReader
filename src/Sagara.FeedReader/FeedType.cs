namespace Sagara.FeedReader;

/// <summary>
/// The type of the feed (RSS 0.91, RSS 2.0, Atom, ...)
/// </summary>
public enum FeedType
{
    /// <summary>
    /// Atom feed
    /// </summary>
    Atom,

    /// <summary>
    /// RSS 0.91 feed
    /// </summary>
    Rss_0_91,

    /// <summary>
    /// RSS 0.92 feed
    /// </summary>
    Rss_0_92,

    /// <summary>
    /// RSS 1.0 feed
    /// </summary>
    Rss_1_0,

    /// <summary>
    /// RSS 2.0 feed
    /// </summary>
    Rss_2_0,

    /// <summary>
    /// Media RSS feed
    /// </summary>
    MediaRss,

    /// <summary>
    /// RSS feed - is used for <see cref="HtmlFeedLink"/> type
    /// </summary>
    Rss,

    /// <summary>
    /// Unknown - default type
    /// </summary>
    Unknown,
}
