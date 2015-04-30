using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LolStatistics.DataAccess.Repositories;
using LolStatistics.Model.Participant;
using LolStatistics.Web.Models;
using LolStatistics.Web.Models.Mapper;

namespace LolStatistics.Web.Controllers
{
    public class StatisticsController : Controller
    {
        private RankedGameRepository gameHistoryRepository = new RankedGameRepository();
        //
        // GET: /Statistics/
        public ActionResult Index()
        {
            StatisticsViewModel model = GetStatisticsViewModelForSummoner(25954150);
            return View(model);
        }

        // 
        // GET: /Statistics/Graphe
        public ActionResult Graphe()
        {
            StatisticsViewModel model = GetStatisticsViewModelForSummoner(25954150);
            return View(model);
        }

        // 
        // GET : /Statistics/Pantheon
        public ActionResult Pantheon()
        {
            StatisticsViewModel model = GetStatisticsViewModelForSummoner(25954150);
            return View(model);
        }

        private StatisticsViewModel GetStatisticsViewModelForSummoner(long summonerId)
        {
            IList<Participant> gh = gameHistoryRepository.GetStatsForSummoner(summonerId);
            return StatisticsMapper.MapToModel(gh);
        }
    }
}