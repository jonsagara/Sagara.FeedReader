#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## AtomFeedCategory Class

Atom feed category according to specification: https://validator.w3.org/feed/docs/rss2.html

```csharp
public class AtomFeedCategory : Sagara.FeedReader.Feeds.BaseFeedCategory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseFeedCategory](Sagara.FeedReader.Feeds.BaseFeedCategory.md 'Sagara.FeedReader.Feeds.BaseFeedCategory') &#129106; AtomFeedCategory
### Constructors

<a name='Sagara.FeedReader.Feeds.AtomFeedCategory.AtomFeedCategory()'></a>

## AtomFeedCategory() Constructor

Initializes a new instance of the [AtomFeedCategory](Sagara.FeedReader.Feeds.AtomFeedCategory.md 'Sagara.FeedReader.Feeds.AtomFeedCategory') class.  
default constructor (for serialization)

```csharp
public AtomFeedCategory();
```
### Properties

<a name='Sagara.FeedReader.Feeds.AtomFeedCategory.Label'></a>

## AtomFeedCategory.Label Property

Optional. Provides a human-readable label for display in end-user applications.

```csharp
public string? Label { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeedCategory.Scheme'></a>

## AtomFeedCategory.Scheme Property

Optional. Identifies  the categorization scheme associated with this category. This attribute   
can be used, for example, to differentiate between tags and categories.

```csharp
public string? Scheme { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomFeedCategory.Term'></a>

## AtomFeedCategory.Term Property

The term attribute is a string that identifies the category to which the entry or feed belongs.

```csharp
public string? Term { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')