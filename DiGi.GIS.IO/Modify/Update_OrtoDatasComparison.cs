using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.Emgu.CV.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.GIS.IO
{
    public static partial class Modify
    {
        /// <summary>
        /// Updates the table with orthophotomap comparison data for structures in a specific county.
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="ortoDatasComparisons">The collection of orthophotomap data comparisons.</param>
        public static void Update_OrtoDatasComparison(this Table? table, int countyId, IEnumerable<OrtoDatasComparison>? ortoDatasComparisons)
        {
            if (table is null || ortoDatasComparisons is null || !ortoDatasComparisons.Any())
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

            List<Tuple<string, int, int>> tuples = [];

            Dictionary<string, OrtoDatasComparison> dictionary = [];
            foreach (OrtoDatasComparison ortoDatasComparison in ortoDatasComparisons)
            {
                if (ortoDatasComparison?.Reference is not string reference || string.IsNullOrWhiteSpace(reference))
                {
                    continue;
                }

                IEnumerable<OrtoDataComparison>? ortoDataComparisons = ortoDatasComparison.OrtoDataComparisons;
                if (ortoDataComparisons is null || !ortoDataComparisons.Any())
                {
                    continue;
                }

                foreach (OrtoDataComparison ortoDataComparison in ortoDataComparisons)
                {
                    int year_1 = ortoDataComparison.DateTime.Year;

                    IEnumerable<OrtoImageComparisonGroup>? ortoImageComparisonGroups = ortoDataComparison.OrtoImageComparisonGroups;
                    if (ortoImageComparisonGroups is not null && ortoImageComparisonGroups.Any())
                    {
                        foreach (OrtoImageComparisonGroup ortoImageComparisonGroup in ortoImageComparisonGroups)
                        {
                            if (ortoImageComparisonGroup is null)
                            {
                                continue;
                            }

                            string name = string.IsNullOrEmpty(ortoImageComparisonGroup.Name) ? string.Empty : ortoImageComparisonGroup.Name!;

                            if (ortoImageComparisonGroup.OrtoImageComparisons is IEnumerable<OrtoImageComparison> ortoImageComparisons)
                            {
                                foreach (OrtoImageComparison ortoImageComparison in ortoImageComparisons)
                                {
                                    int year_2 = ortoImageComparison.DateTime.Year;

                                    if (tuples.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2) != null)
                                    {
                                        continue;
                                    }

                                    tuples.Add(new Tuple<string, int, int>(name, year_1, year_2));
                                }
                            }
                        }
                    }
                }

                dictionary[reference] = ortoDatasComparison;
            }

            List<Tuple<string, int, int, Column>> tuples_AverageColorSimilarity = [];
            List<Tuple<string, int, int, Column>> tuples_HammingDistance = [];
            List<Tuple<string, int, int, Column>> tuples_GrayHistogramFactor = [];
            List<Tuple<string, int, int, Column>> tuples_HistogramCorrelation = [];
            List<Tuple<string, int, int, Column>> tuples_ShapeComparisonFactor = [];
            List<Tuple<string, int, int, Column>> tuples_StructuralSimilarityIndex_AbsoluteDifference = [];
            List<Tuple<string, int, int, Column>> tuples_StructuralSimilarityIndex_MatchTemplate = [];
            List<Tuple<string, int, int, Column>> tuples_ColorDistributionShift = [];
            List<Tuple<string, int, int, Column>> tuples_OpticalFlowAverageMagnitude = [];
            List<Tuple<string, int, int, Column>> tuples_ORBFeatureMatchingFactor = [];

            foreach (Tuple<string, int, int> tuple in tuples)
            {
                Column column;

                column = Create.Column_OrthophotomapData(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.AverageColorSimilarity);

                Column? column_AverageColorSimilarity = table.UpdateColumn(column);
                if (column_AverageColorSimilarity is not null)
                {
                    tuples_AverageColorSimilarity.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_AverageColorSimilarity));
                }

                column = Create.Column_OrthophotomapData(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.HammingDistance);

                Column? column_HammingDistance = table.UpdateColumn(column);
                if (column_HammingDistance is not null)
                {
                    tuples_HammingDistance.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_HammingDistance));
                }

                column = Create.Column_OrthophotomapData(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.GrayHistogramFactor);

                Column? column_GrayHistogramFactor = table.UpdateColumn(column);
                if (column_GrayHistogramFactor is not null)
                {
                    tuples_GrayHistogramFactor.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_GrayHistogramFactor));
                }

                column = Create.Column_OrthophotomapData(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.ShapeComparisonFactor);

                Column? column_ShapeComparisonFactor = table.UpdateColumn(column);
                if (column_ShapeComparisonFactor is not null)
                {
                    tuples_ShapeComparisonFactor.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_ShapeComparisonFactor));
                }

                column = Create.Column_OrthophotomapData(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.StructuralSimilarityIndex_AbsoluteDifference);

                Column? column_StructuralSimilarityIndex_AbsoluteDifference = table.UpdateColumn(column);
                if (column_StructuralSimilarityIndex_AbsoluteDifference is not null)
                {
                    tuples_StructuralSimilarityIndex_AbsoluteDifference.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_StructuralSimilarityIndex_AbsoluteDifference));
                }

                column = Create.Column_OrthophotomapData(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.StructuralSimilarityIndex_MatchTemplate);

                Column? column_StructuralSimilarityIndex_MatchTemplate = table.UpdateColumn(column);
                if (column_StructuralSimilarityIndex_MatchTemplate is not null)
                {
                    tuples_StructuralSimilarityIndex_MatchTemplate.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_StructuralSimilarityIndex_MatchTemplate));
                }

                column = Create.Column_OrthophotomapData(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.ColorDistributionShift);

                Column? column_ColorDistributionShift = table.UpdateColumn(column);
                if (column_ColorDistributionShift is not null)
                {
                    tuples_ColorDistributionShift.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_ColorDistributionShift));
                }

                column = Create.Column_OrthophotomapData(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.OpticalFlowAverageMagnitude);

                Column? column_OpticalFlowAverageMagnitude = table.UpdateColumn(column);
                if (column_OpticalFlowAverageMagnitude is not null)
                {
                    tuples_OpticalFlowAverageMagnitude.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_OpticalFlowAverageMagnitude));
                }

                column = Create.Column_OrthophotomapData(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.ORBFeatureMatchingFactor);

                Column? column_ORBFeatureMatchingFactor = table.UpdateColumn(column);
                if (column_ORBFeatureMatchingFactor is not null)
                {
                    tuples_ORBFeatureMatchingFactor.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_ORBFeatureMatchingFactor));
                }
            }

            List<Tuple<Row, OrtoDatasComparison>> tuples_Row = [];

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

                    if (!dictionary.TryGetValue(reference_Row!, out OrtoDatasComparison ortoDatasComparison))
                    {
                        continue;
                    }

                    tuples_Row.Add(new Tuple<Row, OrtoDatasComparison>(row, ortoDatasComparison));
                    dictionary.Remove(reference_Row!);
                }
            }

            foreach (OrtoDatasComparison ortoDatasComparison in dictionary.Values)
            {
                Row row = table.AddRow();

                SetValue(row, column_Reference, ortoDatasComparison.Reference);
                SetValue(row, column_CountyId, countyId);

                tuples_Row.Add(new Tuple<Row, OrtoDatasComparison>(row, ortoDatasComparison));
            }

            foreach (Tuple<Row, OrtoDatasComparison> tuple in tuples_Row)
            {
                Row row = tuple.Item1;
                OrtoDatasComparison ortoDatasComparison = tuple.Item2;

                if (ortoDatasComparison.OrtoDataComparisons is not List<OrtoDataComparison> ortoDataComparisons)
                {
                    continue;
                }

                foreach (OrtoDataComparison ortoDataComparison in ortoDataComparisons)
                {
                    if (ortoDataComparison?.OrtoImageComparisonGroups is not IEnumerable<OrtoImageComparisonGroup> ortoImageComparisonGroups)
                    {
                        continue;
                    }

                    int year_1 = ortoDataComparison.DateTime.Year;

                    foreach (OrtoImageComparisonGroup ortoImageComparisonGroup in ortoImageComparisonGroups)
                    {
                        if (ortoImageComparisonGroup?.OrtoImageComparisons is not IEnumerable<OrtoImageComparison> ortoImageComparisons)
                        {
                            continue;
                        }

                        string name = string.IsNullOrEmpty(ortoImageComparisonGroup.Name) ? string.Empty : ortoImageComparisonGroup.Name!;

                        foreach (OrtoImageComparison ortoImageComparison in ortoImageComparisons)
                        {
                            int year_2 = ortoImageComparison.DateTime.Year;

                            if (tuples_AverageColorSimilarity.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_AverageColorSimilarity)
                            {
                                SetValue(row, column_AverageColorSimilarity, ortoImageComparison.AverageColorSimilarity);
                            }

                            if (tuples_HammingDistance.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_HammingDistance)
                            {
                                SetValue(row, column_HammingDistance, ortoImageComparison.HammingDistance);
                            }

                            if (tuples_GrayHistogramFactor.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_GrayHistogramFactor)
                            {
                                SetValue(row, column_GrayHistogramFactor, ortoImageComparison.GrayHistogramFactor);
                            }

                            if (tuples_HistogramCorrelation.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_HistogramCorrelation)
                            {
                                SetValue(row, column_HistogramCorrelation, ortoImageComparison.HistogramCorrelation);
                            }

                            if (tuples_ShapeComparisonFactor.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_ShapeComparisonFactor)
                            {
                                SetValue(row, column_ShapeComparisonFactor, ortoImageComparison.ShapeComparisonFactor);
                            }

                            if (tuples_StructuralSimilarityIndex_AbsoluteDifference.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_StructuralSimilarityIndex_AbsoluteDifference)
                            {
                                SetValue(row, column_StructuralSimilarityIndex_AbsoluteDifference, ortoImageComparison.StructuralSimilarityIndex_AbsoluteDifference);
                            }

                            if (tuples_StructuralSimilarityIndex_MatchTemplate.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_StructuralSimilarityIndex_MatchTemplate)
                            {
                                SetValue(row, column_StructuralSimilarityIndex_MatchTemplate, ortoImageComparison.StructuralSimilarityIndex_MatchTemplate);
                            }

                            if (tuples_ColorDistributionShift.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_ColorDistributionShift)
                            {
                                SetValue(row, column_ColorDistributionShift, ortoImageComparison.ColorDistributionShift);
                            }

                            if (tuples_OpticalFlowAverageMagnitude.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_OpticalFlowAverageMagnitude)
                            {
                                SetValue(row, column_OpticalFlowAverageMagnitude, ortoImageComparison.OpticalFlowAverageMagnitude);
                            }

                            if (tuples_ORBFeatureMatchingFactor.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_ORBFeatureMatchingFactor)
                            {
                                SetValue(row, column_ORBFeatureMatchingFactor, ortoImageComparison.ORBFeatureMatchingFactor);
                            }
                        }
                    }
                }

                table.AddRow(row, false);
            }
        }
    }
}
