#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Modules.ApplePodcasts](index.md#Sagara.FeedReader.Modules.ApplePodcasts 'Sagara.FeedReader.Modules.ApplePodcasts')

## iTunesItem Class

  
Item data from an iTunes channel in either RSS 2.0 or Atom.  
  
In RSS 2.0, this is direct child elements of the `channel` element, each within the `itunes` namespace.  
  
In Atom, this is direct child elements of the `feed` element, each within the `im` namespace.

```csharp
public class iTunesItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; iTunesItem

### Remarks
  
See this article for RSS 2.0 requirements: https://help.apple.com/itc/podcasts_connect/#/itcb54353390  
  
Apple no longer accepts Atom feeds for podcasts, so I don't see `im` documented anywhere.
### Constructors

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.iTunesItem(System.Xml.Linq.XElement)'></a>

## iTunesItem(XElement) Constructor

.ctor

```csharp
public iTunesItem(System.Xml.Linq.XElement itemElement);
```
#### Parameters

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.iTunesItem(System.Xml.Linq.XElement).itemElement'></a>

`itemElement` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')
### Properties

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Block'></a>

## iTunesItem.Block Property

  
The episode show or hide status.  
  
If you want an episode removed from the Apple directory, use this tag.  
  
Specifying the <itunes:block> tag with a Yes value prevents that episode from appearing in Apple Podcasts.  
  
Specifying any value other than `Yes` has no effect.

```csharp
public bool Block { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Duration'></a>

## iTunesItem.Duration Property

  
The duration of an episode.  
  
Different duration formats are accepted however it is recommended to convert the length of the episode into seconds.

```csharp
public System.Nullable<System.TimeSpan> Duration { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Episode'></a>

## iTunesItem.Episode Property

  
An episode number.  
  
If all your episodes have numbers and you would like them to be ordered based on them, use this tag for each one.  
  
Episode numbers are optional for <itunes:type> episodic shows, but are mandatory for serial shows.  
  
Where `episode` is a non-zero integer (1, 2, 3, etc.) representing your episode number.

```csharp
public System.Nullable<int> Episode { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.EpisodeType'></a>

## iTunesItem.EpisodeType Property

  
The episode type.  
  
If an episode is a trailer or bonus content, use this tag.  
  
Where the `episodeType` value can be one of the following:  
- Full — Default. Specify full when you are submitting the complete content of your show.  
- Trailer — Specify trailer when you are submitting a short, promotional piece of content that represents a preview of your   
              current show.  
- Bonus — Specify bonus when you are submitting extra content for your show (for example, behind the scenes information   
              or interviews with the cast) or cross-promotional content for another show.

```csharp
public System.Nullable<Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType> EpisodeType { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[iTunesEpisodeType](Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Explicit'></a>

## iTunesItem.Explicit Property

  
The episode parental advisory information.  
  
`true` indicates the presence of explicit content.  
  
`false` indicates that the media doesn't contain explicit language or adult content.

```csharp
public bool Explicit { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Image'></a>

## iTunesItem.Image Property

  
The episode artwork specified as a URL linking to it.  
  
You should use this tag when you have a high quality, episode-specific image you would like listeners to see.

```csharp
public Sagara.FeedReader.Modules.ApplePodcasts.iTunesImage? Image { get; set; }
```

#### Property Value
[iTunesImage](Sagara.FeedReader.Modules.ApplePodcasts.iTunesImage.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesImage')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Season'></a>

## iTunesItem.Season Property

  
The episode season number.  
  
If an episode is within a season use this tag.  
  
Where `season` is a non-zero integer (1, 2, 3, etc.) representing your season number.

```csharp
public System.Nullable<int> Season { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Title'></a>

## iTunesItem.Title Property

The episode title specific for Apple Podcasts.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')