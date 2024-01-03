#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Http](index.md#Sagara.FeedReader.Http 'Sagara.FeedReader.Http')

## HttpClientHelper Class

Original static class that makes HTTP requests to download the feeds themselves,   
or pages to look for feed links.

```csharp
internal static class HttpClientHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpClientHelper
### Methods

<a name='Sagara.FeedReader.Http.HttpClientHelper.DownloadBytesAsync(string,string,System.Threading.CancellationToken)'></a>

## HttpClientHelper.DownloadBytesAsync(string, string, CancellationToken) Method

Download the content from an url

```csharp
public static System.Threading.Tasks.Task<byte[]> DownloadBytesAsync(string url, string? userAgent=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.Http.HttpClientHelper.DownloadBytesAsync(string,string,System.Threading.CancellationToken).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

correct url

<a name='Sagara.FeedReader.Http.HttpClientHelper.DownloadBytesAsync(string,string,System.Threading.CancellationToken).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

override built-in user-agent header

<a name='Sagara.FeedReader.Http.HttpClientHelper.DownloadBytesAsync(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

token to cancel operation

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Content as byte array