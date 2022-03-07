using System.Net;
using Microsoft.IO;

namespace CodeHollow.FeedReader.Http;

/// <summary>
/// New instance-based class that makes HTTP requests to download the feeds themselves, 
/// or pages to look for feed links.
/// </summary>
internal class HttpClientService : IFeedReaderService
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

        url = WebUtility.UrlDecode(url);

        // Make an initial request. Note that HttpClient will follow up to 50 redirects by default.
        using var requestMsg = new HttpRequestMessage(HttpMethod.Get, url);

        requestMsg.Headers.TryAddWithoutValidation(FeedReaderHttpClientConfiguration.ACCEPT_HEADER_NAME, FeedReaderHttpClientConfiguration.ACCEPT_HEADER_VALUE);
        requestMsg.Headers.TryAddWithoutValidation(FeedReaderHttpClientConfiguration.USER_AGENT_NAME, userAgent);

        using var responseMsg = await _httpClient.SendAsync(requestMsg, cancellationToken).ConfigureAwait(false);

        // Try to read the stream.
        var responseStream = _recyclableMemoryStreamManager.GetStream(nameof(DownloadStreamAsync));
        try
        {
            await responseMsg.Content.CopyToAsync(responseStream, cancellationToken).ConfigureAwait(false);

            // Be a kind citizen and reset the stream before returning.
            responseStream.Position = 0L;

            return responseStream;
        }
        catch
        {
            responseStream?.Dispose();
            throw;
        }
    }
}
