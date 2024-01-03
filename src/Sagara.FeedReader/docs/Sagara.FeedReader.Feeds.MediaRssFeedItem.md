#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## MediaRssFeedItem Class

RSS 2.0 feed item according to specification: https://validator.w3.org/feed/docs/rss2.html

```csharp
public class MediaRssFeedItem : Sagara.FeedReader.Feeds.BaseFeedItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem') &#129106; MediaRssFeedItem
### Constructors

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.MediaRssFeedItem()'></a>

## MediaRssFeedItem() Constructor

Initializes a new instance of the [MediaRssFeedItem](Sagara.FeedReader.Feeds.MediaRssFeedItem.md 'Sagara.FeedReader.Feeds.MediaRssFeedItem') class.  
default constructor (for serialization)

```csharp
public MediaRssFeedItem();
```

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.MediaRssFeedItem(System.Xml.Linq.XElement)'></a>

## MediaRssFeedItem(XElement) Constructor

Initializes a new instance of the [MediaRssFeedItem](Sagara.FeedReader.Feeds.MediaRssFeedItem.md 'Sagara.FeedReader.Feeds.MediaRssFeedItem') class.  
Reads a new feed item element based on the given xml item

```csharp
public MediaRssFeedItem(System.Xml.Linq.XElement item);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.MediaRssFeedItem(System.Xml.Linq.XElement).item'></a>

`item` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml containing the feed item
### Properties

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.Author'></a>

## MediaRssFeedItem.Author Property

The "author" field of the feed item

```csharp
public string? Author { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.Categories'></a>

## MediaRssFeedItem.Categories Property

All entries "category" entries

```csharp
public System.Collections.Generic.IReadOnlyCollection<string> Categories { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.Comments'></a>

## MediaRssFeedItem.Comments Property

The "comments" field of the feed item

```csharp
public string? Comments { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.Content'></a>

## MediaRssFeedItem.Content Property

The "content:encoded" field

```csharp
public string? Content { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.DC'></a>

## MediaRssFeedItem.DC Property

All elements starting with "dc:"

```csharp
public Sagara.FeedReader.Feeds.DublinCore? DC { get; set; }
```

#### Property Value
[DublinCore](Sagara.FeedReader.Feeds.DublinCore.md 'Sagara.FeedReader.Feeds.DublinCore')

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.Description'></a>

## MediaRssFeedItem.Description Property

The "description" field of the feed item

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.Enclosure'></a>

## MediaRssFeedItem.Enclosure Property

The "enclosure" field

```csharp
public Sagara.FeedReader.Feeds.FeedItemEnclosure? Enclosure { get; set; }
```

#### Property Value
[FeedItemEnclosure](Sagara.FeedReader.Feeds.FeedItemEnclosure.md 'Sagara.FeedReader.Feeds.FeedItemEnclosure')

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.Guid'></a>

## MediaRssFeedItem.Guid Property

The "guid" field

```csharp
public string? Guid { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.Media'></a>

## MediaRssFeedItem.Media Property

All entries from the "media:content" elements.

```csharp
public System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.Feeds.MediaRSS.Media> Media { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[Media](Sagara.FeedReader.Feeds.MediaRSS.Media.md 'Sagara.FeedReader.Feeds.MediaRSS.Media')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.MediaGroups'></a>

## MediaRssFeedItem.MediaGroups Property

All entries from the "media:group" elements.

```csharp
public System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.Feeds.MediaRSS.MediaGroup> MediaGroups { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[MediaGroup](Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.md 'Sagara.FeedReader.Feeds.MediaRSS.MediaGroup')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.PublishingDate'></a>

## MediaRssFeedItem.PublishingDate Property

The "pubDate" field as DateTime. Null if parsing failed or pubDate is empty.

```csharp
public System.Nullable<System.DateTime> PublishingDate { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.PublishingDateString'></a>

## MediaRssFeedItem.PublishingDateString Property

The "pubDate" field

```csharp
public string? PublishingDateString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeedItem.Source'></a>

## MediaRssFeedItem.Source Property

The "source" field

```csharp
public Sagara.FeedReader.Feeds.FeedItemSource? Source { get; set; }
```

#### Property Value
[FeedItemSource](Sagara.FeedReader.Feeds.FeedItemSource.md 'Sagara.FeedReader.Feeds.FeedItemSource')