namespace DiGi.GIS.IO.Constants
{
    /// <summary>
    /// Provides standard suffix names for columns relating to image and data comparison.
    /// </summary>
    public static class ColumnNameSuffix
    {
        /// <summary>
        /// Suffix for the average color similarity comparison column.
        /// </summary>
        public const string AverageColorSimilarity = "Average Color Similarity";

        /// <summary>
        /// Suffix for the color distribution shift comparison column.
        /// </summary>
        public const string ColorDistributionShift = "Color Distribution Shift";

        /// <summary>
        /// Suffix for the gray histogram factor comparison column.
        /// </summary>
        public const string GrayHistogramFactor = "Gray Histogram Factor";

        /// <summary>
        /// Suffix for the Hamming distance comparison column.
        /// </summary>
        public const string HammingDistance = "Hamming Distance";

        /// <summary>
        /// Suffix for the histogram correlation comparison column.
        /// </summary>
        public const string HistogramCorrelation = "Histogram Correlation";

        /// <summary>
        /// Suffix for the shape comparison factor column.
        /// </summary>
        public const string ShapeComparisonFactor = "Shape Comparison Factor";

        /// <summary>
        /// Suffix for the Structural Similarity Index calculated using the absolute difference method.
        /// </summary>
        public const string StructuralSimilarityIndex_AbsoluteDifference = "Structural Similarity Index (Absolute Difference)";

        /// <summary>
        /// Suffix for the Structural Similarity Index calculated using the match template method.
        /// </summary>
        public const string StructuralSimilarityIndex_MatchTemplate = "Structural Similarity Index (Match Template)";

        /// <summary>
        /// Suffix for the mean Laplacian factor comparison column.
        /// </summary>
        public const string MeanLaplacianFactor = "Mean Laplacian Factor";

        /// <summary>
        /// Suffix for the standard deviation Laplacian factor comparison column.
        /// </summary>
        public const string StandardDeviationLaplacianFactor = "Standard Deviation Laplacian Factor";

        /// <summary>
        /// Suffix for the optical flow average magnitude comparison column.
        /// </summary>
        public const string OpticalFlowAverageMagnitude = "Optical Flow Average Magnitude";

        /// <summary>
        /// Suffix for the ORB feature matching factor comparison column.
        /// </summary>
        public const string ORBFeatureMatchingFactor = "ORB Feature Matching Factor";
    }
}