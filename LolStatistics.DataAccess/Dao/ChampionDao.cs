using LolStatistics.Model.Static;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LolStatistics.DataAccess.Dao
{
    /// <summary>
    /// Dao associée aux champions
    /// </summary>
    public class ChampionDao : BaseDao<Champion>
    {
        /// <summary>
        /// Insert un champion en base
        /// </summary>
        /// <param name="champion">Le champion à insérer</param>
        public void Insert(Champion champion)
        {
            const string cmd = "INSERT INTO CHAMPION("
        + "ID, TITLE, NAME, KY) VALUES("
        + "@id, @title, @name, @key)";

            // Exécution de la requête
            ExecuteNonQuery(cmd, champion, AddParameters);

        }

        /// <summary>
        /// Récupère un objet à partir d'un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement</param>
        /// <returns>Le champion bindé</returns>
        public override Champion RecordToDto(MySqlDataReader reader)
        {
            Champion res = new Champion
            {
                Id = reader.GetInt32("ID"), 
                Title = reader.GetString("TITLE"), 
                Name = reader.GetString("NAME"), 
                Key = reader.GetString("KY")
            };

            // Renseignement des champs

            return res;
        }

        /// <summary>
        /// Récupère tous les champions enregistrés
        /// </summary>
        /// <returns>La liste des champions connus</returns>
        public List<Champion> GetAllChampions()
        {
            const string cmd = "SELECT * FROM CHAMPION";
            return ExecuteReader(cmd);
        }

        /// <summary>
        /// Méthode d'ajout de paramètres pour une insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle on ajoute les paramètres</param>
        /// <param name="obj">L'objet servant à ajouter les paramètres</param>
        private void AddParameters(MySqlCommand cmd, Object obj)
        {
            Champion champion = obj as Champion;

            // Ajout des paramètres
            cmd.Parameters.AddWithValue("@id", champion.Id);
            cmd.Parameters.AddWithValue("@title", champion.Title);
            cmd.Parameters.AddWithValue("@name", champion.Name);
            cmd.Parameters.AddWithValue("@key", champion.Key);

        }
    }
}
