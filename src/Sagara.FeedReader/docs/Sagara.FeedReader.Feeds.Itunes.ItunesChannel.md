#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds.Itunes](index.md#Sagara.FeedReader.Feeds.Itunes 'Sagara.FeedReader.Feeds.Itunes')

## ItunesChannel Class

The basic itunes: elements that are part of the channel xml element of an rss2.0 feed

```csharp
public class ItunesChannel
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ItunesChannel
### Constructors

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.ItunesChannel(System.Xml.Linq.XElement)'></a>

## ItunesChannel(XElement) Constructor

Initializes a new instance of the [ItunesChannel](Sagara.FeedReader.Feeds.Itunes.ItunesChannel.md 'Sagara.FeedReader.Feeds.Itunes.ItunesChannel') class.

```csharp
public ItunesChannel(System.Xml.Linq.XElement channelElement);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.ItunesChannel(System.Xml.Linq.XElement).channelElement'></a>

`channelElement` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')
### Properties

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.Author'></a>

## ItunesChannel.Author Property

The itunes:author element

```csharp
public string? Author { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.Block'></a>

## ItunesChannel.Block Property

The itunes:block element

```csharp
public bool Block { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.Categories'></a>

## ItunesChannel.Categories Property

The itunes:category elements

```csharp
public System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.Feeds.Itunes.ItunesCategory> Categories { get; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[ItunesCategory](Sagara.FeedReader.Feeds.Itunes.ItunesCategory.md 'Sagara.FeedReader.Feeds.Itunes.ItunesCategory')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.Complete'></a>

## ItunesChannel.Complete Property

The itunes:complete element

```csharp
public bool Complete { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.Explicit'></a>

## ItunesChannel.Explicit Property

The itunes:explicit element

```csharp
public bool Explicit { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.Image'></a>

## ItunesChannel.Image Property

The itunes:image element

```csharp
public Sagara.FeedReader.Feeds.Itunes.ItunesImage? Image { get; }
```

#### Property Value
[ItunesImage](Sagara.FeedReader.Feeds.Itunes.ItunesImage.md 'Sagara.FeedReader.Feeds.Itunes.ItunesImage')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.NewFeedUrl'></a>

## ItunesChannel.NewFeedUrl Property

The itunes:new-feed-url element

```csharp
public System.Uri? NewFeedUrl { get; }
```

#### Property Value
[System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.Owner'></a>

## ItunesChannel.Owner Property

The itunes:owner element

```csharp
public Sagara.FeedReader.Feeds.Itunes.ItunesOwner? Owner { get; }
```

#### Property Value
[ItunesOwner](Sagara.FeedReader.Feeds.Itunes.ItunesOwner.md 'Sagara.FeedReader.Feeds.Itunes.ItunesOwner')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.Subtitle'></a>

## ItunesChannel.Subtitle Property

The itunes:subtitle element

```csharp
public string? Subtitle { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.Summary'></a>

## ItunesChannel.Summary Property

The itunes:summary element

```csharp
public string? Summary { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.GetItunesCategories(System.Xml.Linq.XElement)'></a>

## ItunesChannel.GetItunesCategories(XElement) Method

Sets the itunes categories

```csharp
private static Sagara.FeedReader.Feeds.Itunes.ItunesCategory[] GetItunesCategories(System.Xml.Linq.XElement element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesChannel.GetItunesCategories(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the channel element

#### Returns
[ItunesCategory](Sagara.FeedReader.Feeds.Itunes.ItunesCategory.md 'Sagara.FeedReader.Feeds.Itunes.ItunesCategory')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
the itunes:categries