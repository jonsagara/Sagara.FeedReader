using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Html;

/// <summary>
/// Contains HTML helper methods.
/// </summary>
public static class HtmlHelper
{
    private static readonly Regex _rxLinkTag = new Regex("<link[^>]*rel=\"alternate\"[^>]*>", RegexOptions.Singleline | RegexOptions.Compiled);

    /// <summary>
    /// Parses RSS links from html page and returns all links
    /// </summary>
    /// <param name="htmlContent">the content of the html page</param>
    /// <returns>all RSS/feed links</returns>
    public static IReadOnlyCollection<HtmlFeedLink> ParseFeedUrlsFromHtml(string htmlContent)
    {
        ArgumentNullException.ThrowIfNull(htmlContent);

        // sample link:
        // <link rel="alternate" type="application/rss+xml" title="Microsoft Bot Framework Blog" href="http://blog.botframework.com/feed.xml">
        // <link rel="alternate" type="application/atom+xml" title="Aktuelle News von heise online" href="https://www.heise.de/newsticker/heise-atom.xml">

        List<HtmlFeedLink> feedLinks = new();

        foreach (Match m in _rxLinkTag.Matches(htmlContent))
        {
            var hfl = GetFeedLinkFromLinkTag(m.Value);
            if (hfl is not null)
            {
                feedLinks.Add(hfl);
            }
        }

        return feedLinks;
    }

    /// <summary>
    /// Returns a HtmlFeedLink object from a linktag (link href=&quot;&quot; type=&quot;&quot;)
    /// only support application/rss and application/atom as type
    /// if type is not supported, null is returned
    /// </summary>
    /// <param name="input">link tag, e.g. &lt;link rel=&quot;alternate&quot; type=&quot;application/rss+xml&quot; title=&quot;codehollow &gt; Feed&quot; href=&quot;https://codehollow.com/feed/&quot; /&gt;</param>
    /// <returns>Parsed HtmlFeedLink</returns>
    public static HtmlFeedLink? GetFeedLinkFromLinkTag(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        string linkTag = input.HtmlDecode()!;

        // Justification: we know this will be application/rss or similar. We don't need to worry about non-roundtripable characters here.
#pragma warning disable CA1308 // Normalize strings to uppercase
        string type = GetTypeAttributeValueFromLinkTag(linkTag).ToLowerInvariant();
#pragma warning restore CA1308 // Normalize strings to uppercase

        if (!type.Contains("application/rss", StringComparison.Ordinal) && !type.Contains("application/atom", StringComparison.Ordinal))
        {
            return null;
        }

        HtmlFeedLink hfl = new();
        hfl.Title = GetTitleAttributeValueFromLinkTag(linkTag);
        hfl.Url = GetHREFAttributeValueFromLinkTag(linkTag);
        hfl.FeedType = type.Contains("rss", StringComparison.Ordinal) ? FeedType.Rss : FeedType.Atom;
        return hfl;
    }


    //
    // Private methods
    //

    /// <summary>
    /// Identifies and extracts an HTML attribute value.
    /// </summary>
    [StringSyntax(StringSyntaxAttribute.Regex)]
    private const string AttributeValueRegexFormat = "\\s*=\\s*\"(?<val>[^\"]*)\"";

    private static readonly Regex _rxTypeAttributeValue = new Regex($"type{AttributeValueRegexFormat}", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
    private static readonly Regex _rxTitleAttributeValue = new Regex($"title{AttributeValueRegexFormat}", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
    private static readonly Regex _rxHREFAttributeValue = new Regex($"href{AttributeValueRegexFormat}", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);

    /// <summary>
    /// Reads the type attribute value from an HTML &lt;link /&gt; tag.
    /// </summary>
    /// <param name="linkTagHtml">The HTML tag, e.g. &lt;link title=&quot;my title&quot;&gt;.</param>
    private static string GetTypeAttributeValueFromLinkTag(string linkTagHtml)
        => GetAttributeValueFromLinkTag(linkTagHtml, _rxTypeAttributeValue);

    /// <summary>
    /// Reads the title attribute value from an HTML &lt;link /&gt; tag.
    /// </summary>
    /// <param name="linkTagHtml">The HTML tag, e.g. &lt;link title=&quot;my title&quot;&gt;.</param>
    private static string GetTitleAttributeValueFromLinkTag(string linkTagHtml)
        => GetAttributeValueFromLinkTag(linkTagHtml, _rxTitleAttributeValue);

    /// <summary>
    /// Reads the href attribute value from an HTML &lt;link /&gt; tag.
    /// </summary>
    /// <param name="linkTagHtml">The HTML tag, e.g. &lt;link title=&quot;my title&quot;&gt;.</param>
    private static string GetHREFAttributeValueFromLinkTag(string linkTagHtml)
        => GetAttributeValueFromLinkTag(linkTagHtml, _rxHREFAttributeValue);

    private static string GetAttributeValueFromLinkTag(string linkTagHtml, Regex rxAttributeValue)
    {
        var matchResult = rxAttributeValue.Match(linkTagHtml);

        return matchResult.Groups.Count > 1
            ? matchResult.Groups[1].Value
            : string.Empty;
    }
}
