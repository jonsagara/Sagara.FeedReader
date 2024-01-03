#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Http](index.md#Sagara.FeedReader.Http 'Sagara.FeedReader.Http')

## NamedHttpClients Class

A common place to store configuration for named HttpClients.

```csharp
public static class NamedHttpClients
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; NamedHttpClients
### Properties

<a name='Sagara.FeedReader.Http.NamedHttpClients.FeedReader'></a>

## NamedHttpClients.FeedReader Property

Customized HttpClient for making requests to RSS/Atom endpoints. Retries up to 1 time.

```csharp
public static Sagara.FeedReader.Http.HttpClientPropertiesWithWaitAndRetry FeedReader { get; }
```

#### Property Value
[HttpClientPropertiesWithWaitAndRetry](Sagara.FeedReader.Http.HttpClientPropertiesWithWaitAndRetry.md 'Sagara.FeedReader.Http.HttpClientPropertiesWithWaitAndRetry')