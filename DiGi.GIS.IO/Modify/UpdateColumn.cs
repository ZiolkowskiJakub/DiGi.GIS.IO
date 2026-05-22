using DiGi.Core.IO.Table.Classes;

namespace DiGi.GIS.IO
{
    public static partial class Modify
    {
        public static TColumn? UpdateColumn<TColumn>(this Table? table, TColumn column) where TColumn : Column
        {
            if(table is null || column is null)
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
