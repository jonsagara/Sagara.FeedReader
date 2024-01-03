using System.Collections.Frozen;

namespace Sagara.FeedReader.Feeds.Itunes;

/// <summary>
/// Internal helpers for iTunes feeds.
/// </summary>
internal static class ItunesHelper
{
    /// <summary>
    /// Set of values that denote explicit content in an iTunes feed.
    /// </summary>
    private static readonly FrozenSet<string> _explicitValue = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "yes",
            "explicit",
            "true",
        }
        .ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Returns true if <paramref name="value"/> is one of the values denoting explicit iTunes content; false otherwise.
    /// </summary>
    /// <param name="value">The value from an iTunes feed describing whether content is explicit.</param>
    internal static bool IsExplicit(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        return _explicitValue.Contains(value);
    }
}
