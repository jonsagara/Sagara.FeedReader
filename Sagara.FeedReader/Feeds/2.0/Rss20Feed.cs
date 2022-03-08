﻿namespace CodeHollow.FeedReader.Feeds;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using CodeHollow.FeedReader.Extensions;

/// <summary>
/// RSS 2.0 feed accoring to specification: https://validator.w3.org/feed/docs/rss2.html
/// </summary>
public class Rss20Feed : BaseFeed
{
    /// <summary>
    /// The "description" element
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The "language" element
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// The "copyright" element
    /// </summary>
    public string? Copyright { get; set; }

    /// <summary>
    /// The "docs" element
    /// </summary>
    public string? Docs { get; set; }

    /// <summary>
    /// The "image" element
    /// </summary>
    public FeedImage? Image { get; set; }

    /// <summary>
    /// The "lastBuildDate" element as string
    /// </summary>
    public string? LastBuildDateString { get; set; }

    /// <summary>
    /// The "lastBuildDate" element as DateTime. Null if parsing failed of lastBuildDate is empty.
    /// </summary>
    public DateTime? LastBuildDate { get; set; }

    /// <summary>
    /// The "managingEditor" element
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
    /// The "webMaster" field
    /// </summary>
    public string? WebMaster { get; set; }

    /// <summary>
    /// All "category" elements
    /// </summary>
    public IReadOnlyCollection<string> Categories { get; private set; } = Array.Empty<string>();

    /// <summary>
    /// The "generator" element
    /// </summary>
    public string? Generator { get; set; }

    /// <summary>
    /// The "cloud" element
    /// </summary>
    public FeedCloud? Cloud { get; set; }

    /// <summary>
    /// The time to life "ttl" element
    /// </summary>
    public string? TTL { get; set; }

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
    /// All elements starting with "sy:"
    /// </summary>
    public Syndication? Sy { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Rss20Feed"/> class.
    /// default constructor (for serialization)
    /// </summary>
    public Rss20Feed()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Rss20Feed"/> class.
    /// Reads a rss 2.0 feed based on the xml given in channel
    /// </summary>
    /// <param name="feedXml">the entire feed xml as string</param>
    /// <param name="channel">the "channel" element in the xml as XElement</param>
    public Rss20Feed(string feedXml, XElement channel)
        : base(feedXml, channel)
    {
        Description = channel.GetChildElementValue("description");
        Language = channel.GetChildElementValue("language");
        Copyright = channel.GetChildElementValue("copyright");
        ManagingEditor = channel.GetChildElementValue("managingEditor");
        WebMaster = channel.GetChildElementValue("webMaster");
        Docs = channel.GetChildElementValue("docs");
        PublishingDateString = channel.GetChildElementValue("pubDate");
        LastBuildDateString = channel.GetChildElementValue("lastBuildDate");
        ParseDates(Language, PublishingDateString, LastBuildDateString);

        Categories = channel.GetElements("category").Select(ce => ce.Value).ToArray();

        Sy = new Syndication(channel);
        Generator = channel.GetChildElementValue("generator");
        TTL = channel.GetChildElementValue("ttl");
        Image = new Rss20FeedImage(channel.GetElement("image"));
        Cloud = new FeedCloud(channel.GetElement("cloud"));
        TextInput = new FeedTextInput(channel.GetElement("textinput"));

        var skipHours = channel.GetElement("skipHours");
        if (skipHours is not null)
        {
            SkipHours = skipHours.GetElements("hour").Select(he => he.Value).ToArray();
        }

        var skipDays = channel.GetElement("skipDays");
        if (skipDays is not null)
        {
            SkipDays = skipDays.GetElements("day").Select(x => x.Value).ToArray();
        }

        var items = channel.GetElements("item");

        foreach (var item in items)
        {
            Items.Add(new Rss20FeedItem(item));
        }
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
            Type = FeedType.Rss_2_0,
        };

        return f;
    }

    /// <summary>
    /// Sets the PublishingDate and LastBuildDate. If parsing fails, then it checks if the language
    /// is set and tries to parse the date based on the culture of the language.
    /// </summary>
    /// <param name="language">language of the feed</param>
    /// <param name="publishingDate">publishing date as string</param>
    /// <param name="lastBuildDate">last build date as string</param>
    private void ParseDates(string? language, string? publishingDate, string? lastBuildDate)
    {
        PublishingDate = Helpers.TryParseDateTime(publishingDate);
        LastBuildDate = Helpers.TryParseDateTime(lastBuildDate);

        // check if language is set - if so, check if dates could be parsed or try to parse it with culture of the language
        if (string.IsNullOrWhiteSpace(language))
        {
            return;
        }

        // if publishingDateString is set but PublishingDate is null - try to parse with culture of "Language" property
        bool parseLocalizedPublishingDate = PublishingDate is null && !string.IsNullOrWhiteSpace(PublishingDateString);

        // if LastBuildDateString is set but LastBuildDate is null - try to parse with culture of "Language" property
        bool parseLocalizedLastBuildDate = LastBuildDate is null && !string.IsNullOrWhiteSpace(LastBuildDateString);

        // if both dates are set - return
        if (!parseLocalizedPublishingDate && !parseLocalizedLastBuildDate)
        {
            return;
        }

        // dates are set, but one of them couldn't be parsed - so try again with the culture set to the language
        CultureInfo culture;
        try
        {
            culture = new CultureInfo(language);

        }
        catch (CultureNotFoundException)
        {
            // should be replace by a try parse or by getting all cultures and selecting the culture
            // out of the collection. That's unfortunately not available in .net standard 1.3 for now
            // this case should never happen, but in some rare cases it does - so catching the exception
            // is acceptable in that case.
            return; // culture couldn't be found, return as it was already tried to parse with default values
        }

        if (parseLocalizedPublishingDate)
        {
            PublishingDate = Helpers.TryParseDateTime(PublishingDateString, culture);
        }

        if (parseLocalizedLastBuildDate)
        {
            LastBuildDate = Helpers.TryParseDateTime(LastBuildDateString, culture);
        }
    }
}
