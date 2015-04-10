using LolStatistics.Model.App;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LolStatistics.DataAccess.Dao
{
    public class SummonerDao : BaseDao<Summoner>
    {
        public void Insert(Summoner summoner)
        {

            // Création de la requête
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO SUMMONER("
            + "ID, NAME, PROFILE_ICON_ID, REVISION_DATE) VALUES("
            + "@id, @name, @profileIconId, @revisionDate)";

                // Exécution de la requête
                ExecuteNonQuery(cmd, summoner, addParameters);
            }

        }
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

        public void addParameters(MySqlCommand cmd, Object obj)
        {
            Summoner summoner = obj as Summoner;

            // Ajout des paramètres
            cmd.Parameters.AddWithValue("@id", summoner.Id.ToString());
            cmd.Parameters.AddWithValue("@name", summoner.Name);
            cmd.Parameters.AddWithValue("@profileIconId", summoner.ProfileIconId);
            cmd.Parameters.AddWithValue("@revisionDate", summoner.RevisionDate);

        }

        public IList<Summoner> Get()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM SUMMONER";
                return ExecuteReader(cmd, null, null);
            }
        }
    }
}
