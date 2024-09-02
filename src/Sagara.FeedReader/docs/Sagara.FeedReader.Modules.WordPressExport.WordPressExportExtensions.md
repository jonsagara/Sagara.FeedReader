#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Modules.WordPressExport](index.md#Sagara.FeedReader.Modules.WordPressExport 'Sagara.FeedReader.Modules.WordPressExport')

## WordPressExportExtensions Class

  
Extension methods that further parse the feed XML for WordPress Export-specific content.

```csharp
public static class WordPressExportExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; WordPressExportExtensions

### Remarks
  
See: https://wordpress.com/support/export/#about-export-files  
  
Schema: http://wordpress.org/export/1.2/
### Methods

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportExtensions.GetWordPressExportChannel(thisSagara.FeedReader.Feed)'></a>

## WordPressExportExtensions.GetWordPressExportChannel(this Feed) Method

Reads WordPress Export elements from a `channel` (RSS 2.0) or `feed` (Atom) element.

```csharp
public static Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel GetWordPressExportChannel(this Sagara.FeedReader.Feed feed);
```
#### Parameters

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportExtensions.GetWordPressExportChannel(thisSagara.FeedReader.Feed).feed'></a>

`feed` [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')

The parsed RSS 2.0 or Atom [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed').

#### Returns
[WordPressExportChannel](Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.md 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportExtensions.GetWordPressExportItem(thisSagara.FeedReader.FeedItem)'></a>

## WordPressExportExtensions.GetWordPressExportItem(this FeedItem) Method

Reads WordPress Export post elements content from a `item` (RSS 2.0) or `entry` (Atom) element.

```csharp
public static Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem GetWordPressExportItem(this Sagara.FeedReader.FeedItem item);
```
#### Parameters

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportExtensions.GetWordPressExportItem(thisSagara.FeedReader.FeedItem).item'></a>

`item` [FeedItem](Sagara.FeedReader.FeedItem.md 'Sagara.FeedReader.FeedItem')

The parsed RSS 2.0 or Atom [FeedItem](Sagara.FeedReader.FeedItem.md 'Sagara.FeedReader.FeedItem').

#### Returns
[WordPressExportItem](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem')