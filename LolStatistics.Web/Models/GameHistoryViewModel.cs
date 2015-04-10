using System.Collections.Generic;

namespace LolStatistics.Web.Models
{
    public class GameHistoryViewModel
    {
        public GameHistoryViewModel()
        {
            Games = new List<GameViewModel>();
        }
        public long SummonerId { get; set; }

        public List<GameViewModel> Games { get; set; }
    }
}