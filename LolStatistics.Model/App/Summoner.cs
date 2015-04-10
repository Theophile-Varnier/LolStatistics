using System.Runtime.Serialization;

namespace LolStatistics.Model.App
{
    [DataContract]
    public class Summoner
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "profileIconId")]
        public int ProfileIconId { get; set; }

        [DataMember(Name = "revisionDate")]
        public long RevisionDate { get; set; }

    }
}
