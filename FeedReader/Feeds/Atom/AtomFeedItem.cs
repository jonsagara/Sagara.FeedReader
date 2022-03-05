namespace CodeHollow.FeedReader.Feeds;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

/// <summary>
/// Atom 1.0 feed item object according to specification: https://validator.w3.org/feed/docs/atom.html
/// </summary>
public class AtomFeedItem : BaseFeedItem
{
    /// <summary>
    /// The "author" element
    /// </summary>
    public AtomPerson? Author { get; set; }

    /// <summary>
    /// All "category" elements
    /// </summary>
    public List<string> Categories { get; private set; } = new();

    /// <summary>
    /// The "content" element
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// The "contributor" element
    /// </summary>
    public AtomPerson? Contributor { get; set; }

    /// <summary>
    /// The "id" element
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// The "published" date as string
    /// </summary>
    public string? PublishedDateString { get; set; }

    /// <summary>
    /// The "published" element as DateTime. Null if parsing failed or published is empty.
    /// </summary>
    public DateTime? PublishedDate { get; set; }

    /// <summary>
    /// The "rights" element
    /// </summary>
    public string? Rights { get; set; }

    /// <summary>
    /// The "source" element
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// The "summary" element
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// The "updated" element
    /// </summary>
    public string? UpdatedDateString { get; set; }

    /// <summary>
    /// The "updated" element as DateTime. Null if parsing failed or updated is empty
    /// </summary>
    public DateTime? UpdatedDate { get; set; }

    /// <summary>
    /// All "link" elements
    /// </summary>
    public List<AtomLink> Links { get; private set; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="AtomFeedItem"/> class.
    /// default constructor (for serialization)
    /// </summary>
    public AtomFeedItem()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AtomFeedItem"/> class.
    /// Reads an atom feed based on the xml given in item
    /// </summary>
    /// <param name="item">feed item as xml</param>
    public AtomFeedItem(XElement item)
        : base(item)
    {
        Link = item.GetElement("link")?.Attribute("href")?.Value;

        Author = new AtomPerson(item.GetElement("author"));

        var categories = item
            .GetElements("category")
            .Select(ce => ce.GetAttributeValue("term"))
            .Where(t => !string.IsNullOrWhiteSpace(t))
            .Select(t => t!);
        Categories.AddRange(categories);

        Content = item.GetChildElementValue("content").HtmlDecode();
        Contributor = new AtomPerson(item.GetElement("contributor"));
        Id = item.GetChildElementValue("id");

        PublishedDateString = item.GetChildElementValue("published");
        PublishedDate = Helpers.TryParseDateTime(PublishedDateString);
        Links.AddRange(item.GetElements("link").Select(le => new AtomLink(le)));

        Rights = item.GetChildElementValue("rights");
        Source = item.GetChildElementValue("source");
        Summary = item.GetChildElementValue("summary");

        UpdatedDateString = item.GetChildElementValue("updated");
        UpdatedDate = Helpers.TryParseDateTime(UpdatedDateString);
    }

    /// <inheritdoc/>
    internal override FeedItem ToFeedItem()
    {
        FeedItem fi = new(this)
        {
            Author = Author?.ToString(),
            Content = Content,
            Description = Summary,
            Id = Id,
            PublishingDate = PublishedDate,
            PublishingDateString = PublishedDateString,
        };

        fi.Categories.AddRange(Categories);

        return fi;
    }
}
