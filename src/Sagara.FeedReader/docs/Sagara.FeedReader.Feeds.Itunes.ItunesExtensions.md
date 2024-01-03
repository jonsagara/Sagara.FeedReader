#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds.Itunes](index.md#Sagara.FeedReader.Feeds.Itunes 'Sagara.FeedReader.Feeds.Itunes')

## ItunesExtensions Class

Extension method that allows to access the itunes tags for a feed

```csharp
public static class ItunesExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ItunesExtensions
### Methods

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesExtensions.GetItunesChannel(thisSagara.FeedReader.Feed)'></a>

## ItunesExtensions.GetItunesChannel(this Feed) Method

Returns the itunes elements of a rss feed

```csharp
public static Sagara.FeedReader.Feeds.Itunes.ItunesChannel GetItunesChannel(this Sagara.FeedReader.Feed feed);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesExtensions.GetItunesChannel(thisSagara.FeedReader.Feed).feed'></a>

`feed` [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')

the rss feed

#### Returns
[ItunesChannel](Sagara.FeedReader.Feeds.Itunes.ItunesChannel.md 'Sagara.FeedReader.Feeds.Itunes.ItunesChannel')  
ItunesChannel object which contains itunes:... properties

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesExtensions.GetItunesItem(thisSagara.FeedReader.FeedItem)'></a>

## ItunesExtensions.GetItunesItem(this FeedItem) Method

Returns the itunes element of a rss feeditem

```csharp
public static Sagara.FeedReader.Feeds.Itunes.ItunesItem GetItunesItem(this Sagara.FeedReader.FeedItem item);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.Itunes.ItunesExtensions.GetItunesItem(thisSagara.FeedReader.FeedItem).item'></a>

`item` [FeedItem](Sagara.FeedReader.FeedItem.md 'Sagara.FeedReader.FeedItem')

the rss feed item

#### Returns
[ItunesItem](Sagara.FeedReader.Feeds.Itunes.ItunesItem.md 'Sagara.FeedReader.Feeds.Itunes.ItunesItem')  
ItunesItem object which contains itunes:... properties