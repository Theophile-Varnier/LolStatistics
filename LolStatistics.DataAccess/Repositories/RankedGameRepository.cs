using log4net;
using LolStatistics.DataAccess.Dao;
using LolStatistics.Log;
using LolStatistics.Model.Dto;
using LolStatistics.Model.Game;
using LolStatistics.Model.Mappers;
using LolStatistics.Model.Participant;
using System;
using System.Globalization;

namespace LolStatistics.DataAccess.Repositories
{
    /// <summary>
    /// Repository associé aux parties classées
    /// </summary>
    public class RankedGameRepository: IRepository<RankedGame>
    {
        private static readonly ILog logger = Logger.GetLogger(typeof(RankedGameRepository));

        private readonly RankedGameDao rankedGameDao = new RankedGameDao();
        private readonly ParticipantDao participantDao = new ParticipantDao();
        private readonly ParticipantStatsDao participantStatsDao = new ParticipantStatsDao();
        private readonly ParticipantTimelineDataDao participantTimelineDataDao = new ParticipantTimelineDataDao();

        /// <summary>
        /// Insertion d'une partie classée
        /// </summary>
        /// <param name="t">La partie classée à insérer</param>
        public void Insert(RankedGame t)
        {
            logger.Debug("Insertion de la partie");
            rankedGameDao.Insert(t);

            logger.Debug("Insertion des participants");
            foreach (Participant participant in t.Participants)
            {
                // Code à déplacer dans un mapper ?
                participant.MatchId = t.MatchId.ToString(CultureInfo.InvariantCulture);
                participant.ParticipantId = Guid.NewGuid().ToString();

                // Récupération du dto
                ParticipantDto participantDto = ParticipantMapper.Map(participant);

                // Insertion en base
                participantDao.Insert(participantDto);
                participant.Stats.ParticipantId = participant.ParticipantId;
                participantStatsDao.Insert(participant.Stats);
                participant.Timeline.ParticipantId = participant.ParticipantId;

                // On renseigne les id des timeline data
                logger.Debug("Insertion des timeline data");

                foreach (ParticipantTimelineData timelineData in participantDto.TimelineDatas)
                {
                    participantTimelineDataDao.Insert(timelineData);
                }
            }
        }

        /// <summary>
        /// Récupération en base depuis un id
        /// </summary>
        /// <param name="id">L'id de la partie classée à récupérer</param>
        /// <returns></returns>
        public RankedGame GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
