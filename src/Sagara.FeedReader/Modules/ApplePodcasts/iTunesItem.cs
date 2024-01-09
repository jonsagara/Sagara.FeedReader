using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Modules.ApplePodcasts;

/// <summary>
/// <para>Item data from an iTunes channel in either RSS 2.0 or Atom.</para>
/// <para>In RSS 2.0, this is direct child elements of the <c>channel</c> element, each within the <c>itunes</c> namespace.</para>
/// <para>In Atom, this is direct child elements of the <c>feed</c> element, each within the <c>im</c> namespace.</para>
/// </summary>
/// <remarks>
/// <para>See this article for RSS 2.0 requirements: https://help.apple.com/itc/podcasts_connect/#/itcb54353390</para>
/// <para>Apple no longer accepts Atom feeds for podcasts, so I don't see <c>im</c> documented anywhere.</para>
/// </remarks>
public class iTunesItem
{
    /// <summary>
    /// <para>The duration of an episode.</para>
    /// <para>Different duration formats are accepted however it is recommended to convert the length of the episode into seconds.</para>
    /// </summary>
    public TimeSpan? Duration { get; set; }

    /// <summary>
    /// <para>The episode artwork specified as a URL linking to it.</para>
    /// <para>You should use this tag when you have a high quality, episode-specific image you would like listeners to see.</para>
    /// </summary>
    public iTunesImage? Image { get; set; }

    /// <summary>
    /// <para>The episode parental advisory information.</para>
    /// <para><c>true</c> indicates the presence of explicit content.</para>
    /// <para><c>false</c> indicates that the media doesn't contain explicit language or adult content.</para>
    /// </summary>
    public bool Explicit { get; set; }

    /// <summary>
    /// The episode title specific for Apple Podcasts.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// <para>An episode number.</para>
    /// <para>If all your episodes have numbers and you would like them to be ordered based on them, use this tag for each one.</para>
    /// <para>Episode numbers are optional for &lt;itunes:type&gt; episodic shows, but are mandatory for serial shows.</para>
    /// <para>Where <c>episode</c> is a non-zero integer (1, 2, 3, etc.) representing your episode number.</para>
    /// </summary>
    public int? Episode { get; set; }

    /// <summary>
    /// <para>The episode season number.</para>
    /// <para>If an episode is within a season use this tag.</para>
    /// <para>Where <c>season</c> is a non-zero integer (1, 2, 3, etc.) representing your season number.</para>
    /// </summary>
    public int? Season { get; set; }

    /// <summary>
    /// <para>The episode type.</para>
    /// <para>If an episode is a trailer or bonus content, use this tag.</para>
    /// <para>Where the <c>episodeType</c> value can be one of the following:</para>
    /// <list type="bullet">
    /// <item>
    /// <term>Full</term>
    /// <description>Default. Specify full when you are submitting the complete content of your show.</description>
    /// </item>
    /// <item>
    /// <term>Trailer</term>
    /// <description>Specify trailer when you are submitting a short, promotional piece of content that represents a preview of your 
    /// current show.</description>
    /// </item>
    /// <item>
    /// <term>Bonus</term>
    /// <description>Specify bonus when you are submitting extra content for your show (for example, behind the scenes information 
    /// or interviews with the cast) or cross-promotional content for another show.</description>
    /// </item>
    /// </list>
    /// </summary>
    public iTunesEpisodeType? EpisodeType { get; set; }

    /// <summary>
    /// <para>The episode show or hide status.</para>
    /// <para>If you want an episode removed from the Apple directory, use this tag.</para>
    /// <para>Specifying the &lt;itunes:block&gt; tag with a Yes value prevents that episode from appearing in Apple Podcasts.</para>
    /// <para>Specifying any value other than <c>Yes</c> has no effect.</para>
    /// </summary>
    public bool Block { get; set; }


