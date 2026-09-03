#### [DiGi\.GIS\.IO](DiGi.GIS.IO.Overview.md 'DiGi\.GIS\.IO\.Overview')

## DiGi\.GIS\.IO Namespace
### Classes

<a name='DiGi.GIS.IO.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.GIS.IO.Create.Columns_Population(DiGi.Core.Classes.Range_int_)'></a>

## Create\.Columns\_Population\(Range\<int\>\) Method

Creates a collection of demographic municipality population columns across a range of years\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_Population(DiGi.Core.Classes.Range<int>? years);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_Population(DiGi.Core.Classes.Range_int_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of target years\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing municipality population attributes for the specified range of years, or an empty list if null\.

<a name='DiGi.GIS.IO.Create.Columns_Population(int)'></a>

## Create\.Columns\_Population\(int\) Method

Creates a single\-element collection containing a demographic municipality population column for the specified year\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_Population(int year);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_Population(int).year'></a>

`year` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The target year for the municipality population count\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list containing a single [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instance configured for the specified year\.

<a name='DiGi.GIS.IO.Create.Columns_Population(System.Collections.Generic.IEnumerable_int_)'></a>

## Create\.Columns\_Population\(IEnumerable\<int\>\) Method

Creates a collection of demographic municipality population columns for a sequence of years\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_Population(System.Collections.Generic.IEnumerable<int>? years);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_Population(System.Collections.Generic.IEnumerable_int_).years'></a>

`years` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The sequence of target years\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing municipality population attributes for the specified years, or an empty list if null\.

<a name='DiGi.GIS.IO.Create.Columns_PredictionYearBuilt(DiGi.Core.Classes.Range_int_)'></a>

## Create\.Columns\_PredictionYearBuilt\(Range\<int\>\) Method

Creates the collection of prediction columns \(confidence, centroid coordinates, and dimensions\) across a range of years\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_PredictionYearBuilt(DiGi.Core.Classes.Range<int>? years);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_PredictionYearBuilt(DiGi.Core.Classes.Range_int_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of target prediction years\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the prediction attributes for the specified range of years, or an empty list if null\.

<a name='DiGi.GIS.IO.Create.Columns_PredictionYearBuilt(int)'></a>

## Create\.Columns\_PredictionYearBuilt\(int\) Method

Creates the collection of prediction columns \(confidence, centroid coordinates, and dimensions\) for a specified year\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_PredictionYearBuilt(int year);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_PredictionYearBuilt(int).year'></a>

`year` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The target prediction year\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the prediction attributes for the specified year\.

<a name='DiGi.GIS.IO.Create.Columns_PredictionYearBuilt(System.Collections.Generic.IEnumerable_int_)'></a>

## Create\.Columns\_PredictionYearBuilt\(IEnumerable\<int\>\) Method

Creates the collection of prediction columns \(confidence, centroid coordinates, and dimensions\) across a collection of years\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_PredictionYearBuilt(System.Collections.Generic.IEnumerable<int>? years);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_PredictionYearBuilt(System.Collections.Generic.IEnumerable_int_).years'></a>

`years` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of target prediction years\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the prediction attributes for the specified years, or an empty list if null\.

<a name='DiGi.GIS.IO.Create.Columns_RadialRatios(double)'></a>

## Create\.Columns\_RadialRatios\(double\) Method

Creates a collection containing the radial ratio columns \(building coverage ratio and floor area ratio\) for the specified radius\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_RadialRatios(double radius);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_RadialRatios(double).radius'></a>

`radius` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The radius in meters\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the radial ratios for the specified radius\.

<a name='DiGi.GIS.IO.Create.Columns_RadialRatios(System.Collections.Generic.IEnumerable_double_)'></a>

## Create\.Columns\_RadialRatios\(IEnumerable\<double\>\) Method

Creates a collection of radial ratio columns \(building coverage ratio and floor area ratio\) for a collection of radiuses\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_RadialRatios(System.Collections.Generic.IEnumerable<double>? radiuses);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_RadialRatios(System.Collections.Generic.IEnumerable_double_).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of radiuses in meters\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the radial ratios for the specified radiuses, or an empty list if null\.

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

<a name='DiGi.GIS.IO.Create.Column_Population(int)'></a>

## Create\.Column\_Population\(int\) Method

Creates a column representing demographic municipality population for a specific year\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_Population(int year);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_Population(int).year'></a>

`year` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The target year for the municipality population count\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')  
A new [DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn') configured with the generated name, target type \(int\), category description, and metadata explanation\.

<a name='DiGi.GIS.IO.Create.Column_PredictionYearBuit(string,int)'></a>

## Create\.Column\_PredictionYearBuit\(string, int\) Method

Creates a column representing prediction data related to the year a building was built\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_PredictionYearBuit(string columnNamePrefix, int year);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_PredictionYearBuit(string,int).columnNamePrefix'></a>

`columnNamePrefix` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The prefix describing the prediction type \(e\.g\., confidence or bounding box coordinates\)\.

<a name='DiGi.GIS.IO.Create.Column_PredictionYearBuit(string,int).year'></a>

`year` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The target prediction year\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')  
A new [DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn') configured with the generated name, target type \(double\), category description, and description text\.

<a name='DiGi.GIS.IO.Create.Column_RadialBuildingCoverageRatio(double)'></a>

## Create\.Column\_RadialBuildingCoverageRatio\(double\) Method

Creates a column representing radial building coverage ratio for given radius\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_RadialBuildingCoverageRatio(double radius);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_RadialBuildingCoverageRatio(double).radius'></a>

`radius` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Radius \[m\]

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')

<a name='DiGi.GIS.IO.Create.Column_RadialFloorAreaRatio(double)'></a>

## Create\.Column\_RadialFloorAreaRatio\(double\) Method

Creates a column representing radial floor area ratio for given radius\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_RadialFloorAreaRatio(double radius);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_RadialFloorAreaRatio(double).radius'></a>

`radius` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Radius \[m\]

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')

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

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string)'></a>

## Modify\.Update\(this Table, int, Nullable\<int\>, IEnumerable\<Building2D\>, IEnumerable\<Building2DYearBuiltPredictions\>, IEnumerable\<OrtoDatasComparison\>, IEnumerable\<AdministrativeAreal2D\>, string\) Method

Updates the table with building data, year built predictions, orthophotomap comparisons, and administrative boundaries\.

```csharp
public static void Update(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Nullable<int> subdivisionId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2DYearBuiltPredictions>? building2DYearBuiltPredictions=null, System.Collections.Generic.IEnumerable<DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison>? ortoDatasComparisons=null, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.AdministrativeAreal2D>? administrativeAreal2Ds=null, string? apiBaseUrl=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).subdivisionId'></a>

`subdivisionId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional unique identifier of the subdivision\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).building2DYearBuiltPredictions'></a>

`building2DYearBuiltPredictions` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2dyearbuiltpredictions 'DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The optional collection of year built predictions to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).ortoDatasComparisons'></a>

`ortoDatasComparisons` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Emgu\.CV\.Classes\.OrtoDatasComparison](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.emgu.cv.classes.ortodatascomparison 'DiGi\.GIS\.Emgu\.CV\.Classes\.OrtoDatasComparison')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The optional collection of orthophotomap data comparisons to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).administrativeAreal2Ds'></a>

`administrativeAreal2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.AdministrativeAreal2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.administrativeareal2d 'DiGi\.GIS\.Classes\.AdministrativeAreal2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The optional collection of administrative boundary areas to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).apiBaseUrl'></a>

`apiBaseUrl` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The optional API base URL to construct orthophotomap links\.

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

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string)'></a>

## Modify\.Update\_Building2D\(this Table, int, IEnumerable\<Building2D\>, string\) Method

Updates the table with building 2D geometric and shape descriptor features for a specific county\.

Adds and writes the identity columns `Reference` and `County Id`; the function and phase columns `Building general function`, `Building specific functions` and `Building Phase`; the shape columns `Storeys`, `Floor area`, `Total area`, `Internal Point X`, `Internal Point Y`, `BoundingBox X`, `BoundingBox Y`, `BoundingBox width`, `BoundingBox height`, `Cardinal direction`, `Azimuth`, `Isoperimetric ratio`, `Thinness ratio`, `Rectangular thinnes ratio`, `Square thinness ratio`, `Convex hull thinness ratio` and `Calculated Building Shape`; the occupancy flags `Is occupied` and `Is residential`; the per-year orthophotomap link columns; and the grid cell coverage columns.

A cell is written only when its value is computable - the areas only when the outline has one, the internal point and the bounding box only when the outline yields them, the shape only when the solver resolves - so an uncomputable value leaves the cell unset rather than storing a placeholder.

Pushed via `TablePostgreSQLConverter.PushAsync`, the upsert - `ON CONFLICT (county_id, reference) DO UPDATE SET col = EXCLUDED.col` - covers every column present on the table, so a cell left unset on a row is written as NULL and overwrites the stored value of an existing row, while a column this method never adds is never touched.

```csharp
public static void Update_Building2D(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, string? apiBaseUrl=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string).apiBaseUrl'></a>

`apiBaseUrl` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The optional API base URL to construct orthophotomap links\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision)'></a>

