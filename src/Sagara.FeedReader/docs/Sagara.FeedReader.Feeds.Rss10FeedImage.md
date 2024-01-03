#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss10FeedImage Class

Rss 1.0 Feed image according to specification: http://web.resource.org/rss/1.0/spec

```csharp
public class Rss10FeedImage : Sagara.FeedReader.Feeds.FeedImage
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [FeedImage](Sagara.FeedReader.Feeds.FeedImage.md 'Sagara.FeedReader.Feeds.FeedImage') &#129106; Rss10FeedImage
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss10FeedImage.Rss10FeedImage()'></a>

## Rss10FeedImage() Constructor

Initializes a new instance of the [Rss10FeedImage](Sagara.FeedReader.Feeds.Rss10FeedImage.md 'Sagara.FeedReader.Feeds.Rss10FeedImage') class.  
default constructor (for serialization)

```csharp
public Rss10FeedImage();
```

<a name='Sagara.FeedReader.Feeds.Rss10FeedImage.Rss10FeedImage(System.Xml.Linq.XElement)'></a>

## Rss10FeedImage(XElement) Constructor

Initializes a new instance of the [Rss10FeedImage](Sagara.FeedReader.Feeds.Rss10FeedImage.md 'Sagara.FeedReader.Feeds.Rss10FeedImage') class.  
Reads a rss 1.0 feed image based on the xml given in element

```csharp
public Rss10FeedImage(System.Xml.Linq.XElement? element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss10FeedImage.Rss10FeedImage(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

feed image as xml
### Properties

<a name='Sagara.FeedReader.Feeds.Rss10FeedImage.About'></a>

## Rss10FeedImage.About Property

The "about" attribute of the element

```csharp
public string? About { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')