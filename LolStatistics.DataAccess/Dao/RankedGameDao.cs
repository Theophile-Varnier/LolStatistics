using LolStatistics.Model.Game;
using MySql.Data.MySqlClient;
using System;

namespace LolStatistics.DataAccess.Dao
{
    public class RankedGameDao : BaseDao<RankedGame>
    {
        public void Insert(RankedGame rankedGame)
        {

            // Création de la requête
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO RANKED_GAME("
            + "SUMMONER_ID, MAP_ID, MATCH_CREATION, MATCH_DURATION, MATCH_ID, MATCH_MODE, "
            + "MATCH_TYPE, MATCH_VERSION, PLATFORM_ID, QUEUE_TYPE, REGION, "
            + "SEASON) VALUES("
            + "@summonerId, @mapId, @matchCreation, @matchDuration, @matchId, @matchMode, "
            + "@matchType, @matchVersion, @platformId, @queueType, @region, "
            + "@season)";

                // Exécution de la requête
                ExecuteNonQuery(cmd, rankedGame, addParameters);
            }

        }
        public override RankedGame RecordToDto(MySqlDataReader reader)
        {
            RankedGame res = new RankedGame();

            // Renseignement des champs
            res.SummonerId = reader.GetString("SUMMONER_ID");
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
        public void addParameters(MySqlCommand cmd, Object obj)
        {
            RankedGame rankedGame = obj as RankedGame;

            // Ajout des paramètres
            cmd.Parameters.AddWithValue("@summonerId", rankedGame.SummonerId);
            cmd.Parameters.AddWithValue("@mapId", rankedGame.MapId);
            cmd.Parameters.AddWithValue("@matchCreation", rankedGame.MatchCreation);
            cmd.Parameters.AddWithValue("@matchDuration", rankedGame.MatchDuration);
            cmd.Parameters.AddWithValue("@matchId", rankedGame.MatchId.ToString());
            cmd.Parameters.AddWithValue("@matchMode", rankedGame.MatchMode);
            cmd.Parameters.AddWithValue("@matchType", rankedGame.MatchType);
            cmd.Parameters.AddWithValue("@matchVersion", rankedGame.MatchVersion);
            cmd.Parameters.AddWithValue("@platformId", rankedGame.PlatformId);
            cmd.Parameters.AddWithValue("@queueType", rankedGame.QueueType);
            cmd.Parameters.AddWithValue("@region", rankedGame.Region);
            cmd.Parameters.AddWithValue("@season", rankedGame.Season);

        }
    }
}
