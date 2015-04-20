
namespace LolStatistics.Web.Models
{
    public class GameViewModel
    {
        public bool Win { get; set; }

        public int ChampionId { get; set; }

        public int Spell1 { get; set; }

        public int Spell2 { get; set; }

        public int Kills { get; set; }

        public int Assists { get; set; }

        public int Deaths { get; set; }

        public int[] Items { get; set; }

        public int GameDuration { get; set; }

    }
}