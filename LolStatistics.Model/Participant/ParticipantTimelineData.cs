using Newtonsoft.Json;

namespace LolStatistics.Model.Participant
{
    [JsonObject]
    public class ParticipantTimelineData
    {
        [JsonIgnore]
        public string ParticipantId { get; set; }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonProperty("tenToTwenty")]
        public double TenToTwenty { get; set; }

        [JsonProperty("thirtyToEnd")]
        public double ThirtyToEnd { get; set; }

        [JsonProperty("twentyToThirty")]
        public double TwentyToThirty { get; set; }

        [JsonProperty("zeroToTen")]
        public double ZeroToTen { get; set; }

    }
}
