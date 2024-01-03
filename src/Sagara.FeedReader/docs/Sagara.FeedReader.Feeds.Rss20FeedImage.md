#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss20FeedImage Class

Rss 2.0 Image according to specification: https://validator.w3.org/feed/docs/rss2.html#ltimagegtSubelementOfLtchannelgt

```csharp
public class Rss20FeedImage : Sagara.FeedReader.Feeds.Rss091FeedImage
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [FeedImage](Sagara.FeedReader.Feeds.FeedImage.md 'Sagara.FeedReader.Feeds.FeedImage') &#129106; [Rss091FeedImage](Sagara.FeedReader.Feeds.Rss091FeedImage.md 'Sagara.FeedReader.Feeds.Rss091FeedImage') &#129106; Rss20FeedImage
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss20FeedImage.Rss20FeedImage()'></a>

## Rss20FeedImage() Constructor

Initializes a new instance of the [Rss20FeedImage](Sagara.FeedReader.Feeds.Rss20FeedImage.md 'Sagara.FeedReader.Feeds.Rss20FeedImage') class.  
default constructor (for serialization)

```csharp
public Rss20FeedImage();
```

<a name='Sagara.FeedReader.Feeds.Rss20FeedImage.Rss20FeedImage(System.Xml.Linq.XElement)'></a>

## Rss20FeedImage(XElement) Constructor

Initializes a new instance of the [Rss20FeedImage](Sagara.FeedReader.Feeds.Rss20FeedImage.md 'Sagara.FeedReader.Feeds.Rss20FeedImage') class.  
Reads a rss 2.0 feed image based on the xml given in element

```csharp
public Rss20FeedImage(System.Xml.Linq.XElement? element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss20FeedImage.Rss20FeedImage(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

feed image as xml