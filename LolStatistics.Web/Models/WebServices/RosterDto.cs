using Newtonsoft.Json;
using System.Collections.Generic;

namespace LolStatistics.Web.Models.WebServices
{
    [JsonObject]
    public class RosterDto
    {
        [JsonProperty("memberList")]
        public List<TeamMemberDto> Members { get; set; }
    }
}