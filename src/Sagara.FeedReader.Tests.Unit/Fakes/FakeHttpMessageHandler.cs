using System.Net;
using System.Text;

namespace Sagara.FeedReader.Tests.Unit.Fakes;

/// <summary>
/// An <see cref="HttpMessageHandler"/> that records every request it receives and returns a canned response,
/// so that HTTP behavior can be unit tested without network access.
/// </summary>
internal sealed class FakeHttpMessageHandler : HttpMessageHandler
{
    private readonly Func<HttpRequestMessage, HttpResponseMessage> _responseFactory;

    public List<HttpRequestMessage> Requests { get; } = [];

    public FakeHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> responseFactory)
    {
        _responseFactory = responseFactory;
    }

    /// <summary>
    /// Always respond with 200 OK and the given body.
    /// </summary>
    public static FakeHttpMessageHandler Ok(string body = "<rss version=\"2.0\"><channel><title>t</title></channel></rss>", string mediaType = "application/rss+xml")
        => new(_ => new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(body, Encoding.UTF8, mediaType),
        });

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Requests.Add(request);

        var response = _responseFactory(request);
        response.RequestMessage ??= request;

        return Task.FromResult(response);
    }
}
