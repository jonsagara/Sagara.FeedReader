namespace Sagara.FeedReader.Feeds.Itunes;

using System;
using System.Linq;
using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

/// <summary>
/// The basic itunes: elements that are part of the channel xml element of an rss2.0 feed
/// </summary>
public class ItunesChannel
{
    internal const string NAMESPACEPREFIX = "itunes";
    /// <summary>
    /// Initializes a new instance of the <see cref="ItunesChannel"/> class.
    /// </summary>
    /// <param name="channelElement"></param>
    public ItunesChannel(XElement channelElement)
    {
        Author = channelElement.GetChildElementValue(NAMESPACEPREFIX, "author");
        Block = channelElement.GetChildElementValue(NAMESPACEPREFIX, "block").EqualsIgnoreCase("yes");
        Categories = GetItunesCategories(channelElement);

        var imageElement = channelElement.GetElement(NAMESPACEPREFIX, "image");
        if (imageElement is not null)
        {
            Image = new ItunesImage(imageElement);
        }

        var explicitValue = channelElement.GetChildElementValue(NAMESPACEPREFIX, "explicit");
        Explicit = explicitValue.EqualsAnyIgnoreCase("yes", "explicit", "true");

        Complete = channelElement.GetChildElementValue(NAMESPACEPREFIX, "complete").EqualsIgnoreCase("yes");

        if (Uri.TryCreate(channelElement.GetChildElementValue(NAMESPACEPREFIX, "new-feed-url"), UriKind.Absolute, out var newFeedUrl))
        {
            NewFeedUrl = newFeedUrl;
        }

        var ownerElement = channelElement.GetElement(NAMESPACEPREFIX, "owner");

        if (ownerElement is not null)
        {
            Owner = new ItunesOwner(ownerElement);
        }

        Subtitle = channelElement.GetChildElementValue(NAMESPACEPREFIX, "subtitle");
        Summary = channelElement.GetChildElementValue(NAMESPACEPREFIX, "summary");
    }

    /// <summary>
    /// The itunes:author element
    /// </summary>
    public string? Author { get; }

    /// <summary>
    /// The itunes:block element
    /// </summary>
    public bool Block { get; }

    /// <summary>
    /// The itunes:category elements
    /// </summary>
    public IReadOnlyCollection<ItunesCategory> Categories { get; }

    /// <summary>
    /// The itunes:image element
    /// </summary>
    public ItunesImage? Image { get; }

    /// <summary>
    /// The itunes:explicit element
    /// </summary>
    public bool Explicit { get; }

    /// <summary>
    /// The itunes:complete element
    /// </summary>
    public bool Complete { get; }

    /// <summary>
    /// The itunes:new-feed-url element
    /// </summary>
    public Uri? NewFeedUrl { get; }

    /// <summary>
    /// The itunes:owner element
    /// </summary>
    public ItunesOwner? Owner { get; }

    /// <summary>
    /// The itunes:subtitle element
    /// </summary>
    public string? Subtitle { get; }

    /// <summary>
    /// The itunes:summary element
    /// </summary>
    public string? Summary { get; }

    /// <summary>
    /// Sets the itunes categories
    /// </summary>
    /// <param name="element">the channel element</param>
    /// <returns>the itunes:categries</returns>
    private static ItunesCategory[] GetItunesCategories(XElement element)
    {
        var categoryElements = element.GetElements(NAMESPACEPREFIX, "category");
        if (categoryElements.Count == 0)
        {
            return Array.Empty<ItunesCategory>();
        }

        var query = from categoryElement in categoryElements
                    let children = GetItunesCategories(categoryElement)
                    select new ItunesCategory(categoryElement.GetAttributeValue("text"), children);

        return query.ToArray();
    }
}