    /// <summary>
    /// .ctor
    /// </summary>
    public iTunesItem(XElement itemElement)
    {
        ArgumentNullException.ThrowIfNull(itemElement);

        var duration = itemElement.GetChildElementValue(iTunesChannel.NamespacePrefix, "duration");
        Duration = ParseDuration(duration);

        var imageElement = itemElement.GetElement(iTunesChannel.NamespacePrefix, "image");
        if (imageElement is not null)
        {
            Image = new iTunesImage(imageElement);
        }

        var explicitValue = itemElement.GetChildElementValue(iTunesChannel.NamespacePrefix, "explicit");
        Explicit = iTunesHelper.IsExplicit(explicitValue);

        // Some feeds have itunes:subtitle elements, but the Apple Podcasts RSS spec makes no mention of subtitle.
        Title = itemElement.GetChildElementValue(namespacePrefix: iTunesChannel.NamespacePrefix, elementName: "title");

        if (int.TryParse(itemElement.GetChildElementValue(namespacePrefix: iTunesChannel.NamespacePrefix, elementName: "episode"), out int episode))
        {
            Episode = episode;
        }

        if (int.TryParse(itemElement.GetChildElementValue(namespacePrefix: iTunesChannel.NamespacePrefix, elementName: "season"), out int season))
        {
            Season = season;
        }

        EpisodeType = ParseEpisodeType(itemElement);

        Block = itemElement.GetChildElementValue(iTunesChannel.NamespacePrefix, "block").EqualsIgnoreCase("yes");

        /* old code
        // These fields no longer appear in the latest Apple Podcasts RSS spec.
        Author = itemElement.GetChildElementValue(iTunesChannel.NAMESPACEPREFIX, "author");

        IsClosedCaptioned = itemElement.GetChildElementValue(iTunesChannel.NAMESPACEPREFIX, "isClosedCaptioned").EqualsIgnoreCase("yes");

        if (int.TryParse(itemElement.GetChildElementValue(iTunesChannel.NAMESPACEPREFIX, "order"), out var order))
        {
            Order = order;
        }

        // Some feeds have itunes:subtitle and itunes:summary elements, but the Apple Podcasts RSS spec makes no mention of them.
        Subtitle = itemElement.GetChildElementValue(iTunesChannel.NAMESPACEPREFIX, "subtitle");
        Summary = itemElement.GetChildElementValue(iTunesChannel.NAMESPACEPREFIX, "summary");
        */
    }


    //
    // Private methods
    //

    private static TimeSpan? ParseDuration(string? duration)
    {
        if (string.IsNullOrWhiteSpace(duration))
        {
            return null;
        }


        //
        // We don't expect there to ever be more than two colons in the string: HH:MM:SS. However, allow for 4 elements
        //   in the array so that we know, since there are more than 3, we don't know what this value is and we shouldn't
        //   try to parse it into a TimeSpan.
        //

        var durationSpan = duration.AsSpan();

        Span<Range> durationParts = stackalloc Range[4];
        var durationPartsWritten = durationSpan.Split(destination: durationParts, ':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        if (durationPartsWritten == 1 && int.TryParse(durationSpan[durationParts[0]], out int durationSeconds))
        {
            // The value was a single number. Assume it's seconds.
            return TimeSpan.FromSeconds(durationSeconds);
        }

        if (durationPartsWritten == 2
            && int.TryParse(durationSpan[durationParts[0]], out int durationMinutes)
            && int.TryParse(durationSpan[durationParts[1]], out durationSeconds))
        {
            // The value was MM:SS.
            return new TimeSpan(hours: 0, minutes: durationMinutes, seconds: durationSeconds);
        }

        if (durationPartsWritten == 3
            && int.TryParse(durationSpan[durationParts[0]], out int durationHours)
            && int.TryParse(durationSpan[durationParts[1]], out durationMinutes)
            && int.TryParse(durationSpan[durationParts[2]], out durationSeconds))
        {
            // The value was HH:MM:SS.
            return new TimeSpan(hours: durationHours, minutes: durationMinutes, seconds: durationSeconds);
        }

        // Unknown or unsupported duration value.
        return null;
    }

    private static iTunesEpisodeType? ParseEpisodeType(XElement itemElement)
    {
        var typeElement = itemElement.GetChildElementValue(namespacePrefix: iTunesChannel.NamespacePrefix, elementName: "episodeType");
        if (string.IsNullOrWhiteSpace(typeElement))
        {
            // If not present, assume the default value of Episodic.
            return iTunesEpisodeType.Full;
        }

        if (!Enum.TryParse(typeElement, out iTunesEpisodeType episodeType))
        {
            // Can't parse it into an enum. Don't assume any default value.
#warning TODO: logging?
            return null;
        }

        if (!Enum.IsDefined(episodeType))
        {
            // Not a valid enum value. Don't assume any default value.
            return null;
        }

        // Parsed and a valid enum value. Return it as-is.
        return episodeType;
    }
}
