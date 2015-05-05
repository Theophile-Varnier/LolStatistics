using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LolStatistics.Web.Models
{
    public class TeamStalkerViewModel
    {
        public string Name { get; set; }

        public Dictionary<string, ChampionStatisticsViewModel> ChampionStatistics { get; set; }

        public List<string> Mains
        {
            get { return ChampionStatistics.OrderByDescending(f => f.Value.TotalGames).Select(f => f.Key).ToList(); }
        }

        public TeamStalkerViewModel()
        {
            ChampionStatistics = new Dictionary<string, ChampionStatisticsViewModel>();
        }
    }
}