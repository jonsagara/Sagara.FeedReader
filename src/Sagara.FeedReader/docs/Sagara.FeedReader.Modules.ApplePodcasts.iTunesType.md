#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Modules.ApplePodcasts](index.md#Sagara.FeedReader.Modules.ApplePodcasts 'Sagara.FeedReader.Modules.ApplePodcasts')

## iTunesType Enum

Represents the value of `itunes:type`, if present.

```csharp
public enum iTunesType
```
### Fields

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.Episodic'></a>

`Episodic` 1

Default. Specify episodic when episodes are intended to be consumed without any specific order. Apple   
Podcasts will present newest episodes first and display the publish date (required) of each episode.

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.Serial'></a>

`Serial` 2

Specify serial when episodes are intended to be consumed in sequential order. Apple Podcasts will   
present the oldest episodes first and display the episode numbers (required) of each episode.

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.Unknown'></a>

`Unknown` 0

Invalid value.