using LolStatistics.DataAccess.Cache;
using LolStatistics.DataAccess.Repositories;
using LolStatistics.Model.App;
using LolStatistics.Model.Game;
using LolStatistics.Model.Participant;
using LolStatistics.WebServiceConsumers;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace LolStatistics.Reprise
{
    class Program
    {
        private static readonly SummonerRepository summonerRepository = new SummonerRepository();
        private static readonly RankedGameRepository rankedGameRepository = new RankedGameRepository();

        private static WebServiceConsumer<MatchHistory> rankedGameWebServiceConsumer = new WebServiceConsumer<MatchHistory>(ConfigurationManager.AppSettings["BaseApiUrl"], ConfigurationManager.AppSettings["SummonerHistoryUrl"]);

        static void Main(string[] args)
        {
            LolCache.Init();
            IList<Summoner> summoners = summonerRepository.Get();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            MatchHistory games;

            foreach (Summoner summoner in summoners)
            {
                parameters.Clear();
                parameters.Add("summonerId", summoner.Id.ToString(CultureInfo.InvariantCulture));
                int beginIndex = 0;
                bool dataInserted = true;
                parameters.Add("beginIndex", beginIndex.ToString(CultureInfo.InvariantCulture));
                parameters.Add("endIndex", (beginIndex + 14).ToString(CultureInfo.InvariantCulture));

                // On continue tant qu'on a des games et qu'on insert des données
                while ((games = rankedGameWebServiceConsumer.Consume(parameters)).Matches != null && dataInserted)
                {
                    dataInserted = false;
                    foreach (RankedGame game in games.Matches)
                    {
                        if (game.Season == "SEASON2015")
                        {
                            foreach (ParticipantIdentity pi in game.ParticipantIdentities)
                            {
                                if (!summoners.Select(sm => sm.Id).Contains(pi.Player.Id))
                                {
                                    game.Participants.Remove(game.Participants.First(p => p.ParticipantId == pi.ParticipantId));
                                }
                            }
                            dataInserted |= rankedGameRepository.Insert(game);
                        }
                    }
                    beginIndex += 15;
                    parameters["beginIndex"] = (beginIndex).ToString(CultureInfo.InvariantCulture);
                    parameters["endIndex"] = (beginIndex + 14).ToString(CultureInfo.InvariantCulture);
                }
            }
        }
    }
}
