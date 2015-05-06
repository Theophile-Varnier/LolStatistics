﻿using Newtonsoft.Json;

namespace LolStatistics.Web.Models.WebServices
{
    [JsonObject]
    public class TeamMemberDto
    {
        [JsonProperty("inviteDate")]
        public long InviteDate { get; set; }

        [JsonProperty("joinDate")]
        public long JoinDate { get; set; }

        [JsonProperty("playerId")]
        public long PlayerId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}