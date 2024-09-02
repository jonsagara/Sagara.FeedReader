#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Parser](index.md#Sagara.FeedReader.Parser 'Sagara.FeedReader.Parser')

## FeedParser Class

Internal FeedParser - returns the type of the feed or the parsed feed.

```csharp
internal static class FeedParser
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedParser
### Fields

<a name='Sagara.FeedReader.Parser.FeedParser.InvalidCharactersToRemove'></a>

## FeedParser.InvalidCharactersToRemove Field

Certain control characters that cause XML parsing to fail. They shouldn't be there, but sometimes are.

```csharp
internal static readonly Lazy<FrozenSet<char>> InvalidCharactersToRemove;
```

#### Field Value
[System.Lazy&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Lazy-1 'System.Lazy`1')[System.Collections.Frozen.FrozenSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Frozen.FrozenSet-1 'System.Collections.Frozen.FrozenSet`1')[System.Char](https://docs.microsoft.com/en-us/dotnet/api/System.Char 'System.Char')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Frozen.FrozenSet-1 'System.Collections.Frozen.FrozenSet`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Lazy-1 'System.Lazy`1')
### Methods

<a name='Sagara.FeedReader.Parser.FeedParser.GetEncodingAttributeValueFromXmlDeclaration(string)'></a>

## FeedParser.GetEncodingAttributeValueFromXmlDeclaration(string) Method

Try to read the encoding from the XML declaration.

```csharp
private static string? GetEncodingAttributeValueFromXmlDeclaration(string feedContent);
```
#### Parameters

<a name='Sagara.FeedReader.Parser.FeedParser.GetEncodingAttributeValueFromXmlDeclaration(string).feedContent'></a>

`feedContent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The feed content with invalid characters removed.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
See: https://stackoverflow.com/a/34294515

<a name='Sagara.FeedReader.Parser.FeedParser.GetEncodingFromAttributeValue(string)'></a>

## FeedParser.GetEncodingFromAttributeValue(string) Method

Try to get the [System.Text.Encoding](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Encoding 'System.Text.Encoding') from the feed content's XML declaration encoding attribute.  
If none found, or if it's invalid, return UTF-8.

```csharp
private static System.Text.Encoding GetEncodingFromAttributeValue(string? encodingAttrValue);
```
#### Parameters

<a name='Sagara.FeedReader.Parser.FeedParser.GetEncodingFromAttributeValue(string).encodingAttrValue'></a>

`encodingAttrValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The encoding attribute value as read from the feed content's XML declaration.

#### Returns
[System.Text.Encoding](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Encoding 'System.Text.Encoding')  
The [System.Text.Encoding](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Encoding 'System.Text.Encoding') specified by the document, or UTF-8 if none specified or it's invalid.

<a name='Sagara.FeedReader.Parser.FeedParser.GetFeedFromStreamAsync(System.IO.Stream,System.Threading.CancellationToken)'></a>

## FeedParser.GetFeedFromStreamAsync(Stream, CancellationToken) Method

Returns the parsed feed. This method tries to use the encoding of the received file.  
If none found, or it's invalid, it uses UTF8.

```csharp
public static System.Threading.Tasks.Task<Sagara.FeedReader.Feed> GetFeedFromStreamAsync(System.IO.Stream feedContentStream, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.Parser.FeedParser.GetFeedFromStreamAsync(System.IO.Stream,System.Threading.CancellationToken).feedContentStream'></a>

`feedContentStream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The feed document as a Stream.

<a name='Sagara.FeedReader.Parser.FeedParser.GetFeedFromStreamAsync(System.IO.Stream,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

token to cancel operation

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Parsed feed

<a name='Sagara.FeedReader.Parser.FeedParser.GetFeedFromString(string)'></a>

## FeedParser.GetFeedFromString(string) Method

Returns the parsed feed. This method does NOT check the encoding of the received file.

```csharp
public static Sagara.FeedReader.Feed GetFeedFromString(string feedContent);
```
#### Parameters

<a name='Sagara.FeedReader.Parser.FeedParser.GetFeedFromString(string).feedContent'></a>

`feedContent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The feed document's content as a string.

#### Returns
[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')  
Parsed feed

<a name='Sagara.FeedReader.Parser.FeedParser.ParseFeedType(System.Xml.Linq.XDocument)'></a>

## FeedParser.ParseFeedType(XDocument) Method

Returns the feed type - rss 1.0, rss 2.0, atom, ...

```csharp
private static Sagara.FeedReader.FeedType ParseFeedType(System.Xml.Linq.XDocument doc);
```
#### Parameters

<a name='Sagara.FeedReader.Parser.FeedParser.ParseFeedType(System.Xml.Linq.XDocument).doc'></a>

`doc` [System.Xml.Linq.XDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument')

the xml document

#### Returns
[FeedType](Sagara.FeedReader.FeedType.md 'Sagara.FeedReader.FeedType')  
the feed type

<a name='Sagara.FeedReader.Parser.FeedParser.RemoveInvalidChars(string)'></a>

## FeedParser.RemoveInvalidChars(string) Method

Removes some characters at the beginning of the document. These shouldn't be there, but   
unfortunately they are sometimes there. If they are not removed, xml parsing would fail.

```csharp
internal static string RemoveInvalidChars(string feedContent);
```
#### Parameters

<a name='Sagara.FeedReader.Parser.FeedParser.RemoveInvalidChars(string).feedContent'></a>

`feedContent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

RSS feed content.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Cleaned up RSS feed content.