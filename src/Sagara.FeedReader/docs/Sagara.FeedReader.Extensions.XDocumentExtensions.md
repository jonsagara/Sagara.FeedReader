#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Extensions](index.md#Sagara.FeedReader.Extensions 'Sagara.FeedReader.Extensions')

## XDocumentExtensions Class

```csharp
internal static class XDocumentExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; XDocumentExtensions
### Methods

<a name='Sagara.FeedReader.Extensions.XDocumentExtensions.GetRootNamespaceDeclarationAttribute(thisSystem.Xml.Linq.XDocument,string)'></a>

## XDocumentExtensions.GetRootNamespaceDeclarationAttribute(this XDocument, string) Method

Try to load an "xmlns" XML namespace declaration attribute from the root element.

```csharp
internal static System.Xml.Linq.XAttribute? GetRootNamespaceDeclarationAttribute(this System.Xml.Linq.XDocument doc, string localName);
```
#### Parameters

<a name='Sagara.FeedReader.Extensions.XDocumentExtensions.GetRootNamespaceDeclarationAttribute(thisSystem.Xml.Linq.XDocument,string).doc'></a>

`doc` [System.Xml.Linq.XDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument')

The xml document.

<a name='Sagara.FeedReader.Extensions.XDocumentExtensions.GetRootNamespaceDeclarationAttribute(thisSystem.Xml.Linq.XDocument,string).localName'></a>

`localName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The local name of the namespace declaration. For example, for attribute "xmlns:itunes",   
            pass "itunes".

#### Returns
[System.Xml.Linq.XAttribute](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XAttribute 'System.Xml.Linq.XAttribute')  
An XAttribute describing the namespace if found; otherwise, null.