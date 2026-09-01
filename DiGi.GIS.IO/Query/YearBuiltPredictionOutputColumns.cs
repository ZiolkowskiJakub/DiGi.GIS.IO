using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Retrieves the list of columns written as output by the Year Built prediction machine learning model pipeline.
        /// </summary>
        /// <returns>A list of <see cref="Column"/> instances representing the model output columns.</returns>
        public static List<Column> YearBuiltPredictionOutputColumns()
        {
            return
            [
                Constants.Column.PredictedYearBuilt
            ];
        }
    }
}
