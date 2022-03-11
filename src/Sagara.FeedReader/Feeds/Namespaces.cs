using System.Xml.Linq;

namespace Sagara.FeedReader.Feeds;

/// <summary>
/// XML namespace URIs.
/// </summary>
public static class Namespaces
{
    /// <summary>
    /// The Atom 1.0 XML namespace.
    /// </summary>
    public const string AtomName = "http://www.w3.org/2005/Atom";

    /// <summary>
    /// The Atom namespace as an XNamespace.
    /// </summary>
    public static readonly XNamespace Atom = XNamespace.Get(AtomName);
}
