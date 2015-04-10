using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LolStatistics.Model
{
    [DataContract]
    public class GameHistory
    {
        [DataMember(Name="summonerId")]
        public long SummonerId { get; set; }

        [DataMember(Name="games")]
        public List<Game> Games { get; set; }
    }
}
