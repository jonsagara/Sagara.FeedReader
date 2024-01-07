namespace Sagara.FeedReader.Feeds;

using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

/// <summary>
/// The base object for all feed items
/// </summary>
public abstract class BaseFeedItem
{
    /// <summary>
    /// The "title" element
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// The "link" element
    /// </summary>
    public string? Link { get; set; }

    /// <summary>
    /// The <c>item</c> (RSS) or <c>entry</c> (Atom) element from the feed. Return as an XElement in order to 
    /// allow reading properties that are not available as first-class properties in the derived class itself.
    /// </summary>
    public XElement? ItemOrEntryElement { get; }

    internal abstract FeedItem ToFeedItem();

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseFeedItem"/> class.
    /// default constructor (for serialization)
    /// </summary>
    protected BaseFeedItem()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseFeedItem"/> class.
    /// Reads a base feed item based on the xml given in element
    /// </summary>
    /// <param name="itemOrEntryElement">The <c>item</c> or <c>entry</c> element from the feed.</param>
    protected BaseFeedItem(XElement itemOrEntryElement)
    {
        Title = itemOrEntryElement.GetChildElementValue("title");
        Link = itemOrEntryElement.GetChildElementValue("link");
        ItemOrEntryElement = itemOrEntryElement;
    }
}
