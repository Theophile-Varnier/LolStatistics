using System;
using Newtonsoft.Json;

namespace LolStatistics.Web.Models
{
    [JsonObject]
    public class ChampionStatisticsViewModel
    {
        [JsonProperty("totalSessionsWon")]
        public int Wins { get; set; }

        [JsonProperty("totalSessionsLost")]
        public int Loses { get; set; }

        [JsonIgnore]
        public int TotalGames
        {
            get { return Wins + Loses; }
        }

        [JsonIgnore]
        public double WinRate
        {
            get { return Math.Round((100.0 * Wins) / TotalGames, 2); }
        }

        [JsonProperty("totalChampionKills")]
        public long Kills { get; set; }

        [JsonProperty("totalDeathsPerSession")]
        public long Deaths { get; set; }

        [JsonProperty("totalAssists")]
        public long Assists { get; set; }

        [JsonIgnore]
        public double KDA
        {
            get { return Math.Round((Kills + Assists) / (Deaths * 1.0), 2); }
        }

        [JsonProperty("totalDoubleKills")]
        public long DoubleKills { get; set; }

        [JsonProperty("totalTripleKills")]
        public long TripleKills { get; set; }

        [JsonProperty("totalQuadraKills")]
        public long QuadraKills { get; set; }

        [JsonProperty("totalPentaKills")]
        public long PentaKills { get; set; }

        [JsonProperty("killingSpree")]
        public long KillingSprees { get; set; }

        [JsonProperty("maxLargestKillingSpree")]
        public long LargestKillingSpree { get; set; }

        [JsonIgnore]
        public long TotalTimePlayed { get; set; }

        [JsonProperty("totalMinionKills")]
        public long CreepScore { get; set; }
    }
}