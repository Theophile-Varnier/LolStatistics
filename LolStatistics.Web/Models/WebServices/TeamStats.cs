using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LolStatistics.Web.Models.WebServices
{
    [JsonObject]
    public class TeamStats
    {
        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("opposingTeamKills")]
        public int OpposingTeamKills { get; set; }

        [JsonProperty("assists")]
        public int Assists { get; set; }

        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("opposingTeamName")]
        public string OpposingTeamName { get; set; }

        [JsonProperty("win")]
        public bool Win { get; set; }

        [JsonProperty("invalid")]
        public bool Invalid { get; set; }

        [JsonProperty("mapId")]
        public int MapId { get; set; }

        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }
    }
}