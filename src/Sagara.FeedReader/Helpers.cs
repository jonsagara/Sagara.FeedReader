namespace Sagara.FeedReader;

using System;
using System.Globalization;
using Feeds.MediaRSS;
using Sagara.FeedReader.Extensions;

/// <summary>
/// static class with helper functions
/// </summary>
public static class Helpers
{
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
                // CA1307: net11.0 adds a LastIndexOf(char, StringComparison) overload that net10.0 doesn't have,
                // so it can't be used while multi-targeting both.
#pragma warning disable CA1307
                string newdtstring = datetime.Substring(0, datetime.LastIndexOf(' ')).Trim();
#pragma warning restore CA1307

                parseSuccess = DateTimeOffset.TryParse(newdtstring, dateTimeFormat, DateTimeStyles.AssumeUniversal, out dt);
            }

            if (!parseSuccess)
            {
                // CA1307: net11.0 adds a LastIndexOf(char, StringComparison) overload that net10.0 doesn't have,
                // so it can't be used while multi-targeting both.
#pragma warning disable CA1307
                string newdtstring = datetime.Substring(0, datetime.LastIndexOf(' ')).Trim();
#pragma warning restore CA1307

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
    /// Tries to parse the string as long and returns null if it fails
    /// </summary>
    /// <param name="input">long as string</param>
    /// <returns>long or null</returns>
    public static long? TryParseLong(string? input)
        => long.TryParse(input, out var result)
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
}
