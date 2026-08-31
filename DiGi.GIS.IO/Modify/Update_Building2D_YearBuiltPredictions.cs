using DiGi.Core.IO.Table.Classes;
using DiGi.Geometry.Planar.Classes;
using DiGi.GIS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.GIS.IO
{
    public static partial class Modify
    {
        /// <summary>
        /// Updates the table with year-built predictions for structures in a specific county.
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="building2DYearBuiltPredictions">The collection of year-built predictions.</param>
        public static void Update_Building2D_YearBuiltPredictions(this Table? table, int countyId, IEnumerable<Building2DYearBuiltPredictions>? building2DYearBuiltPredictions)
        {
            if (table is null || building2DYearBuiltPredictions is null || !building2DYearBuiltPredictions.Any())
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

            HashSet<ushort> years = [];
            Dictionary<string, Building2DYearBuiltPredictions> dictionary = [];
            foreach (Building2DYearBuiltPredictions building2DYearBuiltPredictions_Temp in building2DYearBuiltPredictions)
            {
                if (building2DYearBuiltPredictions_Temp?.Reference is not string reference || string.IsNullOrWhiteSpace(reference))
                {
                    continue;
                }

                if (building2DYearBuiltPredictions_Temp.Years is not List<ushort> years_Temp)
                {
                    continue;
                }

                dictionary[reference] = building2DYearBuiltPredictions_Temp;

                foreach (ushort year in years_Temp)
                {
                    years.Add(year);
                }
            }

            if (dictionary.Count == 0)
            {
                return;
            }

            Dictionary<ushort, Column> dictionary_PredictionConfidence = [];
            Dictionary<ushort, Column> dictionary_PredictionBoundingBoxX = [];
            Dictionary<ushort, Column> dictionary_PredictionBoundingBoxY = [];
            Dictionary<ushort, Column> dictionary_PredictionBoundingBoxWidth = [];
            Dictionary<ushort, Column> dictionary_PredictionBoundingBoxHeight = [];
            foreach (ushort year in years)
            {
                List<Column> columns = Create.Columns_PredictionYearBuilt(year);
                if (columns.Count < 5)
                {
                    continue;
                }

                Column? column_PredictionConfidence = table.UpdateColumn(columns[0]);
                if (column_PredictionConfidence is not null)
                {
                    dictionary_PredictionConfidence[year] = column_PredictionConfidence;
                }

                Column? column_PredictionBoundingBoxX = table.UpdateColumn(columns[1]);
                if (column_PredictionBoundingBoxX is not null)
                {
                    dictionary_PredictionBoundingBoxX[year] = column_PredictionBoundingBoxX;
                }

                Column? column_PredictionBoundingBoxY = table.UpdateColumn(columns[2]);
                if (column_PredictionBoundingBoxY is not null)
                {
                    dictionary_PredictionBoundingBoxY[year] = column_PredictionBoundingBoxY;
                }

                Column? column_PredictionBoundingBoxWidth = table.UpdateColumn(columns[3]);
                if (column_PredictionBoundingBoxWidth is not null)
                {
                    dictionary_PredictionBoundingBoxWidth[year] = column_PredictionBoundingBoxWidth;
                }

                Column? column_PredictionBoundingBoxHeight = table.UpdateColumn(columns[4]);
                if (column_PredictionBoundingBoxHeight is not null)
                {
                    dictionary_PredictionBoundingBoxHeight[year] = column_PredictionBoundingBoxHeight;
                }
            }

            List<Tuple<Row, Building2DYearBuiltPredictions>> tuples = [];

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

                    if (!dictionary.TryGetValue(reference_Row!, out Building2DYearBuiltPredictions building2DYearBuiltPredictions_Temp))
                    {
                        continue;
                    }

                    tuples.Add(new Tuple<Row, Building2DYearBuiltPredictions>(row, building2DYearBuiltPredictions_Temp));
                    dictionary.Remove(reference_Row!);
                }
            }

            foreach (Building2DYearBuiltPredictions building2DYearBuiltPredictions_Temp in dictionary.Values)
            {
                Row row = table.AddRow();

                SetValue(row, column_Reference, building2DYearBuiltPredictions_Temp.Reference);
                SetValue(row, column_CountyId, countyId);

                tuples.Add(new Tuple<Row, Building2DYearBuiltPredictions>(row, building2DYearBuiltPredictions_Temp));
            }

            foreach (Tuple<Row, Building2DYearBuiltPredictions> tuple in tuples)
            {
                Row row = tuple.Item1;
                Building2DYearBuiltPredictions building2DYearBuiltPredictions_Temp = tuple.Item2;

                if (building2DYearBuiltPredictions_Temp.Years is not List<ushort> years_Temp)
                {
                    continue;
                }

                foreach (ushort year in building2DYearBuiltPredictions_Temp.Years)
                {
                    YearBuiltPrediction? yearBuiltPrediction = building2DYearBuiltPredictions_Temp[year];
                    if (yearBuiltPrediction is null)
                    {
                        continue;
                    }

                    if (dictionary_PredictionConfidence.TryGetValue(year, out Column column))
                    {
                        SetValue(row, column, yearBuiltPrediction.Confidence);
                    }

                    if (yearBuiltPrediction.BoundingBox is BoundingBox2D boundingBox2D && boundingBox2D.GetCentroid() is Point2D centroid)
                    {
                        if (dictionary_PredictionBoundingBoxX.TryGetValue(year, out column) && column is not null)
                        {
                            SetValue(row, column, centroid.X);
                        }

                        if (dictionary_PredictionBoundingBoxY.TryGetValue(year, out column) && column is not null)
                        {
                            SetValue(row, column, centroid.Y);
                        }

                        if (dictionary_PredictionBoundingBoxWidth.TryGetValue(year, out column) && column is not null)
                        {
                            SetValue(row, column, boundingBox2D.Width);
                        }

                        if (dictionary_PredictionBoundingBoxHeight.TryGetValue(year, out column) && column is not null)
                        {
                            SetValue(row, column, boundingBox2D.Height);
                        }
                    }
                }

                table.AddRow(row, false);
            }
        }
    }
}
