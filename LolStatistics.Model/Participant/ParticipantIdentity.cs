using LolStatistics.Model.App;
using Newtonsoft.Json;

namespace LolStatistics.Model.Participant
{
    [JsonObject]
    public class ParticipantIdentity
    {
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        [JsonProperty("player")]
        public Summoner Player { get; set; }
    }
}
