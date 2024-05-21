using Newtonsoft.Json;

public class Field
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("idModel")]
    public string IdModel { get; set; } = null!;

    [JsonProperty("modelType")]
    public string ModelType { get; set; } = null!;

    [JsonProperty("fieldGroup")]
    public string FieldGroup { get; set; } = null!;

    [JsonProperty("display")]
    public Display Display { get; set; } = new();

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("type")]
    public string Type { get; set; } = null!;

    [JsonProperty("isSuggestedField")]
    public bool IsSuggestedField { get; set; }

    [JsonProperty("options")]
    public List<Option> Options { get; set; } = new();
}