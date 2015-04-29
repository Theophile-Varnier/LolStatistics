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
        //
        // GET: /Statistics/
        public ActionResult Index()
        {
            RankedGameRepository gameHistoryRepository = new RankedGameRepository();
            StatisticsViewModel model;
            long summonerId = 25954150;
            IList<Participant> gh = gameHistoryRepository.GetStatsForSummoner(summonerId);
            model = StatisticsMapper.MapToModel(gh);
            return View(model);
        }
    }
}