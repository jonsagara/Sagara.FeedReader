#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## Helpers Class

static class with helper functions

```csharp
public static class Helpers
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Helpers
### Methods

<a name='Sagara.FeedReader.Helpers.DownloadAsync(string,System.Threading.CancellationToken)'></a>

## Helpers.DownloadAsync(string, CancellationToken) Method

Download the content from an url and returns it as utf8 encoded string.  
Preferred way is to use [DownloadBytesAsync(string, string, CancellationToken)](Sagara.FeedReader.Http.HttpClientHelper.md#Sagara.FeedReader.Http.HttpClientHelper.DownloadBytesAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.Http.HttpClientHelper.DownloadBytesAsync(string, string, System.Threading.CancellationToken)') because it works  
better with encoding.

```csharp
public static System.Threading.Tasks.Task<string> DownloadAsync(string url, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.Helpers.DownloadAsync(string,System.Threading.CancellationToken).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

correct url

<a name='Sagara.FeedReader.Helpers.DownloadAsync(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

token to cancel operation

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Content as string

<a name='Sagara.FeedReader.Helpers.GetAbsoluteFeedUrl(string,Sagara.FeedReader.HtmlFeedLink)'></a>

## Helpers.GetAbsoluteFeedUrl(string, HtmlFeedLink) Method

Returns the absolute url of a link on a page. If you got the feed links via  
GetFeedUrlsFromUrl(url) and the url is relative, you can use this method to get the full url.

```csharp
public static Sagara.FeedReader.HtmlFeedLink GetAbsoluteFeedUrl(string pageUrl, Sagara.FeedReader.HtmlFeedLink feedLink);
```
#### Parameters

<a name='Sagara.FeedReader.Helpers.GetAbsoluteFeedUrl(string,Sagara.FeedReader.HtmlFeedLink).pageUrl'></a>

`pageUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the original url to the page

<a name='Sagara.FeedReader.Helpers.GetAbsoluteFeedUrl(string,Sagara.FeedReader.HtmlFeedLink).feedLink'></a>

`feedLink` [HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink')

a referenced feed (link)

#### Returns
[HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink')  
a feed link

### Example
GetAbsoluteFeedUrl("codehollow.com", myRelativeFeedLink);

<a name='Sagara.FeedReader.Helpers.GetAbsoluteUrl(string)'></a>

## Helpers.GetAbsoluteUrl(string) Method

Takes a url (with or without http) and returns the full url.

```csharp
internal static string GetAbsoluteUrl(string url);
```
#### Parameters

<a name='Sagara.FeedReader.Helpers.GetAbsoluteUrl(string).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Url with or without http.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Tull url

### Example
GetUrl("codehollow.com"); => returns https://codehollow.com

<a name='Sagara.FeedReader.Helpers.TryParseBool(string)'></a>

## Helpers.TryParseBool(string) Method

Tries to parse the string as int and returns null if it fails

```csharp
public static System.Nullable<bool> TryParseBool(string? input);
```
#### Parameters

<a name='Sagara.FeedReader.Helpers.TryParseBool(string).input'></a>

`input` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

int as string

#### Returns
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
integer or null

<a name='Sagara.FeedReader.Helpers.TryParseDateTime(string,System.Globalization.CultureInfo)'></a>

## Helpers.TryParseDateTime(string, CultureInfo) Method

Tries to parse the string as datetime and returns null if it fails

```csharp
public static System.Nullable<System.DateTime> TryParseDateTime(string? datetime, System.Globalization.CultureInfo? cultureInfo=null);
```
#### Parameters

<a name='Sagara.FeedReader.Helpers.TryParseDateTime(string,System.Globalization.CultureInfo).datetime'></a>

`datetime` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

datetime as string

<a name='Sagara.FeedReader.Helpers.TryParseDateTime(string,System.Globalization.CultureInfo).cultureInfo'></a>

`cultureInfo` [System.Globalization.CultureInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Globalization.CultureInfo 'System.Globalization.CultureInfo')

The cultureInfo for parsing

#### Returns
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
datetime or null

<a name='Sagara.FeedReader.Helpers.TryParseInt(string)'></a>

## Helpers.TryParseInt(string) Method

Tries to parse the string as int and returns null if it fails

```csharp
public static System.Nullable<int> TryParseInt(string? input);
```
#### Parameters

<a name='Sagara.FeedReader.Helpers.TryParseInt(string).input'></a>

`input` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

int as string

#### Returns
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
integer or null

<a name='Sagara.FeedReader.Helpers.TryParseMedium(string)'></a>

## Helpers.TryParseMedium(string) Method

Tries to parse a string and returns the media type

```csharp
public static Sagara.FeedReader.Feeds.MediaRSS.Medium TryParseMedium(string? medium);
```
#### Parameters

<a name='Sagara.FeedReader.Helpers.TryParseMedium(string).medium'></a>

`medium` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

media type as string

#### Returns
[Medium](Sagara.FeedReader.Feeds.MediaRSS.Medium.md 'Sagara.FeedReader.Feeds.MediaRSS.Medium')  
[Medium](Sagara.FeedReader.Feeds.MediaRSS.Medium.md 'Sagara.FeedReader.Feeds.MediaRSS.Medium')