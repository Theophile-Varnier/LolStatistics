using System.Collections.Generic;

namespace LolStatistics.Web.Models
{
    public class StatisticsViewModel
    {
        public Dictionary<string, ChampionStatisticsViewModel> ChampionStatistics { get; set; }

        public StatisticsViewModel()
        {
            ChampionStatistics = new Dictionary<string, ChampionStatisticsViewModel>();
        }
    }
}