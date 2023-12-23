using System.Net;
using Microsoft.Extensions.Http.Resilience;
using Polly;

namespace Sagara.FeedReader.Http;

/// <summary>
/// Configuration helper for the non-static version of FeedReader that uses
/// dependency injection.
/// </summary>
public static class FeedReaderHttpClientConfiguration
{
    /// <summary>
    /// Creates a customized HttpClientHandler that has automatic decompression enabled (GZip and Deflate).
    /// </summary>
    public static HttpClientHandler CreateHttpClientHandler()
        => new()
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            CheckCertificateRevocationList = true,
        };


    //private static readonly ILogger _logger = Log.Logger.ForContext(typeof(FeedReaderHttpClientConfiguration));

    /// <summary>
    /// Retry <paramref name="maxRetryAttempts"/> times with exponential backoff.
    /// </summary>
    /// <param name="pipelineBuilder">Used to create a resilience pipeline.</param>
    /// <param name="httpClientName">The HttpClient name. Used in logs when a retry occurs.</param>
    /// <param name="maxRetryAttempts">The maximum number of retries to use, in addition to the original call. Minimum is 1. Maximum is int.MaxValue.</param>
    public static void ConfigureRetryAndWaitWithExponentialBackoffStrategy(ResiliencePipelineBuilder<HttpResponseMessage> pipelineBuilder, string httpClientName, int maxRetryAttempts)
    {
        ArgumentNullException.ThrowIfNull(pipelineBuilder);
        ArgumentException.ThrowIfNullOrWhiteSpace(httpClientName);
        ArgumentOutOfRangeException.ThrowIfLessThan(maxRetryAttempts, 1);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(maxRetryAttempts, int.MaxValue);

        pipelineBuilder.AddRetry(new HttpRetryStrategyOptions
        {
            ShouldHandle = args => ValueTask.FromResult(HttpClientResiliencePredicates.IsTransient(args.Outcome)),
            MaxRetryAttempts = maxRetryAttempts,
            BackoffType = DelayBackoffType.Exponential,
            //OnRetry = args =>
            //{
            //    _logger.Warning(args.Outcome.Exception, "[HttpClient={HttpClientName}] Failed to send request to {RequestUri}. StatusCode: {StatusCodeInt} {StatusCode}. The attempt took {Duration}. Retrying after {RetryDelay}...",
            //        httpClientName,
            //        args.Outcome.Result?.RequestMessage?.RequestUri,
            //        (int?)args.Outcome.Result?.StatusCode,
            //        args.Outcome.Result?.StatusCode,
            //        args.Duration,
            //        args.RetryDelay
            //        );

            //    return ValueTask.CompletedTask;
            //}
        });
    }


    internal const string ACCEPT_HEADER_NAME = "Accept";
    internal const string ACCEPT_HEADER_VALUE = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
    internal const string USER_AGENT_NAME = "User-Agent";
    internal const string USER_AGENT_VALUE = "Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/36.0";
}
