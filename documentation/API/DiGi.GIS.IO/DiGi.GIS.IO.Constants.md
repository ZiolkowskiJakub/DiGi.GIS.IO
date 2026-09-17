#### [DiGi\.GIS\.IO](DiGi.GIS.IO.Overview.md 'DiGi\.GIS\.IO\.Overview')

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

<a name='DiGi.GIS.IO.Constants.Column.ExternalComponentsArea'></a>

## Column\.ExternalComponentsArea Field

Sum of all external wall, roof and floor component areas\.

```csharp
public static UnitColumn ExternalComponentsArea;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalEastTiltedRoofAreaAbove45'></a>

## Column\.ExternalEastTiltedRoofAreaAbove45 Field

External roof area with tilt greater than 45 degrees, facing east \(\> 45°\)\.

```csharp
public static UnitColumn ExternalEastTiltedRoofAreaAbove45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalEastTiltedRoofAreaBetween20And45'></a>

## Column\.ExternalEastTiltedRoofAreaBetween20And45 Field

External roof area with tilt greater than 20 and up to 45 degrees, facing east \(\(20°, 45°\]\)\.

```csharp
public static UnitColumn ExternalEastTiltedRoofAreaBetween20And45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalEastTiltedRoofAreaUpTo20'></a>

## Column\.ExternalEastTiltedRoofAreaUpTo20 Field

External roof area with tilt from 5 up to 20 degrees, facing east \(\[5°, 20°\]\)\.

```csharp
public static UnitColumn ExternalEastTiltedRoofAreaUpTo20;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalEastWallArea'></a>

## Column\.ExternalEastWallArea Field

External wall area with outward normal azimuth in the east sector \(\[67\.5°, 112\.5°\)\)\.

```csharp
public static UnitColumn ExternalEastWallArea;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalFlatRoofArea'></a>

## Column\.ExternalFlatRoofArea Field

External roof area with tilt below 5 degrees \(flat, no directional split\)\.

```csharp
public static UnitColumn ExternalFlatRoofArea;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalFloorArea'></a>

## Column\.ExternalFloorArea Field

External floor area \(ground\-facing external floor components\)\.

```csharp
public static UnitColumn ExternalFloorArea;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalNortheastTiltedRoofAreaAbove45'></a>

## Column\.ExternalNortheastTiltedRoofAreaAbove45 Field

External roof area with tilt greater than 45 degrees, facing northeast \(\> 45°\)\.

```csharp
public static UnitColumn ExternalNortheastTiltedRoofAreaAbove45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalNortheastTiltedRoofAreaBetween20And45'></a>

## Column\.ExternalNortheastTiltedRoofAreaBetween20And45 Field

External roof area with tilt greater than 20 and up to 45 degrees, facing northeast \(\(20°, 45°\]\)\.

```csharp
public static UnitColumn ExternalNortheastTiltedRoofAreaBetween20And45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalNortheastTiltedRoofAreaUpTo20'></a>

## Column\.ExternalNortheastTiltedRoofAreaUpTo20 Field

External roof area with tilt from 5 up to 20 degrees, facing northeast \(\[5°, 20°\]\)\.

```csharp
public static UnitColumn ExternalNortheastTiltedRoofAreaUpTo20;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalNortheastWallArea'></a>

## Column\.ExternalNortheastWallArea Field

External wall area with outward normal azimuth in the northeast sector \(\[22\.5°, 67\.5°\)\)\.

```csharp
public static UnitColumn ExternalNortheastWallArea;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalNorthTiltedRoofAreaAbove45'></a>

## Column\.ExternalNorthTiltedRoofAreaAbove45 Field

External roof area with tilt greater than 45 degrees, facing north \(\> 45°\)\.

```csharp
public static UnitColumn ExternalNorthTiltedRoofAreaAbove45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalNorthTiltedRoofAreaBetween20And45'></a>

## Column\.ExternalNorthTiltedRoofAreaBetween20And45 Field

External roof area with tilt greater than 20 and up to 45 degrees, facing north \(\(20°, 45°\]\)\.

```csharp
public static UnitColumn ExternalNorthTiltedRoofAreaBetween20And45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalNorthTiltedRoofAreaUpTo20'></a>

## Column\.ExternalNorthTiltedRoofAreaUpTo20 Field

External roof area with tilt from 5 up to 20 degrees, facing north \(\[5°, 20°\]\)\.

```csharp
public static UnitColumn ExternalNorthTiltedRoofAreaUpTo20;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalNorthWallArea'></a>

## Column\.ExternalNorthWallArea Field

