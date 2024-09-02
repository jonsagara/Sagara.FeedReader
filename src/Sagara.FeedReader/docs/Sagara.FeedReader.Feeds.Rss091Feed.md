#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss091Feed Class

Rss Feed according to Rss 0.91 specification:  
http://www.rssboard.org/rss-0-9-1-netscape

```csharp
public class Rss091Feed : Sagara.FeedReader.Feeds.BaseFeed
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeed](Sagara.FeedReader.Feeds.BaseFeed.md 'Sagara.FeedReader.Feeds.BaseFeed') &#129106; Rss091Feed

Derived  
&#8627; [Rss092Feed](Sagara.FeedReader.Feeds.Rss092Feed.md 'Sagara.FeedReader.Feeds.Rss092Feed')
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss091Feed.Rss091Feed()'></a>

## Rss091Feed() Constructor

Initializes a new instance of the [Rss091Feed](Sagara.FeedReader.Feeds.Rss091Feed.md 'Sagara.FeedReader.Feeds.Rss091Feed') class.  
default constructor (for serialization)

```csharp
public Rss091Feed();
```

<a name='Sagara.FeedReader.Feeds.Rss091Feed.Rss091Feed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement)'></a>

## Rss091Feed(string, XDocument, XElement) Constructor

Initializes a new instance of the [Rss091Feed](Sagara.FeedReader.Feeds.Rss091Feed.md 'Sagara.FeedReader.Feeds.Rss091Feed') class.  
Reads a rss 0.91 feed based on the xml given in channel

```csharp
public Rss091Feed(string feedXml, System.Xml.Linq.XDocument feedDoc, System.Xml.Linq.XElement channel);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss091Feed.Rss091Feed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement).feedXml'></a>

`feedXml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the entire feed xml as string

<a name='Sagara.FeedReader.Feeds.Rss091Feed.Rss091Feed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement).feedDoc'></a>

`feedDoc` [System.Xml.Linq.XDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument')

The XDocument parsed from the feed XML. Used to determine if there are iTunes extensions.

<a name='Sagara.FeedReader.Feeds.Rss091Feed.Rss091Feed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement).channel'></a>

`channel` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the "channel" element in the xml as XElement
### Properties

<a name='Sagara.FeedReader.Feeds.Rss091Feed.Copyright'></a>

## Rss091Feed.Copyright Property

The "copyright" field

```csharp
public string? Copyright { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.Description'></a>

## Rss091Feed.Description Property

The required field "description"

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.Docs'></a>

## Rss091Feed.Docs Property

The "docs" field

```csharp
public string? Docs { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.Image'></a>

## Rss091Feed.Image Property

The "image" element

```csharp
public Sagara.FeedReader.Feeds.FeedImage? Image { get; set; }
```

#### Property Value
[FeedImage](Sagara.FeedReader.Feeds.FeedImage.md 'Sagara.FeedReader.Feeds.FeedImage')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.Language'></a>

## Rss091Feed.Language Property

The required field "language"  
///

```csharp
public string? Language { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.LastBuildDate'></a>

## Rss091Feed.LastBuildDate Property

The "lastBuildDate" as DateTime. Null if parsing failed or lastBuildDate is empty.

```csharp
public System.Nullable<System.DateTime> LastBuildDate { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.LastBuildDateString'></a>

## Rss091Feed.LastBuildDateString Property

The "lastBuildDate" element

```csharp
public string? LastBuildDateString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.ManagingEditor'></a>

## Rss091Feed.ManagingEditor Property

The "managingEditor" field

```csharp
public string? ManagingEditor { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.PublishingDate'></a>

## Rss091Feed.PublishingDate Property

The "pubDate" field as DateTime. Null if parsing failed or pubDate is empty.

```csharp
public System.Nullable<System.DateTime> PublishingDate { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.PublishingDateString'></a>

## Rss091Feed.PublishingDateString Property

The "pubDate" field

```csharp
public string? PublishingDateString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.Rating'></a>

## Rss091Feed.Rating Property

The "rating" field

```csharp
public string? Rating { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.SkipDays'></a>

## Rss091Feed.SkipDays Property

All "day" elements in "skipDays"

```csharp
public System.Collections.Generic.IReadOnlyCollection<string> SkipDays { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.SkipHours'></a>

## Rss091Feed.SkipHours Property

All "hour" elements in "skipHours"

```csharp
public System.Collections.Generic.IReadOnlyCollection<string> SkipHours { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.Sy'></a>

## Rss091Feed.Sy Property

All elements that start with "sy:"

```csharp
public Sagara.FeedReader.Feeds.Syndication? Sy { get; set; }
```

#### Property Value
[Syndication](Sagara.FeedReader.Feeds.Syndication.md 'Sagara.FeedReader.Feeds.Syndication')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.TextInput'></a>

## Rss091Feed.TextInput Property

The "textInput" element

```csharp
public Sagara.FeedReader.Feeds.FeedTextInput? TextInput { get; set; }
```

#### Property Value
[FeedTextInput](Sagara.FeedReader.Feeds.FeedTextInput.md 'Sagara.FeedReader.Feeds.FeedTextInput')

<a name='Sagara.FeedReader.Feeds.Rss091Feed.WebMaster'></a>

## Rss091Feed.WebMaster Property

The "webMaster" element

```csharp
public string? WebMaster { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='Sagara.FeedReader.Feeds.Rss091Feed.AddItems(System.Collections.Generic.IReadOnlyCollection_System.Xml.Linq.XElement_)'></a>

## Rss091Feed.AddItems(IReadOnlyCollection<XElement>) Method

Adds feed items to the items collection

```csharp
internal virtual void AddItems(System.Collections.Generic.IReadOnlyCollection<System.Xml.Linq.XElement> items);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss091Feed.AddItems(System.Collections.Generic.IReadOnlyCollection_System.Xml.Linq.XElement_).items'></a>

`items` [System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

feed items as XElements

<a name='Sagara.FeedReader.Feeds.Rss091Feed.ToFeed()'></a>

## Rss091Feed.ToFeed() Method

Creates the base [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') element out of this feed.

```csharp
public override Sagara.FeedReader.Feed ToFeed();
```

#### Returns
[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')  
feed