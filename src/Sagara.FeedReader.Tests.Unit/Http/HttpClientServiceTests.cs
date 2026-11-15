using Microsoft.IO;
using Sagara.FeedReader.Http;
using Sagara.FeedReader.Tests.Unit.Fakes;
using Xunit;

namespace Sagara.FeedReader.Tests.Unit.Http;

public class HttpClientServiceTests
{
    // Percent-encoded characters that change a URL's meaning if decoded before the request is sent.
    public static TheoryData<string> UrlsWithEncodedCharacters => new()
    {
        "https://example.com/feed?q=a%26b",             // & would split the query value into two parameters
        "https://example.com/feed?q=a%2Bb",             // + would become a space
        "https://example.com/feed?redirect=%2Fother",   // / in a query value
        "https://example.com/feed?q=a%3Db",             // = would split the key/value pair
        "https://example.com/feed?q=50%25",             // a literal percent sign
        "https://example.com/feed?q=a+b",               // a literal + would become a space
        "https://example.com/path%2Fwith%2Fslashes/feed",
    };

    [Theory]
    [MemberData(nameof(UrlsWithEncodedCharacters))]
    public async Task DownloadStreamAsync_PreservesEncodedCharacters(string url)
    {
        var handler = FakeHttpMessageHandler.Ok();
        var httpClientService = CreateHttpClientService(handler);

        using var _ = await httpClientService.DownloadStreamAsync(url, cancellationToken: TestContext.Current.CancellationToken);

        var request = Assert.Single(handler.Requests);
        Assert.Equal(url, request.RequestUri!.AbsoluteUri);
    }

    [Theory]
    [MemberData(nameof(UrlsWithEncodedCharacters))]
    public async Task DownloadStringAsync_PreservesEncodedCharacters(string url)
    {
        var handler = FakeHttpMessageHandler.Ok();
        var httpClientService = CreateHttpClientService(handler);

        await httpClientService.DownloadStringAsync(url, cancellationToken: TestContext.Current.CancellationToken);

        var request = Assert.Single(handler.Requests);
        Assert.Equal(url, request.RequestUri!.AbsoluteUri);
    }


    private static HttpClientService CreateHttpClientService(HttpMessageHandler handler)
        => new(new FakeHttpClientFactory(handler), new RecyclableMemoryStreamManager());
}
