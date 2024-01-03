#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds.Itunes](index.md#Sagara.FeedReader.Feeds.Itunes 'Sagara.FeedReader.Feeds.Itunes')

## ItunesItem Class

The itunes:... elements of an rss 2.0 item

```csharp
public class ItunesItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ItunesItem
### Constructors

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesItem.ItunesItem(System.Xml.Linq.XElement)'></a>

## ItunesItem(XElement) Constructor

Initializes a new instance of the [ItunesItem](Sagara.FeedReader.Feeds.Itunes.ItunesItem.md 'Sagara.FeedReader.Feeds.Itunes.ItunesItem') class.

```csharp
public ItunesItem(System.Xml.Linq.XElement itemElement);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesItem.ItunesItem(System.Xml.Linq.XElement).itemElement'></a>

`itemElement` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')
### Properties

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesItem.Author'></a>

## ItunesItem.Author Property

The itunes:author element

```csharp
public string? Author { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesItem.Block'></a>

## ItunesItem.Block Property

The itunes:block element

```csharp
public bool Block { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesItem.Duration'></a>

## ItunesItem.Duration Property

The itunes:duration element

```csharp
public System.Nullable<System.TimeSpan> Duration { get; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesItem.Explicit'></a>

## ItunesItem.Explicit Property

The itunes:explicit element

```csharp
public bool Explicit { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesItem.Image'></a>

## ItunesItem.Image Property

The itunes:image element

```csharp
public Sagara.FeedReader.Feeds.Itunes.ItunesImage? Image { get; }
```

#### Property Value
[ItunesImage](Sagara.FeedReader.Feeds.Itunes.ItunesImage.md 'Sagara.FeedReader.Feeds.Itunes.ItunesImage')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesItem.IsClosedCaptioned'></a>

## ItunesItem.IsClosedCaptioned Property

The itunes:isClosedCaptioned element

```csharp
public bool IsClosedCaptioned { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesItem.Order'></a>

## ItunesItem.Order Property

The itunes:order element

```csharp
public int Order { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesItem.Subtitle'></a>

## ItunesItem.Subtitle Property

The itunes:subtitle element

```csharp
public string? Subtitle { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesItem.Summary'></a>

## ItunesItem.Summary Property

The itunes:summary element

```csharp
public string? Summary { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')