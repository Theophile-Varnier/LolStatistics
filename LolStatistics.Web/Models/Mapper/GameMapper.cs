using LolStatistics.Model.Participant;

namespace LolStatistics.Web.Models.Mapper
{
    public static class GameMapper
    {
        public static GameViewModel MapToModel(Participant g)
        {
            GameViewModel res = new GameViewModel
            {
                ChampionId = g.ChampionId,
                Win = g.Stats.Winner,
                Spell1 = g.Spell1Id,
                Spell2 = g.Spell2Id,
                Kills = g.Stats.Kills,
                Assists = g.Stats.Assists,
                Deaths = g.Stats.Deaths,
                Items = new long[]
                {
                    g.Stats.Item0,
                    g.Stats.Item1,
                    g.Stats.Item2,
                    g.Stats.Item3,
                    g.Stats.Item4,
                    g.Stats.Item5,
                    g.Stats.Item6
                },
            };
            return res;
        }
    }
}