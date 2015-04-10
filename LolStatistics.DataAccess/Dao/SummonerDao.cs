using LolStatistics.Model.App;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LolStatistics.DataAccess.Dao
{
    /// <summary>
    /// Dao associée aux invocateurs (membres)
    /// </summary>
    public class SummonerDao : BaseDao<Summoner>
    {
        /// <summary>
        /// Insert un invocateur en base
        /// </summary>
        /// <param name="summoner">L'invocateur à insérer</param>
        public void Insert(Summoner summoner)
        {
            const string cmd = "INSERT INTO SUMMONER("
            + "ID, NAME, PROFILE_ICON_ID, REVISION_DATE) VALUES("
            + "@id, @name, @profileIconId, @revisionDate)";

            // Exécution de la requête
            ExecuteNonQuery(cmd, summoner, addParameters);

        }

        /// <summary>
        /// Map un objet depuis un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement à mapper</param>
        /// <returns>L'objet mappé</returns>
        public override Summoner RecordToDto(MySqlDataReader reader)
        {
            Summoner res = new Summoner();

            // Renseignement des champs
            res.Id = reader.GetInt64("ID");
            res.Name = reader.GetString("NAME");
            res.ProfileIconId = reader.GetInt32("PROFILE_ICON_ID");
            res.RevisionDate = reader.GetInt64("REVISION_DATE");

            return res;

        }

        /// <summary>
        /// Méthode d'ajout des paramètres pour la requête d'insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle on ajoute les paramètres</param>
        /// <param name="obj">L'objet qui contient les informations</param>
        private void addParameters(MySqlCommand cmd, Object obj)
        {
            Summoner summoner = obj as Summoner;

            // Ajout des paramètres
            cmd.Parameters.AddWithValue("@id", summoner.Id.ToString());
            cmd.Parameters.AddWithValue("@name", summoner.Name);
            cmd.Parameters.AddWithValue("@profileIconId", summoner.ProfileIconId);
            cmd.Parameters.AddWithValue("@revisionDate", summoner.RevisionDate);

        }

        /// <summary>
        /// Récupère l'ensemble des membres
        /// </summary>
        /// <returns>La liste des membres</returns>
        public IList<Summoner> Get()
        {
            const string cmd = "SELECT * FROM SUMMONER";
            return ExecuteReader(cmd);
        }
    }
}
