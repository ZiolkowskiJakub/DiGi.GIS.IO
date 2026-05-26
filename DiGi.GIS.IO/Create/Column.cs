using DiGi.Core;
using DiGi.Core.IO.Table.Classes;

namespace DiGi.GIS.IO
{
    public static partial class Create
    {
        public static Column Column_Orthophotomap(int year_1, int year_2, string columnNamePrefix, string columnNameSuffix)
        {
            string additionalText = string.Empty;
            if (columnNamePrefix == "BB")
            {
                additionalText = "full BoundingBox ";
            }
            else if (columnNamePrefix == "P")
            {
                additionalText = "BoundingBox filled ";
            }
            else if (columnNamePrefix == "PO")
            {
                additionalText = "BoundingBox filled with offset ";
            }

            return new ExtendedColumn($@"{columnNamePrefix} {year_1} {year_2} {columnNameSuffix}", typeof(float), Enums.Category.Orthophotomap.Description(), $@"{columnNameSuffix} comparison based on {additionalText}orthophotomap taken {year_1} and {year_2}");
        }

        public static Column Column_YearBuit(string columnNamePrefix, int year)
        {
            return new ExtendedColumn($@"{columnNamePrefix} {year}", typeof(double), Enums.Category.YearBuit.Description(), $@"{columnNamePrefix} based on predition for {year}");
        }

        public static Column Column_GridCellCoverage(int widthCount, int heightCount)
        {
            return new ExtendedColumn($"Grid cell coverage [{widthCount},{heightCount}]", typeof(float), Enums.Category.ShapePrediction.Description(), $"A normalized value between 0.0 (completely empty) and 1.0 (fully occupied) that represents the shape intersection area divided by the total area of an individual grid cell. The grid is created by taking the bounding rectangle of the shape and dividing its edges into 5 segments of equal length. Value represents cell [{widthCount},{heightCount}]");
        }
    }
}