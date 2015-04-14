using System.Data.Common;
using LolStatistics.DataAccess.Extensions;
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
        public void Insert(Player player, DbConnection conn, DbTransaction tran)
        {
            const string cmd = "INSERT INTO PLAYER("
                               + "GAME_ID, CHAMPION_ID, SUMMONER_ID, TEAM_ID) VALUES("
                               + "@gameId, @championId, @summonerId, @teamId)";

            // Exécution de la requête
            ExecuteNonQuery(cmd, conn, player, addParameters, tran);
        }

        /// <summary>
        /// Récupère les joueurs d'une partie
        /// </summary>
        /// <param name="id">L'id de la partie</param>
        /// <returns></returns>
        public IList<Player> GetByGameId(string id, DbConnection conn)
        {
            const string cmd = "SELECT * FROM PLAYER WHERE GAME_ID = @gameId";

            return ExecuteReader(cmd, conn, id, ((c, o) => c.AddWithValue("@gameId", o)));
        }

        /// <summary>
        /// Méthode d'ajout des paramètres pour la requête d'insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle on ajoute les paramètres</param>
        /// <param name="obj">L'objet qui contient les informations</param>
        private void addParameters(DbCommand cmd, object obj)
        {
            Player player = obj as Player;

            if (player != null)
            {
                // Ajout des paramètres
                cmd.AddWithValue("@gameId", player.GameId);
                cmd.AddWithValue("@championId", player.ChampionId);
                cmd.AddWithValue("@summonerId", player.SummonerId);
                cmd.AddWithValue("@teamId", player.TeamId);
            }
        }

        /// <summary>
        /// Map un objet depuis un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement à mapper</param>
        /// <returns>L'objet mappé</returns>
        public override Player RecordToDto(DbDataReader reader)
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
