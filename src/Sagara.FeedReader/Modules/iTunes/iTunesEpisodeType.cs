namespace Sagara.FeedReader.Modules.iTunes;

/// <summary>
/// Represents the value of <c>itunes:episodeType</c>, if present.
/// </summary>
public enum iTunesEpisodeType
{
    /// <summary>
    /// Invalid value.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Default. Specify full when you are submitting the complete content of your show.
    /// </summary>
    Full = 1,

    /// <summary>
    /// Specify trailer when you are submitting a short, promotional piece of content that represents a preview of 
    /// your current show.
    /// </summary>
    Trailer = 2,

    /// <summary>
    /// Specify bonus when you are submitting extra content for your show (for example, behind the scenes information 
    /// or interviews with the cast) or cross-promotional content for another show.
    /// </summary>
    Bonus = 3,
}
