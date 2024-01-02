using System.Net;

namespace Sagara.FeedReader.Http;

/// <summary>
/// Configuration helper for the non-static version of FeedReader that uses
/// dependency injection.
/// </summary>
public static class FeedReaderHttpClientConfiguration
{
    internal const string AcceptHeaderValue = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
    internal const string DefaultUserAgentHeaderValue = "Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/36.0";


    /// <summary>
    /// Creates a customized HttpClientHandler that has automatic decompression enabled (GZip and Deflate).
    /// </summary>
    public static HttpClientHandler CreateHttpClientHandler()
        => new()
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            CheckCertificateRevocationList = true,
        };
}
