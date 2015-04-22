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

        private static WebServiceConsumer<RankedGame> rankedGameWebServiceConsumer = new WebServiceConsumer<RankedGame>(ConfigurationManager.AppSettings["BaseApiUrl"], ConfigurationManager.AppSettings["RankedGameUrl"]);

        static void Main(string[] args)
        {
            IList<Summoner> summoners = summonerRepository.Get();
            using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["CheminFichierRattrapage"]))
            {
                string currentLine = sr.ReadLine();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                while ((currentLine = sr.ReadLine()) != null)
                {
                    parameters.Clear();
                    parameters.Add("matchId", currentLine);
                    RankedGame game = rankedGameWebServiceConsumer.Consume(parameters);
                    foreach (ParticipantIdentity pi in game.ParticipantIdentities)
                    {
                        if (!summoners.Select(sm => sm.Id).Contains(pi.Player.Id))
                        {
                            game.Participants.Remove(game.Participants.First(p => p.ParticipantId == pi.ParticipantId));
                        }
                        else
                        {
                            rankedGameRepository.Insert(game);
                        }
                    }
                }
            }
        }
    }
}
