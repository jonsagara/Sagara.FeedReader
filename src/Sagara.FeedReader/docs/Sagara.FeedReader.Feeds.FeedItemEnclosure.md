#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## FeedItemEnclosure Class

Enclosure object of Rss 2.0 according to specification: https://validator.w3.org/feed/docs/rss2.html

```csharp
public class FeedItemEnclosure
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedItemEnclosure
### Constructors

<a name='Sagara.FeedReader.Feeds.FeedItemEnclosure.FeedItemEnclosure()'></a>

## FeedItemEnclosure() Constructor

Initializes a new instance of the [FeedItemEnclosure](Sagara.FeedReader.Feeds.FeedItemEnclosure.md 'Sagara.FeedReader.Feeds.FeedItemEnclosure') class.  
default constructor (for serialization)

```csharp
public FeedItemEnclosure();
```

<a name='Sagara.FeedReader.Feeds.FeedItemEnclosure.FeedItemEnclosure(System.Xml.Linq.XElement)'></a>

## FeedItemEnclosure(XElement) Constructor

Initializes a new instance of the [FeedItemEnclosure](Sagara.FeedReader.Feeds.FeedItemEnclosure.md 'Sagara.FeedReader.Feeds.FeedItemEnclosure') class.  
Reads a rss feed item enclosure based on the xml given in element

```csharp
public FeedItemEnclosure(System.Xml.Linq.XElement? element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.FeedItemEnclosure.FeedItemEnclosure(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

enclosure element as xml
### Properties

<a name='Sagara.FeedReader.Feeds.FeedItemEnclosure.Length'></a>

## FeedItemEnclosure.Length Property

The "length" element as int

```csharp
public System.Nullable<int> Length { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.FeedItemEnclosure.MediaType'></a>

## FeedItemEnclosure.MediaType Property

The "type" element

```csharp
public string? MediaType { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.FeedItemEnclosure.Url'></a>

## FeedItemEnclosure.Url Property

The "url" element

```csharp
public string? Url { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')