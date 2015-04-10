using LolStatistics.Model;
using MySql.Data.MySqlClient;
using System;
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

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO GAME("
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
        }

        /// <summary>
        /// Récupère la liste des games associées à l'utilisateur
        /// </summary>
        /// <param name="summonerId">L'id de l'utilisateur</param>
        /// <returns>La liste des parties associées au joueur</returns>
        public List<Game> GetBySummonerId(string summonerId)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM GAME WHERE SUMMONER_ID = @summonerId";
                return ExecuteReader(cmd, summonerId, new Action<MySqlCommand,object>((c, o) => c.Parameters.AddWithValue("@summonerId", o)));
            }
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
            Game res = new Game();

            // Renseignement des champs
            res.GameId = reader.GetInt32("GAME_ID");
            res.ChampionId = reader.GetInt32("CHAMPION_ID");
            res.SummonerId = long.Parse(reader.GetString("SUMMONER_ID"));
            res.CreateDate = long.Parse(reader.GetString("CREATE_DATE"));
            res.GameMode = reader.GetString("GAME_MODE");
            res.GameType = reader.GetString("GAME_TYPE");
            res.Invalid = reader.GetBoolean("INVALID");
            res.IpEarned = reader.GetInt32("IP_EARNED");
            res.Level = reader.GetInt32("LEVEL");
            res.MapId = reader.GetInt32("MAP_ID");
            res.Spell1 = reader.GetInt32("SPELL1");
            res.Spell2 = reader.GetInt32("SPELL2");
            res.SubType = reader.GetString("SUB_TYPE");
            res.TeamId = reader.GetInt32("TEAM_ID");

            return res;
        }
    }
}
