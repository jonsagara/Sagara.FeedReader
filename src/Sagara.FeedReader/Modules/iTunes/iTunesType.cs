namespace Sagara.FeedReader.Modules.iTunes;

/// <summary>
/// Represents the value of <c>itunes:type</c>, if present.
/// </summary>
public enum iTunesType
{
    /// <summary>
    /// Invalid value.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Default. Specify episodic when episodes are intended to be consumed without any specific order. Apple 
    /// Podcasts will present newest episodes first and display the publish date (required) of each episode.
    /// </summary>
    Episodic = 1,

    /// <summary>
    /// Specify serial when episodes are intended to be consumed in sequential order. Apple Podcasts will 
    /// present the oldest episodes first and display the episode numbers (required) of each episode.
    /// </summary>
    Serial = 2,
}
