#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Parser](index.md#Sagara.FeedReader.Parser 'Sagara.FeedReader.Parser')

## FeedParser Class

Internal FeedParser - returns the type of the feed or the parsed feed.

```csharp
internal static class FeedParser
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedParser
### Methods

<a name='Sagara.FeedReader.Parser.FeedParser.GetEncoding(System.Xml.Linq.XDocument)'></a>

## FeedParser.GetEncoding(XDocument) Method

Tries to read the encoding from the document's XML declaration. If none found, or if it's invalid,  
returns UTF8.

```csharp
private static System.Text.Encoding GetEncoding(System.Xml.Linq.XDocument feedDoc);
```
#### Parameters

<a name='Sagara.FeedReader.Parser.FeedParser.GetEncoding(System.Xml.Linq.XDocument).feedDoc'></a>

`feedDoc` [System.Xml.Linq.XDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument')

rss feed document

#### Returns
[System.Text.Encoding](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Encoding 'System.Text.Encoding')  
encoding or utf8 by default

<a name='Sagara.FeedReader.Parser.FeedParser.GetFeedFromBytes(byte[])'></a>

## FeedParser.GetFeedFromBytes(byte[]) Method

Returns the parsed feed. This method tries to use the encoding of the received file.  
If none found, or it's invalid, it uses UTF8.

```csharp
public static Sagara.FeedReader.Feed GetFeedFromBytes(byte[] feedContentData);
```
#### Parameters

<a name='Sagara.FeedReader.Parser.FeedParser.GetFeedFromBytes(byte[]).feedContentData'></a>

`feedContentData` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The feed document as a byte array.

#### Returns
[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')  
Parsed feed

<a name='Sagara.FeedReader.Parser.FeedParser.GetFeedFromStreamAsync(System.IO.Stream)'></a>

## FeedParser.GetFeedFromStreamAsync(Stream) Method

Returns the parsed feed. This method tries to use the encoding of the received file.  
If none found, or it's invalid, it uses UTF8.

```csharp
public static System.Threading.Tasks.Task<Sagara.FeedReader.Feed> GetFeedFromStreamAsync(System.IO.Stream feedContentStream);
```
#### Parameters

<a name='Sagara.FeedReader.Parser.FeedParser.GetFeedFromStreamAsync(System.IO.Stream).feedContentStream'></a>

`feedContentStream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The feed document as a Stream.

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
private static string RemoveInvalidChars(string feedContent);
```
#### Parameters

<a name='Sagara.FeedReader.Parser.FeedParser.RemoveInvalidChars(string).feedContent'></a>

`feedContent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

RSS feed content.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Cleaned up RSS feed content.