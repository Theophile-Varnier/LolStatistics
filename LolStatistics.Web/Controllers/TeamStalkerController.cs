using LolStatistics.Web.Models;
using LolStatistics.Web.Models.WebServices;
using LolStatistics.Web.Services;
using LolStatistics.WebServiceConsumers;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace LolStatistics.Web.Controllers
{
    public class TeamStalkerController : Controller
    {
        private RankedTeamService service = new RankedTeamService();
        private RankedStatsService statsService = new RankedStatsService();

        // GET: TeamStalker
        /// <summary>
        /// Vue initiale
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Récupère l'ensemble des teams auxquelles appartient un invocateur
        /// </summary>
        /// <param name="summonerName">le nom de l'invocateur</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SummonerTeams(string summonerName)
        {
            WebServiceConsumer<Summoners> webServiceConsumer = new WebServiceConsumer<Summoners>(ConfigurationManager.AppSettings["BaseUri"], ConfigurationManager.AppSettings["SummonerApi"]);
            Dictionary<string, string> parametres = new Dictionary<string, string> { { "summonerNames", summonerName } };
            Summoners current = webServiceConsumer.Consume(parametres);
            IList<RankedTeam> rankedTeams = service.GetRankedTeamsForSummoner(current.First().Value);
            LolStatisticsCache.AddSummonerName(current.First().Value.Id, summonerName);
            return PartialView("Partial/TeamList", rankedTeams);
        }

        /// <summary>
        /// Récupère l'ensemble des statistiques en ranked des membres d'une team
        /// </summary>
        /// <param name="teamName">Le nom de la team en question</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TeamStats(string teamName)
        {
            RankedTeam teamToStalk = LolStatisticsCache.GetTeam(teamName);
            List<TeamStalkerViewModel> models = new List<TeamStalkerViewModel>();
            foreach (long summonerId in teamToStalk.Roster.Members.Select(m => m.PlayerId))
            {
                models.Add(statsService.GetStatsForSummoner(summonerId));
            }
            return PartialView("Partial/SummonerStats", models.OrderByDescending(m => m.LeagueInfo.Tier).ThenBy(m => m.LeagueInfo.Division).ThenByDescending(m => m.LeagueInfo.LeaguePoints).ToList());
        }
    }
}