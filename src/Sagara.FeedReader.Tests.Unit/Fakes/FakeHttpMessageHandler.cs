using System.Diagnostics;
using System.Net;
using System.Text;

namespace Sagara.FeedReader.Tests.Unit.Fakes;

/// <summary>
/// An <see cref="HttpMessageHandler"/> that records every request it receives and returns a canned response,
/// so that HTTP behavior can be unit tested without network access.
/// </summary>
internal sealed class FakeHttpMessageHandler : HttpMessageHandler
{
    public const string MinimalRss20 = "<rss version=\"2.0\"><channel><title>Fake feed</title><item><title>Item 1</title></item></channel></rss>";

    private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _responseFactory;

    public List<HttpRequestMessage> Requests { get; } = [];

    public FakeHttpMessageHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> responseFactory)
    {
        _responseFactory = responseFactory;
    }

    public FakeHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> responseFactory)
        : this((request, _) => Task.FromResult(responseFactory(request)))
    {
    }

    /// <summary>
    /// Always respond with 200 OK and the given body.
    /// </summary>
    public static FakeHttpMessageHandler Ok(string body = MinimalRss20, string mediaType = "application/rss+xml", Encoding? encoding = null)
        => Respond(HttpStatusCode.OK, body, mediaType, encoding);

    /// <summary>
    /// Always respond with the given status code and body.
    /// </summary>
    public static FakeHttpMessageHandler Respond(HttpStatusCode statusCode, string body = "", string mediaType = "text/html", Encoding? encoding = null)
        => new(_ => new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(body, encoding ?? Encoding.UTF8, mediaType),
        });

    /// <summary>
    /// Always respond with 200 OK and the given content.
    /// </summary>
    public static FakeHttpMessageHandler OkWithContent(Func<HttpContent> contentFactory)
        => new(_ => new HttpResponseMessage(HttpStatusCode.OK) { Content = contentFactory() });

    /// <summary>
    /// Respond with 200 OK and the given body, as if the request had been redirected to <paramref name="finalUri"/>.
    /// </summary>
    /// <remarks>
    /// Real redirects are followed by HttpClientHandler, below this fake. HttpClient reports the final URI through
    /// response.RequestMessage.RequestUri, so that's what we set.
    /// </remarks>
    public static FakeHttpMessageHandler OkAfterRedirectTo(Uri finalUri, string body = MinimalRss20, string mediaType = "application/rss+xml")
        => new(request => new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(body, Encoding.UTF8, mediaType),
            RequestMessage = new HttpRequestMessage(request.Method, finalUri),
        });

    /// <summary>
    /// Always throw the given exception, as if the request failed before a response arrived.
    /// </summary>
    public static FakeHttpMessageHandler Throws(Exception exception)
        => new((_, _) => Task.FromException<HttpResponseMessage>(exception));

    /// <summary>
    /// Never respond until the request is cancelled.
    /// </summary>
    public static FakeHttpMessageHandler Hangs()
        => new(async (_, cancellationToken) =>
        {
            await Task.Delay(Timeout.Infinite, cancellationToken);
            throw new UnreachableException();
        });

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Requests.Add(request);

        return SendCoreAsync(request, cancellationToken);
    }

    private async Task<HttpResponseMessage> SendCoreAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await _responseFactory(request, cancellationToken);
        response.RequestMessage ??= request;

        return response;
    }
}
