#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Extensions](index.md#Sagara.FeedReader.Extensions 'Sagara.FeedReader.Extensions')

## StringExtensions Class

Extension methods

```csharp
internal static class StringExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; StringExtensions
### Methods

<a name='Sagara.FeedReader.Extensions.StringExtensions.EqualsIgnoreCase(thisstring,string)'></a>

## StringExtensions.EqualsIgnoreCase(this string, string) Method

Determines whether this string and another string object have the same value.

```csharp
public static bool EqualsIgnoreCase(this string? text, string? compareTo);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.StringExtensions.EqualsIgnoreCase(thisstring,string).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the string

<a name='Sagara.FeedReader.Extensions.StringExtensions.EqualsIgnoreCase(thisstring,string).compareTo'></a>

`compareTo` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the string to compare to

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if two strings are equal in a case-insensitive comparison; false otherwise.

<a name='Sagara.FeedReader.Extensions.StringExtensions.HtmlDecode(thisstring)'></a>

## StringExtensions.HtmlDecode(this string) Method

Decodes a html encoded string

```csharp
public static string? HtmlDecode(this string? text);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.StringExtensions.HtmlDecode(thisstring).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

html text

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
decoded html