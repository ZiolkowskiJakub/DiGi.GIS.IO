using DiGi.Core.Classes;
using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Computes the regressor-free "first detection year" baseline, one entry per row.
        /// <para>For each row, the first year of the range whose <c>Prediction Confidence {year}</c> value is present and greater than zero - the first year the detector saw the building. A row whose confidence values are all absent or zero falls back to <c>year_Default</c>.</para>
        /// <para>This is the detector-only acceptance baseline of the YOLO retrain (ZiolkowskiJakub/DiGi.GIS.YOLO.UI#12): on the 2025-05-27 table it scores MAE 0.434 (OrtoBuildingDetectionModel.provenance.md), the bar a retrained detector has to clear. The regressor evaluation and the detector evaluation both compute it from the same columns, so the rule lives here where both can reach it.</para>
        /// <para>The result aligns with the rows by index, so a caller that wants a dictionary zips it with the reference column.</para>
        /// </summary>
        /// <param name="table">The table carrying the per-year <c>Prediction Confidence</c> columns, or null.</param>
        /// <param name="years">The years to scan, in row order. Defaults to 2008..2025, the same default as <see cref="YearBuiltPredictionFeatureGroups(Range{int}?, IEnumerable{double}?)"/>.</param>
        /// <param name="year_Default">The year reported for a row whose confidence values are all absent or zero. Defaults to 2008.</param>
        /// <returns>One entry per row, in row order: the first detection year of each row. Empty when the table is null or holds no rows.</returns>
        public static List<short> FirstDetectionYears(this Table? table, Range<int>? years = null, short year_Default = 2008)
        {
            List<short> result = [];
            if (table is null || table.RowCount == 0)
            {
                return result;
            }

            Range<int> range_Years = years ?? new(2008, 2025);

            List<short> years_Column = [];
            List<int> indexes = [];
            for (int year = range_Years.Min; year <= range_Years.Max; year++)
            {
                years_Column.Add((short)year);
                indexes.Add(table.GetColumnIndex(Create.Column_PredictionYearBuit(Constants.ColumnNamePrefix.PredictionConfidence, year).Name));
            }

            for (int i = 0; i < table.RowCount; i++)
            {
                short year_First = year_Default;
                for (int j = 0; j < indexes.Count; j++)
                {
                    if (indexes[j] >= 0 && table.TryGetValue(i, indexes[j], out double confidence) && confidence > 0)
                    {
                        year_First = years_Column[j];
                        break;
                    }
                }

                result.Add(year_First);
            }

            return result;
        }
    }
}
