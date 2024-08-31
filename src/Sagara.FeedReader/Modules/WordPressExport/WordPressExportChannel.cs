using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Modules.WordPressExport;

/// <summary>
/// <para>Data from an iTunes channel in either RSS 2.0 or Atom.</para>
/// <para>In RSS 2.0, this is direct child elements of the <c>channel</c> element, each within the <c>itunes</c> namespace.</para>
/// <para>In Atom, this is direct child elements of the <c>feed</c> element, each within the <c>im</c> namespace.</para>
/// </summary>
/// <remarks>
/// <para>See this article for RSS 2.0 requirements: https://help.apple.com/itc/podcasts_connect/#/itcb54353390</para>
/// <para>Apple no longer accepts Atom feeds for podcasts, so I don't see <c>im</c> documented anywhere.</para>
/// </remarks>
public class WordPressExportChannel
{
    internal const string NamespacePrefix = "wp";
    internal const string ContentNamespacePrefix = "content";
    internal const string DCNamespacePrefix = "dc";
    internal const string ExcerptNamespacePrefix = "excerpt";
    internal const string WFWNamespacePrefix = "wfw";

    /// <summary>
    /// The wxr_version element's value.
    /// </summary>
    public string? WxrVersion { get; set; }

    /// <summary>
    /// The base_site_url element's value.
    /// </summary>
    public string? BaseSiteUrl { get; set; }

    /// <summary>
    /// The base_blog_url element's value.
    /// </summary>
    public string? BaseBlogUrl { get; set; }

    /// <summary>
    /// Information about the WordPress site's author.
    /// </summary>
    public WordPressExportAuthor? Author { get; set; }

    /// <summary>
    /// The WordPress site's categories.
    /// </summary>
    public IReadOnlyCollection<WordPressExportCategory> Categories { get; private set; } = Array.Empty<WordPressExportCategory>();

    /// <summary>
    /// The WordPress site's tags.
    /// </summary>
    public IReadOnlyCollection<WordPressExportTag> Tags { get; private set; } = Array.Empty<WordPressExportTag>();


    private readonly ILogger<WordPressExportChannel> _logger;


    /// <summary>
    /// .ctor
    /// </summary>
    public WordPressExportChannel(XElement channelElement, ILoggerFactory? loggerFactory = null)
    {
        ArgumentNullException.ThrowIfNull(channelElement);

        loggerFactory ??= NullLoggerFactory.Instance;
        _logger = loggerFactory.CreateLogger<WordPressExportChannel>();

        var authorElement = channelElement.GetElement(namespacePrefix: NamespacePrefix, elementName: "author");
        if (authorElement is not null)
        {
            Author = new WordPressExportAuthor(authorElement);
        }

        Categories = ParseCategories(channelElement);

        Tags = ParseTags(channelElement);
    }


    //
    // Private methods
    //

    private static WordPressExportCategory[] ParseCategories(XElement channelElement)
    {
        // There can be many category elements in the channel.
        return channelElement.GetElements(namespacePrefix: NamespacePrefix, elementName: "category")
            .Select(catElement =>
            {
                var termId = Helpers.TryParseLong(catElement.GetChildElementValue(namespacePrefix: NamespacePrefix, elementName: "term_id"))!.Value;
                var niceName = catElement.GetChildElementValue(namespacePrefix: NamespacePrefix, elementName: "category_nicename")!;
                var name = catElement.GetChildElementValue(namespacePrefix: NamespacePrefix, elementName: "cat_name")!;

                return new WordPressExportCategory
                {
                    TermId = termId,
                    NiceName = niceName,
                    Name = name,
                };
            })
            .ToArray();
    }

    private static WordPressExportTag[] ParseTags(XElement channelElement)
    {
        // There can be many tag elements in the channel.
        return channelElement.GetElements(namespacePrefix: NamespacePrefix, elementName: "tag")
            .Select(catElement =>
            {
                var termId = Helpers.TryParseLong(catElement.GetChildElementValue(namespacePrefix: NamespacePrefix, elementName: "term_id"))!.Value;
                var slug = catElement.GetChildElementValue(namespacePrefix: NamespacePrefix, elementName: "tag_slug")!;
                var name = catElement.GetChildElementValue(namespacePrefix: NamespacePrefix, elementName: "tag_name")!;

                return new WordPressExportTag
                {
                    TermId = termId,
                    Slug = slug,
                    Name = name,
                };
            })
            .ToArray();
    }
}
