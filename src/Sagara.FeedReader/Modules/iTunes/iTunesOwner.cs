namespace Sagara.FeedReader.Modules.iTunes;

/// <summary>
/// <para>The podcast owner contact information.</para>
/// </summary>
/// <remarks>
/// Note: The &lt;itunes:owner&gt; tag information is for administrative communication about the 
/// podcast and isn’t displayed in Apple Podcasts. Please make sure the email address is active 
/// and monitored.
/// </remarks>
public class iTunesOwner
{
    /// <summary>
    /// Include the email address of the owner.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// The name of the owner.
    /// </summary>
    public string? Name { get; set; }
}
