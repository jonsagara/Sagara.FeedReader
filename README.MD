# Sagara.FeedReader

[![publish](https://github.com/jonsagara/Sagara.FeedReader/actions/workflows/build-and-publish.yml/badge.svg)](https://github.com/jonsagara/Sagara.FeedReader/actions?query=workflow%3Apublish)

`Sagara.FeedReader` is a .NET library for downloading and parsing RSS and Atom feeds. It supports **RSS 0.91, 0.92, 1.0, 2.0, Media RSS, and Atom**, plus the Apple Podcasts (iTunes) and WordPress export extensions.

## Requirements

`.NET 10` or `.NET 11`.

## NuGet Package

[![NuGet](https://img.shields.io/nuget/v/Sagara.FeedReader?label=NuGet)](https://www.nuget.org/packages/Sagara.FeedReader/)

```
dotnet add package Sagara.FeedReader
```

For API docs generated from XML comments, see the [GitHub repo](src/Sagara.FeedReader/docs/index.md).

## Getting Started

### Register the services

```csharp
var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddFeedReaderServices();
```

Then inject `IFeedReader` wherever you need it.

### Read a feed from a URL

`GetFeedAsync` returns a `FeedReaderResult<Feed>` instead of throwing when the request fails or the content isn't a feed. Check `IsSuccess`: when it's `true`, `Value` is the feed; when it's `false`, `Error` says why.

```csharp
var result = await feedReader.GetFeedAsync("https://www.sagara.dev/feed.xml");

if (!result.IsSuccess)
{
    Console.WriteLine($"{result.Error.Kind}: {result.Error.Message}");
    return;
}

foreach (var item in result.Value.Items)
{
    Console.WriteLine($"[Item] {item.Title}");
    Console.WriteLine($"> Publish Date: {item.PublishingDate:yyyy-MM-dd HH:mm:ss zzzz}");
    Console.WriteLine($"> URL: {item.Link}");
}
```

URLs must be absolute `http` or `https` URLs, e.g., `https://example.com/feed.xml`. Anything else, including `example.com/feed.xml`, throws `ArgumentException`. Both `string` and `Uri` overloads are available.

### Find the feeds on a web page

If you have a web page URL rather than a feed URL, `GetFeedUrlsFromPageAsync` returns the feeds that the page links to with `<link rel="alternate">` tags. The URLs are always absolute, resolved against the page's final URL after redirects.

```csharp
var pageResult = await feedReader.GetFeedUrlsFromPageAsync("https://www.sagara.dev/");

if (pageResult.IsSuccess)
{
    foreach (var link in pageResult.Value)
    {
        Console.WriteLine($"{link.Title}: {link.Url} ({link.FeedType})");
    }
}
```

### Parse a feed you already have

`FeedParser` parses content from a stream or a string, without making any HTTP requests:

```csharp
// From a file
await using var stream = File.OpenRead("feed.xml");
var feed = await FeedParser.ParseAsync(stream);

// From a string
var feed = FeedParser.Parse(xml);
```

`ParseAsync` and `Parse` throw `FeedParseException` when the content can't be parsed. `TryParseAsync` and `TryParse` return a `FeedReaderResult<Feed>` instead:

```csharp
var result = FeedParser.TryParse(xml);
if (!result.IsSuccess)
{
    Console.WriteLine($"{result.Error.Kind}: {result.Error.Message}");
}
```

Streams are read from their current position. The encoding declared in the XML declaration is honored, and non-seekable streams are supported.

### Handle errors

`FeedReaderError.Kind` tells you what went wrong, so you can decide what to do about it:

| Kind | Meaning | `StatusCode` |
| --- | --- | --- |
| `HttpError` | The server returned a non-success status code, e.g., 404 or 500. | Set |
| `NetworkError` | The request failed before a response arrived (DNS, TLS, connection), or the connection dropped mid-response. | Null, or set if the body failed |
| `Timeout` | The request took longer than `HttpClient.Timeout`. The timeout covers reading the whole response, not just the headers. | Null, or set if the body stalled |
| `ResponseTooLarge` | The response is larger than `FeedReaderOptions.MaxResponseBytes`. | Set |
| `NotAFeed` | The content is an HTML page. Try `GetFeedUrlsFromPageAsync` instead. | Set when downloaded |
| `InvalidXml` | The content is empty or not well-formed XML. | Set when downloaded |
| `UnsupportedFeedType` | The XML's root element isn't `<rss>`, `<rdf:RDF>`, or `<feed>`. | Set when downloaded |
| `ParseError` | The feed is well-formed but couldn't be parsed, e.g., it has no `<channel>`. | Set when downloaded |

Results from `IFeedReader` also have `FinalUri`, the URL the content was read from after redirects. If it differs from the URL you requested because of a permanent redirect, you may want to update your stored URL.

Methods throw only for invalid arguments, and `OperationCanceledException` when your cancellation token is cancelled.

### Configure

```csharp
builder.Services.AddFeedReaderServices(options =>
{
    options.MaxResponseBytes = 5 * 1024 * 1024;
    options.DefaultUserAgent = "MyFeedBot/1.0 (+https://example.com/bot)";
});
```

| Option | Default | Purpose |
| --- | --- | --- |
| `MaxResponseBytes` | 10 MB | Larger responses fail with `ResponseTooLarge`. |
| `DefaultUserAgent` | A browser-like User-Agent | Sent with every request. Each method also takes a `userAgent` argument that overrides it. |
| `Proxy` | None | An HTTP proxy for FeedReader's `HttpClient`. |
| `ResilienceHandler` | Retry transient failures once | Replaces the [Polly](https://www.pollydocs.org/) resilience pipeline. |
| `RecyclableMemoryStreamManagerOptions` | Library defaults | Configures the `RecyclableMemoryStreamManager` used to buffer responses. |
| `SuppressRecyclableMemoryStreamManagerRegistration` | `false` | Set to `true` if you register your own `RecyclableMemoryStreamManager`. An already-registered one is always kept. |

### Use format-specific properties

`Feed` and `FeedItem` have the properties common to all formats. For format-specific ones, cast `SpecificFeed` or `SpecificItem`:

```csharp
if (feed.SpecificFeed is Rss20Feed rss20Feed)
{
    Console.WriteLine($"Generator: {rss20Feed.Generator}");
}
```

For Apple Podcasts and WordPress export feeds, use the extension methods `feed.GetiTunesChannel()`, `item.GetiTunesItem()`, `feed.GetWordPressExportChannel()`, and `item.GetWordPressExportItem()`.

### Use it without dependency injection

`FeedReader` takes the `HttpClient` to use. Configure it as you see fit, e.g., with automatic decompression:

```csharp
using var httpClient = new HttpClient(new HttpClientHandler
{
    AutomaticDecompression = DecompressionMethods.All,
});

IFeedReader feedReader = new FeedReader(httpClient, new RecyclableMemoryStreamManager());
```

## Migrating from 4.x

5.0 streamlines the public API and returns results instead of throwing. Most code needs the changes in this table:

| 4.x | 5.0 |
| --- | --- |
| Inject `FeedReader` | Inject `IFeedReader`. It's registered as a typed `HttpClient`, so its lifetime is transient instead of scoped. |
| `feedReader.ReadFromUrlAsync(url)` returns `Feed` | `feedReader.GetFeedAsync(url)` returns `FeedReaderResult<Feed>` |
| `feedReader.GetFeedUrlsFromPageAsync(url)` returns `IReadOnlyCollection<HtmlFeedLink>` | Returns `FeedReaderResult<IReadOnlyCollection<HtmlFeedLink>>`. The URLs are absolute. |
| `FeedReader.ReadFromStreamAsync(stream)` | `FeedParser.ParseAsync(stream)` or `FeedParser.TryParseAsync(stream)` |
| `FeedReader.ReadFromFileAsync(path)` | `FeedParser.ParseAsync(File.OpenRead(path))` |
| `FeedReader.ReadFromString(xml)` | `FeedParser.Parse(xml)` or `FeedParser.TryParse(xml)` |
| `Helpers.GetAbsoluteFeedUrl(pageUrl, link)` | Not needed. Discovered URLs are already absolute. |
| `HttpClientService` | Removed. Use `GetFeedAsync` and `Feed.OriginalFeedXml` for the raw XML, or your own `HttpClient`. |
| `using Sagara.FeedReader.Extensions;` for `AddFeedReaderServices` | Not needed. It's in the `Microsoft.Extensions.DependencyInjection` namespace. |
| `FeedTypeNotSupportedException`, `XmlException`, `NullReferenceException` from parsing | `FeedParseException`, with a `Kind` property |

Behavior changes to check for:

- **URLs must include the scheme.** `example.com/feed.xml` used to be treated as `http://example.com/feed.xml`. It now throws `ArgumentException`.
- **Failures are results, not exceptions.** A 404, a timeout, or an HTML page now returns a failed result instead of throwing, or worse, being parsed as a feed.
- **Streams are read from their current position.** If you write to a `MemoryStream` and pass it to `FeedParser`, set `Position = 0` first.
- **URLs are no longer URL-decoded before the request.** 4.x decoded them, which broke URLs with encoded characters such as `%26` in query strings.
- **Responses larger than 10 MB fail** with `ResponseTooLarge`. Raise `MaxResponseBytes` if you need to.
- **`<rss>` without a `version` attribute is parsed** with the RSS 2.0 parser instead of throwing `NullReferenceException`.
- **An already-registered `RecyclableMemoryStreamManager` is kept.** 4.x replaced it unless you set `SuppressRecyclableMemoryStreamManagerRegistration`.

Removed from the public API:

- `HttpClientService`, `NamedHttpClients`, `HttpClientPropertiesWithWaitAndRetry`, and the `IFeedReaderService` marker interface.
- `Helpers` (now internal), `ICollectionExtensions` (now internal), `HtmlHelper.GetFeedLinkFromLinkTag` (now internal), `UrlNotFoundException`, `InvalidFeedLinkException`, and `FeedTypeNotSupportedException`.
- The constructors of the format-specific feed types that take `XElement` or `XDocument`, e.g., `new Rss20FeedItem(element)`. Those types are created by parsing. Their properties, including the `XElement` properties for reading custom elements, are unchanged.

## *** Forked from CodeHollow.FeedReader ***

This is a heavily-modified fork of `CodeHollow.FeedReader`. The biggest difference is that it uses .NET's dependency 
injection framework to manage `HttpClient` instead of storing it in a static variable. I also did a fair bit of 
refactoring and used more modern code constructs in some places.

This version only supports .NET 10 and higher. If you don't need .NET's DI capabilities, or you need support for earlier 
versions of .NET / .NET Framework, please use the original package:

https://github.com/arminreiter/FeedReader

Original readme follows.

-----

# FeedReader

FeedReader is a .net library used for reading and parsing RSS and ATOM feeds. Supports **RSS 0.91, 0.92, 1.0, 2.0 and ATOM**.
Developed because tested existing libraries do not work with different languages, encodings or have other issues. 
Library tested with multiple languages, encodings and feeds.

FeedReader library is available as NuGet package: https://www.nuget.org/packages/CodeHollow.FeedReader/

## Usage
The simplest way to read a feed and show the information is:
```csharp
    var feed = await FeedReader.ReadAsync("https://arminreiter.com/feed");

    Console.WriteLine("Feed Title: " + feed.Title);
    Console.WriteLine("Feed Description: " + feed.Description);
    Console.WriteLine("Feed Image: " + feed.ImageUrl);
    // ...
    foreach(var item in feed.Items)
    {
        Console.WriteLine(item.Title + " - " + item.Link);
    }
```

There are some properties that are only available in e.g. RSS 2.0. If you want to get those properties, the property "SpecificFeed" is the right one:

```csharp
    var feed = await FeedReader.ReadAsync("https://arminreiter.com/feed");

    Console.WriteLine("Feed Title: " + feed.Title);
            
    if(feed.Type == FeedType.Rss_2_0)
    {
        var rss20feed = (Feeds.Rss20Feed)feed.SpecificFeed;
        Console.WriteLine("Generator: " + rss20feed.Generator);
    }
```

If the url to the feed is not known, then you can use FeedReader.GetFeedUrlsFromUrl(url) to parse the url from the html webpage:

```csharp
    string url = "arminreiter.com";
    var urls = FeedReader.GetFeedUrlsFromUrl(url);
            
    string feedUrl;
    if (urls.Count() < 1) // no url - probably the url is already the right feed url
        feedUrl = url;
    else if (urls.Count() == 1)
        feedUrl = urls.First().Url;
    else if (urls.Count() == 2) // if 2 urls, then its usually a feed and a comments feed, so take the first per default
        feedUrl = urls.First().Url;
    else
    {
        // show all urls and let the user select (or take the first or ...)
        // ...
    }

    var readerTask = FeedReader.ReadAsync(feedUrl);
    readerTask.ConfigureAwait(false);

    foreach (var item in readerTask.Result.Items)
    {
        Console.WriteLine(item.Title + " - " + item.Link);
        // ...
    }
```


The code contains a sample console application: https://github.com/codehollow/FeedReader/tree/master/FeedReader.StaticConsoleSample


## Specifications
- RSS 0.91: http://www.rssboard.org/rss-0-9-1-netscape
- RSS 0.92: http://backend.userland.com/rss092, http://www.rssboard.org/rss-0-9-2
- RSS 1.0 : http://web.resource.org/rss/1.0/spec
- RSS 2.0 : https://validator.w3.org/feed/docs/rss2.html
- ATOM    : https://validator.w3.org/feed/docs/atom.html
