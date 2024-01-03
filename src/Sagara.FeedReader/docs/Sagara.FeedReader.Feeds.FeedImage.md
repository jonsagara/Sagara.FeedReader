#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## FeedImage Class

feed image object that is used in feed (rss 0.91, 2.0, atom, ...)

```csharp
public class FeedImage
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedImage

Derived  
&#8627; [Rss091FeedImage](Sagara.FeedReader.Feeds.Rss091FeedImage.md 'Sagara.FeedReader.Feeds.Rss091FeedImage')  
&#8627; [Rss10FeedImage](Sagara.FeedReader.Feeds.Rss10FeedImage.md 'Sagara.FeedReader.Feeds.Rss10FeedImage')
### Constructors

<a name='Sagara.FeedReader.Feeds.FeedImage.FeedImage()'></a>

## FeedImage() Constructor

Initializes a new instance of the [FeedImage](Sagara.FeedReader.Feeds.FeedImage.md 'Sagara.FeedReader.Feeds.FeedImage') class.  
default constructor (for serialization)

```csharp
public FeedImage();
```

<a name='Sagara.FeedReader.Feeds.FeedImage.FeedImage(System.Xml.Linq.XElement)'></a>

## FeedImage(XElement) Constructor

Initializes a new instance of the [FeedImage](Sagara.FeedReader.Feeds.FeedImage.md 'Sagara.FeedReader.Feeds.FeedImage') class.  
Reads a feed image based on the xml given in element

```csharp
public FeedImage(System.Xml.Linq.XElement? element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.FeedImage.FeedImage(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

feed image as xml
### Properties

<a name='Sagara.FeedReader.Feeds.FeedImage.Link'></a>

## FeedImage.Link Property

The "link" element

```csharp
public string? Link { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.FeedImage.Title'></a>

## FeedImage.Title Property

The "title" element

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.FeedImage.Url'></a>

## FeedImage.Url Property

The "url" element

```csharp
public string? Url { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')