namespace Sagara.FeedReader.Modules.iTunes;

/// <summary>
/// <para>Data from an iTunes channel in either RSS 2.0 or Atom.</para>
/// <para>In RSS 2.0, this is direct child elements of the <c>channel</c> element, each within the <c>itunes</c> namespace.</para>
/// <para>In Atom, this is direct child elements of the <c>feed</c> element, each within the <c>im</c> namespace.</para>
/// </summary>
/// <remarks>
/// <para>See this article for RSS 2.0 requirements: https://help.apple.com/itc/podcasts_connect/#/itcb54353390</para>
/// <para>Apple no longer accepts Atom feeds for podcasts, so I don't see <c>im</c> documented anywhere.</para>
/// </remarks>
public class iTunesChannel
{
    internal const string NamespacePrefix = "itunes";


    /// <summary>
    /// The artwork for the show specified as a URL linking to it.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// <para>The show category information. For a complete list of categories and subcategories, see https://podcasters.apple.com/support/1691-apple-podcasts-categories.</para>
    /// <para>A category may contain an optional subcategory.</para>
    /// <para>A feed may specify multiple categories.</para>
    /// </summary>
    public IReadOnlyCollection<iTunesCategory> Categories { get; private set; } = Array.Empty<iTunesCategory>();

    /// <summary>
    /// <para>The podcast parental advisory information.</para>
    /// <para><c>true</c> indicates the presence of explicit content.</para>
    /// <para><c>false</c> indicates that the media doesn't contain explicit language or adult content.</para>
    /// </summary>
    public bool Explicit { get; set; }

    /// <summary>
    /// <para>The group responsible for creating the media.</para>
    /// <para>Show author most often refers to the parent company or network of a podcast, but it can also be 
    /// used to identify the host(s) if none exists.</para>
    /// <para>Author information is especially useful if a company or organization publishes multiple podcasts.</para>
    /// </summary>
    public string? Author { get; set; }

    /// <summary>
    /// <para>The podcast owner contact information.</para>
    /// </summary>
    /// <remarks>
    /// Note: The &lt;itunes:owner&gt; tag information is for administrative communication about the podcast and 
    /// isn't displayed in Apple Podcasts. Please make sure the email address is active and monitored.
    /// </remarks>
    public iTunesOwner? Owner { get; set; }

    /// <summary>
    /// The show title specific for Apple Podcasts.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// <para>The type of show.</para>
    /// <para>If your show is Serial you must use this tag.</para>
    /// </summary>
    /// <remarks>
    /// <para>The values can be one of the following:</para>
    /// <list type="bullet">
    /// <item>
    /// <term>Episodic</term>
    /// <description>Default. Specify episodic when episodes are intended to be consumed without any specific order.</description>
    /// </item>
    /// <item>
    /// <term>Serial</term>
    /// <description>Specify serial when episodes are intended to be consumed in sequential order.</description>
    /// </item>
    /// </list>
    /// </remarks>
    public string? Type { get; set; }

    /// <summary>
    /// <para>The new podcast RSS Feed URL.</para>
    /// <para>If you change the URL of your podcast feed, you should use this tag in your new feed.</para>
    /// </summary>
    public string? NewFeedUrl { get; set; }

    /// <summary>
    /// <para>The podcast show or hide status.</para>
    /// <para>If you want your show removed from the Apple directory, use this tag.</para>
    /// <para>Specifying the &lt;itunes:block&gt; tag with a <c>Yes</c> value, prevents the entire podcast from appearing in 
    /// Apple Podcasts.</para>
    /// <para>Specifying any value other than <c>Yes</c> has no effect.</para>
    /// </summary>
    public bool Block { get; set; }

    /// <summary>
    /// <para>The podcast update status.</para>
    /// <para>If you will never publish another episode to your show, use this tag.</para>
    /// <para>Specifying the &lt;itunes:block&gt; tag with a <c>Yes</c> value indicates that a podcast is complete and you 
    /// will not post any more episodes in the future.</para>
    /// <para>Specifying any value other than <c>Yes</c> has no effect.</para>
    /// </summary>
    public bool Complete { get; set; }
}
