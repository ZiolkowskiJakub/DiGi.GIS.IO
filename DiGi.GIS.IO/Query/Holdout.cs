using System.Text;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Decides whether one key belongs to the Year Built holdout, by hashing the key rather than by shuffling.
        /// <para>A seeded shuffle is only reproducible inside one runtime: the same seed gives different orders in .NET and in Python, and the framework is free to change its generator between versions. Hashing the key makes membership a property of the row, so the same holdout comes back on any machine, in any language, in any order, and two runs months apart stay comparable.</para>
        /// <para>The hash is FNV-1a over the UTF-8 bytes, written out here rather than taken from <c>string.GetHashCode</c>, which is randomised per process and would put the same building in a different half on every run.</para>
        /// <para>Pass the building reference to hold out roughly one row in five. Pass the subdivision identifier to hold out whole subdivisions instead, so no subdivision spans training and holdout - that is the control for a model memorising neighbourhoods rather than reading the imagery.</para>
        /// <para>This is the holdout both the year built regressor (DiGi.GIS.ML) and the YOLO dataset builder (DiGi.GIS.YOLO.UI) carve, so it lives in DiGi.GIS.IO where both can reach it without dragging ML.NET into the detector side.</para>
        /// </summary>
        /// <param name="key">The row key - a building reference or a subdivision identifier.</param>
        /// <param name="denominator">One row in this many joins the holdout. 5 gives a 20 percent holdout.</param>
        /// <returns>True when the key belongs to the holdout, false for a null or empty key.</returns>
        public static bool Holdout(string? key, int denominator = 5)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            int denominator_Temp = denominator < 2 ? 2 : denominator;

            uint hash = 2166136261;
            foreach (byte value in Encoding.UTF8.GetBytes(key!))
            {
                hash ^= value;
                hash *= 16777619;
            }

            return hash % (uint)denominator_Temp == 0;
        }
    }
}
