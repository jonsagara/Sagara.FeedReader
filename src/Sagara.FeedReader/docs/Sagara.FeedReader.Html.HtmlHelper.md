#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Html](index.md#Sagara.FeedReader.Html 'Sagara.FeedReader.Html')

## HtmlHelper Class

Contains HTML helper methods.

```csharp
public static class HtmlHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HtmlHelper
### Methods

<a name='Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string,System.Uri)'></a>

## HtmlHelper.ParseFeedUrlsFromHtml(string, Uri) Method

Parses feed links from an HTML page and resolves them against [baseUri](Sagara.FeedReader.Html.HtmlHelper.md#Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string,System.Uri).baseUri 'Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string, System.Uri).baseUri'), so that every returned  
URL is absolute. Links that can't be resolved to an http or https URL are skipped.

```csharp
public static System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.HtmlFeedLink> ParseFeedUrlsFromHtml(string htmlContent, System.Uri baseUri);
```
#### Parameters

<a name='Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string,System.Uri).htmlContent'></a>

`htmlContent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The content of the HTML page.

<a name='Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string,System.Uri).baseUri'></a>

`baseUri` [System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')

The absolute URI of the page, used to resolve relative links. Use the page's final URI  
            after redirects.

#### Returns
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')  
All feed links, with absolute URLs.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[baseUri](Sagara.FeedReader.Html.HtmlHelper.md#Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string,System.Uri).baseUri 'Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string, System.Uri).baseUri') is not absolute.

<a name='Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string)'></a>

## HtmlHelper.ParseFeedUrlsFromHtml(string) Method

Parses RSS links from html page and returns all links

```csharp
public static System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.HtmlFeedLink> ParseFeedUrlsFromHtml(string htmlContent);
```
#### Parameters

<a name='Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string).htmlContent'></a>

`htmlContent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the content of the html page

#### Returns
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')  
all RSS/feed links