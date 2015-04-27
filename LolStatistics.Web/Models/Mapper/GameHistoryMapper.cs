using System.Collections.Generic;
using LolStatistics.Model;
using LolStatistics.Model.Game;
using LolStatistics.Model.Participant;

namespace LolStatistics.Web.Models.Mapper
{
    public static class GameHistoryMapper
    {
        public static GameHistoryViewModel MapToModel(IList<Participant> gh)
        {
            GameHistoryViewModel res = new GameHistoryViewModel();
            foreach (Participant game in gh)
            {
                res.Games.Add(GameMapper.MapToModel(game));
            }

            return res;
        }
    }
}