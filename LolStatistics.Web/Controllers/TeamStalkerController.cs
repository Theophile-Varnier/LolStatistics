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
        // GET: TeamStalker
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SummonerTeams(string summonerName)
        {
            WebServiceConsumer<Summoners> webServiceConsumer = new WebServiceConsumer<Summoners>(ConfigurationManager.AppSettings["BaseUri"], ConfigurationManager.AppSettings["SummonerApi"]);
            Dictionary<string, string> parametres = new Dictionary<string, string>();
            parametres.Add("summonerNames", summonerName);
            Summoners current = webServiceConsumer.Consume(parametres);
            IList<RankedTeam> rankedTeams = service.GetRankedTeamsForSummoner(current.First().Value);
            return PartialView("Partial/TeamList", rankedTeams);
        }

        /// <summary>
        /// Récupère la liste des ids des membres d'une team
        /// </summary>
        /// <param name="teamName">Le nom de la team</param>
        /// <returns></returns>
        [HttpPost]
        public string TeamMembers(string teamName)
        {
            RankedTeam teamToStalk = LolStatisticsCache.GetTeam(teamName);
            return System.Web.Helpers.Json.Encode(teamToStalk.Roster.Members.Select(m => m.PlayerId).ToList());
        }

        [HttpGet]
        public ActionResult SummonerStats(long summonerId)
        {
            return PartialView("Partial/SummonerStats", summonerId);
        }
    }
}