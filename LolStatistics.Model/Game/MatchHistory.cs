using System.Collections.Generic;
using Newtonsoft.Json;

namespace LolStatistics.Model.Game
{
    [JsonObject]
    public class MatchHistory
    {
        [JsonProperty("matches")]
        public List<RankedGame> Matches { get; set; }
    }
}
