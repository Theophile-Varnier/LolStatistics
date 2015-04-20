using System.Data.Common;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.Game;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace LolStatistics.DataAccess.Dao
{
    /// <summary>
    /// Dao associée aux parties
    /// </summary>
    public class GameDao : BaseDao<Game>
    {
        /// <summary>
        /// Insert une partie en base
        /// </summary>
        /// <param name="game">La partie à insérer</param>
        public void Insert(Game game, DbConnection conn, DbTransaction tran)
        {
            const string cmd = "INSERT INTO GAME("
         + "CHAMPION_ID, SUMMONER_ID, CREATE_DATE, GAME_ID, "
         + "GAME_MODE, GAME_TYPE, INVALID, IP_EARNED, LEVEL, "
         + "MAP_ID, SPELL1, SPELL2, SUB_TYPE, "
         + "TEAM_ID) VALUES("
         + "@championId, @summonerId, @createDate, @gameId, "
         + "@gameMode, @gameType, @invalid, @ipEarned, @level, "
         + "@mapId, @spell1, @spell2, @subType, "
         + "@teamId)";

            // Exécution de la requête
            ExecuteNonQuery(cmd, conn, game, addParameters, tran);
        }

        /// <summary>
        /// Récupère la liste des games associées à l'utilisateur
        /// </summary>
        /// <param name="summonerId">L'id de l'utilisateur</param>
        /// <returns>La liste des parties associées au joueur</returns>
        public List<Game> GetBySummonerId(string summonerId, DbConnection conn)
        {
            const string cmd = "SELECT * FROM GAME WHERE SUMMONER_ID = @summonerId";
            return ExecuteReader(cmd, conn, summonerId, ((c, o) => c.AddWithValue("@summonerId", o)));
        }

        /// <summary>
        /// Méthode servant à ajouter les paramètres d'une requête d'insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle ajouter les paramètres</param>
        /// <param name="obj">La game d'où on tire les données</param>
        private void addParameters(Command cmd, object obj)
        {
            Game game = obj as Game;
            // Ajout des paramètres
            cmd.AddWithValue("@championId", game.ChampionId);
            cmd.AddWithValue("@summonerId", game.SummonerId);
            cmd.AddWithValue("@createDate", game.CreateDate);
            cmd.AddWithValue("@gameId", game.GameId.ToString());
            cmd.AddWithValue("@gameMode", game.GameMode);
            cmd.AddWithValue("@gameType", game.GameType);
            cmd.AddWithValue("@invalid", game.Invalid);
            cmd.AddWithValue("@ipEarned", game.IpEarned);
            cmd.AddWithValue("@level", game.Level);
            cmd.AddWithValue("@mapId", game.MapId);
            cmd.AddWithValue("@spell1", game.Spell1);
            cmd.AddWithValue("@spell2", game.Spell2);
            cmd.AddWithValue("@subType", game.SubType);
            cmd.AddWithValue("@teamId", game.TeamId);
        }

        /// <summary>
        /// Bind un objet à partir d'un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement</param>
        /// <returns>L'objet bindé</returns>
        public override Game RecordToDto(DbDataReader reader)
        {
            Game res = new Game
            {
                GameId = reader.GetInt32("GAME_ID"),
                ChampionId = reader.GetInt32("CHAMPION_ID"),
                SummonerId = long.Parse(reader.GetString("SUMMONER_ID")),
                CreateDate = long.Parse(reader.GetString("CREATE_DATE")),
                GameMode = reader.GetString("GAME_MODE"),
                GameType = reader.GetString("GAME_TYPE"),
                Invalid = reader.GetBoolean("INVALID"),
                IpEarned = reader.GetInt32("IP_EARNED"),
                Level = reader.GetInt32("LEVEL"),
                MapId = reader.GetInt32("MAP_ID"),
                Spell1 = reader.GetInt32("SPELL1"),
                Spell2 = reader.GetInt32("SPELL2"),
                SubType = reader.GetString("SUB_TYPE"),
                TeamId = reader.GetInt32("TEAM_ID")
            };

            return res;
        }
    }
}
