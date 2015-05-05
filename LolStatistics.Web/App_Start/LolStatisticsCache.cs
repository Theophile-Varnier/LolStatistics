using LolStatistics.DataAccess.Repositories;
using LolStatistics.Model.Static;
using LolStatistics.Web.Helpers;
using LolStatistics.Web.Models.WebServices;
using System.Collections.Generic;

namespace LolStatistics.Web
{
    public static class LolStatisticsCache
    {
        private static Dictionary<int, Champion> Champions;

        private static Dictionary<string, RankedTeam> RankedTeams;

        private static Dictionary<string, List<string>> RankedTeamsForSummoner;

        private static Dictionary<long, string> SummonersName; 

        public static bool IsInitialized { get; set; }

        /// <summary>
        /// Initialisation du cache
        /// </summary>
        public static void Init()
        {
            RankedTeams = new Dictionary<string, RankedTeam>();
            RankedTeamsForSummoner = new Dictionary<string, List<string>>();
            Champions = new Dictionary<int, Champion>();
            SummonersName = new Dictionary<long, string>();
            ChampionRepository championRepository = new ChampionRepository();
            List<Champion> temp = championRepository.GetAllChampions();

            foreach (Champion champion in temp)
            {
                Champions.Add(champion.Id, champion);
            }
            IsInitialized = true;
        }

        /// <summary>
        /// Accède à un champion à partir de son Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Champion Champion(int id)
        {
            return Champions.GetOrDefault(id);
        }

        /// <summary>
        /// Ajoute une team ranked à l'ensemble des teams connues
        /// </summary>
        /// <param name="teamName">Le nom de la team</param>
        /// <param name="team">Les paramètres de la team</param>
        public static void AddTeam(string teamName, RankedTeam team)
        {
            if (!RankedTeams.ContainsKey(teamName))
            {
                RankedTeams.Add(teamName, team);
            }
        }

        /// <summary>
        /// Récupère une team si elle est déjà connue
        /// </summary>
        /// <param name="teamName"></param>
        /// <returns></returns>
        public static RankedTeam GetTeam(string teamName)
        {
            return RankedTeams.GetOrDefault(teamName);
        }

        /// <summary>
        /// Ajoute une team ranked à l'ensemble des teams connues
        /// </summary>
        /// <param name="summonerName">Le nom de la team</param>
        /// <param name="teamName">Les paramètres de la team</param>
        public static void AddTeamForSummoner(string summonerName, string teamName)
        {
            if (!RankedTeamsForSummoner.ContainsKey(summonerName))
            {
                RankedTeamsForSummoner.Add(summonerName, new List<string> { teamName });
            }
            else if(!RankedTeamsForSummoner[summonerName].Contains(teamName))
            {
                RankedTeamsForSummoner[summonerName].Add(teamName);
            }
        }

        /// <summary>
        /// Récupère une team d'un invocateur si elle est déjà connue
        /// </summary>
        /// <param name="summonerName"></param>
        /// <returns></returns>
        public static List<string> GetTeamsForSummoner(string summonerName)
        {
            return RankedTeamsForSummoner.GetOrDefault(summonerName);
        }

        /// <summary>
        /// Récupère le nom d'un invocateur connu par son id
        /// </summary>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        public static string GetSummonerName(long summonerId)
        {
            return SummonersName.GetOrDefault(summonerId);
        }

        /// <summary>
        /// Ajoute une association id->nom
        /// </summary>
        /// <param name="summonerId"></param>
        /// <param name="summonerName"></param>
        public static void AddSummonerName(long summonerId, string summonerName)
        {
            if (!SummonersName.ContainsKey(summonerId))
            {
                SummonersName.Add(summonerId, summonerName);
            }
        }
    }
}