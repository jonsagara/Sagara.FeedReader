#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss092FeedItem Class

Rss 0.92 feed item according to specification: http://backend.userland.com/rss092

```csharp
public class Rss092FeedItem : Sagara.FeedReader.Feeds.Rss091FeedItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem') &#129106; [Rss091FeedItem](Sagara.FeedReader.Feeds.Rss091FeedItem.md 'Sagara.FeedReader.Feeds.Rss091FeedItem') &#129106; Rss092FeedItem
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss092FeedItem.Rss092FeedItem()'></a>

## Rss092FeedItem() Constructor

Initializes a new instance of the [Rss092FeedItem](Sagara.FeedReader.Feeds.Rss092FeedItem.md 'Sagara.FeedReader.Feeds.Rss092FeedItem') class.  
default constructor (for serialization)

```csharp
public Rss092FeedItem();
```

<a name='Sagara.FeedReader.Feeds.Rss092FeedItem.Rss092FeedItem(System.Xml.Linq.XElement)'></a>

## Rss092FeedItem(XElement) Constructor

Initializes a new instance of the [Rss092FeedItem](Sagara.FeedReader.Feeds.Rss092FeedItem.md 'Sagara.FeedReader.Feeds.Rss092FeedItem') class.  
Creates a new feed item element based on the given xml XELement

```csharp
public Rss092FeedItem(System.Xml.Linq.XElement item);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss092FeedItem.Rss092FeedItem(System.Xml.Linq.XElement).item'></a>

`item` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml containing the feed item
### Properties

<a name='Sagara.FeedReader.Feeds.Rss092FeedItem.Categories'></a>

## Rss092FeedItem.Categories Property

All entries "category" entries

```csharp
public System.Collections.Generic.IReadOnlyCollection<string> Categories { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.Rss092FeedItem.Enclosure'></a>

## Rss092FeedItem.Enclosure Property

The "enclosure" field

```csharp
public Sagara.FeedReader.Feeds.FeedItemEnclosure? Enclosure { get; set; }
```

#### Property Value
[FeedItemEnclosure](Sagara.FeedReader.Feeds.FeedItemEnclosure.md 'Sagara.FeedReader.Feeds.FeedItemEnclosure')

<a name='Sagara.FeedReader.Feeds.Rss092FeedItem.Source'></a>

## Rss092FeedItem.Source Property

The "source" field

```csharp
public Sagara.FeedReader.Feeds.FeedItemSource? Source { get; set; }
```

#### Property Value
[FeedItemSource](Sagara.FeedReader.Feeds.FeedItemSource.md 'Sagara.FeedReader.Feeds.FeedItemSource')