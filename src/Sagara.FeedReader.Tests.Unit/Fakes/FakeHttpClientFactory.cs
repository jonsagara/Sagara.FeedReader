namespace Sagara.FeedReader.Tests.Unit.Fakes;

/// <summary>
/// An <see cref="IHttpClientFactory"/> that hands out clients backed by a single <see cref="HttpMessageHandler"/>.
/// </summary>
internal sealed class FakeHttpClientFactory : IHttpClientFactory
{
    private readonly HttpMessageHandler _handler;

    public FakeHttpClientFactory(HttpMessageHandler handler)
    {
        _handler = handler;
    }

    // disposeHandler: false because callers dispose the HttpClient, and the handler is shared across clients.
    public HttpClient CreateClient(string name)
        => new(_handler, disposeHandler: false);
}
