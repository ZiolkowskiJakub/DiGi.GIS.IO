namespace DiGi.GIS.IO.Constants
{
    /// <summary>
    /// Provides standard prefix names for prediction-related columns in the GIS system.
    /// </summary>
    public static class ColumnNamePrefix
    {
        /// <summary>
        /// Prefix for confidence score columns.
        /// </summary>
        public const string PredictionConfidence = "Prediction Confidence";

        /// <summary>
        /// Prefix for predicted bounding box center point X coordinate columns.
        /// </summary>
        public const string PredictionBoundingBoxX = "Prediction BoundingBox X";

        /// <summary>
        /// Prefix for predicted bounding box center point Y coordinate columns.
        /// </summary>
        public const string PredictionBoundingBoxY = "Prediction BoundingBox Y";

        /// <summary>
        /// Prefix for predicted bounding box width columns.
        /// </summary>
        public const string PredictionBoundingBoxWidth = "Prediction BoundingBox Width";

        /// <summary>
        /// Prefix for predicted bounding box height columns.
        /// </summary>
        public const string PredictionBoundingBoxHeight = "Prediction BoundingBox Height";
    }
}