using log4net;
using LolStatistics.DataAccess.Dao;
using LolStatistics.DataAccess.Repositories;
using LolStatistics.Log;
using LolStatistics.Model.App;
using LolStatistics.Model.Game;
using LolStatistics.WebServiceConsumers;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;

namespace LolStatistics.Process
{
    /// <summary>
    /// Gestionnaire d'historique de parties
    /// </summary>
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

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public GameHistoryManager()
        {
            gameHistoryWebServiceConsumer = new WebServiceConsumer<GameHistory>(ConfigurationManager.AppSettings["BaseApiUrl"], ConfigurationManager.AppSettings["SimpleGameUrl"]);
        }

        /// <summary>
        /// Fonction principale
        /// </summary>
        public void Execute()
        {
            // Récupération des membres
            IList<Summoner> summoners = summonerDao.Get();
            foreach (Summoner summoner in summoners)
            {
                // Paramètres du web service
                Dictionary<string, string> uriParams = new Dictionary<string, string> {{"SummonerId", summoner.Id.ToString(CultureInfo.InvariantCulture)}};
                logger.Info("Récupération de l'historique des parties pour l'invocateur " + summoner.Name);
                GameHistory gh = gameHistoryWebServiceConsumer.Consume(uriParams);

                if (gh != null)
                {
                    // Insertion des parties en base
                    foreach (Game game in gh.Games)
                    {
                        game.SummonerId = gh.SummonerId;
                        gameDbMapper.Insert(game);
                    }
                }
            }
        }
    }
}
