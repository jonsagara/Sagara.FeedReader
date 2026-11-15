#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## FeedReader Class

The default [IFeedReader](Sagara.FeedReader.IFeedReader.md 'Sagara.FeedReader.IFeedReader'): downloads and parses feeds from URLs, and finds the feeds a web page links to.

```csharp
public sealed class FeedReader :
Sagara.FeedReader.IFeedReader
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedReader

Implements [IFeedReader](Sagara.FeedReader.IFeedReader.md 'Sagara.FeedReader.IFeedReader')

### Remarks
  
Register it with `services.AddFeedReaderServices()` and inject [IFeedReader](Sagara.FeedReader.IFeedReader.md 'Sagara.FeedReader.IFeedReader'). To use it without  
            dependency injection, pass it an [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') configured the way you want (e.g., with automatic decompression).  
  
To parse a feed from content you already have, such as a file or a string, use [FeedParser](Sagara.FeedReader.FeedParser.md 'Sagara.FeedReader.FeedParser').
### Constructors

<a name='Sagara.FeedReader.FeedReader.FeedReader(System.Net.Http.HttpClient,Microsoft.IO.RecyclableMemoryStreamManager,Sagara.FeedReader.Configuration.FeedReaderOptions)'></a>

## FeedReader(HttpClient, RecyclableMemoryStreamManager, FeedReaderOptions) Constructor

Initializes a new [FeedReader](Sagara.FeedReader.FeedReader.md 'Sagara.FeedReader.FeedReader').

```csharp
public FeedReader(System.Net.Http.HttpClient httpClient, Microsoft.IO.RecyclableMemoryStreamManager streamManager, Sagara.FeedReader.Configuration.FeedReaderOptions? options=null);
```
#### Parameters

<a name='Sagara.FeedReader.FeedReader.FeedReader(System.Net.Http.HttpClient,Microsoft.IO.RecyclableMemoryStreamManager,Sagara.FeedReader.Configuration.FeedReaderOptions).httpClient'></a>

`httpClient` [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')

The HttpClient used to make requests. Its [System.Net.Http.HttpClient.Timeout](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient.Timeout 'System.Net.Http.HttpClient.Timeout') applies to the  
            whole download, including reading the response body.

<a name='Sagara.FeedReader.FeedReader.FeedReader(System.Net.Http.HttpClient,Microsoft.IO.RecyclableMemoryStreamManager,Sagara.FeedReader.Configuration.FeedReaderOptions).streamManager'></a>

`streamManager` [Microsoft.IO.RecyclableMemoryStreamManager](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.IO.RecyclableMemoryStreamManager 'Microsoft.IO.RecyclableMemoryStreamManager')

Provides pooled memory streams for buffering responses.

<a name='Sagara.FeedReader.FeedReader.FeedReader(System.Net.Http.HttpClient,Microsoft.IO.RecyclableMemoryStreamManager,Sagara.FeedReader.Configuration.FeedReaderOptions).options'></a>

`options` [FeedReaderOptions](Sagara.FeedReader.Configuration.FeedReaderOptions.md 'Sagara.FeedReader.Configuration.FeedReaderOptions')

Optional. Only [MaxResponseBytes](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.MaxResponseBytes 'Sagara.FeedReader.Configuration.FeedReaderOptions.MaxResponseBytes') and [DefaultUserAgent](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent 'Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent')  
            are used here; the other options configure the HttpClient registered by `AddFeedReaderServices`.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[httpClient](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.FeedReader(System.Net.Http.HttpClient,Microsoft.IO.RecyclableMemoryStreamManager,Sagara.FeedReader.Configuration.FeedReaderOptions).httpClient 'Sagara.FeedReader.FeedReader.FeedReader(System.Net.Http.HttpClient, Microsoft.IO.RecyclableMemoryStreamManager, Sagara.FeedReader.Configuration.FeedReaderOptions).httpClient') or [streamManager](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.FeedReader(System.Net.Http.HttpClient,Microsoft.IO.RecyclableMemoryStreamManager,Sagara.FeedReader.Configuration.FeedReaderOptions).streamManager 'Sagara.FeedReader.FeedReader.FeedReader(System.Net.Http.HttpClient, Microsoft.IO.RecyclableMemoryStreamManager, Sagara.FeedReader.Configuration.FeedReaderOptions).streamManager') is null.

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
[MaxResponseBytes](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.MaxResponseBytes 'Sagara.FeedReader.Configuration.FeedReaderOptions.MaxResponseBytes') is not positive.
### Methods

<a name='Sagara.FeedReader.FeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken)'></a>

## FeedReader.GetFeedAsync(string, string, CancellationToken) Method

Download and parse the feed at [feedUrl](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).feedUrl 'Sagara.FeedReader.FeedReader.GetFeedAsync(string, string, System.Threading.CancellationToken).feedUrl'). The URL must point to a feed, not an HTML page; use  
[GetFeedUrlsFromPageAsync(string, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken)') to find a page's feeds.

```csharp
public System.Threading.Tasks.Task<Sagara.FeedReader.FeedReaderResult<Sagara.FeedReader.Feed>> GetFeedAsync(string feedUrl, string? userAgent=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.FeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).feedUrl'></a>

`feedUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The absolute http or https URL of the feed, e.g., https://example.com/feed.xml.

<a name='Sagara.FeedReader.FeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The User-Agent header for this request. If null, [DefaultUserAgent](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent 'Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent') is used.

<a name='Sagara.FeedReader.FeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel the operation.

Implements [GetFeedAsync(string, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedAsync(string, string, System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Sagara.FeedReader.FeedReaderResult&lt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A successful result with the parsed feed, or a failed result that says why.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[feedUrl](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).feedUrl 'Sagara.FeedReader.FeedReader.GetFeedAsync(string, string, System.Threading.CancellationToken).feedUrl') is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[feedUrl](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).feedUrl 'Sagara.FeedReader.FeedReader.GetFeedAsync(string, string, System.Threading.CancellationToken).feedUrl') is not an absolute http or https URL.

[System.OperationCanceledException](https://docs.microsoft.com/en-us/dotnet/api/System.OperationCanceledException 'System.OperationCanceledException')  
[cancellationToken](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).cancellationToken 'Sagara.FeedReader.FeedReader.GetFeedAsync(string, string, System.Threading.CancellationToken).cancellationToken') was cancelled.

<a name='Sagara.FeedReader.FeedReader.GetFeedAsync(System.Uri,string,System.Threading.CancellationToken)'></a>

## FeedReader.GetFeedAsync(Uri, string, CancellationToken) Method

Download and parse the feed at feedUrl. The URL must point to a feed, not an HTML page; use  
[GetFeedUrlsFromPageAsync(string, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken)') to find a page's feeds.

```csharp
public System.Threading.Tasks.Task<Sagara.FeedReader.FeedReaderResult<Sagara.FeedReader.Feed>> GetFeedAsync(System.Uri feedUri, string? userAgent=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.FeedReader.GetFeedAsync(System.Uri,string,System.Threading.CancellationToken).feedUri'></a>

`feedUri` [System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')

<a name='Sagara.FeedReader.FeedReader.GetFeedAsync(System.Uri,string,System.Threading.CancellationToken).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The User-Agent header for this request. If null, [DefaultUserAgent](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent 'Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent') is used.

<a name='Sagara.FeedReader.FeedReader.GetFeedAsync(System.Uri,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel the operation.

Implements [GetFeedAsync(Uri, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedAsync(System.Uri,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedAsync(System.Uri, string, System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Sagara.FeedReader.FeedReaderResult&lt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A successful result with the parsed feed, or a failed result that says why.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
feedUrl is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
feedUrl is not an absolute http or https URL.

[System.OperationCanceledException](https://docs.microsoft.com/en-us/dotnet/api/System.OperationCanceledException 'System.OperationCanceledException')  
[cancellationToken](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedAsync(System.Uri,string,System.Threading.CancellationToken).cancellationToken 'Sagara.FeedReader.FeedReader.GetFeedAsync(System.Uri, string, System.Threading.CancellationToken).cancellationToken') was cancelled.

<a name='Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken)'></a>

## FeedReader.GetFeedUrlsFromPageAsync(string, string, CancellationToken) Method

Download the web page at [pageUrl](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).pageUrl 'Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken).pageUrl') and return the feeds it links to with  
<link rel="alternate" type="application/rss+xml"/> or type="application/atom+xml" tags.

```csharp
public System.Threading.Tasks.Task<Sagara.FeedReader.FeedReaderResult<System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.HtmlFeedLink>>> GetFeedUrlsFromPageAsync(string pageUrl, string? userAgent=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).pageUrl'></a>

`pageUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The absolute http or https URL of the page, e.g., https://example.com/.

<a name='Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The User-Agent header for this request. If null, [DefaultUserAgent](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent 'Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent') is used.

<a name='Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel the operation.

Implements [GetFeedUrlsFromPageAsync(string, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Sagara.FeedReader.FeedReaderResult&lt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A successful result with the feed links (empty if the page has none), or a failed result that says why.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[pageUrl](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).pageUrl 'Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken).pageUrl') is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[pageUrl](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).pageUrl 'Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken).pageUrl') is not an absolute http or https URL.

[System.OperationCanceledException](https://docs.microsoft.com/en-us/dotnet/api/System.OperationCanceledException 'System.OperationCanceledException')  
[cancellationToken](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).cancellationToken 'Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken).cancellationToken') was cancelled.

### Remarks
Relative links are resolved against the page's final URL after redirects, so every returned URL is absolute.

<a name='Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(System.Uri,string,System.Threading.CancellationToken)'></a>

## FeedReader.GetFeedUrlsFromPageAsync(Uri, string, CancellationToken) Method

Download the web page at pageUrl and return the feeds it links to with  
<link rel="alternate" type="application/rss+xml"/> or type="application/atom+xml" tags.

```csharp
public System.Threading.Tasks.Task<Sagara.FeedReader.FeedReaderResult<System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.HtmlFeedLink>>> GetFeedUrlsFromPageAsync(System.Uri pageUri, string? userAgent=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(System.Uri,string,System.Threading.CancellationToken).pageUri'></a>

`pageUri` [System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')

<a name='Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(System.Uri,string,System.Threading.CancellationToken).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The User-Agent header for this request. If null, [DefaultUserAgent](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent 'Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent') is used.

<a name='Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(System.Uri,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel the operation.

Implements [GetFeedUrlsFromPageAsync(Uri, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(System.Uri,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(System.Uri, string, System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Sagara.FeedReader.FeedReaderResult&lt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A successful result with the feed links (empty if the page has none), or a failed result that says why.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
pageUrl is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
pageUrl is not an absolute http or https URL.

[System.OperationCanceledException](https://docs.microsoft.com/en-us/dotnet/api/System.OperationCanceledException 'System.OperationCanceledException')  
[cancellationToken](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(System.Uri,string,System.Threading.CancellationToken).cancellationToken 'Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(System.Uri, string, System.Threading.CancellationToken).cancellationToken') was cancelled.

### Remarks
Relative links are resolved against the page's final URL after redirects, so every returned URL is absolute.