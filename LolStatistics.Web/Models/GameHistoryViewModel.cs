using System.Collections.Generic;

namespace LolStatistics.Web.Models
{
    public class GameHistoryViewModel
    {
        public GameHistoryViewModel()
        {
            Games = new List<GameViewModel>();
        }

        public List<GameViewModel> Games { get; set; }

        public int PageNumber { get; set; }
    }
}