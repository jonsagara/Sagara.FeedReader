namespace Sagara.FeedReader;

using System;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Feeds.MediaRSS;
using Sagara.FeedReader.Extensions;
using Sagara.FeedReader.Http;

/// <summary>
/// static class with helper functions
/// </summary>
public static class Helpers
{
    /// <summary>
    /// Returns the absolute url of a link on a page. If you got the feed links via
    /// GetFeedUrlsFromUrl(url) and the url is relative, you can use this method to get the full url.
    /// </summary>
    /// <param name="pageUrl">the original url to the page</param>
    /// <param name="feedLink">a referenced feed (link)</param>
    /// <returns>a feed link</returns>
    /// <example>GetAbsoluteFeedUrl("codehollow.com", myRelativeFeedLink);</example>
    public static HtmlFeedLink GetAbsoluteFeedUrl(string pageUrl, HtmlFeedLink feedLink)
    {
        ArgumentNullException.ThrowIfNull(pageUrl);
        ArgumentNullException.ThrowIfNull(feedLink);
        ArgumentNullException.ThrowIfNull(feedLink.Url);

        string tmpUrl = feedLink.Url.HtmlDecode()!;
        pageUrl = GetAbsoluteUrl(pageUrl);

        if (tmpUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
            || tmpUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            return feedLink;
        }

        if (tmpUrl.StartsWith("//", StringComparison.OrdinalIgnoreCase)) // special case
        {
            tmpUrl = "http:" + tmpUrl;
        }

        if (Uri.TryCreate(tmpUrl, UriKind.RelativeOrAbsolute, out Uri? finalUri))
        {
            if (finalUri.IsAbsoluteUri)
            {
                return new HtmlFeedLink(feedLink.Title.HtmlDecode(), finalUri.ToString(), feedLink.FeedType);
            }
            else if (Uri.TryCreate(pageUrl + '/' + tmpUrl.TrimStart('/'), UriKind.Absolute, out finalUri))
            {
                return new HtmlFeedLink(feedLink.Title.HtmlDecode(), finalUri.ToString(), feedLink.FeedType);
            }
        }

        throw new UrlNotFoundException($"Could not get the absolute url out of {pageUrl} and {feedLink.Url}");
    }

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
            if (datetime.Contains(',', StringComparison.Ordinal))
            {
                int pos = datetime.IndexOf(',', StringComparison.Ordinal) + 1;
                string newdtstring = datetime.Substring(pos).Trim();

                parseSuccess = DateTimeOffset.TryParse(newdtstring, dateTimeFormat, DateTimeStyles.None, out dt);
            }
            if (!parseSuccess)
            {
                string newdtstring = datetime.Substring(0, datetime.LastIndexOf(' ')).Trim();

                parseSuccess = DateTimeOffset.TryParse(newdtstring, dateTimeFormat, DateTimeStyles.AssumeUniversal, out dt);
            }

            if (!parseSuccess)
            {
                string newdtstring = datetime.Substring(0, datetime.LastIndexOf(' ')).Trim();

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
        => int.TryParse(input, out var result)
            ? result
            : null;

    /// <summary>
    /// Tries to parse a string and returns the media type
    /// </summary>
    /// <param name="medium">media type as string</param>
    /// <returns><see cref="Medium"/></returns>
    public static Medium TryParseMedium(string? medium)
        => Enum.TryParse(medium, ignoreCase: true, out Medium result)
            ? result
            : Medium.Unknown;

    /// <summary>
    /// Tries to parse the string as int and returns null if it fails
    /// </summary>
    /// <param name="input">int as string</param>
    /// <returns>integer or null</returns>
    public static bool? TryParseBool(string? input)
        => bool.TryParse(input, out var result)
            ? result
            : null;


    //
    // Private/internal methods
    //

    /// <summary>
    /// Takes a url (with or without http) and returns the full url.
    /// </summary>
    /// <param name="url">Url with or without http.</param>
    /// <returns>Tull url</returns>
    /// <example>GetUrl("codehollow.com"); => returns https://codehollow.com</example>
    internal static string GetAbsoluteUrl(string url)
        => new UriBuilder(url).Uri.ToString();
}
