using Newtonsoft.Json;

namespace LolStatistics.Model.Stats
{
    [JsonObject]
    public class ParticipantStats
    {
        [JsonIgnore]
        public string ParticipantId { get; set; }

        [JsonProperty("assists")]
        public long Assists { get; set; }

        [JsonProperty("champLevel")]
        public long ChampLevel { get; set; }

        [JsonProperty("combatPlayerScore")]
        public long CombatPlayerScore { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("doubleKills")]
        public long DoubleKills { get; set; }

        [JsonProperty("firstBloodAssist")]
        public bool FirstBloodAssist { get; set; }

        [JsonProperty("firstBloodKill")]
        public bool FirstBloodKill { get; set; }

        [JsonProperty("firstInhibitorAssist")]
        public bool FirstInhibitorAssist { get; set; }

        [JsonProperty("firstInhibitorKill")]
        public bool FirstInhibitorKill { get; set; }

        [JsonProperty("firstTowerAssist")]
        public bool FirstTowerAssist { get; set; }

        [JsonProperty("firstTowerKill")]
        public bool FirstTowerKill { get; set; }

        [JsonProperty("goldEarned")]
        public long GoldEarned { get; set; }

        [JsonProperty("goldSpent")]
        public long GoldSpent { get; set; }

        [JsonProperty("inhibitorKills")]
        public long InhibitorKills { get; set; }

        [JsonProperty("item0")]
        public long Item0 { get; set; }

        [JsonProperty("item1")]
        public long Item1 { get; set; }

        [JsonProperty("item2")]
        public long Item2 { get; set; }

        [JsonProperty("item3")]
        public long Item3 { get; set; }

        [JsonProperty("item4")]
        public long Item4 { get; set; }

        [JsonProperty("item5")]
        public long Item5 { get; set; }

        [JsonProperty("item6")]
        public long Item6 { get; set; }

        [JsonProperty("killingSprees")]
        public long KillingSprees { get; set; }

        [JsonProperty("kills")]
        public long Kills { get; set; }

        [JsonProperty("largestCriticalStrike")]
        public long LargestCriticalStrike { get; set; }

        [JsonProperty("largestKillingSpree")]
        public long LargestKillingSpree { get; set; }

        [JsonProperty("largestMultiKill")]
        public long LargestMultiKill { get; set; }

        [JsonProperty("magicDamageDealt")]
        public long MagicDamageDealt { get; set; }

        [JsonProperty("magicDamageDealtToChampions")]
        public long MagicDamageDealtToChampions { get; set; }

        [JsonProperty("magicDamageTaken")]
        public long MagicDamageTaken { get; set; }

        [JsonProperty("minionsKilled")]
        public long MinionsKilled { get; set; }

        [JsonProperty("neutralMinionsKilled")]
        public long NeutralMinionsKilled { get; set; }

        [JsonProperty("neutralMinionsKilledEnemyJungle")]
        public long NeutralMinionsKilledEnemyJungle { get; set; }

        [JsonProperty("neutralMinionsKilledTeamJungle")]
        public long NeutralMinionsKilledTeamJungle { get; set; }

        [JsonProperty("nodeCapture")]
        public long NodeCapture { get; set; }

        [JsonProperty("nodeCaptureAssist")]
        public long NodeCaptureAssist { get; set; }

        [JsonProperty("nodeNeutralize")]
        public long NodeNeutralize { get; set; }

        [JsonProperty("nodeNeutralizeAssist")]
        public long NodeNeutralizeAssist { get; set; }

        [JsonProperty("objectivePlayerScore")]
        public long ObjectivePlayerScore { get; set; }

        [JsonProperty("pentaKills")]
        public long PentaKills { get; set; }

        [JsonProperty("physicalDamageDealt")]
        public long PhysicalDamageDealt { get; set; }

        [JsonProperty("physicalDamageDealtToChampions")]
        public long PhysicalDamageDealtToChampions { get; set; }

        [JsonProperty("physicalDamageTaken")]
        public long PhysicalDamageTaken { get; set; }

        [JsonProperty("quadraKills")]
        public long QuadraKills { get; set; }

        [JsonProperty("sightWardsBoughtInGame")]
        public long SightWardsBoughtInGame { get; set; }

        [JsonProperty("teamObjective")]
        public long TeamObjective { get; set; }

        [JsonProperty("totalDamageDealt")]
        public long TotalDamageDealt { get; set; }

        [JsonProperty("totalDamageDealtToChampions")]
        public long TotalDamageDealtToChampions { get; set; }

        [JsonProperty("totalDamageTaken")]
        public long TotalDamageTaken { get; set; }

        [JsonProperty("totalHeal")]
        public long TotalHeal { get; set; }

        [JsonProperty("totalPlayerScore")]
        public long TotalPlayerScore { get; set; }

        [JsonProperty("totalScoreRank")]
        public long TotalScoreRank { get; set; }

        [JsonProperty("totalTimeCrowdControlDealt")]
        public long TotalTimeCrowdControlDealt { get; set; }

        [JsonProperty("totalUnitsHealed")]
        public long TotalUnitsHealed { get; set; }

        [JsonProperty("towerKills")]
        public long TowerKills { get; set; }

        [JsonProperty("tripleKills")]
        public long TripleKills { get; set; }

        [JsonProperty("trueDamageDealt")]
        public long TrueDamageDealt { get; set; }

        [JsonProperty("trueDamageDealtToChampions")]
        public long TrueDamageDealtToChampions { get; set; }

        [JsonProperty("trueDamageTaken")]
        public long TrueDamageTaken { get; set; }

        [JsonProperty("unrealKills")]
        public long UnrealKills { get; set; }

        [JsonProperty("visionWardsBoughtInGame")]
        public long VisionWardsBoughtInGame { get; set; }

        [JsonProperty("wardsKilled")]
        public long WardsKilled { get; set; }

        [JsonProperty("wardsPlaced")]
        public long WardsPlaced { get; set; }

        [JsonProperty("winner")]
        public bool Winner { get; set; }

    }
}
