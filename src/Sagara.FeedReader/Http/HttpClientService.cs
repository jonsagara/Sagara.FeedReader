using System.Net;
using Microsoft.IO;

namespace Sagara.FeedReader.Http;

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
    /// Download the content from the specified URL and store it in a MemoryStream.
    /// </summary>
    /// <remarks>
    /// NOTE: the caller is responsible for disposing of the returned stream.
    /// </remarks>
    /// <param name="url">The URLs content we are downloading.</param>
    /// /// <param name="userAgent">Override built-in user-agent header</param>
    /// <param name="cancellationToken">Token to cancel operation</param>
    /// <returns>A MemoryStream containing the downloaded content.</returns>
    public async Task<MemoryStream> DownloadStreamAsync(string url, string? userAgent = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        url = WebUtility.UrlDecode(url);
        userAgent ??= FeedReaderHttpClientConfiguration.USER_AGENT_VALUE;

        // Make an initial request. Note that HttpClient will follow up to 50 redirects by default.
        using var requestMsg = new HttpRequestMessage(HttpMethod.Get, url);

        AddRequestHeaders(requestMsg, userAgent);

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

    /// <summary>
    /// Download the content from the specified URL and return it as a string.
    /// </summary>
    /// <param name="url">The URL of the content we are downloading.</param>
    /// <param name="userAgent">Override built-in user-agent header</param>
    /// <param name="cancellationToken">Token to cancel operation.</param>
    /// <returns>A string containing the downloaded content.</returns>
    public async Task<string> DownloadStringAsync(string url, string? userAgent = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        url = WebUtility.UrlDecode(url);
        userAgent ??= FeedReaderHttpClientConfiguration.USER_AGENT_VALUE;

        // Make an initial request. Note that HttpClient will follow up to 50 redirects by default.
        using var requestMsg = new HttpRequestMessage(HttpMethod.Get, url);

        AddRequestHeaders(requestMsg, userAgent);

        using var responseMsg = await _httpClient.SendAsync(requestMsg, cancellationToken).ConfigureAwait(false);

        return await responseMsg.Content.ReadAsStringAsync().ConfigureAwait(false);
    }


    //
    // Private methods
    //

    private void AddRequestHeaders(HttpRequestMessage requestMsg, string? userAgent)
    {
        requestMsg.Headers.TryAddWithoutValidation(FeedReaderHttpClientConfiguration.ACCEPT_HEADER_NAME, FeedReaderHttpClientConfiguration.ACCEPT_HEADER_VALUE);
        requestMsg.Headers.TryAddWithoutValidation(FeedReaderHttpClientConfiguration.USER_AGENT_NAME, userAgent);
    }
}
