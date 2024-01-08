namespace Sagara.FeedReader.Modules.iTunes;

/// <summary>
/// A category and optional subcategory for iTunes media.
/// </summary>
public class iTunesCategory
{
    /// <summary>
    /// Top-level category.
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// Subcategory.
    /// </summary>
    public string? Subcategory { get; set; }
}
