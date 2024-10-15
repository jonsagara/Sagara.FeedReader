using System.Xml.Linq;

namespace Sagara.FeedReader.Feeds;

/// <summary>
/// The base object for all feed categories. Since the RSS 2.0 and Atom <c>category</c> elements differ,
/// hydrating the object is done in feed-specific subclasses.
/// </summary>
public class BaseFeedCategory
{
    /// <summary>
    /// The <c>Category</c> (RSS) or <c>entry</c> (Atom) element from the feed. Return as an XElement in order to 
    /// allow reading properties that are not available as first-class properties in the derived class itself.
    /// </summary>
    public XElement? CategoryElement { get; }


    /// <summary>
    /// Initializes a new instance of the <see cref="BaseFeedCategory"/> class.
    /// default constructor (for serialization)
    /// </summary>
    protected BaseFeedCategory()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseFeedCategory"/> class.
    /// Reads a base feed item based on the xml given in element
    /// </summary>
    /// <param name="categoryElement">The <c>category</c> element from the feed.</param>
    public BaseFeedCategory(XElement categoryElement)
    {
        CategoryElement = categoryElement;
    }
}
