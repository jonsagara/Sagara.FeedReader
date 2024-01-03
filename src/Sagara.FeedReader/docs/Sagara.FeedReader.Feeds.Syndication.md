#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Syndication Class

The parsed syndication elements. Those are all elements that start with "sy:"

```csharp
public class Syndication
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Syndication
### Constructors

<a name='Sagara.FeedReader.Feeds.Syndication.Syndication()'></a>

## Syndication() Constructor

Initializes a new instance of the [Syndication](Sagara.FeedReader.Feeds.Syndication.md 'Sagara.FeedReader.Feeds.Syndication') class.  
default constructor (for serialization)

```csharp
public Syndication();
```

<a name='Sagara.FeedReader.Feeds.Syndication.Syndication(System.Xml.Linq.XElement)'></a>

## Syndication(XElement) Constructor

Initializes a new instance of the [Syndication](Sagara.FeedReader.Feeds.Syndication.md 'Sagara.FeedReader.Feeds.Syndication') class.  
Creates the object based on the xml in the given XElement

```csharp
public Syndication(System.Xml.Linq.XElement xelement);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Syndication.Syndication(System.Xml.Linq.XElement).xelement'></a>

`xelement` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

syndication element as xml
### Properties

<a name='Sagara.FeedReader.Feeds.Syndication.UpdateBase'></a>

## Syndication.UpdateBase Property

The "updateBase" element

```csharp
public string? UpdateBase { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Syndication.UpdateFrequency'></a>

## Syndication.UpdateFrequency Property

The "updateFrequency" element

```csharp
public string? UpdateFrequency { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Syndication.UpdatePeriod'></a>

## Syndication.UpdatePeriod Property

The "updatePeriod" element

```csharp
public string? UpdatePeriod { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')