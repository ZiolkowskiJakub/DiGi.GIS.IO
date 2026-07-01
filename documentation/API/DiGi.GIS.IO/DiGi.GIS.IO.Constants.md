#### [DiGi\.GIS\.IO](index.md 'index')

## DiGi\.GIS\.IO\.Constants Namespace
### Classes

<a name='DiGi.GIS.IO.Constants.Column'></a>

## Column Class

Provides static references to standard table columns used throughout the GIS IO system\.

```csharp
public static class Column
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Column
### Fields

<a name='DiGi.GIS.IO.Constants.Column.Azimuth'></a>

## Column\.Azimuth Field

Azimuth as an angle to north direction\.

```csharp
public static UnitColumn Azimuth;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.BoundingBoxHeight'></a>

## Column\.BoundingBoxHeight Field

BoundingBox height calculated based on geometry data from BDOO Geoportal \*\.gml file \(ot:geometria node\)\.

```csharp
public static UnitColumn BoundingBoxHeight;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.BoundingBoxWidth'></a>

## Column\.BoundingBoxWidth Field

BoundingBox width calculated based on geometry data from BDOO Geoportal \*\.gml file \(ot:geometria node\)\.

```csharp
public static UnitColumn BoundingBoxWidth;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.BoundingBoxX'></a>

## Column\.BoundingBoxX Field

BoundingBox center point X coordinate coming from BDOO Geoportal \*\.gml file \(ot:geometria node\)\.

```csharp
public static ExtendedColumn BoundingBoxX;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.BoundingBoxY'></a>

## Column\.BoundingBoxY Field

BoundingBox center point Y coordinate coming from BDOO Geoportal \*\.gml file \(ot:geometria node\)\.

```csharp
public static ExtendedColumn BoundingBoxY;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.BuildingGeneralFunction'></a>

## Column\.BuildingGeneralFunction Field

Building general function from BDOO Geoportal \*\.gml file \(ot:funkcjaOgolnaBudynku node\)\.

```csharp
public static ExtendedColumn BuildingGeneralFunction;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.BuildingPhase'></a>

## Column\.BuildingPhase Field

Current building phase coming from BDOO Geoportal \*\.gml file \(ot:kategoriaIstnienia node\)\.

```csharp
public static ExtendedColumn BuildingPhase;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.BuildingSpecificFunctions'></a>

## Column\.BuildingSpecificFunctions Field

Building specific functions from BDOO Geoportal \*\.gml file \(ot:funkcjaSzczegolowaBudynku node\)\.

```csharp
public static ExtendedColumn BuildingSpecificFunctions;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.CalculatedBuildingShape'></a>

## Column\.CalculatedBuildingShape Field

Building shape \(e\.g\., Square, Rectangular, L, U, T, etc\.\) calculated using the BuildingShapeSolver engine via geometric ratios and bounding box analysis\.

```csharp
public static ExtendedColumn CalculatedBuildingShape;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.CalculatedOccupancy'></a>

## Column\.CalculatedOccupancy Field

Calculated occupancy\.

```csharp
public static ExtendedColumn CalculatedOccupancy;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.CardinalDirection'></a>

## Column\.CardinalDirection Field

Cardinal direction calculated from azimuth\.

```csharp
public static ExtendedColumn CardinalDirection;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.ConvexHullThinnessRatio'></a>

## Column\.ConvexHullThinnessRatio Field

Shape descriptor that measures how elongated or “thin” a shape is compared to a convex hull that perfectly fits around it \(its envelope or convex enclosure\)\.

```csharp
public static ExtendedColumn ConvexHullThinnessRatio;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.CountyId'></a>

## Column\.CountyId Field

County id where the object belongs to\.

```csharp
public static ExtendedColumn CountyId;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.CountyName'></a>

## Column\.CountyName Field

County \(powiat\) name where the object belongs to\.

```csharp
public static ExtendedColumn CountyName;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.DatabaseId'></a>

## Column\.DatabaseId Field

Database Id for the building\.

```csharp
public static ExtendedColumn DatabaseId;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.FloorArea'></a>

## Column\.FloorArea Field

Calculated floor area based on geometry data from BDOO Geoportal \*\.gml file \(ot:geometria node\)\.

```csharp
public static UnitColumn FloorArea;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.InternalPointX'></a>

## Column\.InternalPointX Field

X coordinate of internal point calculated based on bounding box coming from BDOO Geoportal \*\.gml file \(ot:geometria node\)\.

```csharp
public static ExtendedColumn InternalPointX;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.InternalPointY'></a>

## Column\.InternalPointY Field

