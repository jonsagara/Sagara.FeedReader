namespace CodeHollow.FeedReader;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CodeHollow.FeedReader.Extensions;
using CodeHollow.FeedReader.Http;
using Feeds.MediaRSS;

/// <summary>
/// static class with helper functions
/// </summary>
public static class Helpers
{
    /// <summary>
    /// Download the content from an url and returns it as utf8 encoded string.
    /// Preferred way is to use <see cref="HttpClientHelper.DownloadBytesAsync(string, string, CancellationToken)"/> because it works
    /// better with encoding.
    /// </summary>
    /// <param name="url">correct url</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <returns>Content as string</returns>
    public static async Task<string> DownloadAsync(string url, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        var content = await HttpClientHelper.DownloadBytesAsync(url, cancellationToken: cancellationToken).ConfigureAwait(false);

        return Encoding.UTF8.GetString(content);
    }

    /// <summary>
    /// Tries to parse the string as datetime and returns null if it fails
    /// </summary>
    /// <param name="datetime">datetime as string</param>
    /// <param name="cultureInfo">The cultureInfo for parsing</param>
    /// <returns>datetime or null</returns>
    public static DateTime? TryParseDateTime(string? datetime, CultureInfo? cultureInfo = null)
    {
        if (string.IsNullOrWhiteSpace(datetime))
        {
            return null;
        }

        var dateTimeFormat = cultureInfo?.DateTimeFormat ?? DateTimeFormatInfo.CurrentInfo;
        bool parseSuccess = DateTimeOffset.TryParse(datetime, dateTimeFormat, DateTimeStyles.None, out var dt);

        if (!parseSuccess)
        {
            // Do, 22 Dez 2016 17:36:00 +0000
            // note - tried ParseExact with diff formats like "ddd, dd MMM yyyy hh:mm:ss K"
            if (datetime.Contains(","))
            {
                int pos = datetime.IndexOf(',') + 1;
                string newdtstring = datetime.Substring(pos).Trim();

                parseSuccess = DateTimeOffset.TryParse(newdtstring, dateTimeFormat, DateTimeStyles.None, out dt);
            }
            if (!parseSuccess)
            {
                string newdtstring = datetime.Substring(0, datetime.LastIndexOf(" ")).Trim();

                parseSuccess = DateTimeOffset.TryParse(newdtstring, dateTimeFormat, DateTimeStyles.AssumeUniversal, out dt);
            }

            if (!parseSuccess)
            {
                string newdtstring = datetime.Substring(0, datetime.LastIndexOf(" ")).Trim();

                parseSuccess = DateTimeOffset.TryParse(newdtstring, dateTimeFormat, DateTimeStyles.None, out dt);
            }
        }

        if (!parseSuccess)
        {
            return null;
        }

        return dt.UtcDateTime;
    }

    /// <summary>
    /// Tries to parse the string as int and returns null if it fails
    /// </summary>
    /// <param name="input">int as string</param>
    /// <returns>integer or null</returns>
    public static int? TryParseInt(string? input)
    {
        return int.TryParse(input, out var result)
            ? result
            : null;
    }

    /// <summary>
    /// Tries to parse a string and returns the media type
    /// </summary>
    /// <param name="medium">media type as string</param>
    /// <returns><see cref="Medium"/></returns>
    public static Medium TryParseMedium(string? medium)
    {
        if (string.IsNullOrWhiteSpace(medium))
        {
            return Medium.Unknown;
        }

        switch (medium.ToLower())
        {
            case "image":
                return Medium.Image;
            case "audio":
                return Medium.Audio;
            case "video":
                return Medium.Video;
            case "document":
                return Medium.Document;
            case "executable":
                return Medium.Executable;
            default:
                return Medium.Unknown;
        }
    }

    /// <summary>
    /// Tries to parse the string as int and returns null if it fails
    /// </summary>
    /// <param name="input">int as string</param>
    /// <returns>integer or null</returns>
    public static bool? TryParseBool(string? input)
    {
        return bool.TryParse(input, out var result)
            ? result
            : null;
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
