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

            // Création de la requête
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO CHAMPION("
            + "ID, TITLE, NAME, KY) VALUES("
            + "@id, @title, @name, @key)";

                // Exécution de la requête
                ExecuteNonQuery(cmd, champion, addParameters);
            }

        }

        /// <summary>
        /// Récupère un objet à partir d'un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement</param>
        /// <returns>Le champion bindé</returns>
        public override Champion RecordToDto(MySqlDataReader reader)
        {
            Champion res = new Champion();

            // Renseignement des champs
            res.Id = reader.GetInt32("ID");
            res.Title = reader.GetString("TITLE");
            res.Name = reader.GetString("NAME");
            res.Key = reader.GetString("KY");

            return res;
        }

        /// <summary>
        /// Récupère tous les champions enregistrés
        /// </summary>
        /// <returns>La liste des champions connus</returns>
        public List<Champion> GetAllChampions()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM CHAMPION";
                return ExecuteReader(cmd, null, null);
            }
        }

        /// <summary>
        /// Méthode d'ajout de paramètres pour une insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle on ajoute les paramètres</param>
        /// <param name="obj">L'objet servant à ajouter les paramètres</param>
        public void addParameters(MySqlCommand cmd, Object obj)
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
