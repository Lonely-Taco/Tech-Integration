using Newtonsoft.Json;
using TechIntegration.TechIntegration.Infra.Trello.CustomField;

namespace TechIntegration.Core.Models;

public class Card
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("address")]
    public string Address { get; set; } = string.Empty;

    [JsonProperty("badges")]
    public Badges Badges { get; set; } = new Badges();

    [JsonProperty("checkItemStates")]
    public List<string> CheckItemStates { get; set; } = new();

    [JsonProperty("closed")]
    public bool Closed { get; set; }

    [JsonProperty("coordinates")]
    public string Coordinates { get; set; } = string.Empty;

    [JsonProperty("creationMethod")]
    public string CreationMethod { get; set; } = string.Empty;

    [JsonProperty("dateLastActivity")]
    public DateTime DateLastActivity { get; set; }

    [JsonProperty("desc")]
    public string Desc { get; set; } = string.Empty;

    [JsonProperty("due")]
    public string Due { get; set; } = string.Empty;

    [JsonProperty("dueReminder")]
    public string DueReminder { get; set; } = string.Empty;

    [JsonProperty("idBoard")]
    public string IdBoard { get; set; } = string.Empty;

    [JsonProperty("idChecklists")]
    public List<IdChecklist> IdChecklists { get; set; } = new();

    [JsonProperty("idLabels")]
    public List<IdLabel> IdLabels { get; set; } = new();

    [JsonProperty("idList")]
    public string IdList { get; set; } = string.Empty;

    [JsonProperty("idMembers")]
    public List<string> IdMembers { get; set; } = new();

    [JsonProperty("idMembersVoted")]
    public List<string> IdMembersVoted { get; set; } = new();

    [JsonProperty("idShort")]
    public int IdShort { get; set; }

    [JsonProperty("labels")]
    public List<string> Labels { get; set; } = new();

    [JsonProperty("limits")]
    public Limits Limits { get; set; } = new();

    [JsonProperty("locationName")]
    public string LocationName { get; set; } = string.Empty;

    [JsonProperty("manualCoverAttachment")]
    
    public bool ManualCoverAttachment { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("shortLink")]
    public string ShortLink { get; set; } = string.Empty;

    [JsonProperty("shortUrl")]
    public string ShortUrl { get; set; } = string.Empty;

    [JsonProperty("subscribed")]
    public bool Subscribed { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    [JsonProperty("customFieldItems")]
    public List<CustomField> CustomFieldItems { get; set; } = new();
    
    
}

public class Attachments
{
    [JsonProperty("perBoard")]
    public PerBoard PerBoard { get; set; } = new();
}

public class AttachmentsByType
{
    [JsonProperty("trello")]
    public Trello Trello { get; set; } = new();
}

public class Badges
{
    [JsonProperty("attachmentsByType")]
    public AttachmentsByType AttachmentsByType { get; set; } = new();

    [JsonProperty("location")]
    public bool Location { get; set; }

    [JsonProperty("votes")]
    public int Votes { get; set; }

    [JsonProperty("viewingMemberVoted")]
    public bool ViewingMemberVoted { get; set; }

    [JsonProperty("subscribed")]
    public bool Subscribed { get; set; }

    [JsonProperty("fogbugz")]
    public string Fogbugz { get; set; } = string.Empty;

    [JsonProperty("checkItems")]
    public int CheckItems { get; set; }

    [JsonProperty("checkItemsChecked")]
    public int CheckItemsChecked { get; set; }

    [JsonProperty("comments")]
    public int Comments { get; set; }

    [JsonProperty("attachments")]
    public int Attachments { get; set; }

    [JsonProperty("description")]
    public bool Description { get; set; }

    [JsonProperty("due")]
    public string Due { get; set; } = string.Empty;

    [JsonProperty("start")]
    public string Start { get; set; } = string.Empty;

    [JsonProperty("dueComplete")]
    public bool DueComplete { get; set; }
}

public class IdChecklist
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;
}

public class IdLabel
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("idBoard")]
    public string IdBoard { get; set; } = string.Empty;

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("color")]
    public string Color { get; set; } = string.Empty;
}

public class Limits
{
    [JsonProperty("attachments")]
    public Attachments Attachments { get; set; } = new();
}

public class PerBoard
{
    [JsonProperty("status")]
    public string Status { get; set; } = string.Empty;

    [JsonProperty("disableAt")]
    public int DisableAt { get; set; }

    [JsonProperty("warnAt")]
    public int WarnAt { get; set; }
}

public class Trello
{
    [JsonProperty("board")]
    public int Board { get; set; }

    [JsonProperty("card")]
    public int Card { get; set; }
}