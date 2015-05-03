using LolStatistics.Web.Models.WebServices;
using LolStatistics.Web.Services;
using LolStatistics.WebServiceConsumers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
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

        [HttpPost]
        public ActionResult StalkTeam(string teamName)
        {
            RankedTeam teamToStalk = LolStatisticsCache.GetTeam(teamName);
            return PartialView("Partial/TeamStalk", teamToStalk);
        }
    }
}