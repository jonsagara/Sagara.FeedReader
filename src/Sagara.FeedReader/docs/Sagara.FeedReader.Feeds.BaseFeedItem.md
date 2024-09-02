#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## BaseFeedItem Class

The base object for all feed items

```csharp
public abstract class BaseFeedItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BaseFeedItem

Derived  
&#8627; [AtomFeedItem](Sagara.FeedReader.Feeds.AtomFeedItem.md 'Sagara.FeedReader.Feeds.AtomFeedItem')  
&#8627; [MediaRssFeedItem](Sagara.FeedReader.Feeds.MediaRssFeedItem.md 'Sagara.FeedReader.Feeds.MediaRssFeedItem')  
&#8627; [Rss091FeedItem](Sagara.FeedReader.Feeds.Rss091FeedItem.md 'Sagara.FeedReader.Feeds.Rss091FeedItem')  
&#8627; [Rss10FeedItem](Sagara.FeedReader.Feeds.Rss10FeedItem.md 'Sagara.FeedReader.Feeds.Rss10FeedItem')  
&#8627; [Rss20FeedItem](Sagara.FeedReader.Feeds.Rss20FeedItem.md 'Sagara.FeedReader.Feeds.Rss20FeedItem')
### Constructors

<a name='Sagara.FeedReader.Feeds.BaseFeedItem.BaseFeedItem()'></a>

## BaseFeedItem() Constructor

Initializes a new instance of the [BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem') class.  
default constructor (for serialization)

```csharp
protected BaseFeedItem();
```

<a name='Sagara.FeedReader.Feeds.BaseFeedItem.BaseFeedItem(System.Xml.Linq.XElement)'></a>

## BaseFeedItem(XElement) Constructor

Initializes a new instance of the [BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem') class.  
Reads a base feed item based on the xml given in element

```csharp
protected BaseFeedItem(System.Xml.Linq.XElement itemOrEntryElement);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.BaseFeedItem.BaseFeedItem(System.Xml.Linq.XElement).itemOrEntryElement'></a>

`itemOrEntryElement` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

The `item` or `entry` element from the feed.
### Properties

<a name='Sagara.FeedReader.Feeds.BaseFeedItem.ItemOrEntryElement'></a>

## BaseFeedItem.ItemOrEntryElement Property

The `item` (RSS) or `entry` (Atom) element from the feed. Return as an XElement in order to   
allow reading properties that are not available as first-class properties in the derived class itself.

```csharp
public System.Xml.Linq.XElement? ItemOrEntryElement { get; }
```

#### Property Value
[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

<a name='Sagara.FeedReader.Feeds.BaseFeedItem.Link'></a>

## BaseFeedItem.Link Property

The "link" element

```csharp
public string? Link { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.BaseFeedItem.Title'></a>

## BaseFeedItem.Title Property

The "title" element

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')