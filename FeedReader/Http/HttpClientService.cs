using Microsoft.IO;

namespace CodeHollow.FeedReader.Http;

/// <summary>
/// New instance-based class that makes HTTP requests to download the feeds themselves, 
/// or pages to look for feed links.
/// </summary>
public class HttpClientService : IFeedReaderService
{
    private readonly HttpClient _httpClient;
    private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="recyclableMemoryStreamManager"></param>
    public HttpClientService(IHttpClientFactory httpClientFactory, RecyclableMemoryStreamManager recyclableMemoryStreamManager)
    {
        _httpClient = httpClientFactory.CreateClient(FeedReaderHttpClientConfiguration.HttpClientName);
        _recyclableMemoryStreamManager = recyclableMemoryStreamManager;
    }


    /// <summary>
    /// Download the content from the specified URL.
    /// </summary>
    /// <param name="url">The URLs content we are downloading.</param>
    /// <param name="cancellationToken">Token to cancel operation</param>
    /// <param name="userAgent">Override built-in user-agent header</param>
    /// <returns>A MemoryStream containing the downloaded content.</returns>
    public async Task<MemoryStream> DownloadStreamAsync(string url, string? userAgent = FeedReaderHttpClientConfiguration.USER_AGENT_VALUE, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
