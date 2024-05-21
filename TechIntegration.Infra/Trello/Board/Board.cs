using Newtonsoft.Json;

namespace TechIntegration.Core.Models;

public class Board
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("name")]
    public string Name { get; set; }= null!;

    [JsonProperty("desc")]
    public string? Desc { get; set; }

    [JsonProperty("descData")]
    public string? DescData { get; set; }

    [JsonProperty("pinned")]
    public bool Pinned { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; } = null!;
}