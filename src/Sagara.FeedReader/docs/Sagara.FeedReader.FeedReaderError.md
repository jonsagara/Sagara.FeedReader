#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## FeedReaderError Class

Describes why a feed could not be downloaded or parsed.

```csharp
public sealed class FeedReaderError :
System.IEquatable<Sagara.FeedReader.FeedReaderError>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedReaderError

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[FeedReaderError](Sagara.FeedReader.FeedReaderError.md 'Sagara.FeedReader.FeedReaderError')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='Sagara.FeedReader.FeedReaderError.FeedReaderError(Sagara.FeedReader.FeedReaderErrorKind,string,System.Exception)'></a>

## FeedReaderError(FeedReaderErrorKind, string, Exception) Constructor

Describes why a feed could not be downloaded or parsed.

```csharp
public FeedReaderError(Sagara.FeedReader.FeedReaderErrorKind Kind, string Message, System.Exception? Exception=null);
```
#### Parameters

<a name='Sagara.FeedReader.FeedReaderError.FeedReaderError(Sagara.FeedReader.FeedReaderErrorKind,string,System.Exception).Kind'></a>

`Kind` [FeedReaderErrorKind](Sagara.FeedReader.FeedReaderErrorKind.md 'Sagara.FeedReader.FeedReaderErrorKind')

The kind of failure. Use this to decide what to do, e.g., drop a subscription on  
            [HttpError](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.HttpError 'Sagara.FeedReader.FeedReaderErrorKind.HttpError') 404, or retry later on [Timeout](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.Timeout 'Sagara.FeedReader.FeedReaderErrorKind.Timeout').

<a name='Sagara.FeedReader.FeedReaderError.FeedReaderError(Sagara.FeedReader.FeedReaderErrorKind,string,System.Exception).Message'></a>

`Message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A human-readable description of the failure.

<a name='Sagara.FeedReader.FeedReaderError.FeedReaderError(Sagara.FeedReader.FeedReaderErrorKind,string,System.Exception).Exception'></a>

`Exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

The exception that caused the failure, if any.
### Properties

<a name='Sagara.FeedReader.FeedReaderError.Exception'></a>

## FeedReaderError.Exception Property

The exception that caused the failure, if any.

```csharp
public System.Exception? Exception { get; set; }
```

#### Property Value
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='Sagara.FeedReader.FeedReaderError.Kind'></a>

## FeedReaderError.Kind Property

The kind of failure. Use this to decide what to do, e.g., drop a subscription on  
            [HttpError](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.HttpError 'Sagara.FeedReader.FeedReaderErrorKind.HttpError') 404, or retry later on [Timeout](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.Timeout 'Sagara.FeedReader.FeedReaderErrorKind.Timeout').

```csharp
public Sagara.FeedReader.FeedReaderErrorKind Kind { get; set; }
```

#### Property Value
[FeedReaderErrorKind](Sagara.FeedReader.FeedReaderErrorKind.md 'Sagara.FeedReader.FeedReaderErrorKind')

<a name='Sagara.FeedReader.FeedReaderError.Message'></a>

## FeedReaderError.Message Property

A human-readable description of the failure.

```csharp
public string Message { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')