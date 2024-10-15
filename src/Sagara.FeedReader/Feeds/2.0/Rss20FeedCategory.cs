using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Feeds;

/// <summary>
/// RSS 2.0 feed category according to specification: https://validator.w3.org/feed/docs/rss2.html
/// </summary>
public class Rss20FeedCategory : BaseFeedCategory
{
    /// <summary>
    /// Optional. Identifies the taxonomy in which the category is placed. Comes from the domain attribute.
    /// </summary>
    public string? Domain { get; set; }

    /// <summary>
    /// The category text pull from the tag's content.
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Rss20FeedCategory"/> class.
    /// default constructor (for serialization)
    /// </summary>
    public Rss20FeedCategory()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Rss20FeedCategory"/> class.
    /// Reads a new feed category element based on the given xml item.
    /// </summary>
    /// <param name="categoryElement">The xml containing the feed item</param>
    public Rss20FeedCategory(XElement categoryElement)
        : base(categoryElement)
    {
        Domain = categoryElement.GetAttributeValue("domain");
        Content = categoryElement.Value;
    }
}
