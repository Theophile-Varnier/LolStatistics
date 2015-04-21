using System.Collections.Generic;
using LolStatistics.Model.Participant;

namespace LolStatistics.Model.Dto
{
    public class ParticipantDto
    {
        public long MatchId { get; set; }

        public int ChampionId { get; set; }

        public string HighestAchievedSeasonTier { get; set; }

        public long ParticipantId { get; set; }

        public int Spell1Id { get; set; }

        public int Spell2Id { get; set; }

        public int TeamId { get; set; }

        public IList<ParticipantTimelineData> TimelineDatas { get; set; }

        public string Lane { get; set; }

        public string Role { get; set; }
    }
}
