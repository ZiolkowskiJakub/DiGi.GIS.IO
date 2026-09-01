using DiGi.Core.IO.Table.Classes;

namespace DiGi.GIS.IO.Interfaces
{
    /// <summary>
    /// Defines the contract for the machine learning step of the Year Built prediction pipeline.
    /// <para>The seam exists so that an orchestrator can drive the regressor without referencing the assembly that implements it. A direct reference drags Microsoft.ML, Microsoft.ML.FastTree, Microsoft.ML.ImageAnalytics, Microsoft.ML.LightGbm, Microsoft.ML.TorchSharp, TorchSharp-cpu and Plotly.NET into every host that loads the orchestrator.</para>
    /// <para>It is declared here rather than beside the orchestrator because both sides already reference this assembly, and because the column lists the contract is expressed in - <see cref="Query.YearBuiltPredictionInputColumns(Core.Classes.Range{int})"/> and <see cref="Query.YearBuiltPredictionOutputColumns"/> - live here too.</para>
    /// </summary>
    public interface IYearBuiltPredictor
    {
        /// <summary>
        /// Scores a table of building features and returns the predicted construction year of each row.
        /// <para>The table handed in carries the columns of <see cref="Query.YearBuiltPredictionInputColumns(Core.Classes.Range{int})"/> and is keyed by <see cref="Constants.Column.Reference"/>. It never carries <see cref="Constants.Column.PredictedYearBuilt"/> - that column is this pipeline's own output, so feeding it back in would train and score the model on its previous answer.</para>
        /// <para>The table returned carries <see cref="Constants.Column.Reference"/> and <see cref="Constants.Column.PredictedYearBuilt"/>, one row per scored building. A row the implementation cannot score is left out rather than filled with a default.</para>
        /// </summary>
        /// <param name="table">The building features to score, one row per building.</param>
        /// <returns>The predicted construction years, or <see langword="null"/> when the table could not be scored at all.</returns>
        Table? Predict(Table? table);
    }
}
