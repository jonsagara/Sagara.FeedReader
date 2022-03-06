namespace CodeHollow.FeedReader.Feeds.Itunes;

/// <summary>
/// The itunes:category element
/// </summary>
public class ItunesCategory
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ItunesCategory"/> class.
    /// itunes:category element
    /// </summary>
    internal ItunesCategory(string? text, ItunesCategory[] children)
    {
        Text = text;
        Children = children;
    }

    /// <summary>
    /// The text attribute
    /// </summary>
    public string? Text { get; }

    /// <summary>
    /// All child itunes:category elements
    /// </summary>
    public ItunesCategory[] Children { get; }
}
