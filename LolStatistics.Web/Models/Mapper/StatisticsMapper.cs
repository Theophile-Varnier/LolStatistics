using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using LolStatistics.Model.Participant;

namespace LolStatistics.Web.Models.Mapper
{
    public static class StatisticsMapper
    {
        public static StatisticsViewModel MapToModel(IList<Participant> participations)
        {
            StatisticsViewModel res = new StatisticsViewModel();

            foreach (Participant participant in participations)
            {
                string championName = LolStatisticsCache.Champion(participant.ChampionId).Name;
                if (!res.ChampionStatistics.ContainsKey(championName))
                {
                    res.ChampionStatistics.Add(championName, new ChampionStatisticsViewModel
                    {
                        Assists = participant.Stats.Assists,
                        CreepScore = participant.Stats.MinionsKilled,
                        Deaths = participant.Stats.Deaths,
                        Kills = participant.Stats.Kills,
                        Loses = participant.Stats.Winner ? 0 : 1,
                        Wins = participant.Stats.Winner ? 1 : 0,
                        TotalTimePlayed = 0
                    });
                }
                else
                {
                    ChampionStatisticsViewModel stats = res.ChampionStatistics[championName];
                    stats.Assists += participant.Stats.Assists;
                    stats.CreepScore += participant.Stats.MinionsKilled;
                    stats.Deaths += participant.Stats.Deaths;
                    stats.Kills += participant.Stats.Kills;
                    stats.Loses += participant.Stats.Winner ? 0 : 1;
                    stats.Wins += participant.Stats.Winner ? 1 : 0;
                    stats.TotalTimePlayed += 0;
                }
            }

            return res;
        }
    }
}