using DiGi.Core.Classes;
using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Retrieves the list of columns permitted as input features for the Year Built prediction machine learning model across the specified range of years and radial radiuses.
        /// </summary>
        /// <param name="years">The range of years for detection and temporal features. Defaults to 2008..2025 when null.</param>
        /// <param name="radiuses">The collection of radiuses for radial ratio features. Defaults to 200, 400, 600, 1000 when null.</param>
        /// <returns>A list of <see cref="Column"/> instances representing the allowed input features.</returns>
        public static List<Column> YearBuiltPredictionInputColumns(Range<int>? years = null, IEnumerable<double>? radiuses = null)
        {
            Range<int> range_Years = years ?? new(2008, 2025);
            IEnumerable<double> enumerable_Radiuses = radiuses ?? [200, 400, 600, 1000];

            List<Column> columns =
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

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    columns.Add(Create.Column_GridCellCoverage(i, j));
                }
            }

            columns.AddRange(Create.Columns_PredictionYearBuilt(range_Years));
            columns.AddRange(Create.Columns_Population(range_Years));
            columns.AddRange(Create.Columns_RadialRatios(enumerable_Radiuses));

            return columns;
        }
    }
}
