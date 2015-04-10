using LolStatistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LolStatistics.Web.Models.Mapper
{
    public static class GameMapper
    {
        public static GameViewModel MapToModel(Game g)
        {
            GameViewModel res = new GameViewModel();
            res.ChampionId = g.ChampionId;
            res.Win = g.Stats.Win;
            return res;
        }
    }
}