using DiGi.Core.Classes;
using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Retrieves the Year Built prediction input features, grouped by the run that populates them.
        /// <para>This is the definition <see cref="YearBuiltPredictionInputColumns(Range{int}?, IEnumerable{double}?)"/> is assembled from, so the allow-list and the groups cannot drift apart. Read the allow-list when the question is which columns the regressor may see, and read this when the question is which of them a county is actually carrying.</para>
        /// </summary>
        /// <param name="years">The range of years for detection and population features. Defaults to 2008..2025 when null.</param>
        /// <param name="radiuses">The collection of radiuses for radial ratio features. Defaults to 200, 400, 600, 1000 when null.</param>
        /// <returns>A dictionary keyed by <see cref="Constants.YearBuiltPredictionFeatureGroup"/> holding the columns of each group, in the order the allow-list lists them.</returns>
        public static Dictionary<string, List<Column>> YearBuiltPredictionFeatureGroups(Range<int>? years = null, IEnumerable<double>? radiuses = null)
        {
            Range<int> range_Years = years ?? new(2008, 2025);
            IEnumerable<double> enumerable_Radiuses = radiuses ?? [200, 400, 600, 1000];

            List<Column> columns_Base =
            [
                Constants.Column.FloorArea,
                Constants.Column.TotalArea,
                Constants.Column.Storeys,
                Constants.Column.Azimuth,
                Constants.Column.CardinalDirection,
                Constants.Column.InternalPointX,
                Constants.Column.InternalPointY,
                Constants.Column.BoundingBoxX,
                Constants.Column.BoundingBoxY,
                Constants.Column.BoundingBoxWidth,
                Constants.Column.BoundingBoxHeight,
                Constants.Column.IsoperimetricRatio,
                Constants.Column.RectangularThinnessRatio,
                Constants.Column.SquareThinnessRatio,
                Constants.Column.ThinnessRatio,
                Constants.Column.ConvexHullThinnessRatio,
                Constants.Column.CalculatedBuildingShape,
                Constants.Column.BuildingGeneralFunction,
                Constants.Column.BuildingSpecificFunctions,
                Constants.Column.BuildingPhase,
                Constants.Column.IsResidential,
                Constants.Column.IsOccupied,
                Constants.Column.VoivodeshipName,
                Constants.Column.CountyName,
                Constants.Column.CountyId,
                Constants.Column.MunicipalityName,
                Constants.Column.SubdivisionName,
                Constants.Column.SubdivisionId,
                Constants.Column.SettlementType,
                Constants.Column.SubdivisionOccupancy,
                Constants.Column.CalculatedOccupancy
            ];

            List<Column> columns_GridCellCoverage = [];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    columns_GridCellCoverage.Add(Create.Column_GridCellCoverage(i, j));
                }
            }

            return new Dictionary<string, List<Column>>
            {
                { Constants.YearBuiltPredictionFeatureGroup.Base, columns_Base },
                { Constants.YearBuiltPredictionFeatureGroup.GridCellCoverage, columns_GridCellCoverage },
                { Constants.YearBuiltPredictionFeatureGroup.Detection, Create.Columns_PredictionYearBuilt(range_Years) },
                { Constants.YearBuiltPredictionFeatureGroup.Population, Create.Columns_Population(range_Years) },
                { Constants.YearBuiltPredictionFeatureGroup.RadialRatio, Create.Columns_RadialRatios(enumerable_Radiuses) }
            };
        }
    }
}
