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
        public TeamStalkerViewModel GetStatsForSummoner(long summonerId)
        {
            List<Participant> participations = new List<Participant>();
            WebServiceConsumer<MatchHistory> rankedGameWebServiceConsumer = new WebServiceConsumer<MatchHistory>(ConfigurationManager.AppSettings["BaseUri"], ConfigurationManager.AppSettings["SummonerHistoryUrl"]);
            MatchHistory games;
            Dictionary<string, string> parameters = new Dictionary<string, string> { { "summonerId", summonerId.ToString(CultureInfo.InvariantCulture) } };
            int beginIndex = 0;
            parameters.Add("beginIndex", beginIndex.ToString(CultureInfo.InvariantCulture));
            parameters.Add("endIndex", (beginIndex + 14).ToString(CultureInfo.InvariantCulture));
            while ((games = rankedGameWebServiceConsumer.Consume(parameters)).Matches != null)
            {
                foreach (RankedGame game in games.Matches)
                {
                    if (game.Season == "SEASON2015")
                    {
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
                beginIndex += 15;
                parameters["beginIndex"] = (beginIndex).ToString(CultureInfo.InvariantCulture);
                parameters["endIndex"] = (beginIndex + 14).ToString(CultureInfo.InvariantCulture);
            }

            TeamStalkerViewModel res = StatisticsMapper.MapToTeamModel(participations);

            string summonerName = LolStatisticsCache.GetSummonerName(summonerId);
            if (summonerName != null)
            {
                res.Name = summonerName;
            }
            else
            {
                WebServiceConsumer<Summoners> summonerWebServiceConsumer = new WebServiceConsumer<Summoners>(ConfigurationManager.AppSettings["BaseUri"], ConfigurationManager.AppSettings["SummonerByIdApi"]);
                Dictionary<string, string> parametres = new Dictionary<string, string> { { "summonerIds", summonerId.ToString(CultureInfo.InvariantCulture) } };
                Summoners current = summonerWebServiceConsumer.Consume(parametres);
                res.Name = current.First().Value.Name;
                LolStatisticsCache.AddSummonerName(summonerId, res.Name);
            }

            return res;
        }
    }
}