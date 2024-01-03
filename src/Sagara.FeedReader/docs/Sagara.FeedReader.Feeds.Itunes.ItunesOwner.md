#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds.Itunes](index.md#Sagara.FeedReader.Feeds.Itunes 'Sagara.FeedReader.Feeds.Itunes')

## ItunesOwner Class

The itunes:owner xml element

```csharp
public class ItunesOwner
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ItunesOwner
### Constructors

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesOwner.ItunesOwner(System.Xml.Linq.XElement)'></a>

## ItunesOwner(XElement) Constructor

Initializes a new instance of the [ItunesOwner](Sagara.FeedReader.Feeds.Itunes.ItunesOwner.md 'Sagara.FeedReader.Feeds.Itunes.ItunesOwner') class.

```csharp
public ItunesOwner(System.Xml.Linq.XElement ownerElement);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesOwner.ItunesOwner(System.Xml.Linq.XElement).ownerElement'></a>

`ownerElement` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the owner xml element
### Properties

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesOwner.Email'></a>

## ItunesOwner.Email Property

The itunes:email of the owner

```csharp
public string? Email { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesOwner.Name'></a>

## ItunesOwner.Name Property

The itunes:name of the owner

```csharp
public string? Name { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')