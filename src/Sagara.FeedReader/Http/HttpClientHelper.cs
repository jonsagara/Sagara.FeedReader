using System.Net;

namespace Sagara.FeedReader.Http;

/// <summary>
/// Original static class that makes HTTP requests to download the feeds themselves, 
/// or pages to look for feed links.
/// </summary>
internal static class HttpClientHelper
{
    // The HttpClient instance must be a static field
    // https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
    private static readonly HttpClient _httpClient = new HttpClient(FeedReaderHttpClientConfiguration.CreateHttpClientHandler());

    /// <summary>
    /// Download the content from an url
    /// </summary>
    /// <param name="url">correct url</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <param name="userAgent">override built-in user-agent header</param>
    /// <returns>Content as byte array</returns>
    public static async Task<byte[]> DownloadBytesAsync(string url, string? userAgent = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        url = WebUtility.UrlDecode(url);
        userAgent ??= FeedReaderHttpClientConfiguration.USER_AGENT_VALUE;

        HttpResponseMessage? response = null;

        try
        {
            // Make an initial request. Note that HttpClient will follow up to 50 redirects by default.
            using (var initialRequest = new HttpRequestMessage(HttpMethod.Get, url))
            {
                initialRequest.Headers.TryAddWithoutValidation(FeedReaderHttpClientConfiguration.ACCEPT_HEADER_NAME, FeedReaderHttpClientConfiguration.ACCEPT_HEADER_VALUE);
                initialRequest.Headers.TryAddWithoutValidation(FeedReaderHttpClientConfiguration.USER_AGENT_NAME, userAgent);

                response = await _httpClient.SendAsync(initialRequest, cancellationToken).ConfigureAwait(false);
            }

            if (!response.IsSuccessStatusCode)
            {
                // Something went wrong. Retry the request. We're not using the injected HttpClient with Polly,
                //   so we have to do a manual retry here.
                // NOTE: I'm not sure why we're not adding the headers to this request.
                using (var retryRequest = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    response = await _httpClient.SendAsync(retryRequest, cancellationToken).ConfigureAwait(false);
                }
            }

            var content = await response.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);

            return content;
        }
        finally
        {
            response?.Dispose();
        }
    }
}
