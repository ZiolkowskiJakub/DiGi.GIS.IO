using DiGi.Core;
using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.IO.Enums;
using DiGi.Unit.IO.Classes;

namespace DiGi.GIS.IO.Constants
{
    /// <summary>
    /// Provides static references to standard table columns used throughout the GIS IO system.
    /// </summary>
    public static class Column
    {
        /// <summary>
        /// Calculated floor area based on geometry data from BDOO Geoportal *.gml file (ot:geometria node).
        /// </summary>
        public static UnitColumn FloorArea = new("Floor area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ShapeDescriptors.Description(), "Calculated floor area based on geometry data from BDOO Geoportal *.gml file (ot:geometria node)", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// Calculated total area (floor area * storeys) based on geometry data from BDOO Geoportal *.gml file (ot:geometria node).
        /// </summary>
        public static UnitColumn TotalArea = new("Total area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ShapeDescriptors.Description(), "Calculated total area (floor area * storeys) based on geometry data from BDOO Geoportal *.gml file (ot:geometria node)", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External wall area with outward normal azimuth in the north sector ([337.5°, 360°) ∪ [0°, 22.5°)).
        /// </summary>
        public static UnitColumn ExternalNorthWallArea = new("External north wall area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External wall area with outward normal azimuth in the north sector ([337.5°, 360°) ∪ [0°, 22.5°))", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External wall area with outward normal azimuth in the northeast sector ([22.5°, 67.5°)).
        /// </summary>
        public static UnitColumn ExternalNortheastWallArea = new("External northeast wall area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External wall area with outward normal azimuth in the northeast sector ([22.5°, 67.5°))", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External wall area with outward normal azimuth in the east sector ([67.5°, 112.5°)).
        /// </summary>
        public static UnitColumn ExternalEastWallArea = new("External east wall area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External wall area with outward normal azimuth in the east sector ([67.5°, 112.5°))", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External wall area with outward normal azimuth in the southeast sector ([112.5°, 157.5°)).
        /// </summary>
        public static UnitColumn ExternalSoutheastWallArea = new("External southeast wall area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External wall area with outward normal azimuth in the southeast sector ([112.5°, 157.5°))", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External wall area with outward normal azimuth in the south sector ([157.5°, 202.5°)).
        /// </summary>
        public static UnitColumn ExternalSouthWallArea = new("External south wall area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External wall area with outward normal azimuth in the south sector ([157.5°, 202.5°))", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External wall area with outward normal azimuth in the southwest sector ([202.5°, 247.5°)).
        /// </summary>
        public static UnitColumn ExternalSouthwestWallArea = new("External southwest wall area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External wall area with outward normal azimuth in the southwest sector ([202.5°, 247.5°))", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External wall area with outward normal azimuth in the west sector ([247.5°, 292.5°)).
        /// </summary>
        public static UnitColumn ExternalWestWallArea = new("External west wall area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External wall area with outward normal azimuth in the west sector ([247.5°, 292.5°))", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External wall area with outward normal azimuth in the northwest sector ([292.5°, 337.5°)).
        /// </summary>
        public static UnitColumn ExternalNorthwestWallArea = new("External northwest wall area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External wall area with outward normal azimuth in the northwest sector ([292.5°, 337.5°))", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt below 5 degrees (flat, no directional split).
        /// </summary>
        public static UnitColumn ExternalFlatRoofArea = new("External flat roof area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt below 5 degrees (flat, no directional split)", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt from 5 up to 20 degrees, facing north ([5°, 20°]).
        /// </summary>
        public static UnitColumn ExternalNorthTiltedRoofAreaUpTo20 = new("External north tilted roof area up to 20", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt from 5 up to 20 degrees, facing north ([5°, 20°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt from 5 up to 20 degrees, facing northeast ([5°, 20°]).
        /// </summary>
        public static UnitColumn ExternalNortheastTiltedRoofAreaUpTo20 = new("External northeast tilted roof area up to 20", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt from 5 up to 20 degrees, facing northeast ([5°, 20°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt from 5 up to 20 degrees, facing east ([5°, 20°]).
        /// </summary>
        public static UnitColumn ExternalEastTiltedRoofAreaUpTo20 = new("External east tilted roof area up to 20", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt from 5 up to 20 degrees, facing east ([5°, 20°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt from 5 up to 20 degrees, facing southeast ([5°, 20°]).
        /// </summary>
        public static UnitColumn ExternalSoutheastTiltedRoofAreaUpTo20 = new("External southeast tilted roof area up to 20", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt from 5 up to 20 degrees, facing southeast ([5°, 20°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt from 5 up to 20 degrees, facing south ([5°, 20°]).
        /// </summary>
        public static UnitColumn ExternalSouthTiltedRoofAreaUpTo20 = new("External south tilted roof area up to 20", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt from 5 up to 20 degrees, facing south ([5°, 20°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt from 5 up to 20 degrees, facing southwest ([5°, 20°]).
        /// </summary>
        public static UnitColumn ExternalSouthwestTiltedRoofAreaUpTo20 = new("External southwest tilted roof area up to 20", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt from 5 up to 20 degrees, facing southwest ([5°, 20°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt from 5 up to 20 degrees, facing west ([5°, 20°]).
        /// </summary>
        public static UnitColumn ExternalWestTiltedRoofAreaUpTo20 = new("External west tilted roof area up to 20", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt from 5 up to 20 degrees, facing west ([5°, 20°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt from 5 up to 20 degrees, facing northwest ([5°, 20°]).
        /// </summary>
        public static UnitColumn ExternalNorthwestTiltedRoofAreaUpTo20 = new("External northwest tilted roof area up to 20", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt from 5 up to 20 degrees, facing northwest ([5°, 20°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 20 and up to 45 degrees, facing north ((20°, 45°]).
        /// </summary>
        public static UnitColumn ExternalNorthTiltedRoofAreaBetween20And45 = new("External north tilted roof area between 20 and 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 20 and up to 45 degrees, facing north ((20°, 45°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 20 and up to 45 degrees, facing northeast ((20°, 45°]).
        /// </summary>
        public static UnitColumn ExternalNortheastTiltedRoofAreaBetween20And45 = new("External northeast tilted roof area between 20 and 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 20 and up to 45 degrees, facing northeast ((20°, 45°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 20 and up to 45 degrees, facing east ((20°, 45°]).
        /// </summary>
        public static UnitColumn ExternalEastTiltedRoofAreaBetween20And45 = new("External east tilted roof area between 20 and 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 20 and up to 45 degrees, facing east ((20°, 45°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 20 and up to 45 degrees, facing southeast ((20°, 45°]).
        /// </summary>
        public static UnitColumn ExternalSoutheastTiltedRoofAreaBetween20And45 = new("External southeast tilted roof area between 20 and 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 20 and up to 45 degrees, facing southeast ((20°, 45°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 20 and up to 45 degrees, facing south ((20°, 45°]).
        /// </summary>
        public static UnitColumn ExternalSouthTiltedRoofAreaBetween20And45 = new("External south tilted roof area between 20 and 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 20 and up to 45 degrees, facing south ((20°, 45°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 20 and up to 45 degrees, facing southwest ((20°, 45°]).
        /// </summary>
        public static UnitColumn ExternalSouthwestTiltedRoofAreaBetween20And45 = new("External southwest tilted roof area between 20 and 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 20 and up to 45 degrees, facing southwest ((20°, 45°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 20 and up to 45 degrees, facing west ((20°, 45°]).
        /// </summary>
        public static UnitColumn ExternalWestTiltedRoofAreaBetween20And45 = new("External west tilted roof area between 20 and 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 20 and up to 45 degrees, facing west ((20°, 45°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 20 and up to 45 degrees, facing northwest ((20°, 45°]).
        /// </summary>
        public static UnitColumn ExternalNorthwestTiltedRoofAreaBetween20And45 = new("External northwest tilted roof area between 20 and 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 20 and up to 45 degrees, facing northwest ((20°, 45°])", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 45 degrees, facing north (> 45°).
        /// </summary>
        public static UnitColumn ExternalNorthTiltedRoofAreaAbove45 = new("External north tilted roof area above 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 45 degrees, facing north (> 45°)", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 45 degrees, facing northeast (> 45°).
        /// </summary>
        public static UnitColumn ExternalNortheastTiltedRoofAreaAbove45 = new("External northeast tilted roof area above 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 45 degrees, facing northeast (> 45°)", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 45 degrees, facing east (> 45°).
        /// </summary>
        public static UnitColumn ExternalEastTiltedRoofAreaAbove45 = new("External east tilted roof area above 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 45 degrees, facing east (> 45°)", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 45 degrees, facing southeast (> 45°).
        /// </summary>
        public static UnitColumn ExternalSoutheastTiltedRoofAreaAbove45 = new("External southeast tilted roof area above 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 45 degrees, facing southeast (> 45°)", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 45 degrees, facing south (> 45°).
        /// </summary>
        public static UnitColumn ExternalSouthTiltedRoofAreaAbove45 = new("External south tilted roof area above 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 45 degrees, facing south (> 45°)", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 45 degrees, facing southwest (> 45°).
        /// </summary>
        public static UnitColumn ExternalSouthwestTiltedRoofAreaAbove45 = new("External southwest tilted roof area above 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 45 degrees, facing southwest (> 45°)", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 45 degrees, facing west (> 45°).
        /// </summary>
        public static UnitColumn ExternalWestTiltedRoofAreaAbove45 = new("External west tilted roof area above 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 45 degrees, facing west (> 45°)", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External roof area with tilt greater than 45 degrees, facing northwest (> 45°).
        /// </summary>
        public static UnitColumn ExternalNorthwestTiltedRoofAreaAbove45 = new("External northwest tilted roof area above 45", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External roof area with tilt greater than 45 degrees, facing northwest (> 45°)", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// External floor area (ground-facing external floor components).
        /// </summary>
        public static UnitColumn ExternalFloorArea = new("External floor area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "External floor area (ground-facing external floor components)", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// Sum of all external wall, roof and floor component areas.
        /// </summary>
        public static UnitColumn ExternalComponentsArea = new("External components area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.ExternalComponentsArea.Description(), "Sum of all external wall, roof and floor component areas", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// Azimuth as an angle to north direction.
        /// </summary>
        public static UnitColumn Azimuth = new("Azimuth", (Unit.Classes.Unit?)Unit.Enums.AngleUnit.Degree, Category.Orientation.Description(), "Azimuth as an angle to north direction", Unit.Enums.UnitDataType.Float);

        /// <summary>
        /// BoundingBox height calculated based on geometry data from BDOO Geoportal *.gml file (ot:geometria node).
        /// </summary>
        public static UnitColumn BoundingBoxHeight = new("BoundingBox height", (Unit.Classes.Unit?)Unit.Enums.LengthUnit.Meter, Category.BoundingBox.Description(), "BoundingBox height calculated based on geometry data from BDOO Geoportal *.gml file (ot:geometria node)");

        /// <summary>
        /// BoundingBox width calculated based on geometry data from BDOO Geoportal *.gml file (ot:geometria node).
        /// </summary>
        public static UnitColumn BoundingBoxWidth = new("BoundingBox width", (Unit.Classes.Unit?)Unit.Enums.LengthUnit.Meter, Category.BoundingBox.Description(), "BoundingBox width calculated based on geometry data from BDOO Geoportal *.gml file (ot:geometria node)");

        /// <summary>
        /// BoundingBox center point X coordinate coming from BDOO Geoportal *.gml file (ot:geometria node).
        /// </summary>
        public static ExtendedColumn BoundingBoxX = new("BoundingBox X", typeof(double), Category.BoundingBox.Description(), "BoundingBox center point X coordinate coming from BDOO Geoportal *.gml file (ot:geometria node)");

        /// <summary>
        /// BoundingBox center point Y coordinate coming from BDOO Geoportal *.gml file (ot:geometria node).
        /// </summary>
        public static ExtendedColumn BoundingBoxY = new("BoundingBox Y", typeof(double), Category.BoundingBox.Description(), "BoundingBox center point Y coordinate coming from BDOO Geoportal *.gml file (ot:geometria node)");

        /// <summary>
        /// Building general function from BDOO Geoportal *.gml file (ot:funkcjaOgolnaBudynku node).
        /// </summary>
        public static ExtendedColumn BuildingGeneralFunction = new("Building general function", typeof(string), Category.BuildingFunction.Description(), "Building general function from BDOO Geoportal *.gml file (ot:funkcjaOgolnaBudynku node)");

        /// <summary>
        /// Current building phase coming from BDOO Geoportal *.gml file (ot:kategoriaIstnienia node).
        /// </summary>
        public static ExtendedColumn BuildingPhase = new("Building Phase", typeof(string), Category.BuildingState.Description(), "Current building phase coming from BDOO Geoportal *.gml file (ot:kategoriaIstnienia node)");

        /// <summary>
        /// Building specific functions from BDOO Geoportal *.gml file (ot:funkcjaSzczegolowaBudynku node).
        /// </summary>
        public static ExtendedColumn BuildingSpecificFunctions = new("Building specific functions", typeof(string), Category.BuildingFunction.Description(), "Building specific functions from BDOO Geoportal *.gml file (ot:funkcjaSzczegolowaBudynku node)");

        /// <summary>
        /// Cardinal direction calculated from azimuth.
        /// </summary>
        public static ExtendedColumn CardinalDirection = new("Cardinal direction", typeof(string), Category.Orientation.Description(), "Cardinal direction calculated from azimuth");

        /// <summary>
        /// County id where the object belongs to.
        /// </summary>
        public static ExtendedColumn CountyId = new("County Id", typeof(int), Category.Administrative.Description(), "County id where the object belongs to");

        /// <summary>
        /// Subdivision id where the object belongs to.
        /// </summary>
        public static ExtendedColumn SubdivisionId = new("Subdivision Id", typeof(int), Category.Administrative.Description(), "Subdivision id where the object belongs to");

        /// <summary>
        /// County (powiat) name where the object belongs to.
        /// </summary>
        public static ExtendedColumn CountyName = new("County name", typeof(string), Category.Administrative.Description(), "County (powiat) name where the object belongs to");

        /// <summary>
        /// X coordinate of internal point calculated based on bounding box coming from BDOO Geoportal *.gml file (ot:geometria node).
        /// </summary>
        public static ExtendedColumn InternalPointX = new("Internal Point X", typeof(double), Category.Location.Description(), "X coordinate of internal point calculated based on bounding box coming from BDOO Geoportal *.gml file (ot:geometria node)");

        /// <summary>
        /// Y coordinate of internal point calculated based on bounding box coming from BDOO Geoportal *.gml file (ot:geometria node).
        /// </summary>
        public static ExtendedColumn InternalPointY = new("Internal Point Y", typeof(double), Category.Location.Description(), "Y coordinate of internal point calculated based on bounding box coming from BDOO Geoportal *.gml file (ot:geometria node)");

        /// <summary>
        /// Municipality (gmina) name where the object belongs to.
        /// </summary>
        public static ExtendedColumn MunicipalityName = new("Municipality name", typeof(string), Category.Administrative.Description(), "Municipality (gmina) name where the object belongs to");

        /// <summary>
        /// Predicted year built based on historical data analyzed by a Machine Learning engine.
        /// </summary>
        public static ExtendedColumn PredictedYearBuilt = new("Predicted year built", typeof(ushort), Category.YearBuit.Description(), "Predicted year built based on historical data analyzed by a Machine Learning engine");

        /// <summary>
        /// Main reference of the object coming from BDOO Geoportal *.gml file (ot:lokalnyId node).
        /// </summary>
        public static ExtendedColumn Reference = new("Reference", typeof(string), Category.Administrative.Description(), "Main reference of the object coming from BDOO Geoportal *.gml file (ot:lokalnyId node)");

        /// <summary>
        /// Number of building storeys coming from BDOO Geoportal *.gml file (ot:liczbaKondygnacji node).
        /// </summary>
        public static ExtendedColumn Storeys = new("Storeys", typeof(ushort), Category.BuildingState.Description(), "Number of building storeys coming from BDOO Geoportal *.gml file (ot:liczbaKondygnacji node)");

        /// <summary>
        /// Subdivision occupancy coming from BDOO Geoportal *.gml file (ot:liczbaMieszkancow node).
        /// </summary>
        public static ExtendedColumn SubdivisionOccupancy = new("Subdivision occupancy", typeof(uint), Category.Occupancy.Description(), "Subdivision occupancy coming from BDOO Geoportal *.gml file (ot:liczbaMieszkancow node)");

        /// <summary>
        /// Subdivision (city, village, colony etc.) name where the object belongs to.
        /// </summary>
        public static ExtendedColumn SubdivisionName = new("Subdivision name", typeof(string), Category.Administrative.Description(), "Subdivision (city, village, colony etc.) name where the object belongs to");

        /// <summary>
        /// Voivodeship (province) name where the object belongs to.
        /// </summary>
        public static ExtendedColumn VoivodeshipName = new("Voivodeship name", typeof(string), Category.Administrative.Description(), "Voivodeship (province) name where the object belongs to");

        /// <summary>
        /// Determines if building is residental.
        /// </summary>
        public static ExtendedColumn IsResidential = new("Is residential", typeof(bool), Category.BuildingFunction.Description(), "Determines if building is residental");

        /// <summary>
        /// Determines if building is occupied.
        /// </summary>
        public static ExtendedColumn IsOccupied = new("Is occupied", typeof(bool), Category.BuildingState.Description(), "Determines if building is occupied");

        /// <summary>
        /// Settlement type such as rural or urban.
        /// </summary>
        public static ExtendedColumn SettlementType = new("Settlement type", typeof(string), Category.Administrative.Description(), "Settlement type such as rural or urban");

        /// <summary>
        /// Ratio of the curve area to the area of a circle with same perimeter as the curve.
        /// </summary>
        public static ExtendedColumn IsoperimetricRatio = new("Isoperimetric ratio", typeof(float), Category.ShapeDescriptors.Description(), "Ratio of the curve area to the area of a circle with same perimeter as the curve");

        /// <summary>
        /// Ratio of the shape area to the area of its minimum bounding rectangle.
        /// </summary>
        public static ExtendedColumn RectangularThinnessRatio = new("Rectangular thinnes ratio", typeof(float), Category.ShapeDescriptors.Description(), "Ratio of the shape area to the area of its minimum bounding rectangle");

        /// <summary>
        /// Ratio of the shape area to the area of its minimum bounding square.
        /// </summary>
        public static ExtendedColumn SquareThinnessRatio = new("Square thinness ratio", typeof(float), Category.ShapeDescriptors.Description(), "Ratio of the shape area to the area of its minimum bounding square");

        /// <summary>
        /// A geometric measure that describes how close a shape is to a perfect circle, calculated as (4 * Pi * Area) / Perimeter^2.
        /// </summary>
        public static ExtendedColumn ThinnessRatio = new("Thinness ratio", typeof(float), Category.ShapeDescriptors.Description(), "A geometric measure that describes how close a shape is to a perfect circle, calculated as (4 * Pi * Area) / Perimeter^2");

        /// <summary>
        /// Shape descriptor that measures how elongated or “thin” a shape is compared to a convex hull that perfectly fits around it (its envelope or convex enclosure).
        /// </summary>
        public static ExtendedColumn ConvexHullThinnessRatio = new("Convex hull thinness ratio", typeof(float), Category.ShapeDescriptors.Description(), "Shape descriptor that measures how elongated or “thin” a shape is compared to a convex hull that perfectly fits around it (its envelope or convex enclosure)");

        /// <summary>
        /// Predicted Building Shape based on Machine Learning engine.
        /// </summary>
        public static ExtendedColumn PredictedBuildingShape = new("Predicted Building Shape", typeof(string), Category.BuildingShape.Description(), "Predicted Building Shape based on Machine Learning engine");

        /// <summary>
        /// Building shape (e.g., Square, Rectangular, L, U, T, etc.) calculated using the BuildingShapeSolver engine via geometric ratios and bounding box analysis.
        /// </summary>
        public static ExtendedColumn CalculatedBuildingShape = new("Calculated Building Shape", typeof(string), Category.BuildingShape.Description(), "Building shape (e.g., Square, Rectangular, L, U, T, etc.) calculated using the BuildingShapeSolver engine via geometric ratios and bounding box analysis");

        /// <summary>
        /// Building Shape determined by user.
        /// </summary>
        public static ExtendedColumn UserBuildingShape = new("User Building Shape", typeof(string), Category.BuildingShape.Description(), "Building Shape determined by user");

        /// <summary>
        /// Database Id for the building.
        /// </summary>
        public static ExtendedColumn DatabaseId = new("Database Id", typeof(long), Category.Identity.Description(), "Unique identifier for the building in the database");

        /// <summary>
        /// Calculated occupancy.
        /// </summary>
        public static ExtendedColumn CalculatedOccupancy = new("Calculated occupancy", typeof(uint), Category.Occupancy.Description(), "Calculated occupancy"); 
    }
}