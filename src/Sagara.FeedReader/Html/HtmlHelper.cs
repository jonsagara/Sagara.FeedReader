using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Html;

/// <summary>
/// Contains HTML helper methods.
/// </summary>
public static partial class HtmlHelper
{
    [GeneratedRegex(pattern: "<link[^>]*rel=\"alternate\"[^>]*>", options: RegexOptions.Singleline)]
    private static partial Regex LinkTag();

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

        foreach (Match m in LinkTag().Matches(htmlContent))
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
    /// Parses feed links from an HTML page and resolves them against <paramref name="baseUri"/>, so that every returned
    /// URL is absolute. Links that can't be resolved to an http or https URL are skipped.
    /// </summary>
    /// <param name="htmlContent">The content of the HTML page.</param>
    /// <param name="baseUri">The absolute URI of the page, used to resolve relative links. Use the page's final URI
    /// after redirects.</param>
    /// <returns>All feed links, with absolute URLs.</returns>
    /// <exception cref="ArgumentException"><paramref name="baseUri"/> is not absolute.</exception>
    public static IReadOnlyCollection<HtmlFeedLink> ParseFeedUrlsFromHtml(string htmlContent, Uri baseUri)
    {
        ArgumentNullException.ThrowIfNull(htmlContent);
        ArgumentNullException.ThrowIfNull(baseUri);

        if (!baseUri.IsAbsoluteUri)
        {
            throw new ArgumentException($"'{baseUri}' is not an absolute URI.", nameof(baseUri));
        }

        List<HtmlFeedLink> resolvedLinks = new();

        foreach (var feedLink in ParseFeedUrlsFromHtml(htmlContent))
        {
            var resolvedLink = ResolveFeedLink(feedLink, baseUri);
            if (resolvedLink is not null)
            {
                resolvedLinks.Add(resolvedLink);
            }
        }

        return resolvedLinks;
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
    /// Resolve the link's URL against <paramref name="baseUri"/>. Handles absolute ("https://..."), scheme-relative ("//host/feed"),
    /// root-relative ("/feed"), and path-relative ("feed") URLs. Returns null if the result isn't an http or https URL.
    /// </summary>
    private static HtmlFeedLink? ResolveFeedLink(HtmlFeedLink feedLink, Uri baseUri)
    {
        // The link tag was already HTML-decoded by GetFeedLinkFromLinkTag.
        var url = feedLink.Url?.Trim();
        if (string.IsNullOrEmpty(url))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, url, out var absoluteUri) || !FeedReader.IsHttpOrHttps(absoluteUri))
        {
            return null;
        }

        return new HtmlFeedLink(feedLink.Title, absoluteUri.AbsoluteUri, feedLink.FeedType);
    }

    /// <summary>
    /// Identifies and extracts an HTML attribute value.
    /// </summary>
    [StringSyntax(StringSyntaxAttribute.Regex)]
    private const string AttributeValueRegexFormat = "\\s*=\\s*\"(?<val>[^\"]*)\"";

    [GeneratedRegex(pattern: $"type{AttributeValueRegexFormat}", options: RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace)]
    private static partial Regex TypeAttributeValue();

    [GeneratedRegex(pattern: $"title{AttributeValueRegexFormat}", options: RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace)]
    private static partial Regex TitleAttributeValue();

    [GeneratedRegex($"href{AttributeValueRegexFormat}", options: RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace)]
    private static partial Regex HREFAttributeValue();

    /// <summary>
    /// Reads the type attribute value from an HTML &lt;link /&gt; tag.
    /// </summary>
    /// <param name="linkTagHtml">The HTML tag, e.g. &lt;link title=&quot;my title&quot;&gt;.</param>
    private static string GetTypeAttributeValueFromLinkTag(string linkTagHtml)
        => GetAttributeValueFromLinkTag(linkTagHtml, TypeAttributeValue());

    /// <summary>
    /// Reads the title attribute value from an HTML &lt;link /&gt; tag.
    /// </summary>
    /// <param name="linkTagHtml">The HTML tag, e.g. &lt;link title=&quot;my title&quot;&gt;.</param>
    private static string GetTitleAttributeValueFromLinkTag(string linkTagHtml)
        => GetAttributeValueFromLinkTag(linkTagHtml, TitleAttributeValue());

    /// <summary>
    /// Reads the href attribute value from an HTML &lt;link /&gt; tag.
    /// </summary>
    /// <param name="linkTagHtml">The HTML tag, e.g. &lt;link title=&quot;my title&quot;&gt;.</param>
    private static string GetHREFAttributeValueFromLinkTag(string linkTagHtml)
        => GetAttributeValueFromLinkTag(linkTagHtml, HREFAttributeValue());

    private static string GetAttributeValueFromLinkTag(string linkTagHtml, Regex rxAttributeValue)
    {
        var matchResult = rxAttributeValue.Match(linkTagHtml);

        return matchResult.Groups.Count > 1
            ? matchResult.Groups[1].Value
            : string.Empty;
    }
}
