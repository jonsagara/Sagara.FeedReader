#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Configuration](index.md#Sagara.FeedReader.Configuration 'Sagara.FeedReader.Configuration')

## FeedReaderOptions Class

Allow the caller to configure the FeedReader HttpClient and RecyclableMemoryStreamManager.

```csharp
public class FeedReaderOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedReaderOptions
### Properties

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
            the RecyclableMemoryStreamManager for registering with the DI service. Otherwise, use our default values.  
  
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

Set to true if you, the caller, have already registered a RecyclableMemoryStreamManager with  
the DI service and you don't want this library to register another instance. Default is false.

```csharp
public bool SuppressRecyclableMemoryStreamManagerRegistration { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')