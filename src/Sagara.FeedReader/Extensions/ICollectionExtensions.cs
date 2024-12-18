﻿namespace Sagara.FeedReader.Extensions;

/// <summary>
/// Extension methods for the ICollection&lt;T&gt; interface.
/// </summary>
public static class ICollectionExtensions
{
    /// <summary>
    /// Add a range of values to the collection.
    /// </summary>
    public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> valuesToAdd)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(valuesToAdd);

        foreach (var valueToAdd in valuesToAdd)
        {
            source.Add(valueToAdd);
        }
    }
}