## Modify\.Update\_Building2D\(this Table, int, Nullable\<int\>, IEnumerable\<Building2D\>, string, string, string, AdministrativeSubdivision\) Method

Updates the table with building 2D administrative features for a specific county and optional subdivision, taking the administrative names directly rather than reading them off boundary objects\.

This is the overload to reach for from a caller that already knows the names - the reference path of a subdivision carries them - because the boundary objects the other overload takes hold the outlines as well, and those are never read here. At the top of an ancestor chain that outline is the whole country, so loading one per subdivision is the dominant cost of a country-wide run and buys nothing.

Adds the administrative columns `Subdivision Id`, `County name`, `Municipality name`, `Voivodeship name`, `Subdivision name`, `Subdivision occupancy` and `Settlement type` to the table, and writes each cell only when its value is present.

The columns are added to the table even when a value does not resolve, and pushed via `TablePostgreSQLConverter.PushAsync` the upsert - `ON CONFLICT (county_id, reference) DO UPDATE SET col = EXCLUDED.col` - covers every column present on the table. An unset cell is written as NULL, so a name that does not resolve on a re-run clears the value previously stored on an existing row; only a column never added to the table is left untouched.

```csharp
public static void Update_Building2D(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Nullable<int> subdivisionId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, string? countyName, string? municipalityName, string? voivodeshipName, DiGi.GIS.Classes.AdministrativeSubdivision? administrativeSubdivision);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).subdivisionId'></a>

`subdivisionId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional unique identifier of the subdivision\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).countyName'></a>

