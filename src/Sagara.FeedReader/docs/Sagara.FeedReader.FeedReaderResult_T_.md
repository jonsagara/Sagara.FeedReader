#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## FeedReaderResult<T> Class

The outcome of downloading or parsing a feed: either a [Value](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.Value 'Sagara.FeedReader.FeedReaderResult<T>.Value') or an [Error](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.Error 'Sagara.FeedReader.FeedReaderResult<T>.Error'), never both.

```csharp
public sealed class FeedReaderResult<T>
    where T : class
```
#### Type parameters

<a name='Sagara.FeedReader.FeedReaderResult_T_.T'></a>

`T`

The type of the value returned on success.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedReaderResult<T>

### Remarks
Create instances with [Success&lt;T&gt;(T, Nullable&lt;HttpStatusCode&gt;, Uri)](Sagara.FeedReader.FeedReaderResult.md#Sagara.FeedReader.FeedReaderResult.Success_T_(T,System.Nullable_System.Net.HttpStatusCode_,System.Uri) 'Sagara.FeedReader.FeedReaderResult.Success<T>(T, System.Nullable<System.Net.HttpStatusCode>, System.Uri)') and  
[Failure&lt;T&gt;(FeedReaderError, Nullable&lt;HttpStatusCode&gt;, Uri)](Sagara.FeedReader.FeedReaderResult.md#Sagara.FeedReader.FeedReaderResult.Failure_T_(Sagara.FeedReader.FeedReaderError,System.Nullable_System.Net.HttpStatusCode_,System.Uri) 'Sagara.FeedReader.FeedReaderResult.Failure<T>(Sagara.FeedReader.FeedReaderError, System.Nullable<System.Net.HttpStatusCode>, System.Uri)').
### Properties

<a name='Sagara.FeedReader.FeedReaderResult_T_.Error'></a>

## FeedReaderResult<T>.Error Property

Why the operation failed, if it failed. Otherwise, null.

```csharp
public Sagara.FeedReader.FeedReaderError? Error { get; }
```

#### Property Value
[FeedReaderError](Sagara.FeedReader.FeedReaderError.md 'Sagara.FeedReader.FeedReaderError')

<a name='Sagara.FeedReader.FeedReaderResult_T_.FinalUri'></a>

## FeedReaderResult<T>.FinalUri Property

The URI that the content was ultimately read from, after following any redirects. Null when parsing  
local content, or when the request failed before a response arrived.

```csharp
public System.Uri? FinalUri { get; }
```

#### Property Value
[System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')

### Remarks
If this differs from the requested URI because of a permanent redirect, consider updating any stored URI.

<a name='Sagara.FeedReader.FeedReaderResult_T_.IsSuccess'></a>

## FeedReaderResult<T>.IsSuccess Property

True if the operation succeeded, in which case [Value](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.Value 'Sagara.FeedReader.FeedReaderResult<T>.Value') is not null. False if it failed,  
in which case [Error](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.Error 'Sagara.FeedReader.FeedReaderResult<T>.Error') is not null.

```csharp
public bool IsSuccess { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.FeedReaderResult_T_.StatusCode'></a>

## FeedReaderResult<T>.StatusCode Property

The HTTP status code of the response, if an HTTP response was received. Null when parsing local  
content, or when the request failed before a response arrived.

```csharp
public System.Nullable<System.Net.HttpStatusCode> StatusCode { get; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='Sagara.FeedReader.FeedReaderResult_T_.Value'></a>

## FeedReaderResult<T>.Value Property

The value, if the operation succeeded. Otherwise, null.

```csharp
public T? Value { get; }
```

#### Property Value
[T](Sagara.FeedReader.FeedReaderResult_T_.md#Sagara.FeedReader.FeedReaderResult_T_.T 'Sagara.FeedReader.FeedReaderResult<T>.T')