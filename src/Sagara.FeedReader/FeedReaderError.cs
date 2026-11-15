namespace Sagara.FeedReader;

/// <summary>
/// Describes why a feed could not be downloaded or parsed.
/// </summary>
/// <param name="Kind">The kind of failure. Use this to decide what to do, e.g., drop a subscription on
/// <see cref="FeedReaderErrorKind.HttpError"/> 404, or retry later on <see cref="FeedReaderErrorKind.Timeout"/>.</param>
/// <param name="Message">A human-readable description of the failure.</param>
/// <param name="Exception">The exception that caused the failure, if any.</param>
public sealed record FeedReaderError(FeedReaderErrorKind Kind, string Message, Exception? Exception = null);
