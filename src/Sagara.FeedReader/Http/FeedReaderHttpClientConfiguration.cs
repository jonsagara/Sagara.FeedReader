using System.Net;
using Polly;

namespace Sagara.FeedReader.Http;

/// <summary>
/// Configuration helper for the non-static version of FeedReader that uses
/// dependency injection.
/// </summary>
public static class FeedReaderHttpClientConfiguration
{
    /// <summary>
    /// The HttpClient name that FeedReader expects to be registered.
    /// </summary>
    public const string HttpClientName = "FeedReader";

    /// <summary>
    /// Creates a customized HttpClientHandler that has automatic decompression enabled (GZip and Deflate).
    /// </summary>
    public static HttpClientHandler CreateHttpClientHandler()
        => new()
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
        };


    /// <summary>
    /// Wait 2^(retryAttempt) seconds between connection retries.
    /// </summary>
    private readonly static Func<int, TimeSpan> ExponentialBackoff =
        (retryAttempt) => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));

    /// <summary>
    /// Retry 1 time with exponential backoff. This mimics the existing behavior in the static client
    /// of retrying once, albeit with a ~2 second delay.
    /// </summary>
    public static IAsyncPolicy<HttpResponseMessage> BuildWaitAndRetryPolicy(PolicyBuilder<HttpResponseMessage> builder)
    {
        return builder
            .WaitAndRetryAsync(retryCount: 1, sleepDurationProvider: ExponentialBackoff);
    }


    internal const string ACCEPT_HEADER_NAME = "Accept";
    internal const string ACCEPT_HEADER_VALUE = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
    internal const string USER_AGENT_NAME = "User-Agent";
    internal const string USER_AGENT_VALUE = "Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/36.0";
}
