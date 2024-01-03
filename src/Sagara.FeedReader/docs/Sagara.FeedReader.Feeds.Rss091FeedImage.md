#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss091FeedImage Class

Rss 0.91 Feed Image according to specification: http://www.rssboard.org/rss-0-9-1-netscape#image

```csharp
public class Rss091FeedImage : Sagara.FeedReader.Feeds.FeedImage
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [FeedImage](Sagara.FeedReader.Feeds.FeedImage.md 'Sagara.FeedReader.Feeds.FeedImage') &#129106; Rss091FeedImage

Derived  
&#8627; [MediaRssFeedImage](Sagara.FeedReader.Feeds.MediaRssFeedImage.md 'Sagara.FeedReader.Feeds.MediaRssFeedImage')  
&#8627; [Rss092FeedImage](Sagara.FeedReader.Feeds.Rss092FeedImage.md 'Sagara.FeedReader.Feeds.Rss092FeedImage')  
&#8627; [Rss20FeedImage](Sagara.FeedReader.Feeds.Rss20FeedImage.md 'Sagara.FeedReader.Feeds.Rss20FeedImage')
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss091FeedImage.Rss091FeedImage()'></a>

## Rss091FeedImage() Constructor

Initializes a new instance of the [Rss091FeedImage](Sagara.FeedReader.Feeds.Rss091FeedImage.md 'Sagara.FeedReader.Feeds.Rss091FeedImage') class.  
default constructor (for serialization)

```csharp
public Rss091FeedImage();
```

<a name='Sagara.FeedReader.Feeds.Rss091FeedImage.Rss091FeedImage(System.Xml.Linq.XElement)'></a>

## Rss091FeedImage(XElement) Constructor

Initializes a new instance of the [Rss091FeedImage](Sagara.FeedReader.Feeds.Rss091FeedImage.md 'Sagara.FeedReader.Feeds.Rss091FeedImage') class.  
Creates this object based on the xml in the XElement parameter.

```csharp
public Rss091FeedImage(System.Xml.Linq.XElement? element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss091FeedImage.Rss091FeedImage(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

feed image as xml
### Properties

<a name='Sagara.FeedReader.Feeds.Rss091FeedImage.Description'></a>

## Rss091FeedImage.Description Property

The "description" element

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss091FeedImage.Height'></a>

## Rss091FeedImage.Height Property

The "height" element

```csharp
public System.Nullable<int> Height { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.Rss091FeedImage.Width'></a>

## Rss091FeedImage.Width Property

The "width" element

```csharp
public System.Nullable<int> Width { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')