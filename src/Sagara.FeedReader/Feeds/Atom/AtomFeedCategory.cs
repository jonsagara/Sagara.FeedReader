using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Feeds;

/// <summary>
/// Atom feed category according to specification: https://validator.w3.org/feed/docs/rss2.html
/// </summary>
public class AtomFeedCategory : BaseFeedCategory
{
    /// <summary>
    /// The term attribute is a string that identifies the category to which the entry or feed belongs.
    /// </summary>
    public string? Term { get; set; }

    /// <summary>
    /// Optional. Identifies  the categorization scheme associated with this category. This attribute 
    /// can be used, for example, to differentiate between tags and categories.
    /// </summary>
    public string? Scheme { get; set; }

    /// <summary>
    /// Optional. Provides a human-readable label for display in end-user applications.
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AtomFeedCategory"/> class.
    /// default constructor (for serialization)
    /// </summary>
    public AtomFeedCategory()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AtomFeedCategory"/> class.
    /// Reads a new feed category element based on the given xml item.
    /// </summary>
    /// <param name="categoryElement">The xml containing the feed item</param>
    public AtomFeedCategory(XElement categoryElement)
        : base(categoryElement)
    {
        Term = categoryElement.GetAttributeValue("term");
        Scheme = categoryElement.GetAttributeValue("scheme");
        Label = categoryElement.GetAttributeValue("label");
    }
}
