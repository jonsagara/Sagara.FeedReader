#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## FeedReader Class

The FeedReader class allows to read feeds from a given url. Use it to parse a feed   
from an url [ReadFromUrlAsync(string, string, CancellationToken)](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.ReadFromUrlAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedReader.ReadFromUrlAsync(string, string, System.Threading.CancellationToken)'), a file [ReadFromFileAsync(string, CancellationToken)](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.ReadFromFileAsync(string,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedReader.ReadFromFileAsync(string, System.Threading.CancellationToken)'),   
or a string [ReadFromString(string)](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.ReadFromString(string) 'Sagara.FeedReader.FeedReader.ReadFromString(string)'). If the feed url is not known, [GetFeedUrlsFromPageAsync(string, CancellationToken)](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string, System.Threading.CancellationToken)')   
returns all feed links on a given page.

```csharp
public class FeedReader :
Sagara.FeedReader.IFeedReaderService
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedReader

Implements [IFeedReaderService](Sagara.FeedReader.IFeedReaderService.md 'Sagara.FeedReader.IFeedReaderService')
### Constructors

<a name='Sagara.FeedReader.FeedReader.FeedReader(Sagara.FeedReader.Http.HttpClientService)'></a>

## FeedReader(HttpClientService) Constructor

.ctor

```csharp
public FeedReader(Sagara.FeedReader.Http.HttpClientService httpClientService);
```
#### Parameters

<a name='Sagara.FeedReader.FeedReader.FeedReader(Sagara.FeedReader.Http.HttpClientService).httpClientService'></a>

`httpClientService` [HttpClientService](Sagara.FeedReader.Http.HttpClientService.md 'Sagara.FeedReader.Http.HttpClientService')
### Methods

<a name='Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,System.Threading.CancellationToken)'></a>

## FeedReader.GetFeedUrlsFromPageAsync(string, CancellationToken) Method

Opens a webpage and reads all feed urls from link tags within it (<link rel="alternate" type="application/..."/>).

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.HtmlFeedLink>> GetFeedUrlsFromPageAsync(string pageUrl, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,System.Threading.CancellationToken).pageUrl'></a>

`pageUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the url of the page

<a name='Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A list of links including the type and title, an empty list if no links are found

<a name='Sagara.FeedReader.FeedReader.ReadFromFileAsync(string,System.Threading.CancellationToken)'></a>

## FeedReader.ReadFromFileAsync(string, CancellationToken) Method

Reads a feed from a file.

```csharp
public static System.Threading.Tasks.Task<Sagara.FeedReader.Feed> ReadFromFileAsync(string filePath, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.FeedReader.ReadFromFileAsync(string,System.Threading.CancellationToken).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the path to the feed file

<a name='Sagara.FeedReader.FeedReader.ReadFromFileAsync(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
parsed feed

### Remarks
Marked as static because it doesn't rely on HttpClient to get the desired data.

<a name='Sagara.FeedReader.FeedReader.ReadFromStreamAsync(System.IO.Stream,System.Threading.CancellationToken)'></a>

## FeedReader.ReadFromStreamAsync(Stream, CancellationToken) Method

Reads a feed from the Stream [feedContentStream](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.ReadFromStreamAsync(System.IO.Stream,System.Threading.CancellationToken).feedContentStream 'Sagara.FeedReader.FeedReader.ReadFromStreamAsync(System.IO.Stream, System.Threading.CancellationToken).feedContentStream')  
This could be useful if some special encoding is used.

```csharp
public static System.Threading.Tasks.Task<Sagara.FeedReader.Feed> ReadFromStreamAsync(System.IO.Stream feedContentStream, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.FeedReader.ReadFromStreamAsync(System.IO.Stream,System.Threading.CancellationToken).feedContentStream'></a>

`feedContentStream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The feed content as a Stream.

<a name='Sagara.FeedReader.FeedReader.ReadFromStreamAsync(System.IO.Stream,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The parsed feed.

### Remarks
Marked as static because it doesn't rely on HttpClient to get the desired data.

<a name='Sagara.FeedReader.FeedReader.ReadFromString(string)'></a>

## FeedReader.ReadFromString(string) Method

Reads a feed contained in the string argument [feedContent](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.ReadFromString(string).feedContent 'Sagara.FeedReader.FeedReader.ReadFromString(string).feedContent').

```csharp
public static Sagara.FeedReader.Feed ReadFromString(string feedContent);
```
#### Parameters

<a name='Sagara.FeedReader.FeedReader.ReadFromString(string).feedContent'></a>

`feedContent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The feed content (xml).

#### Returns
[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')  
The parsed feed.

<a name='Sagara.FeedReader.FeedReader.ReadFromUrlAsync(string,string,System.Threading.CancellationToken)'></a>

## FeedReader.ReadFromUrlAsync(string, string, CancellationToken) Method

Reads a feed from an url. The url MUST be a feed, and not an HTML page URL.

```csharp
public System.Threading.Tasks.Task<Sagara.FeedReader.Feed> ReadFromUrlAsync(string feedUrl, string? userAgent=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.FeedReader.ReadFromUrlAsync(string,string,System.Threading.CancellationToken).feedUrl'></a>

`feedUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The url to a feed

<a name='Sagara.FeedReader.FeedReader.ReadFromUrlAsync(string,string,System.Threading.CancellationToken).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

override built-in user-agent header

<a name='Sagara.FeedReader.FeedReader.ReadFromUrlAsync(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
parsed feed

### Remarks
Use [GetFeedUrlsFromPageAsync(string, CancellationToken)](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string, System.Threading.CancellationToken)') to parse the feeds from a url which is not a feed.