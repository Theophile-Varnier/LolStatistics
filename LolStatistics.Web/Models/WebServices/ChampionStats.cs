using Newtonsoft.Json;

namespace LolStatistics.Web.Models.WebServices
{
    [JsonObject]
    public class ChampionStats
    {
        [JsonProperty("id")]
        public int ChampionId { get; set; }

        [JsonProperty("stats")]
        public ChampionStatisticsViewModel Stats { get; set; }
    }
}