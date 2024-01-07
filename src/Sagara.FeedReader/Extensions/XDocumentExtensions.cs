using System.Xml.Linq;

namespace Sagara.FeedReader.Extensions;

internal static class XDocumentExtensions
{
    /// <summary>
    /// Try to load an &quot;xmlns&quot; XML namespace declaration attribute from the root element.
    /// </summary>
    /// <param name="doc">The xml document.</param>
    /// <param name="localName">The local name of the namespace declaration. For example, for attribute &quot;xmlns:itunes&quot;, 
    /// pass &quot;itunes&quot;.</param>
    /// <returns>An XAttribute describing the namespace if found; otherwise, null.</returns>
    internal static XAttribute? GetRootNamespaceDeclarationAttribute(this XDocument doc, string localName)
    {
        ArgumentNullException.ThrowIfNull(doc);
        ArgumentException.ThrowIfNullOrWhiteSpace(localName);

        return doc.Root!.Attribute(XName.Get(localName, XNamespace.Xmlns.NamespaceName));
    }
}
