using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using LolStatistics.Model;
using LolStatistics.DataAccess.Exceptions;

namespace LolStatistics.DataAccess.Dao
{
    public class ParticipantTimelineDataDao : BaseDao<ParticipantTimelineData>
    {
        public void Insert(ParticipantTimelineData participantTimelineData)
        {

            // Création de la requête
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO PARTICIPANT_TIMELINE_DATA("
            + "PARTICIPANT_ID, NAME, TEN_TO_TWENTY, THIRTY_TO_END, TWENTY_TO_THIRTY, ZERO_TO_TEN) VALUES("
            + "@participantId, @name, @tenToTwenty, @thirtyToEnd, @twentyToThirty, @zeroToTen)";

                // Exécution de la requête
                ExecuteNonQuery(cmd, participantTimelineData, addParameters);
            }

        }
        public override ParticipantTimelineData RecordToDto(MySqlDataReader reader)
        {
            ParticipantTimelineData res = new ParticipantTimelineData();

            // Renseignement des champs
            res.ParticipantId = reader.GetString("PARTICIPANT_ID");
            res.TenToTwenty = reader.GetDouble("TEN_TO_TWENTY");
            res.ThirtyToEnd = reader.GetDouble("THIRTY_TO_END");
            res.TwentyToThirty = reader.GetDouble("TWENTY_TO_THIRTY");
            res.ZeroToTen = reader.GetDouble("ZERO_TO_TEN");

            return res;

        }
        public void addParameters(MySqlCommand cmd, Object obj)
        {
            ParticipantTimelineData participantTimelineData = obj as ParticipantTimelineData;

            // Ajout des paramètres
            cmd.Parameters.AddWithValue("@participantId", participantTimelineData.ParticipantId);
            cmd.Parameters.AddWithValue("@name", participantTimelineData.Name);
            cmd.Parameters.AddWithValue("@tenToTwenty", participantTimelineData.TenToTwenty);
            cmd.Parameters.AddWithValue("@thirtyToEnd", participantTimelineData.ThirtyToEnd);
            cmd.Parameters.AddWithValue("@twentyToThirty", participantTimelineData.TwentyToThirty);
            cmd.Parameters.AddWithValue("@zeroToTen", participantTimelineData.ZeroToTen);

        }
    }
}
