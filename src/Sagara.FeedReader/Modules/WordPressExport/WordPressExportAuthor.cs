using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Modules.WordPressExport;

/// <summary>
/// <para>The podcast owner contact information.</para>
/// </summary>
/// <remarks>
/// Note: The &lt;itunes:owner&gt; tag information is for administrative communication about the 
/// podcast and isn’t displayed in Apple Podcasts. Please make sure the email address is active 
/// and monitored.
/// </remarks>
public class WordPressExportAuthor
{
    /// <summary>
    /// The author_id element's value.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// The author_login element's value.
    /// </summary>
    public string? Login { get; set; }

    /// <summary>
    /// The author_email element's value.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// The author_display_name element's value.
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    /// The author_first_name element's value.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// The author_last_name element's value.
    /// </summary>
    public string? LastName { get; set; }


    /// <summary>
    /// .ctor
    /// </summary>
    public WordPressExportAuthor(XElement authorElement)
    {
        ArgumentNullException.ThrowIfNull(authorElement);

        Id = Helpers.TryParseLong(authorElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "author_id"))!.Value;
        Login = authorElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "author_login");
        Email = authorElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "author_email");
        DisplayName = authorElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "author_display_name");
        FirstName = authorElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "author_first_name");
        LastName = authorElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "author_last_name");
    }
}
