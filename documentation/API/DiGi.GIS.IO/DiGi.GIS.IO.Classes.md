#### [DiGi\.GIS\.IO](DiGi.GIS.IO.Overview.md 'DiGi\.GIS\.IO\.Overview')

## DiGi\.GIS\.IO\.Classes Namespace
### Classes

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness'></a>

## YearBuiltPredictorReadiness Class

States whether a [IYearBuiltPredictor](DiGi.GIS.IO.Interfaces.md#DiGi.GIS.IO.Interfaces.IYearBuiltPredictor 'DiGi\.GIS\.IO\.Interfaces\.IYearBuiltPredictor') can score at all, probed before a run starts\.

The seam returns this rather than a bare flag so the reason a predictor cannot score travels with the answer - an unattended run learns in seconds that the trained model is missing rather than after exporting a county of imagery. It is the single surface the orchestrator checks, so the contract a predictor expects (the year range and radiuses the loaded model was trained on, ZiolkowskiJakub/DiGi.GIS.ML#6) lands beside this runnability instead of as a second, unrelated member on the interface.

It is a local probe result, computed in the host and consumed in the same call, so it is not a SerializableObject and carries no serialization surface.

```csharp
public sealed class YearBuiltPredictorReadiness
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → YearBuiltPredictorReadiness
### Constructors

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_)'></a>

## YearBuiltPredictorReadiness\(bool, IEnumerable\<string\>\) Constructor

Initializes a new instance of the [YearBuiltPredictorReadiness](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness 'DiGi\.GIS\.IO\.Classes\.YearBuiltPredictorReadiness') class\.

```csharp
public YearBuiltPredictorReadiness(bool runnable, System.Collections.Generic.IEnumerable<string>? messages=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_).runnable'></a>

`runnable` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether the predictor can score at all\.

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The diagnostics explaining why it cannot score\. Null or empty when it can score\.
### Properties

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Messages'></a>

## YearBuiltPredictorReadiness\.Messages Property

Gets the diagnostics that explain the answer \- why the predictor cannot score\. Empty when it can score\.

```csharp
public System.Collections.Generic.List<string> Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Runnable'></a>

## YearBuiltPredictorReadiness\.Runnable Property

Gets whether the predictor can score at all\.

```csharp
public bool Runnable { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')