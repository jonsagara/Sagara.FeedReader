#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## FeedTextInput Class

default text input object for Rss 0.91, 0.92, 1.0, 2.0 and ATOM

```csharp
public class FeedTextInput
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedTextInput

Derived  
&#8627; [Rss10FeedTextInput](Sagara.FeedReader.Feeds.Rss10FeedTextInput.md 'Sagara.FeedReader.Feeds.Rss10FeedTextInput')
### Constructors

<a name='Sagara.FeedReader.Feeds.FeedTextInput.FeedTextInput()'></a>

## FeedTextInput() Constructor

Initializes a new instance of the [FeedTextInput](Sagara.FeedReader.Feeds.FeedTextInput.md 'Sagara.FeedReader.Feeds.FeedTextInput') class.  
default constructor (for serialization)

```csharp
public FeedTextInput();
```

<a name='Sagara.FeedReader.Feeds.FeedTextInput.FeedTextInput(System.Xml.Linq.XElement)'></a>

## FeedTextInput(XElement) Constructor

Initializes a new instance of the [FeedTextInput](Sagara.FeedReader.Feeds.FeedTextInput.md 'Sagara.FeedReader.Feeds.FeedTextInput') class.  
Reads a rss textInput element based on the xml given in element

```csharp
public FeedTextInput(System.Xml.Linq.XElement? element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.FeedTextInput.FeedTextInput(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

text input element as xml
### Properties

<a name='Sagara.FeedReader.Feeds.FeedTextInput.Description'></a>

## FeedTextInput.Description Property

The "description" field

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.FeedTextInput.Link'></a>

## FeedTextInput.Link Property

The "link" element

```csharp
public string? Link { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.FeedTextInput.Name'></a>

## FeedTextInput.Name Property

The "name" element

```csharp
public string? Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.FeedTextInput.Title'></a>

## FeedTextInput.Title Property

The "title" element

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')