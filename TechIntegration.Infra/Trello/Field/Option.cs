using Newtonsoft.Json;

public class Option
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("idCustomField")]
    public string IdCustomField { get; set; } = null!;

    [JsonProperty("value")]
    public Value Value { get; set; } = new();

    [JsonProperty("color")]
    public string Color { get; set; } = null!;

    [JsonProperty("pos")]
    public int Pos { get; set; } 
}