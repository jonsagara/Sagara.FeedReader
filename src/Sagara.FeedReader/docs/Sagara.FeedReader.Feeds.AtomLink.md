#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## AtomLink Class

Atom 1.0 link according to specification: https://validator.w3.org/feed/docs/atom.html#link

```csharp
public class AtomLink
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AtomLink
### Constructors

<a name='Sagara.FeedReader.Feeds.AtomLink.AtomLink()'></a>

## AtomLink() Constructor

Initializes a new instance of the [AtomLink](Sagara.FeedReader.Feeds.AtomLink.md 'Sagara.FeedReader.Feeds.AtomLink') class.  
default constructor (for serialization)

```csharp
public AtomLink();
```

<a name='Sagara.FeedReader.Feeds.AtomLink.AtomLink(System.Xml.Linq.XElement)'></a>

## AtomLink(XElement) Constructor

Initializes a new instance of the [AtomLink](Sagara.FeedReader.Feeds.AtomLink.md 'Sagara.FeedReader.Feeds.AtomLink') class.  
Reads an atom link based on the xml given in element

```csharp
public AtomLink(System.Xml.Linq.XElement element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.AtomLink.AtomLink(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

link as xml
### Properties

<a name='Sagara.FeedReader.Feeds.AtomLink.Href'></a>

## AtomLink.Href Property

The "href" element

```csharp
public string? Href { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomLink.HrefLanguage'></a>

## AtomLink.HrefLanguage Property

The "hreflang" element

```csharp
public string? HrefLanguage { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomLink.Length'></a>

## AtomLink.Length Property

The "length" elemnt as int

```csharp
public System.Nullable<int> Length { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.AtomLink.LinkType'></a>

## AtomLink.LinkType Property

The "type" element

```csharp
public string? LinkType { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomLink.Relation'></a>

## AtomLink.Relation Property

The "rel" element

```csharp
public string? Relation { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomLink.Title'></a>

## AtomLink.Title Property

The "title" element

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='Sagara.FeedReader.Feeds.AtomLink.ToString()'></a>

## AtomLink.ToString() Method

Returns the Href of the link

```csharp
public override string? ToString();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
the href of the link