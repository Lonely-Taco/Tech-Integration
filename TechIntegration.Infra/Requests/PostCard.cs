using Newtonsoft.Json;
using TechIntegration.Core.Models;

namespace TechIntegration.Infra.Requests;

public class PostCard
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("desc")]
    public string Description { get; set; }

    [JsonProperty("pos")]
    public string Pos { get; set; }

    [JsonProperty("due")]
    public string? Due { get; set; }

    [JsonProperty("start")]
    public string Start { get; set; }

    [JsonProperty("dueComplete")]
    public bool DueComplete { get; set; }
    
    [JsonProperty("idList")]
    public required string IdList { get; set; }

    [JsonProperty("idMembers")]
    public List<string> IdMembers { get; set; }

    [JsonProperty("idLabels")]
    public List<string> IdLabels { get; set; }

    [JsonProperty("urlSource")]
    public string UrlSource { get; set; }

    [JsonProperty("fileSource")]
    public string FileSource { get; set; }

    [JsonProperty("mimeType")]
    public string MimeType { get; set; }

    [JsonProperty("idCardSource")]
    public string IdCardSource { get; set; }

    [JsonProperty("keepFromSource")]
    public string KeepFromSource { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("locationName")]
    public string LocationName { get; set; }

    [JsonProperty("coordinates")]
    public string Coordinates { get; set; }

    public static PostCard CreateCardRequestFromTender(Tender tender, string listId)
    {
        return new PostCard
        {
            Name = tender.TenderName,
            Description = tender.Name,
            Pos = "top",
            Due = tender.Deadline.ToString(),
            Start = tender.PublicationDate,
            DueComplete = false,
            IdList = listId,
            IdMembers = [],
            IdLabels = [],
            UrlSource = "",
            FileSource = "",
            MimeType = "",
            IdCardSource = "",
            KeepFromSource = null, // can use this to make new cards based off of existing cards.
            
        };
    }
}