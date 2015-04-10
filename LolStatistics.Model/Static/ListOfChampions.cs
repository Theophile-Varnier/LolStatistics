using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LolStatistics.Model.Static
{
    [JsonObject]
    public class ListOfChampions
    {
        [JsonProperty("data")]
        public Dictionary<string, Champion> Champions { get; set; }
    }
}
