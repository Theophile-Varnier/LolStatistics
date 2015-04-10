using System.Runtime.Serialization;

namespace LolStatistics.Model.Stats
{
    [DataContract]
    public class RawStats
    {
        [IgnoreDataMember]
        public string GameId { get; set; }

        [DataMember(Name = "assists")]
        public int Assists { get; set; }

        [DataMember(Name = "barracksKilled")]
        public int BarracksKilled { get; set; }

        [DataMember(Name = "championsKilled")]
        public int ChampionsKilled { get; set; }

        [DataMember(Name = "combatPlayerScore")]
        public int CombatPlayerScore { get; set; }

        [DataMember(Name = "consumablesPurchased")]
        public int ConsumablesPurchased { get; set; }

        [DataMember(Name = "damageDealtPlayer")]
        public int DamageDealtPlayer { get; set; }

        [DataMember(Name = "doubleKills")]
        public int DoubleKills { get; set; }

        [DataMember(Name = "firstBlood")]
        public int FirstBlood { get; set; }

        [DataMember(Name = "gold")]
        public int Gold { get; set; }

        [DataMember(Name = "goldEarned")]
        public int GoldEarned { get; set; }

        [DataMember(Name = "goldSpent")]
        public int GoldSpent { get; set; }

        [DataMember(Name = "item0")]
        public int Item0 { get; set; }

        [DataMember(Name = "item1")]
        public int Item1 { get; set; }

        [DataMember(Name = "item2")]
        public int Item2 { get; set; }

        [DataMember(Name = "item3")]
        public int Item3 { get; set; }

        [DataMember(Name = "item4")]
        public int Item4 { get; set; }

        [DataMember(Name = "item5")]
        public int Item5 { get; set; }

        [DataMember(Name = "item6")]
        public int Item6 { get; set; }

        [DataMember(Name = "itemsPurchased")]
        public int ItemsPurchased { get; set; }

        [DataMember(Name = "killingSprees")]
        public int KillingSprees { get; set; }

        [DataMember(Name = "largestCriticalStrike")]
        public int LargestCriticalStrike { get; set; }

        [DataMember(Name = "largestKillingSpree")]
        public int LargestKillingSpree { get; set; }

        [DataMember(Name = "largestMultiKill")]
        public int LargestMultiKill { get; set; }

        [DataMember(Name = "legendaryItemsCreated")]
        public int LegendaryItemsCreated { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "magicDamageDealtPlayer")]
        public int MagicDamageDealtPlayer { get; set; }

        [DataMember(Name = "magicDamageDealtToChampions")]
        public int MagicDamageDealtToChampions { get; set; }

        [DataMember(Name = "magicDamageTaken")]
        public int MagicDamageTaken { get; set; }

        [DataMember(Name = "minionsDenied")]
        public int MinionsDenied { get; set; }

        [DataMember(Name = "minionsKilled")]
        public int MinionsKilled { get; set; }

        [DataMember(Name = "neutralMinionsKilled")]
        public int NeutralMinionsKilled { get; set; }

        [DataMember(Name = "neutralMinionsKilledEnemyJungle")]
        public int NeutralMinionsKilledEnemyJungle { get; set; }

        [DataMember(Name = "neutralMinionsKilledYourJungle")]
        public int NeutralMinionsKilledYourJungle { get; set; }

        [DataMember(Name = "nexusKilled")]
        public bool NexusKilled { get; set; }

        [DataMember(Name = "nodeCapture")]
        public int NodeCapture { get; set; }

        [DataMember(Name = "nodeCaptureAssist")]
        public int NodeCaptureAssist { get; set; }

        [DataMember(Name = "nodeNeutralize")]
        public int NodeNeutralize { get; set; }

        [DataMember(Name = "nodeNeutralizeAssist")]
        public int NodeNeutralizeAssist { get; set; }

        [DataMember(Name = "numDeaths")]
        public int NumDeaths { get; set; }

        [DataMember(Name = "numItemsBought")]
        public int NumItemsBought { get; set; }

        [DataMember(Name = "objectivePlayerScore")]
        public int ObjectivePlayerScore { get; set; }

        [DataMember(Name = "pentaKills")]
        public int PentaKills { get; set; }

        [DataMember(Name = "physicalDamageDealtPlayer")]
        public int PhysicalDamageDealtPlayer { get; set; }

        [DataMember(Name = "physicalDamageDealtToChampions")]
        public int PhysicalDamageDealtToChampions { get; set; }

        [DataMember(Name = "physicalDamageTaken")]
        public int PhysicalDamageTaken { get; set; }

        [DataMember(Name = "quadraKills")]
        public int QuadraKills { get; set; }

        [DataMember(Name = "sightWardsBought")]
        public int SightWardsBought { get; set; }

        [DataMember(Name = "spell1Cast")]
        public int Spell1Cast { get; set; }

        [DataMember(Name = "spell2Cast")]
        public int Spell2Cast { get; set; }

        [DataMember(Name = "spell3Cast")]
        public int Spell3Cast { get; set; }

        [DataMember(Name = "spell4Cast")]
        public int Spell4Cast { get; set; }

        [DataMember(Name = "summonSpell1Cast")]
        public int SummonSpell1Cast { get; set; }

        [DataMember(Name = "summonSpell2Cast")]
        public int SummonSpell2Cast { get; set; }

        [DataMember(Name = "superMonsterKilled")]
        public int SuperMonsterKilled { get; set; }

        [DataMember(Name = "team")]
        public int Team { get; set; }

        [DataMember(Name = "teamObjective")]
        public int TeamObjective { get; set; }

        [DataMember(Name = "timePlayed")]
        public int TimePlayed { get; set; }

        [DataMember(Name = "totalDamageDealt")]
        public int TotalDamageDealt { get; set; }

        [DataMember(Name = "totalDamageDealtToChampions")]
        public int TotalDamageDealtToChampions { get; set; }

        [DataMember(Name = "totalDamageTaken")]
        public int TotalDamageTaken { get; set; }

        [DataMember(Name = "totalHeal")]
        public int TotalHeal { get; set; }

        [DataMember(Name = "totalPlayerScore")]
        public int TotalPlayerScore { get; set; }

        [DataMember(Name = "totalScoreRank")]
        public int TotalScoreRank { get; set; }

        [DataMember(Name = "totalTimeCrowdControlDealt")]
        public int TotalTimeCrowdControlDealt { get; set; }

        [DataMember(Name = "totalUnitsHealed")]
        public int TotalUnitsHealed { get; set; }

        [DataMember(Name = "tripleKills")]
        public int TripleKills { get; set; }

        [DataMember(Name = "trueDamageDealtPlayer")]
        public int TrueDamageDealtPlayer { get; set; }

        [DataMember(Name = "trueDamageDealtToChampions")]
        public int TrueDamageDealtToChampions { get; set; }

        [DataMember(Name = "trueDamageTaken")]
        public int TrueDamageTaken { get; set; }

        [DataMember(Name = "turretsKilled")]
        public int TurretsKilled { get; set; }

        [DataMember(Name = "unrealKills")]
        public int UnrealKills { get; set; }

        [DataMember(Name = "victoryPointTotal")]
        public int VictoryPointTotal { get; set; }

        [DataMember(Name = "visionWardsBought")]
        public int VisionWardsBought { get; set; }

        [DataMember(Name = "wardKilled")]
        public int WardKilled { get; set; }

        [DataMember(Name = "wardPlaced")]
        public int WardPlaced { get; set; }

        [DataMember(Name = "win")]
        public bool Win { get; set; }

    }
}