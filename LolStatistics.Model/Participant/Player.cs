using Newtonsoft.Json;

namespace LolStatistics.Model.Participant
{
    [JsonObject]
    public class Player
    {
        [JsonIgnore]
        public string GameId { get; set; }

        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }
    }
}