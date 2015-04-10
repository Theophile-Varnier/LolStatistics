using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolStatistics.Model.Dto
{
    public class ParticipantDto
    {
        public string MatchId { get; set; }

        public int ChampionId { get; set; }

        public string HighestAchievedSeasonTier { get; set; }

        public string ParticipantId { get; set; }

        public int Spell1Id { get; set; }

        public int Spell2Id { get; set; }

        public int TeamId { get; set; }

        public IList<ParticipantTimelineData> TimelineDatas { get; set; }

        public string Lane { get; set; }

        public string Role { get; set; }
    }
}
