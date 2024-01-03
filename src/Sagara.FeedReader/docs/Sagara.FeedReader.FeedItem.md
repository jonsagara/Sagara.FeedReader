#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## FeedItem Class

Generic feed item object that contains some basic properties. The feed item is typically  
an article or a blog post. If a property is not available  
for a specific feed type (e.g. Rss 1.0), then the property is empty.  
If a feed item has more properties, like the Generator property for Rss 2.0, then you can use  
the [SpecificItem](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.SpecificItem 'Sagara.FeedReader.FeedItem.SpecificItem') property.

```csharp
public class FeedItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedItem
### Constructors

<a name='Sagara.FeedReader.FeedItem.FeedItem()'></a>

## FeedItem() Constructor

Initializes a new instance of the [FeedItem](Sagara.FeedReader.FeedItem.md 'Sagara.FeedReader.FeedItem') class.  
Default constructor, just there for serialization.

```csharp
public FeedItem();
```

<a name='Sagara.FeedReader.FeedItem.FeedItem(Sagara.FeedReader.Feeds.BaseFeedItem)'></a>

## FeedItem(BaseFeedItem) Constructor

Initializes a new instance of the [FeedItem](Sagara.FeedReader.FeedItem.md 'Sagara.FeedReader.FeedItem') class.  
Creates the generic feed item object based on a parsed [BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem')

```csharp
public FeedItem(Sagara.FeedReader.Feeds.BaseFeedItem feedItem);
```
#### Parameters

<a name='Sagara.FeedReader.FeedItem.FeedItem(Sagara.FeedReader.Feeds.BaseFeedItem).feedItem'></a>

`feedItem` [BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem')

BaseFeedItem which is a [Rss20FeedItem](Sagara.FeedReader.Feeds.Rss20FeedItem.md 'Sagara.FeedReader.Feeds.Rss20FeedItem') , [Rss10FeedItem](Sagara.FeedReader.Feeds.Rss10FeedItem.md 'Sagara.FeedReader.Feeds.Rss10FeedItem'), or another.
### Properties

<a name='Sagara.FeedReader.FeedItem.Author'></a>

## FeedItem.Author Property

The author of the feed item

```csharp
public string? Author { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.FeedItem.Categories'></a>

## FeedItem.Categories Property

The categories of the feeditem

```csharp
public System.Collections.Generic.ICollection<string> Categories { get; set; }
```

#### Property Value
[System.Collections.Generic.ICollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')

<a name='Sagara.FeedReader.FeedItem.Content'></a>

## FeedItem.Content Property

The content of the feed item

```csharp
public string? Content { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.FeedItem.Description'></a>

## FeedItem.Description Property

The description of the feed item

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.FeedItem.Id'></a>

## FeedItem.Id Property

The id of the feed item

```csharp
public string? Id { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.FeedItem.Link'></a>

## FeedItem.Link Property

The link (url) to the feed item

```csharp
public string? Link { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.FeedItem.PublishingDate'></a>

## FeedItem.PublishingDate Property

The published date as datetime. Null if parsing failed or if  
no publishing date is set. If null, please check [PublishingDateString](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.PublishingDateString 'Sagara.FeedReader.FeedItem.PublishingDateString') property.

```csharp
public System.Nullable<System.DateTime> PublishingDate { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.FeedItem.PublishingDateString'></a>

## FeedItem.PublishingDateString Property

The publishing date as string. This is filled, if a publishing  
date is set - independent if it is a correct date or not

```csharp
public string? PublishingDateString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.FeedItem.SpecificItem'></a>

## FeedItem.SpecificItem Property

The parsed feed item element - e.g. of type [Rss20FeedItem](Sagara.FeedReader.Feeds.Rss20FeedItem.md 'Sagara.FeedReader.Feeds.Rss20FeedItem') which contains  
e.g. the Enclosure property which does not exist in other feed types.

```csharp
public Sagara.FeedReader.Feeds.BaseFeedItem? SpecificItem { get; set; }
```

#### Property Value
[BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem')

<a name='Sagara.FeedReader.FeedItem.Title'></a>

## FeedItem.Title Property

The title of the feed item

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')