using DiGi.Core;
using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.IO.Enums;
using DiGi.Unit.IO.Classes;

namespace DiGi.GIS.IO.Constants
{
    public static class Column
    {
        public static UnitColumn Area = new("Area", (Unit.Classes.Unit?)Unit.Enums.AreaUnit.SquareMeter, Category.Geometry.Description(), "Calculated area based on geometry data from BDOO Geoportal *.gml file (ot:geometria node)");
        public static UnitColumn Azimuth = new("Azimuth", (Unit.Classes.Unit?)Unit.Enums.AngleUnit.Degree, Category.General.Description(), "Azimuth as an angle to north direction");
        public static UnitColumn BoundingBoxHeight = new("BoundingBox height", (Unit.Classes.Unit?)Unit.Enums.LengthUnit.Meter, Category.Geometry.Description(), "BoundingBox height calculated based on geometry data from BDOO Geoportal *.gml file (ot:geometria node)");
        public static UnitColumn BoundingBoxWidth = new("BoundingBox width", (Unit.Classes.Unit?)Unit.Enums.LengthUnit.Meter, Category.Geometry.Description(), "BoundingBox width calculated based on geometry data from BDOO Geoportal *.gml file (ot:geometria node)");
        public static ExtendedColumn BoundingBoxX = new("BoundingBox X", typeof(double), Category.Geometry.Description(), "BoundingBox center point X coordinate coming from BDOO Geoportal *.gml file (ot:geometria node)");
        public static ExtendedColumn BoundingBoxY = new("BoundingBox Y", typeof(double), Category.Geometry.Description(), "BoundingBox center point Y coordinate coming from BDOO Geoportal *.gml file (ot:geometria node)");
        public static ExtendedColumn BuildingGeneralFunction = new("Building general function", typeof(string), Category.General.Description(), "Building general function from BDOO Geoportal *.gml file (ot:funkcjaOgolnaBudynku node)");
        public static ExtendedColumn BuildingPhase = new("Building Phase", typeof(string), Category.General.Description(), "Current building phase coming from BDOO Geoportal *.gml file (ot:kategoriaIstnienia node)");
        public static ExtendedColumn BuildingSpecificFunctions = new("Building specific functions", typeof(string), Category.General.Description(), "Building specific functions from BDOO Geoportal *.gml file (ot:funkcjaSzczegolowaBudynku node)");
        public static ExtendedColumn CardinalDirection = new("Cardinal direction", typeof(string), Category.General.Description(), "Cardinal direction calculated from azimuth");
        public static ExtendedColumn CountyId = new("County Id", typeof(int), Category.Identity.Description(), "County id where the object belongs to");
        public static ExtendedColumn SubdivisionId = new("Subdivision Id", typeof(int), Category.Identity.Description(), "Subdivision id where the object belongs to");
        public static ExtendedColumn CountyName = new("County name", typeof(string), Category.Identity.Description(), "County (powiat) name where the object belongs to");
        public static ExtendedColumn InternalPointX = new("Internal Point X", typeof(double), Category.Location.Description(), "X coordinate of internal point calculated based on bounding box coming from BDOO Geoportal *.gml file (ot:geometria node)");
        public static ExtendedColumn InternalPointY = new("Internal Point Y", typeof(double), Category.Location.Description(), "Y coordinate of internal point calculated based on bounding box coming from BDOO Geoportal *.gml file (ot:geometria node)");
        public static ExtendedColumn MunicipalityName = new("Municipality name", typeof(string), Category.Identity.Description(), "Municipality (gmina) name where the object belongs to");
        public static ExtendedColumn PredictedYearBuilt = new("Predicted year built", typeof(ushort), Category.YearBuit.Description(), "Predicted year built based on year built prediction data for specific years");
        public static ExtendedColumn Reference = new("Reference", typeof(string), Category.Identity.Description(), "Main reference of the object coming from BDOO Geoportal *.gml file (ot:lokalnyId node)");
        public static ExtendedColumn Storeys = new("Storeys", typeof(ushort), Category.General.Description(), "Number of building storeys coming from BDOO Geoportal *.gml file (ot:liczbaKondygnacji node)");
        public static ExtendedColumn SubdivisionCalculatedOccupancy = new("Subdivision calculated occupancy", typeof(int), Category.Occupancy.Description(), "Subdivision calculated occupancy");
        public static ExtendedColumn SubdivisionName = new("Subdivision name", typeof(string), Category.Identity.Description(), "Subdivision (city, village, colony etc.) name where the object belongs to");
        public static ExtendedColumn VoivodeshipName = new("Voivodeship name", typeof(string), Category.Identity.Description(), "Voivodeship (province) name where the object belongs to");

        public static ExtendedColumn IsResidential = new("Is residential", typeof(bool), Category.General.Description(), "Determines if building is residental");
        public static ExtendedColumn IsOccupied = new("Is occupied", typeof(bool), Category.General.Description(), "Determines if building is occupied");
        public static ExtendedColumn SettlementType = new("Settlement type", typeof(string), Category.General.Description(), "Settlement type such as rural or urban");


        public static ExtendedColumn IsoperimetricRatio = new("Isoperimetric ratio", typeof(float), Category.Geometry.Description(), "Ratio of the curve area to the area of a circle with same perimeter as the curve");
        public static ExtendedColumn RectangularThinnessRatio = new("Rectangular thinnes ratio", typeof(float), Category.Geometry.Description(), "Shape descriptor that measures how elongated or “thin” a shape is compared to a rectangle that perfectly fits around it (its minimum bounding rectangle)");
        public static ExtendedColumn SquareThinnessRatio = new("Square thinness ratio", typeof(float), Category.Geometry.Description(), "Shape descriptor that measures how elongated or “thin” a shape is compared to a square that perfectly fits around it (its minimum bounding square)");
        public static ExtendedColumn ThinnessRatio = new("Thinness ratio", typeof(float), Category.Geometry.Description(), "Ratio of area and perimeter");
        public static ExtendedColumn ConvexHullThinnessRatio = new("Convex hull thinness ratio", typeof(float), Category.Geometry.Description(), "Shape descriptor that measures how elongated or “thin” a shape is compared to a convex hull that perfectly fits around it (its envelope or convex enclosure)");

        public static ExtendedColumn PredictedBuildingShape = new("Predicted Building Shape", typeof(string), Category.ShapePrediction.Description(), "Predicted Building Shape based on Machine Learning engine");
        public static ExtendedColumn CalculatedBuildingShape = new("Calculated Building Shape", typeof(string), Category.ShapePrediction.Description(), "Calculated Building Shape based on BuildingShapeSolver engine");
        public static ExtendedColumn UserBuildingShape = new("User Building Shape", typeof(string), Category.ShapePrediction.Description(), "Building Shape determined by user");
    }
}