using System.Diagnostics.CodeAnalysis;
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
    /// Set to true if you, the caller, have already registered a RecyclableMemoryStreamManager with
    /// the DI service and you don't want this library to register another instance. Default is false.
    /// </summary>
    [MemberNotNullWhen(returnValue: false, member: nameof(RecyclableMemoryStreamManagerOptions))]
    public bool SuppressRecyclableMemoryStreamManagerRegistration { get; set; }

    /// <summary>
    /// <para>If <see cref="SuppressRecyclableMemoryStreamManagerRegistration"/> is false, allow the caller to configure
    /// the RecyclableMemoryStreamManager for registering with the DI service. Otherwise, use our default values.</para>
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
}
