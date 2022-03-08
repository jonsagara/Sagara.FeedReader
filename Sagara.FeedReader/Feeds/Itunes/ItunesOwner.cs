namespace Sagara.FeedReader.Feeds.Itunes;

using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

/// <summary>
/// The itunes:owner xml element
/// </summary>
public class ItunesOwner
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ItunesOwner"/> class.
    /// </summary>
    /// <param name="ownerElement">the owner xml element</param>
    public ItunesOwner(XElement ownerElement)
    {
        // The code that calls this constructor does a null check, so this should never be null.
        ArgumentNullException.ThrowIfNull(ownerElement);

        Name = ownerElement.GetChildElementValue(ItunesChannel.NAMESPACEPREFIX, "name");
        Email = ownerElement.GetChildElementValue(ItunesChannel.NAMESPACEPREFIX, "email");
    }

    /// <summary>
    /// The itunes:email of the owner
    /// </summary>
    public string? Email { get; }

    /// <summary>
    /// The itunes:name of the owner
    /// </summary>
    public string? Name { get; }
}
