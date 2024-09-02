#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Modules.WordPressExport](index.md#Sagara.FeedReader.Modules.WordPressExport 'Sagara.FeedReader.Modules.WordPressExport')

## WordPressExportAuthor Class

  
The podcast owner contact information.

```csharp
public class WordPressExportAuthor
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; WordPressExportAuthor

### Remarks
Note: The <itunes:owner> tag information is for administrative communication about the   
podcast and isn’t displayed in Apple Podcasts. Please make sure the email address is active   
and monitored.
### Constructors

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.WordPressExportAuthor(System.Xml.Linq.XElement)'></a>

## WordPressExportAuthor(XElement) Constructor

.ctor

```csharp
public WordPressExportAuthor(System.Xml.Linq.XElement authorElement);
```
#### Parameters

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.WordPressExportAuthor(System.Xml.Linq.XElement).authorElement'></a>

`authorElement` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')
### Properties

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.DisplayName'></a>

## WordPressExportAuthor.DisplayName Property

The author_display_name element's value.

```csharp
public string? DisplayName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.Email'></a>

## WordPressExportAuthor.Email Property

The author_email element's value.

```csharp
public string? Email { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.FirstName'></a>

## WordPressExportAuthor.FirstName Property

The author_first_name element's value.

```csharp
public string? FirstName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.Id'></a>

## WordPressExportAuthor.Id Property

The author_id element's value.

```csharp
public long Id { get; set; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.LastName'></a>

## WordPressExportAuthor.LastName Property

The author_last_name element's value.

```csharp
public string? LastName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportAuthor.Login'></a>

## WordPressExportAuthor.Login Property

The author_login element's value.

```csharp
public string? Login { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')