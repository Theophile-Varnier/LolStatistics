using log4net;
using LolStatistics.DataAccess.Dao;
using LolStatistics.Log;
using LolStatistics.Model.Game;
using LolStatistics.Model.Participant;
using System;
using System.Globalization;

namespace LolStatistics.DataAccess.Repositories
{
    /// <summary>
    /// Repository associé aux parties
    /// </summary>
    public class GameRepository: IRepository<Game>
    {
        private static readonly ILog logger = Logger.GetLogger(typeof(GameRepository));

        private GameDao gameDao = new GameDao();
        private RawStatsDao rawStatsDao = new RawStatsDao();
        private PlayerDao playerDao = new PlayerDao();

        /// <summary>
        /// Insertion d'une partie
        /// </summary>
        /// <param name="game">Partie à insérer</param>
        public void Insert(Game game)
        {
            gameDao.Insert(game);
            logger.Info("Insertion des statistiques");
            game.Stats.GameId = game.GameId.ToString(CultureInfo.InvariantCulture);
            rawStatsDao.Insert(game.Stats);
            logger.Info("Insertion des joueurs");
            foreach (Player player in game.FellowPlayers)
            {
                player.GameId = game.GameId.ToString();
                playerDao.Insert(player);
            }
        }

        /// <summary>
        /// Récupération en base depuis un id
        /// </summary>
        /// <param name="id">L'id de la partie à récupérer</param>
        /// <returns></returns>
        public Game GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
