using System.Collections.Generic;
using LolStatistics.Model.Dto;

namespace LolStatistics.Model.Teams
{
    public class RankedTeamHistory
    {
        public IList<Participant.Participant> Participants { get; set; }

        public RankedTeamHistory()
        {
            Participants = new List<Participant.Participant>();
        }
    }
}
