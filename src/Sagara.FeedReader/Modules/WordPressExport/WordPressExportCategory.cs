namespace Sagara.FeedReader.Modules.WordPressExport;

/// <summary>
/// A post category.
/// </summary>
public class WordPressExportCategory
{
    /// <summary>
    /// The category's Id.
    /// </summary>
    public long TermId { get; set; }

    /// <summary>
    /// The category's nice name, which looks like a slug.
    /// </summary>
    public string NiceName { get; set; } = null!;

    /// <summary>
    /// The category's name.
    /// </summary>
    public string Name { get; set; } = null!;

    // NOTE: Currently does not support category_parent because I do not have an example file that uses it.
}
