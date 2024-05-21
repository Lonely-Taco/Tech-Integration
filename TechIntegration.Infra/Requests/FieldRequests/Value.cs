using Newtonsoft.Json;

namespace TechIntegration.Infra.Requests;

public class Value
{
}

public class TextValue : Value
{
    [JsonProperty("text")]
    public string Text { get; set; } = string.Empty;
}

public class NumberValue : Value
{
    [JsonProperty("number")]
    public int Number { get; set; }
}

public class CheckedValue : Value
{
    [JsonProperty("checked")]
    public bool IsChecked { get; set; }
}

public class DateValue : Value
{
    [JsonProperty("date")]
    public DateTime? Date { get; set; }
}