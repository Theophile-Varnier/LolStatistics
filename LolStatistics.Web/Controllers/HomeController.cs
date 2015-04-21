using LolStatistics.DataAccess.Dao;
using LolStatistics.DataAccess.Repositories;
using LolStatistics.Model.Game;
using LolStatistics.Web.Models;
using LolStatistics.Web.Models.Mapper;
using System.Linq;
using System.Web.Mvc;

namespace LolStatistics.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GameHistoryRepository gameHistoryRepository = new GameHistoryRepository();
            GameHistoryViewModel model = new GameHistoryViewModel();
            long summonerId = 25954150;
            GameHistory gh = gameHistoryRepository.GetById(summonerId);
            gh.Games = gh.Games.OrderBy(g => g.CreateDate).Reverse().ToList();
            model = GameHistoryMapper.MapToModel(gh);
            return View(model);
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