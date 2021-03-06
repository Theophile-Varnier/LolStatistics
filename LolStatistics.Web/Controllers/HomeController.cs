﻿using LolStatistics.DataAccess.Repositories;
using LolStatistics.Model.Participant;
using LolStatistics.Web.Models;
using LolStatistics.Web.Models.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LolStatistics.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            RankedGameRepository gameHistoryRepository = new RankedGameRepository();
            GameHistoryViewModel model = new GameHistoryViewModel();
            long summonerId = 25954150;
            IList<Participant> gh = gameHistoryRepository.GetStatsForSummoner(summonerId).OrderByDescending(p => p.MatchId).ToList();
            model = GameHistoryMapper.MapToModel(gh);
            model.Games = model.Games.Take(10).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult HistoryPage(int Page)
        {
            RankedGameRepository gameHistoryRepository = new RankedGameRepository();
            GameHistoryViewModel model = new GameHistoryViewModel();
            long summonerId = 25954150;
            IList<Participant> gh = gameHistoryRepository.GetStatsForSummoner(summonerId).OrderByDescending(p => p.MatchId).ToList();
            model = GameHistoryMapper.MapToModel(gh);
            model.Games = model.Games.Skip(10 * Page).Take(10).ToList();
            return PartialView("Partial/MatchHistory", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}