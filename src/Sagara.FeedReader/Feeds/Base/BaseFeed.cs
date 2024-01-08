namespace Sagara.FeedReader.Feeds;

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

/// <summary>
/// BaseFeed object which contains the basic properties that each feed has.
/// </summary>
public abstract class BaseFeed
{
    /// <summary>
    /// creates the generic <see cref="Feed"/> object.
    /// </summary>
    /// <returns>Feed</returns>
    public abstract Feed ToFeed();

    /// <summary>
    /// The title of the feed
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// The link (url) to the feed
    /// </summary>
    public string? Link { get; set; }

    /// <summary>
    /// The items that are in the feed, specific to the feed type (Atom vs. RSS 2.0, etc.).
    /// </summary>
    public ICollection<BaseFeedItem> Items { get; private set; } = new List<BaseFeedItem>();

    /// <summary>
    /// The original feed XML string.
    /// </summary>
    /// <remarks>
    /// NOTE: If raw XML contained invalid control characters, they were removed.
    /// </remarks>
    public string? OriginalFeedXml { get; private set; }

    /// <summary>
    /// The <c>channel</c> (RSS) or <c>feed</c> (Atom) element from the feed. Returned as an XElement 
    /// in order to allow reading properties that are not available as first-class properties in the derived
    /// class itself.
    /// </summary>
    /// <remarks>
    /// <para>NOTE: RSS has a root <c>rss</c> element, followed by a <c>channel</c> element.</para>
    /// <para>Atom only has a root <c>feed</c> element that contains.</para>
    /// </remarks>
    public XElement? ChannelOrFeedElement { get; }

    /// <summary>
    /// The root namespace declarations in the XML document. Allows callers to determine if they should
    /// further parse the <c>channel</c> or <c>feed</c> element for custom modules.
    /// </summary>
    public FrozenSet<string> RootNamespaceDeclarations { get; private set; } = FrozenSet<string>.Empty;

    /// <summary>
    /// Returns true if the feed's root element (<c>rss</c> for RSS, <c>feed</c> for atom) has the Apple Podcasts 
    /// module namespace declaration (<c>xmlns:itunes</c>); false otherwise.
    /// </summary>
    /// <remarks>
    /// NOTE: because the library has first-class support for this, we directly set a boolean rather than
    /// querying the collection of root element namespace declarations at runtime.
    /// </remarks>
    public bool HasApplePodcastsModule { get; set; }

    private static readonly string _applePodcastsNamespaceName = XName.Get("itunes", XNamespace.Xmlns.NamespaceName).ToString();

    ///// <summary>
    ///// Returns true if the feed's root element (<c>rss</c> for RSS, <c>feed</c> for atom) has the older
    ///// iTunes media module namespace declaration (<c>xmlns:im</c>); false otherwise.
    ///// </summary>
    ///// <remarks>
    ///// NOTE: because the library has first-class support for this, we directly set a boolean rather than
    ///// querying the collection of root element namespace declarations at runtime.
    ///// </remarks>
    //public bool HasiTunesMediaModule { get; set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="BaseFeed"/> class.
    /// default constructor (for serialization)
    /// </summary>
    protected BaseFeed()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseFeed"/> class.
    /// Reads a base feed based on the xml given in element
    /// </summary>
    /// <param name="feedXml">The entire feed XML as string.</param>
    /// <param name="feedDoc">The XDocument parsed from the feed XML. Used to determine if there are iTunes extensions.</param>
    /// <param name="channel">
    /// <para>The <c>channel</c> (RSS) or <c>feed</c> (Atom) element in the xml as XElement.</para>
    /// <para>NOTE: RSS has a root <c>rss</c> element, followed by a <c>channel</c> element.</para>
    /// <para>Atom only has a root <c>feed</c> element.</para>
    /// </param>
    protected BaseFeed(string feedXml, XDocument feedDoc, XElement channel)
        : this()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(feedXml);
        ArgumentNullException.ThrowIfNull(feedDoc);
        ArgumentNullException.ThrowIfNull(channel);

        OriginalFeedXml = feedXml;

        //
        // im: Atom with iTunes extensions.
        // Atom support is nominally dead, but only in that Apple no longer accepts Atom feeds:
        // See: https://podcasters.apple.com/4115-technical-updates-for-hosting-providers
        // They still publish some feeds in Atom format:
        // See: https://www.apple.com/rss/
        //
        // itunes: RSS 2.0 with iTunes extensions.
        // See: https://help.apple.com/itc/podcasts_connect/#/itcb54353390
        //

        RootNamespaceDeclarations = feedDoc.Root!.Attributes()
            .Where(xAttr => xAttr.IsNamespaceDeclaration)
            .Select(xAttr => xAttr.Name.ToString())
            .ToFrozenSet();

        HasApplePodcastsModule = RootNamespaceDeclarations.Contains(_applePodcastsNamespaceName);

        Title = channel.GetChildElementValue("title");
        Link = channel.GetChildElementValue("link");
        ChannelOrFeedElement = channel;
    }
}
