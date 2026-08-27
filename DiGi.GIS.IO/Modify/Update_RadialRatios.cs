using DiGi.Core;
using DiGi.Core.IO.Table.Classes;
using DiGi.Geometry.Planar;
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
