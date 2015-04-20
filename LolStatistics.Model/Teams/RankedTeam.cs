using LolStatistics.Model.App;
using System.Collections.Generic;

namespace LolStatistics.Model.Teams
{
    public class RankedTeam
    {
        public string Name { get; set; }

        public long Id { get; set; }

        public IList<Summoner> Membres { get; set; }

        public Dictionary<long, RankedTeamHistory> Historique { get; set; }
    }
}