`countyName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The optional name of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).municipalityName'></a>

`municipalityName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The optional name of the municipality\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).voivodeshipName'></a>

`voivodeshipName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The optional name of the voivodeship\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).administrativeSubdivision'></a>

`administrativeSubdivision` [DiGi\.GIS\.Classes\.AdministrativeSubdivision](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.administrativesubdivision 'DiGi\.GIS\.Classes\.AdministrativeSubdivision')

The optional subdivision, read for its name, occupancy and settlement type\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_)'></a>

## Modify\.Update\_Building2D\(this Table, int, Nullable\<int\>, IEnumerable\<Building2D\>, IEnumerable\<AdministrativeAreal2D\>\) Method

Updates the table with building 2D geometric and administrative features for a specific county and optional subdivision\.

Reads only the name of each division and the name, occupancy and type of the first subdivision out of [administrativeAreal2Ds](DiGi.GIS.IO.md#DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).administrativeAreal2Ds 'DiGi\.GIS\.IO\.Modify\.Update\_Building2D\(this DiGi\.Core\.IO\.Table\.Classes\.Table, int, System\.Nullable\<int\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.Building2D\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.AdministrativeAreal2D\>\)\.administrativeAreal2Ds'), then hands those to the overload that takes them directly. A caller that already holds the names - the reference path of a subdivision carries them - should call that overload instead and avoid loading the outlines, which are never read here and reach the size of a whole country at the top of the chain. The administrative columns written, and the unset-cell semantics of the push, are those of the overload it delegates to.

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

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalDataCollection,DiGi.Core.Classes.Range_int_)'></a>

## Modify\.Update\_Building2D\_Population\(this Table, int, IEnumerable\<Building2D\>, StatisticalDataCollection, Range\<int\>\) Method

Updates the table with yearly municipality population data for building 2D geometries in a specific county from a statistical data collection\.

```csharp
public static void Update_Building2D_Population(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, DiGi.GIS.Classes.StatisticalDataCollection? statisticalDataCollection, DiGi.Core.Classes.Range<int>? years=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalDataCollection,DiGi.Core.Classes.Range_int_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalDataCollection,DiGi.Core.Classes.Range_int_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalDataCollection,DiGi.Core.Classes.Range_int_).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalDataCollection,DiGi.Core.Classes.Range_int_).statisticalDataCollection'></a>

`statisticalDataCollection` [DiGi\.GIS\.Classes\.StatisticalDataCollection](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.statisticaldatacollection 'DiGi\.GIS\.Classes\.StatisticalDataCollection')

The statistical data collection containing the municipality population data\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalDataCollection,DiGi.Core.Classes.Range_int_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The optional range of years for the population series, defaulting to 2008\.\.2025\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalYearlyDoubleData,DiGi.Core.Classes.Range_int_)'></a>

## Modify\.Update\_Building2D\_Population\(this Table, int, IEnumerable\<Building2D\>, StatisticalYearlyDoubleData, Range\<int\>\) Method

Updates the table with yearly municipality population data for building 2D geometries in a specific county from a yearly double data series\.

