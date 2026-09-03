using DiGi.Core.IO.Table.Classes;
using System;
using System.Collections.Generic;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Names the given columns that a table either does not carry at all, or carries with the type default in every row.
        /// <para>The two cases are reported together on purpose, because a scorer cannot tell them apart: a column the table does not carry reads as the type default, so an absent feature and a feature that is zero everywhere reach a model as the same thing. Both mean the run that fills the column has not happened.</para>
        /// <para>This is a different question from <see cref="DefaultOnlyColumnNames(Table?)"/>, which names columns that never vary. A column holding one county name in every row never varies and is perfectly populated; a detection column holding zero in every row is not.</para>
        /// </summary>
        /// <param name="table">The table to inspect. A null table carries nothing, so every column is reported.</param>
        /// <param name="columns">The columns to look for. Columns are matched by stored column slug first and by display name second, the way the feature read projects them.</param>
        /// <returns>The names of the unpopulated columns, in the order given. Empty when every column carries a value somewhere.</returns>
        public static List<string> UnpopulatedColumnNames(this Table? table, IEnumerable<Column>? columns)
        {
            List<string> result = [];

            if (columns is null)
            {
                return result;
            }

            Dictionary<string, int> indexes_BySlug = [];
            Dictionary<string, int> indexes_ByName = [];

            if (table is not null && table.Columns is not null)
            {
                int index = 0;
                foreach (Column column_Table in table.Columns)
                {
                    if (column_Table is not null)
                    {
                        if (Core.IO.Query.UniqueId(column_Table) is string slug && !string.IsNullOrWhiteSpace(slug))
                        {
                            if (!indexes_BySlug.ContainsKey(slug))
                            {
                                indexes_BySlug.Add(slug, index);
                            }
                        }

                        if (column_Table.Name is string name_Table && !string.IsNullOrWhiteSpace(name_Table))
                        {
                            if (!indexes_ByName.ContainsKey(name_Table))
                            {
                                indexes_ByName.Add(name_Table, index);
                            }
                        }
                    }

                    index++;
                }
            }

            foreach (Column column in columns)
            {
                if (column?.Name is not string name || string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }

                int index_Column = -1;
                if (Core.IO.Query.UniqueId(column) is string slug_Column && !string.IsNullOrWhiteSpace(slug_Column) && indexes_BySlug.TryGetValue(slug_Column, out int index_Slug))
                {
                    index_Column = index_Slug;
                }
                else if (indexes_ByName.TryGetValue(name, out int index_Name))
                {
                    index_Column = index_Name;
                }

                if (index_Column < 0 || table is null)
                {
                    result.Add(name);
                    continue;
                }

                bool populated = false;
                for (int i = 0; i < table.RowCount; i++)
                {
                    object? value = table.GetValue(i, index_Column);

                    if (value is null)
                    {
                        continue;
                    }

                    if (value is string text)
                    {
                        if (!string.IsNullOrWhiteSpace(text))
                        {
                            populated = true;
                            break;
                        }

                        continue;
                    }

                    Type type = value.GetType();
                    if (!type.IsValueType || !value.Equals(Activator.CreateInstance(type)))
                    {
                        populated = true;
                        break;
                    }
                }

                if (!populated)
                {
                    result.Add(name);
                }
            }

            return result;
        }
    }
}
