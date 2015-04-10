using LolStatistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LolStatistics.Web.Models.Mapper
{
    public static class GameHistoryMapper
    {
        public static GameHistoryViewModel MapToModel(GameHistory gh)
        {
            GameHistoryViewModel res = new GameHistoryViewModel();
            res.SummonerId = gh.SummonerId;
            foreach (Game game in gh.Games)
            {
                res.Games.Add(GameMapper.MapToModel(game));
            }

            return res;
        }
    }
}