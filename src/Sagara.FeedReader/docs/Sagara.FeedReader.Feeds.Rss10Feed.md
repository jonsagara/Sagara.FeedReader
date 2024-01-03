#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss10Feed Class

Rss 1.0 Feed according to specification: http://web.resource.org/rss/1.0/spec

```csharp
public class Rss10Feed : Sagara.FeedReader.Feeds.BaseFeed
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeed](Sagara.FeedReader.Feeds.BaseFeed.md 'Sagara.FeedReader.Feeds.BaseFeed') &#129106; Rss10Feed
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss10Feed.Rss10Feed()'></a>

## Rss10Feed() Constructor

Initializes a new instance of the [Rss10Feed](Sagara.FeedReader.Feeds.Rss10Feed.md 'Sagara.FeedReader.Feeds.Rss10Feed') class.  
default constructor (for serialization)

```csharp
public Rss10Feed();
```

<a name='Sagara.FeedReader.Feeds.Rss10Feed.Rss10Feed(string,System.Xml.Linq.XElement)'></a>

## Rss10Feed(string, XElement) Constructor

Initializes a new instance of the [Rss10Feed](Sagara.FeedReader.Feeds.Rss10Feed.md 'Sagara.FeedReader.Feeds.Rss10Feed') class.  
Reads a rss 1.0 feed based on the xml given in xelement

```csharp
public Rss10Feed(string feedXml, System.Xml.Linq.XElement channel);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss10Feed.Rss10Feed(string,System.Xml.Linq.XElement).feedXml'></a>

`feedXml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the entire feed xml as string

<a name='Sagara.FeedReader.Feeds.Rss10Feed.Rss10Feed(string,System.Xml.Linq.XElement).channel'></a>

`channel` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the "channel" element in the xml as XElement
### Properties

<a name='Sagara.FeedReader.Feeds.Rss10Feed.About'></a>

## Rss10Feed.About Property

The "about" attribute of the element

```csharp
public string? About { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss10Feed.DC'></a>

## Rss10Feed.DC Property

All elements starting with "dc:"

```csharp
public Sagara.FeedReader.Feeds.DublinCore? DC { get; set; }
```

#### Property Value
[DublinCore](Sagara.FeedReader.Feeds.DublinCore.md 'Sagara.FeedReader.Feeds.DublinCore')

<a name='Sagara.FeedReader.Feeds.Rss10Feed.Description'></a>

## Rss10Feed.Description Property

The "description" field

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss10Feed.Image'></a>

## Rss10Feed.Image Property

The "image" element

```csharp
public Sagara.FeedReader.Feeds.FeedImage? Image { get; set; }
```

#### Property Value
[FeedImage](Sagara.FeedReader.Feeds.FeedImage.md 'Sagara.FeedReader.Feeds.FeedImage')

<a name='Sagara.FeedReader.Feeds.Rss10Feed.Sy'></a>

## Rss10Feed.Sy Property

All elements starting with "sy:"

```csharp
public Sagara.FeedReader.Feeds.Syndication? Sy { get; set; }
```

#### Property Value
[Syndication](Sagara.FeedReader.Feeds.Syndication.md 'Sagara.FeedReader.Feeds.Syndication')

<a name='Sagara.FeedReader.Feeds.Rss10Feed.TextInput'></a>

## Rss10Feed.TextInput Property

The "textInput" element

```csharp
public Sagara.FeedReader.Feeds.FeedTextInput? TextInput { get; set; }
```

#### Property Value
[FeedTextInput](Sagara.FeedReader.Feeds.FeedTextInput.md 'Sagara.FeedReader.Feeds.FeedTextInput')
### Methods

<a name='Sagara.FeedReader.Feeds.Rss10Feed.ToFeed()'></a>

## Rss10Feed.ToFeed() Method

Creates the base [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') element out of this feed.

```csharp
public override Sagara.FeedReader.Feed ToFeed();
```

#### Returns
[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')  
feed