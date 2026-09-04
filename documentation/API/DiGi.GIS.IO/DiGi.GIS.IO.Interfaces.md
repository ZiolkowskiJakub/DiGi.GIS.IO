#### [DiGi\.GIS\.IO](DiGi.GIS.IO.Overview.md 'DiGi\.GIS\.IO\.Overview')

## DiGi\.GIS\.IO\.Interfaces Namespace
### Interfaces

<a name='DiGi.GIS.IO.Interfaces.IYearBuiltPredictor'></a>

## IYearBuiltPredictor Interface

Defines the contract for the machine learning step of the Year Built prediction pipeline\.

The seam exists so that an orchestrator can drive the regressor without referencing the assembly that implements it. A direct reference drags Microsoft.ML, Microsoft.ML.FastTree, Microsoft.ML.ImageAnalytics, Microsoft.ML.LightGbm, Microsoft.ML.TorchSharp, TorchSharp-cpu and Plotly.NET into every host that loads the orchestrator.

It is declared here rather than beside the orchestrator because both sides already reference this assembly, and because the column lists the contract is expressed in - [YearBuiltPredictionInputColumns\(Range&lt;int&gt;, IEnumerable&lt;double&gt;\)](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_) 'DiGi\.GIS\.IO\.Query\.YearBuiltPredictionInputColumns\(DiGi\.Core\.Classes\.Range\<int\>, System\.Collections\.Generic\.IEnumerable\<double\>\)') and [YearBuiltPredictionOutputColumns\(\)](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.YearBuiltPredictionOutputColumns() 'DiGi\.GIS\.IO\.Query\.YearBuiltPredictionOutputColumns\(\)') - live here too.

```csharp
public interface IYearBuiltPredictor
```
### Methods

<a name='DiGi.GIS.IO.Interfaces.IYearBuiltPredictor.Predict(DiGi.Core.IO.Table.Classes.Table)'></a>

## IYearBuiltPredictor\.Predict\(Table\) Method

Scores a table of building features and returns the predicted construction year of each row\.

The table handed in carries the columns of [YearBuiltPredictionInputColumns\(Range&lt;int&gt;, IEnumerable&lt;double&gt;\)](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_) 'DiGi\.GIS\.IO\.Query\.YearBuiltPredictionInputColumns\(DiGi\.Core\.Classes\.Range\<int\>, System\.Collections\.Generic\.IEnumerable\<double\>\)') and is keyed by [Reference](DiGi.GIS.IO.Constants.md#DiGi.GIS.IO.Constants.Column.Reference 'DiGi\.GIS\.IO\.Constants\.Column\.Reference'). It never carries [PredictedYearBuilt](DiGi.GIS.IO.Constants.md#DiGi.GIS.IO.Constants.Column.PredictedYearBuilt 'DiGi\.GIS\.IO\.Constants\.Column\.PredictedYearBuilt') - that column is this pipeline's own output, so feeding it back in would train and score the model on its previous answer.

The table returned carries [Reference](DiGi.GIS.IO.Constants.md#DiGi.GIS.IO.Constants.Column.Reference 'DiGi\.GIS\.IO\.Constants\.Column\.Reference') and [PredictedYearBuilt](DiGi.GIS.IO.Constants.md#DiGi.GIS.IO.Constants.Column.PredictedYearBuilt 'DiGi\.GIS\.IO\.Constants\.Column\.PredictedYearBuilt'), one row per scored building. A row the implementation cannot score is left out rather than filled with a default.

```csharp
DiGi.Core.IO.Table.Classes.Table? Predict(DiGi.Core.IO.Table.Classes.Table? table);
```
#### Parameters

<a name='DiGi.GIS.IO.Interfaces.IYearBuiltPredictor.Predict(DiGi.Core.IO.Table.Classes.Table).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The building features to score, one row per building\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')  
The predicted construction years, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') when the table could not be scored at all\.

<a name='DiGi.GIS.IO.Interfaces.IYearBuiltPredictor.YearBuiltPredictorReadiness()'></a>

## IYearBuiltPredictor\.YearBuiltPredictorReadiness\(\) Method

Reports whether this predictor can score at all, probed before a run starts\.

The orchestrator checks this beside the Python preflight when the scoring step is on, so a runner that is missing the model it scores with is refused in seconds instead of after exporting a county of imagery and failing on the first scoring batch. It carries the diagnostics that say why, rather than a bare flag.

```csharp
DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness YearBuiltPredictorReadiness();
```

#### Returns
[YearBuiltPredictorReadiness](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness 'DiGi\.GIS\.IO\.Classes\.YearBuiltPredictorReadiness')  
The readiness of this predictor \- whether it can score, and why not when it cannot\.