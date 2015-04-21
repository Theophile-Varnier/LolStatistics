using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace LolStatistics.Model.Participant
{
    [JsonObject]
    public class ParticipantTimeline
    {
        [JsonIgnore]
        public long ParticipantId { get; set; }

        [JsonProperty("ancientGolemAssistsPerMinCounts")]
        public ParticipantTimelineData AncientGolemAssistsPerMinCounts { get; set; }

        [JsonProperty("ancientGolemKillsPerMinCounts")]
        public ParticipantTimelineData AncientGolemKillsPerMinCounts { get; set; }

        [JsonProperty("assistedLaneDeathsPerMinDeltas")]
        public ParticipantTimelineData AssistedLaneDeathsPerMinDeltas { get; set; }

        [JsonProperty("assistedLaneKillsPerMinDeltas")]
        public ParticipantTimelineData AssistedLaneKillsPerMinDeltas { get; set; }

        [JsonProperty("baronAssistsPerMinCounts")]
        public ParticipantTimelineData BaronAssistsPerMinCounts { get; set; }

        [JsonProperty("baronKillsPerMinCounts")]
        public ParticipantTimelineData BaronKillsPerMinCounts { get; set; }

        [JsonProperty("creepsPerMinDeltas")]
        public ParticipantTimelineData CreepsPerMinDeltas { get; set; }

        [JsonProperty("csDiffPerMinDeltas")]
        public ParticipantTimelineData CsDiffPerMinDeltas { get; set; }

        [JsonProperty("damageTakenDiffPerMinDeltas")]
        public ParticipantTimelineData DamageTakenDiffPerMinDeltas { get; set; }

        [JsonProperty("damageTakenPerMinDeltas")]
        public ParticipantTimelineData DamageTakenPerMinDeltas { get; set; }

        [JsonProperty("dragonAssistsPerMinCounts")]
        public ParticipantTimelineData DragonAssistsPerMinCounts { get; set; }

        [JsonProperty("dragonKillsPerMinCounts")]
        public ParticipantTimelineData DragonKillsPerMinCounts { get; set; }

        [JsonProperty("elderLizardAssistsPerMinCounts")]
        public ParticipantTimelineData ElderLizardAssistsPerMinCounts { get; set; }

        [JsonProperty("elderLizardKillsPerMinCounts")]
        public ParticipantTimelineData ElderLizardKillsPerMinCounts { get; set; }

        [JsonProperty("goldPerMinDeltas")]
        public ParticipantTimelineData GoldPerMinDeltas { get; set; }

        [JsonProperty("inhibitorAssistsPerMinCounts")]
        public ParticipantTimelineData InhibitorAssistsPerMinCounts { get; set; }

        [JsonProperty("inhibitorKillsPerMinCounts")]
        public ParticipantTimelineData InhibitorKillsPerMinCounts { get; set; }

        [JsonProperty("lane")]
        public string Lane { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("towerAssistsPerMinCounts")]
        public ParticipantTimelineData TowerAssistsPerMinCounts { get; set; }

        [JsonProperty("towerKillsPerMinCounts")]
        public ParticipantTimelineData TowerKillsPerMinCounts { get; set; }

        [JsonProperty("towerKillsPerMinDeltas")]
        public ParticipantTimelineData TowerKillsPerMinDeltas { get; set; }

        [JsonProperty("vilemawAssistsPerMinCounts")]
        public ParticipantTimelineData VilemawAssistsPerMinCounts { get; set; }

        [JsonProperty("vilemawKillsPerMinCounts")]
        public ParticipantTimelineData VilemawKillsPerMinCounts { get; set; }

        [JsonProperty("wardsPerMinDeltas")]
        public ParticipantTimelineData WardsPerMinDeltas { get; set; }

        [JsonProperty("xpDiffPerMinDeltas")]
        public ParticipantTimelineData XpDiffPerMinDeltas { get; set; }

        [JsonProperty("xpPerMinDeltas")]
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
