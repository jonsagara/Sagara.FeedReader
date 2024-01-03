#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds.Itunes](index.md#Sagara.FeedReader.Feeds.Itunes 'Sagara.FeedReader.Feeds.Itunes')

## ItunesCategory Class

The itunes:category element

```csharp
public class ItunesCategory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ItunesCategory
### Constructors

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesCategory.ItunesCategory(string,Sagara.FeedReader.Feeds.Itunes.ItunesCategory[])'></a>

## ItunesCategory(string, ItunesCategory[]) Constructor

Initializes a new instance of the [ItunesCategory](Sagara.FeedReader.Feeds.Itunes.ItunesCategory.md 'Sagara.FeedReader.Feeds.Itunes.ItunesCategory') class.  
itunes:category element

```csharp
internal ItunesCategory(string? text, Sagara.FeedReader.Feeds.Itunes.ItunesCategory[] children);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesCategory.ItunesCategory(string,Sagara.FeedReader.Feeds.Itunes.ItunesCategory[]).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesCategory.ItunesCategory(string,Sagara.FeedReader.Feeds.Itunes.ItunesCategory[]).children'></a>

`children` [ItunesCategory](Sagara.FeedReader.Feeds.Itunes.ItunesCategory.md 'Sagara.FeedReader.Feeds.Itunes.ItunesCategory')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')
### Properties

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesCategory.Children'></a>

## ItunesCategory.Children Property

All child itunes:category elements

```csharp
public System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.Feeds.Itunes.ItunesCategory> Children { get; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[ItunesCategory](Sagara.FeedReader.Feeds.Itunes.ItunesCategory.md 'Sagara.FeedReader.Feeds.Itunes.ItunesCategory')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesCategory.Text'></a>

## ItunesCategory.Text Property

The text attribute

```csharp
public string? Text { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')