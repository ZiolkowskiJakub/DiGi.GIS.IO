using DiGi.Core.IO.Table.Classes;

namespace DiGi.GIS.IO
{
    public static partial class Modify
    {
        public static void SetValue(this Row? row, Column? column, object? value)
        {
            if (row is null || column is null)
            {
                return;
            }

            if (column is not null && column.TryGetValidValue(value, out object? validValue))
            {
                row[column.Index] = validValue;
            }
        }
    }
}