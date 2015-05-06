using LolStatistics.Model.Enums;
using Newtonsoft.Json;

namespace LolStatistics.Model.App
{
    [JsonObject]
    public class LeagueEntry
    {
        [JsonProperty("playerOrTeamId")]
        public string Id { get; set; }

        [JsonProperty("division")]
        public string Division { get; set; }

        [JsonProperty("leaguePoints")]
        public int LeaguePoints;

        [JsonIgnore]
        public Pallier Tier { get; set; }

    }
}
