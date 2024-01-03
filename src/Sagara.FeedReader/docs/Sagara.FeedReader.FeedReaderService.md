#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## FeedReaderService Class

The FeedReader class allows to read feeds from a given url. Use it to parse a feed   
from an url [ReadAsync(string, string, CancellationToken)](Sagara.FeedReader.FeedReaderService.md#Sagara.FeedReader.FeedReaderService.ReadAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedReaderService.ReadAsync(string, string, System.Threading.CancellationToken)'), a file [ReadFromFileAsync(string)](Sagara.FeedReader.FeedReaderService.md#Sagara.FeedReader.FeedReaderService.ReadFromFileAsync(string) 'Sagara.FeedReader.FeedReaderService.ReadFromFileAsync(string)'),   
or a string [ReadFromString(string)](Sagara.FeedReader.FeedReaderService.md#Sagara.FeedReader.FeedReaderService.ReadFromString(string) 'Sagara.FeedReader.FeedReaderService.ReadFromString(string)'). If the feed url is not known, [GetFeedUrlsFromPageAsync(string, CancellationToken)](Sagara.FeedReader.FeedReaderService.md#Sagara.FeedReader.FeedReaderService.GetFeedUrlsFromPageAsync(string,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedReaderService.GetFeedUrlsFromPageAsync(string, System.Threading.CancellationToken)')   
returns all feed links on a given page.

```csharp
public class FeedReaderService :
Sagara.FeedReader.IFeedReaderService
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedReaderService

Implements [IFeedReaderService](Sagara.FeedReader.IFeedReaderService.md 'Sagara.FeedReader.IFeedReaderService')

### Example
var links = FeedReader.ParseFeedUrlsFromHtml("https://codehollow.com");  
var firstLink = links.First();  
var feed = FeedReader.Read(firstLink.Url);  
Console.WriteLine(feed.Title);
### Constructors

<a name='Sagara.FeedReader.FeedReaderService.FeedReaderService(Sagara.FeedReader.Http.HttpClientService)'></a>

## FeedReaderService(HttpClientService) Constructor

.ctor

```csharp
public FeedReaderService(Sagara.FeedReader.Http.HttpClientService httpClientService);
```
#### Parameters

<a name='Sagara.FeedReader.FeedReaderService.FeedReaderService(Sagara.FeedReader.Http.HttpClientService).httpClientService'></a>

`httpClientService` [HttpClientService](Sagara.FeedReader.Http.HttpClientService.md 'Sagara.FeedReader.Http.HttpClientService')
### Methods

<a name='Sagara.FeedReader.FeedReaderService.GetFeedUrlsFromPageAsync(string,System.Threading.CancellationToken)'></a>

## FeedReaderService.GetFeedUrlsFromPageAsync(string, CancellationToken) Method

Opens a webpage and reads all feed urls from link tags within it (<link rel="alternate" type="application/..."/>).

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.HtmlFeedLink>> GetFeedUrlsFromPageAsync(string pageUrl, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.FeedReaderService.GetFeedUrlsFromPageAsync(string,System.Threading.CancellationToken).pageUrl'></a>

`pageUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the url of the page

<a name='Sagara.FeedReader.FeedReaderService.GetFeedUrlsFromPageAsync(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

token to cancel operation

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A list of links including the type and title, an empty list if no links are found

<a name='Sagara.FeedReader.FeedReaderService.ReadAsync(string,string,System.Threading.CancellationToken)'></a>

## FeedReaderService.ReadAsync(string, string, CancellationToken) Method

Reads a feed from an url. The url MUST be a feed, and not an HTML page URL.

```csharp
public System.Threading.Tasks.Task<Sagara.FeedReader.Feed> ReadAsync(string feedUrl, string? userAgent=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.FeedReaderService.ReadAsync(string,string,System.Threading.CancellationToken).feedUrl'></a>

`feedUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The url to a feed

<a name='Sagara.FeedReader.FeedReaderService.ReadAsync(string,string,System.Threading.CancellationToken).userAgent'></a>

`userAgent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

override built-in user-agent header

<a name='Sagara.FeedReader.FeedReaderService.ReadAsync(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

token to cancel operation

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
parsed feed

### Remarks
Use [GetFeedUrlsFromPageAsync(string, CancellationToken)](Sagara.FeedReader.FeedReaderService.md#Sagara.FeedReader.FeedReaderService.GetFeedUrlsFromPageAsync(string,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedReaderService.GetFeedUrlsFromPageAsync(string, System.Threading.CancellationToken)') to parse the feeds from a url which is not a feed.

<a name='Sagara.FeedReader.FeedReaderService.ReadFromFileAsync(string)'></a>

## FeedReaderService.ReadFromFileAsync(string) Method

Reads a feed from a file.

```csharp
public static System.Threading.Tasks.Task<Sagara.FeedReader.Feed> ReadFromFileAsync(string filePath);
```
#### Parameters

<a name='Sagara.FeedReader.FeedReaderService.ReadFromFileAsync(string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the path to the feed file

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
parsed feed

### Remarks
Marked as static because it doesn't rely on HttpClient to get the desired data.

<a name='Sagara.FeedReader.FeedReaderService.ReadFromStreamAsync(System.IO.Stream)'></a>

## FeedReaderService.ReadFromStreamAsync(Stream) Method

Reads a feed from the Stream [feedContentStream](Sagara.FeedReader.FeedReaderService.md#Sagara.FeedReader.FeedReaderService.ReadFromStreamAsync(System.IO.Stream).feedContentStream 'Sagara.FeedReader.FeedReaderService.ReadFromStreamAsync(System.IO.Stream).feedContentStream')  
This could be useful if some special encoding is used.

```csharp
public static System.Threading.Tasks.Task<Sagara.FeedReader.Feed> ReadFromStreamAsync(System.IO.Stream feedContentStream);
```
#### Parameters

<a name='Sagara.FeedReader.FeedReaderService.ReadFromStreamAsync(System.IO.Stream).feedContentStream'></a>

`feedContentStream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The feed content as a Stream.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The parsed feed.

### Remarks
Marked as static because it doesn't rely on HttpClient to get the desired data.

<a name='Sagara.FeedReader.FeedReaderService.ReadFromString(string)'></a>

## FeedReaderService.ReadFromString(string) Method

Reads a feed contained in the string argument [feedContent](Sagara.FeedReader.FeedReaderService.md#Sagara.FeedReader.FeedReaderService.ReadFromString(string).feedContent 'Sagara.FeedReader.FeedReaderService.ReadFromString(string).feedContent').

```csharp
public static Sagara.FeedReader.Feed ReadFromString(string feedContent);
```
#### Parameters

<a name='Sagara.FeedReader.FeedReaderService.ReadFromString(string).feedContent'></a>

`feedContent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The feed content (xml).

#### Returns
[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')  
The parsed feed.