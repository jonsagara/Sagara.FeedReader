#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss092Feed Class

Rss 0.92 feed according to specification: http://backend.userland.com/rss092

```csharp
public class Rss092Feed : Sagara.FeedReader.Feeds.Rss091Feed
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeed](Sagara.FeedReader.Feeds.BaseFeed.md 'Sagara.FeedReader.Feeds.BaseFeed') &#129106; [Rss091Feed](Sagara.FeedReader.Feeds.Rss091Feed.md 'Sagara.FeedReader.Feeds.Rss091Feed') &#129106; Rss092Feed
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss092Feed.Rss092Feed()'></a>

## Rss092Feed() Constructor

Initializes a new instance of the [Rss092Feed](Sagara.FeedReader.Feeds.Rss092Feed.md 'Sagara.FeedReader.Feeds.Rss092Feed') class.  
default constructor (for serialization)

```csharp
public Rss092Feed();
```
### Properties

<a name='Sagara.FeedReader.Feeds.Rss092Feed.Cloud'></a>

## Rss092Feed.Cloud Property

The "cloud" field

```csharp
public Sagara.FeedReader.Feeds.FeedCloud? Cloud { get; set; }
```

#### Property Value
[FeedCloud](Sagara.FeedReader.Feeds.FeedCloud.md 'Sagara.FeedReader.Feeds.FeedCloud')
### Methods

<a name='Sagara.FeedReader.Feeds.Rss092Feed.ToFeed()'></a>

## Rss092Feed.ToFeed() Method

Creates the base [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') element out of this feed.

```csharp
public override Sagara.FeedReader.Feed ToFeed();
```

#### Returns
[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')  
feed