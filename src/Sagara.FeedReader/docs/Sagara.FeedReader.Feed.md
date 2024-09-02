#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## Feed Class

Generic Feed object that contains some basic properties. If a property is not available  
for a specific feed type (e.g. Rss 1.0), then the property is empty.  
If a feed has more properties, like the Generator property for Rss 2.0, then you can use  
the [SpecificFeed](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.SpecificFeed 'Sagara.FeedReader.Feed.SpecificFeed') property.

```csharp
public class Feed
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Feed
### Constructors

<a name='Sagara.FeedReader.Feed.Feed()'></a>

## Feed() Constructor

Initializes a new instance of the [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') class.  
Default constructor, just there for serialization.

```csharp
public Feed();
```

<a name='Sagara.FeedReader.Feed.Feed(Sagara.FeedReader.Feeds.BaseFeed)'></a>

## Feed(BaseFeed) Constructor

Initializes a new instance of the [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') class.  
Creates the generic feed object based on a parsed BaseFeed

```csharp
public Feed(Sagara.FeedReader.Feeds.BaseFeed feed);
```
#### Parameters

<a name='Sagara.FeedReader.Feed.Feed(Sagara.FeedReader.Feeds.BaseFeed).feed'></a>

`feed` [BaseFeed](Sagara.FeedReader.Feeds.BaseFeed.md 'Sagara.FeedReader.Feeds.BaseFeed')

BaseFeed which is a [Rss20Feed](Sagara.FeedReader.Feeds.Rss20Feed.md 'Sagara.FeedReader.Feeds.Rss20Feed') , [Rss10Feed](Sagara.FeedReader.Feeds.Rss10Feed.md 'Sagara.FeedReader.Feeds.Rss10Feed'), or another.
### Properties

<a name='Sagara.FeedReader.Feed.Copyright'></a>

## Feed.Copyright Property

The copyright of the feed

```csharp
public string? Copyright { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feed.Description'></a>

## Feed.Description Property

The description of the feed

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feed.HasApplePodcastsModule'></a>

## Feed.HasApplePodcastsModule Property

Returns true if the feed's root element (`rss` for RSS, `feed` for atom) has the Apple Podcasts   
module namespace declaration (`xmlns:itunes`); false otherwise.

```csharp
public bool HasApplePodcastsModule { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.Feed.ImageUrl'></a>

## Feed.ImageUrl Property

The url of the image

```csharp
public string? ImageUrl { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feed.Items'></a>

## Feed.Items Property

List of items. In RSS, these are `item` elements. In Atom, they're `entry` elements.

```csharp
public System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.FeedItem> Items { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[FeedItem](Sagara.FeedReader.FeedItem.md 'Sagara.FeedReader.FeedItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feed.Language'></a>

## Feed.Language Property

The language of the feed

```csharp
public string? Language { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feed.LastUpdatedDate'></a>

## Feed.LastUpdatedDate Property

The last updated date as datetime. Null if parsing failed or if  
no last updated date is set. If null, please check [LastUpdatedDateString](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.LastUpdatedDateString 'Sagara.FeedReader.Feed.LastUpdatedDateString') property.

```csharp
public System.Nullable<System.DateTime> LastUpdatedDate { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feed.LastUpdatedDateString'></a>

## Feed.LastUpdatedDateString Property

The last updated date as string. This is filled, if a last updated  
date is set - independent if it is a correct date or not

```csharp
public string? LastUpdatedDateString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feed.Link'></a>

## Feed.Link Property

The link (url) to the feed

```csharp
public string? Link { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feed.OriginalFeedXml'></a>

## Feed.OriginalFeedXml Property

The original feed XML string.

```csharp
public string? OriginalFeedXml { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
NOTE: If raw XML contained invalid control characters, they were removed.

<a name='Sagara.FeedReader.Feed.SpecificFeed'></a>

## Feed.SpecificFeed Property

The parsed feed element - e.g. of type [Rss20Feed](Sagara.FeedReader.Feeds.Rss20Feed.md 'Sagara.FeedReader.Feeds.Rss20Feed') which contains  
e.g. the Generator property which does not exist in others.

```csharp
public Sagara.FeedReader.Feeds.BaseFeed? SpecificFeed { get; set; }
```

#### Property Value
[BaseFeed](Sagara.FeedReader.Feeds.BaseFeed.md 'Sagara.FeedReader.Feeds.BaseFeed')

<a name='Sagara.FeedReader.Feed.Title'></a>

## Feed.Title Property

The title of the field

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feed.Type'></a>

## Feed.Type Property

The Type of the feed - Rss 2.0, 1.0, 0.92, Atom or others

```csharp
public Sagara.FeedReader.FeedType Type { get; set; }
```

#### Property Value
[FeedType](Sagara.FeedReader.FeedType.md 'Sagara.FeedReader.FeedType')
### Methods

<a name='Sagara.FeedReader.Feed.HasRootNamespaceDeclaration(string)'></a>

## Feed.HasRootNamespaceDeclaration(string) Method

Returns true if the root element has the specified namespace URI declared; false otherwise.

```csharp
public bool HasRootNamespaceDeclaration(string namespaceUri);
```
#### Parameters

<a name='Sagara.FeedReader.Feed.HasRootNamespaceDeclaration(string).namespaceUri'></a>

`namespaceUri` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The local name of the namespace declaration (e.g., `http://www.itunes.com/dtds/podcast-1.0.dtd`  
            for Apple Podcasts).

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')