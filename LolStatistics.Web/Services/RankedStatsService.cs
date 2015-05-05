using LolStatistics.Model.Game;
using LolStatistics.Model.Participant;
using LolStatistics.Web.Models;
using LolStatistics.Web.Models.Mapper;
using LolStatistics.Web.Models.WebServices;
using LolStatistics.WebServiceConsumers;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace LolStatistics.Web.Services
{
    public class RankedStatsService
    {
        /// <summary>
        /// Récupère les statistiques de la saison d'un invocateur
        /// </summary>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        public TeamStalkerViewModel GetStatsForSummoner(long summonerId)
        {
            IList<Participant> participations = GetSummonerHistory(summonerId);

            TeamStalkerViewModel res = StatisticsMapper.MapToTeamModel(participations);

            res.Name = GetSummonerName(summonerId);

            return res;
        }

        /// <summary>
        /// Récupère l'ensemble des stats de la saison d'un invocateur
        /// </summary>
        /// <param name="summonerId">L'id de l'invocateur dont on veut récupérer les stats</param>
        /// <returns></returns>
        private IList<Participant> GetSummonerHistory(long summonerId)
        {
            List<Participant> participations = new List<Participant>();
            WebServiceConsumer<MatchHistory> rankedGameWebServiceConsumer = new WebServiceConsumer<MatchHistory>(ConfigurationManager.AppSettings["BaseUri"], ConfigurationManager.AppSettings["SummonerHistoryUrl"]);
            MatchHistory games;
            Dictionary<string, string> parameters = new Dictionary<string, string> { { "summonerId", summonerId.ToString(CultureInfo.InvariantCulture) } };
            int beginIndex = 0;
            parameters.Add("beginIndex", beginIndex.ToString(CultureInfo.InvariantCulture));
            parameters.Add("endIndex", (beginIndex + 14).ToString(CultureInfo.InvariantCulture));

            // Tant qu'il y a des parties, on les récupère
            while ((games = rankedGameWebServiceConsumer.Consume(parameters)).Matches != null)
            {
                foreach (RankedGame game in games.Matches)
                {
                    // On récupère seulement les parties de la saison qui nous intéresse
                    // TODO: Saison actuelle à paramétrer en base
                    if (game.Season == "SEASON2015")
                    {
                        // On garde seulement notre invocateur
                        foreach (ParticipantIdentity pi in game.ParticipantIdentities)
                        {
                            if (pi.Player.Id != summonerId)
                            {
                                game.Participants.Remove(game.Participants.First(p => p.ParticipantId == pi.ParticipantId));
                            }
                        }
                        participations.AddRange(game.Participants);
                    }
                }
                // On passe à la page suivante
                beginIndex += 15;
                parameters["beginIndex"] = (beginIndex).ToString(CultureInfo.InvariantCulture);
                parameters["endIndex"] = (beginIndex + 14).ToString(CultureInfo.InvariantCulture);
            }
            return participations;
        }

        /// <summary>
        /// Récupère le nom d'un invocateur à l'aide de son id
        /// Via le cache si on le connaît
        /// Via un web service sinon
        /// </summary>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        private string GetSummonerName(long summonerId)
        {
            string summonerName = LolStatisticsCache.GetSummonerName(summonerId);
            if (summonerName != null)
            {
                return summonerName;
            }

            WebServiceConsumer<Summoners> summonerWebServiceConsumer = new WebServiceConsumer<Summoners>(ConfigurationManager.AppSettings["BaseUri"], ConfigurationManager.AppSettings["SummonerByIdApi"]);
            Dictionary<string, string> parametres = new Dictionary<string, string> { { "summonerIds", summonerId.ToString(CultureInfo.InvariantCulture) } };
            Summoners current = summonerWebServiceConsumer.Consume(parametres);
            string name = current.First().Value.Name;
            LolStatisticsCache.AddSummonerName(summonerId, name);
            return name;
        }
    }
}