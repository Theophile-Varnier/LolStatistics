using LolStatistics.Model.Stats;
using System.Runtime.Serialization;

namespace LolStatistics.Model.Participant
{
    [DataContract]
    public class Participant
    {
        [IgnoreDataMember]
        public string MatchId { get; set; }

        [DataMember(Name = "championId")]
        public int ChampionId { get; set; }

        [DataMember(Name = "highestAchievedSeasonTier")]
        public string HighestAchievedSeasonTier { get; set; }

        [IgnoreDataMember]
        public string ParticipantId { get; set; }

        [DataMember(Name = "spell1Id")]
        public int Spell1Id { get; set; }

        [DataMember(Name = "spell2Id")]
        public int Spell2Id { get; set; }

        [DataMember(Name = "stats")]
        public ParticipantStats Stats { get; set; }

        [DataMember(Name = "teamId")]
        public int TeamId { get; set; }

        [DataMember(Name = "timeline")]
        public ParticipantTimeline Timeline { get; set; }

    }
}
