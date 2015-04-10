using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LolStatistics.Model.Game
{
    [DataContract]
    public class MatchHistory
    {
        [DataMember(Name = "matches")]
        public List<RankedGame> Matches { get; set; }
    }
}
