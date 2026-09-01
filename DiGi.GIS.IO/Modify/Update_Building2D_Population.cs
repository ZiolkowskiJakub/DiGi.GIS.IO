using DiGi.Core.Classes;
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
        /// Updates the table with yearly population data for building 2D geometries in a specific county from a yearly double data series.
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="building2Ds">The collection of building 2D geometries.</param>
        /// <param name="statisticalYearlyDoubleData">The yearly statistical double data containing population counts.</param>
        /// <param name="years">The optional range of years for the population series, defaulting to 2008..2025.</param>
        public static void Update_Building2D_Population(this Table? table, int countyId, IEnumerable<Building2D>? building2Ds, StatisticalYearlyDoubleData? statisticalYearlyDoubleData, Range<int>? years = null)
        {
            if (table is null || building2Ds is null || !building2Ds.Any() || statisticalYearlyDoubleData is null)
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

            Range<int> range_Years = years ?? new Range<int>(2008, 2025);

            Dictionary<int, Column> dictionary_Columns = [];
            for (int year = range_Years.Min; year <= range_Years.Max; year++)
            {
                Column? column = table.UpdateColumn(Create.Column_Population(year));
                if (column is not null)
                {
                    dictionary_Columns[year] = column;
                }
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

                for (int year = range_Years.Min; year <= range_Years.Max; year++)
                {
                    if (!dictionary_Columns.TryGetValue(year, out Column column) || column is null)
                    {
                        continue;
                    }

                    if (statisticalYearlyDoubleData.TryGetValue((short)year, out double value))
                    {
                        SetValue(row, column, (int)Math.Round(value));
                    }
                }

                table.AddRow(row, false);
            }
        }

        /// <summary>
        /// Updates the table with yearly population data for building 2D geometries in a specific county from a statistical data collection.
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="building2Ds">The collection of building 2D geometries.</param>
        /// <param name="statisticalDataCollection">The statistical data collection containing the population data.</param>
        /// <param name="years">The optional range of years for the population series, defaulting to 2008..2025.</param>
        public static void Update_Building2D_Population(this Table? table, int countyId, IEnumerable<Building2D>? building2Ds, StatisticalDataCollection? statisticalDataCollection, Range<int>? years = null)
        {
            if (statisticalDataCollection is null)
            {
                return;
            }

            StatisticalYearlyDoubleData? statisticalYearlyDoubleData = statisticalDataCollection.GetStatisticalData("Population") as StatisticalYearlyDoubleData
                ?? statisticalDataCollection.Find<StatisticalYearlyDoubleData>(x => x?.Name != null && x.Name.IndexOf("population", StringComparison.OrdinalIgnoreCase) >= 0);

            Update_Building2D_Population(table, countyId, building2Ds, statisticalYearlyDoubleData, years);
        }
    }
}
