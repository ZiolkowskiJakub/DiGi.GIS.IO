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
        /// Updates the table with building 2D geometric and shape descriptor features for a specific county.
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="building2Ds">The collection of building 2D geometries.</param>
        /// <param name="apiBaseUrl">The optional API base URL to construct orthophotomap links.</param>
        public static void Update_Building2D(this Table? table, int countyId, IEnumerable<Building2D>? building2Ds, string? apiBaseUrl = null)
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

            string baseUrl = (string.IsNullOrWhiteSpace(apiBaseUrl) ? Constants.WebAPI.BaseUri : apiBaseUrl!).TrimEnd('/');

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
                SetValue(row, column_CardinalDirection, GIS.Query.CardinalDirection(azimuth));
                SetValue(row, column_IsOccupied, GIS.Query.IsOccupied(building2D));
                SetValue(row, column_IsResidential, GIS.Query.IsResidential(building2D));

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
                    SetValue(row, tuple_OrthophotomapImage.Item2, $"{baseUrl}/gis/ortodatas/imagebyreference?reference={building2D.Reference}&year={tuple_OrthophotomapImage.Item1}&countyId={countyId}");
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
    }
}
