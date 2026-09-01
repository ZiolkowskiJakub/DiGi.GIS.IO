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
        /// Updates the table with building 2D occupancy features for a specific county.
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="building2Ds">The collection of building 2D geometries.</param>
        public static void Update_Building2D_Occupancy(this Table? table, int countyId, IEnumerable<Building2D>? building2Ds)
        {
            if (table is null || building2Ds is null || !building2Ds.Any())
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

            Dictionary<string, Building2D> dictionary = [];
            foreach (Building2D building2D in building2Ds)
            {
                if (building2D?.Reference is not string reference || string.IsNullOrWhiteSpace(reference))
                {
                    continue;
                }

                dictionary[reference] = building2D;
            }

            if (dictionary.Count == 0)
            {
                return;
            }

            Column? column_IsOccupied = table.UpdateColumn<Column>(Constants.Column.IsOccupied);
            Column? column_IsResidential = table.UpdateColumn<Column>(Constants.Column.IsResidential);

            List<Tuple<Row, Building2D>> tuples = [];

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

                    if (!dictionary.TryGetValue(reference_Row!, out Building2D building2D))
                    {
                        continue;
                    }

                    tuples.Add(new Tuple<Row, Building2D>(row, building2D));
                    dictionary.Remove(reference_Row!);
                }
            }

            foreach (Building2D building2D in dictionary.Values)
            {
                Row row = table.AddRow();

                SetValue(row, column_Reference, building2D.Reference);
                SetValue(row, column_CountyId, countyId);

                tuples.Add(new Tuple<Row, Building2D>(row, building2D));
            }

            foreach (Tuple<Row, Building2D> tuple in tuples)
            {
                Row row = tuple.Item1;
                Building2D building2D = tuple.Item2;

                SetValue(row, column_IsOccupied, GIS.Query.IsOccupied(building2D));
                SetValue(row, column_IsResidential, GIS.Query.IsResidential(building2D));

                table.AddRow(row, false);
            }
        }
    }
}
