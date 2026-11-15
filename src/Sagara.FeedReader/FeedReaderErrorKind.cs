namespace Sagara.FeedReader;

/// <summary>
/// The kind of failure that occurred while downloading or parsing a feed.
/// </summary>
public enum FeedReaderErrorKind
{
    /// <summary>
    /// The server returned a non-success HTTP status code.
    /// </summary>
    HttpError,

    /// <summary>
    /// The request failed before an HTTP response was received, e.g., a DNS, TLS, or connection failure.
    /// </summary>
    NetworkError,

    /// <summary>
    /// The request timed out.
    /// </summary>
    Timeout,

    /// <summary>
    /// The content is an HTML page, not a feed.
    /// </summary>
    NotAFeed,

    /// <summary>
    /// The content is empty or is not well-formed XML.
    /// </summary>
    InvalidXml,

    /// <summary>
    /// The content is well-formed XML, but its root element is not a supported feed type.
    /// </summary>
    UnsupportedFeedType,

    /// <summary>
    /// The response body exceeded the configured maximum size.
    /// </summary>
    ResponseTooLarge,

    /// <summary>
    /// The content is well-formed XML with a supported root element, but the feed could not be parsed, e.g.,
    /// because a required element is missing.
    /// </summary>
    ParseError,
}
