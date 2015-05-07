using LolStatistics.DataAccess.Dao;
using LolStatistics.DataAccess.Exceptions;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.Game;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;

namespace LolStatistics.DataAccess.Repositories
{
    /// <summary>
    /// Repository associé aux historiques de parties
    /// </summary>
    public class GameHistoryRepository : IRepository<GameHistory>
    {

        private GameDao gameDao = new GameDao();
        private RawStatsDao rawStatsDao = new RawStatsDao();
        private PlayerDao playerDao = new PlayerDao();

        /// <summary>
        /// Insertion d'un historique
        /// </summary>
        /// <param name="t">Historique à insérer</param>
        public bool Insert(GameHistory t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Récupération en base de l'historique d'un membre
        /// </summary>
        /// <param name="id">L'id du membre</param>
        /// <returns>L'historique du membre</returns>
        public GameHistory GetById(long id)
        {
            using (DbConnection conn = Command.GetConnexion())
            {
                try
                {
                    conn.Open();
                    GameHistory res = new GameHistory
                    {
                        Games = new List<Game>(),
                        SummonerId = id
                    };

                    // Récupération de toutes les parties du membre
                    IList<Game> games = gameDao.GetBySummonerId(id, conn);

                    foreach (Game game in games)
                    {
                        // Récupération des statistiques
                        game.Stats = rawStatsDao.GetByGameAndSummonerId(game.GameId.ToString(CultureInfo.InvariantCulture), res.SummonerId, conn);

                        // Récupération des autres joueurs
                        game.FellowPlayers = playerDao.GetByGameId(game.GameId.ToString(CultureInfo.InvariantCulture), conn);
                        res.Games.Add(game);
                    }
                    return res;
                }
                catch (DaoException e)
                {
                    return new GameHistory();
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
