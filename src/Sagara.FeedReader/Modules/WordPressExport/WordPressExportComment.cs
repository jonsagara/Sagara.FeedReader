using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Modules.WordPressExport;

/// <summary>
/// WordPress Post comments.
/// </summary>
public class WordPressExportComment
{
    /// <summary>
    /// The comment_id element's value.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// The comment_author element's value.
    /// </summary>
    public string? Author { get; set; }

    /// <summary>
    /// The comment_author_email element's value.
    /// </summary>
    public string? AuthorEmail { get; set; }

    /// <summary>
    /// The comment_author_url element's value.
    /// </summary>
    public string? AuthorUrl { get; set; }

    /// <summary>
    /// The comment_author_IP element's value.
    /// </summary>
    public string? AuthorIP { get; set; }

    /// <summary>
    /// The comment_date element's value.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// The comment_date_gmt element's value.
    /// </summary>
    public DateTime DateGmt { get; set; }

    /// <summary>
    /// The comment_content element's value.
    /// </summary>
    public string Content { get; set; } = null!;

    /// <summary>
    /// The comment_approved element's value.
    /// </summary>
    public string Approved { get; set; } = null!;

    /// <summary>
    /// The comment_type element's value.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// The comment_parent element's value.
    /// </summary>
    public long Parent { get; set; }

    /// <summary>
    /// The comment_user_id element's value.
    /// </summary>
    public long UserId { get; set; }

    // Skipping commentmeta because the values don't appear useful to non-WP installations.


    /// <summary>
    /// .ctor
    /// </summary>
    public WordPressExportComment(XElement commentElement)
    {
        ArgumentNullException.ThrowIfNull(commentElement);

        Id = Helpers.TryParseLong(commentElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "comment_id"))!.Value;
        Author = commentElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "comment_author");
        AuthorEmail = commentElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "comment_author_email");
        AuthorUrl = commentElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "comment_author_url");
        AuthorIP = commentElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "comment_author_IP");
        Date = Helpers.TryParseDateTime(commentElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "comment_date"))!.Value;
        DateGmt = commentElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "comment_date_gmt").ParseUtcOrDefault()!.Value;
        Content = commentElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "comment_content")!;
        Approved = commentElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "comment_approved")!;
        Type = commentElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "comment_type");
        Parent = Helpers.TryParseLong(commentElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "comment_parent"))!.Value;
        UserId = Helpers.TryParseLong(commentElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "comment_user_id"))!.Value;
    }
}
