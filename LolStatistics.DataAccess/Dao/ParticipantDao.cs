using LolStatistics.Model.Dto;
using MySql.Data.MySqlClient;
using System;

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
        public void Insert(ParticipantDto participant)
        {
            const string cmd = "INSERT INTO PARTICIPANT("
            + "MATCH_ID, CHAMPION_ID, HIGHEST_ACHIEVED_SEASON_TIER, PARTICIPANT_ID, SPELL1_ID, "
            + "SPELL2_ID, TEAM_ID, LANE, ROLE) VALUES("
            + "@matchId, @championId, @highestAchievedSeasonTier, @participantId, @spell1Id, "
            + "@spell2Id, @teamId, @lane, @role)";

            // Exécution de la requête
            ExecuteNonQuery(cmd, participant, addParameters);

        }

        /// <summary>
        /// Map un objet depuis un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement à mapper</param>
        /// <returns></returns>
        public override ParticipantDto RecordToDto(MySqlDataReader reader)
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
        public void addParameters(MySqlCommand cmd, Object obj)
        {
            ParticipantDto participant = obj as ParticipantDto;

            // Ajout des paramètres
            cmd.Parameters.AddWithValue("@matchId", participant.MatchId);
            cmd.Parameters.AddWithValue("@championId", participant.ChampionId);
            cmd.Parameters.AddWithValue("@highestAchievedSeasonTier", participant.HighestAchievedSeasonTier);
            cmd.Parameters.AddWithValue("@participantId", participant.ParticipantId.ToString());
            cmd.Parameters.AddWithValue("@spell1Id", participant.Spell1Id);
            cmd.Parameters.AddWithValue("@spell2Id", participant.Spell2Id);
            cmd.Parameters.AddWithValue("@teamId", participant.TeamId);
            cmd.Parameters.AddWithValue("@lane", participant.Lane);
            cmd.Parameters.AddWithValue("@role", participant.Role);

        }
    }
}
