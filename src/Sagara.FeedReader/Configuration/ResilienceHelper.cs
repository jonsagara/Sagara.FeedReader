using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Polly;

namespace Sagara.FeedReader.Configuration;

internal static class ResilienceHelper
{
    /// <summary>
    /// The name of the HttpClient that FeedReader uses. Appears in HttpClient and resilience pipeline logs.
    /// </summary>
    internal const string HttpClientName = "FeedReader.HttpClient";

    /// <summary>
    /// The default resilience pipeline retries transient failures up to this many times.
    /// </summary>
    internal const int MaxRetryAttempts = 1;

    internal static readonly Action<ResiliencePipelineBuilder<HttpResponseMessage>, ResilienceHandlerContext> DefaultResilienceHandler =
        (pipelineBuilder, context) =>
        {
            var loggerFactory = context.ServiceProvider.GetService<ILoggerFactory>() ?? NullLoggerFactory.Instance;
            var logger = loggerFactory.CreateLogger(typeof(ResilienceHelper));

            pipelineBuilder.AddRetry(new HttpRetryStrategyOptions
            {
                ShouldHandle = args => ValueTask.FromResult(HttpClientResiliencePredicates.IsTransient(args.Outcome)),
                MaxRetryAttempts = ResilienceHelper.MaxRetryAttempts,
                BackoffType = DelayBackoffType.Exponential,
                OnRetry = args =>
                {
                    logger.OnRetry(
                        args.Outcome.Exception,
                        httpClientName: HttpClientName,
                        requestUri: args.Outcome.Result?.RequestMessage?.RequestUri,
                        statusCodeInt: (int?)args.Outcome.Result?.StatusCode,
                        statusCode: args.Outcome.Result?.StatusCode,
                        duration: args.Duration,
                        retryDelay: args.RetryDelay
                        );

                    return ValueTask.CompletedTask;
                }
            });
        };
}

internal static partial class ResilienceLogger
{
    [LoggerMessage(Level = LogLevel.Warning, EventId = 100, Message = "[HttpClient={HttpClientName}] Failed to send request to {RequestUri}. StatusCode: {StatusCodeInt} {StatusCode}. The attempt took {Duration}. Retrying after {RetryDelay}...")]
    internal static partial void OnRetry(this ILogger logger, Exception? ex, string httpClientName, Uri? requestUri, int? statusCodeInt, HttpStatusCode? statusCode, TimeSpan duration, TimeSpan retryDelay);
}
