using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using LolStatistics.Model;
using LolStatistics.DataAccess.Exceptions;
using log4net;
using System.Collections.Generic;

namespace LolStatistics.DataAccess.Dao
{
    public class PlayerDao : BaseDao<Player>
    {
        public void Insert(Player player)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO PLAYER("
            + "GAME_ID, CHAMPION_ID, SUMMONER_ID, TEAM_ID) VALUES("
            + "@gameId, @championId, @summonerId, @teamId)";

                // Exécution de la requête
                ExecuteNonQuery(cmd, player, addParameters);
            }

        }

        public IList<Player> GetByGameId(string id)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM PLAYER WHERE GAME_ID = @gameId";

                return ExecuteReader(cmd, id, new Action<MySqlCommand,object>((c, o) => c.Parameters.AddWithValue("@gameId", o)));
            }
        }

        private void addParameters(MySqlCommand cmd, object obj)
        {
            Player player = obj as Player;

            // Ajout des paramètres
            cmd.Parameters.AddWithValue("@gameId", player.GameId);
            cmd.Parameters.AddWithValue("@championId", player.ChampionId);
            cmd.Parameters.AddWithValue("@summonerId", player.SummonerId);
            cmd.Parameters.AddWithValue("@teamId", player.TeamId);
        }

        public override Player RecordToDto(MySqlDataReader reader)
        {
            Player res = new Player();
            res.ChampionId = reader.GetInt32("CHAMPION_ID");
            res.GameId = reader.GetString("SUMMONER_ID");
            res.TeamId = reader.GetInt32("TEAM_ID");
            res.SummonerId = reader.GetInt32("SUMMONER_ID");
            return res;
        }
    }
}
