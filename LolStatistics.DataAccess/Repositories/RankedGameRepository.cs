using log4net;
using LolStatistics.DataAccess.Dao;
using LolStatistics.Model;
using LolStatistics.Model.Dto;
using System;

namespace LolStatistics.DataAccess.Repositories
{
    public class RankedGameRepository: IRepository<RankedGame>
    {
        private static readonly ILog logger = Logger.GetLogger(typeof(RankedGameRepository));

        private readonly RankedGameDao rankedGameDao = new RankedGameDao();
        private readonly ParticipantDao participantDao = new ParticipantDao();
        private readonly ParticipantStatsDao participantStatsDao = new ParticipantStatsDao();
        private readonly ParticipantTimelineDataDao participantTimelineDataDao = new ParticipantTimelineDataDao();

        public void Map(RankedGame t)
        {
            logger.Debug("Insertion de la partie");
            rankedGameDao.Insert(t);
            logger.Debug("Insertion des participants");
            foreach (Participant participant in t.Participants)
            {
                participant.MatchId = t.MatchId.ToString();
                participant.ParticipantId = Guid.NewGuid().ToString();
                ParticipantDto participantDto = ParticipantRepository.Map(participant);
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


        public RankedGame UnMap(string id)
        {
            throw new NotImplementedException();
        }
    }
}