Y coordinate of internal point calculated based on bounding box coming from BDOO Geoportal \*\.gml file \(ot:geometria node\)\.

```csharp
public static ExtendedColumn InternalPointY;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.IsOccupied'></a>

## Column\.IsOccupied Field

Determines if building is occupied\.

```csharp
public static ExtendedColumn IsOccupied;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.IsoperimetricRatio'></a>

## Column\.IsoperimetricRatio Field

Ratio of the curve area to the area of a circle with same perimeter as the curve\.

```csharp
public static ExtendedColumn IsoperimetricRatio;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.IsResidential'></a>

## Column\.IsResidential Field

Determines if building is residental\.

```csharp
public static ExtendedColumn IsResidential;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.MunicipalityName'></a>

## Column\.MunicipalityName Field

Municipality \(gmina\) name where the object belongs to\.

```csharp
public static ExtendedColumn MunicipalityName;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.PredictedBuildingShape'></a>

## Column\.PredictedBuildingShape Field

Predicted Building Shape based on Machine Learning engine\.

```csharp
public static ExtendedColumn PredictedBuildingShape;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.PredictedYearBuilt'></a>

## Column\.PredictedYearBuilt Field

Predicted year built based on historical data analyzed by a Machine Learning engine\.

```csharp
public static ExtendedColumn PredictedYearBuilt;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.RectangularThinnessRatio'></a>

## Column\.RectangularThinnessRatio Field

Ratio of the shape area to the area of its minimum bounding rectangle\.

```csharp
public static ExtendedColumn RectangularThinnessRatio;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.Reference'></a>

## Column\.Reference Field

Main reference of the object coming from BDOO Geoportal \*\.gml file \(ot:lokalnyId node\)\.

```csharp
public static ExtendedColumn Reference;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.SettlementType'></a>

## Column\.SettlementType Field

Settlement type such as rural or urban\.

```csharp
public static ExtendedColumn SettlementType;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.SquareThinnessRatio'></a>

## Column\.SquareThinnessRatio Field

Ratio of the shape area to the area of its minimum bounding square\.

```csharp
public static ExtendedColumn SquareThinnessRatio;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.Storeys'></a>

## Column\.Storeys Field

Number of building storeys coming from BDOO Geoportal \*\.gml file \(ot:liczbaKondygnacji node\)\.

```csharp
public static ExtendedColumn Storeys;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.SubdivisionId'></a>

## Column\.SubdivisionId Field

Subdivision id where the object belongs to\.

```csharp
public static ExtendedColumn SubdivisionId;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.SubdivisionName'></a>

## Column\.SubdivisionName Field

Subdivision \(city, village, colony etc\.\) name where the object belongs to\.

```csharp
public static ExtendedColumn SubdivisionName;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.SubdivisionOccupancy'></a>

## Column\.SubdivisionOccupancy Field

Subdivision occupancy coming from BDOO Geoportal \*\.gml file \(ot:liczbaMieszkancow node\)\.

```csharp
public static ExtendedColumn SubdivisionOccupancy;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.ThinnessRatio'></a>

## Column\.ThinnessRatio Field

A geometric measure that describes how close a shape is to a perfect circle, calculated as \(4 \* Pi \* Area\) / Perimeter^2\.

```csharp
public static ExtendedColumn ThinnessRatio;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.TotalArea'></a>

## Column\.TotalArea Field

Calculated total area \(floor area \* storeys\) based on geometry data from BDOO Geoportal \*\.gml file \(ot:geometria node\)\.

```csharp
public static UnitColumn TotalArea;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.UserBuildingShape'></a>

## Column\.UserBuildingShape Field

Building Shape determined by user\.

```csharp
public static ExtendedColumn UserBuildingShape;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.Column.VoivodeshipName'></a>

## Column\.VoivodeshipName Field

Voivodeship \(province\) name where the object belongs to\.

```csharp
public static ExtendedColumn VoivodeshipName;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.IO.Constants.ColumnNamePrefix'></a>

## ColumnNamePrefix Class

Provides standard prefix names for prediction\-related columns in the GIS system\.

```csharp
public static class ColumnNamePrefix
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ColumnNamePrefix
### Fields

<a name='DiGi.GIS.IO.Constants.ColumnNamePrefix.PredictionBoundingBoxHeight'></a>

## ColumnNamePrefix\.PredictionBoundingBoxHeight Field

Prefix for predicted bounding box height columns\.

