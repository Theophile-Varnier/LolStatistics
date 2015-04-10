using System.Globalization;
using LolStatistics.DataAccess.Dao;
using LolStatistics.Model.Game;
using System;
using System.Collections.Generic;

namespace LolStatistics.DataAccess.Repositories
{
    /// <summary>
    /// Repository associé aux historiques de parties
    /// </summary>
    public class GameHistoryRepository : IRepository<GameHistory>
    {
        /// <summary>
        /// Insertion d'un historique
        /// </summary>
        /// <param name="t">Historique à insérer</param>
        public void Map(GameHistory t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Récupération en base de l'historique d'un membre
        /// </summary>
        /// <param name="id">L'id du membre</param>
        /// <returns>L'historique du membre</returns>
        public GameHistory UnMap(string id)
        {
            GameDao gameDao = new GameDao();
            RawStatsDao rawStatsDao = new RawStatsDao();
            PlayerDao playerDao = new PlayerDao();
            GameHistory res = new GameHistory
            {
                Games = new List<Game>(), 
                SummonerId = long.Parse(id)
            };

            // Récupération de toutes les parties du membre
            IList<Game> games = gameDao.GetBySummonerId(id);

            foreach (Game game in games)
            {
                // Récupération des statistiques
                game.Stats = rawStatsDao.GetByGameId(game.GameId.ToString(CultureInfo.InvariantCulture));

                // Récupération des autres joueurs
                game.FellowPlayers = playerDao.GetByGameId(game.GameId.ToString(CultureInfo.InvariantCulture));
                res.Games.Add(game);
            }
            return res;
        }
    }
}
