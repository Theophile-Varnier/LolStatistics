using System.Runtime.Serialization;

namespace LolStatistics.Model.Participant
{
    [DataContract]
    public class ParticipantTimelineData
    {
        [IgnoreDataMember]
        public string ParticipantId { get; set; }

        [IgnoreDataMember]
        public string Name { get; set; }

        [DataMember(Name = "tenToTwenty")]
        public double TenToTwenty { get; set; }

        [DataMember(Name = "thirtyToEnd")]
        public double ThirtyToEnd { get; set; }

        [DataMember(Name = "twentyToThirty")]
        public double TwentyToThirty { get; set; }

        [DataMember(Name = "zeroToTen")]
        public double ZeroToTen { get; set; }

    }
}
