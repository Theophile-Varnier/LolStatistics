using Newtonsoft.Json;

namespace LolStatistics.Model.Static
{
    [JsonObject]
    public class Champion
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

    }
}