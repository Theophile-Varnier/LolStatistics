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
    }
}