using DiGi.Core;
using DiGi.Core.IO.Table.Classes;

namespace DiGi.GIS.IO
{
    public static partial class Create
    {
        /// <summary>
        /// Creates a column representing comparison data for orthophotomap images taken in two different years.
        /// </summary>
        /// <param name="year_1">The first year of the orthophotomap comparison.</param>
        /// <param name="year_2">The second year of the orthophotomap comparison.</param>
        /// <param name="columnNamePrefix">The prefix describing the type of bounding box filling or method used (e.g., "BB", "P", "PO").</param>
        /// <param name="columnNameSuffix">The suffix describing the metric being compared (e.g., "Average Color Similarity", "Hamming Distance").</param>
        /// <returns>A new <see cref="ExtendedColumn"/> configured with the generated name, target type (float), category description, and metadata explanation.</returns>
        public static Column Column_OrthophotomapData(int year_1, int year_2, string columnNamePrefix, string columnNameSuffix)
        {
            string additionalText = string.Empty;
            if (columnNamePrefix == "BB")
            {
                additionalText = "full BoundingBox ";
            }
            else if (columnNamePrefix == "P")
            {
                additionalText = "BoundingBox filled ";
            }
            else if (columnNamePrefix == "PO")
            {
                additionalText = "BoundingBox filled with offset ";
            }

            return new ExtendedColumn($@"{columnNamePrefix} {year_1} {year_2} {columnNameSuffix}", typeof(float), Enums.Category.OrthophotomapData.Description(), $@"{columnNameSuffix} comparison based on {additionalText}orthophotomap taken {year_1} and {year_2}");
        }

        /// <summary>
        /// Creates a column representing prediction data related to the year a building was built.
        /// </summary>
        /// <param name="columnNamePrefix">The prefix describing the prediction type (e.g., confidence or bounding box coordinates).</param>
        /// <param name="year">The target prediction year.</param>
        /// <returns>A new <see cref="ExtendedColumn"/> configured with the generated name, target type (double), category description, and description text.</returns>
        public static Column Column_YearBuit(string columnNamePrefix, int year)
        {
            return new ExtendedColumn($@"{columnNamePrefix} {year}", typeof(double), Enums.Category.YearBuit.Description(), $@"{columnNamePrefix} based on predition for {year}");
        }

        /// <summary>
        /// Creates a column containing the URL link to the orthophotomap image for a specific year.
        /// </summary>
        /// <param name="year">The year of the orthophotomap image.</param>
        /// <returns>A new <see cref="ExtendedColumn"/> configured with the generated name, target type (string), category description, and details of the image link.</returns>
        public static Column Column_OrthophotomapImage(int year)
        {
            return new ExtendedColumn($@"Orthophotomap image link {year}", typeof(string), Enums.Category.OrthophotomapImage.Description(), $@"Link to orthophotomap image for {year}");
        }

        /// <summary>
        /// Creates a column representing normalized grid cell coverage values for a bounding rectangle.
        /// </summary>
        /// <param name="widthCount">The segment index along the horizontal axis (0 to 4).</param>
        /// <param name="heightCount">The segment index along the vertical axis (0 to 4).</param>
        /// <returns>A new <see cref="ExtendedColumn"/> configured with the grid location, target type (float), category description, and detailed computation details.</returns>
        public static Column Column_GridCellCoverage(int widthCount, int heightCount)
        {
            return new ExtendedColumn($"Grid cell coverage [{widthCount},{heightCount}]", typeof(float), Enums.Category.ShapePrediction.Description(), $"A normalized value between 0.0 (completely empty) and 1.0 (fully occupied) that represents the shape intersection area divided by the total area of an individual grid cell. The grid is created by taking the bounding rectangle of the shape and dividing its edges into 5 segments of equal length. Value represents cell [{widthCount},{heightCount}]");
        }
    }
}