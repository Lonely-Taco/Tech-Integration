using Newtonsoft.Json;

namespace TechIntegration.Infra.Requests;

public class CustomFieldItem
{
    [JsonProperty("idCustomField")]
    public string IdCustomField { get; set; } = string.Empty;

    [JsonProperty("value")]
    public Value Value { get; set; } = new();

    [JsonProperty("idValue")]
    public string IdValue { get; set; } = string.Empty;
}