#### [DiGi\.GIS\.IO](index.md 'index')

## DiGi\.GIS\.IO Namespace
### Classes

<a name='DiGi.GIS.IO.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.GIS.IO.Create.Column_GridCellCoverage(int,int)'></a>

## Create\.Column\_GridCellCoverage\(int, int\) Method

Creates a column representing normalized grid cell coverage values for a bounding rectangle\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_GridCellCoverage(int widthCount, int heightCount);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_GridCellCoverage(int,int).widthCount'></a>

`widthCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The segment index along the horizontal axis \(0 to 4\)\.

<a name='DiGi.GIS.IO.Create.Column_GridCellCoverage(int,int).heightCount'></a>

`heightCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The segment index along the vertical axis \(0 to 4\)\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')  
A new [DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn') configured with the grid location, target type \(float\), category description, and detailed computation details\.

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapData(int,int,string,string)'></a>

## Create\.Column\_OrthophotomapData\(int, int, string, string\) Method

Creates a column representing comparison data for orthophotomap images taken in two different years\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_OrthophotomapData(int year_1, int year_2, string columnNamePrefix, string columnNameSuffix);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapData(int,int,string,string).year_1'></a>

`year_1` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The first year of the orthophotomap comparison\.

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapData(int,int,string,string).year_2'></a>

`year_2` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The second year of the orthophotomap comparison\.

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapData(int,int,string,string).columnNamePrefix'></a>

`columnNamePrefix` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The prefix describing the type of bounding box filling or method used \(e\.g\., "BB", "P", "PO"\)\.

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapData(int,int,string,string).columnNameSuffix'></a>

`columnNameSuffix` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The suffix describing the metric being compared \(e\.g\., "Average Color Similarity", "Hamming Distance"\)\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')  
A new [DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn') configured with the generated name, target type \(float\), category description, and metadata explanation\.

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapImage(int)'></a>

## Create\.Column\_OrthophotomapImage\(int\) Method

Creates a column containing the URL link to the orthophotomap image for a specific year\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_OrthophotomapImage(int year);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapImage(int).year'></a>

`year` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The year of the orthophotomap image\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')  
A new [DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn') configured with the generated name, target type \(string\), category description, and details of the image link\.

<a name='DiGi.GIS.IO.Create.Column_YearBuit(string,int)'></a>

## Create\.Column\_YearBuit\(string, int\) Method

Creates a column representing prediction data related to the year a building was built\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_YearBuit(string columnNamePrefix, int year);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_YearBuit(string,int).columnNamePrefix'></a>

`columnNamePrefix` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The prefix describing the prediction type \(e\.g\., confidence or bounding box coordinates\)\.

<a name='DiGi.GIS.IO.Create.Column_YearBuit(string,int).year'></a>

`year` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The target prediction year\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')  
A new [DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn') configured with the generated name, target type \(double\), category description, and description text\.

<a name='DiGi.GIS.IO.Modify'></a>

## Modify Class

```csharp
public static class Modify
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Modify
### Methods

<a name='DiGi.GIS.IO.Modify.SetValue(thisDiGi.Core.IO.Table.Classes.Row,DiGi.Core.IO.Table.Classes.Column,object)'></a>

## Modify\.SetValue\(this Row, Column, object\) Method

Sets the value of a specific column in a row, performing input value validation first\.

```csharp
public static void SetValue(this DiGi.Core.IO.Table.Classes.Row? row, DiGi.Core.IO.Table.Classes.Column? column, object? value);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.SetValue(thisDiGi.Core.IO.Table.Classes.Row,DiGi.Core.IO.Table.Classes.Column,object).row'></a>

`row` [DiGi\.Core\.IO\.Table\.Classes\.Row](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.row 'DiGi\.Core\.IO\.Table\.Classes\.Row')

The row in which the value is to be set\.

<a name='DiGi.GIS.IO.Modify.SetValue(thisDiGi.Core.IO.Table.Classes.Row,DiGi.Core.IO.Table.Classes.Column,object).column'></a>

`column` [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')

The column whose value is to be set\.

<a name='DiGi.GIS.IO.Modify.SetValue(thisDiGi.Core.IO.Table.Classes.Row,DiGi.Core.IO.Table.Classes.Column,object).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The new value to set, which will be validated before setting\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_)'></a>

## Modify\.Update\(this Table, int, Nullable\<int\>, IEnumerable\<Building2D\>, IEnumerable\<Building2DYearBuiltPredictions\>, IEnumerable\<OrtoDatasComparison\>, IEnumerable\<AdministrativeAreal2D\>\) Method

Updates the table with building data, year built predictions, orthophotomap comparisons, and administrative boundaries\.

```csharp
public static void Update(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Nullable<int> subdivisionId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2DYearBuiltPredictions>? building2DYearBuiltPredictions=null, System.Collections.Generic.IEnumerable<DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison>? ortoDatasComparisons=null, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.AdministrativeAreal2D>? administrativeAreal2Ds=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).subdivisionId'></a>

`subdivisionId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional unique identifier of the subdivision\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).building2DYearBuiltPredictions'></a>

`building2DYearBuiltPredictions` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2dyearbuiltpredictions 'DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The optional collection of year built predictions to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).ortoDatasComparisons'></a>

`ortoDatasComparisons` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Emgu\.CV\.Classes\.OrtoDatasComparison](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.emgu.cv.classes.ortodatascomparison 'DiGi\.GIS\.Emgu\.CV\.Classes\.OrtoDatasComparison')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The optional collection of orthophotomap data comparisons to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).administrativeAreal2Ds'></a>

`administrativeAreal2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.AdministrativeAreal2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.administrativeareal2d 'DiGi\.GIS\.Classes\.AdministrativeAreal2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The optional collection of administrative boundary areas to update\.

<a name='DiGi.GIS.IO.Modify.UpdateColumn_TColumn_(thisDiGi.Core.IO.Table.Classes.Table,TColumn)'></a>

## Modify\.UpdateColumn\<TColumn\>\(this Table, TColumn\) Method

Updates an existing column in the table, or adds it if it does not exist\.

```csharp
public static TColumn? UpdateColumn<TColumn>(this DiGi.Core.IO.Table.Classes.Table? table, TColumn column)
    where TColumn : DiGi.Core.IO.Table.Classes.Column;
```
#### Type parameters

<a name='DiGi.GIS.IO.Modify.UpdateColumn_TColumn_(thisDiGi.Core.IO.Table.Classes.Table,TColumn).TColumn'></a>

`TColumn`

The type of the column to update, which must inherit from [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')\.
#### Parameters

<a name='DiGi.GIS.IO.Modify.UpdateColumn_TColumn_(thisDiGi.Core.IO.Table.Classes.Table,TColumn).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table containing the column\.

<a name='DiGi.GIS.IO.Modify.UpdateColumn_TColumn_(thisDiGi.Core.IO.Table.Classes.Table,TColumn).column'></a>

`column` [TColumn](DiGi.GIS.IO.md#DiGi.GIS.IO.Modify.UpdateColumn_TColumn_(thisDiGi.Core.IO.Table.Classes.Table,TColumn).TColumn 'DiGi\.GIS\.IO\.Modify\.UpdateColumn\<TColumn\>\(this DiGi\.Core\.IO\.Table\.Classes\.Table, TColumn\)\.TColumn')

The column template or definition to update or add\.

#### Returns
[TColumn](DiGi.GIS.IO.md#DiGi.GIS.IO.Modify.UpdateColumn_TColumn_(thisDiGi.Core.IO.Table.Classes.Table,TColumn).TColumn 'DiGi\.GIS\.IO\.Modify\.UpdateColumn\<TColumn\>\(this DiGi\.Core\.IO\.Table\.Classes\.Table, TColumn\)\.TColumn')  
The updated column matching the specified type, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if the table or column parameter is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_)'></a>

## Modify\.Update\_Building2D\(this Table, int, IEnumerable\<Building2D\>\) Method

Updates the table with building 2D geometric and shape descriptor features for a specific county\.

```csharp
public static void Update_Building2D(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_)'></a>

## Modify\.Update\_Building2D\(this Table, int, Nullable\<int\>, IEnumerable\<Building2D\>, IEnumerable\<AdministrativeAreal2D\>\) Method

Updates the table with building 2D geometric and administrative features for a specific county and optional subdivision\.

```csharp
public static void Update_Building2D(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Nullable<int> subdivisionId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.AdministrativeAreal2D>? administrativeAreal2Ds);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).subdivisionId'></a>

`subdivisionId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional unique identifier of the subdivision\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).administrativeAreal2Ds'></a>

`administrativeAreal2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.AdministrativeAreal2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.administrativeareal2d 'DiGi\.GIS\.Classes\.AdministrativeAreal2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of administrative boundary areas\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Occupancy(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_)'></a>

## Modify\.Update\_Building2D\_Occupancy\(this Table, int, IEnumerable\<Building2D\>\) Method

Updates the table with building 2D occupancy features for a specific county\.

```csharp
public static void Update_Building2D_Occupancy(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Occupancy(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Occupancy(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Occupancy(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_YearBuiltPredictions(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_)'></a>

## Modify\.Update\_Building2D\_YearBuiltPredictions\(this Table, int, IEnumerable\<Building2DYearBuiltPredictions\>\) Method

Updates the table with year\-built predictions for structures in a specific county\.

```csharp
public static void Update_Building2D_YearBuiltPredictions(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2DYearBuiltPredictions>? building2DYearBuiltPredictions);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D_YearBuiltPredictions(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_YearBuiltPredictions(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_YearBuiltPredictions(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_).building2DYearBuiltPredictions'></a>

`building2DYearBuiltPredictions` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2dyearbuiltpredictions 'DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of year\-built predictions\.

<a name='DiGi.GIS.IO.Modify.Update_OrtoDatasComparison(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_)'></a>

## Modify\.Update\_OrtoDatasComparison\(this Table, int, IEnumerable\<OrtoDatasComparison\>\) Method

Updates the table with orthophotomap comparison data for structures in a specific county\.

```csharp
public static void Update_OrtoDatasComparison(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison>? ortoDatasComparisons);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_OrtoDatasComparison(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_OrtoDatasComparison(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_OrtoDatasComparison(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_).ortoDatasComparisons'></a>

`ortoDatasComparisons` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Emgu\.CV\.Classes\.OrtoDatasComparison](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.emgu.cv.classes.ortodatascomparison 'DiGi\.GIS\.Emgu\.CV\.Classes\.OrtoDatasComparison')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of orthophotomap data comparisons\.