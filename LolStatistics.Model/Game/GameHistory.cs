using System.Collections.Generic;
using Newtonsoft.Json;

namespace LolStatistics.Model.Game
{
    [JsonObject]
    public class GameHistory
    {
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonProperty("games")]
        public List<Game> Games { get; set; }
    }
}
