using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Sagara.FeedReader;

/// <summary>
/// The outcome of downloading or parsing a feed: either a <see cref="Value"/> or an <see cref="Error"/>, never both.
/// </summary>
/// <remarks>
/// Create instances with <see cref="FeedReaderResult.Success{T}(T, HttpStatusCode?, Uri?)"/> and
/// <see cref="FeedReaderResult.Failure{T}(FeedReaderError, HttpStatusCode?, Uri?)"/>.
/// </remarks>
/// <typeparam name="T">The type of the value returned on success.</typeparam>
public sealed class FeedReaderResult<T>
    where T : class
{
    /// <summary>
    /// True if the operation succeeded, in which case <see cref="Value"/> is not null. False if it failed,
    /// in which case <see cref="Error"/> is not null.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Value))]
    [MemberNotNullWhen(false, nameof(Error))]
    public bool IsSuccess { get; }

    /// <summary>
    /// The value, if the operation succeeded. Otherwise, null.
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// Why the operation failed, if it failed. Otherwise, null.
    /// </summary>
    public FeedReaderError? Error { get; }

    /// <summary>
    /// The HTTP status code of the response, if an HTTP response was received. Null when parsing local
    /// content, or when the request failed before a response arrived.
    /// </summary>
    public HttpStatusCode? StatusCode { get; }

    /// <summary>
    /// The URI that the content was ultimately read from, after following any redirects. Null when parsing
    /// local content, or when the request failed before a response arrived.
    /// </summary>
    /// <remarks>
    /// If this differs from the requested URI because of a permanent redirect, consider updating any stored URI.
    /// </remarks>
    public Uri? FinalUri { get; }

    internal FeedReaderResult(T? value, FeedReaderError? error, HttpStatusCode? statusCode, Uri? finalUri)
    {
        IsSuccess = error is null;
        Value = value;
        Error = error;
        StatusCode = statusCode;
        FinalUri = finalUri;
    }
}

/// <summary>
/// Factory methods for <see cref="FeedReaderResult{T}"/>.
/// </summary>
public static class FeedReaderResult
{
    /// <summary>
    /// Create a successful result.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value. Must not be null.</param>
    /// <param name="statusCode">The HTTP status code of the response, if any.</param>
    /// <param name="finalUri">The URI the content was read from after redirects, if any.</param>
    public static FeedReaderResult<T> Success<T>(T value, HttpStatusCode? statusCode = null, Uri? finalUri = null)
        where T : class
    {
        ArgumentNullException.ThrowIfNull(value);

        return new FeedReaderResult<T>(value, error: null, statusCode, finalUri);
    }

    /// <summary>
    /// Create a failed result.
    /// </summary>
    /// <typeparam name="T">The type of the value that would have been returned on success.</typeparam>
    /// <param name="error">Why the operation failed. Must not be null.</param>
    /// <param name="statusCode">The HTTP status code of the response, if any.</param>
    /// <param name="finalUri">The URI the content was read from after redirects, if any.</param>
    public static FeedReaderResult<T> Failure<T>(FeedReaderError error, HttpStatusCode? statusCode = null, Uri? finalUri = null)
        where T : class
    {
        ArgumentNullException.ThrowIfNull(error);

        return new FeedReaderResult<T>(value: null, error, statusCode, finalUri);
    }
}
