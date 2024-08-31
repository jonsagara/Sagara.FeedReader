using System.Globalization;

namespace Sagara.FeedReader.Modules.WordPressExport;

/// <summary>
/// <para>Extension methods that further parse the feed XML for WordPress Export-specific content.</para>
/// </summary>
/// <remarks>
/// <para>See: https://wordpress.com/support/export/#about-export-files</para>
/// <para>Schema: http://wordpress.org/export/1.2/</para>
/// </remarks>
public static class WordPressExportExtensions
{
    /// <summary>
    /// Reads WordPress Export elements from a <c>channel</c> (RSS 2.0) or <c>feed</c> (Atom) element.
    /// </summary>
    /// <param name="feed">The parsed RSS 2.0 or Atom <see cref="Feed" />.</param>
    public static WordPressExportChannel GetWordPressExportChannel(this Feed feed)
    {
        ArgumentNullException.ThrowIfNull(feed);

        return new WordPressExportChannel(feed.SpecificFeed!.ChannelOrFeedElement!);
    }

    /// <summary>
    /// Reads WordPress Export post elements content from a <c>item</c> (RSS 2.0) or <c>entry</c> (Atom) element.
    /// </summary>
    /// <param name="item">The parsed RSS 2.0 or Atom <see cref="FeedItem"/>.</param>
    public static WordPressExportItem GetWordPressExportItem(this FeedItem item)
    {
        ArgumentNullException.ThrowIfNull(item);

        return new WordPressExportItem(item.SpecificItem!.ItemOrEntryElement!);
    }


    internal static DateTime? ParseUtcOrDefault(this string? value)
        => DateTime.TryParse(value, null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out DateTime dtResult)
        ? dtResult
        : null;

    internal static bool? ParseWordPressBooleanOrDefault(this string? value)
        => value switch
        {
            "0" => false,
            "1" => true,
            _ => null,
        };
}
