using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Modules.ApplePodcasts;

/// <summary>
/// Parses the <c>itunes:image</c> element.
/// </summary>
public class iTunesImage
{
    /// <summary>
    /// The URL to the image.
    /// </summary>
    public string? Href { get; set; }

    /// <summary>
    /// .ctor
    /// </summary>
    public iTunesImage(XElement element)
    {
        ArgumentNullException.ThrowIfNull(element);

        Href = element.GetAttributeValue("href");
    }
}
