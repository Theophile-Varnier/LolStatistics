using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace LolStatistics.Model
{
    [DataContract]
    public class RankedGame
    {
        [IgnoreDataMember]
        public string SummonerId { get; set; }

        [DataMember(Name = "mapId")]
        public int MapId { get; set; }

        [DataMember(Name = "matchCreation")]
        public long MatchCreation { get; set; }

        [DataMember(Name = "matchDuration")]
        public long MatchDuration { get; set; }

        [DataMember(Name = "matchId")]
        public long MatchId { get; set; }

        [DataMember(Name = "matchMode")]
        public string MatchMode { get; set; }

        [DataMember(Name = "matchType")]
        public string MatchType { get; set; }

        [DataMember(Name = "matchVersion")]
        public string MatchVersion { get; set; }

        [DataMember(Name = "participants")]
        public List<Participant> Participants { get; set; }

        [DataMember(Name = "platformId")]
        public string PlatformId { get; set; }

        [DataMember(Name = "queueType")]
        public string QueueType { get; set; }

        [DataMember(Name = "region")]
        public string Region { get; set; }

        [DataMember(Name = "season")]
        public string Season { get; set; }

    }
}
