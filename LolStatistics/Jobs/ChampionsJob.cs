using LolStatistics.DataAccess.Dao;
using LolStatistics.Model.Static;
using LolStatistics.WebServiceConsumers;
using Quartz;
using System.Configuration;

namespace LolStatistics.Jobs
{
    /// <summary>
    /// Classe chargée de récupérer les champions
    /// Mise à jour une fois par jour
    /// </summary>
    public class ChampionsJob : IJob
    {
        private readonly WebServiceConsumer<ListOfChampions> webServiceConsummer = new WebServiceConsumer<ListOfChampions>(ConfigurationManager.AppSettings["ChampionsUri"]);
        private readonly ChampionDao championDao = new ChampionDao();

        /// <summary>
        /// Exécution du job
        /// </summary>
        /// <param name="context">Le contexte d'exécution du Job</param>
        public void Execute(IJobExecutionContext context)
        {
            // Récupération des champions
            ListOfChampions champions = webServiceConsummer.Consume(null);

            // Insertion en base
            foreach (string key in champions.Champions.Keys)
            {
                championDao.Insert(champions.Champions[key]);
            }
        }
    }
}
