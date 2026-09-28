using System.Collections.Generic;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Decides Year Built holdout membership for every key, in row order.
        /// <para>Delegates to <see cref="Holdout(string?, int)"/> per key so the two cannot disagree. A null or empty key is simply not in the holdout, so the result always carries one entry per key, and null input gives an empty list rather than throwing.</para>
        /// </summary>
        /// <param name="keys">The key of each row, in row order - building references, or subdivision identifiers for the grouped carve.</param>
        /// <param name="denominator">One row in this many joins the holdout. 5 gives a 20 percent holdout.</param>
        /// <returns>True for each row that belongs to the holdout, in row order. Empty when the input is null.</returns>
        public static List<bool> Holdouts(this IEnumerable<string?>? keys, int denominator = 5)
        {
            List<bool> result = [];
            if (keys is null)
            {
                return result;
            }

            foreach (string? key in keys)
            {
                result.Add(Holdout(key, denominator));
            }

            return result;
        }
    }
}
