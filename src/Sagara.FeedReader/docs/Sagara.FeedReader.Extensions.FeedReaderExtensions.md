#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Extensions](index.md#Sagara.FeedReader.Extensions 'Sagara.FeedReader.Extensions')

## FeedReaderExtensions Class

Extension methods for configuring FeedReader DI services.

```csharp
public static class FeedReaderExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedReaderExtensions
### Methods

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Sagara.FeedReader.Configuration.FeedReaderOptions)'></a>

## FeedReaderExtensions.AddFeedReaderServices(this IServiceCollection, FeedReaderOptions) Method

Add and configure services required by FeedReader.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddFeedReaderServices(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Sagara.FeedReader.Configuration.FeedReaderOptions? options=null);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Sagara.FeedReader.Configuration.FeedReaderOptions).services'></a>

`services` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')

The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.AddFeedReaderServices(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Sagara.FeedReader.Configuration.FeedReaderOptions).options'></a>

`options` [FeedReaderOptions](Sagara.FeedReader.Configuration.FeedReaderOptions.md 'Sagara.FeedReader.Configuration.FeedReaderOptions')

Optional. Used to allow the caller to configure FeedReader's HttpClient and RecyclableMemoryStreamManager dependencies.

#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
A reference to this instance after the operation has completed.

### Remarks
NOTE: this only applies to the instance-based API.