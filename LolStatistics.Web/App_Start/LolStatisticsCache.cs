using LolStatistics.DataAccess.Repositories;
using LolStatistics.Model.Static;
using System.Collections.Generic;

namespace LolStatistics.Web
{
    public static class LolStatisticsCache
    {
        private static Dictionary<int, Champion> Champions;

        /// <summary>
        /// Initialisation du cache
        /// </summary>
        public static void Init()
        {
            Champions = new Dictionary<int, Champion>();
            ChampionRepository championRepository = new ChampionRepository();
            List<Champion> temp = championRepository.GetAllChampions();

            foreach (Champion champion in temp)
            {
                Champions.Add(champion.Id, champion);
            }
        }

        /// <summary>
        /// Accède à un champion à partir de son Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Champion Champion(int id)
        {
            return Champions[id];
        }
    }
}