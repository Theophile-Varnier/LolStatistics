using System.Data.Common;
using System.Globalization;
using LolStatistics.DataAccess.Dao;
using LolStatistics.Model.Game;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using LolStatistics.DataAccess.Extensions;

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
        public void Insert(GameHistory t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Récupération en base de l'historique d'un membre
        /// </summary>
        /// <param name="id">L'id du membre</param>
        /// <returns>L'historique du membre</returns>
        public GameHistory GetById(string id)
        {
            using (DbConnection conn = Command.GetConnexion())
            {
                try
                {
                    conn.Open();
                    GameHistory res = new GameHistory
                    {
                        Games = new List<Game>(),
                        SummonerId = long.Parse(id)
                    };

                    // Récupération de toutes les parties du membre
                    IList<Game> games = gameDao.GetBySummonerId(id, conn);

                    foreach (Game game in games)
                    {
                        // Récupération des statistiques
                        game.Stats = rawStatsDao.GetByGameId(game.GameId.ToString(CultureInfo.InvariantCulture), conn);

                        // Récupération des autres joueurs
                        game.FellowPlayers = playerDao.GetByGameId(game.GameId.ToString(CultureInfo.InvariantCulture), conn);
                        res.Games.Add(game);
                    }
                    return res;
                }
                catch (DbException e)
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
