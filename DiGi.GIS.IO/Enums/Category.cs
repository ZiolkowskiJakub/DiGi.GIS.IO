using System.ComponentModel;

namespace DiGi.GIS.IO.Enums
{
    public enum Category
    {
        [Description("Undefined")] Undefined,
        [Description("Identity")] Identity,
        [Description("General")] General,
        [Description("Location")] Location,
        [Description("Geometry")] Geometry,
        [Description("Occupancy")] Occupancy,
        [Description("Orthophotomap")] Orthophotomap,
        [Description("Year built")] YearBuit,
        [Description("Thermal properties")] ThermalProperties,
        [Description("Other")] Other,
    }
}
