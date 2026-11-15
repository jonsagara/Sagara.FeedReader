#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## FeedReaderErrorKind Enum

The kind of failure that occurred while downloading or parsing a feed.

```csharp
public enum FeedReaderErrorKind
```
### Fields

<a name='Sagara.FeedReader.FeedReaderErrorKind.HttpError'></a>

`HttpError` 0

The server returned a non-success HTTP status code.

<a name='Sagara.FeedReader.FeedReaderErrorKind.InvalidXml'></a>

`InvalidXml` 4

The content is empty or is not well-formed XML.

<a name='Sagara.FeedReader.FeedReaderErrorKind.NetworkError'></a>

`NetworkError` 1

The request failed before an HTTP response was received, e.g., a DNS, TLS, or connection failure.

<a name='Sagara.FeedReader.FeedReaderErrorKind.NotAFeed'></a>

`NotAFeed` 3

The content is an HTML page, not a feed.

<a name='Sagara.FeedReader.FeedReaderErrorKind.ParseError'></a>

`ParseError` 7

The content is well-formed XML with a supported root element, but the feed could not be parsed, e.g.,  
because a required element is missing.

<a name='Sagara.FeedReader.FeedReaderErrorKind.ResponseTooLarge'></a>

`ResponseTooLarge` 6

The response body exceeded the configured maximum size.

<a name='Sagara.FeedReader.FeedReaderErrorKind.Timeout'></a>

`Timeout` 2

The request timed out.

<a name='Sagara.FeedReader.FeedReaderErrorKind.UnsupportedFeedType'></a>

`UnsupportedFeedType` 5

The content is well-formed XML, but its root element is not a supported feed type.