using LolStatistics.DataAccess.Cache;
using LolStatistics.DataAccess.Repositories;
using LolStatistics.Model.App;
using LolStatistics.Model.Game;
using LolStatistics.Model.Participant;
using LolStatistics.WebServiceConsumers;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;

namespace LolStatistics.Reprise
{
    class Program
    {
        private static readonly SummonerRepository summonerRepository = new SummonerRepository();
        private static readonly RankedGameRepository rankedGameRepository = new RankedGameRepository();

        private static WebServiceConsumer<MatchHistory> rankedGameWebServiceConsumer = new WebServiceConsumer<MatchHistory>(ConfigurationManager.AppSettings["BaseApiUrl"], ConfigurationManager.AppSettings["SummonerHistoryUrl"]);

        //static void Main(string[] args)
        //{
        //    LolCache.Init();
        //    IList<Summoner> summoners = summonerRepository.Get();
        //    using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["CheminFichierRattrapage"]))
        //    {
        //        string currentLine = sr.ReadLine();
        //        Dictionary<string, string> parameters = new Dictionary<string, string>();
        //        while ((currentLine = sr.ReadLine()) != null)
        //        {
        //            parameters.Clear();
        //            parameters.Add("matchId", currentLine);
        //            RankedGame game = rankedGameWebServiceConsumer.Consume(parameters);
        //            if (game.Season == "SEASON2015")
        //            {
        //                foreach (ParticipantIdentity pi in game.ParticipantIdentities)
        //                {
        //                    if (!summoners.Select(sm => sm.Id).Contains(pi.Player.Id))
        //                    {
        //                        game.Participants.Remove(game.Participants.First(p => p.ParticipantId == pi.ParticipantId));
        //                    }
        //                }
        //                rankedGameRepository.Insert(game);
        //            }
        //        }
        //    }
        //}

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
                                if (!summoners.Select(sm => sm.Id).Contains(pi.Player.Id))
                                {
                                    game.Participants.Remove(game.Participants.First(p => p.ParticipantId == pi.ParticipantId));
                                }
                            }
                            rankedGameRepository.Insert(game);
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
