#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## MediaRssFeedImage Class

Rss 2.0 Image according to specification: https://validator.w3.org/feed/docs/rss2.html#ltimagegtSubelementOfLtchannelgt

```csharp
public class MediaRssFeedImage : Sagara.FeedReader.Feeds.Rss091FeedImage
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [FeedImage](Sagara.FeedReader.Feeds.FeedImage.md 'Sagara.FeedReader.Feeds.FeedImage') &#129106; [Rss091FeedImage](Sagara.FeedReader.Feeds.Rss091FeedImage.md 'Sagara.FeedReader.Feeds.Rss091FeedImage') &#129106; MediaRssFeedImage
### Constructors

<a name='Sagara.FeedReader.Feeds.MediaRssFeedImage.MediaRssFeedImage()'></a>

## MediaRssFeedImage() Constructor

Initializes a new instance of the [MediaRssFeedImage](Sagara.FeedReader.Feeds.MediaRssFeedImage.md 'Sagara.FeedReader.Feeds.MediaRssFeedImage') class.  
default constructor (for serialization)

```csharp
public MediaRssFeedImage();
```

<a name='Sagara.FeedReader.Feeds.MediaRssFeedImage.MediaRssFeedImage(System.Xml.Linq.XElement)'></a>

## MediaRssFeedImage(XElement) Constructor

Initializes a new instance of the [MediaRssFeedImage](Sagara.FeedReader.Feeds.MediaRssFeedImage.md 'Sagara.FeedReader.Feeds.MediaRssFeedImage') class.  
Reads a rss 2.0 feed image based on the xml given in element

```csharp
public MediaRssFeedImage(System.Xml.Linq.XElement? element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.MediaRssFeedImage.MediaRssFeedImage(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

feed image as xml