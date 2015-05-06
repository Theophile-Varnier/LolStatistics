using LolStatistics.Model.App;
using LolStatistics.Web.Models;
using LolStatistics.Web.Models.WebServices;
using LolStatistics.WebServiceConsumers;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace LolStatistics.Web.Services
{
    public class RankedStatsService
    {
        /// <summary>
        /// Récupère les statistiques de la saison d'un invocateur
        /// </summary>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        public TeamStalkerViewModel GetStatsForSummoner(long summonerId)
        {
            // TODO: Saison actuelle à paramétrer en base
            TeamStalkerViewModel res = GetRankedStats(summonerId);

            res.Name = LolStatisticsCache.GetSummonerName(summonerId);

            res.LeagueInfo = GetSummonerLeagueEntry(summonerId);

            return res;
        }

        /// <summary>
        /// Récupère les ranked stats d'un invocateur sur la saison en cours
        /// </summary>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        private TeamStalkerViewModel GetRankedStats(long summonerId)
        {
            WebServiceConsumer<TeamStalkerViewModel> webServiceConsumer = new WebServiceConsumer<TeamStalkerViewModel>(ConfigurationManager.AppSettings["BaseUri"], ConfigurationManager.AppSettings["SummonerRankedStats"]);
            Dictionary<string, string> parameters = new Dictionary<string, string> { { "summonerId", summonerId.ToString(CultureInfo.InvariantCulture) } };
            TeamStalkerViewModel res = webServiceConsumer.Consume(parameters);
            return res ?? new TeamStalkerViewModel(summonerId);
        }

        /// <summary>
        /// Récupère les informations de league d'un invocateur
        /// </summary>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        private LeagueEntry GetSummonerLeagueEntry(long summonerId)
        {
            WebServiceConsumer<LeagueInfo> webServiceConsumer = new WebServiceConsumer<LeagueInfo>(ConfigurationManager.AppSettings["BaseUri"], ConfigurationManager.AppSettings["LeagueInfoApi"]);
            Dictionary<string, string> parameters = new Dictionary<string, string> { { "summonerId", summonerId.ToString(CultureInfo.InvariantCulture) } };
            LeagueInfo infos = webServiceConsumer.Consume(parameters);
            LeagueEntry res = new LeagueEntry();
            if (infos != null)
            {
                List<League> leagues = infos.FirstOrDefault().Value;
                if (leagues != null && leagues.Any())
                {
                    League entry = leagues.FirstOrDefault(l => l.Queue == "RANKED_SOLO_5x5");
                    if (entry != null)
                    {
                        res.Tier = entry.Tier;
                        LeagueEntry defaut = entry.Entries.FirstOrDefault(v => v.Id == summonerId.ToString(CultureInfo.InvariantCulture));
                        if (defaut != null)
                        {
                            res.Division = defaut.Division;
                            res.LeaguePoints = defaut.LeaguePoints;
                        }
                    }
                }
            }
            return res;
        }
    }
}