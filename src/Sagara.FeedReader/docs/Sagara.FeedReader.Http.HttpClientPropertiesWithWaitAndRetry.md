#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Http](index.md#Sagara.FeedReader.Http 'Sagara.FeedReader.Http')

## HttpClientPropertiesWithWaitAndRetry Struct

Configuration for a Polly WaitAndRetry resilience strategy.

```csharp
public readonly struct HttpClientPropertiesWithWaitAndRetry :
System.IEquatable<Sagara.FeedReader.Http.HttpClientPropertiesWithWaitAndRetry>
```

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[HttpClientPropertiesWithWaitAndRetry](Sagara.FeedReader.Http.HttpClientPropertiesWithWaitAndRetry.md 'Sagara.FeedReader.Http.HttpClientPropertiesWithWaitAndRetry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='Sagara.FeedReader.Http.HttpClientPropertiesWithWaitAndRetry.HttpClientPropertiesWithWaitAndRetry(string,int)'></a>

## HttpClientPropertiesWithWaitAndRetry(string, int) Constructor

Configuration for a Polly WaitAndRetry resilience strategy.

```csharp
public HttpClientPropertiesWithWaitAndRetry(string Name, int MaxRetryAttempts);
```
#### Parameters

<a name='Sagara.FeedReader.Http.HttpClientPropertiesWithWaitAndRetry.HttpClientPropertiesWithWaitAndRetry(string,int).Name'></a>

`Name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the HttpClient.

<a name='Sagara.FeedReader.Http.HttpClientPropertiesWithWaitAndRetry.HttpClientPropertiesWithWaitAndRetry(string,int).MaxRetryAttempts'></a>

`MaxRetryAttempts` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The maximnum number of times to retry a request.
### Properties

<a name='Sagara.FeedReader.Http.HttpClientPropertiesWithWaitAndRetry.MaxRetryAttempts'></a>

## HttpClientPropertiesWithWaitAndRetry.MaxRetryAttempts Property

The maximnum number of times to retry a request.

```csharp
public int MaxRetryAttempts { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='Sagara.FeedReader.Http.HttpClientPropertiesWithWaitAndRetry.Name'></a>

## HttpClientPropertiesWithWaitAndRetry.Name Property

The name of the HttpClient.

```csharp
public string Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')