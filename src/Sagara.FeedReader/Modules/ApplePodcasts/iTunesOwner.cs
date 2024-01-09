using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Modules.ApplePodcasts;

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


    /// <summary>
    /// .ctor
    /// </summary>
    public iTunesOwner(XElement ownerElement)
    {
        ArgumentNullException.ThrowIfNull(ownerElement);

        Email = ownerElement.GetChildElementValue(namespacePrefix: iTunesChannel.NamespacePrefix, elementName: "email");
        Name = ownerElement.GetChildElementValue(namespacePrefix: iTunesChannel.NamespacePrefix, elementName: "name");
    }
}
