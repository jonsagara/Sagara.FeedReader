#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Extensions](index.md#Sagara.FeedReader.Extensions 'Sagara.FeedReader.Extensions')

## XElementExtensions Class

```csharp
internal static class XElementExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; XElementExtensions
### Methods

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string,string)'></a>

## XElementExtensions.GetAttribute(this XElement, string, string) Method

Gets the attribute with the namespace [namespacePrefix](Sagara.FeedReader.Extensions.XElementExtensions.md#Sagara.FeedReader.Extensions.XElementExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string,string).namespacePrefix 'Sagara.FeedReader.Extensions.XElementExtensions.GetAttribute(this System.Xml.Linq.XElement, string, string).namespacePrefix') and name [attributeName](Sagara.FeedReader.Extensions.XElementExtensions.md#Sagara.FeedReader.Extensions.XElementExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string,string).attributeName 'Sagara.FeedReader.Extensions.XElementExtensions.GetAttribute(this System.Xml.Linq.XElement, string, string).attributeName') of the given XElement

```csharp
public static System.Xml.Linq.XAttribute? GetAttribute(this System.Xml.Linq.XElement element, string? namespacePrefix, string attributeName);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string,string).namespacePrefix'></a>

`namespacePrefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the namespace prefix of the attribute

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string,string).attributeName'></a>

`attributeName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the name of the attribute

#### Returns
[System.Xml.Linq.XAttribute](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XAttribute 'System.Xml.Linq.XAttribute')  
the xml attribute

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string)'></a>

## XElementExtensions.GetAttribute(this XElement, string) Method

Gets the attribute [attributeName](Sagara.FeedReader.Extensions.XElementExtensions.md#Sagara.FeedReader.Extensions.XElementExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string).attributeName 'Sagara.FeedReader.Extensions.XElementExtensions.GetAttribute(this System.Xml.Linq.XElement, string).attributeName') of the given XElement

```csharp
public static System.Xml.Linq.XAttribute? GetAttribute(this System.Xml.Linq.XElement? element, string attributeName);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetAttribute(thisSystem.Xml.Linq.XElement,string).attributeName'></a>

`attributeName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the name of the attribute

#### Returns
[System.Xml.Linq.XAttribute](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XAttribute 'System.Xml.Linq.XAttribute')  
the xml attribute

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetAttributeValue(thisSystem.Xml.Linq.XElement,string)'></a>

## XElementExtensions.GetAttributeValue(this XElement, string) Method

Gets the value of the attribute [attributeName](Sagara.FeedReader.Extensions.XElementExtensions.md#Sagara.FeedReader.Extensions.XElementExtensions.GetAttributeValue(thisSystem.Xml.Linq.XElement,string).attributeName 'Sagara.FeedReader.Extensions.XElementExtensions.GetAttributeValue(this System.Xml.Linq.XElement, string).attributeName')

```csharp
public static string? GetAttributeValue(this System.Xml.Linq.XElement? element, string attributeName);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetAttributeValue(thisSystem.Xml.Linq.XElement,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

The xml element

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetAttributeValue(thisSystem.Xml.Linq.XElement,string).attributeName'></a>

`attributeName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the attribute

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
value of the attribute

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string,string)'></a>

## XElementExtensions.GetChildElementValue(this XElement, string, string) Method

Gets the value of the element "name"

```csharp
public static string? GetChildElementValue(this System.Xml.Linq.XElement element, string namespacePrefix, string elementName);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

xml element

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string,string).namespacePrefix'></a>

`namespacePrefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the namespace prefix of the element that should be returned

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string,string).elementName'></a>

`elementName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

name of the element

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
the value of the XElement

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string)'></a>

## XElementExtensions.GetChildElementValue(this XElement, string) Method

Gets the value of the element with name [elementName](Sagara.FeedReader.Extensions.XElementExtensions.md#Sagara.FeedReader.Extensions.XElementExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string).elementName 'Sagara.FeedReader.Extensions.XElementExtensions.GetChildElementValue(this System.Xml.Linq.XElement, string).elementName'). If the element is  
null, returns null.

```csharp
public static string? GetChildElementValue(this System.Xml.Linq.XElement? element, string elementName);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

xml element

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetChildElementValue(thisSystem.Xml.Linq.XElement,string).elementName'></a>

