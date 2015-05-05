using LolStatistics.Model.Participant;
using LolStatistics.Model.Static;
using System;
using System.Collections.Generic;

namespace LolStatistics.Web.Models.Mapper
{
    public static class StatisticsMapper
    {
        public static StatisticsViewModel MapToModel(IList<Participant> participations)
        {
            StatisticsViewModel res = new StatisticsViewModel();

            foreach (Participant participant in participations)
            {
                Champion champion = LolStatisticsCache.Champion(participant.ChampionId);

                // Initialisation des statistiques par champion
                FillDictionaryWithParticipant(res.ChampionStatistics, champion.Name, participant);

                // Initialisation des statistiques par rôle
                string key = GetChampionRole(participant.Timeline == null ? "UKNOWN" : participant.Timeline.Lane, participant.Timeline == null ? "UKNOWN" : participant.Timeline.Role);

                FillDictionaryWithParticipant(res.RoleStatistics, key, participant);

            }

            return res;
        }

        public static TeamStalkerViewModel MapToTeamModel(IList<Participant> participations)
        {
            TeamStalkerViewModel res = new TeamStalkerViewModel();

            foreach (Participant participant in participations)
            {
                Champion champion = LolStatisticsCache.Champion(participant.ChampionId);

                // Initialisation des statistiques par champion
                FillDictionaryWithParticipant(res.ChampionStatistics, champion.Name, participant);
            }

            return res;
        }

        private static void FillDictionaryWithParticipant(Dictionary<string, ChampionStatisticsViewModel> dico, string key, Participant participant)
        {
            if (!dico.ContainsKey(key))
            {
                dico.Add(key, new ChampionStatisticsViewModel
                {
                    Assists = participant.Stats.Assists,
                    CreepScore = participant.Stats.MinionsKilled,
                    Deaths = participant.Stats.Deaths,
                    Kills = participant.Stats.Kills,
                    Loses = participant.Stats.Winner ? 0 : 1,
                    Wins = participant.Stats.Winner ? 1 : 0,
                    TotalTimePlayed = 0,
                    DoubleKills = participant.Stats.DoubleKills,
                    TripleKills = participant.Stats.TripleKills,
                    QuadraKills = participant.Stats.QuadraKills,
                    PentaKills = participant.Stats.PentaKills,
                    LargestKillingSpree = participant.Stats.LargestKillingSpree,
                    KillingSprees = participant.Stats.KillingSprees
                });
            }
            else
            {
                ChampionStatisticsViewModel stats = dico[key];
                stats.Assists += participant.Stats.Assists;
                stats.CreepScore += participant.Stats.MinionsKilled;
                stats.Deaths += participant.Stats.Deaths;
                stats.Kills += participant.Stats.Kills;
                stats.Loses += participant.Stats.Winner ? 0 : 1;
                stats.Wins += participant.Stats.Winner ? 1 : 0;
                stats.TotalTimePlayed += 0;
                stats.DoubleKills += participant.Stats.DoubleKills;
                stats.TripleKills += participant.Stats.TripleKills;
                stats.QuadraKills += participant.Stats.QuadraKills;
                stats.PentaKills += participant.Stats.PentaKills;
                stats.LargestKillingSpree = Math.Max(participant.Stats.LargestKillingSpree, stats.LargestKillingSpree);
                stats.KillingSprees += participant.Stats.KillingSprees;
            }
        }

        private static string GetChampionRole(string lane, string role)
        {
            switch (role)
            {
                case "DUO_CARRY":
                    return "AD CARRY";
                case "DUO_SUPPORT":
                    return "SUPPORT";
                case "SOLO":
                case "NONE":
                    switch (lane)
                    {
                        case "MIDDLE":
                            return "AP MID";
                        case "TOP":
                        case "JUNGLE":
                            return lane;
                    }
                    break;
            }
            return "UNKNOWN";
        }
    }
}