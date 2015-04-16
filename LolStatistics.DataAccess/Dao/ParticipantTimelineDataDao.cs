using LolStatistics.Model.Participant;
using MySql.Data.MySqlClient;
using System;

namespace LolStatistics.DataAccess.Dao
{
    /// <summary>
    /// Dao associée aux timeline datas
    /// </summary>
    public class ParticipantTimelineDataDao : BaseDao<ParticipantTimelineData>
    {
        /// <summary>
        /// Insert une timeline en base
        /// </summary>
        /// <param name="participantTimelineData">La timeline à insérer</param>
        public void Insert(ParticipantTimelineData participantTimelineData)
        {

            const string cmd = "INSERT INTO PARTICIPANT_TIMELINE_DATA("
            + "PARTICIPANT_ID, NAME, TEN_TO_TWENTY, THIRTY_TO_END, TWENTY_TO_THIRTY, ZERO_TO_TEN) VALUES("
            + "@participantId, @name, @tenToTwenty, @thirtyToEnd, @twentyToThirty, @zeroToTen)";

                // Exécution de la requête
                ExecuteNonQuery(cmd, participantTimelineData, addParameters);

        }

        /// <summary>
        /// Map un objet depuis un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement à mapper</param>
        /// <returns>L'objet mappé</returns>
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

        /// <summary>
        /// Méthode d'ajout des paramètres pour la requête d'insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle on ajoute les paramètres</param>
        /// <param name="obj">L'objet qui contient les informations</param>
        private void addParameters(MySqlCommand cmd, Object obj)
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
