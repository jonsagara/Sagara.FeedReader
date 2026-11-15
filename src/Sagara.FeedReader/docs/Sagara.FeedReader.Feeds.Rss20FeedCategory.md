#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## Rss20FeedCategory Class

RSS 2.0 feed category according to specification: https://validator.w3.org/feed/docs/rss2.html

```csharp
public class Rss20FeedCategory : Sagara.FeedReader.Feeds.BaseFeedCategory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeedCategory](Sagara.FeedReader.Feeds.BaseFeedCategory.md 'Sagara.FeedReader.Feeds.BaseFeedCategory') &#129106; Rss20FeedCategory
### Constructors

<a name='Sagara.FeedReader.Feeds.Rss20FeedCategory.Rss20FeedCategory()'></a>

## Rss20FeedCategory() Constructor

Initializes a new instance of the [Rss20FeedCategory](Sagara.FeedReader.Feeds.Rss20FeedCategory.md 'Sagara.FeedReader.Feeds.Rss20FeedCategory') class.  
default constructor (for serialization)

```csharp
public Rss20FeedCategory();
```
### Properties

<a name='Sagara.FeedReader.Feeds.Rss20FeedCategory.Content'></a>

## Rss20FeedCategory.Content Property

The category text pull from the tag's content.

```csharp
public string? Content { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.Rss20FeedCategory.Domain'></a>

## Rss20FeedCategory.Domain Property

Optional. Identifies the taxonomy in which the category is placed. Comes from the domain attribute.

```csharp
public string? Domain { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')