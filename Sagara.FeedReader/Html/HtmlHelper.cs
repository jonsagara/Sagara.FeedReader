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
    /// Returns a HtmlFeedLink object from a linktag (link href="" type="")
    /// only support application/rss and application/atom as type
    /// if type is not supported, null is returned
    /// </summary>
    /// <param name="input">link tag, e.g. &lt;link rel="alternate" type="application/rss+xml" title="codehollow &gt; Feed" href="https://codehollow.com/feed/" /&gt;</param>
    /// <returns>Parsed HtmlFeedLink</returns>
    public static HtmlFeedLink? GetFeedLinkFromLinkTag(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        string linkTag = input.HtmlDecode()!;
        string type = GetAttributeFromLinkTag("type", linkTag).ToLower();

        if (!type.Contains("application/rss") && !type.Contains("application/atom"))
        {
            return null;
        }

        HtmlFeedLink hfl = new();
        hfl.Title = GetAttributeFromLinkTag("title", linkTag);
        hfl.Url = GetAttributeFromLinkTag("href", linkTag);
        hfl.FeedType = type.Contains("rss") ? FeedType.Rss : FeedType.Atom;
        return hfl;
    }


    //
    // Private methods
    //

    /// <summary>
    /// reads an attribute from an html tag
    /// </summary>
    /// <param name="attribute">name of the attribute, e.g. title</param>
    /// <param name="htmlTag">the html tag, e.g. &lt;link title="my title"&gt;</param>
    /// <returns>the value of the attribute, e.g. my title</returns>
    private static string GetAttributeFromLinkTag(string attribute, string htmlTag)
    {
        var res = Regex.Match(htmlTag, attribute + "\\s*=\\s*\"(?<val>[^\"]*)\"", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

        if (res.Groups.Count > 1)
        {
            return res.Groups[1].Value;
        }

        return string.Empty;
    }
}
