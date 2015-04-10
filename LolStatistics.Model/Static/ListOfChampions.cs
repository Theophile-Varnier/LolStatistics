using Newtonsoft.Json;
using System.Collections.Generic;

namespace LolStatistics.Model.Static
{
    [JsonObject]
    public class ListOfChampions
    {
        [JsonProperty("data")]
        public Dictionary<string, Champion> Champions { get; set; }
    }
}