```csharp
public static void Update_Building2D_Population(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, DiGi.GIS.Classes.StatisticalYearlyDoubleData? statisticalYearlyDoubleData, DiGi.Core.Classes.Range<int>? years=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalYearlyDoubleData,DiGi.Core.Classes.Range_int_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalYearlyDoubleData,DiGi.Core.Classes.Range_int_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalYearlyDoubleData,DiGi.Core.Classes.Range_int_).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalYearlyDoubleData,DiGi.Core.Classes.Range_int_).statisticalYearlyDoubleData'></a>

`statisticalYearlyDoubleData` [DiGi\.GIS\.Classes\.StatisticalYearlyDoubleData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.statisticalyearlydoubledata 'DiGi\.GIS\.Classes\.StatisticalYearlyDoubleData')

The yearly statistical double data containing municipality population counts\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalYearlyDoubleData,DiGi.Core.Classes.Range_int_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The optional range of years for the population series, defaulting to 2008\.\.2025\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_PredictedYearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_)'></a>

## Modify\.Update\_Building2D\_PredictedYearBuilt\(this Table, int, IEnumerable\<YearBuiltData\>\) Method

Updates the table with the latest predicted year built of each building in a specific county\.

A building may hold several stored [DiGi\.GIS\.Classes\.YearBuiltData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.yearbuiltdata 'DiGi\.GIS\.Classes\.YearBuiltData') records - the table appends rather than replaces - so the predictions of every record carrying the same reference are considered together and the one made most recently wins.

Rows already in the table are matched on county identifier and reference; a reference the table does not hold yet is appended, so the same method serves a run that is building rows from buildings and a run that is writing predictions on their own.

```csharp
public static void Update_Building2D_PredictedYearBuilt(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.YearBuiltData>? yearBuiltDatas);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D_PredictedYearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_PredictedYearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_PredictedYearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_).yearBuiltDatas'></a>

`yearBuiltDatas` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.YearBuiltData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.yearbuiltdata 'DiGi\.GIS\.Classes\.YearBuiltData')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of stored year built data to take the predictions from\.

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

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double)'></a>

## Modify\.Update\_RadialRatios\(this Table, IEnumerable\<double\>, int, Building2D, IEnumerable\<Building2D\>, double\) Method

Updates the table with radial ratios \(Radial Building Coverage Ratio and Radial Floor Area Ratio\) for a specific county and building 2D geometry\.

```csharp
public static void Update_RadialRatios(this DiGi.Core.IO.Table.Classes.Table? table, System.Collections.Generic.IEnumerable<double> radiuses, int countyId, DiGi.GIS.Classes.Building2D? building2D, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The list of radiuses to consider\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ID of the county\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).building2D'></a>

`building2D` [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')

The building 2D\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The list of building 2Ds\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The tolerance for distance calculations\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double)'></a>

## Modify\.Update\_RadialRatios\(this Table, IEnumerable\<double\>, int, IEnumerable\<Building2D\>, IEnumerable\<Building2D\>, double\) Method

Updates the table with radial ratios \(Radial Building Coverage Ratio and Radial Floor Area Ratio\) for a whole collection of buildings at once\.

This is the overload to reach for when more than one building is measured against the same surroundings. The table row index, the ratio columns, each neighbour's outline area and bounding box, and a grid index over the neighbours are all built once for the collection rather than once per building - the single-building overload delegates here with a collection of one, so a per-building loop over it repeats all of that work for every building and rescans the whole table each time.

[building2Ds\_Neighbour](DiGi.GIS.IO.md#DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).building2Ds_Neighbour 'DiGi\.GIS\.IO\.Modify\.Update\_RadialRatios\(this DiGi\.Core\.IO\.Table\.Classes\.Table, System\.Collections\.Generic\.IEnumerable\<double\>, int, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.Building2D\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.Building2D\>, double\)\.building2Ds\_Neighbour') is the surroundings, not the subjects: it must already cover every building within the largest radius of every subject, including buildings outside the subjects' own area, and it normally contains the subjects themselves as well - a building counts towards its own ratios.

```csharp
public static void Update_RadialRatios(this DiGi.Core.IO.Table.Classes.Table? table, System.Collections.Generic.IEnumerable<double> radiuses, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds_Neighbour, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The list of radiuses to consider\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ID of the county\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The buildings the ratios are measured for and written against\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).building2Ds_Neighbour'></a>

`building2Ds_Neighbour` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The surrounding buildings the ratios are measured over\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The tolerance for distance calculations\.

<a name='DiGi.GIS.IO.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_)'></a>

## Query\.YearBuiltPredictionInputColumns\(Range\<int\>, IEnumerable\<double\>\) Method

Retrieves the list of columns permitted as input features for the Year Built prediction machine learning model across the specified range of years and radial radiuses\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> YearBuiltPredictionInputColumns(DiGi.Core.Classes.Range<int>? years=null, System.Collections.Generic.IEnumerable<double>? radiuses=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of years for detection and temporal features\. Defaults to 2008\.\.2025 when null\.

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of radiuses for radial ratio features\. Defaults to 200, 400, 600, 1000 when null\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the allowed input features\.

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionOutputColumns()'></a>

## Query\.YearBuiltPredictionOutputColumns\(\) Method

Retrieves the list of columns written as output by the Year Built prediction machine learning model pipeline\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> YearBuiltPredictionOutputColumns();
```

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the model output columns\.