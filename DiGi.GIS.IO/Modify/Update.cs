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
            for (short i = 2008; i <= DateTime.Now.Year; i++)
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
        /// <para>Reads only the name of each division and the name, occupancy and type of the first subdivision out of <paramref name="administrativeAreal2Ds"/>, then hands those to the overload that takes them directly. A caller that already holds the names - the reference path of a subdivision carries them - should call that overload instead and avoid loading the outlines, which are never read here and reach the size of a whole country at the top of the chain.</para>
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="subdivisionId">The optional unique identifier of the subdivision.</param>
        /// <param name="building2Ds">The collection of building 2D geometries.</param>
        /// <param name="administrativeAreal2Ds">The collection of administrative boundary areas.</param>
        public static void Update_Building2D(this Table? table, int countyId, int? subdivisionId, IEnumerable<Building2D>? building2Ds, IEnumerable<AdministrativeAreal2D>? administrativeAreal2Ds)
        {
            string? countyName = null;
            string? municipalityName = null;
            string? voivodeshipName = null;
            AdministrativeSubdivision? administrativeSubdivision = null;

            if (administrativeAreal2Ds is not null)
            {
                foreach (AdministrativeAreal2D administrativeAreal2D in administrativeAreal2Ds)
                {
                    if (administrativeAreal2D is AdministrativeDivision administrativeDivision)
                    {
                        switch (administrativeDivision.AdministrativeDivisionType)
                        {
                            case GIS.Enums.AdministrativeDivisionType.county:
                                countyName ??= administrativeDivision.Name;
                                break;

                            case GIS.Enums.AdministrativeDivisionType.municipality:
                                municipalityName ??= administrativeDivision.Name;
                                break;

                            case GIS.Enums.AdministrativeDivisionType.voivodeship:
                                voivodeshipName ??= administrativeDivision.Name;
                                break;
                        }
                    }
                    else if (administrativeAreal2D is AdministrativeSubdivision administrativeSubdivision_Temp)
                    {
                        administrativeSubdivision ??= administrativeSubdivision_Temp;
                    }
                }
            }

            Update_Building2D(table, countyId, subdivisionId, building2Ds, countyName, municipalityName, voivodeshipName, administrativeSubdivision);
        }

        /// <summary>
        /// Updates the table with building 2D administrative features for a specific county and optional subdivision, taking the administrative names directly rather than reading them off boundary objects.
        /// <para>This is the overload to reach for from a caller that already knows the names - the reference path of a subdivision carries them - because the boundary objects the other overload takes hold the outlines as well, and those are never read here. At the top of an ancestor chain that outline is the whole country, so loading one per subdivision is the dominant cost of a country-wide run and buys nothing.</para>
        /// <para>Each value is written only when it is present, so a name that was not resolved leaves the stored one alone rather than clearing it.</para>
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="subdivisionId">The optional unique identifier of the subdivision.</param>
        /// <param name="building2Ds">The collection of building 2D geometries.</param>
        /// <param name="countyName">The optional name of the county.</param>
        /// <param name="municipalityName">The optional name of the municipality.</param>
        /// <param name="voivodeshipName">The optional name of the voivodeship.</param>
        /// <param name="administrativeSubdivision">The optional subdivision, read for its name, occupancy and settlement type.</param>
        public static void Update_Building2D(
            this Table? table,
            int countyId,
            int? subdivisionId,
            IEnumerable<Building2D>? building2Ds,
            string? countyName,
            string? municipalityName,
            string? voivodeshipName,
            AdministrativeSubdivision? administrativeSubdivision)
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

            string? settlementType = administrativeSubdivision?.AdministrativeSubdivisionType.SettlementType().Description();

            foreach (Tuple<Row, Building2D> tuple in tuples)
            {
                Row row = tuple.Item1;

                if (column_SubdivisionId is not null && column_SubdivisionId.TryGetValidValue(subdivisionId, out object? value))
                {
                    row[column_SubdivisionId.Index] = value;
                }

                if (countyName is not null)
                {
                    SetValue(row, column_CountyName, countyName);
                }

                if (voivodeshipName is not null)
                {
                    SetValue(row, column_VoivodeshipName, voivodeshipName);
                }

                if (municipalityName is not null)
                {
                    SetValue(row, column_MunicipalityName, municipalityName);
                }

                if (administrativeSubdivision is not null)
                {
                    SetValue(row, column_SubdivisionName, administrativeSubdivision.Name);

                    if (administrativeSubdivision.Occupancy is uint occupancy)
                    {
                        SetValue(row, column_SubdivisionOccupancy, occupancy);
                    }

                    SetValue(row, column_SettlementType, settlementType);
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

        /// <summary>
        /// Updates the table with radial ratios (Radial Building Coverage Ratio and Radial Floor Area Ratio) for a specific county and building 2D geometry.
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="radiuses">The list of radiuses to consider.</param>
        /// <param name="countyId">The ID of the county.</param>
        /// <param name="building2D">The building 2D.</param>
        /// <param name="building2Ds">The list of building 2Ds.</param>
        /// <param name="tolerance">The tolerance for distance calculations.</param>
        public static void Update_RadialRatios(this Table? table, IEnumerable<double> radiuses, int countyId, Building2D? building2D, IEnumerable<Building2D>? building2Ds, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (building2D is null)
            {
                return;
            }

            Update_RadialRatios(table, radiuses, countyId, [building2D], building2Ds, tolerance);
        }

        /// <summary>
        /// Updates the table with radial ratios (Radial Building Coverage Ratio and Radial Floor Area Ratio) for a whole collection of buildings at once.
        /// <para>This is the overload to reach for when more than one building is measured against the same surroundings. The table row index, the ratio columns, each neighbour's outline area and bounding box, and a grid index over the neighbours are all built once for the collection rather than once per building - the single-building overload delegates here with a collection of one, so a per-building loop over it repeats all of that work for every building and rescans the whole table each time.</para>
        /// <para><paramref name="building2Ds_Neighbour"/> is the surroundings, not the subjects: it must already cover every building within the largest radius of every subject, including buildings outside the subjects' own area, and it normally contains the subjects themselves as well - a building counts towards its own ratios.</para>
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="radiuses">The list of radiuses to consider.</param>
        /// <param name="countyId">The ID of the county.</param>
        /// <param name="building2Ds">The buildings the ratios are measured for and written against.</param>
        /// <param name="building2Ds_Neighbour">The surrounding buildings the ratios are measured over.</param>
        /// <param name="tolerance">The tolerance for distance calculations.</param>
        public static void Update_RadialRatios(this Table? table, IEnumerable<double> radiuses, int countyId, IEnumerable<Building2D>? building2Ds, IEnumerable<Building2D>? building2Ds_Neighbour, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (table is null || building2Ds is null || !building2Ds.Any() || building2Ds_Neighbour is null || !building2Ds_Neighbour.Any() || radiuses is null || !radiuses.Any())
            {
                return;
            }

            List<double> radiuses_Sorted = [.. radiuses.Where(x => !double.IsNaN(x) && !double.IsInfinity(x) && x > 0)];
            if (radiuses_Sorted.Count == 0)
            {
                return;
            }

            radiuses_Sorted.Sort((x, y) => y.CompareTo(x));

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

            List<Tuple<double, Column, Column>> tuples_Column = [];
            foreach (double radius in radiuses_Sorted)
            {
                Column? column_RadialBuildingCoverageRatio = table.UpdateColumn(Create.Column_RadialBuildingCoverageRatio(radius));
                if (column_RadialBuildingCoverageRatio is null)
                {
                    continue;
                }

                Column? column_RadialFloorAreaRatio = table.UpdateColumn(Create.Column_RadialFloorAreaRatio(radius));
                if (column_RadialFloorAreaRatio is null)
                {
                    continue;
                }

                tuples_Column.Add(new Tuple<double, Column, Column>(radius, column_RadialBuildingCoverageRatio, column_RadialFloorAreaRatio));
            }

            if (tuples_Column.Count == 0)
            {
                return;
            }

            // The rows are indexed once. Scanned from the back so that the highest matching row index wins,
            // which is what the single-building lookup this replaced did when it stopped at its first hit.
            Dictionary<string, Row> dictionary_Row = [];

            int count = table.RowCount;
            for (int i = count - 1; i >= 0; i--)
            {
                Row? row_Temp = table.GetRow(i);
                if (row_Temp is null)
                {
                    continue;
                }

                if (!row_Temp.TryGetValue(column_CountyId.Index, out int countyId_Row) || countyId_Row != countyId)
                {
                    continue;
                }

                if (!row_Temp.TryGetValue(column_Reference.Index, out string? reference_Row) || string.IsNullOrWhiteSpace(reference_Row))
                {
                    continue;
                }

                if (!dictionary_Row.ContainsKey(reference_Row!))
                {
                    dictionary_Row[reference_Row!] = row_Temp;
                }
            }

            // Each neighbour's outline, bounding box, area and storey count are resolved once here rather than
            // per subject building: GetArea and GetBoundingBox walk the outline, and a neighbour is looked at
            // once per subject it is near.
            List<Tuple<PolygonalFace2D, BoundingBox2D, double, ushort>> tuples_Neighbour = [];
            foreach (Building2D building2D_Neighbour in building2Ds_Neighbour)
            {
                if (building2D_Neighbour?.PolygonalFace2D is not PolygonalFace2D polygonalFace2D)
                {
                    continue;
                }

                if (polygonalFace2D.GetBoundingBox() is not BoundingBox2D boundingBox2D)
                {
                    continue;
                }

                double area_Neighbour = polygonalFace2D.GetArea();
                if (double.IsNaN(area_Neighbour) || area_Neighbour < tolerance)
                {
                    continue;
                }

                ushort storeys_Neighbour = building2D_Neighbour.Storeys;
                if (storeys_Neighbour <= 0)
                {
                    storeys_Neighbour = 1;
                }

                tuples_Neighbour.Add(new Tuple<PolygonalFace2D, BoundingBox2D, double, ushort>(polygonalFace2D, boundingBox2D, area_Neighbour, storeys_Neighbour));
            }

            // A uniform grid over the neighbours, one cell wide per largest radius, so that everything within
            // that radius of a subject is in the subject's own cell or one of the eight around it. Neighbours
            // are filed by bounding box rather than by a single point, so one straddling a cell edge is filed
            // in both. The cell index is floored rather than rounded because these are area buckets, not an
            // attempt to bring coincident points together.
            double cellSize = radiuses_Sorted[0];

            Dictionary<(int, int), List<int>> dictionary_Cell = [];
            for (int i = 0; i < tuples_Neighbour.Count; i++)
            {
                BoundingBox2D boundingBox2D = tuples_Neighbour[i].Item2;

                int x_Min = (int)Math.Floor(boundingBox2D.Min.X / cellSize);
                int x_Max = (int)Math.Floor(boundingBox2D.Max.X / cellSize);
                int y_Min = (int)Math.Floor(boundingBox2D.Min.Y / cellSize);
                int y_Max = (int)Math.Floor(boundingBox2D.Max.Y / cellSize);

                for (int x = x_Min; x <= x_Max; x++)
                {
                    for (int y = y_Min; y <= y_Max; y++)
                    {
                        if (!dictionary_Cell.TryGetValue((x, y), out List<int>? indexes) || indexes is null)
                        {
                            indexes = [];
                            dictionary_Cell[(x, y)] = indexes;
                        }

                        indexes.Add(i);
                    }
                }
            }

            HashSet<int> indexes_Candidate = [];

            foreach (Building2D building2D in building2Ds)
            {
                if (building2D?.Reference is not string reference || string.IsNullOrWhiteSpace(reference))
                {
                    continue;
                }

                Point2D? point2D_Centroid = building2D.PolygonalFace2D?.Centroid();
                if (point2D_Centroid is null)
                {
                    continue;
                }

                if (!dictionary_Row.TryGetValue(reference, out Row? row) || row is null)
                {
                    row = table.AddRow();
                    if (row is null)
                    {
                        continue;
                    }

                    SetValue(row, column_Reference, reference);
                    SetValue(row, column_CountyId, countyId);

                    dictionary_Row[reference] = row;
                }

                indexes_Candidate.Clear();

                int x_Centre = (int)Math.Floor(point2D_Centroid.X / cellSize);
                int y_Centre = (int)Math.Floor(point2D_Centroid.Y / cellSize);

                for (int x = x_Centre - 1; x <= x_Centre + 1; x++)
                {
                    for (int y = y_Centre - 1; y <= y_Centre + 1; y++)
                    {
                        if (!dictionary_Cell.TryGetValue((x, y), out List<int>? indexes) || indexes is null)
                        {
                            continue;
                        }

                        foreach (int index in indexes)
                        {
                            indexes_Candidate.Add(index);
                        }
                    }
                }

                List<Tuple<Point2D, double, ushort>>? tuples = null;

                foreach (Tuple<double, Column, Column> tuple_Column in tuples_Column)
                {
                    double radius = tuple_Column.Item1;

                    double area_Building2D = 0;
                    double area_Floor = 0;

                    if (tuples is null)
                    {
                        tuples = [];

                        foreach (int index in indexes_Candidate)
                        {
                            Tuple<PolygonalFace2D, BoundingBox2D, double, ushort> tuple_Neighbour = tuples_Neighbour[index];

                            // Optimization: Check bounding box distance first
                            BoundingBox2D boundingBox2D = tuple_Neighbour.Item2;
                            double dx = Math.Max(0.0, Math.Max(boundingBox2D.Min.X - point2D_Centroid.X, point2D_Centroid.X - boundingBox2D.Max.X));
                            double dy = Math.Max(0.0, Math.Max(boundingBox2D.Min.Y - point2D_Centroid.Y, point2D_Centroid.Y - boundingBox2D.Max.Y));
                            if (Math.Sqrt((dx * dx) + (dy * dy)) > radius + tolerance)
                            {
                                continue;
                            }

                            Point2D? point2D_Closest = tuple_Neighbour.Item1.ClosestPoint(point2D_Centroid, tolerance);
                            if (point2D_Closest is null)
                            {
                                continue;
                            }

                            if (point2D_Centroid.Distance(point2D_Closest) > radius + tolerance)
                            {
                                continue;
                            }

                            tuples.Add(new Tuple<Point2D, double, ushort>(point2D_Closest, tuple_Neighbour.Item3, tuple_Neighbour.Item4));
                            area_Building2D += tuple_Neighbour.Item3;
                            area_Floor += tuple_Neighbour.Item3 * tuple_Neighbour.Item4;
                        }
                    }
                    else
                    {
                        int count_Tuples = tuples.Count;

                        for (int i = count_Tuples - 1; i >= 0; i--)
                        {
                            Tuple<Point2D, double, ushort> tuple = tuples[i];

                            if (point2D_Centroid.Distance(tuple.Item1) > radius + tolerance)
                            {
                                tuples.RemoveAt(i);
                                continue;
                            }

                            area_Building2D += tuple.Item2;
                            area_Floor += tuple.Item2 * tuple.Item3;
                        }
                    }

                    if (area_Building2D < tolerance)
                    {
                        SetValue(row, tuple_Column.Item2, 0.0f);
                        SetValue(row, tuple_Column.Item3, 0.0f);
                        continue;
                    }

                    double area = Math.PI * radius * radius;

                    SetValue(row, tuple_Column.Item2, (float)(area_Building2D / area));

                    SetValue(row, tuple_Column.Item3, (float)(area_Floor / area));
                }

                table.AddRow(row, false);
            }
        }
    }
}