#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## BaseFeedCategory Class

The base object for all feed categories. Since the RSS 2.0 and Atom `category` elements differ,  
hydrating the object is done in feed-specific subclasses.

```csharp
public class BaseFeedCategory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BaseFeedCategory

Derived  
&#8627; [AtomFeedCategory](Sagara.FeedReader.Feeds.AtomFeedCategory.md 'Sagara.FeedReader.Feeds.AtomFeedCategory')  
&#8627; [Rss20FeedCategory](Sagara.FeedReader.Feeds.Rss20FeedCategory.md 'Sagara.FeedReader.Feeds.Rss20FeedCategory')
### Constructors

<a name='Sagara.FeedReader.Feeds.BaseFeedCategory.BaseFeedCategory()'></a>

## BaseFeedCategory() Constructor

Initializes a new instance of the [BaseFeedCategory](Sagara.FeedReader.Feeds.BaseFeedCategory.md 'Sagara.FeedReader.Feeds.BaseFeedCategory') class.  
default constructor (for serialization)

```csharp
protected BaseFeedCategory();
```
### Properties

<a name='Sagara.FeedReader.Feeds.BaseFeedCategory.CategoryElement'></a>

## BaseFeedCategory.CategoryElement Property

The `Category` (RSS) or `entry` (Atom) element from the feed. Return as an XElement in order to   
allow reading properties that are not available as first-class properties in the derived class itself.

```csharp
public System.Xml.Linq.XElement? CategoryElement { get; }
```

#### Property Value
[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')