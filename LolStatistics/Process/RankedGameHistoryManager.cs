﻿using System.Globalization;
using log4net;
using LolStatistics.DataAccess.Dao;
using LolStatistics.DataAccess.Repositories;
using LolStatistics.Model.App;
using LolStatistics.Model.Game;
using LolStatistics.WebServiceConsumers;
using System.Collections.Generic;
using System.Configuration;

namespace LolStatistics.Process
{
    /// <summary>
    /// Gestionnaire d'historique de parties classées
    /// </summary>
    public class RankedGameHistoryManager
    {
        private static readonly ILog logger = Logger.Logger.GetLogger(typeof(RankedGameHistoryManager));

        private WebServiceConsumer<MatchHistory> matchHistoryWebServiceConsumer;

        private readonly RankedGameRepository rankedGameRepository = new RankedGameRepository();

        private readonly SummonerDao summonerDao = new SummonerDao();

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
            // Récupération de l'ensemble des membres
            IList<Summoner> summoners = summonerDao.Get();

            foreach (Summoner summoner in summoners)
            {
                // Paramètres du web service
                Dictionary<string, string> uriParams = new Dictionary<string, string> {{"SummonerId", summoner.Id.ToString(CultureInfo.InvariantCulture)}};

                logger.Info("Récupération de l'historique des parties pour l'invocateur " + summoner.Name);
                MatchHistory mh = matchHistoryWebServiceConsumer.Consume(uriParams);
                if (mh != null)
                {
                    // Insertion des parties classées
                    foreach (RankedGame rg in mh.Matches)
                    {
                        rg.SummonerId = summoner.Id.ToString(CultureInfo.InvariantCulture);
                        rankedGameRepository.Map(rg);
                    }
                }
            }
        }
    }
}
