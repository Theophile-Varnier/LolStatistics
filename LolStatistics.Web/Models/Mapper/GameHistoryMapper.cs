using LolStatistics.Model.Participant;
using System.Collections.Generic;

namespace LolStatistics.Web.Models.Mapper
{
    public static class GameHistoryMapper
    {
        public static GameHistoryViewModel MapToModel(IList<Participant> gh)
        {
            GameHistoryViewModel res = new GameHistoryViewModel();
            res.PageNumber = gh.Count / 10 + (gh.Count % 10 == 0 ? 0 : 1);
            foreach (Participant game in gh)
            {
                res.Games.Add(GameMapper.MapToModel(game));
            }

            return res;
        }
    }
}