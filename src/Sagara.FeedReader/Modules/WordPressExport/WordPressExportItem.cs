using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Modules.WordPressExport;

/// <summary>
/// Per-post data from a WordPress Export Item.
/// </summary>
public class WordPressExportItem
{
    /// <summary>
    /// The post's content.
    /// </summary>
    public string Content { get; set; } = null!;

    /// <summary>
    /// An excerpt of the post's content.
    /// </summary>
    public string? Excerpt { get; set; }

    /// <summary>
    /// The post_id element's value.
    /// </summary>
    public long PostId { get; set; }

    /// <summary>
    /// The post_date element's value.
    /// </summary>
    public DateTime PostDate { get; set; }

    /// <summary>
    /// The post_date_gmt element's value.
    /// </summary>
    public DateTime? PostDateGmt { get; set; }

    /// <summary>
    /// The post_modified element's value.
    /// </summary>
    public DateTime PostModified { get; set; }

    /// <summary>
    /// The post_modified_gmt element's value.
    /// </summary>
    public DateTime? PostModifiedGmt { get; set; }

    /// <summary>
    /// The comment_status element's value.
    /// </summary>
    public string CommentStatus { get; set; } = null!;

    /// <summary>
    /// The ping_status element's value.
    /// </summary>
    public string PingStatus { get; set; } = null!;

    /// <summary>
    /// The post_name element's value.
    /// </summary>
    public string PostName { get; set; } = null!;

    /// <summary>
    /// The status element's value.
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// The post_parent element's value.
    /// </summary>
    public long PostParent { get; set; }

    /// <summary>
    /// The menu_order element's value.
    /// </summary>
    public long MenuOrder { get; set; }

    /// <summary>
    /// The post_type element's value.
    /// </summary>
    public string PostType { get; set; } = null!;

    /// <summary>
    /// The post_password element's value.
    /// </summary>
    public string? PostPassword { get; set; }

    /// <summary>
    /// The is_sticky element's value.
    /// </summary>
    public bool IsSticky { get; set; }

    // Skipping postmeta because the values don't appear useful to non-WP installations.

    /// <summary>
    /// The post's comments.
    /// </summary>
    public IReadOnlyCollection<WordPressExportComment> Comments { get; private set; } = Array.Empty<WordPressExportComment>();


    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="itemElement"></param>
    public WordPressExportItem(XElement itemElement)
    {
        ArgumentNullException.ThrowIfNull(itemElement);

        Content = itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.ContentNamespacePrefix, elementName: "encoded")!;
        Excerpt = itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.ExcerptNamespacePrefix, elementName: "encoded");

        PostId = Helpers.TryParseLong(itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "post_id"))!.Value;
        PostDate = Helpers.TryParseDateTime(itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "post_date"))!.Value;

        // We can't assume that a post will have a valid GMT date. One of my entries did not.
        PostDateGmt = itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "post_date_gmt").ParseUtcOrDefault();

        PostModified = Helpers.TryParseDateTime(itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "post_modified"))!.Value;

        // We can't assume that a post will have a valid GMT date. One of my entries did not.
        PostModifiedGmt = itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "post_modified_gmt").ParseUtcOrDefault();

        CommentStatus = itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "comment_status")!;
        PingStatus = itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "ping_status")!;
        PostName = itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "post_name")!;
        Status = itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "status")!;

        PostParent = Helpers.TryParseLong(itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "post_parent"))!.Value;
        MenuOrder = Helpers.TryParseLong(itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "menu_order"))!.Value;
        PostType = itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "post_type")!;
        PostPassword = itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "post_password");
        IsSticky = itemElement.GetChildElementValue(namespacePrefix: WordPressExportChannel.NamespacePrefix, elementName: "is_sticky").ParseWordPressBooleanOrDefault()!.Value;

        Comments = ParseComments(itemElement);
    }


    //
    // Private methods
    //

    private static WordPressExportComment[] ParseComments(XElement itemElement)
    {
        // There can be many comment elements in the item.
        return itemElement.GetElements(namespacePrefix: WordPressExportChannel.NamespacePrefix, "comment")
            .Select(commentElement => new WordPressExportComment(commentElement))
            .ToArray();
    }
}
