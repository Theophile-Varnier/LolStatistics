﻿using System.Data.Common;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.Participant;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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
        public void Insert(ParticipantTimelineData participantTimelineData, DbConnection conn, DbTransaction tran)
        {

            const string cmd = "INSERT INTO PARTICIPANT_TIMELINE_DATA("
            + "MATCH_ID, PARTICIPANT_ID, NAME, TEN_TO_TWENTY, THIRTY_TO_END, TWENTY_TO_THIRTY, ZERO_TO_TEN) VALUES("
            + "@matchId, @participantId, @name, @tenToTwenty, @thirtyToEnd, @twentyToThirty, @zeroToTen)";

                // Exécution de la requête
                ExecuteNonQuery(cmd, conn, participantTimelineData, addParameters, tran);

        }

        public List<ParticipantTimelineData> GetFromParticipant(long matchId, long summonerId, DbConnection conn)
        {
            const string cmd = "SELECT * FROM PARTICIPANT_TIMELINE_DATA WHERE MATCH_ID = @matchId AND PARTICIPANT_ID = @participantId";
            return ExecuteReader(cmd, conn, null, (c, o) =>
            {
                c.AddWithValue("@matchId", matchId);
                c.AddWithValue("@participantId", summonerId);
            });

        }

        /// <summary>
        /// Map un objet depuis un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement à mapper</param>
        /// <returns>L'objet mappé</returns>
        public override ParticipantTimelineData RecordToDto(DbDataReader reader)
        {
            ParticipantTimelineData res = new ParticipantTimelineData();

            // Renseignement des champs
            res.ParticipantId = reader.GetInt64("PARTICIPANT_ID");
            res.MatchId = reader.GetInt64("MATCH_ID");
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
        private void addParameters(Command cmd, Object obj)
        {
            ParticipantTimelineData participantTimelineData = obj as ParticipantTimelineData;

            // Ajout des paramètres
            cmd.AddWithValue("@participantId", participantTimelineData.ParticipantId);
            cmd.AddWithValue("@matchId", participantTimelineData.MatchId);
            cmd.AddWithValue("@name", participantTimelineData.Name);
            cmd.AddWithValue("@tenToTwenty", participantTimelineData.TenToTwenty);
            cmd.AddWithValue("@thirtyToEnd", participantTimelineData.ThirtyToEnd);
            cmd.AddWithValue("@twentyToThirty", participantTimelineData.TwentyToThirty);
            cmd.AddWithValue("@zeroToTen", participantTimelineData.ZeroToTen);

        }
    }
}
