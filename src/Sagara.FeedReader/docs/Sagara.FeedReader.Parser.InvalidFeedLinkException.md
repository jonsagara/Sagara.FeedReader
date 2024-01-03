#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Parser](index.md#Sagara.FeedReader.Parser 'Sagara.FeedReader.Parser')

## InvalidFeedLinkException Class

Exception is thrown if the html link element contains a feed type that does not exist. Feed types are rss or atom

```csharp
public sealed class InvalidFeedLinkException : System.Exception
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') &#129106; InvalidFeedLinkException
### Constructors

<a name='Sagara.FeedReader.Parser.InvalidFeedLinkException.InvalidFeedLinkException()'></a>

## InvalidFeedLinkException() Constructor

Initializes a new InvalidFeedLinkException

```csharp
public InvalidFeedLinkException();
```

<a name='Sagara.FeedReader.Parser.InvalidFeedLinkException.InvalidFeedLinkException(string,System.Exception)'></a>

## InvalidFeedLinkException(string, Exception) Constructor

Initializes a new InvalidFeedLinkException with a message and an innerException

```csharp
public InvalidFeedLinkException(string message, System.Exception innerException);
```
#### Parameters

<a name='Sagara.FeedReader.Parser.InvalidFeedLinkException.InvalidFeedLinkException(string,System.Exception).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

custom error message

<a name='Sagara.FeedReader.Parser.InvalidFeedLinkException.InvalidFeedLinkException(string,System.Exception).innerException'></a>

`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

the inner exception

<a name='Sagara.FeedReader.Parser.InvalidFeedLinkException.InvalidFeedLinkException(string)'></a>

## InvalidFeedLinkException(string) Constructor

Initializes a new InvalidFeedLinkException with a message

```csharp
public InvalidFeedLinkException(string message);
```
#### Parameters

<a name='Sagara.FeedReader.Parser.InvalidFeedLinkException.InvalidFeedLinkException(string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

custom error message