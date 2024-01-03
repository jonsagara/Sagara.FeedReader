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
}
