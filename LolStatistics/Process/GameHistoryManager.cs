using log4net;
using LolStatistics.DataAccess.Dao;
using LolStatistics.DataAccess.Repositories;
using LolStatistics.Model;
using LolStatistics.WebServiceConsumers;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Timers;

namespace LolStatistics.Process
{
    public class GameHistoryManager
    {
        private static readonly ILog logger = Logger.GetLogger(typeof(GameHistoryManager));

        private GameRepository gameDbMapper = new GameRepository();
        private SummonerDao summonerDao = new SummonerDao();

        //private static List<string> recordedQueue = new List<string> { 
        //        "NORMAL",
        //        "RANKED_SOLO_5x5",
        //        "ARAM_UNRANKED_5x5",
        //        "RANKED_PREMADE_5x5",
        //        "RANKED_TEAM_5x5",
        //        "CAP_5x5"
        //    };

        private WebServiceConsumer<GameHistory> gameHistoryWebServiceConsumer;

        public GameHistoryManager()
        {
            gameHistoryWebServiceConsumer = new WebServiceConsumer<GameHistory>(ConfigurationManager.AppSettings["SimpleGameUrl"]);
        }

        public void Execute()
        {
            IList<Summoner> summoners = summonerDao.Get();
            foreach (Summoner summoner in summoners)
            {
                Dictionary<string, string> uriParams = new Dictionary<string, string>();
                uriParams.Add("SummonerId", summoner.Id.ToString());
                logger.Info("Récupération de l'historique des parties pour l'invocateur " + summoner.Name);
                GameHistory gh = gameHistoryWebServiceConsumer.Consume(uriParams);
                if (gh != null)
                {
                    foreach (Game game in gh.Games)
                    {
                        game.SummonerId = gh.SummonerId;
                        gameDbMapper.Map(game);
                    }
                }
            }
        }
    }
}
