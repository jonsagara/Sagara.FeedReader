#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss10FeedItem Class

Rss 1.0 Feed Item according to specification: http://web.resource.org/rss/1.0/spec

```csharp
public class Rss10FeedItem : Sagara.FeedReader.Feeds.BaseFeedItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem') &#129106; Rss10FeedItem
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss10FeedItem.Rss10FeedItem()'></a>

## Rss10FeedItem() Constructor

Initializes a new instance of the [Rss10FeedItem](Sagara.FeedReader.Feeds.Rss10FeedItem.md 'Sagara.FeedReader.Feeds.Rss10FeedItem') class.  
default constructor (for serialization)

```csharp
public Rss10FeedItem();
```

<a name='Sagara.FeedReader.Feeds.Rss10FeedItem.Rss10FeedItem(System.Xml.Linq.XElement)'></a>

## Rss10FeedItem(XElement) Constructor

Initializes a new instance of the [Rss10FeedItem](Sagara.FeedReader.Feeds.Rss10FeedItem.md 'Sagara.FeedReader.Feeds.Rss10FeedItem') class.  
Reads a rss 1.0 feed item based on the xml given in item

```csharp
public Rss10FeedItem(System.Xml.Linq.XElement item);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss10FeedItem.Rss10FeedItem(System.Xml.Linq.XElement).item'></a>

`item` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

feed item as xml
### Properties

<a name='Sagara.FeedReader.Feeds.Rss10FeedItem.About'></a>

## Rss10FeedItem.About Property

The "about" attribute of the element

```csharp
public string? About { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss10FeedItem.DC'></a>

## Rss10FeedItem.DC Property

All elements starting with "dc:"

```csharp
public Sagara.FeedReader.Feeds.DublinCore? DC { get; set; }
```

#### Property Value
[DublinCore](Sagara.FeedReader.Feeds.DublinCore.md 'Sagara.FeedReader.Feeds.DublinCore')

<a name='Sagara.FeedReader.Feeds.Rss10FeedItem.Description'></a>

## Rss10FeedItem.Description Property

The "description" field

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss10FeedItem.Sy'></a>

## Rss10FeedItem.Sy Property

All elements starting with "sy:"

```csharp
public Sagara.FeedReader.Feeds.Syndication? Sy { get; set; }
```

#### Property Value
[Syndication](Sagara.FeedReader.Feeds.Syndication.md 'Sagara.FeedReader.Feeds.Syndication')