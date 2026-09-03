using DiGi.Core.Classes;
using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Retrieves the list of columns permitted as input features for the Year Built prediction machine learning model across the specified range of years and radial radiuses.
        /// <para>Assembled from <see cref="YearBuiltPredictionFeatureGroups(Range{int}?, IEnumerable{double}?)"/> rather than listed a second time, so a column added to a group reaches the allow-list without anyone remembering to add it twice.</para>
        /// </summary>
        /// <param name="years">The range of years for detection and temporal features. Defaults to 2008..2025 when null.</param>
        /// <param name="radiuses">The collection of radiuses for radial ratio features. Defaults to 200, 400, 600, 1000 when null.</param>
        /// <returns>A list of <see cref="Column"/> instances representing the allowed input features.</returns>
        public static List<Column> YearBuiltPredictionInputColumns(Range<int>? years = null, IEnumerable<double>? radiuses = null)
        {
            Dictionary<string, List<Column>> columns_ByGroup = YearBuiltPredictionFeatureGroups(years, radiuses);

            List<string> names_Group =
            [
                Constants.YearBuiltPredictionFeatureGroup.Base,
                Constants.YearBuiltPredictionFeatureGroup.GridCellCoverage,
                Constants.YearBuiltPredictionFeatureGroup.Detection,
                Constants.YearBuiltPredictionFeatureGroup.Population,
                Constants.YearBuiltPredictionFeatureGroup.RadialRatio
            ];

            List<Column> result = [];
            foreach (string name_Group in names_Group)
            {
                if (columns_ByGroup.TryGetValue(name_Group, out List<Column>? columns) && columns is not null)
                {
                    result.AddRange(columns);
                }
            }

            return result;
        }
    }
}
