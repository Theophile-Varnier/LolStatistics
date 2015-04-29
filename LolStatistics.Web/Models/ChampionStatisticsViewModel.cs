﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LolStatistics.Web.Models
{
    public class ChampionStatisticsViewModel
    {
        public int Wins { get; set; }

        public int Loses { get; set; }

        public int TotalGames
        {
            get { return Wins + Loses; }
        }

        public long Kills { get; set; }

        public long Deaths { get; set; }

        public long Assists { get; set; }

        public double KDA
        {
            get { return Math.Round((Kills + Assists) / (Deaths * 1.0), 2); }
        }

        public long TotalTimePlayed { get; set; }

        public long CreepScore { get; set; }
    }
}