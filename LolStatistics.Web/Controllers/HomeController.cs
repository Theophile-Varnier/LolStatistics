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
            GameHistoryRepository dbMapper = new GameHistoryRepository();
            GameHistoryViewModel model = new GameHistoryViewModel();
            GameDao gameDao = new GameDao();
            string summonerId = "25954150";
            GameHistory gh = dbMapper.UnMap(summonerId);
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