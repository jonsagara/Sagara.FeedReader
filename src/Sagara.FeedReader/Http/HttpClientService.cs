using System.Net;
using Microsoft.IO;
using Microsoft.Net.Http.Headers;

namespace Sagara.FeedReader.Http;

/// <summary>
/// New instance-based class that makes HTTP requests to download the feeds themselves, 
/// or pages to look for feed links.
/// </summary>
public class HttpClientService : IFeedReaderService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="recyclableMemoryStreamManager"></param>
    public HttpClientService(IHttpClientFactory httpClientFactory, RecyclableMemoryStreamManager recyclableMemoryStreamManager)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory);

        _httpClientFactory = httpClientFactory;
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

        // Make an initial request. Note that HttpClient will follow up to 50 redirects by default.
        using var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.FeedReader.Name);
        using var requestMsg = CreateRequestMessage(url: url, userAgent: userAgent);
        using var responseMsg = await httpClient.SendAsync(requestMsg, cancellationToken).ConfigureAwait(false);

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
            // Something failed. Dispose of the response stream before rethrowing.
            if (responseStream is not null)
            {
                await responseStream.DisposeAsync().ConfigureAwait(false);
            }

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

        // Make an initial request. Note that HttpClient will follow up to 50 redirects by default.
        using var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.FeedReader.Name);
        using var requestMsg = CreateRequestMessage(url: url, userAgent: userAgent);
        using var responseMsg = await httpClient.SendAsync(requestMsg, cancellationToken).ConfigureAwait(false);

        return await responseMsg.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
    }


    //
    // Private methods
    //

    /// <summary>
    /// Create the <see cref="HttpRequestMessage"/> use to request a feed or page.
    /// </summary>
    /// <remarks>
    /// NOTE: The caller is responsible for disposing of the returned message.
    /// </remarks>
    private static HttpRequestMessage CreateRequestMessage(string url, string? userAgent)
    {
        url = WebUtility.UrlDecode(url);

        // NOTE: The caller is responsible for disposing of the returned message.
        HttpRequestMessage requestMsg = new(HttpMethod.Get, url);

        requestMsg.Headers.TryAddWithoutValidation(HeaderNames.Accept, FeedReaderHttpRequestHeaderValues.Accept);
        requestMsg.Headers.TryAddWithoutValidation(HeaderNames.UserAgent, userAgent ?? FeedReaderHttpRequestHeaderValues.DefaultUserAgent);

        return requestMsg;
    }
}
