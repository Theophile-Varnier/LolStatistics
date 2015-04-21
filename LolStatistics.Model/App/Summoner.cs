using Newtonsoft.Json;

namespace LolStatistics.Model.App
{
    [JsonObject]
    public class Summoner
    {
        [JsonProperty("summonerId")]
        public long Id { get; set; }

        [JsonProperty("summonerName")]
        public string Name { get; set; }

        [JsonProperty("profileIcon")]
        public int ProfileIconId { get; set; }

        [JsonProperty("revisionDate")]
        public long RevisionDate { get; set; }

    }
}
