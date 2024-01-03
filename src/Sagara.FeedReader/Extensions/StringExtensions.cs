namespace Sagara.FeedReader.Extensions;

using System;
using System.Net;

/// <summary>
/// Extension methods
/// </summary>
internal static class StringExtensions
{
    /// <summary>
    /// Decodes a html encoded string
    /// </summary>
    /// <param name="text">html text</param>
    /// <returns>decoded html</returns>
    public static string? HtmlDecode(this string? text)
        => WebUtility.HtmlDecode(text);

    /// <summary>
    /// Determines whether this string and another string object have the same value.
    /// </summary>
    /// <param name="text">the string</param>
    /// <param name="compareTo">the string to compare to</param>
    /// <returns>True if two strings are equal in a case-insensitive comparison; false otherwise.</returns>
    public static bool EqualsIgnoreCase(this string? text, string? compareTo)
        => string.Equals(text, compareTo, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Determines whether this string equals one of the given strings. If any string
    /// matches, the method returns immediately without evaluating the remaining options.
    /// </summary>
    /// <param name="text">the string</param>
    /// <param name="candidates">all strings to compare to</param>
    /// <returns>True if the text matches of any of the candidate strings; false otherwise.</returns>
    public static bool EqualsAnyIgnoreCase(this string? text, params string[] candidates)
    {
        ArgumentNullException.ThrowIfNull(candidates);

        foreach (var candidate in candidates)
        {
            if (text.EqualsIgnoreCase(candidate))
            {
                return true;
            }
        }

        return false;
    }
}
