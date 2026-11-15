#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## IFeedReader Interface

Downloads and parses feeds from URLs, and finds the feeds a web page links to.

```csharp
public interface IFeedReader
```

Derived  
&#8627; [FeedReader](Sagara.FeedReader.FeedReader.md 'Sagara.FeedReader.FeedReader')

### Remarks
  
Register the default implementation with `services.AddFeedReaderServices()`, then inject [IFeedReader](Sagara.FeedReader.IFeedReader.md 'Sagara.FeedReader.IFeedReader').  
  
Methods return a [FeedReaderResult&lt;T&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>') instead of throwing when a request fails or the content can't  
            be parsed. They throw only for invalid arguments, and [System.OperationCanceledException](https://docs.microsoft.com/en-us/dotnet/api/System.OperationCanceledException 'System.OperationCanceledException') when the caller's  
            cancellation token is cancelled.
### Methods

<a name='Sagara.FeedReader.IFeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken)'></a>

## IFeedReader.GetFeedAsync(string, string, CancellationToken) Method

Download and parse the feed at [feedUrl](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).feedUrl 'Sagara.FeedReader.IFeedReader.GetFeedAsync(string, string, System.Threading.CancellationToken).feedUrl'). The URL must point to a feed, not an HTML page; use  
[GetFeedUrlsFromPageAsync(string, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken)') to find a page's feeds.

```csharp
System.Threading.Tasks.Task<Sagara.FeedReader.FeedReaderResult<Sagara.FeedReader.Feed>> GetFeedAsync(string feedUrl, string? userAgent=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.IFeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).feedUrl'></a>

`feedUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The absolute http or https URL of the feed, e.g., https://example.com/feed.xml.

<a name='Sagara.FeedReader.IFeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The User-Agent header for this request. If null, [DefaultUserAgent](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent 'Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent') is used.

<a name='Sagara.FeedReader.IFeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel the operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Sagara.FeedReader.FeedReaderResult&lt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A successful result with the parsed feed, or a failed result that says why.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[feedUrl](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).feedUrl 'Sagara.FeedReader.IFeedReader.GetFeedAsync(string, string, System.Threading.CancellationToken).feedUrl') is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[feedUrl](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).feedUrl 'Sagara.FeedReader.IFeedReader.GetFeedAsync(string, string, System.Threading.CancellationToken).feedUrl') is not an absolute http or https URL.

[System.OperationCanceledException](https://docs.microsoft.com/en-us/dotnet/api/System.OperationCanceledException 'System.OperationCanceledException')  
[cancellationToken](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken).cancellationToken 'Sagara.FeedReader.IFeedReader.GetFeedAsync(string, string, System.Threading.CancellationToken).cancellationToken') was cancelled.

<a name='Sagara.FeedReader.IFeedReader.GetFeedAsync(System.Uri,string,System.Threading.CancellationToken)'></a>

## IFeedReader.GetFeedAsync(Uri, string, CancellationToken) Method

Download and parse the feed at feedUrl. The URL must point to a feed, not an HTML page; use  
[GetFeedUrlsFromPageAsync(string, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken)') to find a page's feeds.

```csharp
System.Threading.Tasks.Task<Sagara.FeedReader.FeedReaderResult<Sagara.FeedReader.Feed>> GetFeedAsync(System.Uri feedUri, string? userAgent=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.IFeedReader.GetFeedAsync(System.Uri,string,System.Threading.CancellationToken).feedUri'></a>

`feedUri` [System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')

<a name='Sagara.FeedReader.IFeedReader.GetFeedAsync(System.Uri,string,System.Threading.CancellationToken).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The User-Agent header for this request. If null, [DefaultUserAgent](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent 'Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent') is used.

<a name='Sagara.FeedReader.IFeedReader.GetFeedAsync(System.Uri,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel the operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Sagara.FeedReader.FeedReaderResult&lt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A successful result with the parsed feed, or a failed result that says why.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
feedUrl is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
feedUrl is not an absolute http or https URL.

[System.OperationCanceledException](https://docs.microsoft.com/en-us/dotnet/api/System.OperationCanceledException 'System.OperationCanceledException')  
[cancellationToken](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedAsync(System.Uri,string,System.Threading.CancellationToken).cancellationToken 'Sagara.FeedReader.IFeedReader.GetFeedAsync(System.Uri, string, System.Threading.CancellationToken).cancellationToken') was cancelled.

<a name='Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken)'></a>

## IFeedReader.GetFeedUrlsFromPageAsync(string, string, CancellationToken) Method

Download the web page at [pageUrl](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).pageUrl 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken).pageUrl') and return the feeds it links to with  
<link rel="alternate" type="application/rss+xml"/> or type="application/atom+xml" tags.

```csharp
System.Threading.Tasks.Task<Sagara.FeedReader.FeedReaderResult<System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.HtmlFeedLink>>> GetFeedUrlsFromPageAsync(string pageUrl, string? userAgent=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).pageUrl'></a>

`pageUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The absolute http or https URL of the page, e.g., https://example.com/.

<a name='Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The User-Agent header for this request. If null, [DefaultUserAgent](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent 'Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent') is used.

<a name='Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel the operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Sagara.FeedReader.FeedReaderResult&lt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A successful result with the feed links (empty if the page has none), or a failed result that says why.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[pageUrl](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).pageUrl 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken).pageUrl') is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[pageUrl](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).pageUrl 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken).pageUrl') is not an absolute http or https URL.

[System.OperationCanceledException](https://docs.microsoft.com/en-us/dotnet/api/System.OperationCanceledException 'System.OperationCanceledException')  
[cancellationToken](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken).cancellationToken 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken).cancellationToken') was cancelled.

### Remarks
Relative links are resolved against the page's final URL after redirects, so every returned URL is absolute.

<a name='Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(System.Uri,string,System.Threading.CancellationToken)'></a>

## IFeedReader.GetFeedUrlsFromPageAsync(Uri, string, CancellationToken) Method

Download the web page at pageUrl and return the feeds it links to with  
<link rel="alternate" type="application/rss+xml"/> or type="application/atom+xml" tags.

```csharp
System.Threading.Tasks.Task<Sagara.FeedReader.FeedReaderResult<System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.HtmlFeedLink>>> GetFeedUrlsFromPageAsync(System.Uri pageUri, string? userAgent=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(System.Uri,string,System.Threading.CancellationToken).pageUri'></a>

`pageUri` [System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')

<a name='Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(System.Uri,string,System.Threading.CancellationToken).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The User-Agent header for this request. If null, [DefaultUserAgent](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent 'Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent') is used.

<a name='Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(System.Uri,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel the operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Sagara.FeedReader.FeedReaderResult&lt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A successful result with the feed links (empty if the page has none), or a failed result that says why.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
pageUrl is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
pageUrl is not an absolute http or https URL.

[System.OperationCanceledException](https://docs.microsoft.com/en-us/dotnet/api/System.OperationCanceledException 'System.OperationCanceledException')  
[cancellationToken](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(System.Uri,string,System.Threading.CancellationToken).cancellationToken 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(System.Uri, string, System.Threading.CancellationToken).cancellationToken') was cancelled.

### Remarks
Relative links are resolved against the page's final URL after redirects, so every returned URL is absolute.