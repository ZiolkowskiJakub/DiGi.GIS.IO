using DiGi.Core;
using DiGi.Core.IO.Table.Classes;
using DiGi.Geometry.Planar;
using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Planar.Interfaces;
using DiGi.GIS.Classes;
using DiGi.GIS.Emgu.CV.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.GIS.IO
{
    public static partial class Modify
    {
        /// <summary>
        /// Updates the table with building data, year built predictions, orthophotomap comparisons, and administrative boundaries.
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="subdivisionId">The optional unique identifier of the subdivision.</param>
        /// <param name="building2Ds">The collection of building 2D geometries to update.</param>
        /// <param name="building2DYearBuiltPredictions">The optional collection of year built predictions to update.</param>
        /// <param name="ortoDatasComparisons">The optional collection of orthophotomap data comparisons to update.</param>
        /// <param name="administrativeAreal2Ds">The optional collection of administrative boundary areas to update.</param>
        public static void Update(this Table? table, int countyId, int? subdivisionId, IEnumerable<Building2D>? building2Ds, IEnumerable<Building2DYearBuiltPredictions>? building2DYearBuiltPredictions = null, IEnumerable<OrtoDatasComparison>? ortoDatasComparisons = null, IEnumerable<AdministrativeAreal2D>? administrativeAreal2Ds = null)
        {
            if (table is null)
            {
                return;
            }

            if (building2Ds is not null && building2Ds.Any())
            {
                Update_Building2D(table, countyId, building2Ds);
                Update_Building2D(table, countyId, subdivisionId, building2Ds, administrativeAreal2Ds);
            }

            if (building2DYearBuiltPredictions is not null && building2DYearBuiltPredictions.Any())
            {
                Update_Building2D_YearBuiltPredictions(table, countyId, building2DYearBuiltPredictions);
            }

            if (ortoDatasComparisons is not null && ortoDatasComparisons.Any())
            {
                Update_OrtoDatasComparison(table, countyId, ortoDatasComparisons);
            }
        }

        /// <summary>
        /// Updates the table with building 2D geometric and shape descriptor features for a specific county.
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="building2Ds">The collection of building 2D geometries.</param>
        public static void Update_Building2D(this Table? table, int countyId, IEnumerable<Building2D>? building2Ds)
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

            Column? column_BuildingGeneralFunction = table.UpdateColumn<Column>(Constants.Column.BuildingGeneralFunction);
            Column? column_BuildingSpecificFunctions = table.UpdateColumn<Column>(Constants.Column.BuildingSpecificFunctions);
            Column? column_BuildingPhase = table.UpdateColumn<Column>(Constants.Column.BuildingPhase);
            Column? column_Storeys = table.UpdateColumn<Column>(Constants.Column.Storeys);
            Column? column_FloorArea = table.UpdateColumn<Column>(Constants.Column.FloorArea);
            Column? column_TotalArea = table.UpdateColumn<Column>(Constants.Column.TotalArea);
            Column? column_InternalPointX = table.UpdateColumn<Column>(Constants.Column.InternalPointX);
            Column? column_InternalPointY = table.UpdateColumn<Column>(Constants.Column.InternalPointY);
            Column? column_BoundingBoxX = table.UpdateColumn<Column>(Constants.Column.BoundingBoxX);
            Column? column_BoundingBoxY = table.UpdateColumn<Column>(Constants.Column.BoundingBoxY);
            Column? column_BoundingBoxWidth = table.UpdateColumn<Column>(Constants.Column.BoundingBoxWidth);
            Column? column_BoundingBoxHeight = table.UpdateColumn<Column>(Constants.Column.BoundingBoxHeight);
            Column? column_CardinalDirection = table.UpdateColumn<Column>(Constants.Column.CardinalDirection);
            Column? column_Azimuth = table.UpdateColumn<Column>(Constants.Column.Azimuth);
            Column? column_IsoperimetricRatio = table.UpdateColumn<Column>(Constants.Column.IsoperimetricRatio);
            Column? column_RectangularThinnessRatio = table.UpdateColumn<Column>(Constants.Column.RectangularThinnessRatio);
            Column? column_SquareThinnessRatio = table.UpdateColumn<Column>(Constants.Column.SquareThinnessRatio);
            Column? column_ThinnessRatio = table.UpdateColumn<Column>(Constants.Column.ThinnessRatio);
            Column? column_ConvexHullThinnessRatio = table.UpdateColumn<Column>(Constants.Column.ConvexHullThinnessRatio);
            Column? column_CalculatedBuildingShape = table.UpdateColumn<Column>(Constants.Column.CalculatedBuildingShape);
            Column? column_IsOccupied = table.UpdateColumn<Column>(Constants.Column.IsOccupied);
            Column? column_IsResidential = table.UpdateColumn<Column>(Constants.Column.IsResidential);

            List<Tuple<short, Column>> tuples_OrthophotomapImage = [];
            for(short i = 2008; i <= DateTime.Now.Year; i++)
            {
                Column? column_Existing = table.UpdateColumn(Create.Column_OrthophotomapImage(i));

                if (column_Existing is not null)
                {
                    tuples_OrthophotomapImage.Add(new Tuple<short, Column>(i, column_Existing));
                }
            }

            List<Tuple<int, int, Column>> tuples_GridCellCoverage = [];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Column? column_Existing = table.UpdateColumn(Create.Column_GridCellCoverage(i, j));

                    if (column_Existing is not null)
                    {
                        tuples_GridCellCoverage.Add(new Tuple<int, int, Column>(i, j, column_Existing));
                    }
                }
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

            BuildingShapeSolver buildingShapeSolver = new();

            foreach (Tuple<Row, Building2D> tuple in tuples)
            {
                Row row = tuple.Item1;
                Building2D building2D = tuple.Item2;

                ushort storeys = building2D.Storeys;
                double azimuth = building2D.Azimuth();

                SetValue(row, column_BuildingGeneralFunction, building2D.BuildingGeneralFunction.Description());
                SetValue(row, column_BuildingSpecificFunctions, string.Join(", ", building2D.BuildingSpecificFunctions?.ToList().ConvertAll(x => x.Description())) ?? null);
                SetValue(row, column_BuildingPhase, building2D.BuildingPhase?.Description());
                SetValue(row, column_Storeys, storeys);
                SetValue(row, column_Azimuth, azimuth);
                SetValue(row, column_CardinalDirection, Query.CardinalDirection(azimuth));
                SetValue(row, column_IsOccupied, Query.IsOccupied(building2D));
                SetValue(row, column_IsResidential, Query.IsResidential(building2D));

                PolygonalFace2D? polygonalFace2D = building2D.PolygonalFace2D;
                if (polygonalFace2D is not null)
                {
                    double area = polygonalFace2D.GetArea();

                    if (!double.IsNaN(area))
                    {
                        SetValue(row, column_FloorArea, area);
                        SetValue(row, column_TotalArea, area * storeys);
                    }

                    if (polygonalFace2D.GetInternalPoint() is Point2D internalPoint)
                    {
                        SetValue(row, column_InternalPointX, internalPoint.X);
                        SetValue(row, column_InternalPointY, internalPoint.Y);
                    }

                    BoundingBox2D? boundingBox2D = polygonalFace2D.GetBoundingBox();

                    if (boundingBox2D?.GetCentroid() is Point2D centroid)
                    {
                        SetValue(row, column_BoundingBoxX, centroid.X);
                        SetValue(row, column_BoundingBoxY, centroid.Y);
                        SetValue(row, column_BoundingBoxWidth, boundingBox2D.Width);
                        SetValue(row, column_BoundingBoxHeight, boundingBox2D.Height);
                    }

                    IPolygonal2D? externalEdge = polygonalFace2D.ExternalEdge;
                    if (externalEdge is not null)
                    {
                        double externalEdgeArea = externalEdge.GetArea();
                        double perimeter = externalEdge.GetPerimeter();

                        double isoperimetricRatio = Geometry.Core.Query.IsoperimetricRatio(externalEdgeArea, perimeter);
                        if (!double.IsNaN(isoperimetricRatio))
                        {
                            SetValue(row, column_IsoperimetricRatio, isoperimetricRatio);
                        }

                        double thinnessRatio = externalEdge.ThinnessRatio();

                        SetValue(row, column_ThinnessRatio, thinnessRatio);

                        if (Geometry.Planar.Create.Rectangle2D(externalEdge) is Rectangle2D rectangle2D)
                        {
                            double rectangleArea = rectangle2D.GetArea();

                            double rectangleThinnesRatio = Geometry.Core.Query.RectangularThinnessRatio(externalEdgeArea, rectangleArea);

                            double length = Math.Max(rectangle2D.Width, rectangle2D.Height);

                            double squareThinnesRatio = Geometry.Core.Query.SquareThinnessRatio(externalEdgeArea, length * length);

                            SetValue(row, column_RectangularThinnessRatio, rectangleThinnesRatio);
                            SetValue(row, column_SquareThinnessRatio, squareThinnesRatio);

                            Grid2D grid2D = new(rectangle2D, 5, 5);
                            if (grid2D is not null)
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    for (int j = 0; j < 5; j++)
                                    {
                                        Column? column = tuples_GridCellCoverage.Find(x => x.Item1 == i && x.Item2 == j)?.Item3;
                                        if (column is null)
                                        {
                                            continue;
                                        }

                                        Rectangle2D? rectangle2D_Grid = grid2D.GetRectangle(i, j);
                                        if (rectangle2D_Grid is null)
                                        {
                                            continue;
                                        }

                                        double area_Grid = rectangle2D_Grid.GetArea();
                                        if (double.IsNaN(area_Grid))
                                        {
                                            continue;
                                        }

                                        double factor = 0;

                                        List<Polygon2D>? polygon2Ds = Geometry.Planar.Query.Intersection<Polygon2D, IPolygonal2D>([rectangle2D_Grid, externalEdge]);
                                        if (polygon2Ds is not null && polygon2Ds.Count != 0)
                                        {
                                            double area_Intersection = polygon2Ds.ConvertAll(x => x.GetArea()).Sum();

                                            factor = Core.Query.Clamp(area_Intersection / area_Grid, 0, 1);
                                        }

                                        SetValue(row, column, factor);
                                    }
                                }
                            }
                        }

                        List<Point2D>? point2Ds = externalEdge.ConvexHull();
                        if (point2Ds is not null)
                        {
                            double convexHullArea = Geometry.Planar.Query.Area(point2Ds);
                            if (!double.IsNaN(convexHullArea) && convexHullArea > 0)
                            {
                                double convexHullThinnesRatio = Geometry.Core.Query.RectangularThinnessRatio(area, convexHullArea);

                                SetValue(row, column_ConvexHullThinnessRatio, convexHullThinnesRatio);
                            }
                        }
                    }
                }

                buildingShapeSolver.Input = building2D;
                if (buildingShapeSolver.Solve())
                {
                    string? buildingShapeText = buildingShapeSolver.Output.Description();
                    if (!string.IsNullOrWhiteSpace(buildingShapeText))
                    {
                        SetValue(row, column_CalculatedBuildingShape, buildingShapeText);
                    }
                }

                foreach (Tuple<short, Column> tuple_OrthophotomapImage in tuples_OrthophotomapImage)
                {
                    SetValue(row, tuple_OrthophotomapImage.Item2, $"https://api.digiproject.uk/gis/ortodatas/imagebyreference?reference={building2D.Reference}&year={tuple_OrthophotomapImage.Item1}&countyId={countyId}");
                }

                table.AddRow(row, false);
            }
        }

        /// <summary>
        /// Updates the table with building 2D geometric and administrative features for a specific county and optional subdivision.
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="subdivisionId">The optional unique identifier of the subdivision.</param>
        /// <param name="building2Ds">The collection of building 2D geometries.</param>
        /// <param name="administrativeAreal2Ds">The collection of administrative boundary areas.</param>
        public static void Update_Building2D(this Table? table, int countyId, int? subdivisionId, IEnumerable<Building2D>? building2Ds, IEnumerable<AdministrativeAreal2D>? administrativeAreal2Ds)
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

            Column? column_SubdivisionId = table.UpdateColumn<Column>(Constants.Column.SubdivisionId);
            Column? column_CountyName = table.UpdateColumn<Column>(Constants.Column.CountyName);
            Column? column_MunicipalityName = table.UpdateColumn<Column>(Constants.Column.MunicipalityName);
            Column? column_SubdivisionOccupancy = table.UpdateColumn<Column>(Constants.Column.SubdivisionOccupancy);
            Column? column_SubdivisionName = table.UpdateColumn<Column>(Constants.Column.SubdivisionName);
            Column? column_VoivodeshipName = table.UpdateColumn<Column>(Constants.Column.VoivodeshipName);
            Column? column_SettlementType = table.UpdateColumn<Column>(Constants.Column.SettlementType);

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

                if (column_CountyId.TryGetValidValue(countyId, out value))
                {
                    row[column_CountyId.Index] = value;
                }

                tuples.Add(new Tuple<Row, Building2D>(row, building2D));
            }

            List<AdministrativeDivision> administrativeDivisions = [];
            List<AdministrativeSubdivision> administrativeSubdivisions = [];

            if (administrativeAreal2Ds is not null && administrativeAreal2Ds.Any())
            {
                foreach (AdministrativeAreal2D administrativeAreal2D in administrativeAreal2Ds)
                {
                    if (administrativeAreal2D is AdministrativeDivision administrativeDivision)
                    {
                        administrativeDivisions.Add(administrativeDivision);
                    }
                    else if (administrativeAreal2D is AdministrativeSubdivision administrativeSubdivision)
                    {
                        administrativeSubdivisions.Add(administrativeSubdivision);
                    }
                }
            }

            foreach (Tuple<Row, Building2D> tuple in tuples)
            {
                Row row = tuple.Item1;
                Building2D building2D = tuple.Item2;

                object? value = null;

                if (column_SubdivisionId is not null && column_SubdivisionId.TryGetValidValue(subdivisionId, out value))
                {
                    row[column_SubdivisionId.Index] = value;
                }

                if (administrativeDivisions is not null && administrativeDivisions.Any())
                {
                    AdministrativeDivision administrativeDivision_County = administrativeDivisions.Find(x => x.AdministrativeDivisionType == GIS.Enums.AdministrativeDivisionType.county);
                    if (administrativeDivision_County is not null)
                    {
                        SetValue(row, column_CountyName, administrativeDivision_County.Name);
                    }

                    AdministrativeDivision administrativeDivision_Voivodeship = administrativeDivisions.Find(x => x.AdministrativeDivisionType == GIS.Enums.AdministrativeDivisionType.voivodeship);
                    if (administrativeDivision_Voivodeship is not null)
                    {
                        SetValue(row, column_VoivodeshipName, administrativeDivision_Voivodeship.Name);
                    }

                    AdministrativeDivision administrativeDivision_Municipality = administrativeDivisions.Find(x => x.AdministrativeDivisionType == GIS.Enums.AdministrativeDivisionType.municipality);
                    if (administrativeDivision_Municipality is not null)
                    {
                        SetValue(row, column_MunicipalityName, administrativeDivision_Municipality.Name);
                    }

                    if (administrativeSubdivisions.Count > 0)
                    {
                        AdministrativeSubdivision administrativeSubdivision = administrativeSubdivisions[0];

                        SetValue(row, column_SubdivisionName, administrativeSubdivision.Name);

                        if (administrativeSubdivision.Occupancy is uint occupancy)
                        {
                            SetValue(row, column_SubdivisionOccupancy, occupancy);
                        }

                        SetValue(row, column_SettlementType, administrativeSubdivision.AdministrativeSubdivisionType.SettlementType().Description());
                    }
                }

                table.AddRow(row, false);
            }
        }

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

                SetValue(row, column_IsOccupied, Query.IsOccupied(building2D));
                SetValue(row, column_IsResidential, Query.IsResidential(building2D));

                table.AddRow(row, false);
            }
        }
        
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
                Column column;

                column = Create.Column_YearBuit(Constants.ColumnNamePrefix.PredictionConfidence, year);

                Column? column_PredictionConfidence = table.UpdateColumn(column);
                if (column_PredictionConfidence is not null)
                {
                    dictionary_PredictionConfidence[year] = column_PredictionConfidence;
                }

                column = Create.Column_YearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxX, year);

                Column? column_PredictionBoundingBoxX = table.UpdateColumn(column);
                if (column_PredictionBoundingBoxX is not null)
                {
                    dictionary_PredictionBoundingBoxX[year] = column_PredictionBoundingBoxX;
                }

                column = Create.Column_YearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxY, year);

                Column? column_PredictionBoundingBoxY = table.UpdateColumn(column);
                if (column_PredictionBoundingBoxY is not null)
                {
                    dictionary_PredictionBoundingBoxY[year] = column_PredictionBoundingBoxY;
                }

                column = Create.Column_YearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxWidth, year);

                Column? column_PredictionBoundingBoxWidth = table.UpdateColumn(column);
                if (column_PredictionBoundingBoxWidth is not null)
                {
                    dictionary_PredictionBoundingBoxWidth[year] = column_PredictionBoundingBoxWidth;
                }

                column = Create.Column_YearBuit(Constants.ColumnNamePrefix.PredictionBoundingBoxHeight, year);

                Column? column_PredictionBoundingBoxHeight = table.UpdateColumn(column);
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