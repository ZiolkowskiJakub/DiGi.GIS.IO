using DiGi.Core.IO.Table.Classes;

namespace DiGi.GIS.IO
{
    public static partial class Modify
    {
        /// <summary>
        /// Updates an existing column in the table, or adds it if it does not exist.
        /// </summary>
        /// <typeparam name="TColumn">The type of the column to update, which must inherit from <see cref="Column"/>.</typeparam>
        /// <param name="table">The table containing the column.</param>
        /// <param name="column">The column template or definition to update or add.</param>
        /// <returns>The updated column matching the specified type, or <see langword="null"/> if the table or column parameter is <see langword="null"/>.</returns>
        public static TColumn? UpdateColumn<TColumn>(this Table? table, TColumn column) where TColumn : Column
        {
            if (table is null || column is null)
            {
                return null;
            }

            if (!table.TryGetColumn(column.Name, out Column? result) || result is null)
            {
                result = table.AddColumn(column);
            }

            return (TColumn?)result;
        }
    }
}