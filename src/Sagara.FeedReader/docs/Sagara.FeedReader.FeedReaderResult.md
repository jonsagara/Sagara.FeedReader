#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## FeedReaderResult Class

Factory methods for [FeedReaderResult&lt;T&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>').

```csharp
public static class FeedReaderResult
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedReaderResult
### Methods

<a name='Sagara.FeedReader.FeedReaderResult.Failure_T_(Sagara.FeedReader.FeedReaderError,System.Nullable_System.Net.HttpStatusCode_,System.Uri)'></a>

## FeedReaderResult.Failure<T>(FeedReaderError, Nullable<HttpStatusCode>, Uri) Method

Create a failed result.

```csharp
public static Sagara.FeedReader.FeedReaderResult<T> Failure<T>(Sagara.FeedReader.FeedReaderError error, System.Nullable<System.Net.HttpStatusCode> statusCode=null, System.Uri? finalUri=null)
    where T : class;
```
#### Type parameters

<a name='Sagara.FeedReader.FeedReaderResult.Failure_T_(Sagara.FeedReader.FeedReaderError,System.Nullable_System.Net.HttpStatusCode_,System.Uri).T'></a>

`T`

The type of the value that would have been returned on success.
#### Parameters

<a name='Sagara.FeedReader.FeedReaderResult.Failure_T_(Sagara.FeedReader.FeedReaderError,System.Nullable_System.Net.HttpStatusCode_,System.Uri).error'></a>

`error` [FeedReaderError](Sagara.FeedReader.FeedReaderError.md 'Sagara.FeedReader.FeedReaderError')

Why the operation failed. Must not be null.

<a name='Sagara.FeedReader.FeedReaderResult.Failure_T_(Sagara.FeedReader.FeedReaderError,System.Nullable_System.Net.HttpStatusCode_,System.Uri).statusCode'></a>

`statusCode` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The HTTP status code of the response, if any.

<a name='Sagara.FeedReader.FeedReaderResult.Failure_T_(Sagara.FeedReader.FeedReaderError,System.Nullable_System.Net.HttpStatusCode_,System.Uri).finalUri'></a>

`finalUri` [System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')

The URI the content was read from after redirects, if any.

#### Returns
[Sagara.FeedReader.FeedReaderResult&lt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[T](Sagara.FeedReader.FeedReaderResult.md#Sagara.FeedReader.FeedReaderResult.Failure_T_(Sagara.FeedReader.FeedReaderError,System.Nullable_System.Net.HttpStatusCode_,System.Uri).T 'Sagara.FeedReader.FeedReaderResult.Failure<T>(Sagara.FeedReader.FeedReaderError, System.Nullable<System.Net.HttpStatusCode>, System.Uri).T')[&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')

<a name='Sagara.FeedReader.FeedReaderResult.Success_T_(T,System.Nullable_System.Net.HttpStatusCode_,System.Uri)'></a>

## FeedReaderResult.Success<T>(T, Nullable<HttpStatusCode>, Uri) Method

Create a successful result.

```csharp
public static Sagara.FeedReader.FeedReaderResult<T> Success<T>(T value, System.Nullable<System.Net.HttpStatusCode> statusCode=null, System.Uri? finalUri=null)
    where T : class;
```
#### Type parameters

<a name='Sagara.FeedReader.FeedReaderResult.Success_T_(T,System.Nullable_System.Net.HttpStatusCode_,System.Uri).T'></a>

`T`

The type of the value.
#### Parameters

<a name='Sagara.FeedReader.FeedReaderResult.Success_T_(T,System.Nullable_System.Net.HttpStatusCode_,System.Uri).value'></a>

`value` [T](Sagara.FeedReader.FeedReaderResult.md#Sagara.FeedReader.FeedReaderResult.Success_T_(T,System.Nullable_System.Net.HttpStatusCode_,System.Uri).T 'Sagara.FeedReader.FeedReaderResult.Success<T>(T, System.Nullable<System.Net.HttpStatusCode>, System.Uri).T')

The value. Must not be null.

<a name='Sagara.FeedReader.FeedReaderResult.Success_T_(T,System.Nullable_System.Net.HttpStatusCode_,System.Uri).statusCode'></a>

`statusCode` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The HTTP status code of the response, if any.

<a name='Sagara.FeedReader.FeedReaderResult.Success_T_(T,System.Nullable_System.Net.HttpStatusCode_,System.Uri).finalUri'></a>

`finalUri` [System.Uri](https://docs.microsoft.com/en-us/dotnet/api/System.Uri 'System.Uri')

The URI the content was read from after redirects, if any.

#### Returns
[Sagara.FeedReader.FeedReaderResult&lt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')[T](Sagara.FeedReader.FeedReaderResult.md#Sagara.FeedReader.FeedReaderResult.Success_T_(T,System.Nullable_System.Net.HttpStatusCode_,System.Uri).T 'Sagara.FeedReader.FeedReaderResult.Success<T>(T, System.Nullable<System.Net.HttpStatusCode>, System.Uri).T')[&gt;](Sagara.FeedReader.FeedReaderResult_T_.md 'Sagara.FeedReader.FeedReaderResult<T>')