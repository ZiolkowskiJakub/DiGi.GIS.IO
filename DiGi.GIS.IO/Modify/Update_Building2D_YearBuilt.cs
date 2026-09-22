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
        /// Updates the table with the three year built columns - predicted, user and calculated - of each building in a specific county.
        /// <para>A building may hold several stored <see cref="YearBuiltData"/> records - the table appends rather than replaces - so the entries of every record carrying the same reference are considered together: each column holds the most frequent year of its kind, the user column counts only exact user years, and the calculated column is the user year when one exists, otherwise the predicted year. All three are derived from the same records in the same call, so they cannot disagree.</para>
        /// <para>Rows already in the table are matched on county identifier and reference; a reference the table does not hold yet is appended. A column a building holds no value for is left as it stood, and a building whose records carry no usable entry at all leaves no row behind.</para>
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="yearBuiltDatas">The collection of stored year built data to derive the columns from.</param>
        /// <returns>The number of rows given at least one of the three values - updated and appended alike. Zero when nothing was written, so a run can tell a county without stored entries from one it never asked about.</returns>
        public static int Update_Building2D_YearBuilt(this Table? table, int countyId, IEnumerable<YearBuiltData>? yearBuiltDatas)
        {
            if (table is null || yearBuiltDatas is null || !yearBuiltDatas.Any())
            {
                return 0;
            }

            Column? column_Reference = table.UpdateColumn<Column>(Constants.Column.Reference);
            if (column_Reference is null)
            {
                return 0;
            }

            Column? column_CountyId = table.UpdateColumn<Column>(Constants.Column.CountyId);
            if (column_CountyId is null)
            {
                return 0;
            }

            //Several records may be stored for one building, so the entries of every record are counted together per reference
            Dictionary<string, List<YearBuiltData>> groupsByReference = [];
            foreach (YearBuiltData? yearBuiltData in yearBuiltDatas)
            {
                if (yearBuiltData?.Reference is not string reference || string.IsNullOrWhiteSpace(reference))
                {
                    continue;
                }

                if (!groupsByReference.TryGetValue(reference, out List<YearBuiltData>? yearBuiltDatas_Group))
                {
                    yearBuiltDatas_Group = [];
                    groupsByReference[reference] = yearBuiltDatas_Group;
                }

                yearBuiltDatas_Group.Add(yearBuiltData);
            }

            if (groupsByReference.Count == 0)
            {
                return 0;
            }

            //reference => the three values to write, a null member being a column the building holds no value for
            Dictionary<string, Tuple<ushort?, ushort?, ushort?>> valuesByReference = [];
            foreach (KeyValuePair<string, List<YearBuiltData>> keyValuePair in groupsByReference)
            {
                //The columns are declared as unsigned years, so a negative year is not written rather than wrapping round to a large one
                ushort? predicted = DiGi.GIS.Query.MostFrequentPredictedYearBuilt(keyValuePair.Value)?.Year is short year_Predicted && year_Predicted >= 0 ? (ushort)year_Predicted : null;
                ushort? user = DiGi.GIS.Query.MostFrequentUserYearBuilt(keyValuePair.Value)?.Year is short year_User && year_User >= 0 ? (ushort)year_User : null;
                ushort? calculated = DiGi.GIS.Query.CalculatedYearBuilt(keyValuePair.Value) is short year_Calculated && year_Calculated >= 0 ? (ushort)year_Calculated : null;

                //A reference is kept only when at least one of the three columns has a value, so a building with bounds-only user entries and no prediction leaves no row
                if (predicted is not null || user is not null || calculated is not null)
                {
                    valuesByReference[keyValuePair.Key] = new Tuple<ushort?, ushort?, ushort?>(predicted, user, calculated);
                }
            }

            if (valuesByReference.Count == 0)
            {
                return 0;
            }

            //The columns are added lazily: a table pushed without a column leaves the stored column untouched, so a missing value keeps what it had
            Column? column_PredictedYearBuilt = table.UpdateColumn<Column>(Constants.Column.PredictedYearBuilt);
            if (column_PredictedYearBuilt is null)
            {
                return 0;
            }

            Column? column_UserYearBuilt = table.UpdateColumn<Column>(Constants.Column.UserYearBuilt);
            if (column_UserYearBuilt is null)
            {
                return 0;
            }

            Column? column_CalculatedYearBuilt = table.UpdateColumn<Column>(Constants.Column.CalculatedYearBuilt);
            if (column_CalculatedYearBuilt is null)
            {
                return 0;
            }

            List<Tuple<Row, Tuple<ushort?, ushort?, ushort?>>> tuples = [];

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

                    if (!valuesByReference.TryGetValue(reference_Row!, out Tuple<ushort?, ushort?, ushort?>? values))
                    {
                        continue;
                    }

                    tuples.Add(new Tuple<Row, Tuple<ushort?, ushort?, ushort?>>(row, values!));
                    valuesByReference.Remove(reference_Row!);
                }
            }

            foreach (KeyValuePair<string, Tuple<ushort?, ushort?, ushort?>> keyValuePair in valuesByReference)
            {
                Row row = table.AddRow();

                SetValue(row, column_Reference, keyValuePair.Key);
                SetValue(row, column_CountyId, countyId);

                tuples.Add(new Tuple<Row, Tuple<ushort?, ushort?, ushort?>>(row, keyValuePair.Value));
            }

            int result = 0;

            foreach (Tuple<Row, Tuple<ushort?, ushort?, ushort?>> tuple in tuples)
            {
                Row row = tuple.Item1;
                Tuple<ushort?, ushort?, ushort?> values = tuple.Item2;

                //A missing value is not written, so the cell keeps what it had
                if (values.Item1 is not null)
                {
                    SetValue(row, column_PredictedYearBuilt, values.Item1);
                }

                if (values.Item2 is not null)
                {
                    SetValue(row, column_UserYearBuilt, values.Item2);
                }

                if (values.Item3 is not null)
                {
                    SetValue(row, column_CalculatedYearBuilt, values.Item3);
                }

                table.AddRow(row, false);
                result++;
            }

            return result;
        }
    }
}
