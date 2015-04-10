using LolStatistics.DataAccess.Dao;
using LolStatistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolStatistics.DataAccess.Repositories
{
    public class GameHistoryRepository : IRepository<GameHistory>
    {

        public void Map(GameHistory t)
        {
            throw new NotImplementedException();
        }

        public GameHistory UnMap(string id)
        {
            GameDao gameDao = new GameDao();
            RawStatsDao rawStatsDao = new RawStatsDao();
            PlayerDao playerDao = new PlayerDao();
            GameHistory res = new GameHistory();

            res.Games = new List<Game>();
            res.SummonerId = long.Parse(id);
            IList<Game> games = gameDao.GetBySummonerId(id);

            foreach (Game game in games)
            {
                game.Stats = rawStatsDao.GetByGameID(game.GameId.ToString());
                game.FellowPlayers = playerDao.GetByGameId(game.GameId.ToString());
                res.Games.Add(game);
            }
            return res;
        }
    }
}
