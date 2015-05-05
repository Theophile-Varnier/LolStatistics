using LolStatistics.Model.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace LolStatistics.Model.App
{
    [JsonObject]
    public class League
    {
        [JsonProperty("queue")]
        public string Queue { get; set; }

        [JsonProperty("entries")]
        public List<LeagueEntry> Entries { get; set; }

        [JsonProperty("tier")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Pallier Tier { get; set; }
    }
}
