using LolStatistics.Model;
using LolStatistics.Model.Game;

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