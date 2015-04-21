using System.Collections;
using System.Collections.Generic;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.Game;
using System;
using System.Data.Common;

namespace LolStatistics.DataAccess.Dao
{
    /// <summary>
    /// Dao associée aux parties classées
    /// </summary>
    public class RankedGameDao : BaseDao<RankedGame>
    {
        /// <summary>
        /// Insert une partie classée en base
        /// </summary>
        /// <param name="rankedGame">La partie à insérer</param>
        /// <param name="conn">La connexion à utiliser</param>
        /// <param name="tran">La transaction à utiliser</param>
        public void Insert(RankedGame rankedGame, DbConnection conn, DbTransaction tran)
        {
            const string cmd = "INSERT INTO RANKED_GAME("
        + "MAP_ID, MATCH_CREATION, MATCH_DURATION, MATCH_ID, MATCH_MODE, "
        + "MATCH_TYPE, MATCH_VERSION, PLATFORM_ID, QUEUE_TYPE, REGION, "
        + "SEASON) VALUES("
        + "@mapId, @matchCreation, @matchDuration, @matchId, @matchMode, "
        + "@matchType, @matchVersion, @platformId, @queueType, @region, "
        + "@season)";

            // Exécution de la requête
            ExecuteNonQuery(cmd, conn, rankedGame, addParameters, tran);

        }

        public IList<RankedGame> GetMatchStatistics(long matchId, DbConnection conn)
        {
            const string cmd = "SELECT * FROM RANKED_GAME WHERE MATCH_ID = @matchId";

            return ExecuteReader(cmd, conn, matchId, (c, o) => c.AddWithValue("@matchId", o));
        }

        /// <summary>
        /// Map un objet depuis un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement à mapper</param>
        /// <returns>L'objet mappé</returns>
        public override RankedGame RecordToDto(DbDataReader reader)
        {
            RankedGame res = new RankedGame();

            // Renseignement des champs
            res.MapId = reader.GetInt32("MAP_ID");
            res.MatchCreation = reader.GetInt64("MATCH_CREATION");
            res.MatchDuration = reader.GetInt64("MATCH_DURATION");
            res.MatchId = reader.GetInt64("MATCH_ID");
            res.MatchMode = reader.GetString("MATCH_MODE");
            res.MatchType = reader.GetString("MATCH_TYPE");
            res.MatchVersion = reader.GetString("MATCH_VERSION");
            res.PlatformId = reader.GetString("PLATFORM_ID");
            res.QueueType = reader.GetString("QUEUE_TYPE");
            res.Region = reader.GetString("REGION");
            res.Season = reader.GetString("SEASON");

            return res;

        }

        /// <summary>
        /// Méthode d'ajout des paramètres pour la requête d'insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle on ajoute les paramètres</param>
        /// <param name="obj">L'objet qui contient les informations</param>
        private void addParameters(Command cmd, Object obj)
        {
            RankedGame rankedGame = obj as RankedGame;

            // Ajout des paramètres
            cmd.AddWithValue("@mapId", rankedGame.MapId);
            cmd.AddWithValue("@matchCreation", rankedGame.MatchCreation);
            cmd.AddWithValue("@matchDuration", rankedGame.MatchDuration);
            cmd.AddWithValue("@matchId", rankedGame.MatchId.ToString());
            cmd.AddWithValue("@matchMode", rankedGame.MatchMode);
            cmd.AddWithValue("@matchType", rankedGame.MatchType);
            cmd.AddWithValue("@matchVersion", rankedGame.MatchVersion);
            cmd.AddWithValue("@platformId", rankedGame.PlatformId);
            cmd.AddWithValue("@queueType", rankedGame.QueueType);
            cmd.AddWithValue("@region", rankedGame.Region);
            cmd.AddWithValue("@season", rankedGame.Season);

        }
    }
}
