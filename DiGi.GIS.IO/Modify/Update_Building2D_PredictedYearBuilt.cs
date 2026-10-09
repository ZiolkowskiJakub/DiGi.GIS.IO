using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.GIS.IO
{
    public static partial class Modify
    {
        /// <summary>
        /// Clears the <c>Predicted year built</c> column of each named building in a specific county, leaving the <c>User year built</c> and <c>Calculated year built</c> columns as they stood.
        /// <para>Only the predicted column is carried, so <c>TablePostgreSQLConverter.PushAsync</c> writes NULL for it on the named rows while the two other year built columns are untouched - a table pushed without a column does not touch the stored column. A value a matched row already held is removed from it, so a stale predicted year cannot survive into the push.</para>
        /// <para>This is the companion to <see cref="Update_Building2D_YearBuiltPredictions"/>: a building the current detector never fired on has its detection columns replaced (ZiolkowskiJakub/DiGi.GIS.YOLO.UI#21), and this removes the predicted year that was derived from the evidence that is now gone (ZiolkowskiJakub/DiGi.GIS.YOLO.UI#28). It is the selective counterpart of <see cref="Update_Building2D_YearBuilt"/>, which clears all three year built columns together and would also remove a stored user year.</para>
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="references">The references of the buildings whose predicted year is cleared.</param>
        /// <returns>The number of references emitted - updated and appended alike. Zero when nothing was written, so a run can tell a county without named buildings from one it never asked about.</returns>
        public static int Update_Building2D_PredictedYearBuilt(this Table? table, int countyId, IEnumerable<string>? references)
        {
            if (table is null || references is null)
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

            //Only the predicted column is carried, so the push writes NULL for it and leaves user and calculated as they stood
            Column? column_PredictedYearBuilt = table.UpdateColumn<Column>(Constants.Column.PredictedYearBuilt);
            if (column_PredictedYearBuilt is null)
            {
                return 0;
            }

            HashSet<string> references_Emit = [.. references.Where(x => !string.IsNullOrWhiteSpace(x))];
            if (references_Emit.Count == 0)
            {
                return 0;
            }

            List<Row> rows = [];

            //A row the table already holds for the same county and building is reused rather than appended a second time
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

                    if (!row.TryGetValue(column_CountyId.Index, out int countyId_Row) || countyId_Row != countyId)
                    {
                        continue;
                    }

                    if (!row.TryGetValue(column_Reference.Index, out string? reference_Row) || string.IsNullOrWhiteSpace(reference_Row))
                    {
                        continue;
                    }

                    if (references_Emit.Contains(reference_Row!))
                    {
                        rows.Add(row);
                        references_Emit.Remove(reference_Row!);
                    }
                }
            }

            foreach (string reference in references_Emit)
            {
                Row row = table.AddRow();

                SetValue(row, column_Reference, reference);
                SetValue(row, column_CountyId, countyId);

                rows.Add(row);
            }

            int result = 0;
            foreach (Row row in rows)
            {
                //A cleared cell is an absent one - a value a matched row already held is removed so the push stores NULL
                row.RemoveValue(column_PredictedYearBuilt.Index);

                table.AddRow(row, false);

                result++;
            }

            return result;
        }
    }
}
