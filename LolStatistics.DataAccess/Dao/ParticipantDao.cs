using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.Dto;
using System;
using System.Data.Common;

namespace LolStatistics.DataAccess.Dao
{
    /// <summary>
    /// Dao associée aux participants
    /// </summary>
    public class ParticipantDao : BaseDao<ParticipantDto>
    {
        /// <summary>
        /// Insertion d'un participant
        /// </summary>
        /// <param name="participant">Le participant à insérer</param>
        public void Insert(ParticipantDto participant, DbConnection conn, DbTransaction tran)
        {
            const string cmd = "INSERT INTO PARTICIPANT("
            + "MATCH_ID, CHAMPION_ID, HIGHEST_ACHIEVED_SEASON_TIER, PARTICIPANT_ID, SPELL1_ID, "
            + "SPELL2_ID, TEAM_ID, LANE, ROLE) VALUES("
            + "@matchId, @championId, @highestAchievedSeasonTier, @participantId, @spell1Id, "
            + "@spell2Id, @teamId, @lane, @role)";

            // Exécution de la requête
            ExecuteNonQuery(cmd, conn, participant, addParameters, tran);

        }

        /// <summary>
        /// Map un objet depuis un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement à mapper</param>
        /// <returns></returns>
        public override ParticipantDto RecordToDto(DbDataReader reader)
        {
            ParticipantDto res = new ParticipantDto
            {
                MatchId = reader.GetString("MATCH_ID"), 
                ChampionId = reader.GetInt32("CHAMPION_ID"), 
                HighestAchievedSeasonTier = reader.GetString("HIGHEST_ACHIEVED_SEASON_TIER"), 
                ParticipantId = reader.GetString("PARTICIPANT_ID"), 
                Spell1Id = reader.GetInt32("SPELL1_ID"), 
                Spell2Id = reader.GetInt32("SPELL2_ID"), 
                TeamId = reader.GetInt32("TEAM_ID"), 
                Lane = reader.GetString("LANE"), 
                Role = reader.GetString("ROLE")
            };

            // Renseignement des champs

            return res;

        }

        /// <summary>
        /// Méthode d'ajout des paramètres pour la requête d'insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle on ajoute les paramètres</param>
        /// <param name="obj">L'objet qui contient les informations</param>
        public void addParameters(Command cmd, Object obj)
        {
            ParticipantDto participant = obj as ParticipantDto;

            // Ajout des paramètres
            cmd.AddWithValue("@matchId", participant.MatchId);
            cmd.AddWithValue("@championId", participant.ChampionId);
            cmd.AddWithValue("@highestAchievedSeasonTier", participant.HighestAchievedSeasonTier);
            cmd.AddWithValue("@participantId", participant.ParticipantId.ToString());
            cmd.AddWithValue("@spell1Id", participant.Spell1Id);
            cmd.AddWithValue("@spell2Id", participant.Spell2Id);
            cmd.AddWithValue("@teamId", participant.TeamId);
            cmd.AddWithValue("@lane", participant.Lane);
            cmd.AddWithValue("@role", participant.Role);

        }
    }
}
