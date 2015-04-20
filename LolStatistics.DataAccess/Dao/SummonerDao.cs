using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.App;
using LolStatistics.Model.Dto;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;

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
        /// <param name="conn">La connexion à utiliser</param>
        /// <param name="tran">La transaction à utiliser</param>
        public void Insert(Summoner summoner, DbConnection conn, DbTransaction tran)
        {
            const string cmd = "INSERT INTO SUMMONER("
            + "ID, NAME, PROFILE_ICON_ID, REVISION_DATE) VALUES("
            + "@id, @name, @profileIconId, @revisionDate)";

            // Exécution de la requête
            ExecuteNonQuery(cmd, conn, summoner, addParameters, tran);

        }

        /// <summary>
        /// Insert un membre d'une team
        /// </summary>
        /// <param name="summonerId">L'id du summoner</param>
        /// <param name="teamId">L'id de la team</param>
        /// <param name="conn">La connexion à utiliser</param>
        /// <param name="tran">La transaction à utiliser</param>
        public void InsertTeamMember(long summonerId, long teamId, DbConnection conn, DbTransaction tran)
        {
            TeamMemberDto dto = new TeamMemberDto
            {
                SummonerId = summonerId,
                TeamId = teamId
            };
            const string cmd = "INSERT INTO RANKED_TEAM_MEMBER(TEAM_ID, MEMBER_ID) VALUES(" +
                               "@teamId, @memberId)";
            ExecuteNonQuery(cmd, conn, dto, AddTeamMemberParameters, tran);
        }

        /// <summary>
        /// Méthode d'ajout des paramètres pour la requête d'insertion
        /// d'un membre de team
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="o"></param>
        private void AddTeamMemberParameters(Command cmd, object o)
        {
            TeamMemberDto dto = o as TeamMemberDto;

            if (dto == null) return;

            cmd.AddWithValue("@teamId", dto.TeamId);
            cmd.AddWithValue("@memberId", dto.SummonerId);
        }

        /// <summary>
        /// Map un objet depuis un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement à mapper</param>
        /// <returns>L'objet mappé</returns>
        public override Summoner RecordToDto(DbDataReader reader)
        {
            Summoner res = new Summoner
            {
                Id = reader.GetInt64("ID"), 
                Name = reader.GetString("NAME"), 
                ProfileIconId = reader.GetInt32("PROFILE_ICON_ID"), 
                RevisionDate = reader.GetInt64("REVISION_DATE")
            };

            // Renseignement des champs

            return res;
        }

        /// <summary>
        /// Méthode d'ajout des paramètres pour la requête d'insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle on ajoute les paramètres</param>
        /// <param name="obj">L'objet qui contient les informations</param>
        private void addParameters(Command cmd, Object obj)
        {
            Summoner summoner = obj as Summoner;

            // Ajout des paramètres
            if (summoner == null) return;

            cmd.AddWithValue("@id", summoner.Id.ToString(CultureInfo.InvariantCulture));
            cmd.AddWithValue("@name", summoner.Name);
            cmd.AddWithValue("@profileIconId", summoner.ProfileIconId);
            cmd.AddWithValue("@revisionDate", summoner.RevisionDate);
        }

        /// <summary>
        /// Récupère l'ensemble des membres
        /// </summary>
        /// <returns>La liste des membres</returns>
        public IList<Summoner> Get(DbConnection conn)
        {
            const string cmd = "SELECT * FROM SUMMONER";
            return ExecuteReader(cmd, conn);
        }

        /// <summary>
        /// Récupère la liste des membres d'une team
        /// </summary>
        /// <param name="teamId">L'id de la team</param>
        /// <param name="conn">La connection à utiliser</param>
        /// <returns></returns>
        public IList<Summoner> GetTeamMembers(long teamId, DbConnection conn)
        {
            const string cmd = "SELECT ID, NAME, PROFILE_ICON_ID, REVISION_DATE FROM SUMMONER WHERE ID IN" +
                               "(" +
                               "SELECT MEMBER_ID FROM RANKED_TEAM_MEMBER WHERE TEAM_ID = @teamId" +
                               ")";

            return ExecuteReader(cmd, conn, teamId, (c, obj) => c.AddWithValue("@teamId", obj));
        }
    }
}
