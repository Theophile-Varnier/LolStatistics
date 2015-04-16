using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolStatistics.DataAccess.Dao;
using LolStatistics.Model.Static;
using LolStatistics.WebServiceConsumers;

namespace LolStatistics.Process
{
    public class ChampionManager : IManager
    {

        private readonly WebServiceConsumer<ListOfChampions> webServiceConsummer = new WebServiceConsumer<ListOfChampions>(ConfigurationManager.AppSettings["GlobalApiUrl"], ConfigurationManager.AppSettings["ChampionsUri"]);
        private readonly ChampionDao championDao = new ChampionDao();

        public void Execute()
        {
            // Récupération des champions
            ListOfChampions champions = webServiceConsummer.Consume();

            // Insertion en base
            foreach (string key in champions.Champions.Keys)
            {
                championDao.Insert(champions.Champions[key]);
            }
        }
    }
}
