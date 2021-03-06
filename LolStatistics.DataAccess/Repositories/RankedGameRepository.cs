﻿using log4net;
using LolStatistics.DataAccess.Cache;
using LolStatistics.DataAccess.Dao;
using LolStatistics.DataAccess.Exceptions;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Log;
using LolStatistics.Model.Dto;
using LolStatistics.Model.Game;
using LolStatistics.Model.Mappers;
using LolStatistics.Model.Participant;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace LolStatistics.DataAccess.Repositories
{
    /// <summary>
    /// Repository associé aux parties classées
    /// </summary>
    public class RankedGameRepository : IRepository<RankedGame>
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
        public bool Insert(RankedGame t)
        {
            bool res = false;
            using (DbConnection conn = Command.GetConnexion())
            {
                conn.Open();
                using (DbTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (LolCache.UseCache && LolCache.RegisteredGames.Contains(t.MatchId))
                        {
                            logger.Info(string.Format("Partie {0} déjà enregistrée -> ignorée", t.MatchId));
                        }
                        else
                        {
                            logger.Debug("Insertion de la partie");
                            rankedGameDao.Insert(t, conn, tran);
                            LolCache.RegisteredGames.Add(t.MatchId);
                        }

                        logger.Debug("Insertion des participants");
                        foreach (Participant participant in t.Participants)
                        {
                            participant.MatchId = t.MatchId;
                            participant.ParticipantId = t.ParticipantIdentities.First(pi => pi.ParticipantId == participant.ParticipantId).Player.Id;

                            // Récupération du dto
                            ParticipantDto participantDto = ParticipantMapper.Map(participant);

                            if (LolCache.UseCache && LolCache.RegisteredStats.Any( s => s.Equals(new Tuple<long, long>(participantDto.MatchId, participantDto.ParticipantId))))
                            {
                                logger.Info(string.Format("Participant {0}/{1} déjà enregistré -> ignoré", participantDto.MatchId, participantDto.ParticipantId));
                            }
                            else
                            {
                                // On renvoie true si au moins une donnée a été insérée
                                res = true;

                                // Insertion en base
                                participantDao.Insert(participantDto, conn, tran);
                                participant.Stats.ParticipantId = participant.ParticipantId;
                                participant.Stats.MatchId = participant.MatchId;
                                participantStatsDao.Insert(participant.Stats, conn, tran);

                                // On insert les timeline data
                                logger.Debug("Insertion des timeline data");

                                foreach (ParticipantTimelineData timelineData in participantDto.TimelineDatas)
                                {
                                    participantTimelineDataDao.Insert(timelineData, conn, tran);
                                }
                                LolCache.RegisteredStats.Add(new Tuple<long, long>(participantDto.MatchId, participantDto.ParticipantId));
                            }
                        }
                        tran.Commit();
                        return res;
                    }
                    catch (DaoException e)
                    {
                        tran.Rollback();
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Récupération en base depuis un id
        /// </summary>
        /// <param name="id">L'id de la partie classée à récupérer</param>
        /// <returns></returns>
        public RankedGame GetById(long id)
        {
            using (DbConnection conn = Command.GetConnexion())
            {
                try
                {
                    conn.Open();
                    return rankedGameDao.GetMatchStatistics(id, conn);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Récupère la liste des parties classées enregistrées
        /// </summary>
        /// <returns></returns>
        public IList<RankedGame> GetAllGames()
        {
            using (DbConnection conn = Command.GetConnexion())
            {
                try
                {
                    conn.Open();
                    return rankedGameDao.GetAllMatches(conn);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Récupère la liste des participants enregistrés
        /// </summary>
        /// <returns></returns>
        public IList<ParticipantDto> GetAllParticipants()
        {
            using (DbConnection conn = Command.GetConnexion())
            {
                try
                {
                    conn.Open();
                    return participantDao.GetAllParticipants(conn);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public IList<Participant> GetStatsForSummoner(long summonerId)
        {
            IList<Participant> res = new List<Participant>();
            using (DbConnection conn = Command.GetConnexion())
            {
                try
                {
                    conn.Open();
                    IList<ParticipantDto> participations = participantDao.GetSummonerParticipations(summonerId, conn);

                    foreach (ParticipantDto participation in participations)
                    {
                        Participant participant = ParticipantMapper.UnMap(participation);
                        participant.Stats = participantStatsDao.GetStats(participation.MatchId, participation.ParticipantId, conn);
                        res.Add(participant);
                    }

                    return res;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
