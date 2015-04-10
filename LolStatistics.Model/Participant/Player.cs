using System.Runtime.Serialization;

namespace LolStatistics.Model.Participant
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