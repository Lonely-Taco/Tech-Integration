using Newtonsoft.Json;

namespace TechIntegration.Core.Models;

 public class Card
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("badges")]
        public Badges Badges { get; set; }

        [JsonProperty("checkItemStates")]
        public List<string> CheckItemStates { get; set; }

        [JsonProperty("closed")]
        public bool Closed { get; set; }

        [JsonProperty("coordinates")]
        public string Coordinates { get; set; }

        [JsonProperty("creationMethod")]
        public string CreationMethod { get; set; }

        [JsonProperty("dateLastActivity")]
        public DateTime DateLastActivity { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }
        
        [JsonProperty("due")]
        public string Due { get; set; }

        [JsonProperty("dueReminder")]
        public string DueReminder { get; set; }

        [JsonProperty("idBoard")]
        public string IdBoard { get; set; }

        [JsonProperty("idChecklists")]
        public List<IdChecklist> IdChecklists { get; set; }

        [JsonProperty("idLabels")]
        public List<IdLabel> IdLabels { get; set; }

        [JsonProperty("idList")]
        public string IdList { get; set; }

        [JsonProperty("idMembers")]
        public List<string> IdMembers { get; set; }

        [JsonProperty("idMembersVoted")]
        public List<string> IdMembersVoted { get; set; }

        [JsonProperty("idShort")]
        public int IdShort { get; set; }

        [JsonProperty("labels")]
        public List<string> Labels { get; set; }

        [JsonProperty("limits")]
        public Limits Limits { get; set; }

        [JsonProperty("locationName")]
        public string LocationName { get; set; }

        [JsonProperty("manualCoverAttachment")]
        public bool ManualCoverAttachment { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pos")]
        public int Pos { get; set; }

        [JsonProperty("shortLink")]
        public string ShortLink { get; set; }

        [JsonProperty("shortUrl")]
        public string ShortUrl { get; set; }

        [JsonProperty("subscribed")]
        public bool Subscribed { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Attachments
    {
        [JsonProperty("perBoard")]
        public PerBoard PerBoard { get; set; }
    }

    public class AttachmentsByType
    {
        [JsonProperty("trello")]
        public Trello Trello { get; set; }
    }

    public class Badges
    {
        [JsonProperty("attachmentsByType")]
        public AttachmentsByType AttachmentsByType { get; set; }

        [JsonProperty("location")]
        public bool Location { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }

        [JsonProperty("viewingMemberVoted")]
        public bool ViewingMemberVoted { get; set; }

        [JsonProperty("subscribed")]
        public bool Subscribed { get; set; }

        [JsonProperty("fogbugz")]
        public string Fogbugz { get; set; }

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
        public string Due { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("dueComplete")]
        public bool DueComplete { get; set; }
    }

    public class IdChecklist
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class IdLabel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("idBoard")]
        public string IdBoard { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
   


    public class Limits
    {
        [JsonProperty("attachments")]
        public Attachments Attachments { get; set; }
    }

    public class PerBoard
    {
        [JsonProperty("status")]
        public string Status { get; set; }

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

