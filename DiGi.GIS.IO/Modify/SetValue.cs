using DiGi.Core.IO.Table.Classes;

namespace DiGi.GIS.IO
{
    public static partial class Modify
    {
        /// <summary>
        /// Sets the value of a specific column in a row, performing input value validation first.
        /// </summary>
        /// <param name="row">The row in which the value is to be set.</param>
        /// <param name="column">The column whose value is to be set.</param>
        /// <param name="value">The new value to set, which will be validated before setting.</param>
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