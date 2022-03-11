namespace Sagara.FeedReader.Feeds.Itunes;

using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

/// <summary>
/// The itunes:image xml element
/// </summary>
public class ItunesImage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ItunesImage"/> class.
    /// </summary>
    /// <param name="image">The itunes:image element</param>
    public ItunesImage(XElement image)
    {
        // The code that calls this constructor does a null check, so this should really
        //   never be null.
        ArgumentNullException.ThrowIfNull(image);

        Href = image.GetAttributeValue("href");
    }

    /// <summary>
    /// The value of the href attribute
    /// </summary>
    public string? Href { get; }
}