External wall area with outward normal azimuth in the north sector \(\[337\.5°, 360°\) ∪ \[0°, 22\.5°\)\)\.

```csharp
public static UnitColumn ExternalNorthWallArea;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalNorthwestTiltedRoofAreaAbove45'></a>

## Column\.ExternalNorthwestTiltedRoofAreaAbove45 Field

External roof area with tilt greater than 45 degrees, facing northwest \(\> 45°\)\.

```csharp
public static UnitColumn ExternalNorthwestTiltedRoofAreaAbove45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalNorthwestTiltedRoofAreaBetween20And45'></a>

## Column\.ExternalNorthwestTiltedRoofAreaBetween20And45 Field

External roof area with tilt greater than 20 and up to 45 degrees, facing northwest \(\(20°, 45°\]\)\.

```csharp
public static UnitColumn ExternalNorthwestTiltedRoofAreaBetween20And45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalNorthwestTiltedRoofAreaUpTo20'></a>

## Column\.ExternalNorthwestTiltedRoofAreaUpTo20 Field

External roof area with tilt from 5 up to 20 degrees, facing northwest \(\[5°, 20°\]\)\.

```csharp
public static UnitColumn ExternalNorthwestTiltedRoofAreaUpTo20;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalNorthwestWallArea'></a>

## Column\.ExternalNorthwestWallArea Field

External wall area with outward normal azimuth in the northwest sector \(\[292\.5°, 337\.5°\)\)\.

```csharp
public static UnitColumn ExternalNorthwestWallArea;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalSoutheastTiltedRoofAreaAbove45'></a>

## Column\.ExternalSoutheastTiltedRoofAreaAbove45 Field

External roof area with tilt greater than 45 degrees, facing southeast \(\> 45°\)\.

```csharp
public static UnitColumn ExternalSoutheastTiltedRoofAreaAbove45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalSoutheastTiltedRoofAreaBetween20And45'></a>

## Column\.ExternalSoutheastTiltedRoofAreaBetween20And45 Field

External roof area with tilt greater than 20 and up to 45 degrees, facing southeast \(\(20°, 45°\]\)\.

```csharp
public static UnitColumn ExternalSoutheastTiltedRoofAreaBetween20And45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalSoutheastTiltedRoofAreaUpTo20'></a>

## Column\.ExternalSoutheastTiltedRoofAreaUpTo20 Field

External roof area with tilt from 5 up to 20 degrees, facing southeast \(\[5°, 20°\]\)\.

```csharp
public static UnitColumn ExternalSoutheastTiltedRoofAreaUpTo20;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalSoutheastWallArea'></a>

## Column\.ExternalSoutheastWallArea Field

External wall area with outward normal azimuth in the southeast sector \(\[112\.5°, 157\.5°\)\)\.

```csharp
public static UnitColumn ExternalSoutheastWallArea;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalSouthTiltedRoofAreaAbove45'></a>

## Column\.ExternalSouthTiltedRoofAreaAbove45 Field

External roof area with tilt greater than 45 degrees, facing south \(\> 45°\)\.

```csharp
public static UnitColumn ExternalSouthTiltedRoofAreaAbove45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalSouthTiltedRoofAreaBetween20And45'></a>

## Column\.ExternalSouthTiltedRoofAreaBetween20And45 Field

External roof area with tilt greater than 20 and up to 45 degrees, facing south \(\(20°, 45°\]\)\.

```csharp
public static UnitColumn ExternalSouthTiltedRoofAreaBetween20And45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalSouthTiltedRoofAreaUpTo20'></a>

## Column\.ExternalSouthTiltedRoofAreaUpTo20 Field

External roof area with tilt from 5 up to 20 degrees, facing south \(\[5°, 20°\]\)\.

```csharp
public static UnitColumn ExternalSouthTiltedRoofAreaUpTo20;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalSouthWallArea'></a>

## Column\.ExternalSouthWallArea Field

External wall area with outward normal azimuth in the south sector \(\[157\.5°, 202\.5°\)\)\.

```csharp
public static UnitColumn ExternalSouthWallArea;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalSouthwestTiltedRoofAreaAbove45'></a>

## Column\.ExternalSouthwestTiltedRoofAreaAbove45 Field

External roof area with tilt greater than 45 degrees, facing southwest \(\> 45°\)\.

```csharp
public static UnitColumn ExternalSouthwestTiltedRoofAreaAbove45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalSouthwestTiltedRoofAreaBetween20And45'></a>

## Column\.ExternalSouthwestTiltedRoofAreaBetween20And45 Field

External roof area with tilt greater than 20 and up to 45 degrees, facing southwest \(\(20°, 45°\]\)\.

