using DiGi.Core.Classes;
using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Retrieves the names the Year Built prediction input features are bound by, for the specified range of years and radial radiuses.
        /// <para>These are the <see cref="Column.Name"/> values - the names a <c>ModelInput</c> member is bound to, not the stored column identifiers - and they are the one place an orchestrator compares its options against the predictor's stated contract: a name the model needs but the options do not ask for is the silent-degradation case, and a name the options ask for but the model does not use is the harmless surplus.</para>
        /// <para>Built from <see cref="YearBuiltPredictionInputColumns(Range{int}?, IEnumerable{double}?)"/> so the allow-list and its names cannot drift apart.</para>
        /// </summary>
        /// <param name="years">The range of years for detection and temporal features. Defaults to 2008..2025 when null.</param>
        /// <param name="radiuses">The collection of radiuses for radial ratio features. Defaults to 200, 400, 600, 1000 when null.</param>
        /// <returns>The set of input feature names the projection for the given options asks for.</returns>
        public static HashSet<string> YearBuiltPredictionInputColumnNames(Range<int>? years = null, IEnumerable<double>? radiuses = null)
        {
            HashSet<string> names = [];
            foreach (Column column in YearBuiltPredictionInputColumns(years, radiuses))
            {
                if (column.Name is string name)
                {
                    names.Add(name);
                }
            }

            return names;
        }
    }
}
