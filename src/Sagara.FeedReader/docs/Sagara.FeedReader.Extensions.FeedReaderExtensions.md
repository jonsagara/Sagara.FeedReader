#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Extensions](index.md#Sagara.FeedReader.Extensions 'Sagara.FeedReader.Extensions')

## FeedReaderExtensions Class

Extension methods

```csharp
internal static class FeedReaderExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedReaderExtensions
### Methods

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.EqualsAnyIgnoreCase(thisstring,string[])'></a>

## FeedReaderExtensions.EqualsAnyIgnoreCase(this string, string[]) Method

Determines whether this string equals one of the given strings. If any string  
matches, the method returns immediately without evaluating the remaining options.

```csharp
public static bool EqualsAnyIgnoreCase(this string? text, params string[] candidates);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.EqualsAnyIgnoreCase(thisstring,string[]).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the string

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.EqualsAnyIgnoreCase(thisstring,string[]).candidates'></a>

`candidates` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

all strings to compare to

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the text matches of any of the candidate strings; false otherwise.

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.EqualsIgnoreCase(thisstring,string)'></a>

## FeedReaderExtensions.EqualsIgnoreCase(this string, string) Method

Determines whether this string and another string object have the same value.

```csharp
public static bool EqualsIgnoreCase(this string? text, string? compareTo);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.EqualsIgnoreCase(thisstring,string).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the string

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.EqualsIgnoreCase(thisstring,string).compareTo'></a>

`compareTo` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the string to compare to

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if two strings are equal in a case-insensitive comparison; false otherwise.

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string,string)'></a>

## FeedReaderExtensions.GetAttribute(this XElement, string, string) Method

Gets the attribute with the namespace [namespacePrefix](Sagara.FeedReader.Extensions.FeedReaderExtensions.md#Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string,string).namespacePrefix 'Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttribute(this System.Xml.Linq.XElement, string, string).namespacePrefix') and name [name](Sagara.FeedReader.Extensions.FeedReaderExtensions.md#Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string,string).name 'Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttribute(this System.Xml.Linq.XElement, string, string).name') of the given XElement

```csharp
public static System.Xml.Linq.XAttribute? GetAttribute(this System.Xml.Linq.XElement element, string? namespacePrefix, string name);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string,string).namespacePrefix'></a>

`namespacePrefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the namespace prefix of the attribute

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the name of the attribute

#### Returns
[System.Xml.Linq.XAttribute](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XAttribute 'System.Xml.Linq.XAttribute')  
the xml attribute

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string)'></a>

## FeedReaderExtensions.GetAttribute(this XElement, string) Method

Gets the attribute [name](Sagara.FeedReader.Extensions.FeedReaderExtensions.md#Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string).name 'Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttribute(this System.Xml.Linq.XElement, string).name') of the given XElement

```csharp
public static System.Xml.Linq.XAttribute? GetAttribute(this System.Xml.Linq.XElement? element, string name);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the name of the attribute

#### Returns
[System.Xml.Linq.XAttribute](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XAttribute 'System.Xml.Linq.XAttribute')  
the xml attribute

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttributeValue(thisSystem.Xml.Linq.XElement,string)'></a>

## FeedReaderExtensions.GetAttributeValue(this XElement, string) Method

Gets the value of the attribute [name](Sagara.FeedReader.Extensions.FeedReaderExtensions.md#Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttributeValue(thisSystem.Xml.Linq.XElement,string).name 'Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttributeValue(this System.Xml.Linq.XElement, string).name')

```csharp
public static string? GetAttributeValue(this System.Xml.Linq.XElement? element, string name);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttributeValue(thisSystem.Xml.Linq.XElement,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetAttributeValue(thisSystem.Xml.Linq.XElement,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the name of the attribute

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
value of the attribute

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string,string)'></a>

## FeedReaderExtensions.GetChildElementValue(this XElement, string, string) Method

Gets the value of the element "name"

```csharp
public static string? GetChildElementValue(this System.Xml.Linq.XElement element, string namespacePrefix, string elementName);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

xml element

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string,string).namespacePrefix'></a>

`namespacePrefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the namespace prefix of the element that should be returned

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string,string).elementName'></a>

`elementName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

name of the element

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
the value of the XElement

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string)'></a>

## FeedReaderExtensions.GetChildElementValue(this XElement, string) Method