`elementName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

name of the element

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The value of the XElement

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElement(thisSystem.Xml.Linq.XElement,string,string)'></a>

## XElementExtensions.GetElement(this XElement, string, string) Method

Gets the element of the given XElement

```csharp
public static System.Xml.Linq.XElement? GetElement(this System.Xml.Linq.XElement element, string? namespacePrefix, string elementName);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElement(thisSystem.Xml.Linq.XElement,string,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElement(thisSystem.Xml.Linq.XElement,string,string).namespacePrefix'></a>

`namespacePrefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the namespace prefix of the element that should be returned

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElement(thisSystem.Xml.Linq.XElement,string,string).elementName'></a>

`elementName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of the element that should be returned

#### Returns
[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')  
the "name" element with the prefix "namespacePrefix" of the XElement

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElement(thisSystem.Xml.Linq.XElement,string)'></a>

## XElementExtensions.GetElement(this XElement, string) Method

Gets the element of the given XElement

```csharp
public static System.Xml.Linq.XElement? GetElement(this System.Xml.Linq.XElement element, string elementName);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElement(thisSystem.Xml.Linq.XElement,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElement(thisSystem.Xml.Linq.XElement,string).elementName'></a>

`elementName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of the element that should be returned

#### Returns
[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')  
the "name" element of the XElement

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElements(thisSystem.Xml.Linq.XElement,string,string)'></a>

## XElementExtensions.GetElements(this XElement, string, string) Method

Gets all elements of the given XElement

```csharp
public static System.Collections.Generic.IReadOnlyCollection<System.Xml.Linq.XElement> GetElements(this System.Xml.Linq.XElement element, string? namespacePrefix, string elementName);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElements(thisSystem.Xml.Linq.XElement,string,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElements(thisSystem.Xml.Linq.XElement,string,string).namespacePrefix'></a>

`namespacePrefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the namespace prefix of the elements that should be returned

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElements(thisSystem.Xml.Linq.XElement,string,string).elementName'></a>

`elementName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of the elements that should be returned

#### Returns
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')  
all "name" elements of the given XElement

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElements(thisSystem.Xml.Linq.XElement,string)'></a>

## XElementExtensions.GetElements(this XElement, string) Method

Gets all elements of the given XElement

```csharp
public static System.Collections.Generic.IReadOnlyCollection<System.Xml.Linq.XElement> GetElements(this System.Xml.Linq.XElement element, string elementName);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElements(thisSystem.Xml.Linq.XElement,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetElements(thisSystem.Xml.Linq.XElement,string).elementName'></a>

`elementName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of the elements that should be returned

#### Returns
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')  
all "name" elements of the given XElement

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetNamespacePrefix(thisSystem.Xml.Linq.XElement,string)'></a>

## XElementExtensions.GetNamespacePrefix(this XElement, string) Method

Gets the namespace prefix of the given XElement, if namespacePrefix is null or empty, it returns the default namespace.

```csharp
public static System.Xml.Linq.XNamespace? GetNamespacePrefix(this System.Xml.Linq.XElement element, string? namespacePrefix);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetNamespacePrefix(thisSystem.Xml.Linq.XElement,string).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetNamespacePrefix(thisSystem.Xml.Linq.XElement,string).namespacePrefix'></a>

`namespacePrefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the namespace prefix

#### Returns
[System.Xml.Linq.XNamespace](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XNamespace 'System.Xml.Linq.XNamespace')  
the namespace prefix or default namespace if the [namespacePrefix](Sagara.FeedReader.Extensions.XElementExtensions.md#Sagara.FeedReader.Extensions.XElementExtensions.GetNamespacePrefix(thisSystem.Xml.Linq.XElement,string).namespacePrefix 'Sagara.FeedReader.Extensions.XElementExtensions.GetNamespacePrefix(this System.Xml.Linq.XElement, string).namespacePrefix') is null or empty

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetNamespacePrefix(thisSystem.Xml.Linq.XElement)'></a>

## XElementExtensions.GetNamespacePrefix(this XElement) Method

Gets the namespace prefix of the given XElement

```csharp
public static System.Xml.Linq.XNamespace? GetNamespacePrefix(this System.Xml.Linq.XElement element);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.XElementExtensions.GetNamespacePrefix(thisSystem.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

the xml element

#### Returns
[System.Xml.Linq.XNamespace](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XNamespace 'System.Xml.Linq.XNamespace')  
the namespace prefix

<a name='Sagara.FeedReader.Extensions.XElementExtensions.SplitName(string)'></a>

## XElementExtensions.SplitName(string) Method

Splits the name into namespace and name if it contains a ':'. If it does not contain a   
namespace, the returned namespace is null and name is the original name.

```csharp
private static Sagara.FeedReader.Extensions.XElementExtensions.NamespaceAndName SplitName(string name);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.XElementExtensions.SplitName(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the input name

#### Returns
[Sagara.FeedReader.Extensions.XElementExtensions.NamespaceAndName](https://docs.microsoft.com/en-us/dotnet/api/Sagara.FeedReader.Extensions.XElementExtensions.NamespaceAndName 'Sagara.FeedReader.Extensions.XElementExtensions.NamespaceAndName')  
splitted namespace and name, item1 is null if namespace is empty