﻿using LolStatistics.Model.Stats;
using Newtonsoft.Json;

namespace LolStatistics.Model.Participant
{
    [JsonObject]
    public class Participant
    {
        [JsonIgnore]
        public long MatchId { get; set; }

        [JsonProperty("participantId")]
        public long ParticipantId { get; set; }

        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        [JsonProperty("highestAchievedSeasonTier")]
        public string HighestAchievedSeasonTier { get; set; }

        [JsonProperty("spell1Id")]
        public int Spell1Id { get; set; }

        [JsonProperty("spell2Id")]
        public int Spell2Id { get; set; }

        [JsonProperty("stats")]
        public ParticipantStats Stats { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("timeline")]
        public ParticipantTimeline Timeline { get; set; }

    }
}
