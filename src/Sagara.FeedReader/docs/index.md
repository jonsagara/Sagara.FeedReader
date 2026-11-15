#### [Sagara.FeedReader](index.md 'index')

## Sagara.FeedReader Assembly
### Namespaces

<a name='Microsoft.Extensions.DependencyInjection'></a>

## Microsoft.Extensions.DependencyInjection Namespace
- **[FeedReaderServiceCollectionExtensions](Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.md 'Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions')** `Class` Extension methods for registering [IFeedReader](Sagara.FeedReader.IFeedReader.md 'Sagara.FeedReader.IFeedReader') with dependency injection.
  - **[AddFeedReaderServices(this IServiceCollection, FeedReaderOptions)](Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.md#Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Sagara.FeedReader.Configuration.FeedReaderOptions) 'Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(this Microsoft.Extensions.DependencyInjection.IServiceCollection, Sagara.FeedReader.Configuration.FeedReaderOptions)')** `Method` Register [IFeedReader](Sagara.FeedReader.IFeedReader.md 'Sagara.FeedReader.IFeedReader'), its HttpClient, and the RecyclableMemoryStreamManager it uses.
  - **[AddFeedReaderServices(this IServiceCollection, Action&lt;FeedReaderOptions&gt;)](Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.md#Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Sagara.FeedReader.Configuration.FeedReaderOptions_) 'Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(this Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Sagara.FeedReader.Configuration.FeedReaderOptions>)')** `Method` Register [IFeedReader](Sagara.FeedReader.IFeedReader.md 'Sagara.FeedReader.IFeedReader'), its HttpClient, and the RecyclableMemoryStreamManager it uses.

<a name='Sagara.FeedReader'></a>

## Sagara.FeedReader Namespace
- **[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')** `Class` Generic Feed object that contains some basic properties. If a property is not available  
  for a specific feed type (e.g. Rss 1.0), then the property is empty.  
  If a feed has more properties, like the Generator property for Rss 2.0, then you can use  
  the [SpecificFeed](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.SpecificFeed 'Sagara.FeedReader.Feed.SpecificFeed') property.
  - **[Feed()](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.Feed() 'Sagara.FeedReader.Feed.Feed()')** `Constructor` Initializes a new instance of the [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') class.  
    Default constructor, just there for serialization.
  - **[Feed(BaseFeed)](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.Feed(Sagara.FeedReader.Feeds.BaseFeed) 'Sagara.FeedReader.Feed.Feed(Sagara.FeedReader.Feeds.BaseFeed)')** `Constructor` Initializes a new instance of the [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') class.  
    Creates the generic feed object based on a parsed BaseFeed
  - **[Copyright](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.Copyright 'Sagara.FeedReader.Feed.Copyright')** `Property` The copyright of the feed
  - **[Description](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.Description 'Sagara.FeedReader.Feed.Description')** `Property` The description of the feed
  - **[HasApplePodcastsModule](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.HasApplePodcastsModule 'Sagara.FeedReader.Feed.HasApplePodcastsModule')** `Property` Returns true if the feed's root element (`rss` for RSS, `feed` for atom) has the Apple Podcasts   
    module namespace declaration (`xmlns:itunes`); false otherwise.
  - **[ImageUrl](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.ImageUrl 'Sagara.FeedReader.Feed.ImageUrl')** `Property` The url of the image
  - **[Items](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.Items 'Sagara.FeedReader.Feed.Items')** `Property` List of items. In RSS, these are `item` elements. In Atom, they're `entry` elements.
  - **[Language](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.Language 'Sagara.FeedReader.Feed.Language')** `Property` The language of the feed
  - **[LastUpdatedDate](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.LastUpdatedDate 'Sagara.FeedReader.Feed.LastUpdatedDate')** `Property` The last updated date as datetime. Null if parsing failed or if  
    no last updated date is set. If null, please check [LastUpdatedDateString](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.LastUpdatedDateString 'Sagara.FeedReader.Feed.LastUpdatedDateString') property.
  - **[LastUpdatedDateString](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.LastUpdatedDateString 'Sagara.FeedReader.Feed.LastUpdatedDateString')** `Property` The last updated date as string. This is filled, if a last updated  
    date is set - independent if it is a correct date or not
  - **[Link](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.Link 'Sagara.FeedReader.Feed.Link')** `Property` The link (url) to the feed
  - **[OriginalFeedXml](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.OriginalFeedXml 'Sagara.FeedReader.Feed.OriginalFeedXml')** `Property` The original feed XML string.
  - **[SpecificFeed](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.SpecificFeed 'Sagara.FeedReader.Feed.SpecificFeed')** `Property` The parsed feed element - e.g. of type [Rss20Feed](Sagara.FeedReader.Feeds.Rss20Feed.md 'Sagara.FeedReader.Feeds.Rss20Feed') which contains  
    e.g. the Generator property which does not exist in others.
  - **[Title](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.Title 'Sagara.FeedReader.Feed.Title')** `Property` The title of the field
  - **[Type](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.Type 'Sagara.FeedReader.Feed.Type')** `Property` The Type of the feed - Rss 2.0, 1.0, 0.92, Atom or others
  - **[HasRootNamespaceDeclaration(string)](Sagara.FeedReader.Feed.md#Sagara.FeedReader.Feed.HasRootNamespaceDeclaration(string) 'Sagara.FeedReader.Feed.HasRootNamespaceDeclaration(string)')** `Method` Returns true if the root element has the specified namespace URI declared; false otherwise.
- **[FeedItem](Sagara.FeedReader.FeedItem.md 'Sagara.FeedReader.FeedItem')** `Class` Generic feed item object that contains some basic properties. The feed item is typically  
  an article or a blog post. If a property is not available  
  for a specific feed type (e.g. Rss 1.0), then the property is empty.  
  If a feed item has more properties, like the Generator property for Rss 2.0, then you can use  
  the [SpecificItem](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.SpecificItem 'Sagara.FeedReader.FeedItem.SpecificItem') property.
  - **[FeedItem()](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.FeedItem() 'Sagara.FeedReader.FeedItem.FeedItem()')** `Constructor` Initializes a new instance of the [FeedItem](Sagara.FeedReader.FeedItem.md 'Sagara.FeedReader.FeedItem') class.  
    Default constructor, just there for serialization.
  - **[FeedItem(BaseFeedItem)](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.FeedItem(Sagara.FeedReader.Feeds.BaseFeedItem) 'Sagara.FeedReader.FeedItem.FeedItem(Sagara.FeedReader.Feeds.BaseFeedItem)')** `Constructor` Initializes a new instance of the [FeedItem](Sagara.FeedReader.FeedItem.md 'Sagara.FeedReader.FeedItem') class.  
    Creates the generic feed item object based on a parsed [BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem')
  - **[Author](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.Author 'Sagara.FeedReader.FeedItem.Author')** `Property` The author of the feed item
  - **[Categories](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.Categories 'Sagara.FeedReader.FeedItem.Categories')** `Property` The categories of the feeditem
  - **[Content](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.Content 'Sagara.FeedReader.FeedItem.Content')** `Property` The content of the feed item
  - **[Description](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.Description 'Sagara.FeedReader.FeedItem.Description')** `Property` The description of the feed item
  - **[Id](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.Id 'Sagara.FeedReader.FeedItem.Id')** `Property` The id of the feed item
  - **[Link](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.Link 'Sagara.FeedReader.FeedItem.Link')** `Property` The link (url) to the feed item
  - **[PublishingDate](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.PublishingDate 'Sagara.FeedReader.FeedItem.PublishingDate')** `Property` The published date as datetime. Null if parsing failed or if  
    no publishing date is set. If null, please check [PublishingDateString](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.PublishingDateString 'Sagara.FeedReader.FeedItem.PublishingDateString') property.
  - **[PublishingDateString](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.PublishingDateString 'Sagara.FeedReader.FeedItem.PublishingDateString')** `Property` The publishing date as string. This is filled, if a publishing  
    date is set - independent if it is a correct date or not
  - **[SpecificItem](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.SpecificItem 'Sagara.FeedReader.FeedItem.SpecificItem')** `Property` The parsed feed item element - e.g. of type [Rss20FeedItem](Sagara.FeedReader.Feeds.Rss20FeedItem.md 'Sagara.FeedReader.Feeds.Rss20FeedItem') which contains  
    e.g. the Enclosure property which does not exist in other feed types.
  - **[Title](Sagara.FeedReader.FeedItem.md#Sagara.FeedReader.FeedItem.Title 'Sagara.FeedReader.FeedItem.Title')** `Property` The title of the feed item
- **[FeedParseException](Sagara.FeedReader.FeedParseException.md 'Sagara.FeedReader.FeedParseException')** `Class` Thrown when feed content cannot be parsed. [Kind](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.Kind 'Sagara.FeedReader.FeedParseException.Kind') says why.
  - **[FeedParseException()](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.FeedParseException() 'Sagara.FeedReader.FeedParseException.FeedParseException()')** `Constructor` Initializes a new [FeedParseException](Sagara.FeedReader.FeedParseException.md 'Sagara.FeedReader.FeedParseException') with [Kind](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.Kind 'Sagara.FeedReader.FeedParseException.Kind') set to [InvalidXml](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.InvalidXml 'Sagara.FeedReader.FeedReaderErrorKind.InvalidXml').
  - **[FeedParseException(FeedReaderErrorKind, string, Exception)](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.FeedParseException(Sagara.FeedReader.FeedReaderErrorKind,string,System.Exception) 'Sagara.FeedReader.FeedParseException.FeedParseException(Sagara.FeedReader.FeedReaderErrorKind, string, System.Exception)')** `Constructor` Initializes a new [FeedParseException](Sagara.FeedReader.FeedParseException.md 'Sagara.FeedReader.FeedParseException').
  - **[FeedParseException(string, Exception)](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.FeedParseException(string,System.Exception) 'Sagara.FeedReader.FeedParseException.FeedParseException(string, System.Exception)')** `Constructor` Initializes a new [FeedParseException](Sagara.FeedReader.FeedParseException.md 'Sagara.FeedReader.FeedParseException') with [Kind](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.Kind 'Sagara.FeedReader.FeedParseException.Kind') set to [InvalidXml](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.InvalidXml 'Sagara.FeedReader.FeedReaderErrorKind.InvalidXml').
  - **[FeedParseException(string)](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.FeedParseException(string) 'Sagara.FeedReader.FeedParseException.FeedParseException(string)')** `Constructor` Initializes a new [FeedParseException](Sagara.FeedReader.FeedParseException.md 'Sagara.FeedReader.FeedParseException') with [Kind](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.Kind 'Sagara.FeedReader.FeedParseException.Kind') set to [InvalidXml](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.InvalidXml 'Sagara.FeedReader.FeedReaderErrorKind.InvalidXml').
  - **[Kind](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.Kind 'Sagara.FeedReader.FeedParseException.Kind')** `Property` Why the content could not be parsed. One of [InvalidXml](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.InvalidXml 'Sagara.FeedReader.FeedReaderErrorKind.InvalidXml'),  
    [NotAFeed](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.NotAFeed 'Sagara.FeedReader.FeedReaderErrorKind.NotAFeed'), [UnsupportedFeedType](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.UnsupportedFeedType 'Sagara.FeedReader.FeedReaderErrorKind.UnsupportedFeedType'),  
    or [ParseError](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.ParseError 'Sagara.FeedReader.FeedReaderErrorKind.ParseError').
- **[FeedParser](Sagara.FeedReader.FeedParser.md 'Sagara.FeedReader.FeedParser')** `Class` Parses RSS 0.91, 0.92, 1.0, 2.0, Media RSS, and Atom feeds from content you already have, e.g., a file or a string.
  - **[Parse(string)](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.Parse(string) 'Sagara.FeedReader.FeedParser.Parse(string)')** `Method` Parse a feed from a string. The XML declaration's encoding is ignored, because the content has already  
    been decoded into a string.
  - **[ParseAsync(Stream, CancellationToken)](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream, System.Threading.CancellationToken)')** `Method` Parse a feed from a stream. The encoding declared in the document's XML declaration is honored;  
    if there is none, or it's invalid, UTF-8 is used.
  - **[TryParse(string)](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.TryParse(string) 'Sagara.FeedReader.FeedParser.TryParse(string)')** `Method` Parse a feed from a string without throwing when the content can't be parsed. Otherwise the same as  
    [Parse(string)](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.Parse(string) 'Sagara.FeedReader.FeedParser.Parse(string)').
  - **[TryParseAsync(Stream, CancellationToken)](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.TryParseAsync(System.IO.Stream,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedParser.TryParseAsync(System.IO.Stream, System.Threading.CancellationToken)')** `Method` Parse a feed from a stream without throwing when the content can't be parsed. Otherwise the same as  
    [ParseAsync(Stream, CancellationToken)](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream, System.Threading.CancellationToken)').
- **[FeedReader](Sagara.FeedReader.FeedReader.md 'Sagara.FeedReader.FeedReader')** `Class` The default [IFeedReader](Sagara.FeedReader.IFeedReader.md 'Sagara.FeedReader.IFeedReader'): downloads and parses feeds from URLs, and finds the feeds a web page links to.
  - **[FeedReader(HttpClient, RecyclableMemoryStreamManager, FeedReaderOptions)](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.FeedReader(System.Net.Http.HttpClient,Microsoft.IO.RecyclableMemoryStreamManager,Sagara.FeedReader.Configuration.FeedReaderOptions) 'Sagara.FeedReader.FeedReader.FeedReader(System.Net.Http.HttpClient, Microsoft.IO.RecyclableMemoryStreamManager, Sagara.FeedReader.Configuration.FeedReaderOptions)')** `Constructor` Initializes a new [FeedReader](Sagara.FeedReader.FeedReader.md 'Sagara.FeedReader.FeedReader').
  - **[GetFeedAsync(string, string, CancellationToken)](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedReader.GetFeedAsync(string, string, System.Threading.CancellationToken)')** `Method` Download and parse the feed at feedUrl. The URL must point to a feed, not an HTML page; use  
    [GetFeedUrlsFromPageAsync(string, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken)') to find a page's feeds.
  - **[GetFeedAsync(Uri, string, CancellationToken)](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedAsync(System.Uri,string,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedReader.GetFeedAsync(System.Uri, string, System.Threading.CancellationToken)')** `Method` Download and parse the feed at feedUrl. The URL must point to a feed, not an HTML page; use  
    [GetFeedUrlsFromPageAsync(string, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken)') to find a page's feeds.
  - **[GetFeedUrlsFromPageAsync(string, string, CancellationToken)](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken)')** `Method` Download the web page at pageUrl and return the feeds it links to with  
    <link rel="alternate" type="application/rss+xml"/> or type="application/atom+xml" tags.
  - **[GetFeedUrlsFromPageAsync(Uri, string, CancellationToken)](Sagara.FeedReader.FeedReader.md#Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(System.Uri,string,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedReader.GetFeedUrlsFromPageAsync(System.Uri, string, System.Threading.CancellationToken)')** `Method` Download the web page at pageUrl and return the feeds it links to with  
    <link rel="alternate" type="application/rss+xml"/> or type="application/atom+xml" tags.
- **[FeedReaderError](Sagara.FeedReader.FeedReaderError.md 'Sagara.FeedReader.FeedReaderError')** `Class` Describes why a feed could not be downloaded or parsed.
  - **[FeedReaderError(FeedReaderErrorKind, string, Exception)](Sagara.FeedReader.FeedReaderError.md#Sagara.FeedReader.FeedReaderError.FeedReaderError(Sagara.FeedReader.FeedReaderErrorKind,string,System.Exception) 'Sagara.FeedReader.FeedReaderError.FeedReaderError(Sagara.FeedReader.FeedReaderErrorKind, string, System.Exception)')** `Constructor` Describes why a feed could not be downloaded or parsed.
  - **[Exception](Sagara.FeedReader.FeedReaderError.md#Sagara.FeedReader.FeedReaderError.Exception 'Sagara.FeedReader.FeedReaderError.Exception')** `Property` The exception that caused the failure, if any.
  - **[Kind](Sagara.FeedReader.FeedReaderError.md#Sagara.FeedReader.FeedReaderError.Kind 'Sagara.FeedReader.FeedReaderError.Kind')** `Property` The kind of failure. Use this to decide what to do, e.g., drop a subscription on  
                [HttpError](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.HttpError 'Sagara.FeedReader.FeedReaderErrorKind.HttpError') 404, or retry later on [Timeout](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.Timeout 'Sagara.FeedReader.FeedReaderErrorKind.Timeout').
  - **[Message](Sagara.FeedReader.FeedReaderError.md#Sagara.FeedReader.FeedReaderError.Message 'Sagara.FeedReader.FeedReaderError.Message')** `Property` A human-readable description of the failure.
- **[FeedReaderResult](Sagara.FeedReader.FeedReaderResult.md 'Sagara.FeedReader.FeedReaderResult')** `Class` Factory methods for [FeedReaderResult&lt;T&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>').
  - **[Failure&lt;T&gt;(FeedReaderError, Nullable&lt;HttpStatusCode&gt;, Uri)](Sagara.FeedReader.FeedReaderResult.md#Sagara.FeedReader.FeedReaderResult.Failure_T_(Sagara.FeedReader.FeedReaderError,System.Nullable_System.Net.HttpStatusCode_,System.Uri) 'Sagara.FeedReader.FeedReaderResult.Failure<T>(Sagara.FeedReader.FeedReaderError, System.Nullable<System.Net.HttpStatusCode>, System.Uri)')** `Method` Create a failed result.
  - **[Success&lt;T&gt;(T, Nullable&lt;HttpStatusCode&gt;, Uri)](Sagara.FeedReader.FeedReaderResult.md#Sagara.FeedReader.FeedReaderResult.Success_T_(T,System.Nullable_System.Net.HttpStatusCode_,System.Uri) 'Sagara.FeedReader.FeedReaderResult.Success<T>(T, System.Nullable<System.Net.HttpStatusCode>, System.Uri)')** `Method` Create a successful result.
- **[FeedReaderResult&lt;T&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')** `Class` The outcome of downloading or parsing a feed: either a [Value](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.Value 'Sagara.FeedReader.FeedReaderResult<T>.Value') or an [Error](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.Error 'Sagara.FeedReader.FeedReaderResult<T>.Error'), never both.
  - **[Error](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.Error 'Sagara.FeedReader.FeedReaderResult<T>.Error')** `Property` Why the operation failed, if it failed. Otherwise, null.
  - **[FinalUri](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.FinalUri 'Sagara.FeedReader.FeedReaderResult<T>.FinalUri')** `Property` The URI that the content was ultimately read from, after following any redirects. Null when parsing  
    local content, or when the request failed before a response arrived.
  - **[IsSuccess](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.IsSuccess 'Sagara.FeedReader.FeedReaderResult<T>.IsSuccess')** `Property` True if the operation succeeded, in which case [Value](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.Value 'Sagara.FeedReader.FeedReaderResult<T>.Value') is not null. False if it failed,  
    in which case [Error](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.Error 'Sagara.FeedReader.FeedReaderResult<T>.Error') is not null.
  - **[StatusCode](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.StatusCode 'Sagara.FeedReader.FeedReaderResult<T>.StatusCode')** `Property` The HTTP status code of the response, if an HTTP response was received. Null when parsing local  
    content, or when the request failed before a response arrived.
  - **[Value](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.Value 'Sagara.FeedReader.FeedReaderResult<T>.Value')** `Property` The value, if the operation succeeded. Otherwise, null.
- **[HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink')** `Class` An html feed link, containing the title, the url and the type of the feed
  - **[HtmlFeedLink()](Sagara.FeedReader.HtmlFeedLink.md#Sagara.FeedReader.HtmlFeedLink.HtmlFeedLink() 'Sagara.FeedReader.HtmlFeedLink.HtmlFeedLink()')** `Constructor` Initializes a new instance of the [HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink') class.  
    default constructor (for serialization)
  - **[HtmlFeedLink(string, string, FeedType)](Sagara.FeedReader.HtmlFeedLink.md#Sagara.FeedReader.HtmlFeedLink.HtmlFeedLink(string,string,Sagara.FeedReader.FeedType) 'Sagara.FeedReader.HtmlFeedLink.HtmlFeedLink(string, string, Sagara.FeedReader.FeedType)')** `Constructor` Initializes a new instance of the [HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink') class.  
    Creates an html feed link item
  - **[FeedType](Sagara.FeedReader.HtmlFeedLink.md#Sagara.FeedReader.HtmlFeedLink.FeedType 'Sagara.FeedReader.HtmlFeedLink.FeedType')** `Property` The type of the feed - rss or atom
  - **[Title](Sagara.FeedReader.HtmlFeedLink.md#Sagara.FeedReader.HtmlFeedLink.Title 'Sagara.FeedReader.HtmlFeedLink.Title')** `Property` The title of the feed
  - **[Url](Sagara.FeedReader.HtmlFeedLink.md#Sagara.FeedReader.HtmlFeedLink.Url 'Sagara.FeedReader.HtmlFeedLink.Url')** `Property` The url to the feed
- **[IFeedReader](Sagara.FeedReader.IFeedReader.md 'Sagara.FeedReader.IFeedReader')** `Interface` Downloads and parses feeds from URLs, and finds the feeds a web page links to.
  - **[GetFeedAsync(string, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedAsync(string, string, System.Threading.CancellationToken)')** `Method` Download and parse the feed at feedUrl. The URL must point to a feed, not an HTML page; use  
    [GetFeedUrlsFromPageAsync(string, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken)') to find a page's feeds.
  - **[GetFeedAsync(Uri, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedAsync(System.Uri,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedAsync(System.Uri, string, System.Threading.CancellationToken)')** `Method` Download and parse the feed at feedUrl. The URL must point to a feed, not an HTML page; use  
    [GetFeedUrlsFromPageAsync(string, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken)') to find a page's feeds.
  - **[GetFeedUrlsFromPageAsync(string, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(string, string, System.Threading.CancellationToken)')** `Method` Download the web page at pageUrl and return the feeds it links to with  
    <link rel="alternate" type="application/rss+xml"/> or type="application/atom+xml" tags.
  - **[GetFeedUrlsFromPageAsync(Uri, string, CancellationToken)](Sagara.FeedReader.IFeedReader.md#Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(System.Uri,string,System.Threading.CancellationToken) 'Sagara.FeedReader.IFeedReader.GetFeedUrlsFromPageAsync(System.Uri, string, System.Threading.CancellationToken)')** `Method` Download the web page at pageUrl and return the feeds it links to with  
    <link rel="alternate" type="application/rss+xml"/> or type="application/atom+xml" tags.
- **[FeedReaderErrorKind](Sagara.FeedReader.FeedReaderErrorKind.md 'Sagara.FeedReader.FeedReaderErrorKind')** `Enum` The kind of failure that occurred while downloading or parsing a feed.
  - **[HttpError](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.HttpError 'Sagara.FeedReader.FeedReaderErrorKind.HttpError')** `Field` The server returned a non-success HTTP status code.
  - **[InvalidXml](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.InvalidXml 'Sagara.FeedReader.FeedReaderErrorKind.InvalidXml')** `Field` The content is empty or is not well-formed XML.
  - **[NetworkError](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.NetworkError 'Sagara.FeedReader.FeedReaderErrorKind.NetworkError')** `Field` The request failed before an HTTP response was received, e.g., a DNS, TLS, or connection failure.
  - **[NotAFeed](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.NotAFeed 'Sagara.FeedReader.FeedReaderErrorKind.NotAFeed')** `Field` The content is an HTML page, not a feed.
  - **[ParseError](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.ParseError 'Sagara.FeedReader.FeedReaderErrorKind.ParseError')** `Field` The content is well-formed XML with a supported root element, but the feed could not be parsed, e.g.,  
    because a required element is missing.
  - **[ResponseTooLarge](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.ResponseTooLarge 'Sagara.FeedReader.FeedReaderErrorKind.ResponseTooLarge')** `Field` The response body exceeded the configured maximum size.
  - **[Timeout](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.Timeout 'Sagara.FeedReader.FeedReaderErrorKind.Timeout')** `Field` The request timed out.
  - **[UnsupportedFeedType](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.UnsupportedFeedType 'Sagara.FeedReader.FeedReaderErrorKind.UnsupportedFeedType')** `Field` The content is well-formed XML, but its root element is not a supported feed type.
- **[FeedType](Sagara.FeedReader.FeedType.md 'Sagara.FeedReader.FeedType')** `Enum` The type of the feed (RSS 0.91, RSS 2.0, Atom, ...)
  - **[Atom](Sagara.FeedReader.FeedType.md#Sagara.FeedReader.FeedType.Atom 'Sagara.FeedReader.FeedType.Atom')** `Field` Atom feed
  - **[MediaRss](Sagara.FeedReader.FeedType.md#Sagara.FeedReader.FeedType.MediaRss 'Sagara.FeedReader.FeedType.MediaRss')** `Field` Media RSS feed
  - **[Rss](Sagara.FeedReader.FeedType.md#Sagara.FeedReader.FeedType.Rss 'Sagara.FeedReader.FeedType.Rss')** `Field` RSS feed - is used for [HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink') type
  - **[Rss_0_91](Sagara.FeedReader.FeedType.md#Sagara.FeedReader.FeedType.Rss_0_91 'Sagara.FeedReader.FeedType.Rss_0_91')** `Field` RSS 0.91 feed
  - **[Rss_0_92](Sagara.FeedReader.FeedType.md#Sagara.FeedReader.FeedType.Rss_0_92 'Sagara.FeedReader.FeedType.Rss_0_92')** `Field` RSS 0.92 feed
  - **[Rss_1_0](Sagara.FeedReader.FeedType.md#Sagara.FeedReader.FeedType.Rss_1_0 'Sagara.FeedReader.FeedType.Rss_1_0')** `Field` RSS 1.0 feed
  - **[Rss_2_0](Sagara.FeedReader.FeedType.md#Sagara.FeedReader.FeedType.Rss_2_0 'Sagara.FeedReader.FeedType.Rss_2_0')** `Field` RSS 2.0 feed
  - **[Unknown](Sagara.FeedReader.FeedType.md#Sagara.FeedReader.FeedType.Unknown 'Sagara.FeedReader.FeedType.Unknown')** `Field` Unknown - default type

<a name='Sagara.FeedReader.Configuration'></a>

## Sagara.FeedReader.Configuration Namespace
- **[FeedReaderOptions](Sagara.FeedReader.Configuration.FeedReaderOptions.md 'Sagara.FeedReader.Configuration.FeedReaderOptions')** `Class` Allow the caller to configure the FeedReader HttpClient and RecyclableMemoryStreamManager.
  - **[DefaultMaxResponseBytes](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultMaxResponseBytes 'Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultMaxResponseBytes')** `Field` The default value of [MaxResponseBytes](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.MaxResponseBytes 'Sagara.FeedReader.Configuration.FeedReaderOptions.MaxResponseBytes'): 10 MB.
  - **[DefaultUserAgent](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent 'Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultUserAgent')** `Property` The User-Agent header sent with every request, unless a request passes its own. If null or white space,  
    a browser-like User-Agent is used, because some sites reject requests that don't look like they come from a browser.
  - **[MaxResponseBytes](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.MaxResponseBytes 'Sagara.FeedReader.Configuration.FeedReaderOptions.MaxResponseBytes')** `Property` The largest response body, in bytes, that will be downloaded. Larger responses fail with  
    [ResponseTooLarge](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.ResponseTooLarge 'Sagara.FeedReader.FeedReaderErrorKind.ResponseTooLarge'). Must be positive. Default is [DefaultMaxResponseBytes](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultMaxResponseBytes 'Sagara.FeedReader.Configuration.FeedReaderOptions.DefaultMaxResponseBytes') (10 MB).
  - **[Proxy](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.Proxy 'Sagara.FeedReader.Configuration.FeedReaderOptions.Proxy')** `Property` Optionally allow the caller to specify an HTTP proxy for the FeedReader named HttpClient.
  - **[RecyclableMemoryStreamManagerOptions](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.RecyclableMemoryStreamManagerOptions 'Sagara.FeedReader.Configuration.FeedReaderOptions.RecyclableMemoryStreamManagerOptions')** `Property`   
      
    If [SuppressRecyclableMemoryStreamManagerRegistration](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.SuppressRecyclableMemoryStreamManagerRegistration 'Sagara.FeedReader.Configuration.FeedReaderOptions.SuppressRecyclableMemoryStreamManagerRegistration') is false, allow the caller to configure  
                the RecyclableMemoryStreamManager for registering with the DI service. If null, our default values are used.  
      
    Ignored if [SuppressRecyclableMemoryStreamManagerRegistration](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.SuppressRecyclableMemoryStreamManagerRegistration 'Sagara.FeedReader.Configuration.FeedReaderOptions.SuppressRecyclableMemoryStreamManagerRegistration') is true.
  - **[ResilienceHandler](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.ResilienceHandler 'Sagara.FeedReader.Configuration.FeedReaderOptions.ResilienceHandler')** `Property` Optionally allow the caller to customize the Polly HTTP resilience strategy for the HttpClient.
  - **[SuppressRecyclableMemoryStreamManagerRegistration](Sagara.FeedReader.Configuration.FeedReaderOptions.md#Sagara.FeedReader.Configuration.FeedReaderOptions.SuppressRecyclableMemoryStreamManagerRegistration 'Sagara.FeedReader.Configuration.FeedReaderOptions.SuppressRecyclableMemoryStreamManagerRegistration')** `Property` Set to true if you, the caller, will register a RecyclableMemoryStreamManager with the DI service yourself  
    and you don't want this library to register one. Default is false.

<a name='Sagara.FeedReader.Feeds'></a>

## Sagara.FeedReader.Feeds Namespace
- **[AtomFeed](Sagara.FeedReader.Feeds.AtomFeed.md 'Sagara.FeedReader.Feeds.AtomFeed')** `Class` Atom 1.0 feed object according to specification: https://validator.w3.org/feed/docs/atom.html
  - **[AtomFeed()](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.AtomFeed() 'Sagara.FeedReader.Feeds.AtomFeed.AtomFeed()')** `Constructor` Initializes a new instance of the [AtomFeed](Sagara.FeedReader.Feeds.AtomFeed.md 'Sagara.FeedReader.Feeds.AtomFeed') class.  
    default constructor (for serialization)
  - **[Author](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.Author 'Sagara.FeedReader.Feeds.AtomFeed.Author')** `Property` The "author" element
  - **[Categories](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.Categories 'Sagara.FeedReader.Feeds.AtomFeed.Categories')** `Property` All "category" elements
  - **[Contributor](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.Contributor 'Sagara.FeedReader.Feeds.AtomFeed.Contributor')** `Property` The "contributor" element
  - **[Generator](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.Generator 'Sagara.FeedReader.Feeds.AtomFeed.Generator')** `Property` The "generator" element
  - **[Icon](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.Icon 'Sagara.FeedReader.Feeds.AtomFeed.Icon')** `Property` The "icon" element
  - **[Id](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.Id 'Sagara.FeedReader.Feeds.AtomFeed.Id')** `Property` The "id" element
  - **[Links](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.Links 'Sagara.FeedReader.Feeds.AtomFeed.Links')** `Property` All "link" elements
  - **[Logo](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.Logo 'Sagara.FeedReader.Feeds.AtomFeed.Logo')** `Property` The "logo" element
  - **[Rights](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.Rights 'Sagara.FeedReader.Feeds.AtomFeed.Rights')** `Property` The "rights" element
  - **[Subtitle](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.Subtitle 'Sagara.FeedReader.Feeds.AtomFeed.Subtitle')** `Property` The "subtitle" element
  - **[UpdatedDate](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.UpdatedDate 'Sagara.FeedReader.Feeds.AtomFeed.UpdatedDate')** `Property` The "updated" element as DateTime. Null if parsing failed of updatedDate is empty.
  - **[UpdatedDateString](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.UpdatedDateString 'Sagara.FeedReader.Feeds.AtomFeed.UpdatedDateString')** `Property` The "updated" element as string
  - **[ToFeed()](Sagara.FeedReader.Feeds.AtomFeed.md#Sagara.FeedReader.Feeds.AtomFeed.ToFeed() 'Sagara.FeedReader.Feeds.AtomFeed.ToFeed()')** `Method` Creates the base [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') element out of this feed.
- **[AtomFeedCategory](Sagara.FeedReader.Feeds.AtomFeedCategory.md 'Sagara.FeedReader.Feeds.AtomFeedCategory')** `Class` Atom feed category according to specification: https://validator.w3.org/feed/docs/rss2.html
  - **[AtomFeedCategory()](Sagara.FeedReader.Feeds.AtomFeedCategory.md#Sagara.FeedReader.Feeds.AtomFeedCategory.AtomFeedCategory() 'Sagara.FeedReader.Feeds.AtomFeedCategory.AtomFeedCategory()')** `Constructor` Initializes a new instance of the [AtomFeedCategory](Sagara.FeedReader.Feeds.AtomFeedCategory.md 'Sagara.FeedReader.Feeds.AtomFeedCategory') class.  
    default constructor (for serialization)
  - **[Label](Sagara.FeedReader.Feeds.AtomFeedCategory.md#Sagara.FeedReader.Feeds.AtomFeedCategory.Label 'Sagara.FeedReader.Feeds.AtomFeedCategory.Label')** `Property` Optional. Provides a human-readable label for display in end-user applications.
  - **[Scheme](Sagara.FeedReader.Feeds.AtomFeedCategory.md#Sagara.FeedReader.Feeds.AtomFeedCategory.Scheme 'Sagara.FeedReader.Feeds.AtomFeedCategory.Scheme')** `Property` Optional. Identifies  the categorization scheme associated with this category. This attribute   
    can be used, for example, to differentiate between tags and categories.
  - **[Term](Sagara.FeedReader.Feeds.AtomFeedCategory.md#Sagara.FeedReader.Feeds.AtomFeedCategory.Term 'Sagara.FeedReader.Feeds.AtomFeedCategory.Term')** `Property` The term attribute is a string that identifies the category to which the entry or feed belongs.
- **[AtomFeedItem](Sagara.FeedReader.Feeds.AtomFeedItem.md 'Sagara.FeedReader.Feeds.AtomFeedItem')** `Class` Atom 1.0 feed item object according to specification: https://validator.w3.org/feed/docs/atom.html
  - **[AtomFeedItem()](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.AtomFeedItem() 'Sagara.FeedReader.Feeds.AtomFeedItem.AtomFeedItem()')** `Constructor` Initializes a new instance of the [AtomFeedItem](Sagara.FeedReader.Feeds.AtomFeedItem.md 'Sagara.FeedReader.Feeds.AtomFeedItem') class.  
    default constructor (for serialization)
  - **[Author](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.Author 'Sagara.FeedReader.Feeds.AtomFeedItem.Author')** `Property` The "author" element
  - **[Categories](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.Categories 'Sagara.FeedReader.Feeds.AtomFeedItem.Categories')** `Property` All "category" elements
  - **[Content](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.Content 'Sagara.FeedReader.Feeds.AtomFeedItem.Content')** `Property` The "content" element
  - **[Contributor](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.Contributor 'Sagara.FeedReader.Feeds.AtomFeedItem.Contributor')** `Property` The "contributor" element
  - **[Id](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.Id 'Sagara.FeedReader.Feeds.AtomFeedItem.Id')** `Property` The "id" element
  - **[Links](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.Links 'Sagara.FeedReader.Feeds.AtomFeedItem.Links')** `Property` All "link" elements
  - **[PublishedDate](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.PublishedDate 'Sagara.FeedReader.Feeds.AtomFeedItem.PublishedDate')** `Property` The "published" element as DateTime. Null if parsing failed or published is empty.
  - **[PublishedDateString](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.PublishedDateString 'Sagara.FeedReader.Feeds.AtomFeedItem.PublishedDateString')** `Property` The "published" date as string
  - **[Rights](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.Rights 'Sagara.FeedReader.Feeds.AtomFeedItem.Rights')** `Property` The "rights" element
  - **[Source](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.Source 'Sagara.FeedReader.Feeds.AtomFeedItem.Source')** `Property` The "source" element
  - **[Summary](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.Summary 'Sagara.FeedReader.Feeds.AtomFeedItem.Summary')** `Property` The "summary" element
  - **[UpdatedDate](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.UpdatedDate 'Sagara.FeedReader.Feeds.AtomFeedItem.UpdatedDate')** `Property` The "updated" element as DateTime. Null if parsing failed or updated is empty
  - **[UpdatedDateString](Sagara.FeedReader.Feeds.AtomFeedItem.md#Sagara.FeedReader.Feeds.AtomFeedItem.UpdatedDateString 'Sagara.FeedReader.Feeds.AtomFeedItem.UpdatedDateString')** `Property` The "updated" element
- **[AtomLink](Sagara.FeedReader.Feeds.AtomLink.md 'Sagara.FeedReader.Feeds.AtomLink')** `Class` Atom 1.0 link according to specification: https://validator.w3.org/feed/docs/atom.html#link
  - **[AtomLink()](Sagara.FeedReader.Feeds.AtomLink.md#Sagara.FeedReader.Feeds.AtomLink.AtomLink() 'Sagara.FeedReader.Feeds.AtomLink.AtomLink()')** `Constructor` Initializes a new instance of the [AtomLink](Sagara.FeedReader.Feeds.AtomLink.md 'Sagara.FeedReader.Feeds.AtomLink') class.  
    default constructor (for serialization)
  - **[Href](Sagara.FeedReader.Feeds.AtomLink.md#Sagara.FeedReader.Feeds.AtomLink.Href 'Sagara.FeedReader.Feeds.AtomLink.Href')** `Property` The "href" element
  - **[HrefLanguage](Sagara.FeedReader.Feeds.AtomLink.md#Sagara.FeedReader.Feeds.AtomLink.HrefLanguage 'Sagara.FeedReader.Feeds.AtomLink.HrefLanguage')** `Property` The "hreflang" element
  - **[Length](Sagara.FeedReader.Feeds.AtomLink.md#Sagara.FeedReader.Feeds.AtomLink.Length 'Sagara.FeedReader.Feeds.AtomLink.Length')** `Property` The "length" elemnt as int
  - **[LinkType](Sagara.FeedReader.Feeds.AtomLink.md#Sagara.FeedReader.Feeds.AtomLink.LinkType 'Sagara.FeedReader.Feeds.AtomLink.LinkType')** `Property` The "type" element
  - **[Relation](Sagara.FeedReader.Feeds.AtomLink.md#Sagara.FeedReader.Feeds.AtomLink.Relation 'Sagara.FeedReader.Feeds.AtomLink.Relation')** `Property` The "rel" element
  - **[Title](Sagara.FeedReader.Feeds.AtomLink.md#Sagara.FeedReader.Feeds.AtomLink.Title 'Sagara.FeedReader.Feeds.AtomLink.Title')** `Property` The "title" element
  - **[ToString()](Sagara.FeedReader.Feeds.AtomLink.md#Sagara.FeedReader.Feeds.AtomLink.ToString() 'Sagara.FeedReader.Feeds.AtomLink.ToString()')** `Method` Returns the Href of the link
- **[AtomPerson](Sagara.FeedReader.Feeds.AtomPerson.md 'Sagara.FeedReader.Feeds.AtomPerson')** `Class` Atom 1.0 person element according to specification: https://validator.w3.org/feed/docs/atom.html
  - **[AtomPerson()](Sagara.FeedReader.Feeds.AtomPerson.md#Sagara.FeedReader.Feeds.AtomPerson.AtomPerson() 'Sagara.FeedReader.Feeds.AtomPerson.AtomPerson()')** `Constructor` Initializes a new instance of the [AtomPerson](Sagara.FeedReader.Feeds.AtomPerson.md 'Sagara.FeedReader.Feeds.AtomPerson') class.  
    default constructor (for serialization)
  - **[EMail](Sagara.FeedReader.Feeds.AtomPerson.md#Sagara.FeedReader.Feeds.AtomPerson.EMail 'Sagara.FeedReader.Feeds.AtomPerson.EMail')** `Property` The "email" element
  - **[Name](Sagara.FeedReader.Feeds.AtomPerson.md#Sagara.FeedReader.Feeds.AtomPerson.Name 'Sagara.FeedReader.Feeds.AtomPerson.Name')** `Property` The "name" element
  - **[Uri](Sagara.FeedReader.Feeds.AtomPerson.md#Sagara.FeedReader.Feeds.AtomPerson.Uri 'Sagara.FeedReader.Feeds.AtomPerson.Uri')** `Property` The "uri" element
  - **[ToString()](Sagara.FeedReader.Feeds.AtomPerson.md#Sagara.FeedReader.Feeds.AtomPerson.ToString() 'Sagara.FeedReader.Feeds.AtomPerson.ToString()')** `Method` returns the name of the author including the email if available
- **[BaseFeed](Sagara.FeedReader.Feeds.BaseFeed.md 'Sagara.FeedReader.Feeds.BaseFeed')** `Class` BaseFeed object which contains the basic properties that each feed has.
  - **[BaseFeed()](Sagara.FeedReader.Feeds.BaseFeed.md#Sagara.FeedReader.Feeds.BaseFeed.BaseFeed() 'Sagara.FeedReader.Feeds.BaseFeed.BaseFeed()')** `Constructor` Initializes a new instance of the [BaseFeed](Sagara.FeedReader.Feeds.BaseFeed.md 'Sagara.FeedReader.Feeds.BaseFeed') class.  
    default constructor (for serialization)
  - **[ChannelOrFeedElement](Sagara.FeedReader.Feeds.BaseFeed.md#Sagara.FeedReader.Feeds.BaseFeed.ChannelOrFeedElement 'Sagara.FeedReader.Feeds.BaseFeed.ChannelOrFeedElement')** `Property` The `channel` (RSS) or `feed` (Atom) element from the feed. Returned as an XElement   
    in order to allow reading properties that are not available as first-class properties in the derived  
    class itself.
  - **[HasApplePodcastsModule](Sagara.FeedReader.Feeds.BaseFeed.md#Sagara.FeedReader.Feeds.BaseFeed.HasApplePodcastsModule 'Sagara.FeedReader.Feeds.BaseFeed.HasApplePodcastsModule')** `Property` Returns true if the feed's root element (`rss` for RSS, `feed` for atom) has the Apple Podcasts   
    module namespace declaration (`xmlns:itunes`); false otherwise.
  - **[Items](Sagara.FeedReader.Feeds.BaseFeed.md#Sagara.FeedReader.Feeds.BaseFeed.Items 'Sagara.FeedReader.Feeds.BaseFeed.Items')** `Property` The items that are in the feed, specific to the feed type (Atom vs. RSS 2.0, etc.).
  - **[Link](Sagara.FeedReader.Feeds.BaseFeed.md#Sagara.FeedReader.Feeds.BaseFeed.Link 'Sagara.FeedReader.Feeds.BaseFeed.Link')** `Property` The link (url) to the feed
  - **[OriginalFeedXml](Sagara.FeedReader.Feeds.BaseFeed.md#Sagara.FeedReader.Feeds.BaseFeed.OriginalFeedXml 'Sagara.FeedReader.Feeds.BaseFeed.OriginalFeedXml')** `Property` The original feed XML string.
  - **[RootNamespaceDeclarations](Sagara.FeedReader.Feeds.BaseFeed.md#Sagara.FeedReader.Feeds.BaseFeed.RootNamespaceDeclarations 'Sagara.FeedReader.Feeds.BaseFeed.RootNamespaceDeclarations')** `Property` The root namespace declarations in the XML document. Key is the namespace attribute value (the namespace URI),   
    Value is the LocalName (the abbreviation, e.g., `itunes`) used to declare the namespace in the root element,  
    minus the `xmlns:` part.
  - **[Title](Sagara.FeedReader.Feeds.BaseFeed.md#Sagara.FeedReader.Feeds.BaseFeed.Title 'Sagara.FeedReader.Feeds.BaseFeed.Title')** `Property` The title of the feed
  - **[ToFeed()](Sagara.FeedReader.Feeds.BaseFeed.md#Sagara.FeedReader.Feeds.BaseFeed.ToFeed() 'Sagara.FeedReader.Feeds.BaseFeed.ToFeed()')** `Method` creates the generic [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') object.
- **[BaseFeedCategory](Sagara.FeedReader.Feeds.BaseFeedCategory.md 'Sagara.FeedReader.Feeds.BaseFeedCategory')** `Class` The base object for all feed categories. Since the RSS 2.0 and Atom `category` elements differ,  
  hydrating the object is done in feed-specific subclasses.
  - **[BaseFeedCategory()](Sagara.FeedReader.Feeds.BaseFeedCategory.md#Sagara.FeedReader.Feeds.BaseFeedCategory.BaseFeedCategory() 'Sagara.FeedReader.Feeds.BaseFeedCategory.BaseFeedCategory()')** `Constructor` Initializes a new instance of the [BaseFeedCategory](Sagara.FeedReader.Feeds.BaseFeedCategory.md 'Sagara.FeedReader.Feeds.BaseFeedCategory') class.  
    default constructor (for serialization)
  - **[CategoryElement](Sagara.FeedReader.Feeds.BaseFeedCategory.md#Sagara.FeedReader.Feeds.BaseFeedCategory.CategoryElement 'Sagara.FeedReader.Feeds.BaseFeedCategory.CategoryElement')** `Property` The `Category` (RSS) or `entry` (Atom) element from the feed. Return as an XElement in order to   
    allow reading properties that are not available as first-class properties in the derived class itself.
- **[BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem')** `Class` The base object for all feed items
  - **[BaseFeedItem()](Sagara.FeedReader.Feeds.BaseFeedItem.md#Sagara.FeedReader.Feeds.BaseFeedItem.BaseFeedItem() 'Sagara.FeedReader.Feeds.BaseFeedItem.BaseFeedItem()')** `Constructor` Initializes a new instance of the [BaseFeedItem](Sagara.FeedReader.Feeds.BaseFeedItem.md 'Sagara.FeedReader.Feeds.BaseFeedItem') class.  
    default constructor (for serialization)
  - **[ItemOrEntryElement](Sagara.FeedReader.Feeds.BaseFeedItem.md#Sagara.FeedReader.Feeds.BaseFeedItem.ItemOrEntryElement 'Sagara.FeedReader.Feeds.BaseFeedItem.ItemOrEntryElement')** `Property` The `item` (RSS) or `entry` (Atom) element from the feed. Return as an XElement in order to   
    allow reading properties that are not available as first-class properties in the derived class itself.
  - **[Link](Sagara.FeedReader.Feeds.BaseFeedItem.md#Sagara.FeedReader.Feeds.BaseFeedItem.Link 'Sagara.FeedReader.Feeds.BaseFeedItem.Link')** `Property` The "link" element
  - **[Title](Sagara.FeedReader.Feeds.BaseFeedItem.md#Sagara.FeedReader.Feeds.BaseFeedItem.Title 'Sagara.FeedReader.Feeds.BaseFeedItem.Title')** `Property` The "title" element
- **[DublinCore](Sagara.FeedReader.Feeds.DublinCore.md 'Sagara.FeedReader.Feeds.DublinCore')** `Class` The parsed "dc:" elements in a feed
  - **[DublinCore()](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.DublinCore() 'Sagara.FeedReader.Feeds.DublinCore.DublinCore()')** `Constructor` Initializes a new instance of the [DublinCore](Sagara.FeedReader.Feeds.DublinCore.md 'Sagara.FeedReader.Feeds.DublinCore') class.  
    default constructor (for serialization)
  - **[Contributor](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Contributor 'Sagara.FeedReader.Feeds.DublinCore.Contributor')** `Property` The "contributor" element
  - **[Coverage](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Coverage 'Sagara.FeedReader.Feeds.DublinCore.Coverage')** `Property` The "coverage" element
  - **[Creator](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Creator 'Sagara.FeedReader.Feeds.DublinCore.Creator')** `Property` The "creator" element
  - **[Date](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Date 'Sagara.FeedReader.Feeds.DublinCore.Date')** `Property` The "date" element as datetime. Null if parsing failed or date is empty.
  - **[DateString](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.DateString 'Sagara.FeedReader.Feeds.DublinCore.DateString')** `Property` The "date" element
  - **[Description](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Description 'Sagara.FeedReader.Feeds.DublinCore.Description')** `Property` The "description" field
  - **[Format](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Format 'Sagara.FeedReader.Feeds.DublinCore.Format')** `Property` The "format" element
  - **[Identifier](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Identifier 'Sagara.FeedReader.Feeds.DublinCore.Identifier')** `Property` The "identifier" element
  - **[Language](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Language 'Sagara.FeedReader.Feeds.DublinCore.Language')** `Property` The "language" element
  - **[Publisher](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Publisher 'Sagara.FeedReader.Feeds.DublinCore.Publisher')** `Property` The "publisher" element
  - **[Relation](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Relation 'Sagara.FeedReader.Feeds.DublinCore.Relation')** `Property` The "rel" element
  - **[Rights](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Rights 'Sagara.FeedReader.Feeds.DublinCore.Rights')** `Property` The "rights" element
  - **[Source](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Source 'Sagara.FeedReader.Feeds.DublinCore.Source')** `Property` The "source" element
  - **[Subject](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Subject 'Sagara.FeedReader.Feeds.DublinCore.Subject')** `Property` The "subject" element
  - **[Title](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Title 'Sagara.FeedReader.Feeds.DublinCore.Title')** `Property` The "title" element
  - **[Type](Sagara.FeedReader.Feeds.DublinCore.md#Sagara.FeedReader.Feeds.DublinCore.Type 'Sagara.FeedReader.Feeds.DublinCore.Type')** `Property` The "type" element
- **[FeedCloud](Sagara.FeedReader.Feeds.FeedCloud.md 'Sagara.FeedReader.Feeds.FeedCloud')** `Class` Cloud object according to Rss 2.0 specification: https://validator.w3.org/feed/docs/rss2.html#ltcloudgtSubelementOfLtchannelgt
  - **[FeedCloud()](Sagara.FeedReader.Feeds.FeedCloud.md#Sagara.FeedReader.Feeds.FeedCloud.FeedCloud() 'Sagara.FeedReader.Feeds.FeedCloud.FeedCloud()')** `Constructor` Initializes a new instance of the [FeedCloud](Sagara.FeedReader.Feeds.FeedCloud.md 'Sagara.FeedReader.Feeds.FeedCloud') class.  
    default constructor (for serialization)
  - **[Domain](Sagara.FeedReader.Feeds.FeedCloud.md#Sagara.FeedReader.Feeds.FeedCloud.Domain 'Sagara.FeedReader.Feeds.FeedCloud.Domain')** `Property` The "domain" element
  - **[Path](Sagara.FeedReader.Feeds.FeedCloud.md#Sagara.FeedReader.Feeds.FeedCloud.Path 'Sagara.FeedReader.Feeds.FeedCloud.Path')** `Property` The "path" element
  - **[Port](Sagara.FeedReader.Feeds.FeedCloud.md#Sagara.FeedReader.Feeds.FeedCloud.Port 'Sagara.FeedReader.Feeds.FeedCloud.Port')** `Property` The "port" element
  - **[Protocol](Sagara.FeedReader.Feeds.FeedCloud.md#Sagara.FeedReader.Feeds.FeedCloud.Protocol 'Sagara.FeedReader.Feeds.FeedCloud.Protocol')** `Property` The "protocol" element
  - **[RegisterProcedure](Sagara.FeedReader.Feeds.FeedCloud.md#Sagara.FeedReader.Feeds.FeedCloud.RegisterProcedure 'Sagara.FeedReader.Feeds.FeedCloud.RegisterProcedure')** `Property` The "registerProcedure" element
- **[FeedImage](Sagara.FeedReader.Feeds.FeedImage.md 'Sagara.FeedReader.Feeds.FeedImage')** `Class` feed image object that is used in feed (rss 0.91, 2.0, atom, ...)
  - **[FeedImage()](Sagara.FeedReader.Feeds.FeedImage.md#Sagara.FeedReader.Feeds.FeedImage.FeedImage() 'Sagara.FeedReader.Feeds.FeedImage.FeedImage()')** `Constructor` Initializes a new instance of the [FeedImage](Sagara.FeedReader.Feeds.FeedImage.md 'Sagara.FeedReader.Feeds.FeedImage') class.  
    default constructor (for serialization)
  - **[Link](Sagara.FeedReader.Feeds.FeedImage.md#Sagara.FeedReader.Feeds.FeedImage.Link 'Sagara.FeedReader.Feeds.FeedImage.Link')** `Property` The "link" element
  - **[Title](Sagara.FeedReader.Feeds.FeedImage.md#Sagara.FeedReader.Feeds.FeedImage.Title 'Sagara.FeedReader.Feeds.FeedImage.Title')** `Property` The "title" element
  - **[Url](Sagara.FeedReader.Feeds.FeedImage.md#Sagara.FeedReader.Feeds.FeedImage.Url 'Sagara.FeedReader.Feeds.FeedImage.Url')** `Property` The "url" element
- **[FeedItemEnclosure](Sagara.FeedReader.Feeds.FeedItemEnclosure.md 'Sagara.FeedReader.Feeds.FeedItemEnclosure')** `Class` Enclosure object of Rss 2.0 according to specification: https://validator.w3.org/feed/docs/rss2.html
  - **[FeedItemEnclosure()](Sagara.FeedReader.Feeds.FeedItemEnclosure.md#Sagara.FeedReader.Feeds.FeedItemEnclosure.FeedItemEnclosure() 'Sagara.FeedReader.Feeds.FeedItemEnclosure.FeedItemEnclosure()')** `Constructor` Initializes a new instance of the [FeedItemEnclosure](Sagara.FeedReader.Feeds.FeedItemEnclosure.md 'Sagara.FeedReader.Feeds.FeedItemEnclosure') class.  
    default constructor (for serialization)
  - **[Length](Sagara.FeedReader.Feeds.FeedItemEnclosure.md#Sagara.FeedReader.Feeds.FeedItemEnclosure.Length 'Sagara.FeedReader.Feeds.FeedItemEnclosure.Length')** `Property` The "length" element as int
  - **[MediaType](Sagara.FeedReader.Feeds.FeedItemEnclosure.md#Sagara.FeedReader.Feeds.FeedItemEnclosure.MediaType 'Sagara.FeedReader.Feeds.FeedItemEnclosure.MediaType')** `Property` The "type" element
  - **[Url](Sagara.FeedReader.Feeds.FeedItemEnclosure.md#Sagara.FeedReader.Feeds.FeedItemEnclosure.Url 'Sagara.FeedReader.Feeds.FeedItemEnclosure.Url')** `Property` The "url" element
- **[FeedItemSource](Sagara.FeedReader.Feeds.FeedItemSource.md 'Sagara.FeedReader.Feeds.FeedItemSource')** `Class` item source object from rss 2.0 according to specification: https://validator.w3.org/feed/docs/rss2.html
  - **[FeedItemSource()](Sagara.FeedReader.Feeds.FeedItemSource.md#Sagara.FeedReader.Feeds.FeedItemSource.FeedItemSource() 'Sagara.FeedReader.Feeds.FeedItemSource.FeedItemSource()')** `Constructor` Initializes a new instance of the [FeedItemSource](Sagara.FeedReader.Feeds.FeedItemSource.md 'Sagara.FeedReader.Feeds.FeedItemSource') class.  
    default constructor (for serialization)
  - **[Url](Sagara.FeedReader.Feeds.FeedItemSource.md#Sagara.FeedReader.Feeds.FeedItemSource.Url 'Sagara.FeedReader.Feeds.FeedItemSource.Url')** `Property` The "url" element
  - **[Value](Sagara.FeedReader.Feeds.FeedItemSource.md#Sagara.FeedReader.Feeds.FeedItemSource.Value 'Sagara.FeedReader.Feeds.FeedItemSource.Value')** `Property` The value of the element
- **[FeedTextInput](Sagara.FeedReader.Feeds.FeedTextInput.md 'Sagara.FeedReader.Feeds.FeedTextInput')** `Class` default text input object for Rss 0.91, 0.92, 1.0, 2.0 and ATOM
  - **[FeedTextInput()](Sagara.FeedReader.Feeds.FeedTextInput.md#Sagara.FeedReader.Feeds.FeedTextInput.FeedTextInput() 'Sagara.FeedReader.Feeds.FeedTextInput.FeedTextInput()')** `Constructor` Initializes a new instance of the [FeedTextInput](Sagara.FeedReader.Feeds.FeedTextInput.md 'Sagara.FeedReader.Feeds.FeedTextInput') class.  
    default constructor (for serialization)
  - **[Description](Sagara.FeedReader.Feeds.FeedTextInput.md#Sagara.FeedReader.Feeds.FeedTextInput.Description 'Sagara.FeedReader.Feeds.FeedTextInput.Description')** `Property` The "description" field
  - **[Link](Sagara.FeedReader.Feeds.FeedTextInput.md#Sagara.FeedReader.Feeds.FeedTextInput.Link 'Sagara.FeedReader.Feeds.FeedTextInput.Link')** `Property` The "link" element
  - **[Name](Sagara.FeedReader.Feeds.FeedTextInput.md#Sagara.FeedReader.Feeds.FeedTextInput.Name 'Sagara.FeedReader.Feeds.FeedTextInput.Name')** `Property` The "name" element
  - **[Title](Sagara.FeedReader.Feeds.FeedTextInput.md#Sagara.FeedReader.Feeds.FeedTextInput.Title 'Sagara.FeedReader.Feeds.FeedTextInput.Title')** `Property` The "title" element
- **[MediaRssFeed](Sagara.FeedReader.Feeds.MediaRssFeed.md 'Sagara.FeedReader.Feeds.MediaRssFeed')** `Class` Media RSS 2.0 feed according to specification: http://www.rssboard.org/media-rss
  - **[MediaRssFeed()](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.MediaRssFeed() 'Sagara.FeedReader.Feeds.MediaRssFeed.MediaRssFeed()')** `Constructor` Initializes a new instance of the [MediaRssFeed](Sagara.FeedReader.Feeds.MediaRssFeed.md 'Sagara.FeedReader.Feeds.MediaRssFeed') class.  
    default constructor (for serialization)
  - **[Categories](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.Categories 'Sagara.FeedReader.Feeds.MediaRssFeed.Categories')** `Property` All "category" elements
  - **[Cloud](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.Cloud 'Sagara.FeedReader.Feeds.MediaRssFeed.Cloud')** `Property` The "cloud" element
  - **[Copyright](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.Copyright 'Sagara.FeedReader.Feeds.MediaRssFeed.Copyright')** `Property` The "copyright" element
  - **[Description](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.Description 'Sagara.FeedReader.Feeds.MediaRssFeed.Description')** `Property` The "description" element
  - **[Docs](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.Docs 'Sagara.FeedReader.Feeds.MediaRssFeed.Docs')** `Property` The "docs" element
  - **[Generator](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.Generator 'Sagara.FeedReader.Feeds.MediaRssFeed.Generator')** `Property` The "generator" element
  - **[Image](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.Image 'Sagara.FeedReader.Feeds.MediaRssFeed.Image')** `Property` The "image" element
  - **[Language](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.Language 'Sagara.FeedReader.Feeds.MediaRssFeed.Language')** `Property` The "language" element
  - **[LastBuildDate](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.LastBuildDate 'Sagara.FeedReader.Feeds.MediaRssFeed.LastBuildDate')** `Property` The "lastBuildDate" element as DateTime. Null if parsing failed of lastBuildDate is empty.
  - **[LastBuildDateString](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.LastBuildDateString 'Sagara.FeedReader.Feeds.MediaRssFeed.LastBuildDateString')** `Property` The "lastBuildDate" element as string
  - **[ManagingEditor](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.ManagingEditor 'Sagara.FeedReader.Feeds.MediaRssFeed.ManagingEditor')** `Property` The "managingEditor" element
  - **[PublishingDate](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.PublishingDate 'Sagara.FeedReader.Feeds.MediaRssFeed.PublishingDate')** `Property` The "pubDate" field as DateTime. Null if parsing failed or pubDate is empty.
  - **[PublishingDateString](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.PublishingDateString 'Sagara.FeedReader.Feeds.MediaRssFeed.PublishingDateString')** `Property` The "pubDate" field
  - **[SkipDays](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.SkipDays 'Sagara.FeedReader.Feeds.MediaRssFeed.SkipDays')** `Property` All "day" elements in "skipDays"
  - **[SkipHours](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.SkipHours 'Sagara.FeedReader.Feeds.MediaRssFeed.SkipHours')** `Property` All "hour" elements in "skipHours"
  - **[Sy](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.Sy 'Sagara.FeedReader.Feeds.MediaRssFeed.Sy')** `Property` All elements starting with "sy:"
  - **[TextInput](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.TextInput 'Sagara.FeedReader.Feeds.MediaRssFeed.TextInput')** `Property` The "textInput" element
  - **[TTL](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.TTL 'Sagara.FeedReader.Feeds.MediaRssFeed.TTL')** `Property` The time to life "ttl" element
  - **[WebMaster](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.WebMaster 'Sagara.FeedReader.Feeds.MediaRssFeed.WebMaster')** `Property` The "webMaster" field
  - **[ToFeed()](Sagara.FeedReader.Feeds.MediaRssFeed.md#Sagara.FeedReader.Feeds.MediaRssFeed.ToFeed() 'Sagara.FeedReader.Feeds.MediaRssFeed.ToFeed()')** `Method` Creates the base [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') element out of this feed.
- **[MediaRssFeedImage](Sagara.FeedReader.Feeds.MediaRssFeedImage.md 'Sagara.FeedReader.Feeds.MediaRssFeedImage')** `Class` Rss 2.0 Image according to specification: https://validator.w3.org/feed/docs/rss2.html#ltimagegtSubelementOfLtchannelgt
  - **[MediaRssFeedImage()](Sagara.FeedReader.Feeds.MediaRssFeedImage.md#Sagara.FeedReader.Feeds.MediaRssFeedImage.MediaRssFeedImage() 'Sagara.FeedReader.Feeds.MediaRssFeedImage.MediaRssFeedImage()')** `Constructor` Initializes a new instance of the [MediaRssFeedImage](Sagara.FeedReader.Feeds.MediaRssFeedImage.md 'Sagara.FeedReader.Feeds.MediaRssFeedImage') class.  
    default constructor (for serialization)
- **[MediaRssFeedItem](Sagara.FeedReader.Feeds.MediaRssFeedItem.md 'Sagara.FeedReader.Feeds.MediaRssFeedItem')** `Class` RSS 2.0 feed item according to specification: https://validator.w3.org/feed/docs/rss2.html
  - **[MediaRssFeedItem()](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.MediaRssFeedItem() 'Sagara.FeedReader.Feeds.MediaRssFeedItem.MediaRssFeedItem()')** `Constructor` Initializes a new instance of the [MediaRssFeedItem](Sagara.FeedReader.Feeds.MediaRssFeedItem.md 'Sagara.FeedReader.Feeds.MediaRssFeedItem') class.  
    default constructor (for serialization)
  - **[Author](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.Author 'Sagara.FeedReader.Feeds.MediaRssFeedItem.Author')** `Property` The "author" field of the feed item
  - **[Categories](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.Categories 'Sagara.FeedReader.Feeds.MediaRssFeedItem.Categories')** `Property` All entries "category" entries
  - **[Comments](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.Comments 'Sagara.FeedReader.Feeds.MediaRssFeedItem.Comments')** `Property` The "comments" field of the feed item
  - **[Content](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.Content 'Sagara.FeedReader.Feeds.MediaRssFeedItem.Content')** `Property` The "content:encoded" field
  - **[DC](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.DC 'Sagara.FeedReader.Feeds.MediaRssFeedItem.DC')** `Property` All elements starting with "dc:"
  - **[Description](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.Description 'Sagara.FeedReader.Feeds.MediaRssFeedItem.Description')** `Property` The "description" field of the feed item
  - **[Enclosure](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.Enclosure 'Sagara.FeedReader.Feeds.MediaRssFeedItem.Enclosure')** `Property` The "enclosure" field
  - **[Guid](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.Guid 'Sagara.FeedReader.Feeds.MediaRssFeedItem.Guid')** `Property` The "guid" field
  - **[Media](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.Media 'Sagara.FeedReader.Feeds.MediaRssFeedItem.Media')** `Property` All entries from the "media:content" elements.
  - **[MediaGroups](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.MediaGroups 'Sagara.FeedReader.Feeds.MediaRssFeedItem.MediaGroups')** `Property` All entries from the "media:group" elements.
  - **[PublishingDate](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.PublishingDate 'Sagara.FeedReader.Feeds.MediaRssFeedItem.PublishingDate')** `Property` The "pubDate" field as DateTime. Null if parsing failed or pubDate is empty.
  - **[PublishingDateString](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.PublishingDateString 'Sagara.FeedReader.Feeds.MediaRssFeedItem.PublishingDateString')** `Property` The "pubDate" field
  - **[Source](Sagara.FeedReader.Feeds.MediaRssFeedItem.md#Sagara.FeedReader.Feeds.MediaRssFeedItem.Source 'Sagara.FeedReader.Feeds.MediaRssFeedItem.Source')** `Property` The "source" field
- **[Namespaces](Sagara.FeedReader.Feeds.Namespaces.md 'Sagara.FeedReader.Feeds.Namespaces')** `Class` XML namespace URIs.
  - **[ApplePodcasts](Sagara.FeedReader.Feeds.Namespaces.md#Sagara.FeedReader.Feeds.Namespaces.ApplePodcasts 'Sagara.FeedReader.Feeds.Namespaces.ApplePodcasts')** `Field` The namespace for Apple Podcasts elements, typically denoted by the prefix `itunes` on the  
    root element.
  - **[Atom](Sagara.FeedReader.Feeds.Namespaces.md#Sagara.FeedReader.Feeds.Namespaces.Atom 'Sagara.FeedReader.Feeds.Namespaces.Atom')** `Field` The Atom namespace as an XNamespace.
- **[Rss091Feed](Sagara.FeedReader.Feeds.Rss091Feed.md 'Sagara.FeedReader.Feeds.Rss091Feed')** `Class` Rss Feed according to Rss 0.91 specification:  
  http://www.rssboard.org/rss-0-9-1-netscape
  - **[Rss091Feed()](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.Rss091Feed() 'Sagara.FeedReader.Feeds.Rss091Feed.Rss091Feed()')** `Constructor` Initializes a new instance of the [Rss091Feed](Sagara.FeedReader.Feeds.Rss091Feed.md 'Sagara.FeedReader.Feeds.Rss091Feed') class.  
    default constructor (for serialization)
  - **[Copyright](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.Copyright 'Sagara.FeedReader.Feeds.Rss091Feed.Copyright')** `Property` The "copyright" field
  - **[Description](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.Description 'Sagara.FeedReader.Feeds.Rss091Feed.Description')** `Property` The required field "description"
  - **[Docs](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.Docs 'Sagara.FeedReader.Feeds.Rss091Feed.Docs')** `Property` The "docs" field
  - **[Image](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.Image 'Sagara.FeedReader.Feeds.Rss091Feed.Image')** `Property` The "image" element
  - **[Language](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.Language 'Sagara.FeedReader.Feeds.Rss091Feed.Language')** `Property` The required field "language"  
    ///
  - **[LastBuildDate](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.LastBuildDate 'Sagara.FeedReader.Feeds.Rss091Feed.LastBuildDate')** `Property` The "lastBuildDate" as DateTime. Null if parsing failed or lastBuildDate is empty.
  - **[LastBuildDateString](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.LastBuildDateString 'Sagara.FeedReader.Feeds.Rss091Feed.LastBuildDateString')** `Property` The "lastBuildDate" element
  - **[ManagingEditor](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.ManagingEditor 'Sagara.FeedReader.Feeds.Rss091Feed.ManagingEditor')** `Property` The "managingEditor" field
  - **[PublishingDate](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.PublishingDate 'Sagara.FeedReader.Feeds.Rss091Feed.PublishingDate')** `Property` The "pubDate" field as DateTime. Null if parsing failed or pubDate is empty.
  - **[PublishingDateString](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.PublishingDateString 'Sagara.FeedReader.Feeds.Rss091Feed.PublishingDateString')** `Property` The "pubDate" field
  - **[Rating](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.Rating 'Sagara.FeedReader.Feeds.Rss091Feed.Rating')** `Property` The "rating" field
  - **[SkipDays](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.SkipDays 'Sagara.FeedReader.Feeds.Rss091Feed.SkipDays')** `Property` All "day" elements in "skipDays"
  - **[SkipHours](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.SkipHours 'Sagara.FeedReader.Feeds.Rss091Feed.SkipHours')** `Property` All "hour" elements in "skipHours"
  - **[Sy](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.Sy 'Sagara.FeedReader.Feeds.Rss091Feed.Sy')** `Property` All elements that start with "sy:"
  - **[TextInput](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.TextInput 'Sagara.FeedReader.Feeds.Rss091Feed.TextInput')** `Property` The "textInput" element
  - **[WebMaster](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.WebMaster 'Sagara.FeedReader.Feeds.Rss091Feed.WebMaster')** `Property` The "webMaster" element
  - **[ToFeed()](Sagara.FeedReader.Feeds.Rss091Feed.md#Sagara.FeedReader.Feeds.Rss091Feed.ToFeed() 'Sagara.FeedReader.Feeds.Rss091Feed.ToFeed()')** `Method` Creates the base [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') element out of this feed.
- **[Rss091FeedImage](Sagara.FeedReader.Feeds.Rss091FeedImage.md 'Sagara.FeedReader.Feeds.Rss091FeedImage')** `Class` Rss 0.91 Feed Image according to specification: http://www.rssboard.org/rss-0-9-1-netscape#image
  - **[Rss091FeedImage()](Sagara.FeedReader.Feeds.Rss091FeedImage.md#Sagara.FeedReader.Feeds.Rss091FeedImage.Rss091FeedImage() 'Sagara.FeedReader.Feeds.Rss091FeedImage.Rss091FeedImage()')** `Constructor` Initializes a new instance of the [Rss091FeedImage](Sagara.FeedReader.Feeds.Rss091FeedImage.md 'Sagara.FeedReader.Feeds.Rss091FeedImage') class.  
    default constructor (for serialization)
  - **[Description](Sagara.FeedReader.Feeds.Rss091FeedImage.md#Sagara.FeedReader.Feeds.Rss091FeedImage.Description 'Sagara.FeedReader.Feeds.Rss091FeedImage.Description')** `Property` The "description" element
  - **[Height](Sagara.FeedReader.Feeds.Rss091FeedImage.md#Sagara.FeedReader.Feeds.Rss091FeedImage.Height 'Sagara.FeedReader.Feeds.Rss091FeedImage.Height')** `Property` The "height" element
  - **[Width](Sagara.FeedReader.Feeds.Rss091FeedImage.md#Sagara.FeedReader.Feeds.Rss091FeedImage.Width 'Sagara.FeedReader.Feeds.Rss091FeedImage.Width')** `Property` The "width" element
- **[Rss091FeedItem](Sagara.FeedReader.Feeds.Rss091FeedItem.md 'Sagara.FeedReader.Feeds.Rss091FeedItem')** `Class` Rss 0.91 Feed Item according to specification: http://www.rssboard.org/rss-0-9-1-netscape#image
  - **[Rss091FeedItem()](Sagara.FeedReader.Feeds.Rss091FeedItem.md#Sagara.FeedReader.Feeds.Rss091FeedItem.Rss091FeedItem() 'Sagara.FeedReader.Feeds.Rss091FeedItem.Rss091FeedItem()')** `Constructor` Initializes a new instance of the [Rss091FeedItem](Sagara.FeedReader.Feeds.Rss091FeedItem.md 'Sagara.FeedReader.Feeds.Rss091FeedItem') class.  
    default constructor (for serialization)
  - **[Description](Sagara.FeedReader.Feeds.Rss091FeedItem.md#Sagara.FeedReader.Feeds.Rss091FeedItem.Description 'Sagara.FeedReader.Feeds.Rss091FeedItem.Description')** `Property` The "description" field
  - **[PublishingDate](Sagara.FeedReader.Feeds.Rss091FeedItem.md#Sagara.FeedReader.Feeds.Rss091FeedItem.PublishingDate 'Sagara.FeedReader.Feeds.Rss091FeedItem.PublishingDate')** `Property` The "pubDate" field as DateTime. Null if parsing failed or pubDate is empty.
  - **[PublishingDateString](Sagara.FeedReader.Feeds.Rss091FeedItem.md#Sagara.FeedReader.Feeds.Rss091FeedItem.PublishingDateString 'Sagara.FeedReader.Feeds.Rss091FeedItem.PublishingDateString')** `Property` The "pubDate" field
- **[Rss092Feed](Sagara.FeedReader.Feeds.Rss092Feed.md 'Sagara.FeedReader.Feeds.Rss092Feed')** `Class` Rss 0.92 feed according to specification: http://backend.userland.com/rss092
  - **[Rss092Feed()](Sagara.FeedReader.Feeds.Rss092Feed.md#Sagara.FeedReader.Feeds.Rss092Feed.Rss092Feed() 'Sagara.FeedReader.Feeds.Rss092Feed.Rss092Feed()')** `Constructor` Initializes a new instance of the [Rss092Feed](Sagara.FeedReader.Feeds.Rss092Feed.md 'Sagara.FeedReader.Feeds.Rss092Feed') class.  
    default constructor (for serialization)
  - **[Cloud](Sagara.FeedReader.Feeds.Rss092Feed.md#Sagara.FeedReader.Feeds.Rss092Feed.Cloud 'Sagara.FeedReader.Feeds.Rss092Feed.Cloud')** `Property` The "cloud" field
  - **[ToFeed()](Sagara.FeedReader.Feeds.Rss092Feed.md#Sagara.FeedReader.Feeds.Rss092Feed.ToFeed() 'Sagara.FeedReader.Feeds.Rss092Feed.ToFeed()')** `Method` Creates the base [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') element out of this feed.
- **[Rss092FeedImage](Sagara.FeedReader.Feeds.Rss092FeedImage.md 'Sagara.FeedReader.Feeds.Rss092FeedImage')** `Class` Rss 0.92 Feed Image according to specification: http://backend.userland.com/rss092
  - **[Rss092FeedImage()](Sagara.FeedReader.Feeds.Rss092FeedImage.md#Sagara.FeedReader.Feeds.Rss092FeedImage.Rss092FeedImage() 'Sagara.FeedReader.Feeds.Rss092FeedImage.Rss092FeedImage()')** `Constructor` Initializes a new instance of the [Rss092FeedImage](Sagara.FeedReader.Feeds.Rss092FeedImage.md 'Sagara.FeedReader.Feeds.Rss092FeedImage') class.  
    default constructor (for serialization)
- **[Rss092FeedItem](Sagara.FeedReader.Feeds.Rss092FeedItem.md 'Sagara.FeedReader.Feeds.Rss092FeedItem')** `Class` Rss 0.92 feed item according to specification: http://backend.userland.com/rss092
  - **[Rss092FeedItem()](Sagara.FeedReader.Feeds.Rss092FeedItem.md#Sagara.FeedReader.Feeds.Rss092FeedItem.Rss092FeedItem() 'Sagara.FeedReader.Feeds.Rss092FeedItem.Rss092FeedItem()')** `Constructor` Initializes a new instance of the [Rss092FeedItem](Sagara.FeedReader.Feeds.Rss092FeedItem.md 'Sagara.FeedReader.Feeds.Rss092FeedItem') class.  
    default constructor (for serialization)
  - **[Categories](Sagara.FeedReader.Feeds.Rss092FeedItem.md#Sagara.FeedReader.Feeds.Rss092FeedItem.Categories 'Sagara.FeedReader.Feeds.Rss092FeedItem.Categories')** `Property` All entries "category" entries
  - **[Enclosure](Sagara.FeedReader.Feeds.Rss092FeedItem.md#Sagara.FeedReader.Feeds.Rss092FeedItem.Enclosure 'Sagara.FeedReader.Feeds.Rss092FeedItem.Enclosure')** `Property` The "enclosure" field
  - **[Source](Sagara.FeedReader.Feeds.Rss092FeedItem.md#Sagara.FeedReader.Feeds.Rss092FeedItem.Source 'Sagara.FeedReader.Feeds.Rss092FeedItem.Source')** `Property` The "source" field
- **[Rss10Feed](Sagara.FeedReader.Feeds.Rss10Feed.md 'Sagara.FeedReader.Feeds.Rss10Feed')** `Class` Rss 1.0 Feed according to specification: http://web.resource.org/rss/1.0/spec
  - **[Rss10Feed()](Sagara.FeedReader.Feeds.Rss10Feed.md#Sagara.FeedReader.Feeds.Rss10Feed.Rss10Feed() 'Sagara.FeedReader.Feeds.Rss10Feed.Rss10Feed()')** `Constructor` Initializes a new instance of the [Rss10Feed](Sagara.FeedReader.Feeds.Rss10Feed.md 'Sagara.FeedReader.Feeds.Rss10Feed') class.  
    default constructor (for serialization)
  - **[About](Sagara.FeedReader.Feeds.Rss10Feed.md#Sagara.FeedReader.Feeds.Rss10Feed.About 'Sagara.FeedReader.Feeds.Rss10Feed.About')** `Property` The "about" attribute of the element
  - **[DC](Sagara.FeedReader.Feeds.Rss10Feed.md#Sagara.FeedReader.Feeds.Rss10Feed.DC 'Sagara.FeedReader.Feeds.Rss10Feed.DC')** `Property` All elements starting with "dc:"
  - **[Description](Sagara.FeedReader.Feeds.Rss10Feed.md#Sagara.FeedReader.Feeds.Rss10Feed.Description 'Sagara.FeedReader.Feeds.Rss10Feed.Description')** `Property` The "description" field
  - **[Image](Sagara.FeedReader.Feeds.Rss10Feed.md#Sagara.FeedReader.Feeds.Rss10Feed.Image 'Sagara.FeedReader.Feeds.Rss10Feed.Image')** `Property` The "image" element
  - **[Sy](Sagara.FeedReader.Feeds.Rss10Feed.md#Sagara.FeedReader.Feeds.Rss10Feed.Sy 'Sagara.FeedReader.Feeds.Rss10Feed.Sy')** `Property` All elements starting with "sy:"
  - **[TextInput](Sagara.FeedReader.Feeds.Rss10Feed.md#Sagara.FeedReader.Feeds.Rss10Feed.TextInput 'Sagara.FeedReader.Feeds.Rss10Feed.TextInput')** `Property` The "textInput" element
  - **[ToFeed()](Sagara.FeedReader.Feeds.Rss10Feed.md#Sagara.FeedReader.Feeds.Rss10Feed.ToFeed() 'Sagara.FeedReader.Feeds.Rss10Feed.ToFeed()')** `Method` Creates the base [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') element out of this feed.
- **[Rss10FeedImage](Sagara.FeedReader.Feeds.Rss10FeedImage.md 'Sagara.FeedReader.Feeds.Rss10FeedImage')** `Class` Rss 1.0 Feed image according to specification: http://web.resource.org/rss/1.0/spec
  - **[Rss10FeedImage()](Sagara.FeedReader.Feeds.Rss10FeedImage.md#Sagara.FeedReader.Feeds.Rss10FeedImage.Rss10FeedImage() 'Sagara.FeedReader.Feeds.Rss10FeedImage.Rss10FeedImage()')** `Constructor` Initializes a new instance of the [Rss10FeedImage](Sagara.FeedReader.Feeds.Rss10FeedImage.md 'Sagara.FeedReader.Feeds.Rss10FeedImage') class.  
    default constructor (for serialization)
  - **[About](Sagara.FeedReader.Feeds.Rss10FeedImage.md#Sagara.FeedReader.Feeds.Rss10FeedImage.About 'Sagara.FeedReader.Feeds.Rss10FeedImage.About')** `Property` The "about" attribute of the element
- **[Rss10FeedItem](Sagara.FeedReader.Feeds.Rss10FeedItem.md 'Sagara.FeedReader.Feeds.Rss10FeedItem')** `Class` Rss 1.0 Feed Item according to specification: http://web.resource.org/rss/1.0/spec
  - **[Rss10FeedItem()](Sagara.FeedReader.Feeds.Rss10FeedItem.md#Sagara.FeedReader.Feeds.Rss10FeedItem.Rss10FeedItem() 'Sagara.FeedReader.Feeds.Rss10FeedItem.Rss10FeedItem()')** `Constructor` Initializes a new instance of the [Rss10FeedItem](Sagara.FeedReader.Feeds.Rss10FeedItem.md 'Sagara.FeedReader.Feeds.Rss10FeedItem') class.  
    default constructor (for serialization)
  - **[About](Sagara.FeedReader.Feeds.Rss10FeedItem.md#Sagara.FeedReader.Feeds.Rss10FeedItem.About 'Sagara.FeedReader.Feeds.Rss10FeedItem.About')** `Property` The "about" attribute of the element
  - **[DC](Sagara.FeedReader.Feeds.Rss10FeedItem.md#Sagara.FeedReader.Feeds.Rss10FeedItem.DC 'Sagara.FeedReader.Feeds.Rss10FeedItem.DC')** `Property` All elements starting with "dc:"
  - **[Description](Sagara.FeedReader.Feeds.Rss10FeedItem.md#Sagara.FeedReader.Feeds.Rss10FeedItem.Description 'Sagara.FeedReader.Feeds.Rss10FeedItem.Description')** `Property` The "description" field
  - **[Sy](Sagara.FeedReader.Feeds.Rss10FeedItem.md#Sagara.FeedReader.Feeds.Rss10FeedItem.Sy 'Sagara.FeedReader.Feeds.Rss10FeedItem.Sy')** `Property` All elements starting with "sy:"
- **[Rss10FeedTextInput](Sagara.FeedReader.Feeds.Rss10FeedTextInput.md 'Sagara.FeedReader.Feeds.Rss10FeedTextInput')** `Class` Rss 1.0 Feed textinput according to specification: http://web.resource.org/rss/1.0/spec
  - **[Rss10FeedTextInput()](Sagara.FeedReader.Feeds.Rss10FeedTextInput.md#Sagara.FeedReader.Feeds.Rss10FeedTextInput.Rss10FeedTextInput() 'Sagara.FeedReader.Feeds.Rss10FeedTextInput.Rss10FeedTextInput()')** `Constructor` Initializes a new instance of the [Rss10FeedTextInput](Sagara.FeedReader.Feeds.Rss10FeedTextInput.md 'Sagara.FeedReader.Feeds.Rss10FeedTextInput') class.  
    default constructor (for serialization)
  - **[About](Sagara.FeedReader.Feeds.Rss10FeedTextInput.md#Sagara.FeedReader.Feeds.Rss10FeedTextInput.About 'Sagara.FeedReader.Feeds.Rss10FeedTextInput.About')** `Property` The "about" attribute of the element
- **[Rss20Feed](Sagara.FeedReader.Feeds.Rss20Feed.md 'Sagara.FeedReader.Feeds.Rss20Feed')** `Class` RSS 2.0 feed according to specification: https://validator.w3.org/feed/docs/rss2.html
  - **[Rss20Feed()](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.Rss20Feed() 'Sagara.FeedReader.Feeds.Rss20Feed.Rss20Feed()')** `Constructor` Initializes a new instance of the [Rss20Feed](Sagara.FeedReader.Feeds.Rss20Feed.md 'Sagara.FeedReader.Feeds.Rss20Feed') class.  
    default constructor (for serialization)
  - **[Categories](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.Categories 'Sagara.FeedReader.Feeds.Rss20Feed.Categories')** `Property` All "category" elements
  - **[Cloud](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.Cloud 'Sagara.FeedReader.Feeds.Rss20Feed.Cloud')** `Property` The "cloud" element
  - **[Copyright](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.Copyright 'Sagara.FeedReader.Feeds.Rss20Feed.Copyright')** `Property` The "copyright" element
  - **[Description](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.Description 'Sagara.FeedReader.Feeds.Rss20Feed.Description')** `Property` The "description" element
  - **[Docs](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.Docs 'Sagara.FeedReader.Feeds.Rss20Feed.Docs')** `Property` The "docs" element
  - **[Generator](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.Generator 'Sagara.FeedReader.Feeds.Rss20Feed.Generator')** `Property` The "generator" element
  - **[Image](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.Image 'Sagara.FeedReader.Feeds.Rss20Feed.Image')** `Property` The "image" element
  - **[Language](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.Language 'Sagara.FeedReader.Feeds.Rss20Feed.Language')** `Property` The "language" element
  - **[LastBuildDate](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.LastBuildDate 'Sagara.FeedReader.Feeds.Rss20Feed.LastBuildDate')** `Property` The "lastBuildDate" element as DateTime. Null if parsing failed of lastBuildDate is empty.
  - **[LastBuildDateString](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.LastBuildDateString 'Sagara.FeedReader.Feeds.Rss20Feed.LastBuildDateString')** `Property` The "lastBuildDate" element as string
  - **[ManagingEditor](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.ManagingEditor 'Sagara.FeedReader.Feeds.Rss20Feed.ManagingEditor')** `Property` The "managingEditor" element
  - **[PublishingDate](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.PublishingDate 'Sagara.FeedReader.Feeds.Rss20Feed.PublishingDate')** `Property` The "pubDate" field as DateTime. Null if parsing failed or pubDate is empty.
  - **[PublishingDateString](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.PublishingDateString 'Sagara.FeedReader.Feeds.Rss20Feed.PublishingDateString')** `Property` The "pubDate" field
  - **[SkipDays](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.SkipDays 'Sagara.FeedReader.Feeds.Rss20Feed.SkipDays')** `Property` All "day" elements in "skipDays"
  - **[SkipHours](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.SkipHours 'Sagara.FeedReader.Feeds.Rss20Feed.SkipHours')** `Property` All "hour" elements in "skipHours"
  - **[Sy](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.Sy 'Sagara.FeedReader.Feeds.Rss20Feed.Sy')** `Property` All elements starting with "sy:"
  - **[TextInput](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.TextInput 'Sagara.FeedReader.Feeds.Rss20Feed.TextInput')** `Property` The "textInput" element
  - **[TTL](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.TTL 'Sagara.FeedReader.Feeds.Rss20Feed.TTL')** `Property` The time to life "ttl" element
  - **[WebMaster](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.WebMaster 'Sagara.FeedReader.Feeds.Rss20Feed.WebMaster')** `Property` The "webMaster" field
  - **[ToFeed()](Sagara.FeedReader.Feeds.Rss20Feed.md#Sagara.FeedReader.Feeds.Rss20Feed.ToFeed() 'Sagara.FeedReader.Feeds.Rss20Feed.ToFeed()')** `Method` Creates the base [Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed') element out of this feed.
- **[Rss20FeedCategory](Sagara.FeedReader.Feeds.Rss20FeedCategory.md 'Sagara.FeedReader.Feeds.Rss20FeedCategory')** `Class` RSS 2.0 feed category according to specification: https://validator.w3.org/feed/docs/rss2.html
  - **[Rss20FeedCategory()](Sagara.FeedReader.Feeds.Rss20FeedCategory.md#Sagara.FeedReader.Feeds.Rss20FeedCategory.Rss20FeedCategory() 'Sagara.FeedReader.Feeds.Rss20FeedCategory.Rss20FeedCategory()')** `Constructor` Initializes a new instance of the [Rss20FeedCategory](Sagara.FeedReader.Feeds.Rss20FeedCategory.md 'Sagara.FeedReader.Feeds.Rss20FeedCategory') class.  
    default constructor (for serialization)
  - **[Content](Sagara.FeedReader.Feeds.Rss20FeedCategory.md#Sagara.FeedReader.Feeds.Rss20FeedCategory.Content 'Sagara.FeedReader.Feeds.Rss20FeedCategory.Content')** `Property` The category text pull from the tag's content.
  - **[Domain](Sagara.FeedReader.Feeds.Rss20FeedCategory.md#Sagara.FeedReader.Feeds.Rss20FeedCategory.Domain 'Sagara.FeedReader.Feeds.Rss20FeedCategory.Domain')** `Property` Optional. Identifies the taxonomy in which the category is placed. Comes from the domain attribute.
- **[Rss20FeedImage](Sagara.FeedReader.Feeds.Rss20FeedImage.md 'Sagara.FeedReader.Feeds.Rss20FeedImage')** `Class` Rss 2.0 Image according to specification: https://validator.w3.org/feed/docs/rss2.html#ltimagegtSubelementOfLtchannelgt
  - **[Rss20FeedImage()](Sagara.FeedReader.Feeds.Rss20FeedImage.md#Sagara.FeedReader.Feeds.Rss20FeedImage.Rss20FeedImage() 'Sagara.FeedReader.Feeds.Rss20FeedImage.Rss20FeedImage()')** `Constructor` Initializes a new instance of the [Rss20FeedImage](Sagara.FeedReader.Feeds.Rss20FeedImage.md 'Sagara.FeedReader.Feeds.Rss20FeedImage') class.  
    default constructor (for serialization)
- **[Rss20FeedItem](Sagara.FeedReader.Feeds.Rss20FeedItem.md 'Sagara.FeedReader.Feeds.Rss20FeedItem')** `Class` RSS 2.0 feed item according to specification: https://validator.w3.org/feed/docs/rss2.html
  - **[Rss20FeedItem()](Sagara.FeedReader.Feeds.Rss20FeedItem.md#Sagara.FeedReader.Feeds.Rss20FeedItem.Rss20FeedItem() 'Sagara.FeedReader.Feeds.Rss20FeedItem.Rss20FeedItem()')** `Constructor` Initializes a new instance of the [Rss20FeedItem](Sagara.FeedReader.Feeds.Rss20FeedItem.md 'Sagara.FeedReader.Feeds.Rss20FeedItem') class.  
    default constructor (for serialization)
  - **[Author](Sagara.FeedReader.Feeds.Rss20FeedItem.md#Sagara.FeedReader.Feeds.Rss20FeedItem.Author 'Sagara.FeedReader.Feeds.Rss20FeedItem.Author')** `Property` The "author" field of the feed item
  - **[Categories](Sagara.FeedReader.Feeds.Rss20FeedItem.md#Sagara.FeedReader.Feeds.Rss20FeedItem.Categories 'Sagara.FeedReader.Feeds.Rss20FeedItem.Categories')** `Property` All entries "category" entries
  - **[Comments](Sagara.FeedReader.Feeds.Rss20FeedItem.md#Sagara.FeedReader.Feeds.Rss20FeedItem.Comments 'Sagara.FeedReader.Feeds.Rss20FeedItem.Comments')** `Property` The "comments" field of the feed item
  - **[Content](Sagara.FeedReader.Feeds.Rss20FeedItem.md#Sagara.FeedReader.Feeds.Rss20FeedItem.Content 'Sagara.FeedReader.Feeds.Rss20FeedItem.Content')** `Property` The "content:encoded" field
  - **[DC](Sagara.FeedReader.Feeds.Rss20FeedItem.md#Sagara.FeedReader.Feeds.Rss20FeedItem.DC 'Sagara.FeedReader.Feeds.Rss20FeedItem.DC')** `Property` All elements starting with "dc:"
  - **[Description](Sagara.FeedReader.Feeds.Rss20FeedItem.md#Sagara.FeedReader.Feeds.Rss20FeedItem.Description 'Sagara.FeedReader.Feeds.Rss20FeedItem.Description')** `Property` The "description" field of the feed item
  - **[Enclosure](Sagara.FeedReader.Feeds.Rss20FeedItem.md#Sagara.FeedReader.Feeds.Rss20FeedItem.Enclosure 'Sagara.FeedReader.Feeds.Rss20FeedItem.Enclosure')** `Property` The "enclosure" field
  - **[Guid](Sagara.FeedReader.Feeds.Rss20FeedItem.md#Sagara.FeedReader.Feeds.Rss20FeedItem.Guid 'Sagara.FeedReader.Feeds.Rss20FeedItem.Guid')** `Property` The "guid" field
  - **[PublishingDate](Sagara.FeedReader.Feeds.Rss20FeedItem.md#Sagara.FeedReader.Feeds.Rss20FeedItem.PublishingDate 'Sagara.FeedReader.Feeds.Rss20FeedItem.PublishingDate')** `Property` The "pubDate" field as DateTime. Null if parsing failed or pubDate is empty.
  - **[PublishingDateString](Sagara.FeedReader.Feeds.Rss20FeedItem.md#Sagara.FeedReader.Feeds.Rss20FeedItem.PublishingDateString 'Sagara.FeedReader.Feeds.Rss20FeedItem.PublishingDateString')** `Property` The "pubDate" field
  - **[Source](Sagara.FeedReader.Feeds.Rss20FeedItem.md#Sagara.FeedReader.Feeds.Rss20FeedItem.Source 'Sagara.FeedReader.Feeds.Rss20FeedItem.Source')** `Property` The "source" field
- **[Syndication](Sagara.FeedReader.Feeds.Syndication.md 'Sagara.FeedReader.Feeds.Syndication')** `Class` The parsed syndication elements. Those are all elements that start with "sy:"
  - **[Syndication()](Sagara.FeedReader.Feeds.Syndication.md#Sagara.FeedReader.Feeds.Syndication.Syndication() 'Sagara.FeedReader.Feeds.Syndication.Syndication()')** `Constructor` Initializes a new instance of the [Syndication](Sagara.FeedReader.Feeds.Syndication.md 'Sagara.FeedReader.Feeds.Syndication') class.  
    default constructor (for serialization)
  - **[UpdateBase](Sagara.FeedReader.Feeds.Syndication.md#Sagara.FeedReader.Feeds.Syndication.UpdateBase 'Sagara.FeedReader.Feeds.Syndication.UpdateBase')** `Property` The "updateBase" element
  - **[UpdateFrequency](Sagara.FeedReader.Feeds.Syndication.md#Sagara.FeedReader.Feeds.Syndication.UpdateFrequency 'Sagara.FeedReader.Feeds.Syndication.UpdateFrequency')** `Property` The "updateFrequency" element
  - **[UpdatePeriod](Sagara.FeedReader.Feeds.Syndication.md#Sagara.FeedReader.Feeds.Syndication.UpdatePeriod 'Sagara.FeedReader.Feeds.Syndication.UpdatePeriod')** `Property` The "updatePeriod" element

<a name='Sagara.FeedReader.Feeds.MediaRSS'></a>

## Sagara.FeedReader.Feeds.MediaRSS Namespace
- **[Media](Sagara.FeedReader.Feeds.MediaRSS.Media.md 'Sagara.FeedReader.Feeds.MediaRSS.Media')** `Class` Media object
  - **[Duration](Sagara.FeedReader.Feeds.MediaRSS.Media.md#Sagara.FeedReader.Feeds.MediaRSS.Media.Duration 'Sagara.FeedReader.Feeds.MediaRSS.Media.Duration')** `Property` Number of seconds the media object plays. Optional attribute
  - **[Element](Sagara.FeedReader.Feeds.MediaRSS.Media.md#Sagara.FeedReader.Feeds.MediaRSS.Media.Element 'Sagara.FeedReader.Feeds.MediaRSS.Media.Element')** `Property` Gets the underlying XElement in order to allow reading properties that are not available in the class itself
  - **[FileSize](Sagara.FeedReader.Feeds.MediaRSS.Media.md#Sagara.FeedReader.Feeds.MediaRSS.Media.FileSize 'Sagara.FeedReader.Feeds.MediaRSS.Media.FileSize')** `Property` Number of bytes of the media object. Optional attribute
  - **[Height](Sagara.FeedReader.Feeds.MediaRSS.Media.md#Sagara.FeedReader.Feeds.MediaRSS.Media.Height 'Sagara.FeedReader.Feeds.MediaRSS.Media.Height')** `Property` Height of the object media. Optional attribute
  - **[isDefault](Sagara.FeedReader.Feeds.MediaRSS.Media.md#Sagara.FeedReader.Feeds.MediaRSS.Media.isDefault 'Sagara.FeedReader.Feeds.MediaRSS.Media.isDefault')** `Property` Determines if this is the default object that should be used for the [MediaGroup](Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.md 'Sagara.FeedReader.Feeds.MediaRSS.MediaGroup')
  - **[Language](Sagara.FeedReader.Feeds.MediaRSS.Media.md#Sagara.FeedReader.Feeds.MediaRSS.Media.Language 'Sagara.FeedReader.Feeds.MediaRSS.Media.Language')** `Property` The primary language encapsulated in the media object. Language codes possible are detailed in RFC 3066. This attribute is used similar to the xml:lang attribute detailed in the XML 1.0 Specification (Third Edition). It is an optional attribute.
  - **[Medium](Sagara.FeedReader.Feeds.MediaRSS.Media.md#Sagara.FeedReader.Feeds.MediaRSS.Media.Medium 'Sagara.FeedReader.Feeds.MediaRSS.Media.Medium')** `Property` Type of object. Optional attribute
  - **[Thumbnails](Sagara.FeedReader.Feeds.MediaRSS.Media.md#Sagara.FeedReader.Feeds.MediaRSS.Media.Thumbnails 'Sagara.FeedReader.Feeds.MediaRSS.Media.Thumbnails')** `Property` Representative images for the media object
  - **[Type](Sagara.FeedReader.Feeds.MediaRSS.Media.md#Sagara.FeedReader.Feeds.MediaRSS.Media.Type 'Sagara.FeedReader.Feeds.MediaRSS.Media.Type')** `Property` Standard MIME type of the object. Optional attribute
  - **[Url](Sagara.FeedReader.Feeds.MediaRSS.Media.md#Sagara.FeedReader.Feeds.MediaRSS.Media.Url 'Sagara.FeedReader.Feeds.MediaRSS.Media.Url')** `Property` The direct URL to the media object
  - **[Width](Sagara.FeedReader.Feeds.MediaRSS.Media.md#Sagara.FeedReader.Feeds.MediaRSS.Media.Width 'Sagara.FeedReader.Feeds.MediaRSS.Media.Width')** `Property` Width of the object media. Optional attribute
- **[MediaGroup](Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.md 'Sagara.FeedReader.Feeds.MediaRSS.MediaGroup')** `Class` A collection of media that are effectively the same content, yet different representations. For isntance: the same song recorded in both WAV and MP3 format.
  - **[Element](Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.md#Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.Element 'Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.Element')** `Property` Gets the underlying XElement in order to allow reading properties that are not available in the class itself
  - **[Media](Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.md#Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.Media 'Sagara.FeedReader.Feeds.MediaRSS.MediaGroup.Media')** `Property` Media object
- **[Thumbnail](Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.md 'Sagara.FeedReader.Feeds.MediaRSS.Thumbnail')** `Class` Allows particular images to be used as representative images for the media object. If multiple thumbnails are included, and time coding is not at play, it is assumed that the images are in order of importance.
  - **[Height](Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.md#Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Height 'Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Height')** `Property` Height of the object media. Optional attribute
  - **[Time](Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.md#Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Time 'Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Time')** `Property` Specifies the time offset in relation to the media object
  - **[Url](Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.md#Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Url 'Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Url')** `Property` The url of the thumbnail. Required attribute
  - **[Width](Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.md#Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Width 'Sagara.FeedReader.Feeds.MediaRSS.Thumbnail.Width')** `Property` Width of the object media. Optional attribute
- **[Medium](Sagara.FeedReader.Feeds.MediaRSS.Medium.md 'Sagara.FeedReader.Feeds.MediaRSS.Medium')** `Enum` Specifies the type of an object
  - **[Audio](Sagara.FeedReader.Feeds.MediaRSS.Medium.md#Sagara.FeedReader.Feeds.MediaRSS.Medium.Audio 'Sagara.FeedReader.Feeds.MediaRSS.Medium.Audio')** `Field` Audio
  - **[Document](Sagara.FeedReader.Feeds.MediaRSS.Medium.md#Sagara.FeedReader.Feeds.MediaRSS.Medium.Document 'Sagara.FeedReader.Feeds.MediaRSS.Medium.Document')** `Field` Document
  - **[Executable](Sagara.FeedReader.Feeds.MediaRSS.Medium.md#Sagara.FeedReader.Feeds.MediaRSS.Medium.Executable 'Sagara.FeedReader.Feeds.MediaRSS.Medium.Executable')** `Field` Executable
  - **[Image](Sagara.FeedReader.Feeds.MediaRSS.Medium.md#Sagara.FeedReader.Feeds.MediaRSS.Medium.Image 'Sagara.FeedReader.Feeds.MediaRSS.Medium.Image')** `Field` Image
  - **[Unknown](Sagara.FeedReader.Feeds.MediaRSS.Medium.md#Sagara.FeedReader.Feeds.MediaRSS.Medium.Unknown 'Sagara.FeedReader.Feeds.MediaRSS.Medium.Unknown')** `Field` Type could not be determined
  - **[Video](Sagara.FeedReader.Feeds.MediaRSS.Medium.md#Sagara.FeedReader.Feeds.MediaRSS.Medium.Video 'Sagara.FeedReader.Feeds.MediaRSS.Medium.Video')** `Field` Video

<a name='Sagara.FeedReader.Html'></a>

## Sagara.FeedReader.Html Namespace
- **[HtmlHelper](Sagara.FeedReader.Html.HtmlHelper.md 'Sagara.FeedReader.Html.HtmlHelper')** `Class` Contains HTML helper methods.
  - **[ParseFeedUrlsFromHtml(string, Uri)](Sagara.FeedReader.Html.HtmlHelper.md#Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string,System.Uri) 'Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string, System.Uri)')** `Method` Parses feed links from an HTML page and resolves them against baseUri, so that every returned  
    URL is absolute. Links that can't be resolved to an http or https URL are skipped.
  - **[ParseFeedUrlsFromHtml(string)](Sagara.FeedReader.Html.HtmlHelper.md#Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string) 'Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string)')** `Method` Parses RSS links from html page and returns all links

<a name='Sagara.FeedReader.Modules.ApplePodcasts'></a>

## Sagara.FeedReader.Modules.ApplePodcasts Namespace
- **[iTunesCategory](Sagara.FeedReader.Modules.ApplePodcasts.iTunesCategory.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesCategory')** `Class` A category and optional subcategory for iTunes media.
  - **[Subcategory](Sagara.FeedReader.Modules.ApplePodcasts.iTunesCategory.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesCategory.Subcategory 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesCategory.Subcategory')** `Property` Optional Subcategory.
  - **[Text](Sagara.FeedReader.Modules.ApplePodcasts.iTunesCategory.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesCategory.Text 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesCategory.Text')** `Property` The category text.
- **[iTunesChannel](Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel')** `Class`   
    
  Data from an iTunes channel in either RSS 2.0 or Atom.  
    
  In RSS 2.0, this is direct child elements of the `channel` element, each within the `itunes` namespace.  
    
  In Atom, this is direct child elements of the `feed` element, each within the `im` namespace.
  - **[Author](Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Author 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Author')** `Property`   
      
    The group responsible for creating the media.  
      
    Show author most often refers to the parent company or network of a podcast, but it can also be   
                used to identify the host(s) if none exists.  
      
    Author information is especially useful if a company or organization publishes multiple podcasts.
  - **[Block](Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Block 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Block')** `Property`   
      
    The podcast show or hide status.  
      
    If you want your show removed from the Apple directory, use this tag.  
      
    Specifying the <itunes:block> tag with a `Yes` value, prevents the entire podcast from appearing in   
                Apple Podcasts.  
      
    Specifying any value other than `Yes` has no effect.
  - **[Categories](Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Categories 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Categories')** `Property`   
      
    The show category information. For a complete list of categories and subcategories, see https://podcasters.apple.com/support/1691-apple-podcasts-categories.  
      
    A category may contain an optional subcategory.  
      
    A feed may specify multiple categories.
  - **[Complete](Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Complete 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Complete')** `Property`   
      
    The podcast update status.  
      
    If you will never publish another episode to your show, use this tag.  
      
    Specifying the <itunes:block> tag with a `Yes` value indicates that a podcast is complete and you   
                will not post any more episodes in the future.  
      
    Specifying any value other than `Yes` has no effect.
  - **[Explicit](Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Explicit 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Explicit')** `Property`   
      
    The podcast parental advisory information.  
      
    `true` indicates the presence of explicit content.  
      
    `false` indicates that the media doesn't contain explicit language or adult content.
  - **[Image](Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Image 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Image')** `Property` The artwork for the show specified as a URL linking to it.
  - **[NewFeedUrl](Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.NewFeedUrl 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.NewFeedUrl')** `Property`   
      
    The new podcast RSS Feed URL.  
      
    If you change the URL of your podcast feed, you should use this tag in your new feed.
  - **[Owner](Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Owner 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Owner')** `Property`   
      
    The podcast owner contact information.
  - **[Title](Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Title 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Title')** `Property` The show title specific for Apple Podcasts.
  - **[Type](Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Type 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannel.Type')** `Property`   
      
    The type of show.  
      
    If your show is Serial you must use this tag.
- **[iTunesExtensions](Sagara.FeedReader.Modules.ApplePodcasts.iTunesExtensions.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesExtensions')** `Class` Extension methods that further parse the feed XML for iTunes-specific content.
  - **[GetiTunesChannel(this Feed)](Sagara.FeedReader.Modules.ApplePodcasts.iTunesExtensions.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesExtensions.GetiTunesChannel(thisSagara.FeedReader.Feed) 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesExtensions.GetiTunesChannel(this Sagara.FeedReader.Feed)')** `Method` Reads Apple Podcast show elements from a `channel` (RSS 2.0) or `feed` (Atom) element.
  - **[GetiTunesItem(this FeedItem)](Sagara.FeedReader.Modules.ApplePodcasts.iTunesExtensions.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesExtensions.GetiTunesItem(thisSagara.FeedReader.FeedItem) 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesExtensions.GetiTunesItem(this Sagara.FeedReader.FeedItem)')** `Method` Reads Apple Podcast episode elements content from a `item` (RSS 2.0) or `entry` (Atom) element.
- **[iTunesImage](Sagara.FeedReader.Modules.ApplePodcasts.iTunesImage.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesImage')** `Class` Parses the `itunes:image` element.
  - **[Href](Sagara.FeedReader.Modules.ApplePodcasts.iTunesImage.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesImage.Href 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesImage.Href')** `Property` The URL to the image.
- **[iTunesItem](Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem')** `Class`   
    
  Item data from an iTunes channel in either RSS 2.0 or Atom.  
    
  In RSS 2.0, this is direct child elements of the `channel` element, each within the `itunes` namespace.  
    
  In Atom, this is direct child elements of the `feed` element, each within the `im` namespace.
  - **[Block](Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Block 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Block')** `Property`   
      
    The episode show or hide status.  
      
    If you want an episode removed from the Apple directory, use this tag.  
      
    Specifying the <itunes:block> tag with a Yes value prevents that episode from appearing in Apple Podcasts.  
      
    Specifying any value other than `Yes` has no effect.
  - **[Duration](Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Duration 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Duration')** `Property`   
      
    The duration of an episode.  
      
    Different duration formats are accepted however it is recommended to convert the length of the episode into seconds.
  - **[Episode](Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Episode 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Episode')** `Property`   
      
    An episode number.  
      
    If all your episodes have numbers and you would like them to be ordered based on them, use this tag for each one.  
      
    Episode numbers are optional for <itunes:type> episodic shows, but are mandatory for serial shows.  
      
    Where `episode` is a non-zero integer (1, 2, 3, etc.) representing your episode number.
  - **[EpisodeType](Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.EpisodeType 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.EpisodeType')** `Property`   
      
    The episode type.  
      
    If an episode is a trailer or bonus content, use this tag.  
      
    Where the `episodeType` value can be one of the following:  
    - Full — Default. Specify full when you are submitting the complete content of your show.  
    - Trailer — Specify trailer when you are submitting a short, promotional piece of content that represents a preview of your   
                  current show.  
    - Bonus — Specify bonus when you are submitting extra content for your show (for example, behind the scenes information   
                  or interviews with the cast) or cross-promotional content for another show.
  - **[Explicit](Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Explicit 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Explicit')** `Property`   
      
    The episode parental advisory information.  
      
    `true` indicates the presence of explicit content.  
      
    `false` indicates that the media doesn't contain explicit language or adult content.
  - **[Image](Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Image 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Image')** `Property`   
      
    The episode artwork specified as a URL linking to it.  
      
    You should use this tag when you have a high quality, episode-specific image you would like listeners to see.
  - **[Season](Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Season 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Season')** `Property`   
      
    The episode season number.  
      
    If an episode is within a season use this tag.  
      
    Where `season` is a non-zero integer (1, 2, 3, etc.) representing your season number.
  - **[Title](Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Title 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesItem.Title')** `Property` The episode title specific for Apple Podcasts.
- **[iTunesOwner](Sagara.FeedReader.Modules.ApplePodcasts.iTunesOwner.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesOwner')** `Class`   
    
  The podcast owner contact information.
  - **[Email](Sagara.FeedReader.Modules.ApplePodcasts.iTunesOwner.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesOwner.Email 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesOwner.Email')** `Property` Include the email address of the owner.
  - **[Name](Sagara.FeedReader.Modules.ApplePodcasts.iTunesOwner.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesOwner.Name 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesOwner.Name')** `Property` The name of the owner.
- **[iTunesSubcategory](Sagara.FeedReader.Modules.ApplePodcasts.iTunesSubcategory.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesSubcategory')** `Class` Since a subcategory has no subcategories of its own, give it its own entity without  
  a Subcategory property.
  - **[Text](Sagara.FeedReader.Modules.ApplePodcasts.iTunesSubcategory.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesSubcategory.Text 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesSubcategory.Text')** `Property` The subcategory text.
- **[iTunesEpisodeType](Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType')** `Enum` Represents the value of `itunes:episodeType`, if present.
  - **[Bonus](Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.Bonus 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.Bonus')** `Field` Specify bonus when you are submitting extra content for your show (for example, behind the scenes information   
    or interviews with the cast) or cross-promotional content for another show.
  - **[Full](Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.Full 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.Full')** `Field` Default. Specify full when you are submitting the complete content of your show.
  - **[Trailer](Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.Trailer 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.Trailer')** `Field` Specify trailer when you are submitting a short, promotional piece of content that represents a preview of   
    your current show.
  - **[Unknown](Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.Unknown 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesEpisodeType.Unknown')** `Field` Invalid value.
- **[iTunesType](Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesType')** `Enum` Represents the value of `itunes:type`, if present.
  - **[Episodic](Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.Episodic 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.Episodic')** `Field` Default. Specify episodic when episodes are intended to be consumed without any specific order. Apple   
    Podcasts will present newest episodes first and display the publish date (required) of each episode.
  - **[Serial](Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.Serial 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.Serial')** `Field` Specify serial when episodes are intended to be consumed in sequential order. Apple Podcasts will   
    present the oldest episodes first and display the episode numbers (required) of each episode.
  - **[Unknown](Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.Unknown 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.Unknown')** `Field` Invalid value.

<a name='Sagara.FeedReader.Modules.WordPressExport'></a>

## Sagara.FeedReader.Modules.WordPressExport Namespace
- **[WordPressExportAuthor](Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.md 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor')** `Class`   
    
  The podcast owner contact information.
  - **[DisplayName](Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.DisplayName 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.DisplayName')** `Property` The author_display_name element's value.
  - **[Email](Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.Email 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.Email')** `Property` The author_email element's value.
  - **[FirstName](Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.FirstName 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.FirstName')** `Property` The author_first_name element's value.
  - **[Id](Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.Id 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.Id')** `Property` The author_id element's value.
  - **[LastName](Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.LastName 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.LastName')** `Property` The author_last_name element's value.
  - **[Login](Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.Login 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.Login')** `Property` The author_login element's value.
- **[WordPressExportCategory](Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory.md 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory')** `Class` A post category.
  - **[Name](Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory.Name 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory.Name')** `Property` The category's name.
  - **[NiceName](Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory.NiceName 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory.NiceName')** `Property` The category's nice name, which looks like a slug.
  - **[TermId](Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory.TermId 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportCategory.TermId')** `Property` The category's Id.
- **[WordPressExportChannel](Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.md 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel')** `Class`   
    
  Data from an iTunes channel in either RSS 2.0 or Atom.  
    
  In RSS 2.0, this is direct child elements of the `channel` element, each within the `itunes` namespace.  
    
  In Atom, this is direct child elements of the `feed` element, each within the `im` namespace.
  - **[Author](Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.Author 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.Author')** `Property` Information about the WordPress site's author.
  - **[BaseBlogUrl](Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.BaseBlogUrl 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.BaseBlogUrl')** `Property` The base_blog_url element's value.
  - **[BaseSiteUrl](Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.BaseSiteUrl 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.BaseSiteUrl')** `Property` The base_site_url element's value.
  - **[Categories](Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.Categories 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.Categories')** `Property` The WordPress site's categories.
  - **[Tags](Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.Tags 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.Tags')** `Property` The WordPress site's tags.
  - **[WxrVersion](Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.WxrVersion 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportChannel.WxrVersion')** `Property` The wxr_version element's value.
- **[WordPressExportComment](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment')** `Class` WordPress Post comments.
  - **[Approved](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Approved 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Approved')** `Property` The comment_approved element's value.
  - **[Author](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Author 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Author')** `Property` The comment_author element's value.
  - **[AuthorEmail](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.AuthorEmail 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.AuthorEmail')** `Property` The comment_author_email element's value.
  - **[AuthorIP](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.AuthorIP 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.AuthorIP')** `Property` The comment_author_IP element's value.
  - **[AuthorUrl](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.AuthorUrl 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.AuthorUrl')** `Property` The comment_author_url element's value.
  - **[Content](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Content 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Content')** `Property` The comment_content element's value.
  - **[Date](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Date 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Date')** `Property` The comment_date element's value.
  - **[DateGmt](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.DateGmt 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.DateGmt')** `Property` The comment_date_gmt element's value.
  - **[Id](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Id 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Id')** `Property` The comment_id element's value.
  - **[Parent](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Parent 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Parent')** `Property` The comment_parent element's value.
  - **[Type](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Type 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.Type')** `Property` The comment_type element's value.
  - **[UserId](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.UserId 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.UserId')** `Property` The comment_user_id element's value.
- **[WordPressExportExtensions](Sagara.FeedReader.Modules.WordPressExport.WordPressExportExtensions.md 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportExtensions')** `Class`   
    
  Extension methods that further parse the feed XML for WordPress Export-specific content.
  - **[GetWordPressExportChannel(this Feed)](Sagara.FeedReader.Modules.WordPressExport.WordPressExportExtensions.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportExtensions.GetWordPressExportChannel(thisSagara.FeedReader.Feed) 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportExtensions.GetWordPressExportChannel(this Sagara.FeedReader.Feed)')** `Method` Reads WordPress Export elements from a `channel` (RSS 2.0) or `feed` (Atom) element.
  - **[GetWordPressExportItem(this FeedItem)](Sagara.FeedReader.Modules.WordPressExport.WordPressExportExtensions.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportExtensions.GetWordPressExportItem(thisSagara.FeedReader.FeedItem) 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportExtensions.GetWordPressExportItem(this Sagara.FeedReader.FeedItem)')** `Method` Reads WordPress Export post elements content from a `item` (RSS 2.0) or `entry` (Atom) element.
- **[WordPressExportItem](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem')** `Class` Per-post data from a WordPress Export Item.
  - **[Comments](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.Comments 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.Comments')** `Property` The post's comments.
  - **[CommentStatus](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.CommentStatus 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.CommentStatus')** `Property` The comment_status element's value.
  - **[Content](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.Content 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.Content')** `Property` The post's content.
  - **[Excerpt](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.Excerpt 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.Excerpt')** `Property` An excerpt of the post's content.
  - **[IsSticky](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.IsSticky 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.IsSticky')** `Property` The is_sticky element's value.
  - **[MenuOrder](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.MenuOrder 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.MenuOrder')** `Property` The menu_order element's value.
  - **[PingStatus](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PingStatus 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PingStatus')** `Property` The ping_status element's value.
  - **[PostDate](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostDate 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostDate')** `Property` The post_date element's value.
  - **[PostDateGmt](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostDateGmt 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostDateGmt')** `Property` The post_date_gmt element's value.
  - **[PostId](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostId 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostId')** `Property` The post_id element's value.
  - **[PostModified](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostModified 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostModified')** `Property` The post_modified element's value.
  - **[PostModifiedGmt](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostModifiedGmt 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostModifiedGmt')** `Property` The post_modified_gmt element's value.
  - **[PostName](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostName 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostName')** `Property` The post_name element's value.
  - **[PostParent](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostParent 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostParent')** `Property` The post_parent element's value.
  - **[PostPassword](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostPassword 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostPassword')** `Property` The post_password element's value.
  - **[PostType](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostType 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostType')** `Property` The post_type element's value.
  - **[Status](Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.Status 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.Status')** `Property` The status element's value.
- **[WordPressExportTag](Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag.md 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag')** `Class` A tag used by posts.
  - **[Name](Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag.Name 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag.Name')** `Property` The tag's name.
  - **[Slug](Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag.Slug 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag.Slug')** `Property` The tag's url-safe slug.
  - **[TermId](Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag.md#Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag.TermId 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportTag.TermId')** `Property` Tag Id.