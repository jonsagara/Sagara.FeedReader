namespace Sagara.FeedReader.Http;

/// <summary>
/// A common place to store configuration for named HttpClients.
/// </summary>
public static class NamedHttpClients
{
    private static readonly HttpClientPropertiesWithWaitAndRetry _feedReaderProperties = new HttpClientPropertiesWithWaitAndRetry(Name: "FeedReader", MaxRetryAttempts: 1);

    /// <summary>
    /// Customized HttpClient for making requests to RSS/Atom endpoints. Retries up to 1 time.
    /// </summary>
    public static HttpClientPropertiesWithWaitAndRetry FeedReader
        => _feedReaderProperties;
}


/// <summary>
/// Configuration for a Polly WaitAndRetry resilience strategy.
/// </summary>
/// <param name="Name">The name of the HttpClient.</param>
/// <param name="MaxRetryAttempts">The maximnum number of times to retry a request.</param>
public readonly record struct HttpClientPropertiesWithWaitAndRetry(string Name, int MaxRetryAttempts);
