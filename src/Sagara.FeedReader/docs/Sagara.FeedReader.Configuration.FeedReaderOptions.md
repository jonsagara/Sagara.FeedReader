#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Configuration](index.md#Sagara.FeedReader.Configuration 'Sagara.FeedReader.Configuration')

## FeedReaderOptions Class

Allow the caller to configure the FeedReader HttpClient and RecyclableMemoryStreamManager.

```csharp
public class FeedReaderOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedReaderOptions
### Fields

<a name='Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultMaxResponseBytes'></a>

## FeedReaderOptions.DefaultMaxResponseBytes Field

The default value of [MaxResponseBytes](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.MaxResponseBytes 'Sagara.FeedReader.Configuration.FeedReaderOptions.MaxResponseBytes'): 10 MB.

```csharp
public const long DefaultMaxResponseBytes = 10485760;
```

#### Field Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')
### Properties

<a name='Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent'></a>

## FeedReaderOptions.DefaultUserAgent Property

The User-Agent header sent with every request, unless a request passes its own. If null or white space,  
a browser-like User-Agent is used, because some sites reject requests that don't look like they come from a browser.

```csharp
public string? DefaultUserAgent { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
If you run a crawler or bot, consider identifying it, e.g., "MyFeedBot/1.0 (+https://example.com/bot)".

<a name='Sagara.FeedReader.Configuration.FeedReaderOptions.MaxResponseBytes'></a>

## FeedReaderOptions.MaxResponseBytes Property

The largest response body, in bytes, that will be downloaded. Larger responses fail with  
[ResponseTooLarge](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.ResponseTooLarge 'Sagara.FeedReader.FeedReaderErrorKind.ResponseTooLarge'). Must be positive. Default is [DefaultMaxResponseBytes](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultMaxResponseBytes 'Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultMaxResponseBytes') (10 MB).

```csharp
public long MaxResponseBytes { get; set; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='Sagara.FeedReader.Configuration.FeedReaderOptions.Proxy'></a>

## FeedReaderOptions.Proxy Property

Optionally allow the caller to specify an HTTP proxy for the FeedReader named HttpClient.

```csharp
public System.Net.IWebProxy? Proxy { get; set; }
```

#### Property Value
[System.Net.IWebProxy](https://docs.microsoft.com/en-us/dotnet/api/System.Net.IWebProxy 'System.Net.IWebProxy')

<a name='Sagara.FeedReader.Configuration.FeedReaderOptions.RecyclableMemoryStreamManagerOptions'></a>

## FeedReaderOptions.RecyclableMemoryStreamManagerOptions Property

  
If [SuppressRecyclableMemoryStreamManagerRegistration](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.SuppressRecyclableMemoryStreamManagerRegistration 'Sagara.FeedReader.Configuration.FeedReaderOptions.SuppressRecyclableMemoryStreamManagerRegistration') is false, allow the caller to configure  
            the RecyclableMemoryStreamManager for registering with the DI service. If null, our default values are used.  
  
Ignored if [SuppressRecyclableMemoryStreamManagerRegistration](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.SuppressRecyclableMemoryStreamManagerRegistration 'Sagara.FeedReader.Configuration.FeedReaderOptions.SuppressRecyclableMemoryStreamManagerRegistration') is true.

```csharp
public Microsoft.IO.RecyclableMemoryStreamManager.Options? RecyclableMemoryStreamManagerOptions { get; set; }
```

#### Property Value
[Microsoft.IO.RecyclableMemoryStreamManager.Options](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.IO.RecyclableMemoryStreamManager.Options 'Microsoft.IO.RecyclableMemoryStreamManager.Options')

<a name='Sagara.FeedReader.Configuration.FeedReaderOptions.ResilienceHandler'></a>

## FeedReaderOptions.ResilienceHandler Property

Optionally allow the caller to customize the Polly HTTP resilience strategy for the HttpClient.

```csharp
public System.Action<Polly.ResiliencePipelineBuilder<System.Net.Http.HttpResponseMessage>,Microsoft.Extensions.Http.Resilience.ResilienceHandlerContext>? ResilienceHandler { get; set; }
```

#### Property Value
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[Polly.ResiliencePipelineBuilder&lt;](https://docs.microsoft.com/en-us/dotnet/api/Polly.ResiliencePipelineBuilder-1 'Polly.ResiliencePipelineBuilder`1')[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Polly.ResiliencePipelineBuilder-1 'Polly.ResiliencePipelineBuilder`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[Microsoft.Extensions.Http.Resilience.ResilienceHandlerContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Http.Resilience.ResilienceHandlerContext 'Microsoft.Extensions.Http.Resilience.ResilienceHandlerContext')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')

<a name='Sagara.FeedReader.Configuration.FeedReaderOptions.SuppressRecyclableMemoryStreamManagerRegistration'></a>

## FeedReaderOptions.SuppressRecyclableMemoryStreamManagerRegistration Property

Set to true if you, the caller, will register a RecyclableMemoryStreamManager with the DI service yourself  
and you don't want this library to register one. Default is false.

```csharp
public bool SuppressRecyclableMemoryStreamManagerRegistration { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### Remarks
Even when this is false, a RecyclableMemoryStreamManager that is already registered when  
`AddFeedReaderServices` is called is kept, not replaced.