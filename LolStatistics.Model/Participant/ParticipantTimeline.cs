using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace LolStatistics.Model.Participant
{
    [DataContract]
    public class ParticipantTimeline
    {
        [IgnoreDataMember]
        public string ParticipantId { get; set; }

        [DataMember(Name = "ancientGolemAssistsPerMinCounts")]
        public ParticipantTimelineData AncientGolemAssistsPerMinCounts { get; set; }

        [DataMember(Name = "ancientGolemKillsPerMinCounts")]
        public ParticipantTimelineData AncientGolemKillsPerMinCounts { get; set; }

        [DataMember(Name = "assistedLaneDeathsPerMinDeltas")]
        public ParticipantTimelineData AssistedLaneDeathsPerMinDeltas { get; set; }

        [DataMember(Name = "assistedLaneKillsPerMinDeltas")]
        public ParticipantTimelineData AssistedLaneKillsPerMinDeltas { get; set; }

        [DataMember(Name = "baronAssistsPerMinCounts")]
        public ParticipantTimelineData BaronAssistsPerMinCounts { get; set; }

        [DataMember(Name = "baronKillsPerMinCounts")]
        public ParticipantTimelineData BaronKillsPerMinCounts { get; set; }

        [DataMember(Name = "creepsPerMinDeltas")]
        public ParticipantTimelineData CreepsPerMinDeltas { get; set; }

        [DataMember(Name = "csDiffPerMinDeltas")]
        public ParticipantTimelineData CsDiffPerMinDeltas { get; set; }

        [DataMember(Name = "damageTakenDiffPerMinDeltas")]
        public ParticipantTimelineData DamageTakenDiffPerMinDeltas { get; set; }

        [DataMember(Name = "damageTakenPerMinDeltas")]
        public ParticipantTimelineData DamageTakenPerMinDeltas { get; set; }

        [DataMember(Name = "dragonAssistsPerMinCounts")]
        public ParticipantTimelineData DragonAssistsPerMinCounts { get; set; }

        [DataMember(Name = "dragonKillsPerMinCounts")]
        public ParticipantTimelineData DragonKillsPerMinCounts { get; set; }

        [DataMember(Name = "elderLizardAssistsPerMinCounts")]
        public ParticipantTimelineData ElderLizardAssistsPerMinCounts { get; set; }

        [DataMember(Name = "elderLizardKillsPerMinCounts")]
        public ParticipantTimelineData ElderLizardKillsPerMinCounts { get; set; }

        [DataMember(Name = "goldPerMinDeltas")]
        public ParticipantTimelineData GoldPerMinDeltas { get; set; }

        [DataMember(Name = "inhibitorAssistsPerMinCounts")]
        public ParticipantTimelineData InhibitorAssistsPerMinCounts { get; set; }

        [DataMember(Name = "inhibitorKillsPerMinCounts")]
        public ParticipantTimelineData InhibitorKillsPerMinCounts { get; set; }

        [DataMember(Name = "lane")]
        public string Lane { get; set; }

        [DataMember(Name = "role")]
        public string Role { get; set; }

        [DataMember(Name = "towerAssistsPerMinCounts")]
        public ParticipantTimelineData TowerAssistsPerMinCounts { get; set; }

        [DataMember(Name = "towerKillsPerMinCounts")]
        public ParticipantTimelineData TowerKillsPerMinCounts { get; set; }

        [DataMember(Name = "towerKillsPerMinDeltas")]
        public ParticipantTimelineData TowerKillsPerMinDeltas { get; set; }

        [DataMember(Name = "vilemawAssistsPerMinCounts")]
        public ParticipantTimelineData VilemawAssistsPerMinCounts { get; set; }

        [DataMember(Name = "vilemawKillsPerMinCounts")]
        public ParticipantTimelineData VilemawKillsPerMinCounts { get; set; }

        [DataMember(Name = "wardsPerMinDeltas")]
        public ParticipantTimelineData WardsPerMinDeltas { get; set; }

        [DataMember(Name = "xpDiffPerMinDeltas")]
        public ParticipantTimelineData XpDiffPerMinDeltas { get; set; }

        [DataMember(Name = "xpPerMinDeltas")]
        public ParticipantTimelineData XpPerMinDeltas { get; set; }

        public IList<PropertyInfo> TimelineDatas
        {
            get
            {
                PropertyInfo[] properties = typeof(ParticipantTimeline).GetProperties();

                IList<PropertyInfo> res = new List<PropertyInfo>();

                foreach (PropertyInfo property in properties)
                {
                    if (property.Name != "TimelineDatas")
                    {
                        // Ne cherche pas à comprendre et dis toi que ça marche
                        ParticipantTimelineData prop = this.GetType().GetProperty(property.Name).GetValue(this) as ParticipantTimelineData;
                        if (prop != null)
                        {
                            res.Add(property);
                        }
                    }
                }
                return res;
            }
        }

    }

}
