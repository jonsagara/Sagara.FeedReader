#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader](index.md#Sagara.FeedReader 'Sagara.FeedReader')

## FeedParseException Class

Thrown when feed content cannot be parsed. [Kind](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.Kind 'Sagara.FeedReader.FeedParseException.Kind') says why.

```csharp
public sealed class FeedParseException : System.Exception
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') &#129106; FeedParseException
### Constructors

<a name='Sagara.FeedReader.FeedParseException.FeedParseException()'></a>

## FeedParseException() Constructor

Initializes a new [FeedParseException](Sagara.FeedReader.FeedParseException.md 'Sagara.FeedReader.FeedParseException') with [Kind](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.Kind 'Sagara.FeedReader.FeedParseException.Kind') set to [InvalidXml](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.InvalidXml 'Sagara.FeedReader.FeedReaderErrorKind.InvalidXml').

```csharp
public FeedParseException();
```

<a name='Sagara.FeedReader.FeedParseException.FeedParseException(Sagara.FeedReader.FeedReaderErrorKind,string,System.Exception)'></a>

## FeedParseException(FeedReaderErrorKind, string, Exception) Constructor

Initializes a new [FeedParseException](Sagara.FeedReader.FeedParseException.md 'Sagara.FeedReader.FeedParseException').

```csharp
public FeedParseException(Sagara.FeedReader.FeedReaderErrorKind kind, string message, System.Exception? innerException=null);
```
#### Parameters

<a name='Sagara.FeedReader.FeedParseException.FeedParseException(Sagara.FeedReader.FeedReaderErrorKind,string,System.Exception).kind'></a>

`kind` [FeedReaderErrorKind](Sagara.FeedReader.FeedReaderErrorKind.md 'Sagara.FeedReader.FeedReaderErrorKind')

Why the content could not be parsed.

<a name='Sagara.FeedReader.FeedParseException.FeedParseException(Sagara.FeedReader.FeedReaderErrorKind,string,System.Exception).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The error message.

<a name='Sagara.FeedReader.FeedParseException.FeedParseException(Sagara.FeedReader.FeedReaderErrorKind,string,System.Exception).innerException'></a>

`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

The exception that caused this one, if any.

<a name='Sagara.FeedReader.FeedParseException.FeedParseException(string,System.Exception)'></a>

## FeedParseException(string, Exception) Constructor

Initializes a new [FeedParseException](Sagara.FeedReader.FeedParseException.md 'Sagara.FeedReader.FeedParseException') with [Kind](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.Kind 'Sagara.FeedReader.FeedParseException.Kind') set to [InvalidXml](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.InvalidXml 'Sagara.FeedReader.FeedReaderErrorKind.InvalidXml').

```csharp
public FeedParseException(string message, System.Exception? innerException);
```
#### Parameters

<a name='Sagara.FeedReader.FeedParseException.FeedParseException(string,System.Exception).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The error message.

<a name='Sagara.FeedReader.FeedParseException.FeedParseException(string,System.Exception).innerException'></a>

`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

The exception that caused this one.

<a name='Sagara.FeedReader.FeedParseException.FeedParseException(string)'></a>

## FeedParseException(string) Constructor

Initializes a new [FeedParseException](Sagara.FeedReader.FeedParseException.md 'Sagara.FeedReader.FeedParseException') with [Kind](Sagara.FeedReader.FeedParseException.md#Sagara.FeedReader.FeedParseException.Kind 'Sagara.FeedReader.FeedParseException.Kind') set to [InvalidXml](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.InvalidXml 'Sagara.FeedReader.FeedReaderErrorKind.InvalidXml').

```csharp
public FeedParseException(string message);
```
#### Parameters

<a name='Sagara.FeedReader.FeedParseException.FeedParseException(string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The error message.
### Properties

<a name='Sagara.FeedReader.FeedParseException.Kind'></a>

## FeedParseException.Kind Property

Why the content could not be parsed. One of [InvalidXml](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.InvalidXml 'Sagara.FeedReader.FeedReaderErrorKind.InvalidXml'),  
[NotAFeed](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.NotAFeed 'Sagara.FeedReader.FeedReaderErrorKind.NotAFeed'), [UnsupportedFeedType](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.UnsupportedFeedType 'Sagara.FeedReader.FeedReaderErrorKind.UnsupportedFeedType'),  
or [ParseError](Sagara.FeedReader.FeedReaderErrorKind.md#Sagara.FeedReader.FeedReaderErrorKind.ParseError 'Sagara.FeedReader.FeedReaderErrorKind.ParseError').

```csharp
public Sagara.FeedReader.FeedReaderErrorKind Kind { get; }
```

#### Property Value
[FeedReaderErrorKind](Sagara.FeedReader.FeedReaderErrorKind.md 'Sagara.FeedReader.FeedReaderErrorKind')