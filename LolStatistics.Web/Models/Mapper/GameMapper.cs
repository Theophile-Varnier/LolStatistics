using LolStatistics.Model.Game;

namespace LolStatistics.Web.Models.Mapper
{
    public static class GameMapper
    {
        public static GameViewModel MapToModel(Game g)
        {
            GameViewModel res = new GameViewModel
            {
                ChampionId = g.ChampionId, 
                Win = g.Stats.Win,
                Spell1 = g.Spell1,
                Spell2 = g.Spell2,
                Kills = g.Stats.ChampionsKilled,
                Assists = g.Stats.Assists,
                Deaths = g.Stats.NumDeaths,
                Items = new int[]
                {
                    g.Stats.Item0,
                    g.Stats.Item1,
                    g.Stats.Item2,
                    g.Stats.Item3,
                    g.Stats.Item4,
                    g.Stats.Item5,
                    g.Stats.Item6
                },
                GameDuration = g.Stats.TimePlayed
            };
            return res;
        }
    }
}