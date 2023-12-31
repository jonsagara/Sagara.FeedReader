﻿using System.Xml.Linq;

namespace Sagara.FeedReader.Extensions;

internal static class XElementExtensions
{
    /// <summary>
    /// Gets the value of the element with name <paramref name="elementName"/>. If the element is
    /// null, returns null.
    /// </summary>
    /// <param name="element">xml element</param>
    /// <param name="elementName">name of the element</param>
    /// <returns>The value of the XElement</returns>
    public static string? GetChildElementValue(this XElement? element, string elementName)
    {
        ArgumentNullException.ThrowIfNull(elementName);

        return element
            ?.GetElement(elementName)
            ?.Value;
    }

    /// <summary>
    /// Gets the value of the element "name"
    /// </summary>
    /// <param name="element">xml element</param>
    /// <param name="namespacePrefix">the namespace prefix of the element that should be returned</param>
    /// <param name="elementName">name of the element</param>
    /// <returns>the value of the XElement</returns>
    public static string? GetChildElementValue(this XElement element, string namespacePrefix, string elementName)
    {
        ArgumentNullException.ThrowIfNull(namespacePrefix);
        ArgumentNullException.ThrowIfNull(elementName);

        return element
            ?.GetElement(namespacePrefix, elementName)
            ?.Value;
    }

    /// <summary>
    /// Gets the value of the attribute <paramref name="attributeName"/>
    /// </summary>
    /// <param name="element">The xml element</param>
    /// <param name="attributeName">The name of the attribute</param>
    /// <returns>value of the attribute</returns>
    public static string? GetAttributeValue(this XElement? element, string attributeName)
        => element?.GetAttribute(attributeName)?.Value;

    /// <summary>
    /// Gets the attribute <paramref name="attributeName"/> of the given XElement
    /// </summary>
    /// <param name="element">the xml element</param>
    /// <param name="attributeName">the name of the attribute</param>
    /// <returns>the xml attribute</returns>
    public static XAttribute? GetAttribute(this XElement? element, string attributeName)
    {
        var nsAndName = SplitName(attributeName);

        return element?.GetAttribute(namespacePrefix: nsAndName.Namespace, attributeName: nsAndName.Name);
    }

    /// <summary>
    /// Gets the attribute with the namespace <paramref name="namespacePrefix"/> and name <paramref name="attributeName"/> of the given XElement
    /// </summary>
    /// <param name="element">the xml element</param>
    /// <param name="namespacePrefix">the namespace prefix of the attribute</param>
    /// <param name="attributeName">the name of the attribute</param>
    /// <returns>the xml attribute</returns>
    public static XAttribute? GetAttribute(this XElement element, string? namespacePrefix, string attributeName)
    {
        if (string.IsNullOrEmpty(namespacePrefix))
        {
            return element.Attribute(attributeName);
        }

        var namesp = element.GetNamespacePrefix(namespacePrefix) ?? string.Empty;
        return element.Attribute(namesp + attributeName);
    }

    /// <summary>
    /// Gets the element of the given XElement
    /// </summary>
    /// <param name="element">the xml element</param>
    /// <param name="elementName">Name of the element that should be returned</param>
    /// <returns>the "name" element of the XElement</returns>
    public static XElement? GetElement(this XElement element, string elementName)
    {
        var nsAndName = SplitName(elementName);

        return element?.GetElement(namespacePrefix: nsAndName.Namespace, elementName: nsAndName.Name);
    }

    /// <summary>
    /// Gets the element of the given XElement
    /// </summary>
    /// <param name="element">the xml element</param>
    /// <param name="namespacePrefix">the namespace prefix of the element that should be returned</param>
    /// <param name="elementName">Name of the element that should be returned</param>
    /// <returns>the "name" element with the prefix "namespacePrefix" of the XElement</returns>
    public static XElement? GetElement(this XElement element, string? namespacePrefix, string elementName)
    {
        var namesp = element.GetNamespacePrefix(namespacePrefix);
        if (namesp is null)
        {
            return null;
        }

        return element.Element(namesp + elementName);
    }

    /// <summary>
    /// Gets all elements of the given XElement
    /// </summary>
    /// <param name="element">the xml element</param>
    /// <param name="elementName">Name of the elements that should be returned</param>
    /// <returns>all "name" elements of the given XElement</returns>
    public static IReadOnlyCollection<XElement> GetElements(this XElement element, string elementName)
    {
        var nsAndName = SplitName(elementName);

        return element.GetElements(namespacePrefix: nsAndName.Namespace, elementName: nsAndName.Name);
    }

    /// <summary>
    /// Gets all elements of the given XElement
    /// </summary>
    /// <param name="element">the xml element</param>
    /// <param name="namespacePrefix">the namespace prefix of the elements that should be returned</param>
    /// <param name="elementName">Name of the elements that should be returned</param>
    /// <returns>all "name" elements of the given XElement</returns>
    public static IReadOnlyCollection<XElement> GetElements(this XElement element, string? namespacePrefix, string elementName)
    {
        var namesp = element.GetNamespacePrefix(namespacePrefix);
        if (namesp is null)
        {
            return Array.Empty<XElement>();
        }

        return element.Elements(namesp + elementName).ToArray();
    }

    /// <summary>
    /// Gets the namespace prefix of the given XElement
    /// </summary>
    /// <param name="element">the xml element</param>
    /// <returns>the namespace prefix</returns>
    public static XNamespace? GetNamespacePrefix(this XElement element)
    {
        return element.GetNamespacePrefix(null);
    }

    /// <summary>
    /// Gets the namespace prefix of the given XElement, if namespacePrefix is null or empty, it returns the default namespace.
    /// </summary>
    /// <param name="element">the xml element</param>
    /// <param name="namespacePrefix">the namespace prefix</param>
    /// <returns>the namespace prefix or default namespace if the <paramref name="namespacePrefix"/> is null or empty</returns>
    public static XNamespace? GetNamespacePrefix(this XElement element, string? namespacePrefix)
    {
        var namesp = string.IsNullOrWhiteSpace(namespacePrefix)
            ? element.GetDefaultNamespace()
            : element.GetNamespaceOfPrefix(namespacePrefix);

        return namesp;
    }


    //
    // Private methods
    //

    /// <summary>
    /// Splits the name into namespace and name if it contains a ':'. If it does not contain a 
    /// namespace, the returned namespace is null and name is the original name.
    /// </summary>
    /// <param name="name">the input name</param>
    /// <returns>splitted namespace and name, item1 is null if namespace is empty</returns>
    private static NamespaceAndName SplitName(string name)
    {
        // Example expected input: atom:updated
        //   This would be split into namespace 'atom' and name 'updated'.
        // Example expected input: pubDate
        //   The split would not have the correct number of parts, and we would return the 
        //   original name 'pubDate' as the name.

        // Split on the first occurrence of ':'. At most, we should see two elements.
        var nameSpan = name.AsSpan();
        Span<Range> nameParts = stackalloc Range[2];
        var partsWritten = nameSpan.Split(destination: nameParts, ':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        return partsWritten == 2
            ? new NamespaceAndName(Namespace: nameSpan[nameParts[0]].ToString(), Name: nameSpan[nameParts[1]].ToString())
            : new NamespaceAndName(Namespace: null, Name: name);
    }


    //
    // Classes
    //

    private readonly record struct NamespaceAndName(string? Namespace, string Name);
}
