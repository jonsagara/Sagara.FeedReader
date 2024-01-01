using Microsoft.Extensions.Http.Resilience;
using Sagara.FeedReader.Http;

namespace Sagara.FeedReader.Configuration;

internal static class ResilienceHelper
{
    internal static readonly Action<Polly.ResiliencePipelineBuilder<HttpResponseMessage>, ResilienceHandlerContext> DefaultResilienceHandler = 
        (pipelineBuilder, _) =>
        {
            FeedReaderHttpClientConfiguration.ConfigureRetryAndWaitWithExponentialBackoffStrategy(pipelineBuilder, httpClientName: NamedHttpClients.FeedReader.Name, maxRetryAttempts: NamedHttpClients.FeedReader.MaxRetryAttempts);
        };
}
