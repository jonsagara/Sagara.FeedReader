#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss091FeedItem Class

Rss 0.91 Feed Item according to specification: http://www.rssboard.org/rss-0-9-1-netscape#image

```csharp
public class Rss091FeedItem : Sagara.FeedReader.Feeds.BaseFeedItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem') &#129106; Rss091FeedItem

Derived  
&#8627; [Rss092FeedItem](Sagara.FeedReader.Feeds.Rss092FeedItem.md 'Sagara.FeedReader.Feeds.Rss092FeedItem')
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss091FeedItem.Rss091FeedItem()'></a>

## Rss091FeedItem() Constructor

Initializes a new instance of the [Rss091FeedItem](Sagara.FeedReader.Feeds.Rss091FeedItem.md 'Sagara.FeedReader.Feeds.Rss091FeedItem') class.  
default constructor (for serialization)

```csharp
public Rss091FeedItem();
```

<a name='Sagara.FeedReader.Feeds.Rss091FeedItem.Rss091FeedItem(System.Xml.Linq.XElement)'></a>

## Rss091FeedItem(XElement) Constructor

Initializes a new instance of the [Rss091FeedItem](Sagara.FeedReader.Feeds.Rss091FeedItem.md 'Sagara.FeedReader.Feeds.Rss091FeedItem') class.  
Creates this object based on the xml in the XElement parameter.

```csharp
public Rss091FeedItem(System.Xml.Linq.XElement item);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss091FeedItem.Rss091FeedItem(System.Xml.Linq.XElement).item'></a>

`item` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

feed item as xml
### Properties

<a name='Sagara.FeedReader.Feeds.Rss091FeedItem.Description'></a>

## Rss091FeedItem.Description Property

The "description" field

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss091FeedItem.PublishingDate'></a>

## Rss091FeedItem.PublishingDate Property

The "pubDate" field as DateTime. Null if parsing failed or pubDate is empty.

```csharp
public System.Nullable<System.DateTime> PublishingDate { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.Rss091FeedItem.PublishingDateString'></a>

## Rss091FeedItem.PublishingDateString Property

The "pubDate" field

```csharp
public string? PublishingDateString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')