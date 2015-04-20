using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolStatistics.DataAccess.Dao;
using LolStatistics.DataAccess.Repositories;
using LolStatistics.Model.Static;
using LolStatistics.WebServiceConsumers;

namespace LolStatistics.Process
{
    public class ChampionManager : IManager
    {

        private readonly WebServiceConsumer<ListOfChampions> webServiceConsummer = new WebServiceConsumer<ListOfChampions>(ConfigurationManager.AppSettings["GlobalApiUrl"], ConfigurationManager.AppSettings["ChampionsUri"]);
        private readonly ChampionRepository championRepository = new ChampionRepository();

        public void Execute()
        {
            // Récupération des champions
            ListOfChampions champions = webServiceConsummer.Consume();

            // Insertion en base
            foreach (string key in champions.Champions.Keys)
            {
                championRepository.Insert(champions.Champions[key]);
            }
        }
    }
}
