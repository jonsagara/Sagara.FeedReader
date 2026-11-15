using System.Net;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.IO;

namespace Sagara.FeedReader.Configuration;

/// <summary>
/// Allow the caller to configure the FeedReader HttpClient and RecyclableMemoryStreamManager.
/// </summary>
public class FeedReaderOptions
{
    /// <summary>
    /// Set to true if you, the caller, will register a RecyclableMemoryStreamManager with the DI service yourself
    /// and you don't want this library to register one. Default is false.
    /// </summary>
    /// <remarks>
    /// Even when this is false, a RecyclableMemoryStreamManager that is already registered when
    /// <c>AddFeedReaderServices</c> is called is kept, not replaced.
    /// </remarks>
    public bool SuppressRecyclableMemoryStreamManagerRegistration { get; set; }

    /// <summary>
    /// <para>If <see cref="SuppressRecyclableMemoryStreamManagerRegistration"/> is false, allow the caller to configure
    /// the RecyclableMemoryStreamManager for registering with the DI service. If null, our default values are used.</para>
    /// <para>Ignored if <see cref="SuppressRecyclableMemoryStreamManagerRegistration"/> is true.</para>
    /// </summary>
    public RecyclableMemoryStreamManager.Options? RecyclableMemoryStreamManagerOptions { get; set; }

    /// <summary>
    /// Optionally allow the caller to customize the Polly HTTP resilience strategy for the HttpClient.
    /// </summary>
    public Action<Polly.ResiliencePipelineBuilder<HttpResponseMessage>, ResilienceHandlerContext>? ResilienceHandler { get; set; }

    /// <summary>
    /// Optionally allow the caller to specify an HTTP proxy for the FeedReader named HttpClient.
    /// </summary>
    public IWebProxy? Proxy { get; set; }

    /// <summary>
    /// The default value of <see cref="MaxResponseBytes"/>: 10 MB.
    /// </summary>
    public const long DefaultMaxResponseBytes = 10L * 1024L * 1024L;

    /// <summary>
    /// The largest response body, in bytes, that will be downloaded. Larger responses fail with
    /// <see cref="FeedReaderErrorKind.ResponseTooLarge"/>. Must be positive. Default is <see cref="DefaultMaxResponseBytes"/> (10 MB).
    /// </summary>
    public long MaxResponseBytes { get; set; } = DefaultMaxResponseBytes;

    /// <summary>
    /// The User-Agent header sent with every request, unless a request passes its own. If null or white space,
    /// a browser-like User-Agent is used, because some sites reject requests that don't look like they come from a browser.
    /// </summary>
    /// <remarks>
    /// If you run a crawler or bot, consider identifying it, e.g., "MyFeedBot/1.0 (+https://example.com/bot)".
    /// </remarks>
    public string? DefaultUserAgent { get; set; }
}
