using System.Collections.Generic;
using LolStatistics.DataAccess.Dao;
using LolStatistics.Model.Static;

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
            ChampionDao championDao = new ChampionDao();
            List<Champion> temp = championDao.GetAllChampions();

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