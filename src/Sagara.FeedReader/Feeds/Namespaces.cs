using System.Xml.Linq;

namespace Sagara.FeedReader.Feeds;

/// <summary>
/// XML namespace URIs.
/// </summary>
public static class Namespaces
{
    private const string AtomNamespaceName = "http://www.w3.org/2005/Atom";

    /// <summary>
    /// The Atom namespace as an XNamespace.
    /// </summary>
    public static readonly XNamespace Atom = XNamespace.Get(AtomNamespaceName);


    private const string ApplePodcastsNamespaceName = "http://www.itunes.com/dtds/podcast-1.0.dtd";

    /// <summary>
    /// The namespace for Apple Podcasts elements, typically denoted by the prefix <c>itunes</c> on the
    /// root element.
    /// </summary>
    public static readonly XNamespace ApplePodcasts = XNamespace.Get(ApplePodcastsNamespaceName);
}
