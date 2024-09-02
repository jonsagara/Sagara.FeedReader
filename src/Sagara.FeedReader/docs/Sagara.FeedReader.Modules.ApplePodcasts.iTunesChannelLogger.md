#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Modules.ApplePodcasts](index.md#Sagara.FeedReader.Modules.ApplePodcasts 'Sagara.FeedReader.Modules.ApplePodcasts')

## iTunesChannelLogger Class

```csharp
internal static class iTunesChannelLogger
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; iTunesChannelLogger
### Methods

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannelLogger.EnumValueNotDefined(thisMicrosoft.Extensions.Logging.ILogger,Sagara.FeedReader.Modules.ApplePodcasts.iTunesType,string)'></a>

## iTunesChannelLogger.EnumValueNotDefined(this ILogger, iTunesType, string) Method

Logs "Parsed iTunesType, but the value '{TypeValue}' is not defined. itunes:type element: {TypeElementXml}" at "Warning" level.

```csharp
internal static void EnumValueNotDefined(this Microsoft.Extensions.Logging.ILogger logger, Sagara.FeedReader.Modules.ApplePodcasts.iTunesType typeValue, string typeElementXml);
```
#### Parameters

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannelLogger.EnumValueNotDefined(thisMicrosoft.Extensions.Logging.ILogger,Sagara.FeedReader.Modules.ApplePodcasts.iTunesType,string).logger'></a>

`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannelLogger.EnumValueNotDefined(thisMicrosoft.Extensions.Logging.ILogger,Sagara.FeedReader.Modules.ApplePodcasts.iTunesType,string).typeValue'></a>

`typeValue` [iTunesType](Sagara.FeedReader.Modules.ApplePodcasts.iTunesType.md 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesType')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannelLogger.EnumValueNotDefined(thisMicrosoft.Extensions.Logging.ILogger,Sagara.FeedReader.Modules.ApplePodcasts.iTunesType,string).typeElementXml'></a>

`typeElementXml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannelLogger.UnableToParseEnumValue(thisMicrosoft.Extensions.Logging.ILogger,string)'></a>

## iTunesChannelLogger.UnableToParseEnumValue(this ILogger, string) Method

Logs "Unable to parse an iTunesType enum value from the itunes:type element: {TypeElementXml}" at "Warning" level.

```csharp
internal static void UnableToParseEnumValue(this Microsoft.Extensions.Logging.ILogger logger, string typeElementXml);
```
#### Parameters

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannelLogger.UnableToParseEnumValue(thisMicrosoft.Extensions.Logging.ILogger,string).logger'></a>

`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesChannelLogger.UnableToParseEnumValue(thisMicrosoft.Extensions.Logging.ILogger,string).typeElementXml'></a>

`typeElementXml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')