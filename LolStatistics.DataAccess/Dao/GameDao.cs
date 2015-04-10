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
        public void Insert(Game game)
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
            ExecuteNonQuery(cmd, game, addParameters);
        }

        /// <summary>
        /// Récupère la liste des games associées à l'utilisateur
        /// </summary>
        /// <param name="summonerId">L'id de l'utilisateur</param>
        /// <returns>La liste des parties associées au joueur</returns>
        public List<Game> GetBySummonerId(string summonerId)
        {
            const string cmd = "SELECT * FROM GAME WHERE SUMMONER_ID = @summonerId";
            return ExecuteReader(cmd, summonerId, ((c, o) => c.Parameters.AddWithValue("@summonerId", o)));
        }

        /// <summary>
        /// Méthode servant à ajouter les paramètres d'une requête d'insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle ajouter les paramètres</param>
        /// <param name="obj">La game d'où on tire les données</param>
        private void addParameters(MySqlCommand cmd, object obj)
        {
            Game game = obj as Game;
            // Ajout des paramètres
            cmd.Parameters.AddWithValue("@championId", game.ChampionId);
            cmd.Parameters.AddWithValue("@summonerId", game.SummonerId);
            cmd.Parameters.AddWithValue("@createDate", game.CreateDate);
            cmd.Parameters.AddWithValue("@gameId", game.GameId.ToString());
            cmd.Parameters.AddWithValue("@gameMode", game.GameMode);
            cmd.Parameters.AddWithValue("@gameType", game.GameType);
            cmd.Parameters.AddWithValue("@invalid", game.Invalid);
            cmd.Parameters.AddWithValue("@ipEarned", game.IpEarned);
            cmd.Parameters.AddWithValue("@level", game.Level);
            cmd.Parameters.AddWithValue("@mapId", game.MapId);
            cmd.Parameters.AddWithValue("@spell1", game.Spell1);
            cmd.Parameters.AddWithValue("@spell2", game.Spell2);
            cmd.Parameters.AddWithValue("@subType", game.SubType);
            cmd.Parameters.AddWithValue("@teamId", game.TeamId);
        }

        /// <summary>
        /// Bind un objet à partir d'un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement</param>
        /// <returns>L'objet bindé</returns>
        public override Game RecordToDto(MySqlDataReader reader)
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
