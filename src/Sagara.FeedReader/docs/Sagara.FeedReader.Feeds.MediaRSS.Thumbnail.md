#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds.MediaRSS](index.md#Sagara.FeedReader.Feeds.MediaRSS 'Sagara.FeedReader.Feeds.MediaRSS')

## Thumbnail Class

Allows particular images to be used as representative images for the media object. If multiple thumbnails are included, and time coding is not at play, it is assumed that the images are in order of importance.

```csharp
public class Thumbnail
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Thumbnail
### Constructors

<a name='Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Thumbnail(System.Xml.Linq.XElement)'></a>

## Thumbnail(XElement) Constructor

Initializes a new instance of the [Thumbnail](Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.md 'Sagara.FeedReader.Feeds.MediaRSS.Thumbnail') class.  
Reads a rss feed item enclosure based on the xml given in element

```csharp
public Thumbnail(System.Xml.Linq.XElement element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Thumbnail(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

enclosure element as xml
### Properties

<a name='Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Height'></a>

## Thumbnail.Height Property

Height of the object media. Optional attribute

```csharp
public System.Nullable<int> Height { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Time'></a>

## Thumbnail.Time Property

Specifies the time offset in relation to the media object

```csharp
public string? Time { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Url'></a>

## Thumbnail.Url Property

The url of the thumbnail. Required attribute

```csharp
public string? Url { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Width'></a>

## Thumbnail.Width Property

Width of the object media. Optional attribute

```csharp
public System.Nullable<int> Width { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')