using Newtonsoft.Json;

namespace TechIntegration.Infra.Trello.List;

public class BoardList
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("name")]
    public string Name { get; set; } = null!;
}