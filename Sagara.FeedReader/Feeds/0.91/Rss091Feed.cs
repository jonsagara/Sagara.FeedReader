namespace Sagara.FeedReader.Feeds;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

/// <summary>
/// Rss Feed according to Rss 0.91 specification:
/// http://www.rssboard.org/rss-0-9-1-netscape
/// </summary>
public class Rss091Feed : BaseFeed
{
    /// <summary>
    /// The required field "description"
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The required field "language"
    /// /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// The "copyright" field
    /// </summary>
    public string? Copyright { get; set; }

    /// <summary>
    /// The "docs" field
    /// </summary>
    public string? Docs { get; set; }

    /// <summary>
    /// The "image" element
    /// </summary>
    public FeedImage? Image { get; set; }

    /// <summary>
    /// The "lastBuildDate" element
    /// </summary>
    public string? LastBuildDateString { get; set; }

    /// <summary>
    /// The "lastBuildDate" as DateTime. Null if parsing failed or lastBuildDate is empty.
    /// </summary>
    public DateTime? LastBuildDate { get; set; }

    /// <summary>
    /// The "managingEditor" field
    /// </summary>
    public string? ManagingEditor { get; set; }

    /// <summary>
    /// The "pubDate" field
    /// </summary>
    public string? PublishingDateString { get; set; }

    /// <summary>
    /// The "pubDate" field as DateTime. Null if parsing failed or pubDate is empty.
    /// </summary>
    public DateTime? PublishingDate { get; set; }

    /// <summary>
    /// The "rating" field
    /// </summary>
    public string? Rating { get; set; }

    /// <summary>
    /// All "day" elements in "skipDays"
    /// </summary>
    public IReadOnlyCollection<string> SkipDays { get; private set; } = Array.Empty<string>();

    /// <summary>
    /// All "hour" elements in "skipHours"
    /// </summary>
    public IReadOnlyCollection<string> SkipHours { get; private set; } = Array.Empty<string>();

    /// <summary>
    /// The "textInput" element
    /// </summary>
    public FeedTextInput? TextInput { get; set; }

    /// <summary>
    /// The "webMaster" element
    /// </summary>
    public string? WebMaster { get; set; }

    /// <summary>
    /// All elements that start with "sy:"
    /// </summary>
    public Syndication? Sy { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Rss091Feed"/> class.
    /// default constructor (for serialization)
    /// </summary>
    public Rss091Feed()
        : base()
    {
        SkipDays = new List<string>();
        SkipHours = new List<string>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Rss091Feed"/> class.
    /// Reads a rss 0.91 feed based on the xml given in channel
    /// </summary>
    /// <param name="feedXml">the entire feed xml as string</param>
    /// <param name="channel">the "channel" element in the xml as XElement</param>
    public Rss091Feed(string feedXml, XElement channel)
        : base(feedXml, channel)
    {
        Description = channel.GetChildElementValue("description");
        Language = channel.GetChildElementValue("language");
        Image = new Rss091FeedImage(channel.GetElement("image"));
        Copyright = channel.GetChildElementValue("copyright");
        ManagingEditor = channel.GetChildElementValue("managingEditor");
        WebMaster = channel.GetChildElementValue("webMaster");
        Rating = channel.GetChildElementValue("rating");

        PublishingDateString = channel.GetChildElementValue("pubDate");
        PublishingDate = Helpers.TryParseDateTime(PublishingDateString);

        LastBuildDateString = channel.GetChildElementValue("lastBuildDate");
        LastBuildDate = Helpers.TryParseDateTime(LastBuildDateString);

        Docs = channel.GetChildElementValue("docs");

        TextInput = new FeedTextInput(channel.GetElement("textinput"));

        Sy = new Syndication(channel);

        var skipHours = channel.GetElement("skipHours");
        if (skipHours is not null)
        {
            SkipHours = skipHours.GetElements("hour").Select(he => he.Value).ToArray();
        }

        var skipDays = channel.GetElement("skipDays");
        if (skipDays is not null)
        {
            SkipDays = skipDays.GetElements("day").Select(de => de.Value).ToArray();
        }

        var items = channel.GetElements("item");
        AddItems(items);
    }

    /// <summary>
    /// Creates the base <see cref="Feed"/> element out of this feed.
    /// </summary>
    /// <returns>feed</returns>
    public override Feed ToFeed()
    {
        Feed f = new(this)
        {
            Copyright = Copyright,
            Description = Description,
            ImageUrl = Image?.Url,
            Language = Language,
            LastUpdatedDate = LastBuildDate,
            LastUpdatedDateString = LastBuildDateString,
            Type = FeedType.Rss_0_91,
        };

        return f;
    }

    /// <summary>
    /// Adds feed items to the items collection
    /// </summary>
    /// <param name="items">feed items as XElements</param>
    internal virtual void AddItems(IReadOnlyCollection<XElement> items)
    {
        foreach (var item in items)
        {
            Items.Add(new Rss091FeedItem(item));
        }
    }
}
