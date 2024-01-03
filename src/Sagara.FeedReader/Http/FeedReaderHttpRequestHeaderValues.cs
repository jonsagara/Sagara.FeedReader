namespace Sagara.FeedReader.Http;

/// <summary>
/// Configuration helper for the non-static version of FeedReader that uses
/// dependency injection.
/// </summary>
internal static class FeedReaderHttpRequestHeaderValues
{
    internal const string Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
    internal const string DefaultUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:121.0) Gecko/20100101 Firefox/121.0";
}
