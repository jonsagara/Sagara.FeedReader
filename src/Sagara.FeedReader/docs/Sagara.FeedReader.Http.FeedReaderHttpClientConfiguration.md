#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Http](index.md#Sagara.FeedReader.Http 'Sagara.FeedReader.Http')

## FeedReaderHttpClientConfiguration Class

Configuration helper for the non-static version of FeedReader that uses  
dependency injection.

```csharp
public static class FeedReaderHttpClientConfiguration
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedReaderHttpClientConfiguration
### Methods

<a name='Sagara.FeedReader.Http.FeedReaderHttpClientConfiguration.CreateHttpClientHandler()'></a>

## FeedReaderHttpClientConfiguration.CreateHttpClientHandler() Method

Creates a customized HttpClientHandler that has automatic decompression enabled (GZip and Deflate).

```csharp
public static System.Net.Http.HttpClientHandler CreateHttpClientHandler();
```

#### Returns
[System.Net.Http.HttpClientHandler](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClientHandler 'System.Net.Http.HttpClientHandler')