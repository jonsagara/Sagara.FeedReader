namespace Sagara.FeedReader.Modules.iTunes;

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
    public string? Image { get; set; }

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
    public string? Episode { get; set; }

    /// <summary>
    /// <para>The episode season number.</para>
    /// <para>If an episode is within a season use this tag.</para>
    /// <para>Where <c>season</c> is a non-zero integer (1, 2, 3, etc.) representing your season number.</para>
    /// </summary>
    public string? Season { get; set; }

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
    public string? EpisodeType { get; set; }

    /// <summary>
    /// <para>The episode show or hide status.</para>
    /// <para>If you want an episode removed from the Apple directory, use this tag.</para>
    /// <para>Specifying the &lt;itunes:block&gt; tag with a Yes value prevents that episode from appearing in Apple Podcasts.</para>
    /// <para>Specifying any value other than <c>Yes</c> has no effect.</para>
    /// </summary>
    public bool Block { get; set; }
}
