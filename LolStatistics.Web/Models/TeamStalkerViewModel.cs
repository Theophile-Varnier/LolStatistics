using System.Collections.Generic;
using System.IO;
using System.Linq;
using LolStatistics.Model.App;
using LolStatistics.Model.Static;
using LolStatistics.Web.Models.WebServices;
using Newtonsoft.Json;

namespace LolStatistics.Web.Models
{
    [JsonObject]
    public class TeamStalkerViewModel
    {
        [JsonIgnore]
        public string Name { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonIgnore]
        public List<Champion> Mains
        {
            get { return Champions.Where(f => f.ChampionId != 0)
                .OrderByDescending(f => f.Stats.TotalGames)
                .Select(f => LolStatisticsCache.Champion(f.ChampionId)).ToList(); }
        }

        [JsonProperty("champions")]
        public List<ChampionStats> Champions { get; set; }

        public ChampionStatisticsViewModel ChampionStats(int championId)
        {
            ChampionStats championStats = Champions.FirstOrDefault(c => c.ChampionId == championId);
            return championStats != null ? championStats.Stats : null;
        }

        [JsonIgnore]
        public LeagueEntry LeagueInfo { get; set; }

        public string Classement
        {
            get
            {
                return string.Concat(LeagueInfo.Tier.ToString(), " ", LeagueInfo.Division);
            }
        }
    }
}