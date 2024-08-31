namespace Sagara.FeedReader.Modules.WordPressExport;

/// <summary>
/// A tag used by posts.
/// </summary>
public class WordPressExportTag
{
    /// <summary>
    /// Tag Id.
    /// </summary>
    public long TermId { get; set; }

    /// <summary>
    /// The tag's url-safe slug.
    /// </summary>
    public string Slug { get; set; } = null!;

    /// <summary>
    /// The tag's name.
    /// </summary>
    public string Name { get; set; } = null!;
}
