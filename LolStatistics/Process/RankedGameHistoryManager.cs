using log4net;
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
    /// Gestionnaire d'historique de parties classées
    /// </summary>
    public class RankedGameHistoryManager : IManager
    {
        private static readonly ILog logger = Logger.GetLogger(typeof(RankedGameHistoryManager));

        private readonly WebServiceConsumer<MatchHistory> matchHistoryWebServiceConsumer;

        private readonly RankedGameRepository rankedGameRepository = new RankedGameRepository();

        private readonly SummonerRepository summonerRepository = new SummonerRepository();

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public RankedGameHistoryManager()
        {
            matchHistoryWebServiceConsumer = new WebServiceConsumer<MatchHistory>(ConfigurationManager.AppSettings["BaseApiUrl"], ConfigurationManager.AppSettings["RankedGameUrl"]);
        }

        /// <summary>
        /// Fonction principale
        /// </summary>
        public void Execute()
        {
            logger.Info("Démarrage du traitement des historiques de parties classées");
            // Récupération de l'ensemble des membres
            IList<Summoner> summoners = summonerRepository.Get();

            foreach (Summoner summoner in summoners)
            {
                // Paramètres du web service
                Dictionary<string, string> uriParams = new Dictionary<string, string> { { "SummonerId", summoner.Id.ToString(CultureInfo.InvariantCulture) } };

                logger.Info("Récupération de l'historique des parties pour l'invocateur " + summoner.Name);
                MatchHistory mh = matchHistoryWebServiceConsumer.Consume(uriParams);
                if (mh != null)
                {
                    // Insertion des parties classées
                    foreach (RankedGame rg in mh.Matches)
                    {
                        rg.SummonerId = summoner.Id.ToString(CultureInfo.InvariantCulture);
                        rankedGameRepository.Insert(rg);
                    }
                }
            }
            logger.Info("Fin du traitement des historiques de parties classées");
        }
    }
}
