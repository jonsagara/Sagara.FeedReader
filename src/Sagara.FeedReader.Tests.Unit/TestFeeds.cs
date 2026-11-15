using Xunit;

namespace Sagara.FeedReader.Tests.Unit;

/// <summary>
/// Helpers for parsing the feed files in the Feeds folder.
/// </summary>
internal static class TestFeeds
{
    /// <summary>
    /// Parse the feed file at <paramref name="path"/> with <see cref="FeedParser.ParseAsync(Stream, CancellationToken)"/>.
    /// </summary>
    public static async Task<Feed> ParseFileAsync(string path, CancellationToken cancellationToken = default)
    {
        await using var stream = File.OpenRead(path);

        return await FeedParser.ParseAsync(stream, cancellationToken);
    }

    /// <summary>
    /// Every feed file in the Feeds folder, for use with <c>[MemberData]</c>.
    /// </summary>
    public static TheoryData<string> AllFeedFiles
        => new(Directory.EnumerateFiles("Feeds", "*.xml").Order(StringComparer.Ordinal));
}
