#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss10FeedTextInput Class

Rss 1.0 Feed textinput according to specification: http://web.resource.org/rss/1.0/spec

```csharp
public class Rss10FeedTextInput : Sagara.FeedReader.Feeds.FeedTextInput
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [FeedTextInput](Sagara.FeedReader.Feeds.FeedTextInput.md 'Sagara.FeedReader.Feeds.FeedTextInput') &#129106; Rss10FeedTextInput
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss10FeedTextInput.Rss10FeedTextInput()'></a>

## Rss10FeedTextInput() Constructor

Initializes a new instance of the [Rss10FeedTextInput](Sagara.FeedReader.Feeds.Rss10FeedTextInput.md 'Sagara.FeedReader.Feeds.Rss10FeedTextInput') class.  
default constructor (for serialization)

```csharp
public Rss10FeedTextInput();
```

<a name='Sagara.FeedReader.Feeds.Rss10FeedTextInput.Rss10FeedTextInput(System.Xml.Linq.XElement)'></a>

## Rss10FeedTextInput(XElement) Constructor

Initializes a new instance of the [Rss10FeedTextInput](Sagara.FeedReader.Feeds.Rss10FeedTextInput.md 'Sagara.FeedReader.Feeds.Rss10FeedTextInput') class.  
Reads a rss 1.0 textInput element based on the xml given in item

```csharp
public Rss10FeedTextInput(System.Xml.Linq.XElement? element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Rss10FeedTextInput.Rss10FeedTextInput(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

about element as xml
### Properties

<a name='Sagara.FeedReader.Feeds.Rss10FeedTextInput.About'></a>

## Rss10FeedTextInput.About Property

The "about" attribute of the element

```csharp
public string? About { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')