using System.Collections.Generic;

namespace DiGi.GIS.IO.Classes
{
    /// <summary>
    /// States whether a <see cref="Interfaces.IYearBuiltPredictor"/> can score at all, probed before a run starts.
    /// <para>The seam returns this rather than a bare flag so the reason a predictor cannot score travels with the answer - an unattended run learns in seconds that the trained model is missing rather than after exporting a county of imagery. It is the single surface the orchestrator checks, so the contract a predictor expects (the year range and radiuses the loaded model was trained on, ZiolkowskiJakub/DiGi.GIS.ML#6) lands beside this runnability instead of as a second, unrelated member on the interface.</para>
    /// <para>It is a local probe result, computed in the host and consumed in the same call, so it is not a SerializableObject and carries no serialization surface.</para>
    /// </summary>
    public sealed class YearBuiltPredictorReadiness
    {
        /// <summary>Gets whether the predictor can score at all.</summary>
        public bool Runnable { get; }

        /// <summary>Gets the diagnostics that explain the answer - why the predictor cannot score. Empty when it can score.</summary>
        public List<string> Messages { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="YearBuiltPredictorReadiness"/> class.
        /// </summary>
        /// <param name="runnable">Whether the predictor can score at all.</param>
        /// <param name="messages">The diagnostics explaining why it cannot score. Null or empty when it can score.</param>
        public YearBuiltPredictorReadiness(bool runnable, IEnumerable<string>? messages = null)
        {
            this.Runnable = runnable;
            this.Messages = messages is null ? [] : [.. messages];
        }
    }
}
