#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## AtomPerson Class

Atom 1.0 person element according to specification: https://validator.w3.org/feed/docs/atom.html

```csharp
public class AtomPerson
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AtomPerson
### Constructors

<a name='Sagara.FeedReader.Feeds.AtomPerson.AtomPerson()'></a>

## AtomPerson() Constructor

Initializes a new instance of the [AtomPerson](Sagara.FeedReader.Feeds.AtomPerson.md 'Sagara.FeedReader.Feeds.AtomPerson') class.  
default constructor (for serialization)

```csharp
public AtomPerson();
```

<a name='Sagara.FeedReader.Feeds.AtomPerson.AtomPerson(System.Xml.Linq.XElement)'></a>

## AtomPerson(XElement) Constructor

Initializes a new instance of the [AtomPerson](Sagara.FeedReader.Feeds.AtomPerson.md 'Sagara.FeedReader.Feeds.AtomPerson') class.  
Reads an atom person based on the xml given in element

```csharp
public AtomPerson(System.Xml.Linq.XElement? element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.AtomPerson.AtomPerson(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

person element as xml
### Properties

<a name='Sagara.FeedReader.Feeds.AtomPerson.EMail'></a>

## AtomPerson.EMail Property

The "email" element

```csharp
public string? EMail { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomPerson.Name'></a>

## AtomPerson.Name Property

The "name" element

```csharp
public string? Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.AtomPerson.Uri'></a>

## AtomPerson.Uri Property

The "uri" element

```csharp
public string? Uri { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='Sagara.FeedReader.Feeds.AtomPerson.ToString()'></a>

## AtomPerson.ToString() Method

returns the name of the author including the email if available

```csharp
public override string? ToString();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
name of the author with email if available