namespace Sagara.FeedReader.Modules.ApplePodcasts;

/// <summary>
/// A category and optional subcategory for iTunes media.
/// </summary>
public class iTunesCategory
{
    /// <summary>
    /// Top-level category text.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Optional Subcategory.
    /// </summary>
    public iTunesCategory? Subcategory { get; set; }
}
