using DiGi.Core.Classes;
using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.IO
{
    public static partial class Create
    {
        /// <summary>
        /// Creates the collection of prediction columns (confidence, centroid coordinates, and dimensions) for a specified year.
        /// </summary>
        /// <param name="year">The target prediction year.</param>
        /// <returns>A list of <see cref="Column"/> instances representing the prediction attributes for the specified year.</returns>
        public static List<Column> Columns_PredictionYearBuilt(int year)
        {
            return
            [
                Column_YearBuit(Constants.ColumnNamePrefix.PredictionConfidence, year),
                Column_YearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxX, year),
                Column_YearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxY, year),
                Column_YearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxWidth, year),
                Column_YearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxHeight, year)
            ];
        }

        /// <summary>
        /// Creates the collection of prediction columns (confidence, centroid coordinates, and dimensions) across a collection of years.
        /// </summary>
        /// <param name="years">The collection of target prediction years.</param>
        /// <returns>A list of <see cref="Column"/> instances representing the prediction attributes for the specified years, or an empty list if null.</returns>
        public static List<Column> Columns_PredictionYearBuilt(IEnumerable<int>? years)
        {
            if (years is null)
            {
                return [];
            }

            List<Column> columns = [];
            foreach (int year in years)
            {
                columns.AddRange(Columns_PredictionYearBuilt(year));
            }

            return columns;
        }

        /// <summary>
        /// Creates the collection of prediction columns (confidence, centroid coordinates, and dimensions) across a range of years.
        /// </summary>
        /// <param name="years">The range of target prediction years.</param>
        /// <returns>A list of <see cref="Column"/> instances representing the prediction attributes for the specified range of years, or an empty list if null.</returns>
        public static List<Column> Columns_PredictionYearBuilt(Range<int>? years)
        {
            if (years is null)
            {
                return [];
            }

            List<Column> columns = [];
            for (int year = years.Min; year <= years.Max; year++)
            {
                columns.AddRange(Columns_PredictionYearBuilt(year));
            }

            return columns;
        }
    }
}
