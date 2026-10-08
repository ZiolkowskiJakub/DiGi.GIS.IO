using DiGi.Core.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.IO.Classes
{
    /// <summary>
    /// States whether a <see cref="Interfaces.IYearBuiltPredictor"/> can score at all, and what it expects, probed before a run starts.
    /// <para>The seam returns this rather than a bare flag so the reason a predictor cannot score travels with the answer - an unattended run learns in seconds that the trained model is missing rather than after exporting a county of imagery. It is the single surface the orchestrator checks, so the contract a predictor expects - the year range and radiuses the loaded model was trained on - travels with the runnability rather than living only beside the model.</para>
    /// <para><see cref="Years"/> and <see cref="Radiuses"/> state that contract. When both are <see langword="null"/> the predictor states no contract and the orchestrator's feature-contract check is skipped; when they are set, the orchestrator compares the run's options against them before it reads a county.</para>
    /// <para>It is a local probe result, computed in the host and consumed in the same call, so it is not a SerializableObject and carries no serialization surface.</para>
    /// </summary>
    public sealed class YearBuiltPredictorReadiness
    {
        /// <summary>Gets whether the predictor can score at all.</summary>
        public bool Runnable { get; }

        /// <summary>Gets the diagnostics that explain the answer - why the predictor cannot score. Empty when it can score.</summary>
        public List<string> Messages { get; }

        /// <summary>Gets the year range the loaded model was trained on, or <see langword="null"/> when the predictor states no contract.</summary>
        public Range<int>? Years { get; }

        /// <summary>Gets the radiuses the loaded model was trained on, in metres, or <see langword="null"/> when the predictor states no contract.</summary>
        public List<double>? Radiuses { get; }

        /// <summary>
        /// Gets the identity of the loaded model - normally the lowercase hexadecimal SHA-256 of its file - or <see langword="null"/> when the predictor states none.
        /// <para>The orchestrator stamps it on every prediction it stores (<c>PredictedYearBuilt.ModelId</c>), so the history can tell one model's predictions from another's after the model file is replaced in place - a file name says nothing then (ZiolkowskiJakub/DiGi.GIS.YOLO.UI#26).</para>
        /// </summary>
        public string? ModelId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="YearBuiltPredictorReadiness"/> class.
        /// </summary>
        /// <param name="runnable">Whether the predictor can score at all.</param>
        /// <param name="messages">The diagnostics explaining why it cannot score. Null or empty when it can score.</param>
        /// <param name="years">The year range the loaded model was trained on, or null when the predictor states no contract.</param>
        /// <param name="radiuses">The radiuses the loaded model was trained on, in metres, or null when the predictor states no contract.</param>
        /// <param name="modelId">The identity of the loaded model, normally the lowercase hexadecimal SHA-256 of its file, or null when the predictor states none.</param>
        public YearBuiltPredictorReadiness(bool runnable, IEnumerable<string>? messages = null, Range<int>? years = null, IEnumerable<double>? radiuses = null, string? modelId = null)
        {
            this.Runnable = runnable;
            this.Messages = messages is null ? [] : [.. messages];
            this.Years = years;
            this.Radiuses = radiuses is null ? null : [.. radiuses];
            this.ModelId = string.IsNullOrWhiteSpace(modelId) ? null : modelId;
        }
    }
}
