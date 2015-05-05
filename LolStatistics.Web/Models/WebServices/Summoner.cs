using Newtonsoft.Json;

namespace LolStatistics.Web.Models.WebServices
{
    [JsonObject]
    public class Summoner
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonProperty("revisionDate")]
        public long RevisionDate { get; set; }

    }
}