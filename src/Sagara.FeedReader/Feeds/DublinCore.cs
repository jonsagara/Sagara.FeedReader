using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Feeds;

/// <summary>
/// The parsed "dc:" elements in a feed
/// </summary>
public class DublinCore
{
    /// <summary>
    /// The "title" element
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// The "creator" element
    /// </summary>
    public string? Creator { get; set; }

    /// <summary>
    /// The "subject" element
    /// </summary>
    public string? Subject { get; set; }

    /// <summary>
    /// The "description" field
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The "publisher" element
    /// </summary>
    public string? Publisher { get; set; }

    /// <summary>
    /// The "contributor" element
    /// </summary>
    public string? Contributor { get; set; }

    /// <summary>
    /// The "date" element
    /// </summary>
    public string? DateString { get; set; }

    /// <summary>
    /// The "date" element as datetime. Null if parsing failed or date is empty.
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// The "type" element
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// The "format" element
    /// </summary>
    public string? Format { get; set; }

    /// <summary>
    /// The "identifier" element
    /// </summary>
    public string? Identifier { get; set; }

    /// <summary>
    /// The "source" element
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// The "language" element
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// The "rel" element
    /// </summary>
    public string? Relation { get; set; }

    /// <summary>
    /// The "coverage" element
    /// </summary>
    public string? Coverage { get; set; }

    /// <summary>
    /// The "rights" element
    /// </summary>
    public string? Rights { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DublinCore"/> class.
    /// default constructor (for serialization)
    /// </summary>
    public DublinCore()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DublinCore"/> class.
    /// Reads a dublincore (dc:) element based on the xml given in element
    /// </summary>
    /// <param name="item">item element as xml</param>
    public DublinCore(XElement item)
    {
        Title = item.GetChildElementValue("dc:title");
        Creator = item.GetChildElementValue("dc:creator");
        Subject = item.GetChildElementValue("dc:subject");
        Description = item.GetChildElementValue("dc:description");
        Publisher = item.GetChildElementValue("dc:publisher");
        Contributor = item.GetChildElementValue("dc:contributor");
        DateString = item.GetChildElementValue("dc:date");
        Date = Helpers.TryParseDateTime(DateString);
        Type = item.GetChildElementValue("dc:type");
        Format = item.GetChildElementValue("dc:format");
        Identifier = item.GetChildElementValue("dc:identifier");
        Source = item.GetChildElementValue("dc:source");
        Language = item.GetChildElementValue("dc:language");
        Relation = item.GetChildElementValue("dc:relation");
        Coverage = item.GetChildElementValue("dc:coverage");
        Rights = item.GetChildElementValue("dc:rights");
    }
}
