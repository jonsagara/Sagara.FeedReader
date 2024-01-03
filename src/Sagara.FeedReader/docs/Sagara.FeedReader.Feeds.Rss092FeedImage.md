#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss092FeedImage Class

Rss 0.92 Feed Image according to specification: http://backend.userland.com/rss092

```csharp
public class Rss092FeedImage : Sagara.FeedReader.Feeds.Rss091FeedImage
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [FeedImage](Sagara.FeedReader.Feeds.FeedImage.md 'Sagara.FeedReader.Feeds.FeedImage') &#129106; [Rss091FeedImage](Sagara.FeedReader.Feeds.Rss091FeedImage.md 'Sagara.FeedReader.Feeds.Rss091FeedImage') &#129106; Rss092FeedImage
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss092FeedImage.Rss092FeedImage()'></a>

## Rss092FeedImage() Constructor

Initializes a new instance of the [Rss092FeedImage](Sagara.FeedReader.Feeds.Rss092FeedImage.md 'Sagara.FeedReader.Feeds.Rss092FeedImage') class.  
default constructor (for serialization)

```csharp
public Rss092FeedImage();
```

<a name='Sagara.FeedReader.Feeds.Rss092FeedImage.Rss092FeedImage(System.Xml.Linq.XElement)'></a>

## Rss092FeedImage(XElement) Constructor

Initializes a new instance of the [Rss092FeedImage](Sagara.FeedReader.Feeds.Rss092FeedImage.md 'Sagara.FeedReader.Feeds.Rss092FeedImage') class.  
Creates this object based on the xml in the XElement parameter.

```csharp
public Rss092FeedImage(System.Xml.Linq.XElement element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss092FeedImage.Rss092FeedImage(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

rss 0.92 image as xml