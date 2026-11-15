#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## FeedParser Class

Parses RSS 0.91, 0.92, 1.0, 2.0, Media RSS, and Atom feeds from content you already have, e.g., a file or a string.

```csharp
public static class FeedParser
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedParser

### Example
  
```csharp  
await using var stream = File.OpenRead("feed.xml");  
var feed = await FeedParser.ParseAsync(stream);  
```

### Remarks
  
To download and parse a feed from a URL, use [FeedReader](Sagara.FeedReader.FeedReader.md 'Sagara.FeedReader.FeedReader') instead.  
  
[ParseAsync(Stream, CancellationToken)](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream, System.Threading.CancellationToken)') and [Parse(string)](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.Parse(string) 'Sagara.FeedReader.FeedParser.Parse(string)') throw  
            [FeedParseException](Sagara.FeedReader.FeedParseException.md 'Sagara.FeedReader.FeedParseException') when the content can't be parsed. [TryParseAsync(Stream, CancellationToken)](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.TryParseAsync(System.IO.Stream,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedParser.TryParseAsync(System.IO.Stream, System.Threading.CancellationToken)')  
            and [TryParse(string)](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.TryParse(string) 'Sagara.FeedReader.FeedParser.TryParse(string)') return a failed [FeedReaderResult&lt;T&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>') instead.
### Methods

<a name='Sagara.FeedReader.FeedParser.Parse(string)'></a>

## FeedParser.Parse(string) Method

Parse a feed from a string. The XML declaration's encoding is ignored, because the content has already  
been decoded into a string.

```csharp
public static Sagara.FeedReader.Feed Parse(string feedContent);
```
#### Parameters

<a name='Sagara.FeedReader.FeedParser.Parse(string).feedContent'></a>

`feedContent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The feed document's content as a string.

#### Returns
[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')  
The parsed feed.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[feedContent](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.Parse(string).feedContent 'Sagara.FeedReader.FeedParser.Parse(string).feedContent') is null.

[FeedParseException](Sagara.FeedReader.FeedParseException.md 'Sagara.FeedReader.FeedParseException')  
The content can't be parsed. [Kind](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.Kind 'Sagara.FeedReader.FeedParseException.Kind') says why.

<a name='Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream,System.Threading.CancellationToken)'></a>

## FeedParser.ParseAsync(Stream, CancellationToken) Method

Parse a feed from a stream. The encoding declared in the document's XML declaration is honored;  
if there is none, or it's invalid, UTF-8 is used.

```csharp
public static System.Threading.Tasks.Task<Sagara.FeedReader.Feed> ParseAsync(System.IO.Stream feedContentStream, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream,System.Threading.CancellationToken).feedContentStream'></a>

`feedContentStream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The feed document as a Stream.

<a name='Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel the operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The parsed feed.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[feedContentStream](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream,System.Threading.CancellationToken).feedContentStream 'Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream, System.Threading.CancellationToken).feedContentStream') is null.

[FeedParseException](Sagara.FeedReader.FeedParseException.md 'Sagara.FeedReader.FeedParseException')  
The content can't be parsed. [Kind](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.Kind 'Sagara.FeedReader.FeedParseException.Kind') says why.

[System.OperationCanceledException](https://docs.microsoft.com/en-us/dotnet/api/System.OperationCanceledException 'System.OperationCanceledException')  
[cancellationToken](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream,System.Threading.CancellationToken).cancellationToken 'Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream, System.Threading.CancellationToken).cancellationToken') was cancelled.

### Remarks
Reading starts at the stream's current position. Non-seekable streams (e.g., network streams) are  
buffered into memory first, because the content may need to be re-read with its declared encoding.  
The stream is not disposed.

<a name='Sagara.FeedReader.FeedParser.TryParse(string)'></a>

## FeedParser.TryParse(string) Method

Parse a feed from a string without throwing when the content can't be parsed. Otherwise the same as  
[Parse(string)](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.Parse(string) 'Sagara.FeedReader.FeedParser.Parse(string)').

```csharp
public static Sagara.FeedReader.FeedReaderResult<Sagara.FeedReader.Feed> TryParse(string feedContent);
```
#### Parameters

<a name='Sagara.FeedReader.FeedParser.TryParse(string).feedContent'></a>

`feedContent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The feed document's content as a string.

#### Returns
[Sagara.FeedReader.FeedReaderResult&lt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')  
A successful result with the parsed feed, or a failed result whose [Error](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.Error 'Sagara.FeedReader.FeedReaderResult<T>.Error')  
            says why the content couldn't be parsed. [StatusCode](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.StatusCode 'Sagara.FeedReader.FeedReaderResult<T>.StatusCode') and  
            [FinalUri](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.FinalUri 'Sagara.FeedReader.FeedReaderResult<T>.FinalUri') are always null.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[feedContent](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.TryParse(string).feedContent 'Sagara.FeedReader.FeedParser.TryParse(string).feedContent') is null.

<a name='Sagara.FeedReader.FeedParser.TryParseAsync(System.IO.Stream,System.Threading.CancellationToken)'></a>

## FeedParser.TryParseAsync(Stream, CancellationToken) Method

Parse a feed from a stream without throwing when the content can't be parsed. Otherwise the same as  
[ParseAsync(Stream, CancellationToken)](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream,System.Threading.CancellationToken) 'Sagara.FeedReader.FeedParser.ParseAsync(System.IO.Stream, System.Threading.CancellationToken)').

```csharp
public static System.Threading.Tasks.Task<Sagara.FeedReader.FeedReaderResult<Sagara.FeedReader.Feed>> TryParseAsync(System.IO.Stream feedContentStream, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Sagara.FeedReader.FeedParser.TryParseAsync(System.IO.Stream,System.Threading.CancellationToken).feedContentStream'></a>

`feedContentStream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The feed document as a Stream.

<a name='Sagara.FeedReader.FeedParser.TryParseAsync(System.IO.Stream,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token to cancel the operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Sagara.FeedReader.FeedReaderResult&lt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[Feed](Sagara.FeedReader.Feed.md 'Sagara.FeedReader.Feed')[&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A successful result with the parsed feed, or a failed result whose [Error](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.Error 'Sagara.FeedReader.FeedReaderResult<T>.Error')  
            says why the content couldn't be parsed. [StatusCode](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.StatusCode 'Sagara.FeedReader.FeedReaderResult<T>.StatusCode') and  
            [FinalUri](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.FinalUri 'Sagara.FeedReader.FeedReaderResult<T>.FinalUri') are always null.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[feedContentStream](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.TryParseAsync(System.IO.Stream,System.Threading.CancellationToken).feedContentStream 'Sagara.FeedReader.FeedParser.TryParseAsync(System.IO.Stream, System.Threading.CancellationToken).feedContentStream') is null.

[System.OperationCanceledException](https://docs.microsoft.com/en-us/dotnet/api/System.OperationCanceledException 'System.OperationCanceledException')  
[cancellationToken](Sagara.FeedReader.FeedParser.md#Sagara.FeedReader.FeedParser.TryParseAsync(System.IO.Stream,System.Threading.CancellationToken).cancellationToken 'Sagara.FeedReader.FeedParser.TryParseAsync(System.IO.Stream, System.Threading.CancellationToken).cancellationToken') was cancelled.