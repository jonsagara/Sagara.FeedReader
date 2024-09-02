#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Modules.ApplePodcasts](index.md#Sagara.FeedReader.Modules.ApplePodcasts 'Sagara.FeedReader.Modules.ApplePodcasts')

## iTunesChannel Class

  
Data from an iTunes channel in either RSS 2.0 or Atom.  
  
In RSS 2.0, this is direct child elements of the `channel` element, each within the `itunes` namespace.  
  
In Atom, this is direct child elements of the `feed` element, each within the `im` namespace.

```csharp
public class iTunesChannel
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; iTunesChannel

### Remarks
  
See this article for RSS 2.0 requirements: https://help.apple.com/itc/podcasts_connect/#/itcb54353390  
  
Apple no longer accepts Atom feeds for podcasts, so I don't see `im` documented anywhere.
### Constructors

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.iTunesChannel(System.Xml.Linq.XElement,Microsoft.Extensions.Logging.ILoggerFactory)'></a>

## iTunesChannel(XElement, ILoggerFactory) Constructor

.ctor

```csharp
public iTunesChannel(System.Xml.Linq.XElement channelElement, Microsoft.Extensions.Logging.ILoggerFactory? loggerFactory=null);
```
#### Parameters

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.iTunesChannel(System.Xml.Linq.XElement,Microsoft.Extensions.Logging.ILoggerFactory).channelElement'></a>

`channelElement` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.iTunesChannel(System.Xml.Linq.XElement,Microsoft.Extensions.Logging.ILoggerFactory).loggerFactory'></a>

`loggerFactory` [Microsoft.Extensions.Logging.ILoggerFactory](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILoggerFactory 'Microsoft.Extensions.Logging.ILoggerFactory')
### Properties

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Author'></a>

## iTunesChannel.Author Property

  
The group responsible for creating the media.  
  
Show author most often refers to the parent company or network of a podcast, but it can also be   
            used to identify the host(s) if none exists.  
  
Author information is especially useful if a company or organization publishes multiple podcasts.

```csharp
public string? Author { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Block'></a>

## iTunesChannel.Block Property

  
The podcast show or hide status.  
  
If you want your show removed from the Apple directory, use this tag.  
  
Specifying the <itunes:block> tag with a `Yes` value, prevents the entire podcast from appearing in   
            Apple Podcasts.  
  
Specifying any value other than `Yes` has no effect.

```csharp
public bool Block { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Categories'></a>

## iTunesChannel.Categories Property

  
The show category information. For a complete list of categories and subcategories, see https://podcasters.apple.com/support/1691-apple-podcasts-categories.  
  
A category may contain an optional subcategory.  
  
A feed may specify multiple categories.

```csharp
public System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.Modules.ApplePodcasts.iTunesCategory> Categories { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[iTunesCategory](Sagara.FeedReader.Modules.ApplePodcasts.iTunesCategory.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesCategory')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Complete'></a>

## iTunesChannel.Complete Property

  
The podcast update status.  
  
If you will never publish another episode to your show, use this tag.  
  
Specifying the <itunes:block> tag with a `Yes` value indicates that a podcast is complete and you   
            will not post any more episodes in the future.  
  
Specifying any value other than `Yes` has no effect.

```csharp
public bool Complete { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Explicit'></a>

## iTunesChannel.Explicit Property

  
The podcast parental advisory information.  
  
`true` indicates the presence of explicit content.  
  
`false` indicates that the media doesn't contain explicit language or adult content.

```csharp
public bool Explicit { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Image'></a>

## iTunesChannel.Image Property

The artwork for the show specified as a URL linking to it.

```csharp
public Sagara.FeedReader.Modules.ApplePodcasts.iTunesImage? Image { get; set; }
```

#### Property Value
[iTunesImage](Sagara.FeedReader.Modules.ApplePodcasts.iTunesImage.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesImage')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.NewFeedUrl'></a>

## iTunesChannel.NewFeedUrl Property

  
The new podcast RSS Feed URL.  
  
If you change the URL of your podcast feed, you should use this tag in your new feed.

```csharp
public System.Uri? NewFeedUrl { get; set; }
```

#### Property Value
[System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Owner'></a>

## iTunesChannel.Owner Property

  
The podcast owner contact information.

```csharp
public Sagara.FeedReader.Modules.ApplePodcasts.iTunesOwner? Owner { get; set; }
```

#### Property Value
[iTunesOwner](Sagara.FeedReader.Modules.ApplePodcasts.iTunesOwner.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesOwner')

### Remarks
Note: The <itunes:owner> tag information is for administrative communication about the podcast and   
isn't displayed in Apple Podcasts. Please make sure the email address is active and monitored.

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Title'></a>

## iTunesChannel.Title Property

The show title specific for Apple Podcasts.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Type'></a>

## iTunesChannel.Type Property

  
The type of show.  
  
If your show is Serial you must use this tag.

```csharp
public System.Nullable<Sagara.FeedReader.Modules.ApplePodcasts.iTunesType> Type { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[iTunesType](Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
  
The values can be one of the following:  
- Episodic — Default. Specify episodic when episodes are intended to be consumed without any specific order.  
- Serial — Specify serial when episodes are intended to be consumed in sequential order.