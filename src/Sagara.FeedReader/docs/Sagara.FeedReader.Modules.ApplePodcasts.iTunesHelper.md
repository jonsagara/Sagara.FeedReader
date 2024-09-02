#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Modules.ApplePodcasts](index.md#Sagara.FeedReader.Modules.ApplePodcasts 'Sagara.FeedReader.Modules.ApplePodcasts')

## iTunesHelper Class

Internal helpers for iTunes feeds.

```csharp
internal static class iTunesHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; iTunesHelper
### Fields

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesHelper._explicitValue'></a>

## iTunesHelper._explicitValue Field

Set of values that denote explicit content in an iTunes feed.

```csharp
private static readonly FrozenSet<string> _explicitValue;
```

#### Field Value
[System.Collections.Frozen.FrozenSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Frozen.FrozenSet-1 'System.Collections.Frozen.FrozenSet`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Frozen.FrozenSet-1 'System.Collections.Frozen.FrozenSet`1')
### Methods

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesHelper.IsExplicit(string)'></a>

## iTunesHelper.IsExplicit(string) Method

Returns true if [value](Sagara.FeedReader.Modules.ApplePodcasts.iTunesHelper.md#Sagara.FeedReader.Modules.ApplePodcasts.iTunesHelper.IsExplicit(string).value 'Sagara.FeedReader.Modules.ApplePodcasts.iTunesHelper.IsExplicit(string).value') is one of the values denoting explicit iTunes content; false otherwise.

```csharp
internal static bool IsExplicit(string? value);
```
#### Parameters

<a name='Sagara.FeedReader.Modules.ApplePodcasts.iTunesHelper.IsExplicit(string).value'></a>

`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The value from an iTunes feed describing whether content is explicit.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')