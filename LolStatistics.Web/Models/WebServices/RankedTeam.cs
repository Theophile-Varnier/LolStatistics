using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LolStatistics.Web.Models.WebServices
{
    [JsonObject]
    public class RankedTeam
    {
        [JsonProperty("createDate")]
        public long CreateDate { get; set; }

        [JsonProperty("fullId")]
        public string FullId { get; set; }

        [JsonProperty("lastGameDate")]
        public long LastGameDate { get; set; }

        [JsonProperty("lastJoinDate")]
        public long LastJoinDate { get; set; }

        [JsonProperty("lastJoinedRankedTeamQueueDate")]
        public long LastJoinedRankedTeamQueueDate { get; set; }

        [JsonProperty("modifyDate")]
        public long ModifyDate { get; set; }

        [JsonProperty("roster")]
        public RosterDto Roster { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("secondLastJoinDate")]
        public long SecondLastJoinDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("matchHistory")]
        public List<TeamStats> MatchHistory { get; set; }
    }
}