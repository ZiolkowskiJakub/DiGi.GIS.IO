namespace DiGi.GIS.IO.Constants
{
    /// <summary>
    /// Names the groups the Year Built prediction feature set is built from.
    /// <para>The groups are not cosmetic. Each is populated by a different run - the base and grid cell columns by a General building data update, the population columns by a Statistical one, the radial ratios by a Radial Ratios one, and the detection columns by the prediction pipeline itself - so which group is empty says which run has not happened.</para>
    /// </summary>
    public static class YearBuiltPredictionFeatureGroup
    {
        /// <summary>
        /// The scalar geometry, shape, administrative and occupancy columns. Written by a General building data update.
        /// </summary>
        public const string Base = "base";

        /// <summary>
        /// The five by five grid cell coverage columns. Written by a General building data update.
        /// </summary>
        public const string GridCellCoverage = "grid cell coverage";

        /// <summary>
        /// The five per year detection columns. Written by the prediction pipeline itself, never by a building data update.
        /// </summary>
        public const string Detection = "detection";

        /// <summary>
        /// The per year municipality population columns. Written by a Statistical building data update.
        /// </summary>
        public const string Population = "population";

        /// <summary>
        /// The two per radius radial ratio columns. Written by a Radial Ratios building data update.
        /// </summary>
        public const string RadialRatio = "radial ratio";
    }
}
