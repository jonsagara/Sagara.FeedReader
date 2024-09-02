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

<a name='Sagara.FeedReader.Feeds.BaseFeed.BaseFeed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement)'></a>

## BaseFeed(string, XDocument, XElement) Constructor

Initializes a new instance of the [BaseFeed](Sagara.FeedReader.Feeds.BaseFeed.md 'Sagara.FeedReader.Feeds.BaseFeed') class.  
Reads a base feed based on the xml given in element

```csharp
protected BaseFeed(string feedXml, System.Xml.Linq.XDocument feedDoc, System.Xml.Linq.XElement channel);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.BaseFeed.BaseFeed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement).feedXml'></a>

`feedXml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The entire feed XML as string.

<a name='Sagara.FeedReader.Feeds.BaseFeed.BaseFeed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement).feedDoc'></a>

`feedDoc` [System.Xml.Linq.XDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument')

The XDocument parsed from the feed XML. Used to determine if there are iTunes extensions.

<a name='Sagara.FeedReader.Feeds.BaseFeed.BaseFeed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement).channel'></a>

`channel` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

  
The `channel` (RSS) or `feed` (Atom) element in the xml as XElement.  
  
NOTE: RSS has a root `rss` element, followed by a `channel` element.  
  
Atom only has a root `feed` element.
### Properties

<a name='Sagara.FeedReader.Feeds.BaseFeed.ChannelOrFeedElement'></a>

## BaseFeed.ChannelOrFeedElement Property

The `channel` (RSS) or `feed` (Atom) element from the feed. Returned as an XElement   
in order to allow reading properties that are not available as first-class properties in the derived  
class itself.

```csharp
public System.Xml.Linq.XElement? ChannelOrFeedElement { get; }
```

#### Property Value
[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

### Remarks
  
NOTE: RSS has a root `rss` element, followed by a `channel` element.  
  
Atom only has a root `feed` element that contains.

<a name='Sagara.FeedReader.Feeds.BaseFeed.HasApplePodcastsModule'></a>

## BaseFeed.HasApplePodcastsModule Property

Returns true if the feed's root element (`rss` for RSS, `feed` for atom) has the Apple Podcasts   
module namespace declaration (`xmlns:itunes`); false otherwise.

```csharp
public bool HasApplePodcastsModule { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### Remarks
NOTE: because the library has first-class support for this, we directly set a boolean rather than  
querying the collection of root element namespace declarations at runtime.

<a name='Sagara.FeedReader.Feeds.BaseFeed.Items'></a>

## BaseFeed.Items Property

The items that are in the feed, specific to the feed type (Atom vs. RSS 2.0, etc.).

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

<a name='Sagara.FeedReader.Feeds.BaseFeed.OriginalFeedXml'></a>

## BaseFeed.OriginalFeedXml Property

The original feed XML string.

```csharp
public string? OriginalFeedXml { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
NOTE: If raw XML contained invalid control characters, they were removed.

<a name='Sagara.FeedReader.Feeds.BaseFeed.RootNamespaceDeclarations'></a>

## BaseFeed.RootNamespaceDeclarations Property

The root namespace declarations in the XML document. Key is the namespace attribute value (the namespace URI),   
Value is the LocalName (the abbreviation, e.g., `itunes`) used to declare the namespace in the root element,  
minus the `xmlns:` part.

```csharp
public System.Collections.Frozen.FrozenDictionary<string,string> RootNamespaceDeclarations { get; set; }
```

#### Property Value
[System.Collections.Frozen.FrozenDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Frozen.FrozenDictionary-2 'System.Collections.Frozen.FrozenDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Frozen.FrozenDictionary-2 'System.Collections.Frozen.FrozenDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Frozen.FrozenDictionary-2 'System.Collections.Frozen.FrozenDictionary`2')

### Remarks
Allows callers to determine if they should further parse the `channel` or `feed` element for custom modules.

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