namespace Sagara.FeedReader;

/// <summary>
/// Thrown when feed content cannot be parsed. <see cref="Kind"/> says why.
/// </summary>
public sealed class FeedParseException : Exception
{
    /// <summary>
    /// Why the content could not be parsed. One of <see cref="FeedReaderErrorKind.InvalidXml"/>,
    /// <see cref="FeedReaderErrorKind.NotAFeed"/>, or <see cref="FeedReaderErrorKind.UnsupportedFeedType"/>.
    /// </summary>
    public FeedReaderErrorKind Kind { get; }

    /// <summary>
    /// Initializes a new <see cref="FeedParseException"/> with <see cref="Kind"/> set to <see cref="FeedReaderErrorKind.InvalidXml"/>.
    /// </summary>
    public FeedParseException()
        : this(FeedReaderErrorKind.InvalidXml, "The feed content could not be parsed.")
    {
    }

    /// <summary>
    /// Initializes a new <see cref="FeedParseException"/> with <see cref="Kind"/> set to <see cref="FeedReaderErrorKind.InvalidXml"/>.
    /// </summary>
    /// <param name="message">The error message.</param>
    public FeedParseException(string message)
        : this(FeedReaderErrorKind.InvalidXml, message)
    {
    }

    /// <summary>
    /// Initializes a new <see cref="FeedParseException"/> with <see cref="Kind"/> set to <see cref="FeedReaderErrorKind.InvalidXml"/>.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The exception that caused this one.</param>
    public FeedParseException(string message, Exception? innerException)
        : this(FeedReaderErrorKind.InvalidXml, message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new <see cref="FeedParseException"/>.
    /// </summary>
    /// <param name="kind">Why the content could not be parsed.</param>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The exception that caused this one, if any.</param>
    public FeedParseException(FeedReaderErrorKind kind, string message, Exception? innerException = null)
        : base(message, innerException)
    {
        Kind = kind;
    }
}
