
namespace LolStatistics.Web.Models
{
    public class GameViewModel
    {
        public bool Win { get; set; }

        public int ChampionId { get; set; }

        public int Spell1 { get; set; }

        public int Spell2 { get; set; }

        public long Kills { get; set; }

        public long Assists { get; set; }

        public long Deaths { get; set; }

        public long[] Items { get; set; }

        public int GameDuration { get; set; }

    }
}