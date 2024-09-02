#### [Sagara.FeedReader](index.md 'index')
### [Sagara.FeedReader.Modules.WordPressExport](index.md#Sagara.FeedReader.Modules.WordPressExport 'Sagara.FeedReader.Modules.WordPressExport')

## WordPressExportItem Class

Per-post data from a WordPress Export Item.

```csharp
public class WordPressExportItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; WordPressExportItem
### Constructors

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.WordPressExportItem(System.Xml.Linq.XElement)'></a>

## WordPressExportItem(XElement) Constructor

.ctor

```csharp
public WordPressExportItem(System.Xml.Linq.XElement itemElement);
```
#### Parameters

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.WordPressExportItem(System.Xml.Linq.XElement).itemElement'></a>

`itemElement` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')
### Properties

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.Comments'></a>

## WordPressExportItem.Comments Property

The post's comments.

```csharp
public System.Collections.Generic.IReadOnlyCollection<Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment> Comments { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[WordPressExportComment](Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment.md 'Sagara.FeedReader.Modules.WordPressExport.WordPressExportComment')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.CommentStatus'></a>

## WordPressExportItem.CommentStatus Property

The comment_status element's value.

```csharp
public string CommentStatus { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.Content'></a>

## WordPressExportItem.Content Property

The post's content.

```csharp
public string Content { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.Excerpt'></a>

## WordPressExportItem.Excerpt Property

An excerpt of the post's content.

```csharp
public string? Excerpt { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.IsSticky'></a>

## WordPressExportItem.IsSticky Property

The is_sticky element's value.

```csharp
public bool IsSticky { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.MenuOrder'></a>

## WordPressExportItem.MenuOrder Property

The menu_order element's value.

```csharp
public long MenuOrder { get; set; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PingStatus'></a>

## WordPressExportItem.PingStatus Property

The ping_status element's value.

```csharp
public string PingStatus { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostDate'></a>

## WordPressExportItem.PostDate Property

The post_date element's value.

```csharp
public System.DateTime PostDate { get; set; }
```

#### Property Value
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostDateGmt'></a>

## WordPressExportItem.PostDateGmt Property

The post_date_gmt element's value.

```csharp
public System.DateTime PostDateGmt { get; set; }
```

#### Property Value
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostId'></a>

## WordPressExportItem.PostId Property

The post_id element's value.

```csharp
public long PostId { get; set; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostModified'></a>

## WordPressExportItem.PostModified Property

The post_modified element's value.

```csharp
public System.DateTime PostModified { get; set; }
```

#### Property Value
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostModifiedGmt'></a>

## WordPressExportItem.PostModifiedGmt Property

The post_modified_gmt element's value.

```csharp
public System.DateTime PostModifiedGmt { get; set; }
```

#### Property Value
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostName'></a>

## WordPressExportItem.PostName Property

The post_name element's value.

```csharp
public string PostName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostParent'></a>

## WordPressExportItem.PostParent Property

The post_parent element's value.

```csharp
public long PostParent { get; set; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostPassword'></a>

## WordPressExportItem.PostPassword Property

The post_password element's value.

```csharp
public string? PostPassword { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.PostType'></a>

## WordPressExportItem.PostType Property

The post_type element's value.

```csharp
public string PostType { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Sagara.FeedReader.Modules.WordPressExport.WordPressExportItem.Status'></a>

## WordPressExportItem.Status Property

The status element's value.

```csharp
public string Status { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')