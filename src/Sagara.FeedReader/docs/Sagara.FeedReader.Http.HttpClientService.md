#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Http](index.md#Sagara.FeedReader.Http 'Sagara.FeedReader.Http')

## HttpClientService Class

New instance-based class that makes HTTP requests to download the feeds themselves,   
or pages to look for feed links.

```csharp
public class HttpClientService :
Sagara.FeedReader.IFeedReaderService
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpClientService

Implements [IFeedReaderService](Sagara.FeedReader.IFeedReaderService.md 'Sagara.FeedReader.IFeedReaderService')
### Constructors

<a name='Sagara.FeedReader.Http.HttpClientService.HttpClientService(System.Net.Http.IHttpClientFactory,Microsoft.IO.RecyclableMemoryStreamManager)'></a>

## HttpClientService(IHttpClientFactory, RecyclableMemoryStreamManager) Constructor

.ctor

```csharp
public HttpClientService(System.Net.Http.IHttpClientFactory httpClientFactory, Microsoft.IO.RecyclableMemoryStreamManager recyclableMemoryStreamManager);
```
#### Parameters

<a name='Sagara.FeedReader.Http.HttpClientService.HttpClientService(System.Net.Http.IHttpClientFactory,Microsoft.IO.RecyclableMemoryStreamManager).httpClientFactory'></a>

`httpClientFactory` [System.Net.Http.IHttpClientFactory](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.IHttpClientFactory 'System.Net.Http.IHttpClientFactory')

<a name='Sagara.FeedReader.Http.HttpClientService.HttpClientService(System.Net.Http.IHttpClientFactory,Microsoft.IO.RecyclableMemoryStreamManager).recyclableMemoryStreamManager'></a>

`recyclableMemoryStreamManager` [Microsoft.IO.RecyclableMemoryStreamManager](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.IO.RecyclableMemoryStreamManager 'Microsoft.IO.RecyclableMemoryStreamManager')
### Methods

<a name='Sagara.FeedReader.Http.HttpClientService.CreateRequestMessage(string,string)'></a>

## HttpClientService.CreateRequestMessage(string, string) Method

Create the [System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage') use to request a feed or page.

```csharp
private static System.Net.Http.HttpRequestMessage CreateRequestMessage(string url, string? userAgent);
```
#### Parameters

<a name='Sagara.FeedReader.Http.HttpClientService.CreateRequestMessage(string,string).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Http.HttpClientService.CreateRequestMessage(string,string).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Net.Http.HttpRequestMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage')

### Remarks
NOTE: The caller is responsible for disposing of the returned message.

<a name='Sagara.FeedReader.Http.HttpClientService.DownloadStreamAsync(string,string,System.Threading.CancellationToken)'></a>

## HttpClientService.DownloadStreamAsync(string, string, CancellationToken) Method

Download the content from the specified URL and store it in a MemoryStream.

```csharp
public System.Threading.Tasks.Task<System.IO.MemoryStream> DownloadStreamAsync(string url, string? userAgent=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.Http.HttpClientService.DownloadStreamAsync(string,string,System.Threading.CancellationToken).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The URLs content we are downloading.

<a name='Sagara.FeedReader.Http.HttpClientService.DownloadStreamAsync(string,string,System.Threading.CancellationToken).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Override built-in user-agent header

<a name='Sagara.FeedReader.Http.HttpClientService.DownloadStreamAsync(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.IO.MemoryStream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.MemoryStream 'System.IO.MemoryStream')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A MemoryStream containing the downloaded content.

### Remarks
NOTE: the caller is responsible for disposing of the returned stream.

<a name='Sagara.FeedReader.Http.HttpClientService.DownloadStringAsync(string,string,System.Threading.CancellationToken)'></a>

## HttpClientService.DownloadStringAsync(string, string, CancellationToken) Method

Download the content from the specified URL and return it as a string.

```csharp
public System.Threading.Tasks.Task<string> DownloadStringAsync(string url, string? userAgent=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.Http.HttpClientService.DownloadStringAsync(string,string,System.Threading.CancellationToken).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The URL of the content we are downloading.

<a name='Sagara.FeedReader.Http.HttpClientService.DownloadStringAsync(string,string,System.Threading.CancellationToken).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Override built-in user-agent header

<a name='Sagara.FeedReader.Http.HttpClientService.DownloadStringAsync(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A string containing the downloaded content.