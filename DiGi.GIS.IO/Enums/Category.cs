using System.ComponentModel;

namespace DiGi.GIS.IO.Enums
{
    public enum Category
    {
        [Description("Undefined")] Undefined,
        [Description("Identity")] Identity,
        [Description("Administrative")] Administrative,
        [Description("General")] General,
        [Description("Building function")] BuildingFunction,
        [Description("Building State")] BuildingState,
        [Description("Orientation")] Orientation,
        [Description("Location")] Location,
        [Description("Geometry")] Geometry,
        [Description("Bounding Box")] BoundingBox,
        [Description("Shape descriptors")] ShapeDescriptors,
        [Description("Occupancy")] Occupancy,
        [Description("Orthophotomap")] Orthophotomap,
        [Description("Year built")] YearBuit,
        [Description("Building shape")] BuildingShape,
        [Description("Thermal properties")] ThermalProperties,
        [Description("Shape prediction")] ShapePrediction,
        [Description("Other")] Other,
    }
}