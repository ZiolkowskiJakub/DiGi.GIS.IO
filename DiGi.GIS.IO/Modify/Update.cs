using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.Classes;
using DiGi.GIS.Emgu.CV.Classes;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.GIS.IO
{
    public static partial class Modify
    {
        /// <summary>
        /// Updates the table with building data, year built predictions, orthophotomap comparisons, and administrative boundaries.
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="subdivisionId">The optional unique identifier of the subdivision.</param>
        /// <param name="building2Ds">The collection of building 2D geometries to update.</param>
        /// <param name="building2DYearBuiltPredictions">The optional collection of year built predictions to update.</param>
        /// <param name="ortoDatasComparisons">The optional collection of orthophotomap data comparisons to update.</param>
        /// <param name="administrativeAreal2Ds">The optional collection of administrative boundary areas to update.</param>
        /// <param name="apiBaseUrl">The optional API base URL to construct orthophotomap links.</param>
        public static void Update(this Table? table, int countyId, int? subdivisionId, IEnumerable<Building2D>? building2Ds, IEnumerable<Building2DYearBuiltPredictions>? building2DYearBuiltPredictions = null, IEnumerable<OrtoDatasComparison>? ortoDatasComparisons = null, IEnumerable<AdministrativeAreal2D>? administrativeAreal2Ds = null, string? apiBaseUrl = null)
        {
            if (table is null)
            {
                return;
            }

            if (building2Ds is not null && building2Ds.Any())
            {
                Update_Building2D(table, countyId, building2Ds, apiBaseUrl);
                Update_Building2D(table, countyId, subdivisionId, building2Ds, administrativeAreal2Ds);
            }

            if (building2DYearBuiltPredictions is not null && building2DYearBuiltPredictions.Any())
            {
                Update_Building2D_YearBuiltPredictions(table, countyId, building2DYearBuiltPredictions);
            }

            if (ortoDatasComparisons is not null && ortoDatasComparisons.Any())
            {
                Update_OrtoDatasComparison(table, countyId, ortoDatasComparisons);
            }
        }
    }
}