Gets the value of the element with name [elementName](Sagara.FeedReader.Extensions.FeedReaderExtensions.md#Sagara.FeedReader.Extensions.FeedReaderExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string).elementName 'Sagara.FeedReader.Extensions.FeedReaderExtensions.GetChildElementValue(this System.Xml.Linq.XElement, string).elementName'). If the element is  
null, returns null.

```csharp
public static string? GetChildElementValue(this System.Xml.Linq.XElement? element, string elementName);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

xml element

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string).elementName'></a>

`elementName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

name of the element

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The value of the XElement

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElement(thisSystem.Xml.Linq.XElement,string,string)'></a>

## FeedReaderExtensions.GetElement(this XElement, string, string) Method

Gets the element of the given XElement

```csharp
public static System.Xml.Linq.XElement? GetElement(this System.Xml.Linq.XElement element, string? namespacePrefix, string name);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElement(thisSystem.Xml.Linq.XElement,string,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElement(thisSystem.Xml.Linq.XElement,string,string).namespacePrefix'></a>

`namespacePrefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the namespace prefix of the element that should be returned

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElement(thisSystem.Xml.Linq.XElement,string,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of the element that should be returned

#### Returns
[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')  
the "name" element with the prefix "namespacePrefix" of the XElement

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElement(thisSystem.Xml.Linq.XElement,string)'></a>

## FeedReaderExtensions.GetElement(this XElement, string) Method

Gets the element of the given XElement

```csharp
public static System.Xml.Linq.XElement? GetElement(this System.Xml.Linq.XElement element, string name);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElement(thisSystem.Xml.Linq.XElement,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElement(thisSystem.Xml.Linq.XElement,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of the element that should be returned

#### Returns
[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')  
the "name" element of the XElement

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElements(thisSystem.Xml.Linq.XElement,string,string)'></a>

## FeedReaderExtensions.GetElements(this XElement, string, string) Method

Gets all elements of the given XElement

```csharp
public static System.Collections.Generic.IReadOnlyCollection<System.Xml.Linq.XElement> GetElements(this System.Xml.Linq.XElement element, string? namespacePrefix, string name);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElements(thisSystem.Xml.Linq.XElement,string,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElements(thisSystem.Xml.Linq.XElement,string,string).namespacePrefix'></a>

`namespacePrefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the namespace prefix of the elements that should be returned

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElements(thisSystem.Xml.Linq.XElement,string,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of the elements that should be returned

#### Returns
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')  
all "name" elements of the given XElement

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElements(thisSystem.Xml.Linq.XElement,string)'></a>

## FeedReaderExtensions.GetElements(this XElement, string) Method

Gets all elements of the given XElement

```csharp
public static System.Collections.Generic.IReadOnlyCollection<System.Xml.Linq.XElement> GetElements(this System.Xml.Linq.XElement element, string name);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElements(thisSystem.Xml.Linq.XElement,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetElements(thisSystem.Xml.Linq.XElement,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of the elements that should be returned

#### Returns
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')  
all "name" elements of the given XElement

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetNamespacePrefix(thisSystem.Xml.Linq.XElement,string)'></a>

## FeedReaderExtensions.GetNamespacePrefix(this XElement, string) Method

Gets the namespace prefix of the given XElement, if namespacePrefix is null or empty, it returns the default namespace.

```csharp
public static System.Xml.Linq.XNamespace? GetNamespacePrefix(this System.Xml.Linq.XElement element, string? namespacePrefix);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetNamespacePrefix(thisSystem.Xml.Linq.XElement,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetNamespacePrefix(thisSystem.Xml.Linq.XElement,string).namespacePrefix'></a>

`namespacePrefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the namespace prefix

#### Returns
[System.Xml.Linq.XNamespace](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XNamespace 'System.Xml.Linq.XNamespace')  
the namespace prefix or default namespace if the [namespacePrefix](Sagara.FeedReader.Extensions.FeedReaderExtensions.md#Sagara.FeedReader.Extensions.FeedReaderExtensions.GetNamespacePrefix(thisSystem.Xml.Linq.XElement,string).namespacePrefix 'Sagara.FeedReader.Extensions.FeedReaderExtensions.GetNamespacePrefix(this System.Xml.Linq.XElement, string).namespacePrefix') is null or empty

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetNamespacePrefix(thisSystem.Xml.Linq.XElement)'></a>

## FeedReaderExtensions.GetNamespacePrefix(this XElement) Method

Gets the namespace prefix of the given XElement

```csharp
public static System.Xml.Linq.XNamespace? GetNamespacePrefix(this System.Xml.Linq.XElement element);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.GetNamespacePrefix(thisSystem.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

#### Returns
[System.Xml.Linq.XNamespace](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XNamespace 'System.Xml.Linq.XNamespace')  
the namespace prefix

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.HtmlDecode(thisstring)'></a>

## FeedReaderExtensions.HtmlDecode(this string) Method

Decodes a html encoded string

```csharp
public static string? HtmlDecode(this string? text);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.HtmlDecode(thisstring).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

html text

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
decoded html

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.SplitName(string)'></a>

## FeedReaderExtensions.SplitName(string) Method

Splits the name into namespace and name if it contains a ':'. If it does not contain a   
namespace, the returned namespace is null and name is the original name.

```csharp
private static Sagara.FeedReader.Extensions.FeedReaderExtensions.NamespaceAndName SplitName(string name);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.SplitName(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the input name

#### Returns
[Sagara.FeedReader.Extensions.FeedReaderExtensions.NamespaceAndName](https://docs.microsoft.com/en-us/dotnet/api/Sagara.FeedReader.Extensions.FeedReaderExtensions.NamespaceAndName 'Sagara.FeedReader.Extensions.FeedReaderExtensions.NamespaceAndName')  
splitted namespace and name, item1 is null if namespace is empty

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.ToUtf8(thisstring,System.Text.Encoding)'></a>

## FeedReaderExtensions.ToUtf8(this string, Encoding) Method

Converts a string to UTF-8

```csharp
public static string ToUtf8(this string text, System.Text.Encoding encoding);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.ToUtf8(thisstring,System.Text.Encoding).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

text to convert

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.ToUtf8(thisstring,System.Text.Encoding).encoding'></a>

`encoding` [System.Text.Encoding](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Encoding 'System.Text.Encoding')

the encoding of the text

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
text as utf8 encoded string

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.ToUtf8(thisstring)'></a>

## FeedReaderExtensions.ToUtf8(this string) Method

Converts a string to UTF-8

```csharp
public static string ToUtf8(this string text);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.FeedReaderExtensions.ToUtf8(thisstring).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

text to convert

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
text as utf8 encoded string