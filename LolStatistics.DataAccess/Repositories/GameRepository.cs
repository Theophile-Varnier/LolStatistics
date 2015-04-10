using log4net;
using LolStatistics.DataAccess.Dao;
using LolStatistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolStatistics.DataAccess.Repositories
{
    public class GameRepository: IRepository<Game>
    {
        private static readonly ILog logger = Logger.GetLogger(typeof(GameRepository));

        private GameDao gameDao = new GameDao();
        private RawStatsDao rawStatsDao = new RawStatsDao();
        private PlayerDao playerDao = new PlayerDao();

        public void Map(Game game)
        {
            gameDao.Insert(game);
            logger.Info("Insertion des statistiques");
            game.Stats.GameId = game.GameId.ToString();
            rawStatsDao.Insert(game.Stats);
            logger.Info("Insertion des joueurs");
            foreach (Player player in game.FellowPlayers)
            {
                player.GameId = game.GameId.ToString();
                playerDao.Insert(player);
            }
        }


        public Game UnMap(string id)
        {
            throw new NotImplementedException();
        }
    }
}
