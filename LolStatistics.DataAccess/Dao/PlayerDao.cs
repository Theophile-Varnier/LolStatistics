using LolStatistics.Model.Participant;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace LolStatistics.DataAccess.Dao
{
    /// <summary>
    /// Dao associée aux joueurs
    /// </summary>
    public class PlayerDao : BaseDao<Player>
    {

        /// <summary>
        /// Insert un joueur en base
        /// </summary>
        /// <param name="player">Le joueur à insérer</param>
        public void Insert(Player player)
        {
            const string cmd = "INSERT INTO PLAYER("
                               + "GAME_ID, CHAMPION_ID, SUMMONER_ID, TEAM_ID) VALUES("
                               + "@gameId, @championId, @summonerId, @teamId)";

            // Exécution de la requête
            ExecuteNonQuery(cmd, player, addParameters);
        }

        /// <summary>
        /// Récupère les joueurs d'une partie
        /// </summary>
        /// <param name="id">L'id de la partie</param>
        /// <returns></returns>
        public IList<Player> GetByGameId(string id)
        {
            const string cmd = "SELECT * FROM PLAYER WHERE GAME_ID = @gameId";

            return ExecuteReader(cmd, id, ((c, o) => c.Parameters.AddWithValue("@gameId", o)));
        }

        /// <summary>
        /// Méthode d'ajout des paramètres pour la requête d'insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle on ajoute les paramètres</param>
        /// <param name="obj">L'objet qui contient les informations</param>
        private void addParameters(MySqlCommand cmd, object obj)
        {
            Player player = obj as Player;

            // Ajout des paramètres
            cmd.Parameters.AddWithValue("@gameId", player.GameId);
            cmd.Parameters.AddWithValue("@championId", player.ChampionId);
            cmd.Parameters.AddWithValue("@summonerId", player.SummonerId);
            cmd.Parameters.AddWithValue("@teamId", player.TeamId);
        }

        /// <summary>
        /// Map un objet depuis un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement à mapper</param>
        /// <returns>L'objet mappé</returns>
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
