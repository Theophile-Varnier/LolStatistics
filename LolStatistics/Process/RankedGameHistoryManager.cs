using log4net;
using LolStatistics.DataAccess.Dao;
using LolStatistics.DataAccess.Repositories;
using LolStatistics.Model;
using LolStatistics.WebServiceConsumers;
using System.Collections.Generic;
using System.Configuration;

namespace LolStatistics.Process
{
    class RankedGameHistoryManager
    {
        private static readonly ILog logger = Logger.GetLogger(typeof(RankedGameHistoryManager));

        private WebServiceConsumer<MatchHistory> matchHistoryWebServiceConsumer;

        private readonly RankedGameRepository rankedGameDbMapper = new RankedGameRepository();

        private readonly SummonerDao summonerDao = new SummonerDao();

        public RankedGameHistoryManager()
        {
            matchHistoryWebServiceConsumer = new WebServiceConsumer<MatchHistory>(ConfigurationManager.AppSettings["RankedGameUrl"]);
        }

        public void Execute()
        {
            IList<Summoner> summoners = summonerDao.Get();
            foreach (Summoner summoner in summoners)
            {
                Dictionary<string, string> uriParams = new Dictionary<string, string>();
                uriParams.Add("SummonerId", summoner.Id.ToString());
                logger.Info("Récupération de l'historique des parties pour l'invocateur " + summoner.Name);
                MatchHistory mh = matchHistoryWebServiceConsumer.Consume(uriParams);
                if (mh != null)
                {
                    foreach (RankedGame rg in mh.Matches)
                    {
                        rg.SummonerId = summoner.Id.ToString();
                        rankedGameDbMapper.Map(rg);
                    }
                }
            }
        }
    }
}
