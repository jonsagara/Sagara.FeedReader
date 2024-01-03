#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## DublinCore Class

The parsed "dc:" elements in a feed

```csharp
public class DublinCore
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DublinCore
### Constructors

<a name='Sagara.FeedReader.Feeds.DublinCore.DublinCore()'></a>

## DublinCore() Constructor

Initializes a new instance of the [DublinCore](Sagara.FeedReader.Feeds.DublinCore.md 'Sagara.FeedReader.Feeds.DublinCore') class.  
default constructor (for serialization)

```csharp
public DublinCore();
```

<a name='Sagara.FeedReader.Feeds.DublinCore.DublinCore(System.Xml.Linq.XElement)'></a>

## DublinCore(XElement) Constructor

Initializes a new instance of the [DublinCore](Sagara.FeedReader.Feeds.DublinCore.md 'Sagara.FeedReader.Feeds.DublinCore') class.  
Reads a dublincore (dc:) element based on the xml given in element

```csharp
public DublinCore(System.Xml.Linq.XElement item);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.DublinCore.DublinCore(System.Xml.Linq.XElement).item'></a>

`item` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

item element as xml
### Properties

<a name='Sagara.FeedReader.Feeds.DublinCore.Contributor'></a>

## DublinCore.Contributor Property

The "contributor" element

```csharp
public string? Contributor { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Coverage'></a>

## DublinCore.Coverage Property

The "coverage" element

```csharp
public string? Coverage { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Creator'></a>

## DublinCore.Creator Property

The "creator" element

```csharp
public string? Creator { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Date'></a>

## DublinCore.Date Property

The "date" element as datetime. Null if parsing failed or date is empty.

```csharp
public System.Nullable<System.DateTime> Date { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.DublinCore.DateString'></a>

## DublinCore.DateString Property

The "date" element

```csharp
public string? DateString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Description'></a>

## DublinCore.Description Property

The "description" field

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Format'></a>

## DublinCore.Format Property

The "format" element

```csharp
public string? Format { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Identifier'></a>

## DublinCore.Identifier Property

The "identifier" element

```csharp
public string? Identifier { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Language'></a>

## DublinCore.Language Property

The "language" element

```csharp
public string? Language { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Publisher'></a>

## DublinCore.Publisher Property

The "publisher" element

```csharp
public string? Publisher { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Relation'></a>

## DublinCore.Relation Property

The "rel" element

```csharp
public string? Relation { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Rights'></a>

## DublinCore.Rights Property

The "rights" element

```csharp
public string? Rights { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Source'></a>

## DublinCore.Source Property

The "source" element

```csharp
public string? Source { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Subject'></a>

## DublinCore.Subject Property

The "subject" element

```csharp
public string? Subject { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Title'></a>

## DublinCore.Title Property

The "title" element

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.DublinCore.Type'></a>

## DublinCore.Type Property

The "type" element

```csharp
public string? Type { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')