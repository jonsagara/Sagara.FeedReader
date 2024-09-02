#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss092Feed Class

Rss 0.92 feed according to specification: http://backend.userland.com/rss092

```csharp
public class Rss092Feed : Sagara.FeedReader.Feeds.Rss091Feed
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeed](Sagara.FeedReader.Feeds.BaseFeed.md 'Sagara.FeedReader.Feeds.BaseFeed') &#129106; [Rss091Feed](Sagara.FeedReader.Feeds.Rss091Feed.md 'Sagara.FeedReader.Feeds.Rss091Feed') &#129106; Rss092Feed
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss092Feed.Rss092Feed()'></a>

## Rss092Feed() Constructor

Initializes a new instance of the [Rss092Feed](Sagara.FeedReader.Feeds.Rss092Feed.md 'Sagara.FeedReader.Feeds.Rss092Feed') class.  
default constructor (for serialization)

```csharp
public Rss092Feed();
```

<a name='Sagara.FeedReader.Feeds.Rss092Feed.Rss092Feed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement)'></a>

## Rss092Feed(string, XDocument, XElement) Constructor

Initializes a new instance of the [Rss092Feed](Sagara.FeedReader.Feeds.Rss092Feed.md 'Sagara.FeedReader.Feeds.Rss092Feed') class.  
Reads a rss 0.92 feed based on the xml given in channel

```csharp
public Rss092Feed(string feedXml, System.Xml.Linq.XDocument feedDoc, System.Xml.Linq.XElement channel);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss092Feed.Rss092Feed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement).feedXml'></a>

`feedXml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the entire feed xml as string

<a name='Sagara.FeedReader.Feeds.Rss092Feed.Rss092Feed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement).feedDoc'></a>

`feedDoc` [System.Xml.Linq.XDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument')

The XDocument parsed from the feed XML. Used to determine if there are iTunes extensions.

<a name='Sagara.FeedReader.Feeds.Rss092Feed.Rss092Feed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement).channel'></a>

`channel` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the "channel" element in the xml as XElement
### Properties

<a name='Sagara.FeedReader.Feeds.Rss092Feed.Cloud'></a>

## Rss092Feed.Cloud Property

The "cloud" field

```csharp
public Sagara.FeedReader.Feeds.FeedCloud? Cloud { get; set; }
```

#### Property Value
[FeedCloud](Sagara.FeedReader.Feeds.FeedCloud.md 'Sagara.FeedReader.Feeds.FeedCloud')
### Methods

<a name='Sagara.FeedReader.Feeds.Rss092Feed.AddItems(System.Collections.Generic.IReadOnlyCollection_System.Xml.Linq.XElement_)'></a>

## Rss092Feed.AddItems(IReadOnlyCollection<XElement>) Method

Adds feed items to the items collection

```csharp
internal override void AddItems(System.Collections.Generic.IReadOnlyCollection<System.Xml.Linq.XElement> items);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss092Feed.AddItems(System.Collections.Generic.IReadOnlyCollection_System.Xml.Linq.XElement_).items'></a>

`items` [System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

feed items as XElements

<a name='Sagara.FeedReader.Feeds.Rss092Feed.ToFeed()'></a>

## Rss092Feed.ToFeed() Method

Creates the base [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') element out of this feed.

```csharp
public override Sagara.FeedReader.Feed ToFeed();
```

#### Returns
[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')  
feed