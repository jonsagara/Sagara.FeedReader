using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Logging;
using Polly;
using Sagara.FeedReader.Http;

namespace Sagara.FeedReader.Configuration;

internal static class ResilienceHelper
{
    internal static readonly Action<ResiliencePipelineBuilder<HttpResponseMessage>, ResilienceHandlerContext> DefaultResilienceHandler =
        (pipelineBuilder, context) =>
        {
            var loggerFactory = context.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger(typeof(ResilienceHelper));

            pipelineBuilder.AddRetry(new HttpRetryStrategyOptions
            {
                ShouldHandle = args => ValueTask.FromResult(HttpClientResiliencePredicates.IsTransient(args.Outcome)),
                MaxRetryAttempts = NamedHttpClients.FeedReader.MaxRetryAttempts,
                BackoffType = DelayBackoffType.Exponential,
                OnRetry = args =>
                {
                    logger.OnRetry(
                        args.Outcome.Exception,
                        httpClientName: NamedHttpClients.FeedReader.Name,
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
