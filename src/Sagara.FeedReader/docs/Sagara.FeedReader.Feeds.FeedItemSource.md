#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## FeedItemSource Class

item source object from rss 2.0 according to specification: https://validator.w3.org/feed/docs/rss2.html

```csharp
public class FeedItemSource
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedItemSource
### Constructors

<a name='Sagara.FeedReader.Feeds.FeedItemSource.FeedItemSource()'></a>

## FeedItemSource() Constructor

Initializes a new instance of the [FeedItemSource](Sagara.FeedReader.Feeds.FeedItemSource.md 'Sagara.FeedReader.Feeds.FeedItemSource') class.  
default constructor (for serialization)

```csharp
public FeedItemSource();
```

<a name='Sagara.FeedReader.Feeds.FeedItemSource.FeedItemSource(System.Xml.Linq.XElement)'></a>

## FeedItemSource(XElement) Constructor

Initializes a new instance of the [FeedItemSource](Sagara.FeedReader.Feeds.FeedItemSource.md 'Sagara.FeedReader.Feeds.FeedItemSource') class.  
Reads a rss feed item based on the xml given in element

```csharp
public FeedItemSource(System.Xml.Linq.XElement? element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.FeedItemSource.FeedItemSource(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

item source element as xml
### Properties

<a name='Sagara.FeedReader.Feeds.FeedItemSource.Url'></a>

## FeedItemSource.Url Property

The "url" element

```csharp
public string? Url { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.FeedItemSource.Value'></a>

## FeedItemSource.Value Property

The value of the element

```csharp
public string? Value { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')