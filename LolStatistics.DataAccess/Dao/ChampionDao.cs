using LolStatistics.DataAccess.Exceptions;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.Static;
using System;
using System.Collections.Generic;
using System.Data.Common;

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
        public void Insert(Champion champion, DbConnection conn, DbTransaction tran)
        {
            const string cmd = "INSERT INTO CHAMPION("
        + "ID, TITLE, NAME, KY) VALUES("
        + "@id, @title, @name, @key)";

            // Exécution de la requête
            ExecuteNonQuery(cmd, conn, champion, AddParameters, tran);

        }

        /// <summary>
        /// Récupère un objet à partir d'un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement</param>
        /// <returns>Le champion bindé</returns>
        public override Champion RecordToDto(DbDataReader reader)
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
        public List<Champion> GetAllChampions(DbConnection conn)
        {
            const string cmd = "SELECT * FROM CHAMPION";
            return ExecuteReader(cmd, conn);
        }

        /// <summary>
        /// Méthode d'ajout de paramètres pour une insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle on ajoute les paramètres</param>
        /// <param name="obj">L'objet servant à ajouter les paramètres</param>
        private void AddParameters(Command cmd, Object obj)
        {
            Champion champion = obj as Champion;

            if (champion == null) return;
            // Ajout des paramètres
            cmd.AddWithValue("@id", champion.Id);
            cmd.AddWithValue("@title", champion.Title);
            cmd.AddWithValue("@name", champion.Name);
            cmd.AddWithValue("@key", champion.Key);
        }

        /// <summary>
        /// Récupère un champion à partir de son id
        /// </summary>
        /// <param name="id">L'id du champion à récupérer</param>
        /// <param name="conn">La connexion à utiliser</param>
        /// <returns></returns>
        internal Champion GetById(long id, DbConnection conn)
        {
            const string cmd = "SELECT * FROM CHAMPION WHERE CHAMPION_ID = @championId";
            List<Champion> champions = ExecuteReader(cmd, conn, id, (command, o) => command.AddWithValue("@championId", o));
            if (champions.Count > 1)
            {
                throw new DaoException(string.Format("Plusieurs champions avec le même id ({0}) existent en base!", id));
            }
            return champions.Count == 0 ? null : champions[0];
        }
    }
}
