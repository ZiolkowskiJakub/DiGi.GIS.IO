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
                Column_PredictionYearBuit(Constants.ColumnNamePrefix.PredictionConfidence, year),
                Column_PredictionYearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxX, year),
                Column_PredictionYearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxY, year),
                Column_PredictionYearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxWidth, year),
                Column_PredictionYearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxHeight, year)
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

        /// <summary>
        /// Creates a single-element collection containing a demographic municipality population column for the specified year.
        /// </summary>
        /// <param name="year">The target year for the municipality population count.</param>
        /// <returns>A list containing a single <see cref="Column"/> instance configured for the specified year.</returns>
        public static List<Column> Columns_Population(int year)
        {
            return [Column_Population(year)];
        }

        /// <summary>
        /// Creates a collection of demographic municipality population columns for a sequence of years.
        /// </summary>
        /// <param name="years">The sequence of target years.</param>
        /// <returns>A list of <see cref="Column"/> instances representing municipality population attributes for the specified years, or an empty list if null.</returns>
        public static List<Column> Columns_Population(IEnumerable<int>? years)
        {
            if (years is null)
            {
                return [];
            }

            List<Column> columns = [];
            foreach (int year in years)
            {
                columns.Add(Column_Population(year));
            }

            return columns;
        }

        /// <summary>
        /// Creates a collection of demographic municipality population columns across a range of years.
        /// </summary>
        /// <param name="years">The range of target years.</param>
        /// <returns>A list of <see cref="Column"/> instances representing municipality population attributes for the specified range of years, or an empty list if null.</returns>
        public static List<Column> Columns_Population(Range<int>? years)
        {
            if (years is null)
            {
                return [];
            }

            List<Column> columns = [];
            for (int year = years.Min; year <= years.Max; year++)
            {
                columns.Add(Column_Population(year));
            }

            return columns;
        }

        /// <summary>
        /// Creates a collection containing the radial ratio columns (building coverage ratio and floor area ratio) for the specified radius.
        /// </summary>
        /// <param name="radius">The radius in meters.</param>
        /// <returns>A list of <see cref="Column"/> instances representing the radial ratios for the specified radius.</returns>
        public static List<Column> Columns_RadialRatios(double radius)
        {
            if (double.IsNaN(radius) || double.IsInfinity(radius) || radius <= 0)
            {
                return [];
            }

            return
            [
                Column_RadialBuildingCoverageRatio(radius),
                Column_RadialFloorAreaRatio(radius)
            ];
        }

        /// <summary>
        /// Creates a collection of radial ratio columns (building coverage ratio and floor area ratio) for a collection of radiuses.
        /// </summary>
        /// <param name="radiuses">The collection of radiuses in meters.</param>
        /// <returns>A list of <see cref="Column"/> instances representing the radial ratios for the specified radiuses, or an empty list if null.</returns>
        public static List<Column> Columns_RadialRatios(IEnumerable<double>? radiuses)
        {
            if (radiuses is null)
            {
                return [];
            }

            List<Column> columns = [];
            foreach (double radius in radiuses)
            {
                columns.AddRange(Columns_RadialRatios(radius));
            }

            return columns;
        }
    }
}
