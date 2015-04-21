using System.Collections.Generic;
using LolStatistics.Model.Participant;
using Newtonsoft.Json;

namespace LolStatistics.Model.Game
{
    [JsonObject]
    public class RankedGame
    {
        [JsonProperty("mapId")]
        public int MapId { get; set; }

        [JsonProperty("matchCreation")]
        public long MatchCreation { get; set; }

        [JsonProperty("matchDuration")]
        public long MatchDuration { get; set; }

        [JsonProperty("matchId")]
        public long MatchId { get; set; }

        [JsonProperty("matchMode")]
        public string MatchMode { get; set; }

        [JsonProperty("matchType")]
        public string MatchType { get; set; }

        [JsonProperty("matchVersion")]
        public string MatchVersion { get; set; }

        [JsonProperty("participants")]
        public List<Participant.Participant> Participants { get; set; }

        [JsonProperty("participantIdentities")]
        public List<ParticipantIdentity> ParticipantIdentities { get; set; }
        
        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        [JsonProperty("queueType")]
        public string QueueType { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

    }
}