```csharp
public const string PredictionBoundingBoxHeight = "Prediction BoundingBox Height";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNamePrefix.PredictionBoundingBoxWidth'></a>

## ColumnNamePrefix\.PredictionBoundingBoxWidth Field

Prefix for predicted bounding box width columns\.

```csharp
public const string PredictionBoundingBoxWidth = "Prediction BoundingBox Width";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNamePrefix.PredictionBoundingBoxX'></a>

## ColumnNamePrefix\.PredictionBoundingBoxX Field

Prefix for predicted bounding box center point X coordinate columns\.

```csharp
public const string PredictionBoundingBoxX = "Prediction BoundingBox X";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNamePrefix.PredictionBoundingBoxY'></a>

## ColumnNamePrefix\.PredictionBoundingBoxY Field

Prefix for predicted bounding box center point Y coordinate columns\.

```csharp
public const string PredictionBoundingBoxY = "Prediction BoundingBox Y";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNamePrefix.PredictionConfidence'></a>

## ColumnNamePrefix\.PredictionConfidence Field

Prefix for confidence score columns\.

```csharp
public const string PredictionConfidence = "Prediction Confidence";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNameSuffix'></a>

## ColumnNameSuffix Class

Provides standard suffix names for columns relating to image and data comparison\.

```csharp
public static class ColumnNameSuffix
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ColumnNameSuffix
### Fields

<a name='DiGi.GIS.IO.Constants.ColumnNameSuffix.AverageColorSimilarity'></a>

## ColumnNameSuffix\.AverageColorSimilarity Field

Suffix for the average color similarity comparison column\.

```csharp
public const string AverageColorSimilarity = "Average Color Similarity";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNameSuffix.ColorDistributionShift'></a>

## ColumnNameSuffix\.ColorDistributionShift Field

Suffix for the color distribution shift comparison column\.

```csharp
public const string ColorDistributionShift = "Color Distribution Shift";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNameSuffix.GrayHistogramFactor'></a>

## ColumnNameSuffix\.GrayHistogramFactor Field

Suffix for the gray histogram factor comparison column\.

```csharp
public const string GrayHistogramFactor = "Gray Histogram Factor";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNameSuffix.HammingDistance'></a>

## ColumnNameSuffix\.HammingDistance Field

Suffix for the Hamming distance comparison column\.

```csharp
public const string HammingDistance = "Hamming Distance";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNameSuffix.HistogramCorrelation'></a>

## ColumnNameSuffix\.HistogramCorrelation Field

Suffix for the histogram correlation comparison column\.

```csharp
public const string HistogramCorrelation = "Histogram Correlation";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNameSuffix.MeanLaplacianFactor'></a>

## ColumnNameSuffix\.MeanLaplacianFactor Field

Suffix for the mean Laplacian factor comparison column\.

```csharp
public const string MeanLaplacianFactor = "Mean Laplacian Factor";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNameSuffix.OpticalFlowAverageMagnitude'></a>

## ColumnNameSuffix\.OpticalFlowAverageMagnitude Field

Suffix for the optical flow average magnitude comparison column\.

```csharp
public const string OpticalFlowAverageMagnitude = "Optical Flow Average Magnitude";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNameSuffix.ORBFeatureMatchingFactor'></a>

## ColumnNameSuffix\.ORBFeatureMatchingFactor Field

Suffix for the ORB feature matching factor comparison column\.

```csharp
public const string ORBFeatureMatchingFactor = "ORB Feature Matching Factor";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNameSuffix.ShapeComparisonFactor'></a>

## ColumnNameSuffix\.ShapeComparisonFactor Field

Suffix for the shape comparison factor column\.

```csharp
public const string ShapeComparisonFactor = "Shape Comparison Factor";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNameSuffix.StandardDeviationLaplacianFactor'></a>

## ColumnNameSuffix\.StandardDeviationLaplacianFactor Field

Suffix for the standard deviation Laplacian factor comparison column\.

```csharp
public const string StandardDeviationLaplacianFactor = "Standard Deviation Laplacian Factor";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNameSuffix.StructuralSimilarityIndex_AbsoluteDifference'></a>

## ColumnNameSuffix\.StructuralSimilarityIndex\_AbsoluteDifference Field

Suffix for the Structural Similarity Index calculated using the absolute difference method\.

```csharp
public const string StructuralSimilarityIndex_AbsoluteDifference = "Structural Similarity Index (Absolute Difference)";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.ColumnNameSuffix.StructuralSimilarityIndex_MatchTemplate'></a>

## ColumnNameSuffix\.StructuralSimilarityIndex\_MatchTemplate Field

Suffix for the Structural Similarity Index calculated using the match template method\.

```csharp
public const string StructuralSimilarityIndex_MatchTemplate = "Structural Similarity Index (Match Template)";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')