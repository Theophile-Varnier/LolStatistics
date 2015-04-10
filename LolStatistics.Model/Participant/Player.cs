using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace LolStatistics.Model
{
    [DataContract]
    public class Player
    {
        [IgnoreDataMember]
        public string GameId { get; set; }

        [DataMember(Name = "championId")]
        public int ChampionId { get; set; }

        [DataMember(Name = "summonerId")]
        public long SummonerId { get; set; }

        [DataMember(Name = "teamId")]
        public int TeamId { get; set; }
    }
}