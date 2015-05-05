using System.Collections.Generic;
using System.Linq;

namespace LolStatistics.Web.Models
{
    public class StatisticsViewModel
    {
        public Dictionary<string, ChampionStatisticsViewModel> ChampionStatistics { get; set; }

        public Dictionary<string, ChampionStatisticsViewModel> RoleStatistics { get; set; }

        public StatisticsViewModel()
        {
            ChampionStatistics = new Dictionary<string, ChampionStatisticsViewModel>();
            RoleStatistics = new Dictionary<string, ChampionStatisticsViewModel>();
        }
    }
}