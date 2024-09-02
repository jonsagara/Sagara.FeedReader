#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## MediaRssFeed Class

Media RSS 2.0 feed according to specification: http://www.rssboard.org/media-rss

```csharp
public class MediaRssFeed : Sagara.FeedReader.Feeds.BaseFeed
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeed](Sagara.FeedReader.Feeds.BaseFeed.md 'Sagara.FeedReader.Feeds.BaseFeed') &#129106; MediaRssFeed
### Constructors

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.MediaRssFeed()'></a>

## MediaRssFeed() Constructor

Initializes a new instance of the [MediaRssFeed](Sagara.FeedReader.Feeds.MediaRssFeed.md 'Sagara.FeedReader.Feeds.MediaRssFeed') class.  
default constructor (for serialization)

```csharp
public MediaRssFeed();
```

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.MediaRssFeed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement)'></a>

## MediaRssFeed(string, XDocument, XElement) Constructor

Initializes a new instance of the [MediaRssFeed](Sagara.FeedReader.Feeds.MediaRssFeed.md 'Sagara.FeedReader.Feeds.MediaRssFeed') class.  
Reads a Media Rss feed based on the xml given in channel

```csharp
public MediaRssFeed(string feedXml, System.Xml.Linq.XDocument feedDoc, System.Xml.Linq.XElement channel);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.MediaRssFeed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement).feedXml'></a>

`feedXml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the entire feed xml as string

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.MediaRssFeed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement).feedDoc'></a>

`feedDoc` [System.Xml.Linq.XDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument')

The XDocument parsed from the feed XML. Used to determine if there are iTunes extensions.

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.MediaRssFeed(string,System.Xml.Linq.XDocument,System.Xml.Linq.XElement).channel'></a>

`channel` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the "channel" element in the xml as XElement
### Properties

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.Categories'></a>

## MediaRssFeed.Categories Property

All "category" elements

```csharp
public System.Collections.Generic.IReadOnlyCollection<string> Categories { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.Cloud'></a>

## MediaRssFeed.Cloud Property

The "cloud" element

```csharp
public Sagara.FeedReader.Feeds.FeedCloud? Cloud { get; set; }
```

#### Property Value
[FeedCloud](Sagara.FeedReader.Feeds.FeedCloud.md 'Sagara.FeedReader.Feeds.FeedCloud')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.Copyright'></a>

## MediaRssFeed.Copyright Property

The "copyright" element

```csharp
public string? Copyright { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.Description'></a>

## MediaRssFeed.Description Property

The "description" element

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.Docs'></a>

## MediaRssFeed.Docs Property

The "docs" element

```csharp
public string? Docs { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.Generator'></a>

## MediaRssFeed.Generator Property

The "generator" element

```csharp
public string? Generator { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.Image'></a>

## MediaRssFeed.Image Property

The "image" element

```csharp
public Sagara.FeedReader.Feeds.FeedImage? Image { get; set; }
```

#### Property Value
[FeedImage](Sagara.FeedReader.Feeds.FeedImage.md 'Sagara.FeedReader.Feeds.FeedImage')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.Language'></a>

## MediaRssFeed.Language Property

The "language" element

```csharp
public string? Language { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.LastBuildDate'></a>

## MediaRssFeed.LastBuildDate Property

The "lastBuildDate" element as DateTime. Null if parsing failed of lastBuildDate is empty.

```csharp
public System.Nullable<System.DateTime> LastBuildDate { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.LastBuildDateString'></a>

## MediaRssFeed.LastBuildDateString Property

The "lastBuildDate" element as string

```csharp
public string? LastBuildDateString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.ManagingEditor'></a>

## MediaRssFeed.ManagingEditor Property

The "managingEditor" element

```csharp
public string? ManagingEditor { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.PublishingDate'></a>

## MediaRssFeed.PublishingDate Property

The "pubDate" field as DateTime. Null if parsing failed or pubDate is empty.

```csharp
public System.Nullable<System.DateTime> PublishingDate { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.PublishingDateString'></a>

## MediaRssFeed.PublishingDateString Property

The "pubDate" field

```csharp
public string? PublishingDateString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.SkipDays'></a>

## MediaRssFeed.SkipDays Property

All "day" elements in "skipDays"

```csharp
public System.Collections.Generic.IReadOnlyCollection<string> SkipDays { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.SkipHours'></a>

## MediaRssFeed.SkipHours Property

All "hour" elements in "skipHours"

```csharp
public System.Collections.Generic.IReadOnlyCollection<string> SkipHours { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.Sy'></a>

## MediaRssFeed.Sy Property

All elements starting with "sy:"

```csharp
public Sagara.FeedReader.Feeds.Syndication? Sy { get; set; }
```

#### Property Value
[Syndication](Sagara.FeedReader.Feeds.Syndication.md 'Sagara.FeedReader.Feeds.Syndication')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.TextInput'></a>

## MediaRssFeed.TextInput Property

The "textInput" element

```csharp
public Sagara.FeedReader.Feeds.FeedTextInput? TextInput { get; set; }
```

#### Property Value
[FeedTextInput](Sagara.FeedReader.Feeds.FeedTextInput.md 'Sagara.FeedReader.Feeds.FeedTextInput')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.TTL'></a>

## MediaRssFeed.TTL Property

The time to life "ttl" element

```csharp
public string? TTL { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.WebMaster'></a>

## MediaRssFeed.WebMaster Property

The "webMaster" field

```csharp
public string? WebMaster { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.ParseDates(string,string,string)'></a>

## MediaRssFeed.ParseDates(string, string, string) Method

Sets the PublishingDate and LastBuildDate. If parsing fails, then it checks if the language  
is set and tries to parse the date based on the culture of the language.

```csharp
private void ParseDates(string? language, string? publishingDate, string? lastBuildDate);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.ParseDates(string,string,string).language'></a>

`language` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

language of the feed

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.ParseDates(string,string,string).publishingDate'></a>

`publishingDate` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

publishing date as string

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.ParseDates(string,string,string).lastBuildDate'></a>

`lastBuildDate` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

last build date as string

<a name='Sagara.FeedReader.Feeds.MediaRssFeed.ToFeed()'></a>

## MediaRssFeed.ToFeed() Method

Creates the base [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') element out of this feed.

```csharp
public override Sagara.FeedReader.Feed ToFeed();
```

#### Returns
[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')  
feed