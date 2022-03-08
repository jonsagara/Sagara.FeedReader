namespace Sagara.FeedReader.Feeds;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

/// <summary>
/// RSS 2.0 feed item accoring to specification: https://validator.w3.org/feed/docs/rss2.html
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
    public string? Guid { get; set; }

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
    /// <param name="item">the xml containing the feed item</param>
    public Rss20FeedItem(XElement item)
        : base(item)
    {
        Comments = item.GetChildElementValue("comments");
        Author = item.GetChildElementValue("author");
        Enclosure = new FeedItemEnclosure(item.GetElement("enclosure"));
        PublishingDateString = item.GetChildElementValue("pubDate");
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
}
