#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Modules.WordPressExport](index.md#Sagara.FeedReader.Modules.WordPressExport 'Sagara.FeedReader.Modules.WordPressExport')

## WordPressExportChannel Class

  
Data from an iTunes channel in either RSS 2.0 or Atom.  
  
In RSS 2.0, this is direct child elements of the `channel` element, each within the `itunes` namespace.  
  
In Atom, this is direct child elements of the `feed` element, each within the `im` namespace.

```csharp
public class WordPressExportChannel
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; WordPressExportChannel

### Remarks
  
See this article for RSS 2.0 requirements: https://help.apple.com/itc/podcasts_connect/#/itcb54353390  
  
Apple no longer accepts Atom feeds for podcasts, so I don't see `im` documented anywhere.
### Constructors

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.WordPressExportChannel(System.Xml.Linq.XElement,Microsoft.Extensions.Logging.ILoggerFactory)'></a>

## WordPressExportChannel(XElement, ILoggerFactory) Constructor

.ctor

```csharp
public WordPressExportChannel(System.Xml.Linq.XElement channelElement, Microsoft.Extensions.Logging.ILoggerFactory? loggerFactory=null);
```
#### Parameters

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.WordPressExportChannel(System.Xml.Linq.XElement,Microsoft.Extensions.Logging.ILoggerFactory).channelElement'></a>

`channelElement` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.WordPressExportChannel(System.Xml.Linq.XElement,Microsoft.Extensions.Logging.ILoggerFactory).loggerFactory'></a>

`loggerFactory` [Microsoft.Extensions.Logging.ILoggerFactory](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILoggerFactory 'Microsoft.Extensions.Logging.ILoggerFactory')
### Properties

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.Author'></a>

## WordPressExportChannel.Author Property

Information about the WordPress site's author.

```csharp
public Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor? Author { get; set; }
```

#### Property Value
[WordPressExportAuthor](Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.md 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.BaseBlogUrl'></a>

## WordPressExportChannel.BaseBlogUrl Property

The base_blog_url element's value.

```csharp
public string? BaseBlogUrl { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.BaseSiteUrl'></a>

## WordPressExportChannel.BaseSiteUrl Property

The base_site_url element's value.

```csharp
public string? BaseSiteUrl { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.Categories'></a>

## WordPressExportChannel.Categories Property

The WordPress site's categories.

```csharp
public System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory> Categories { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[WordPressExportCategory](Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory.md 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.Tags'></a>

## WordPressExportChannel.Tags Property

The WordPress site's tags.

```csharp
public System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag> Tags { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[WordPressExportTag](Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag.md 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.WxrVersion'></a>

## WordPressExportChannel.WxrVersion Property

The wxr_version element's value.

```csharp
public string? WxrVersion { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')