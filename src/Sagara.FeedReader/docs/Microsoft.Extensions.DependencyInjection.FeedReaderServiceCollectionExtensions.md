#### [Sagara.FeedReader](index.md 'index')
### [Microsoft.Extensions.DependencyInjection](index.md#Microsoft.Extensions.DependencyInjection 'Microsoft.Extensions.DependencyInjection')

## FeedReaderServiceCollectionExtensions Class

Extension methods for registering [IFeedReader](Sagara.FeedReader.IFeedReader.md 'Sagara.FeedReader.IFeedReader') with dependency injection.

```csharp
public static class FeedReaderServiceCollectionExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedReaderServiceCollectionExtensions
### Methods

<a name='Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Sagara.FeedReader.Configuration.FeedReaderOptions)'></a>

## FeedReaderServiceCollectionExtensions.AddFeedReaderServices(this IServiceCollection, FeedReaderOptions) Method

Register [IFeedReader](Sagara.FeedReader.IFeedReader.md 'Sagara.FeedReader.IFeedReader'), its HttpClient, and the RecyclableMemoryStreamManager it uses.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddFeedReaderServices(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Sagara.FeedReader.Configuration.FeedReaderOptions? options=null);
```
#### Parameters

<a name='Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Sagara.FeedReader.Configuration.FeedReaderOptions).services'></a>

`services` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')

The service collection to add the services to.

<a name='Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Sagara.FeedReader.Configuration.FeedReaderOptions).options'></a>

`options` [FeedReaderOptions](Sagara.FeedReader.Configuration.FeedReaderOptions.md 'Sagara.FeedReader.Configuration.FeedReaderOptions')

Optional. Configures FeedReader's HttpClient, RecyclableMemoryStreamManager, and download limits.  
            If null, the defaults are used.

#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The service collection, for chaining.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[services](Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.md#Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Sagara.FeedReader.Configuration.FeedReaderOptions).services 'Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(this Microsoft.Extensions.DependencyInjection.IServiceCollection, Sagara.FeedReader.Configuration.FeedReaderOptions).services') is null.

<a name='Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Sagara.FeedReader.Configuration.FeedReaderOptions_)'></a>

## FeedReaderServiceCollectionExtensions.AddFeedReaderServices(this IServiceCollection, Action<FeedReaderOptions>) Method

Register [IFeedReader](Sagara.FeedReader.IFeedReader.md 'Sagara.FeedReader.IFeedReader'), its HttpClient, and the RecyclableMemoryStreamManager it uses.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddFeedReaderServices(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Sagara.FeedReader.Configuration.FeedReaderOptions> configure);
```
#### Parameters

<a name='Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Sagara.FeedReader.Configuration.FeedReaderOptions_).services'></a>

`services` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')

The service collection to add the services to.

<a name='Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Sagara.FeedReader.Configuration.FeedReaderOptions_).configure'></a>

`configure` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[FeedReaderOptions](Sagara.FeedReader.Configuration.FeedReaderOptions.md 'Sagara.FeedReader.Configuration.FeedReaderOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

Configures the options.

#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The service collection, for chaining.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[services](Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.md#Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Sagara.FeedReader.Configuration.FeedReaderOptions_).services 'Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(this Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Sagara.FeedReader.Configuration.FeedReaderOptions>).services') or [configure](Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.md#Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Sagara.FeedReader.Configuration.FeedReaderOptions_).configure 'Microsoft.Extensions.DependencyInjection.FeedReaderServiceCollectionExtensions.AddFeedReaderServices(this Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Sagara.FeedReader.Configuration.FeedReaderOptions>).configure') is null.

### Example
  
```csharp  
services.AddFeedReaderServices(options =>  
{  
    options.MaxResponseBytes = 5 * 1024 * 1024;  
    options.DefaultUserAgent = "MyFeedBot/1.0 (+https://example.com/bot)";  
});  
```