```csharp
public static UnitColumn ExternalSouthwestTiltedRoofAreaBetween20And45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalSouthwestTiltedRoofAreaUpTo20'></a>

## Column\.ExternalSouthwestTiltedRoofAreaUpTo20 Field

External roof area with tilt from 5 up to 20 degrees, facing southwest \(\[5°, 20°\]\)\.

```csharp
public static UnitColumn ExternalSouthwestTiltedRoofAreaUpTo20;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalSouthwestWallArea'></a>

## Column\.ExternalSouthwestWallArea Field

External wall area with outward normal azimuth in the southwest sector \(\[202\.5°, 247\.5°\)\)\.

```csharp
public static UnitColumn ExternalSouthwestWallArea;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalWestTiltedRoofAreaAbove45'></a>

## Column\.ExternalWestTiltedRoofAreaAbove45 Field

External roof area with tilt greater than 45 degrees, facing west \(\> 45°\)\.

```csharp
public static UnitColumn ExternalWestTiltedRoofAreaAbove45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalWestTiltedRoofAreaBetween20And45'></a>

## Column\.ExternalWestTiltedRoofAreaBetween20And45 Field

External roof area with tilt greater than 20 and up to 45 degrees, facing west \(\(20°, 45°\]\)\.

```csharp
public static UnitColumn ExternalWestTiltedRoofAreaBetween20And45;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalWestTiltedRoofAreaUpTo20'></a>

## Column\.ExternalWestTiltedRoofAreaUpTo20 Field

External roof area with tilt from 5 up to 20 degrees, facing west \(\[5°, 20°\]\)\.

```csharp
public static UnitColumn ExternalWestTiltedRoofAreaUpTo20;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

<a name='DiGi.GIS.IO.Constants.Column.ExternalWestWallArea'></a>

## Column\.ExternalWestWallArea Field

External wall area with outward normal azimuth in the west sector \(\[247\.5°, 292\.5°\)\)\.

```csharp
public static UnitColumn ExternalWestWallArea;
```

#### Field Value
[DiGi\.Unit\.IO\.Classes\.UnitColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.unit.io.classes.unitcolumn 'DiGi\.Unit\.IO\.Classes\.UnitColumn')

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

<a name='DiGi.GIS.IO.Constants.WebAPI'></a>

## WebAPI Class

Provides Web API constant endpoint configurations\.

```csharp
public static class WebAPI
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → WebAPI
### Fields

<a name='DiGi.GIS.IO.Constants.WebAPI.BaseUri'></a>

## WebAPI\.BaseUri Field

Default base URL for the deployed Web API\.

```csharp
public const string BaseUri = "https://api.digiproject.uk";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.YearBuiltPredictionFeatureGroup'></a>

## YearBuiltPredictionFeatureGroup Class

Names the groups the Year Built prediction feature set is built from\.

The groups are not cosmetic. Each is populated by a different run - the base and grid cell columns by a General building data update, the population columns by a Statistical one, the radial ratios by a Radial Ratios one, and the detection columns by the prediction pipeline itself - so which group is empty says which run has not happened.

```csharp
public static class YearBuiltPredictionFeatureGroup
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → YearBuiltPredictionFeatureGroup
### Fields

<a name='DiGi.GIS.IO.Constants.YearBuiltPredictionFeatureGroup.Base'></a>

## YearBuiltPredictionFeatureGroup\.Base Field

The scalar geometry, shape, administrative and occupancy columns\. Written by a General building data update\.

```csharp
public const string Base = "base";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.YearBuiltPredictionFeatureGroup.Detection'></a>

## YearBuiltPredictionFeatureGroup\.Detection Field

The five per year detection columns\. Written by the prediction pipeline itself, never by a building data update\.

```csharp
public const string Detection = "detection";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.YearBuiltPredictionFeatureGroup.GridCellCoverage'></a>

## YearBuiltPredictionFeatureGroup\.GridCellCoverage Field

The five by five grid cell coverage columns\. Written by a General building data update\.

```csharp
public const string GridCellCoverage = "grid cell coverage";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.YearBuiltPredictionFeatureGroup.Population'></a>

## YearBuiltPredictionFeatureGroup\.Population Field

The per year municipality population columns\. Written by a Statistical building data update\.

```csharp
public const string Population = "population";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Constants.YearBuiltPredictionFeatureGroup.RadialRatio'></a>

## YearBuiltPredictionFeatureGroup\.RadialRatio Field

The two per radius radial ratio columns\. Written by a Radial Ratios building data update\.

```csharp
public const string RadialRatio = "radial ratio";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')