using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LolStatistics.Web.Models.WebServices
{
    [JsonObject]
    public class RosterDto
    {
        [JsonProperty("memberList")]
        public List<TeamMemberDto> Members { get; set; }
    }
}