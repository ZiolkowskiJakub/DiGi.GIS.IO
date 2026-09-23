#### [DiGi\.GIS\.IO](DiGi.GIS.IO.Overview.md 'DiGi\.GIS\.IO\.Overview')

## DiGi\.GIS\.IO\.Classes Namespace
### Classes

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness'></a>

## YearBuiltPredictorReadiness Class

States whether a [IYearBuiltPredictor](DiGi.GIS.IO.Interfaces.md#DiGi.GIS.IO.Interfaces.IYearBuiltPredictor 'DiGi\.GIS\.IO\.Interfaces\.IYearBuiltPredictor') can score at all, and what it expects, probed before a run starts\.

The seam returns this rather than a bare flag so the reason a predictor cannot score travels with the answer - an unattended run learns in seconds that the trained model is missing rather than after exporting a county of imagery. It is the single surface the orchestrator checks, so the contract a predictor expects - the year range and radiuses the loaded model was trained on - travels with the runnability rather than living only beside the model.

[Years](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Years 'DiGi\.GIS\.IO\.Classes\.YearBuiltPredictorReadiness\.Years') and [Radiuses](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Radiuses 'DiGi\.GIS\.IO\.Classes\.YearBuiltPredictorReadiness\.Radiuses') state that contract. When both are [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') the predictor states no contract and the orchestrator's feature-contract check is skipped; when they are set, the orchestrator compares the run's options against them before it reads a county.

It is a local probe result, computed in the host and consumed in the same call, so it is not a SerializableObject and carries no serialization surface.

```csharp
public sealed class YearBuiltPredictorReadiness
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → YearBuiltPredictorReadiness
### Constructors

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_)'></a>

## YearBuiltPredictorReadiness\(bool, IEnumerable\<string\>, Range\<int\>, IEnumerable\<double\>\) Constructor

Initializes a new instance of the [YearBuiltPredictorReadiness](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness 'DiGi\.GIS\.IO\.Classes\.YearBuiltPredictorReadiness') class\.

```csharp
public YearBuiltPredictorReadiness(bool runnable, System.Collections.Generic.IEnumerable<string>? messages=null, DiGi.Core.Classes.Range<int>? years=null, System.Collections.Generic.IEnumerable<double>? radiuses=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).runnable'></a>

`runnable` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether the predictor can score at all\.

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The diagnostics explaining why it cannot score\. Null or empty when it can score\.

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The year range the loaded model was trained on, or null when the predictor states no contract\.

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The radiuses the loaded model was trained on, in metres, or null when the predictor states no contract\.
### Properties

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Messages'></a>

## YearBuiltPredictorReadiness\.Messages Property

Gets the diagnostics that explain the answer \- why the predictor cannot score\. Empty when it can score\.

```csharp
public System.Collections.Generic.List<string> Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Radiuses'></a>

## YearBuiltPredictorReadiness\.Radiuses Property

Gets the radiuses the loaded model was trained on, in metres, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') when the predictor states no contract\.

```csharp
public System.Collections.Generic.List<double>? Radiuses { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Runnable'></a>

## YearBuiltPredictorReadiness\.Runnable Property

Gets whether the predictor can score at all\.

```csharp
public bool Runnable { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Years'></a>

## YearBuiltPredictorReadiness\.Years Property

Gets the year range the loaded model was trained on, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') when the predictor states no contract\.

```csharp
public DiGi.Core.Classes.Range<int>? Years { get; }
```

#### Property Value
[DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')