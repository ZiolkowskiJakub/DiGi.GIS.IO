using System.ComponentModel;

namespace DiGi.GIS.IO.Enums
{
    /// <summary>
    /// Specifies the category of a column or data element in the GIS IO system.
    /// </summary>
    public enum Category
    {
        /// <summary>
        /// Represents an undefined category.
        /// </summary>
        [Description("Undefined")] Undefined,

        /// <summary>
        /// Represents identity-related information.
        /// </summary>
        [Description("Identity")] Identity,

        /// <summary>
        /// Represents administrative or geopolitical boundaries.
        /// </summary>
        [Description("Administrative")] Administrative,

        /// <summary>
        /// Represents general data.
        /// </summary>
        [Description("General")] General,

        /// <summary>
        /// Represents functions or purposes of a building.
        /// </summary>
        [Description("Building function")] BuildingFunction,

        /// <summary>
        /// Represents the state or phase of a building.
        /// </summary>
        [Description("Building State")] BuildingState,

        /// <summary>
        /// Represents orientation (e.g., azimuth or cardinal directions).
        /// </summary>
        [Description("Orientation")] Orientation,

        /// <summary>
        /// Represents geographic location parameters.
        /// </summary>
        [Description("Location")] Location,

        /// <summary>
        /// Represents spatial or geometric configurations.
        /// </summary>
        [Description("Geometry")] Geometry,

        /// <summary>
        /// Represents bounding box coordinates.
        /// </summary>
        [Description("Bounding Box")] BoundingBox,

        /// <summary>
        /// Represents geometric shape descriptors.
        /// </summary>
        [Description("Shape descriptors")] ShapeDescriptors,

        /// <summary>
        /// Represents occupancy levels or counts.
        /// </summary>
        [Description("Occupancy")] Occupancy,

        /// <summary>
        /// Represents links to orthophotomap imagery.
        /// </summary>
        [Description("Orthophotomap Image")] OrthophotomapImage,

        /// <summary>
        /// Represents comparative data from orthophotomaps.
        /// </summary>
        [Description("Orthophotomap Data")] OrthophotomapData,

        /// <summary>
        /// Represents the year when a structure was built.
        /// </summary>
        [Description("Year built")] YearBuit,

        /// <summary>
        /// Represents building shape classifications.
        /// </summary>
        [Description("Building shape")] BuildingShape,

        /// <summary>
        /// Represents thermal property parameters of a building.
        /// </summary>
        [Description("Thermal properties")] ThermalProperties,

        /// <summary>
        /// Represents shape prediction information.
        /// </summary>
        [Description("Shape prediction")] ShapePrediction,

        /// <summary>
        /// Represents other classifications.
        /// </summary>
        [Description("Other")] Other,
    }
}