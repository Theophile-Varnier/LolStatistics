using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LolStatistics.Model
{
    [DataContract]
    public class MatchHistory
    {
        [DataMember(Name = "matches")]
        public List<RankedGame> Matches { get; set; }
    }
}
