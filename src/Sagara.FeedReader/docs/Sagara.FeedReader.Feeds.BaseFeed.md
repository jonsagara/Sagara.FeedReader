#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## BaseFeed Class

BaseFeed object which contains the basic properties that each feed has.

```csharp
public abstract class BaseFeed
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BaseFeed

Derived  
&#8627; [AtomFeed](Sagara.FeedReader.Feeds.AtomFeed.md 'Sagara.FeedReader.Feeds.AtomFeed')  
&#8627; [MediaRssFeed](Sagara.FeedReader.Feeds.MediaRssFeed.md 'Sagara.FeedReader.Feeds.MediaRssFeed')  
&#8627; [Rss091Feed](Sagara.FeedReader.Feeds.Rss091Feed.md 'Sagara.FeedReader.Feeds.Rss091Feed')  
&#8627; [Rss10Feed](Sagara.FeedReader.Feeds.Rss10Feed.md 'Sagara.FeedReader.Feeds.Rss10Feed')  
&#8627; [Rss20Feed](Sagara.FeedReader.Feeds.Rss20Feed.md 'Sagara.FeedReader.Feeds.Rss20Feed')
### Constructors

<a name='Sagara.FeedReader.Feeds.BaseFeed.BaseFeed()'></a>

## BaseFeed() Constructor

Initializes a new instance of the [BaseFeed](Sagara.FeedReader.Feeds.BaseFeed.md 'Sagara.FeedReader.Feeds.BaseFeed') class.  
default constructor (for serialization)

```csharp
protected BaseFeed();
```

<a name='Sagara.FeedReader.Feeds.BaseFeed.BaseFeed(string,System.Xml.Linq.XElement)'></a>

## BaseFeed(string, XElement) Constructor

Initializes a new instance of the [BaseFeed](Sagara.FeedReader.Feeds.BaseFeed.md 'Sagara.FeedReader.Feeds.BaseFeed') class.  
Reads a base feed based on the xml given in element

```csharp
protected BaseFeed(string feedXml, System.Xml.Linq.XElement channel);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.BaseFeed.BaseFeed(string,System.Xml.Linq.XElement).feedXml'></a>

`feedXml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the entire feed xml as string

<a name='Sagara.FeedReader.Feeds.BaseFeed.BaseFeed(string,System.Xml.Linq.XElement).channel'></a>

`channel` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the "channel" element in the xml as XElement
### Properties

<a name='Sagara.FeedReader.Feeds.BaseFeed.Element'></a>

## BaseFeed.Element Property

Gets the underlying XElement in order to allow reading properties that are not available in the class itself

```csharp
public System.Xml.Linq.XElement? Element { get; }
```

#### Property Value
[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

<a name='Sagara.FeedReader.Feeds.BaseFeed.Items'></a>

## BaseFeed.Items Property

The items that are in the feed

```csharp
public System.Collections.Generic.ICollection<Sagara.FeedReader.Feeds.BaseFeedItem> Items { get; set; }
```

#### Property Value
[System.Collections.Generic.ICollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')

<a name='Sagara.FeedReader.Feeds.BaseFeed.Link'></a>

## BaseFeed.Link Property

The link (url) to the feed

```csharp
public string? Link { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.BaseFeed.OriginalDocument'></a>

## BaseFeed.OriginalDocument Property

Gets the whole, original feed as string

```csharp
public string? OriginalDocument { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.BaseFeed.Title'></a>

## BaseFeed.Title Property

The title of the feed

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='Sagara.FeedReader.Feeds.BaseFeed.ToFeed()'></a>

## BaseFeed.ToFeed() Method

creates the generic [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') object.

```csharp
public abstract Sagara.FeedReader.Feed ToFeed();
```

#### Returns
[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')  
Feed