using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LolStatistics.Web.Models
{
    public class TeamStalkerViewModel
    {
        IList<ChampionStatisticsViewModel> Membres { get; set; }
    }
}