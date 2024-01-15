namespace Sagara.FeedReader.Modules.ApplePodcasts;

/// <summary>
/// A category and optional subcategory for iTunes media.
/// </summary>
public class iTunesCategory
{
    /// <summary>
    /// The category text.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Optional Subcategory.
    /// </summary>
    public iTunesSubcategory? Subcategory { get; set; }
}

/// <summary>
/// Since a subcategory has no subcategories of its own, give it its own entity without
/// a Subcategory property.
/// </summary>
public class iTunesSubcategory
{
    /// <summary>
    /// The subcategory text.
    /// </summary>
    public string? Text { get; set; }
}
