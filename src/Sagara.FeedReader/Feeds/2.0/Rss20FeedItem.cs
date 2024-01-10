using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Feeds;

/// <summary>
/// RSS 2.0 feed item according to specification: https://validator.w3.org/feed/docs/rss2.html
/// </summary>
public class Rss20FeedItem : BaseFeedItem
{
    /// <summary>
    /// The "description" field of the feed item
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The "author" field of the feed item
    /// </summary>
    public string? Author { get; set; }

    /// <summary>
    /// The "comments" field of the feed item
    /// </summary>
    public string? Comments { get; set; }

    /// <summary>
    /// The "enclosure" field
    /// </summary>
    public FeedItemEnclosure? Enclosure { get; set; }

    /// <summary>
    /// The "guid" field
    /// </summary>
#pragma warning disable CA1720 // Identifier contains type name. Justification: It's in the spec.
    public string? Guid { get; set; }
#pragma warning restore CA1720 // Identifier contains type name

    /// <summary>
    /// The "pubDate" field
    /// </summary>
    public string? PublishingDateString { get; set; }

    /// <summary>
    /// The "pubDate" field as DateTime. Null if parsing failed or pubDate is empty.
    /// </summary>
    public DateTime? PublishingDate { get; set; }

    /// <summary>
    /// The "source" field
    /// </summary>
    public FeedItemSource? Source { get; set; }

    /// <summary>
    /// All entries "category" entries
    /// </summary>
    public IReadOnlyCollection<string> Categories { get; private set; } = Array.Empty<string>();

    /// <summary>
    /// The "content:encoded" field
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// All elements starting with "dc:"
    /// </summary>
    public DublinCore? DC { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Rss20FeedItem"/> class.
    /// default constructor (for serialization)
    /// </summary>
    public Rss20FeedItem()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Rss20FeedItem"/> class.
    /// Reads a new feed item element based on the given xml item
    /// </summary>
    /// <param name="item">The xml containing the feed item</param>
    public Rss20FeedItem(XElement item)
        : base(item)
    {
        Comments = item.GetChildElementValue("comments");
        Author = item.GetChildElementValue("author");
        Enclosure = new FeedItemEnclosure(item.GetElement("enclosure"));
        PublishingDateString = GetPublishingDateString(item);
        PublishingDate = Helpers.TryParseDateTime(PublishingDateString);
        DC = new DublinCore(item);
        Source = new FeedItemSource(item.GetElement("source"));

        var categories = item.GetElements("category");
        Categories = categories.Select(x => x.Value).ToArray();

        Guid = item.GetChildElementValue("guid");
        Description = item.GetChildElementValue("description");
        Content = item.GetChildElementValue("content:encoded")?.HtmlDecode();
    }

    /// <inheritdoc/>
    internal override FeedItem ToFeedItem()
    {
        FeedItem fi = new(this)
        {
            Author = Author,
            Content = Content,
            Description = Description,
            Id = Guid,
            PublishingDate = PublishingDate,
            PublishingDateString = PublishingDateString,
        };

        fi.Categories.AddRange(Categories);

        return fi;
    }


    //
    // Private methods
    //

    /// <summary>
    /// If we can't find a value for pubDate, look for Atom's updated element.
    /// </summary>
    /// <param name="item">The xml containing the feed item.</param>
    private static string? GetPublishingDateString(XElement item)
    {
        // #1: at least one feed I follow is RSS 2.0, but instead of each item having a
        //   pubDate element, it has an Atom updated element. Sheesh.
        //   See: http://feeds.feedburner.com/CrossCuttingConcerns

        string? pubDate = item.GetChildElementValue("pubDate");
        if (pubDate is not null)
        {
            // item has a pubDate child. Nothing further to do! This is good RSS.
            return pubDate;
        }

        // Some demon spawn from hell either omitted pubDate or decided to use Atom's 
        //   updated element instead. Look for atom.
        return item.Element(Namespaces.Atom + "updated")?.Value;
    }
}
