using LolStatistics.Model;
using LolStatistics.Model.Dto;
using MySql.Data.MySqlClient;
using System;

namespace LolStatistics.DataAccess.Dao
{
    public class ParticipantDao : BaseDao<ParticipantDto>
    {
        public void Insert(ParticipantDto participant)
        {

            // Création de la requête
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO PARTICIPANT("
            + "MATCH_ID, CHAMPION_ID, HIGHEST_ACHIEVED_SEASON_TIER, PARTICIPANT_ID, SPELL1_ID, "
            + "SPELL2_ID, TEAM_ID, LANE, ROLE) VALUES("
            + "@matchId, @championId, @highestAchievedSeasonTier, @participantId, @spell1Id, "
            + "@spell2Id, @teamId, @lane, @role)";

                // Exécution de la requête
                ExecuteNonQuery(cmd, participant, addParameters);
            }

        }
        public override ParticipantDto RecordToDto(MySqlDataReader reader)
        {
            ParticipantDto res = new ParticipantDto();

            // Renseignement des champs
            res.MatchId = reader.GetString("MATCH_ID");
            res.ChampionId = reader.GetInt32("CHAMPION_ID");
            res.HighestAchievedSeasonTier = reader.GetString("HIGHEST_ACHIEVED_SEASON_TIER");
            res.ParticipantId = reader.GetString("PARTICIPANT_ID");
            res.Spell1Id = reader.GetInt32("SPELL1_ID");
            res.Spell2Id = reader.GetInt32("SPELL2_ID");
            res.TeamId = reader.GetInt32("TEAM_ID");
            res.Lane = reader.GetString("LANE");
            res.Role = reader.GetString("ROLE");

            return res;

        }
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
