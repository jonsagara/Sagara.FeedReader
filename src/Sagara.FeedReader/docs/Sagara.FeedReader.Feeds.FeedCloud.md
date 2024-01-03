#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Feeds](index.md#Sagara.FeedReader.Feeds 'Sagara.FeedReader.Feeds')

## FeedCloud Class

Cloud object according to Rss 2.0 specification: https://validator.w3.org/feed/docs/rss2.html#ltcloudgtSubelementOfLtchannelgt

```csharp
public class FeedCloud
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FeedCloud
### Constructors

<a name='Sagara.FeedReader.Feeds.FeedCloud.FeedCloud()'></a>

## FeedCloud() Constructor

Initializes a new instance of the [FeedCloud](Sagara.FeedReader.Feeds.FeedCloud.md 'Sagara.FeedReader.Feeds.FeedCloud') class.  
default constructor (for serialization)

```csharp
public FeedCloud();
```

<a name='Sagara.FeedReader.Feeds.FeedCloud.FeedCloud(System.Xml.Linq.XElement)'></a>

## FeedCloud(XElement) Constructor

Initializes a new instance of the [FeedCloud](Sagara.FeedReader.Feeds.FeedCloud.md 'Sagara.FeedReader.Feeds.FeedCloud') class.  
Reads a rss feed cloud element based on the xml given in element

```csharp
public FeedCloud(System.Xml.Linq.XElement? element);
```
#### Parameters

<a name='Sagara.FeedReader.Feeds.FeedCloud.FeedCloud(System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

cloud element as xml
### Properties

<a name='Sagara.FeedReader.Feeds.FeedCloud.Domain'></a>

## FeedCloud.Domain Property

The "domain" element

```csharp
public string? Domain { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.FeedCloud.Path'></a>

## FeedCloud.Path Property

The "path" element

```csharp
public string? Path { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.FeedCloud.Port'></a>

## FeedCloud.Port Property

The "port" element

```csharp
public string? Port { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.FeedCloud.Protocol'></a>

## FeedCloud.Protocol Property

The "protocol" element

```csharp
public string? Protocol { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Feeds.FeedCloud.RegisterProcedure'></a>

## FeedCloud.RegisterProcedure Property

The "registerProcedure" element

```csharp
public string? RegisterProcedure { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')