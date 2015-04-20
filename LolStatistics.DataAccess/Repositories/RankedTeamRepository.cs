using System.Globalization;
using System.Linq;
using log4net;
using LolStatistics.DataAccess.Dao;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Log;
using LolStatistics.Model.App;
using LolStatistics.Model.Dto;
using LolStatistics.Model.Mappers;
using LolStatistics.Model.Participant;
using LolStatistics.Model.Teams;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace LolStatistics.DataAccess.Repositories
{
    public class RankedTeamRepository : IRepository<RankedTeam>
    {
        private static readonly ILog logger = Logger.GetLogger(typeof(RankedTeamRepository));

        private readonly RankedTeamDao rankedTeamDao = new RankedTeamDao();
        private readonly SummonerDao summonerDao = new SummonerDao();
        private readonly ParticipantDao participantDao = new ParticipantDao();
        private readonly ParticipantStatsDao participantStatsDao = new ParticipantStatsDao();

        public void Insert(RankedTeam t)
        {
            throw new NotImplementedException();
        }

        public RankedTeam GetById(string id)
        {
            RankedTeam res;
            using (DbConnection conn = Command.GetConnexion())
            {
                logger.Info("Récupération du nom de la team");
                res = rankedTeamDao.GetByName(id, conn);
                res.Historique = new Dictionary<long, RankedTeamHistory>();
                logger.Info("Récupération des membres de la team");
                res.Membres = summonerDao.GetTeamMembers(res.Id, conn);
                logger.Info("Récupération de l'historique des parties");
                IList<long> gamesId = rankedTeamDao.GetHistory(res.Id, conn);
                foreach (long gameId in gamesId)
                {
                    RankedTeamHistory history = new RankedTeamHistory();
                    IList<ParticipantDto> participants = participantDao.GetGameParticipants(gameId, conn);
                    foreach (ParticipantDto participant in participants)
                    {
                        Participant finalParticipant = ParticipantMapper.UnMap(participant);
                        finalParticipant.Stats = participantStatsDao.GetStats(gameId, long.Parse(participant.ParticipantId), conn);
                        // On ne récupère que les stats des membres de la team
                        if (res.Membres.Select(m => m.Id.ToString(CultureInfo.InvariantCulture)).Contains(participant.ParticipantId))
                        {
                            history.Participants.Add(finalParticipant);
                        }
                    }
                    res.Historique.Add(gameId, history);
                }
            }

            return res;
        }
    }
}
