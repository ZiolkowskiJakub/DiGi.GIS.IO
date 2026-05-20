using DiGi.Core;
using DiGi.Core.Classes;
using DiGi.Core.IO.Table.Classes;
using DiGi.Geometry.Planar;
using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Planar.Interfaces;
using DiGi.GIS.Classes;
using DiGi.GIS.Emgu.CV.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.GIS.IO
{
    public static partial class Modify
    {
        public static void Update(this Table? table, int countyId, IEnumerable<Building2D>? building2Ds, IEnumerable<Building2DYearBuiltPredictions>? building2DYearBuiltPredictions, IEnumerable<OrtoDatasComparison>? ortoDatasComparisons)
        {
            if (table is null)
            {
                return;
            }

            if (building2Ds is null || !building2Ds.Any())
            {
                Update_Building2D(table, countyId, building2Ds);
            }

            if (building2DYearBuiltPredictions is null || !building2DYearBuiltPredictions.Any())
            {
                Update_Building2DYearBuiltPredictions(table, countyId, building2DYearBuiltPredictions);
            }

            if (ortoDatasComparisons is null || !ortoDatasComparisons.Any())
            {
                Update_OrtoDatasComparison(table, countyId, ortoDatasComparisons);
            }
        }

        public static void Update_Building2D(this Table? table, int countyId, IEnumerable<Building2D>? building2Ds)
        {
            if (table is null || building2Ds is null || !building2Ds.Any())
            {
                return;
            }

            if (!table.TryGetColumn(Constants.Column.Reference.Name, out Column? column_Reference) || column_Reference is null)
            {
                column_Reference = table.AddColumn(Constants.Column.Reference);
            }

            if (column_Reference is null)
            {
                return;
            }

            if (!table.TryGetColumn(Constants.Column.CountyId.Name, out Column? column_CountyId) || column_CountyId is null)
            {
                column_CountyId = table.AddColumn(Constants.Column.CountyId);
            }

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

            if (!table.TryGetColumn(Constants.Column.BuildingGeneralFunction.Name, out Column? column_BuildingGeneralFunction) || column_BuildingGeneralFunction is null)
            {
                column_BuildingGeneralFunction = table.AddColumn(Constants.Column.BuildingGeneralFunction);
            }

            if (!table.TryGetColumn(Constants.Column.BuildingSpecificFunctions.Name, out Column? column_BuildingSpecificFunctions) || column_BuildingSpecificFunctions is null)
            {
                column_BuildingSpecificFunctions = table.AddColumn(Constants.Column.BuildingSpecificFunctions);
            }

            if (!table.TryGetColumn(Constants.Column.BuildingPhase.Name, out Column? column_BuildingPhase) || column_BuildingPhase is null)
            {
                column_BuildingPhase = table.AddColumn(Constants.Column.BuildingPhase);
            }

            if (!table.TryGetColumn(Constants.Column.Storeys.Name, out Column? column_Storeys) || column_Storeys is null)
            {
                column_Storeys = table.AddColumn(Constants.Column.Storeys);
            }

            if (!table.TryGetColumn(Constants.Column.Area.Name, out Column? column_Area) || column_Area is null)
            {
                column_Area = table.AddColumn(Constants.Column.Area);
            }

            if (!table.TryGetColumn(Constants.Column.InternalPointX.Name, out Column? column_InternalPointX) || column_InternalPointX is null)
            {
                column_InternalPointX = table.AddColumn(Constants.Column.InternalPointX);
            }

            if (!table.TryGetColumn(Constants.Column.InternalPointY.Name, out Column? column_InternalPointY) || column_InternalPointY is null)
            {
                column_InternalPointY = table.AddColumn(Constants.Column.InternalPointY);
            }

            if (!table.TryGetColumn(Constants.Column.BoundingBoxX.Name, out Column? column_BoundingBoxX) || column_BoundingBoxX is null)
            {
                column_BoundingBoxX = table.AddColumn(Constants.Column.BoundingBoxX);
            }

            if (!table.TryGetColumn(Constants.Column.BoundingBoxY.Name, out Column? column_BoundingBoxY) || column_BoundingBoxY is null)
            {
                column_BoundingBoxY = table.AddColumn(Constants.Column.BoundingBoxY);
            }

            if (!table.TryGetColumn(Constants.Column.BoundingBoxWidth.Name, out Column? column_BoundingBoxWidth) || column_BoundingBoxWidth is null)
            {
                column_BoundingBoxWidth = table.AddColumn(Constants.Column.BoundingBoxWidth);
            }

            if (!table.TryGetColumn(Constants.Column.BoundingBoxHeight.Name, out Column? column_BoundingBoxHeight) || column_BoundingBoxHeight is null)
            {
                column_BoundingBoxHeight = table.AddColumn(Constants.Column.BoundingBoxHeight);
            }

            if (!table.TryGetColumn(Constants.Column.CardinalDirection.Name, out Column? column_CardinalDirection) || column_CardinalDirection is null)
            {
                column_CardinalDirection = table.AddColumn(Constants.Column.CardinalDirection);
            }

            if (!table.TryGetColumn(Constants.Column.Azimuth.Name, out Column? column_Azimuth) || column_Azimuth is null)
            {
                column_Azimuth = table.AddColumn(Constants.Column.Azimuth);
            }

            if (!table.TryGetColumn(Constants.Column.IsoperimetricRatio.Name, out Column? column_IsoperimetricRatio) || column_IsoperimetricRatio is null)
            {
                column_IsoperimetricRatio = table.AddColumn(Constants.Column.IsoperimetricRatio);
            }

            if (!table.TryGetColumn(Constants.Column.RectangularThinnessRatio.Name, out Column? column_RectangularThinnessRatio) || column_RectangularThinnessRatio is null)
            {
                column_RectangularThinnessRatio = table.AddColumn(Constants.Column.RectangularThinnessRatio);
            }

            if (!table.TryGetColumn(Constants.Column.SquareThinnessRatio.Name, out Column? column_SquareThinnessRatio) || column_SquareThinnessRatio is null)
            {
                column_SquareThinnessRatio = table.AddColumn(Constants.Column.SquareThinnessRatio);
            }

            if (!table.TryGetColumn(Constants.Column.ThinnessRatio.Name, out Column? column_ThinnessRatio) || column_ThinnessRatio is null)
            {
                column_ThinnessRatio = table.AddColumn(Constants.Column.ThinnessRatio);
            }

            if (!table.TryGetColumn(Constants.Column.ConvexHullThinnessRatio.Name, out Column? column_ConvexHullThinnessRatio) || column_ConvexHullThinnessRatio is null)
            {
                column_ConvexHullThinnessRatio = table.AddColumn(Constants.Column.ConvexHullThinnessRatio);
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

                if (column_Reference.TryGetValidValue(building2D.Reference, out object? value))
                {
                    row[column_Reference.Index] = value;
                }

                if (column_Reference.TryGetValidValue(countyId, out value))
                {
                    row[column_CountyId.Index] = value;
                }

                tuples.Add(new Tuple<Row, Building2D>(row, building2D));
            }

            foreach (Tuple<Row, Building2D> tuple in tuples)
            {
                Row row = tuple.Item1;
                Building2D building2D = tuple.Item2;

                object? value = null;

                if (column_BuildingGeneralFunction is not null && column_BuildingGeneralFunction.TryGetValidValue(building2D.BuildingGeneralFunction.Description(), out value))
                {
                    row[column_BuildingGeneralFunction.Index] = value;
                }

                if (column_BuildingSpecificFunctions is not null && column_BuildingSpecificFunctions.TryGetValidValue(building2D.BuildingSpecificFunctions?.ToList().ConvertAll(x => x.Description()), out value))
                {
                    row[column_BuildingSpecificFunctions.Index] = value;
                }

                if (column_BuildingPhase is not null && column_BuildingPhase.TryGetValidValue(building2D.BuildingPhase?.Description(), out value))
                {
                    row[column_BuildingPhase.Index] = value;
                }

                if (column_Storeys is not null && column_Storeys.TryGetValidValue(building2D.Storeys, out value))
                {
                    row[column_Storeys.Index] = value;
                }

                double azimuth = building2D.Azimuth();

                if (column_Azimuth is not null && column_Azimuth.TryGetValidValue(azimuth, out value))
                {
                    row[column_Azimuth.Index] = value;
                }

                if (column_CardinalDirection is not null && column_CardinalDirection.TryGetValidValue(Query.CardinalDirection(azimuth), out value))
                {
                    row[column_CardinalDirection.Index] = value;
                }

                PolygonalFace2D? polygonalFace2D = building2D.PolygonalFace2D;
                if (polygonalFace2D is not null)
                {
                    if (column_Area is not null && column_Area.TryGetValidValue(polygonalFace2D.GetArea(), out value))
                    {
                        row[column_Area.Index] = value;
                    }

                    if (polygonalFace2D.GetInternalPoint() is Point2D internalPoint)
                    {
                        if (column_InternalPointX is not null && column_InternalPointX.TryGetValidValue(internalPoint.X, out value))
                        {
                            row[column_InternalPointX.Index] = value;
                        }

                        if (column_InternalPointY is not null && column_InternalPointY.TryGetValidValue(internalPoint.Y, out value))
                        {
                            row[column_InternalPointY.Index] = value;
                        }
                    }

                    BoundingBox2D? boundingBox2D = polygonalFace2D.GetBoundingBox();

                    if (boundingBox2D?.GetCentroid() is Point2D centroid)
                    {
                        if (column_BoundingBoxX is not null && column_BoundingBoxX.TryGetValidValue(centroid.X, out value))
                        {
                            row[column_BoundingBoxX.Index] = value;
                        }

                        if (column_BoundingBoxY is not null && column_BoundingBoxY.TryGetValidValue(centroid.Y, out value))
                        {
                            row[column_BoundingBoxY.Index] = value;
                        }

                        if (column_BoundingBoxWidth is not null && column_BoundingBoxWidth.TryGetValidValue(boundingBox2D.Width, out value))
                        {
                            row[column_BoundingBoxWidth.Index] = value;
                        }

                        if (column_BoundingBoxHeight is not null && column_BoundingBoxHeight.TryGetValidValue(boundingBox2D.Height, out value))
                        {
                            row[column_BoundingBoxHeight.Index] = value;
                        }
                    }

                    IPolygonal2D? externalEdge = polygonalFace2D.ExternalEdge;
                    if(externalEdge is not null)
                    {
                        double area = externalEdge.GetArea();
                        double perimeter = externalEdge.GetPerimeter();

                        double isoperimetricRatio = Geometry.Core.Query.IsoperimetricRatio(area, perimeter);
                        if(!double.IsNaN(isoperimetricRatio))
                        {
                            if (column_IsoperimetricRatio is not null && column_IsoperimetricRatio.TryGetValidValue(isoperimetricRatio, out value))
                            {
                                row[column_IsoperimetricRatio.Index] = value;
                            }
                        }

                        double thinnessRatio = externalEdge.ThinnessRatio();

                        if (column_ThinnessRatio is not null && column_ThinnessRatio.TryGetValidValue(thinnessRatio, out value))
                        {
                            row[column_ThinnessRatio.Index] = value;
                        }

                        if (Geometry.Planar.Create.Rectangle2D(externalEdge) is Rectangle2D rectangle2D)
                        {
                            double rectangleArea = rectangle2D.GetArea();

                            double rectangleThinnesRatio = Geometry.Core.Query.RectangularThinnessRatio(area, rectangleArea);

                            double length = Math.Max(rectangle2D.Width, rectangle2D.Height);

                            double squareThinnesRatio = Geometry.Core.Query.SquareThinnessRatio(area, length * length);

                            if (column_RectangularThinnessRatio is not null && column_RectangularThinnessRatio.TryGetValidValue(rectangleThinnesRatio, out value))
                            {
                                row[column_RectangularThinnessRatio.Index] = value;
                            }

                            if (column_SquareThinnessRatio is not null && column_SquareThinnessRatio.TryGetValidValue(squareThinnesRatio, out value))
                            {
                                row[column_SquareThinnessRatio.Index] = value;
                            }
                        }

                        List<Point2D>? point2Ds = externalEdge.ConvexHull();
                        if(point2Ds is not null)
                        {
                            double convexHullArea = Geometry.Planar.Query.Area(point2Ds);
                            if(!double.IsNaN(convexHullArea) && convexHullArea > 0)
                            {
                                double convexHullThinnesRatio = Geometry.Core.Query.RectangularThinnessRatio(area, convexHullArea);

                                if (column_ConvexHullThinnessRatio is not null && column_ConvexHullThinnessRatio.TryGetValidValue(convexHullThinnesRatio, out value))
                                {
                                    row[column_ConvexHullThinnessRatio.Index] = value;
                                }
                            }
                        }
                    }
                }

                table.AddRow(row, false);
            }
        }

        public static void Update_Building2DYearBuiltPredictions(this Table? table, int countyId, IEnumerable<Building2DYearBuiltPredictions>? building2DYearBuiltPredictions)
        {
            if(table is null || building2DYearBuiltPredictions is null || !building2DYearBuiltPredictions.Any())
            {
                return;
            }

            if (!table.TryGetColumn(Constants.Column.Reference.Name, out Column? column_Reference) || column_Reference is null)
            {
                column_Reference = table.AddColumn(Constants.Column.Reference);
            }

            if (column_Reference is null)
            {
                return;
            }

            if (!table.TryGetColumn(Constants.Column.CountyId.Name, out Column? column_CountyId) || column_CountyId is null)
            {
                column_CountyId = table.AddColumn(Constants.Column.CountyId);
            }

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
                Column column;

                column = Create.Column_YearBuit(Constants.ColumnNamePrefix.PredictionConfidence, year);

                if (!table.TryGetColumn(column.Name, out Column? column_PredictionConfidence) || column_PredictionConfidence is null)
                {
                    column_PredictionConfidence = table.AddColumn(column);
                }

                if(column_PredictionConfidence is not null)
                {
                    dictionary_PredictionConfidence[year] = column_PredictionConfidence;
                }

                column = Create.Column_YearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxX, year);

                if (!table.TryGetColumn(column.Name, out Column? column_PredictionBoundingBoxX) || column_PredictionBoundingBoxX is null)
                {
                    column_PredictionBoundingBoxX = table.AddColumn(column);
                }

                if (column_PredictionBoundingBoxX is not null)
                {
                    dictionary_PredictionBoundingBoxX[year] = column_PredictionBoundingBoxX;
                }

                column = Create.Column_YearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxY, year);

                if (!table.TryGetColumn(column.Name, out Column? column_PredictionBoundingBoxY) || column_PredictionBoundingBoxY is null)
                {
                    column_PredictionBoundingBoxY = table.AddColumn(column);
                }

                if (column_PredictionBoundingBoxY is not null)
                {
                    dictionary_PredictionBoundingBoxY[year] = column_PredictionBoundingBoxY;
                }

                column = Create.Column_YearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxWidth, year);

                if (!table.TryGetColumn(column.Name, out Column? column_PredictionBoundingBoxWidth) || column_PredictionBoundingBoxWidth is null)
                {
                    column_PredictionBoundingBoxWidth = table.AddColumn(column);
                }

                if (column_PredictionBoundingBoxWidth is not null)
                {
                    dictionary_PredictionBoundingBoxWidth[year] = column_PredictionBoundingBoxWidth;
                }

                column = Create.Column_YearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxHeight, year);

                if (!table.TryGetColumn(column.Name, out Column? column_PredictionBoundingBoxHeight) || column_PredictionBoundingBoxHeight is null)
                {
                    column_PredictionBoundingBoxHeight = table.AddColumn(column);
                }

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

                if (column_Reference.TryGetValidValue(building2DYearBuiltPredictions_Temp.Reference, out object? value))
                {
                    row[column_Reference.Index] = value;
                }

                if (column_Reference.TryGetValidValue(countyId, out value))
                {
                    row[column_CountyId.Index] = value;
                }

                tuples.Add(new Tuple<Row, Building2DYearBuiltPredictions>(row, building2DYearBuiltPredictions_Temp));
            }

            foreach (Tuple<Row, Building2DYearBuiltPredictions> tuple in tuples)
            {
                Row row = tuple.Item1;
                Building2DYearBuiltPredictions building2DYearBuiltPredictions_Temp = tuple.Item2;

                if(building2DYearBuiltPredictions_Temp.Years is not List<ushort> years_Temp)
                {
                    continue;
                }

                foreach(ushort year in building2DYearBuiltPredictions_Temp.Years)
                {
                    YearBuiltPrediction? yearBuiltPrediction = building2DYearBuiltPredictions_Temp[year];
                    if(yearBuiltPrediction is null)
                    {
                        continue;
                    }


                    if (dictionary_PredictionConfidence.TryGetValue(year, out Column column) && column is not null && column.TryGetValidValue(yearBuiltPrediction.Confidence, out object? value))
                    {
                        row[column.Index] = value;
                    }

                    if (yearBuiltPrediction.BoundingBox is BoundingBox2D boundingBox2D && boundingBox2D.GetCentroid() is Point2D centroid)
                    {
                        if (dictionary_PredictionBoundingBoxX.TryGetValue(year, out column) && column is not null && column.TryGetValidValue(centroid.X, out value))
                        {
                            row[column.Index] = value;
                        }

                        if (dictionary_PredictionBoundingBoxY.TryGetValue(year, out column) && column is not null && column.TryGetValidValue(centroid.Y, out value))
                        {
                            row[column.Index] = value;
                        }

                        if (dictionary_PredictionBoundingBoxWidth.TryGetValue(year, out column) && column is not null && column.TryGetValidValue(boundingBox2D.Width, out value))
                        {
                            row[column.Index] = value;
                        }

                        if (dictionary_PredictionBoundingBoxHeight.TryGetValue(year, out column) && column is not null && column.TryGetValidValue(boundingBox2D.Height, out value))
                        {
                            row[column.Index] = value;
                        }
                    }
                }

                table.AddRow(row, false);
            }
        }

        public static void Update_OrtoDatasComparison(this Table? table, int countyId, IEnumerable<OrtoDatasComparison>? ortoDatasComparisons)
        {
            if (table is null || ortoDatasComparisons is null || !ortoDatasComparisons.Any())
            {
                return;
            }

            if (!table.TryGetColumn(Constants.Column.Reference.Name, out Column? column_Reference) || column_Reference is null)
            {
                column_Reference = table.AddColumn(Constants.Column.Reference);
            }

            if (column_Reference is null)
            {
                return;
            }

            if (!table.TryGetColumn(Constants.Column.CountyId.Name, out Column? column_CountyId) || column_CountyId is null)
            {
                column_CountyId = table.AddColumn(Constants.Column.CountyId);
            }

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
                if(ortoDataComparisons is null || !ortoDataComparisons.Any())
                {
                    continue;
                }

                foreach(OrtoDataComparison ortoDataComparison in ortoDataComparisons)
                {
                    int year_1 = ortoDataComparison.DateTime.Year;

                    IEnumerable< OrtoImageComparisonGroup>? ortoImageComparisonGroups =  ortoDataComparison.OrtoImageComparisonGroups;
                    if(ortoImageComparisonGroups is not null && ortoImageComparisonGroups.Any())
                    {
                        foreach(OrtoImageComparisonGroup ortoImageComparisonGroup in ortoImageComparisonGroups)
                        {
                            if(ortoImageComparisonGroup is null)
                            {
                                continue;
                            }

                            string name = string.IsNullOrEmpty(ortoImageComparisonGroup.Name) ? string.Empty : ortoImageComparisonGroup.Name!;

                            if(ortoImageComparisonGroup.OrtoImageComparisons is IEnumerable<OrtoImageComparison> ortoImageComparisons)
                            {
                                foreach (OrtoImageComparison ortoImageComparison in ortoImageComparisons)
                                {
                                    int year_2 = ortoImageComparison.DateTime.Year;

                                    if(tuples.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2) != null)
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

                column = Create.Column_Orthophotomap(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.AverageColorSimilarity);

                if (!table.TryGetColumn(column.Name, out Column? column_AverageColorSimilarity) || column_AverageColorSimilarity is null)
                {
                    column_AverageColorSimilarity = table.AddColumn(column);
                }

                if (column_AverageColorSimilarity is not null)
                {
                    tuples_AverageColorSimilarity.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_AverageColorSimilarity));
                }

                column = Create.Column_Orthophotomap(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.HammingDistance);

                if (!table.TryGetColumn(column.Name, out Column? column_HammingDistance) || column_HammingDistance is null)
                {
                    column_HammingDistance = table.AddColumn(column);
                }

                if (column_HammingDistance is not null)
                {
                    tuples_HammingDistance.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_HammingDistance));
                }

                column = Create.Column_Orthophotomap(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.GrayHistogramFactor);

                if (!table.TryGetColumn(column.Name, out Column? column_GrayHistogramFactor) || column_GrayHistogramFactor is null)
                {
                    column_GrayHistogramFactor = table.AddColumn(column);
                }

                if (column_GrayHistogramFactor is not null)
                {
                    tuples_GrayHistogramFactor.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_GrayHistogramFactor));
                }

                column = Create.Column_Orthophotomap(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.ShapeComparisonFactor);

                if (!table.TryGetColumn(column.Name, out Column? column_ShapeComparisonFactor) || column_ShapeComparisonFactor is null)
                {
                    column_ShapeComparisonFactor = table.AddColumn(column);
                }

                if (column_ShapeComparisonFactor is not null)
                {
                    tuples_ShapeComparisonFactor.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_ShapeComparisonFactor));
                }

                column = Create.Column_Orthophotomap(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.StructuralSimilarityIndex_AbsoluteDifference);

                if (!table.TryGetColumn(column.Name, out Column? column_StructuralSimilarityIndex_AbsoluteDifference) || column_StructuralSimilarityIndex_AbsoluteDifference is null)
                {
                    column_StructuralSimilarityIndex_AbsoluteDifference = table.AddColumn(column);
                }

                if (column_StructuralSimilarityIndex_AbsoluteDifference is not null)
                {
                    tuples_StructuralSimilarityIndex_AbsoluteDifference.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_StructuralSimilarityIndex_AbsoluteDifference));
                }

                column = Create.Column_Orthophotomap(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.StructuralSimilarityIndex_MatchTemplate);

                if (!table.TryGetColumn(column.Name, out Column? column_StructuralSimilarityIndex_MatchTemplate) || column_StructuralSimilarityIndex_MatchTemplate is null)
                {
                    column_StructuralSimilarityIndex_MatchTemplate = table.AddColumn(column);
                }

                if (column_StructuralSimilarityIndex_MatchTemplate is not null)
                {
                    tuples_StructuralSimilarityIndex_MatchTemplate.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_StructuralSimilarityIndex_MatchTemplate));
                }

                column = Create.Column_Orthophotomap(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.ColorDistributionShift);

                if (!table.TryGetColumn(column.Name, out Column? column_ColorDistributionShift) || column_ColorDistributionShift is null)
                {
                    column_ColorDistributionShift = table.AddColumn(column);
                }

                if (column_ColorDistributionShift is not null)
                {
                    tuples_ColorDistributionShift.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_ColorDistributionShift));
                }

                column = Create.Column_Orthophotomap(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.OpticalFlowAverageMagnitude);

                if (!table.TryGetColumn(column.Name, out Column? column_OpticalFlowAverageMagnitude) || column_OpticalFlowAverageMagnitude is null)
                {
                    column_OpticalFlowAverageMagnitude = table.AddColumn(column);
                }

                if (column_OpticalFlowAverageMagnitude is not null)
                {
                    tuples_OpticalFlowAverageMagnitude.Add(new Tuple<string, int, int, Column>(tuple.Item1, tuple.Item2, tuple.Item3, column_OpticalFlowAverageMagnitude));
                }

                column = Create.Column_Orthophotomap(tuple.Item2, tuple.Item3, tuple.Item1, Constants.ColumnNameSuffix.ORBFeatureMatchingFactor);

                if (!table.TryGetColumn(column.Name, out Column? column_ORBFeatureMatchingFactor) || column_ORBFeatureMatchingFactor is null)
                {
                    column_ORBFeatureMatchingFactor = table.AddColumn(column);
                }

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

                if (column_Reference.TryGetValidValue(ortoDatasComparison.Reference, out object? value))
                {
                    row[column_Reference.Index] = value;
                }

                if (column_Reference.TryGetValidValue(countyId, out value))
                {
                    row[column_CountyId.Index] = value;
                }

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

                foreach(OrtoDataComparison ortoDataComparison in ortoDataComparisons)
                {
                    if(ortoDataComparison?.OrtoImageComparisonGroups is not IEnumerable<OrtoImageComparisonGroup> ortoImageComparisonGroups)
                    {
                        continue;
                    }

                    int year_1 = ortoDataComparison.DateTime.Year;

                    foreach (OrtoImageComparisonGroup ortoImageComparisonGroup in ortoImageComparisonGroups)
                    {
                        if(ortoImageComparisonGroup?.OrtoImageComparisons is not IEnumerable<OrtoImageComparison> ortoImageComparisons)
                        {
                            continue;
                        }

                        string name = string.IsNullOrEmpty(ortoImageComparisonGroup.Name) ? string.Empty : ortoImageComparisonGroup.Name!;

                        foreach (OrtoImageComparison ortoImageComparison in ortoImageComparisons)
                        {
                            int year_2 = ortoImageComparison.DateTime.Year;

                            object? value;

                            if (tuples_AverageColorSimilarity.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_AverageColorSimilarity && column_AverageColorSimilarity.TryGetValidValue(ortoImageComparison.AverageColorSimilarity, out value))
                            {
                                row[column_AverageColorSimilarity.Index] = value;
                            }

                            if (tuples_HammingDistance.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_HammingDistance && column_HammingDistance.TryGetValidValue(ortoImageComparison.HammingDistance, out value))
                            {
                                row[column_HammingDistance.Index] = value;
                            }

                            if (tuples_GrayHistogramFactor.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_GrayHistogramFactor && column_GrayHistogramFactor.TryGetValidValue(ortoImageComparison.GrayHistogramFactor, out value))
                            {
                                row[column_GrayHistogramFactor.Index] = value;
                            }

                            if (tuples_HistogramCorrelation.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_HistogramCorrelation && column_HistogramCorrelation.TryGetValidValue(ortoImageComparison.HistogramCorrelation, out value))
                            {
                                row[column_HistogramCorrelation.Index] = value;
                            }

                            if (tuples_ShapeComparisonFactor.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_ShapeComparisonFactor && column_ShapeComparisonFactor.TryGetValidValue(ortoImageComparison.ShapeComparisonFactor, out value))
                            {
                                row[column_ShapeComparisonFactor.Index] = value;
                            }

                            if (tuples_StructuralSimilarityIndex_AbsoluteDifference.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_StructuralSimilarityIndex_AbsoluteDifference && column_StructuralSimilarityIndex_AbsoluteDifference.TryGetValidValue(ortoImageComparison.StructuralSimilarityIndex_AbsoluteDifference, out value))
                            {
                                row[column_StructuralSimilarityIndex_AbsoluteDifference.Index] = value;
                            }

                            if (tuples_StructuralSimilarityIndex_MatchTemplate.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_StructuralSimilarityIndex_MatchTemplate && column_StructuralSimilarityIndex_MatchTemplate.TryGetValidValue(ortoImageComparison.StructuralSimilarityIndex_MatchTemplate, out value))
                            {
                                row[column_StructuralSimilarityIndex_MatchTemplate.Index] = value;
                            }

                            if (tuples_ColorDistributionShift.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_ColorDistributionShift && column_ColorDistributionShift.TryGetValidValue(ortoImageComparison.ColorDistributionShift, out value))
                            {
                                row[column_ColorDistributionShift.Index] = value;
                            }

                            if (tuples_OpticalFlowAverageMagnitude.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_OpticalFlowAverageMagnitude && column_OpticalFlowAverageMagnitude.TryGetValidValue(ortoImageComparison.OpticalFlowAverageMagnitude, out value))
                            {
                                row[column_OpticalFlowAverageMagnitude.Index] = value;
                            }

                            if (tuples_ORBFeatureMatchingFactor.Find(x => x.Item1 == name && x.Item2 == year_1 && x.Item3 == year_2)?.Item4 is Column column_ORBFeatureMatchingFactor && column_ORBFeatureMatchingFactor.TryGetValidValue(ortoImageComparison.ORBFeatureMatchingFactor, out value))
                            {
                                row[column_ORBFeatureMatchingFactor.Index] = value;
                            }
                        }
                    }
                }

                table.AddRow(row, false);
            }
        }
    }
}
