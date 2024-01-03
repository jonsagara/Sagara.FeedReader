#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## AtomFeedItem Class

Atom 1.0 feed item object according to specification: https://validator.w3.org/feed/docs/atom.html

```csharp
public class AtomFeedItem : Sagara.FeedReader.Feeds.BaseFeedItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem') &#129106; AtomFeedItem
### Constructors

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.AtomFeedItem()'></a>

## AtomFeedItem() Constructor

Initializes a new instance of the [AtomFeedItem](Sagara.FeedReader.Feeds.AtomFeedItem.md 'Sagara.FeedReader.Feeds.AtomFeedItem') class.  
default constructor (for serialization)

```csharp
public AtomFeedItem();
```

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.AtomFeedItem(System.Xml.Linq.XElement)'></a>

## AtomFeedItem(XElement) Constructor

Initializes a new instance of the [AtomFeedItem](Sagara.FeedReader.Feeds.AtomFeedItem.md 'Sagara.FeedReader.Feeds.AtomFeedItem') class.  
Reads an atom feed based on the xml given in item

```csharp
public AtomFeedItem(System.Xml.Linq.XElement item);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.AtomFeedItem(System.Xml.Linq.XElement).item'></a>

`item` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

feed item as xml
### Properties

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.Author'></a>

## AtomFeedItem.Author Property

The "author" element

```csharp
public Sagara.FeedReader.Feeds.AtomPerson? Author { get; set; }
```

#### Property Value
[AtomPerson](Sagara.FeedReader.Feeds.AtomPerson.md 'Sagara.FeedReader.Feeds.AtomPerson')

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.Categories'></a>

## AtomFeedItem.Categories Property

All "category" elements

```csharp
public System.Collections.Generic.IReadOnlyCollection<string> Categories { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.Content'></a>

## AtomFeedItem.Content Property

The "content" element

```csharp
public string? Content { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.Contributor'></a>

## AtomFeedItem.Contributor Property

The "contributor" element

```csharp
public Sagara.FeedReader.Feeds.AtomPerson? Contributor { get; set; }
```

#### Property Value
[AtomPerson](Sagara.FeedReader.Feeds.AtomPerson.md 'Sagara.FeedReader.Feeds.AtomPerson')

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.Id'></a>

## AtomFeedItem.Id Property

The "id" element

```csharp
public string? Id { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.Links'></a>

## AtomFeedItem.Links Property

All "link" elements

```csharp
public System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.Feeds.AtomLink> Links { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[AtomLink](Sagara.FeedReader.Feeds.AtomLink.md 'Sagara.FeedReader.Feeds.AtomLink')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.PublishedDate'></a>

## AtomFeedItem.PublishedDate Property

The "published" element as DateTime. Null if parsing failed or published is empty.

```csharp
public System.Nullable<System.DateTime> PublishedDate { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.PublishedDateString'></a>

## AtomFeedItem.PublishedDateString Property

The "published" date as string

```csharp
public string? PublishedDateString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.Rights'></a>

## AtomFeedItem.Rights Property

The "rights" element

```csharp
public string? Rights { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.Source'></a>

## AtomFeedItem.Source Property

The "source" element

```csharp
public string? Source { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.Summary'></a>

## AtomFeedItem.Summary Property

The "summary" element

```csharp
public string? Summary { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.UpdatedDate'></a>

## AtomFeedItem.UpdatedDate Property

The "updated" element as DateTime. Null if parsing failed or updated is empty

```csharp
public System.Nullable<System.DateTime> UpdatedDate { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Feeds.AtomFeedItem.UpdatedDateString'></a>

## AtomFeedItem.UpdatedDateString Property

The "updated" element

```csharp
public string? UpdatedDateString { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')