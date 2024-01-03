#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## HtmlFeedLink Class

An html feed link, containing the title, the url and the type of the feed

```csharp
public class HtmlFeedLink
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HtmlFeedLink
### Constructors

<a name='Sagara.FeedReader.HtmlFeedLink.HtmlFeedLink()'></a>

## HtmlFeedLink() Constructor

Initializes a new instance of the [HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink') class.  
default constructor (for serialization)

```csharp
public HtmlFeedLink();
```

<a name='Sagara.FeedReader.HtmlFeedLink.HtmlFeedLink(string,string,Sagara.FeedReader.FeedType)'></a>

## HtmlFeedLink(string, string, FeedType) Constructor

Initializes a new instance of the [HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink') class.  
Creates an html feed link item

```csharp
public HtmlFeedLink(string? title, string url, Sagara.FeedReader.FeedType feedtype);
```
#### Parameters

<a name='Sagara.FeedReader.HtmlFeedLink.HtmlFeedLink(string,string,Sagara.FeedReader.FeedType).title'></a>

`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

title fo the feed

<a name='Sagara.FeedReader.HtmlFeedLink.HtmlFeedLink(string,string,Sagara.FeedReader.FeedType).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

url of the feed

<a name='Sagara.FeedReader.HtmlFeedLink.HtmlFeedLink(string,string,Sagara.FeedReader.FeedType).feedtype'></a>

`feedtype` [FeedType](Sagara.FeedReader.FeedType.md 'Sagara.FeedReader.FeedType')

type of the feed (rss 1.0, 2.0, ...)
### Properties

<a name='Sagara.FeedReader.HtmlFeedLink.FeedType'></a>

## HtmlFeedLink.FeedType Property

The type of the feed - rss or atom

```csharp
public Sagara.FeedReader.FeedType FeedType { get; set; }
```

#### Property Value
[FeedType](Sagara.FeedReader.FeedType.md 'Sagara.FeedReader.FeedType')

<a name='Sagara.FeedReader.HtmlFeedLink.Title'></a>

## HtmlFeedLink.Title Property

The title of the feed

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.HtmlFeedLink.Url'></a>

## HtmlFeedLink.Url Property

The url to the feed

```csharp
public string Url { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')