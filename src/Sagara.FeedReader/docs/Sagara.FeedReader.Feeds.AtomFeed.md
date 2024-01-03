#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## AtomFeed Class

Atom 1.0 feed object according to specification: https://validator.w3.org/feed/docs/atom.html

```csharp
public class AtomFeed : Sagara.FeedReader.Feeds.BaseFeed
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeed](Sagara.FeedReader.Feeds.BaseFeed.md 'Sagara.FeedReader.Feeds.BaseFeed') &#129106; AtomFeed
### Constructors

<a name='Sagara.FeedReader.Feeds.AtomFeed.AtomFeed()'></a>

## AtomFeed() Constructor

Initializes a new instance of the [AtomFeed](Sagara.FeedReader.Feeds.AtomFeed.md 'Sagara.FeedReader.Feeds.AtomFeed') class.  
default constructor (for serialization)

```csharp
public AtomFeed();
```

<a name='Sagara.FeedReader.Feeds.AtomFeed.AtomFeed(string,System.Xml.Linq.XElement)'></a>

## AtomFeed(string, XElement) Constructor

Initializes a new instance of the [AtomFeed](Sagara.FeedReader.Feeds.AtomFeed.md 'Sagara.FeedReader.Feeds.AtomFeed') class.  
Reads an atom feed based on the xml given in channel

```csharp
public AtomFeed(string feedXml, System.Xml.Linq.XElement feed);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.AtomFeed.AtomFeed(string,System.Xml.Linq.XElement).feedXml'></a>

`feedXml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the entire feed xml as string

<a name='Sagara.FeedReader.Feeds.AtomFeed.AtomFeed(string,System.Xml.Linq.XElement).feed'></a>

`feed` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the feed element in the xml as XElement
### Properties

<a name='Sagara.FeedReader.Feeds.AtomFeed.Author'></a>

## AtomFeed.Author Property

The "author" element

```csharp
public Sagara.FeedReader.Feeds.AtomPerson? Author { get; set; }
```

#### Property Value
[AtomPerson](Sagara.FeedReader.Feeds.AtomPerson.md 'Sagara.FeedReader.Feeds.AtomPerson')

<a name='Sagara.FeedReader.Feeds.AtomFeed.Categories'></a>

## AtomFeed.Categories Property

All "category" elements

```csharp
public System.Collections.Generic.IReadOnlyCollection<string> Categories { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.AtomFeed.Contributor'></a>

## AtomFeed.Contributor Property

The "contributor" element

```csharp
public Sagara.FeedReader.Feeds.AtomPerson? Contributor { get; set; }
```

#### Property Value
[AtomPerson](Sagara.FeedReader.Feeds.AtomPerson.md 'Sagara.FeedReader.Feeds.AtomPerson')

<a name='Sagara.FeedReader.Feeds.AtomFeed.Generator'></a>

## AtomFeed.Generator Property

The "generator" element

```csharp
public string? Generator { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeed.Icon'></a>

## AtomFeed.Icon Property

The "icon" element

```csharp
public string? Icon { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeed.Id'></a>

## AtomFeed.Id Property

The "id" element

```csharp
public string? Id { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeed.Links'></a>

## AtomFeed.Links Property

All "link" elements

```csharp
public System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.Feeds.AtomLink> Links { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[AtomLink](Sagara.FeedReader.Feeds.AtomLink.md 'Sagara.FeedReader.Feeds.AtomLink')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.AtomFeed.Logo'></a>

## AtomFeed.Logo Property

The "logo" element

```csharp
public string? Logo { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeed.Rights'></a>

## AtomFeed.Rights Property

The "rights" element

```csharp
public string? Rights { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeed.Subtitle'></a>

## AtomFeed.Subtitle Property

The "subtitle" element

```csharp
public string? Subtitle { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeed.UpdatedDate'></a>

## AtomFeed.UpdatedDate Property

The "updated" element as DateTime. Null if parsing failed of updatedDate is empty.

```csharp
public System.Nullable<System.DateTime> UpdatedDate { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.AtomFeed.UpdatedDateString'></a>

## AtomFeed.UpdatedDateString Property

The "updated" element as string

```csharp
public string? UpdatedDateString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='Sagara.FeedReader.Feeds.AtomFeed.ToFeed()'></a>

## AtomFeed.ToFeed() Method

Creates the base [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') element out of this feed.

```csharp
public override Sagara.FeedReader.Feed ToFeed();
```

#### Returns
[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')  
feed