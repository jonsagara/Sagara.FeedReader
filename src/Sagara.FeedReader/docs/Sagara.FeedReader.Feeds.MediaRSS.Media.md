#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds.MediaRSS](index.md#Sagara.FeedReader.Feeds.MediaRSS 'Sagara.FeedReader.Feeds.MediaRSS')

## Media Class

Media object

```csharp
public class Media
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Media
### Constructors

<a name='Sagara.FeedReader.Feeds.MediaRSS.Media.Media(System.Xml.Linq.XElement)'></a>

## Media(XElement) Constructor

Initializes a new instance of the [Media](Sagara.FeedReader.Feeds.MediaRSS.Media.md 'Sagara.FeedReader.Feeds.MediaRSS.Media') class.  
Reads a rss feed item enclosure based on the xml given in element

```csharp
public Media(System.Xml.Linq.XElement element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.MediaRSS.Media.Media(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

enclosure element as xml
### Properties

<a name='Sagara.FeedReader.Feeds.MediaRSS.Media.Duration'></a>

## Media.Duration Property

Number of seconds the media object plays. Optional attribute

```csharp
public System.Nullable<int> Duration { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.MediaRSS.Media.Element'></a>

## Media.Element Property

Gets the underlying XElement in order to allow reading properties that are not available in the class itself

```csharp
public System.Xml.Linq.XElement Element { get; }
```

#### Property Value
[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

<a name='Sagara.FeedReader.Feeds.MediaRSS.Media.FileSize'></a>

## Media.FileSize Property

Number of bytes of the media object. Optional attribute

```csharp
public System.Nullable<long> FileSize { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.MediaRSS.Media.Height'></a>

## Media.Height Property

Height of the object media. Optional attribute

```csharp
public System.Nullable<int> Height { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.MediaRSS.Media.isDefault'></a>

## Media.isDefault Property

Determines if this is the default object that should be used for the [MediaGroup](Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.md 'Sagara.FeedReader.Feeds.MediaRSS.MediaGroup')

```csharp
public System.Nullable<bool> isDefault { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.MediaRSS.Media.Language'></a>

## Media.Language Property

The primary language encapsulated in the media object. Language codes possible are detailed in RFC 3066. This attribute is used similar to the xml:lang attribute detailed in the XML 1.0 Specification (Third Edition). It is an optional attribute.

```csharp
public string? Language { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRSS.Media.Medium'></a>

## Media.Medium Property

Type of object. Optional attribute

```csharp
public Sagara.FeedReader.Feeds.MediaRSS.Medium Medium { get; set; }
```

#### Property Value
[Medium](Sagara.FeedReader.Feeds.MediaRSS.Medium.md 'Sagara.FeedReader.Feeds.MediaRSS.Medium')

<a name='Sagara.FeedReader.Feeds.MediaRSS.Media.Thumbnails'></a>

## Media.Thumbnails Property

Representative images for the media object

```csharp
public System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.Feeds.MediaRSS.Thumbnail> Thumbnails { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[Thumbnail](Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.md 'Sagara.FeedReader.Feeds.MediaRSS.Thumbnail')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.MediaRSS.Media.Type'></a>

## Media.Type Property

Standard MIME type of the object. Optional attribute

```csharp
public string? Type { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRSS.Media.Url'></a>

## Media.Url Property

The direct URL to the media object

```csharp
public string? Url { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRSS.Media.Width'></a>

## Media.Width Property

Width of the object media. Optional attribute

```csharp
public System.Nullable<int> Width { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')