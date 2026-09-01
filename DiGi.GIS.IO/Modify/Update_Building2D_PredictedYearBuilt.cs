using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.GIS.IO
{
    public static partial class Modify
    {
        /// <summary>
        /// Updates the table with the latest predicted year built of each building in a specific county.
        /// <para>A building may hold several stored <see cref="YearBuiltData"/> records - the table appends rather than replaces - so the predictions of every record carrying the same reference are considered together and the one made most recently wins.</para>
        /// <para>Rows already in the table are matched on county identifier and reference; a reference the table does not hold yet is appended, so the same method serves a run that is building rows from buildings and a run that is writing predictions on their own.</para>
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="yearBuiltDatas">The collection of stored year built data to take the predictions from.</param>
        public static void Update_Building2D_PredictedYearBuilt(this Table? table, int countyId, IEnumerable<YearBuiltData>? yearBuiltDatas)
        {
            if (table is null || yearBuiltDatas is null || !yearBuiltDatas.Any())
            {
                return;
            }

            Column? column_Reference = table.UpdateColumn<Column>(Constants.Column.Reference);
            if (column_Reference is null)
            {
                return;
            }

            Column? column_CountyId = table.UpdateColumn<Column>(Constants.Column.CountyId);
            if (column_CountyId is null)
            {
                return;
            }

            Dictionary<string, PredictedYearBuilt> dictionary = [];
            foreach (YearBuiltData yearBuiltData in yearBuiltDatas)
            {
                if (yearBuiltData?.Reference is not string reference || string.IsNullOrWhiteSpace(reference))
                {
                    continue;
                }

                if (yearBuiltData.GetLatestPredictedYearBuilt() is not PredictedYearBuilt predictedYearBuilt)
                {
                    continue;
                }

                //Several records may be stored for one building, so the newest prediction across all of them is the one written
                if (dictionary.TryGetValue(reference, out PredictedYearBuilt predictedYearBuilt_Existing) && predictedYearBuilt_Existing is not null && predictedYearBuilt_Existing.DateTime >= predictedYearBuilt.DateTime)
                {
                    continue;
                }

                dictionary[reference] = predictedYearBuilt;
            }

            if (dictionary.Count == 0)
            {
                return;
            }

            Column? column_PredictedYearBuilt = table.UpdateColumn<Column>(Constants.Column.PredictedYearBuilt);
            if (column_PredictedYearBuilt is null)
            {
                return;
            }

            List<Tuple<Row, PredictedYearBuilt>> tuples = [];

            int count = table.RowCount;
            if (count != 0)
            {
                for (int i = count - 1; i >= 0; i--)
                {
                    Row? row = table.GetRow(i);
                    if (row is null)
                    {
                        continue;
                    }

                    if (!row.TryGetValue(column_CountyId.Index, out int countyId_Row))
                    {
                        continue;
                    }

                    if (countyId_Row != countyId)
                    {
                        continue;
                    }

                    if (!row.TryGetValue(column_Reference.Index, out string? reference_Row) || string.IsNullOrWhiteSpace(reference_Row))
                    {
                        continue;
                    }

                    if (!dictionary.TryGetValue(reference_Row!, out PredictedYearBuilt predictedYearBuilt))
                    {
                        continue;
                    }

                    tuples.Add(new Tuple<Row, PredictedYearBuilt>(row, predictedYearBuilt));
                    dictionary.Remove(reference_Row!);
                }
            }

            foreach (KeyValuePair<string, PredictedYearBuilt> keyValuePair in dictionary)
            {
                Row row = table.AddRow();

                SetValue(row, column_Reference, keyValuePair.Key);
                SetValue(row, column_CountyId, countyId);

                tuples.Add(new Tuple<Row, PredictedYearBuilt>(row, keyValuePair.Value));
            }

            foreach (Tuple<Row, PredictedYearBuilt> tuple in tuples)
            {
                Row row = tuple.Item1;
                short year = tuple.Item2.Year;

                //The column is declared as an unsigned year, so a negative prediction is not written rather than wrapping round to a large one
                if (year < 0)
                {
                    continue;
                }

                SetValue(row, column_PredictedYearBuilt, (ushort)year);

                table.AddRow(row, false);
            }
        }
    }
}
