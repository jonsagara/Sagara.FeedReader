#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss20FeedItem Class

RSS 2.0 feed item according to specification: https://validator.w3.org/feed/docs/rss2.html

```csharp
public class Rss20FeedItem : Sagara.FeedReader.Feeds.BaseFeedItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem') &#129106; Rss20FeedItem
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.Rss20FeedItem()'></a>

## Rss20FeedItem() Constructor

Initializes a new instance of the [Rss20FeedItem](Sagara.FeedReader.Feeds.Rss20FeedItem.md 'Sagara.FeedReader.Feeds.Rss20FeedItem') class.  
default constructor (for serialization)

```csharp
public Rss20FeedItem();
```

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.Rss20FeedItem(System.Xml.Linq.XElement)'></a>

## Rss20FeedItem(XElement) Constructor

Initializes a new instance of the [Rss20FeedItem](Sagara.FeedReader.Feeds.Rss20FeedItem.md 'Sagara.FeedReader.Feeds.Rss20FeedItem') class.  
Reads a new feed item element based on the given xml item

```csharp
public Rss20FeedItem(System.Xml.Linq.XElement item);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.Rss20FeedItem(System.Xml.Linq.XElement).item'></a>

`item` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

The xml containing the feed item
### Properties

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.Author'></a>

## Rss20FeedItem.Author Property

The "author" field of the feed item

```csharp
public string? Author { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.Categories'></a>

## Rss20FeedItem.Categories Property

All entries "category" entries

```csharp
public System.Collections.Generic.IReadOnlyCollection<string> Categories { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.Comments'></a>

## Rss20FeedItem.Comments Property

The "comments" field of the feed item

```csharp
public string? Comments { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.Content'></a>

## Rss20FeedItem.Content Property

The "content:encoded" field

```csharp
public string? Content { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.DC'></a>

## Rss20FeedItem.DC Property

All elements starting with "dc:"

```csharp
public Sagara.FeedReader.Feeds.DublinCore? DC { get; set; }
```

#### Property Value
[DublinCore](Sagara.FeedReader.Feeds.DublinCore.md 'Sagara.FeedReader.Feeds.DublinCore')

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.Description'></a>

## Rss20FeedItem.Description Property

The "description" field of the feed item

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.Enclosure'></a>

## Rss20FeedItem.Enclosure Property

The "enclosure" field

```csharp
public Sagara.FeedReader.Feeds.FeedItemEnclosure? Enclosure { get; set; }
```

#### Property Value
[FeedItemEnclosure](Sagara.FeedReader.Feeds.FeedItemEnclosure.md 'Sagara.FeedReader.Feeds.FeedItemEnclosure')

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.Guid'></a>

## Rss20FeedItem.Guid Property

The "guid" field

```csharp
public string? Guid { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.PublishingDate'></a>

## Rss20FeedItem.PublishingDate Property

The "pubDate" field as DateTime. Null if parsing failed or pubDate is empty.

```csharp
public System.Nullable<System.DateTime> PublishingDate { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.PublishingDateString'></a>

## Rss20FeedItem.PublishingDateString Property

The "pubDate" field

```csharp
public string? PublishingDateString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.Source'></a>

## Rss20FeedItem.Source Property

The "source" field

```csharp
public Sagara.FeedReader.Feeds.FeedItemSource? Source { get; set; }
```

#### Property Value
[FeedItemSource](Sagara.FeedReader.Feeds.FeedItemSource.md 'Sagara.FeedReader.Feeds.FeedItemSource')
### Methods

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.GetPublishingDateString(System.Xml.Linq.XElement)'></a>

## Rss20FeedItem.GetPublishingDateString(XElement) Method

If we can't find a value for pubDate, look for Atom's updated element.

```csharp
private static string? GetPublishingDateString(System.Xml.Linq.XElement item);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss20FeedItem.GetPublishingDateString(System.Xml.Linq.XElement).item'></a>

`item` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

The xml containing the feed item.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')