#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds.MediaRSS](index.md#Sagara.FeedReader.Feeds.MediaRSS 'Sagara.FeedReader.Feeds.MediaRSS')

## MediaGroup Class

A collection of media that are effectively the same content, yet different representations. For isntance: the same song recorded in both WAV and MP3 format.

```csharp
public class MediaGroup
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; MediaGroup
### Constructors

<a name='Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.MediaGroup(System.Xml.Linq.XElement)'></a>

## MediaGroup(XElement) Constructor

Initializes a new instance of the [MediaGroup](Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.md 'Sagara.FeedReader.Feeds.MediaRSS.MediaGroup') class.  
Reads a rss media group item enclosure based on the xml given in element

```csharp
public MediaGroup(System.Xml.Linq.XElement element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.MediaGroup(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

enclosure element as xml
### Properties

<a name='Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.Element'></a>

## MediaGroup.Element Property

Gets the underlying XElement in order to allow reading properties that are not available in the class itself

```csharp
public System.Xml.Linq.XElement Element { get; }
```

#### Property Value
[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

<a name='Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.Media'></a>

## MediaGroup.Media Property

Media object

```csharp
public System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.Feeds.MediaRSS.Media> Media { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[Media](Sagara.FeedReader.Feeds.MediaRSS.Media.md 'Sagara.FeedReader.Feeds.MediaRSS.Media')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')