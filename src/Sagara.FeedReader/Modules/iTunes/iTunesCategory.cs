namespace Sagara.FeedReader.Modules.iTunes;

/// <summary>
/// A category and optional subcategory for iTunes media.
/// </summary>
public class iTunesCategory
{
    /// <summary>
    /// Top-level category.
    /// </summary>
    public string? CategoryText { get; set; }

    /// <summary>
    /// Subcategory.
    /// </summary>
    public string? SubcategoryText { get; set; }
}
