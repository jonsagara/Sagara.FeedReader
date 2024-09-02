#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Modules.ApplePodcasts](index.md#Sagara.FeedReader.Modules.ApplePodcasts 'Sagara.FeedReader.Modules.ApplePodcasts')

## iTunesExtensions Class

Extension methods that further parse the feed XML for iTunes-specific content.

```csharp
public static class iTunesExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; iTunesExtensions
### Methods

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesExtensions.GetiTunesChannel(thisSagara.FeedReader.Feed)'></a>

## iTunesExtensions.GetiTunesChannel(this Feed) Method

Reads Apple Podcast show elements from a `channel` (RSS 2.0) or `feed` (Atom) element.

```csharp
public static Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel GetiTunesChannel(this Sagara.FeedReader.Feed feed);
```
#### Parameters

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesExtensions.GetiTunesChannel(thisSagara.FeedReader.Feed).feed'></a>

`feed` [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')

The parsed RSS 2.0 or Atom [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed').

#### Returns
[iTunesChannel](Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesExtensions.GetiTunesItem(thisSagara.FeedReader.FeedItem)'></a>

## iTunesExtensions.GetiTunesItem(this FeedItem) Method

Reads Apple Podcast episode elements content from a `item` (RSS 2.0) or `entry` (Atom) element.

```csharp
public static Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem GetiTunesItem(this Sagara.FeedReader.FeedItem item);
```
#### Parameters

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesExtensions.GetiTunesItem(thisSagara.FeedReader.FeedItem).item'></a>

`item` [FeedItem](Sagara.FeedReader.FeedItem.md 'Sagara.FeedReader.FeedItem')

The parsed RSS 2.0 or Atom [FeedItem](Sagara.FeedReader.FeedItem.md 'Sagara.FeedReader.FeedItem').

#### Returns
[iTunesItem](Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem')