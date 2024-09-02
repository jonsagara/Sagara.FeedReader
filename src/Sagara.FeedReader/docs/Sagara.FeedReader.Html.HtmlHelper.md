#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Html](index.md#Sagara.FeedReader.Html 'Sagara.FeedReader.Html')

## HtmlHelper Class

Contains HTML helper methods.

```csharp
public static class HtmlHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HtmlHelper
### Fields

<a name='Sagara.FeedReader.Html.HtmlHelper.AttributeValueRegexFormat'></a>

## HtmlHelper.AttributeValueRegexFormat Field

Identifies and extracts an HTML attribute value.

```csharp
private const string AttributeValueRegexFormat = \s*=\s*"(?<val>[^"]*)";
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='Sagara.FeedReader.Html.HtmlHelper.GetFeedLinkFromLinkTag(string)'></a>

## HtmlHelper.GetFeedLinkFromLinkTag(string) Method

Returns a HtmlFeedLink object from a linktag (link href="" type="")  
only support application/rss and application/atom as type  
if type is not supported, null is returned

```csharp
public static Sagara.FeedReader.HtmlFeedLink? GetFeedLinkFromLinkTag(string input);
```
#### Parameters

<a name='Sagara.FeedReader.Html.HtmlHelper.GetFeedLinkFromLinkTag(string).input'></a>

`input` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

link tag, e.g. <link rel="alternate" type="application/rss+xml" title="codehollow > Feed" href="https://codehollow.com/feed/"/>

#### Returns
[HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink')  
Parsed HtmlFeedLink

<a name='Sagara.FeedReader.Html.HtmlHelper.GetHREFAttributeValueFromLinkTag(string)'></a>

## HtmlHelper.GetHREFAttributeValueFromLinkTag(string) Method

Reads the href attribute value from an HTML <link/> tag.

```csharp
private static string GetHREFAttributeValueFromLinkTag(string linkTagHtml);
```
#### Parameters

<a name='Sagara.FeedReader.Html.HtmlHelper.GetHREFAttributeValueFromLinkTag(string).linkTagHtml'></a>

`linkTagHtml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The HTML tag, e.g. <link title="my title">.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Html.HtmlHelper.GetTitleAttributeValueFromLinkTag(string)'></a>

## HtmlHelper.GetTitleAttributeValueFromLinkTag(string) Method

Reads the title attribute value from an HTML <link/> tag.

```csharp
private static string GetTitleAttributeValueFromLinkTag(string linkTagHtml);
```
#### Parameters

<a name='Sagara.FeedReader.Html.HtmlHelper.GetTitleAttributeValueFromLinkTag(string).linkTagHtml'></a>

`linkTagHtml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The HTML tag, e.g. <link title="my title">.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Html.HtmlHelper.GetTypeAttributeValueFromLinkTag(string)'></a>

## HtmlHelper.GetTypeAttributeValueFromLinkTag(string) Method

Reads the type attribute value from an HTML <link/> tag.

```csharp
private static string GetTypeAttributeValueFromLinkTag(string linkTagHtml);
```
#### Parameters

<a name='Sagara.FeedReader.Html.HtmlHelper.GetTypeAttributeValueFromLinkTag(string).linkTagHtml'></a>

`linkTagHtml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The HTML tag, e.g. <link title="my title">.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Html.HtmlHelper.HREFAttributeValue()'></a>

## HtmlHelper.HREFAttributeValue() Method

```csharp
private static System.Text.RegularExpressions.Regex HREFAttributeValue();
```

#### Returns
[System.Text.RegularExpressions.Regex](https://docs.microsoft.com/en-us/dotnet/api/System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex')

### Remarks
Pattern:<br/>  
  
```csharp  
href\\s*=\\s*"(?<val>[^"]*)"  
```<br/>  
Options:<br/>  
  
```csharp  
RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace  
```<br/>  
Explanation:<br/>  
  
```csharp  
○ Match a character in the set [Hh].<br/>  
○ Match a character in the set [Rr].<br/>  
○ Match a character in the set [Ee].<br/>  
○ Match a character in the set [Ff].<br/>  
○ Match a whitespace character atomically any number of times.<br/>  
○ Match '='.<br/>  
○ Match a whitespace character atomically any number of times.<br/>  
○ Match '"'.<br/>  
○ "val" capture group.<br/>  
    ○ Match a character other than '"' atomically any number of times.<br/>  
○ Match '"'.<br/>  
```

<a name='Sagara.FeedReader.Html.HtmlHelper.LinkTag()'></a>

## HtmlHelper.LinkTag() Method

```csharp
private static System.Text.RegularExpressions.Regex LinkTag();
```

#### Returns
[System.Text.RegularExpressions.Regex](https://docs.microsoft.com/en-us/dotnet/api/System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex')

### Remarks
Pattern:<br/>  
  
```csharp  
<link[^>]*rel="alternate"[^>]*>  
```<br/>  
Options:<br/>  
  
```csharp  
RegexOptions.Singleline  
```<br/>  
Explanation:<br/>  
  
```csharp  
○ Match the string "<link".<br/>  
○ Match a character other than '>' greedily any number of times.<br/>  
○ Match the string "rel=\"alternate\"".<br/>  
○ Match a character other than '>' atomically any number of times.<br/>  
○ Match '>'.<br/>  
```

<a name='Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string)'></a>

## HtmlHelper.ParseFeedUrlsFromHtml(string) Method

Parses RSS links from html page and returns all links

```csharp
public static System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.HtmlFeedLink> ParseFeedUrlsFromHtml(string htmlContent);
```
#### Parameters

<a name='Sagara.FeedReader.Html.HtmlHelper.ParseFeedUrlsFromHtml(string).htmlContent'></a>

`htmlContent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the content of the html page

#### Returns
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[HtmlFeedLink](Sagara.FeedReader.HtmlFeedLink.md 'Sagara.FeedReader.HtmlFeedLink')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')  
all RSS/feed links

<a name='Sagara.FeedReader.Html.HtmlHelper.TitleAttributeValue()'></a>

## HtmlHelper.TitleAttributeValue() Method

```csharp
private static System.Text.RegularExpressions.Regex TitleAttributeValue();
```

#### Returns
[System.Text.RegularExpressions.Regex](https://docs.microsoft.com/en-us/dotnet/api/System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex')

### Remarks
Pattern:<br/>  
  
```csharp  
title\\s*=\\s*"(?<val>[^"]*)"  
```<br/>  
Options:<br/>  
  
```csharp  
RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace  
```<br/>  
Explanation:<br/>  
  
```csharp  
○ Match a character in the set [Tt].<br/>  
○ Match a character in the set [Ii].<br/>  
○ Match a character in the set [Tt].<br/>  
○ Match a character in the set [Ll].<br/>  
○ Match a character in the set [Ee].<br/>  
○ Match a whitespace character atomically any number of times.<br/>  
○ Match '='.<br/>  
○ Match a whitespace character atomically any number of times.<br/>  
○ Match '"'.<br/>  
○ "val" capture group.<br/>  
    ○ Match a character other than '"' atomically any number of times.<br/>  
○ Match '"'.<br/>  
```

<a name='Sagara.FeedReader.Html.HtmlHelper.TypeAttributeValue()'></a>

## HtmlHelper.TypeAttributeValue() Method

```csharp
private static System.Text.RegularExpressions.Regex TypeAttributeValue();
```

#### Returns
[System.Text.RegularExpressions.Regex](https://docs.microsoft.com/en-us/dotnet/api/System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex')

### Remarks
Pattern:<br/>  
  
```csharp  
type\\s*=\\s*"(?<val>[^"]*)"  
```<br/>  
Options:<br/>  
  
```csharp  
RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace  
```<br/>  
Explanation:<br/>  
  
```csharp  
○ Match a character in the set [Tt].<br/>  
○ Match a character in the set [Yy].<br/>  
○ Match a character in the set [Pp].<br/>  
○ Match a character in the set [Ee].<br/>  
○ Match a whitespace character atomically any number of times.<br/>  
○ Match '='.<br/>  
○ Match a whitespace character atomically any number of times.<br/>  
○ Match '"'.<br/>  
○ "val" capture group.<br/>  
    ○ Match a character other than '"' atomically any number of times.<br/>  
○ Match '"'.<br/>  
```