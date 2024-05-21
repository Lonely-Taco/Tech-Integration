using Newtonsoft.Json;

namespace TechIntegration.TechIntegration.Infra.Trello.CustomField;

public class CustomField
{
    [JsonProperty("idCustomField")]
    public string IdCustomField { get; set; } = string.Empty;
    
    [JsonProperty("value")]
    public CustomFieldValue Value { get; set; } = new();

    [JsonProperty("idValue")]
    public string IdValue { get; set; } = string.Empty;

    [JsonProperty("options")]
    public List<Option> Options { get; set; } = new();
}

public class CustomFieldValue
{
    [JsonProperty("text")]
    public string Text { get; set; } = string.Empty;
    
    [JsonProperty("number")]
    public int Number { get; set; }
    
    [JsonProperty("checked")]
    public bool IsChecked { get; set; }
    
    [JsonProperty("date")]
    public DateTime? Date { get; set; }
}

/*
 * "id": "664a5270cffab976d3383c27",
"idModel": "664622fe3b6521a91bbaceb3",
"modelType": "board",
"fieldGroup": "e8620327b22fc5e743a35720260ad7f03a0edaef6e64e3c47f37f04f09ce4747",
"display": {
  "cardFront": true
},
"name": "Status",
"type": "list",
"isSuggestedField": false,
"options": [
  {
    "id": "664a5270cffab976d3383c28",
    "idCustomField": "664a5270cffab976d3383c27",
    "value": {
      "text": "Satus1"
    },
    "color": "blue",
    "pos": 16384
  },
  {
    "id": "664a5270cffab976d3383c29",
    "idCustomField": "664a5270cffab976d3383c27",
    "value": {
      "text": "Status2"
    },
    "color": "pink",
    "pos": 32768
  },
  {
    "id": "664a5270cffab976d3383c2a",
    "idCustomField": "664a5270cffab976d3383c27",
    "value": {
      "text": "Status3"
    },
    "color": "lime",
    "pos": 49152
  }
]
}
 */