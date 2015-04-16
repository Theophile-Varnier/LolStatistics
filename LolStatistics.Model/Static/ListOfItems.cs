using Newtonsoft.Json;
using System.Collections.Generic;

namespace LolStatistics.Model.Static
{
    [JsonObject]
    public class ListOfItems
    {
        [JsonProperty("data")]
        public List<Item> Items { get; set; } 
    }
}
