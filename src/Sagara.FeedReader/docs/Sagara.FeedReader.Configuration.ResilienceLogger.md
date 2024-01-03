#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Configuration](index.md#Sagara.FeedReader.Configuration 'Sagara.FeedReader.Configuration')

## ResilienceLogger Class

```csharp
internal static class ResilienceLogger
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ResilienceLogger
### Methods

<a name='Sagara.FeedReader.Configuration.ResilienceLogger.OnRetry(thisMicrosoft.Extensions.Logging.ILogger,System.Exception,string,System.Uri,System.Nullable_int_,System.Nullable_System.Net.HttpStatusCode_,System.TimeSpan,System.TimeSpan)'></a>

## ResilienceLogger.OnRetry(this ILogger, Exception, string, Uri, Nullable<int>, Nullable<HttpStatusCode>, TimeSpan, TimeSpan) Method

Logs "[HttpClient={HttpClientName}] Failed to send request to {RequestUri}. StatusCode: {StatusCodeInt} {StatusCode}. The attempt took {Duration}. Retrying after {RetryDelay}..." at "Warning" level.

```csharp
internal static void OnRetry(this Microsoft.Extensions.Logging.ILogger logger, System.Exception? ex, string httpClientName, System.Uri? requestUri, System.Nullable<int> statusCodeInt, System.Nullable<System.Net.HttpStatusCode> statusCode, System.TimeSpan duration, System.TimeSpan retryDelay);
```
#### Parameters

<a name='Sagara.FeedReader.Configuration.ResilienceLogger.OnRetry(thisMicrosoft.Extensions.Logging.ILogger,System.Exception,string,System.Uri,System.Nullable_int_,System.Nullable_System.Net.HttpStatusCode_,System.TimeSpan,System.TimeSpan).logger'></a>

`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')

<a name='Sagara.FeedReader.Configuration.ResilienceLogger.OnRetry(thisMicrosoft.Extensions.Logging.ILogger,System.Exception,string,System.Uri,System.Nullable_int_,System.Nullable_System.Net.HttpStatusCode_,System.TimeSpan,System.TimeSpan).ex'></a>

`ex` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='Sagara.FeedReader.Configuration.ResilienceLogger.OnRetry(thisMicrosoft.Extensions.Logging.ILogger,System.Exception,string,System.Uri,System.Nullable_int_,System.Nullable_System.Net.HttpStatusCode_,System.TimeSpan,System.TimeSpan).httpClientName'></a>

`httpClientName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Configuration.ResilienceLogger.OnRetry(thisMicrosoft.Extensions.Logging.ILogger,System.Exception,string,System.Uri,System.Nullable_int_,System.Nullable_System.Net.HttpStatusCode_,System.TimeSpan,System.TimeSpan).requestUri'></a>

`requestUri` [System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')

<a name='Sagara.FeedReader.Configuration.ResilienceLogger.OnRetry(thisMicrosoft.Extensions.Logging.ILogger,System.Exception,string,System.Uri,System.Nullable_int_,System.Nullable_System.Net.HttpStatusCode_,System.TimeSpan,System.TimeSpan).statusCodeInt'></a>

`statusCodeInt` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Configuration.ResilienceLogger.OnRetry(thisMicrosoft.Extensions.Logging.ILogger,System.Exception,string,System.Uri,System.Nullable_int_,System.Nullable_System.Net.HttpStatusCode_,System.TimeSpan,System.TimeSpan).statusCode'></a>

`statusCode` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Configuration.ResilienceLogger.OnRetry(thisMicrosoft.Extensions.Logging.ILogger,System.Exception,string,System.Uri,System.Nullable_int_,System.Nullable_System.Net.HttpStatusCode_,System.TimeSpan,System.TimeSpan).duration'></a>

`duration` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')

<a name='Sagara.FeedReader.Configuration.ResilienceLogger.OnRetry(thisMicrosoft.Extensions.Logging.ILogger,System.Exception,string,System.Uri,System.Nullable_int_,System.Nullable_System.Net.HttpStatusCode_,System.TimeSpan,System.TimeSpan).retryDelay'></a>

`retryDelay` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')