using LolStatistics.DataAccess.Exceptions;
using LolStatistics.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LolStatistics.DataAccess.Dao
{
    public class RawStatsDao : BaseDao<RawStats>
    {
        public void Insert(RawStats rawStats)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO RAW_STATS("
            + "GAME_ID, ASSISTS, BARRACKS_KILLED, CHAMPIONS_KILLED, COMBAT_PLAYER_SCORE, CONSUMABLES_PURCHASED, "
            + "DAMAGE_DEALT_PLAYER, DOUBLE_KILLS, FIRST_BLOOD, GOLD, GOLD_EARNED, "
            + "GOLD_SPENT, ITEM0, ITEM1, ITEM2, ITEM3, "
            + "ITEM4, ITEM5, ITEM6, ITEMS_PURCHASED, KILLING_SPREES, "
            + "LARGEST_CRITICAL_STRIKE, LARGEST_KILLING_SPREE, LARGEST_MULTI_KILL, LEGENDARY_ITEMS_CREATED, LEVEL, "
            + "MAGIC_DAMAGE_DEALT_PLAYER, MAGIC_DAMAGE_DEALT_TO_CHAMPIONS, MAGIC_DAMAGE_TAKEN, MINIONS_DENIED, MINIONS_KILLED, "
            + "NEUTRAL_MINIONS_KILLED, NEUTRAL_MINIONS_KILLED_ENEMY_JUNGLE, NEUTRAL_MINIONS_KILLED_YOUR_JUNGLE, NEXUS_KILLED, NODE_CAPTURE, "
            + "NODE_CAPTURE_ASSIST, NODE_NEUTRALIZE, NODE_NEUTRALIZE_ASSIST, NUM_DEATHS, NUM_ITEMS_BOUGHT, "
            + "OBJECTIVE_PLAYER_SCORE, PENTA_KILLS, PHYSICAL_DAMAGE_DEALT_PLAYER, PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS, PHYSICAL_DAMAGE_TAKEN, "
            + "QUADRA_KILLS, SIGHT_WARDS_BOUGHT, SPELL1_CAST, SPELL2_CAST, SPELL3_CAST, "
            + "SPELL4_CAST, SUMMON_SPELL1_CAST, SUMMON_SPELL2_CAST, SUPER_MONSTER_KILLED, TEAM, "
            + "TEAM_OBJECTIVE, TIME_PLAYED, TOTAL_DAMAGE_DEALT, TOTAL_DAMAGE_DEALT_TO_CHAMPIONS, TOTAL_DAMAGE_TAKEN, "
            + "TOTAL_HEAL, TOTAL_PLAYER_SCORE, TOTAL_SCORE_RANK, TOTAL_TIME_CROWD_CONTROL_DEALT, TOTAL_UNITS_HEALED, "
            + "TRIPLE_KILLS, TRUE_DAMAGE_DEALT_PLAYER, TRUE_DAMAGE_DEALT_TO_CHAMPIONS, TRUE_DAMAGE_TAKEN, TURRETS_KILLED, "
            + "UNREAL_KILLS, VICTORY_POINT_TOTAL, VISION_WARDS_BOUGHT, WARD_KILLED, WARD_PLACED, "
            + "WIN) VALUES("
            + "@gameId, @assists, @barracksKilled, @championsKilled, @combatPlayerScore, @consumablesPurchased, "
            + "@damageDealtPlayer, @doubleKills, @firstBlood, @gold, @goldEarned, "
            + "@goldSpent, @item0, @item1, @item2, @item3, "
            + "@item4, @item5, @item6, @itemsPurchased, @killingSprees, "
            + "@largestCriticalStrike, @largestKillingSpree, @largestMultiKill, @legendaryItemsCreated, @level, "
            + "@magicDamageDealtPlayer, @magicDamageDealtToChampions, @magicDamageTaken, @minionsDenied, @minionsKilled, "
            + "@neutralMinionsKilled, @neutralMinionsKilledEnemyJungle, @neutralMinionsKilledYourJungle, @nexusKilled, @nodeCapture, "
            + "@nodeCaptureAssist, @nodeNeutralize, @nodeNeutralizeAssist, @numDeaths, @numItemsBought, "
            + "@objectivePlayerScore, @pentaKills, @physicalDamageDealtPlayer, @physicalDamageDealtToChampions, @physicalDamageTaken, "
            + "@quadraKills, @sightWardsBought, @spell1Cast, @spell2Cast, @spell3Cast, "
            + "@spell4Cast, @summonSpell1Cast, @summonSpell2Cast, @superMonsterKilled, @team, "
            + "@teamObjective, @timePlayed, @totalDamageDealt, @totalDamageDealtToChampions, @totalDamageTaken, "
            + "@totalHeal, @totalPlayerScore, @totalScoreRank, @totalTimeCrowdControlDealt, @totalUnitsHealed, "
            + "@tripleKills, @trueDamageDealtPlayer, @trueDamageDealtToChampions, @trueDamageTaken, @turretsKilled, "
            + "@unrealKills, @victoryPointTotal, @visionWardsBought, @wardKilled, @wardPlaced, "
            + "@win)";

                // Ajout des paramètres
                // cmd.Parameters.AddWithValue("@gameId", gameId);

                // Exécution de la requête
                ExecuteNonQuery(cmd, rawStats, addParameters);
            }
        }

        public RawStats GetByGameID(string id)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM RAW_STATS WHERE GAME_ID = @gameId";

                return ExecuteReader(cmd, id, new Action<MySqlCommand, object>((c, o) => c.Parameters.AddWithValue("@gameId", o)))[0];
            }
        }

        private void addParameters(MySqlCommand cmd, object obj)
        {
            RawStats rawStats = obj as RawStats;

            cmd.Parameters.AddWithValue("@gameId", rawStats.GameId);
            cmd.Parameters.AddWithValue("@assists", rawStats.Assists);
            cmd.Parameters.AddWithValue("@barracksKilled", rawStats.BarracksKilled);
            cmd.Parameters.AddWithValue("@championsKilled", rawStats.ChampionsKilled);
            cmd.Parameters.AddWithValue("@combatPlayerScore", rawStats.CombatPlayerScore);
            cmd.Parameters.AddWithValue("@consumablesPurchased", rawStats.ConsumablesPurchased);
            cmd.Parameters.AddWithValue("@damageDealtPlayer", rawStats.DamageDealtPlayer);
            cmd.Parameters.AddWithValue("@doubleKills", rawStats.DoubleKills);
            cmd.Parameters.AddWithValue("@firstBlood", rawStats.FirstBlood);
            cmd.Parameters.AddWithValue("@gold", rawStats.Gold);
            cmd.Parameters.AddWithValue("@goldEarned", rawStats.GoldEarned);
            cmd.Parameters.AddWithValue("@goldSpent", rawStats.GoldSpent);
            cmd.Parameters.AddWithValue("@item0", rawStats.Item0);
            cmd.Parameters.AddWithValue("@item1", rawStats.Item1);
            cmd.Parameters.AddWithValue("@item2", rawStats.Item2);
            cmd.Parameters.AddWithValue("@item3", rawStats.Item3);
            cmd.Parameters.AddWithValue("@item4", rawStats.Item4);
            cmd.Parameters.AddWithValue("@item5", rawStats.Item5);
            cmd.Parameters.AddWithValue("@item6", rawStats.Item6);
            cmd.Parameters.AddWithValue("@itemsPurchased", rawStats.ItemsPurchased);
            cmd.Parameters.AddWithValue("@killingSprees", rawStats.KillingSprees);
            cmd.Parameters.AddWithValue("@largestCriticalStrike", rawStats.LargestCriticalStrike);
            cmd.Parameters.AddWithValue("@largestKillingSpree", rawStats.LargestKillingSpree);
            cmd.Parameters.AddWithValue("@largestMultiKill", rawStats.LargestMultiKill);
            cmd.Parameters.AddWithValue("@legendaryItemsCreated", rawStats.LegendaryItemsCreated);
            cmd.Parameters.AddWithValue("@level", rawStats.Level);
            cmd.Parameters.AddWithValue("@magicDamageDealtPlayer", rawStats.MagicDamageDealtPlayer);
            cmd.Parameters.AddWithValue("@magicDamageDealtToChampions", rawStats.MagicDamageDealtToChampions);
            cmd.Parameters.AddWithValue("@magicDamageTaken", rawStats.MagicDamageTaken);
            cmd.Parameters.AddWithValue("@minionsDenied", rawStats.MinionsDenied);
            cmd.Parameters.AddWithValue("@minionsKilled", rawStats.MinionsKilled);
            cmd.Parameters.AddWithValue("@neutralMinionsKilled", rawStats.NeutralMinionsKilled);
            cmd.Parameters.AddWithValue("@neutralMinionsKilledEnemyJungle", rawStats.NeutralMinionsKilledEnemyJungle);
            cmd.Parameters.AddWithValue("@neutralMinionsKilledYourJungle", rawStats.NeutralMinionsKilledYourJungle);
            cmd.Parameters.AddWithValue("@nexusKilled", rawStats.NexusKilled);
            cmd.Parameters.AddWithValue("@nodeCapture", rawStats.NodeCapture);
            cmd.Parameters.AddWithValue("@nodeCaptureAssist", rawStats.NodeCaptureAssist);
            cmd.Parameters.AddWithValue("@nodeNeutralize", rawStats.NodeNeutralize);
            cmd.Parameters.AddWithValue("@nodeNeutralizeAssist", rawStats.NodeNeutralizeAssist);
            cmd.Parameters.AddWithValue("@numDeaths", rawStats.NumDeaths);
            cmd.Parameters.AddWithValue("@numItemsBought", rawStats.NumItemsBought);
            cmd.Parameters.AddWithValue("@objectivePlayerScore", rawStats.ObjectivePlayerScore);
            cmd.Parameters.AddWithValue("@pentaKills", rawStats.PentaKills);
            cmd.Parameters.AddWithValue("@physicalDamageDealtPlayer", rawStats.PhysicalDamageDealtPlayer);
            cmd.Parameters.AddWithValue("@physicalDamageDealtToChampions", rawStats.PhysicalDamageDealtToChampions);
            cmd.Parameters.AddWithValue("@physicalDamageTaken", rawStats.PhysicalDamageTaken);
            cmd.Parameters.AddWithValue("@quadraKills", rawStats.QuadraKills);
            cmd.Parameters.AddWithValue("@sightWardsBought", rawStats.SightWardsBought);
            cmd.Parameters.AddWithValue("@spell1Cast", rawStats.Spell1Cast);
            cmd.Parameters.AddWithValue("@spell2Cast", rawStats.Spell2Cast);
            cmd.Parameters.AddWithValue("@spell3Cast", rawStats.Spell3Cast);
            cmd.Parameters.AddWithValue("@spell4Cast", rawStats.Spell4Cast);
            cmd.Parameters.AddWithValue("@summonSpell1Cast", rawStats.SummonSpell1Cast);
            cmd.Parameters.AddWithValue("@summonSpell2Cast", rawStats.SummonSpell2Cast);
            cmd.Parameters.AddWithValue("@superMonsterKilled", rawStats.SuperMonsterKilled);
            cmd.Parameters.AddWithValue("@team", rawStats.Team);
            cmd.Parameters.AddWithValue("@teamObjective", rawStats.TeamObjective);
            cmd.Parameters.AddWithValue("@timePlayed", rawStats.TimePlayed);
            cmd.Parameters.AddWithValue("@totalDamageDealt", rawStats.TotalDamageDealt);
            cmd.Parameters.AddWithValue("@totalDamageDealtToChampions", rawStats.TotalDamageDealtToChampions);
            cmd.Parameters.AddWithValue("@totalDamageTaken", rawStats.TotalDamageTaken);
            cmd.Parameters.AddWithValue("@totalHeal", rawStats.TotalHeal);
            cmd.Parameters.AddWithValue("@totalPlayerScore", rawStats.TotalPlayerScore);
            cmd.Parameters.AddWithValue("@totalScoreRank", rawStats.TotalScoreRank);
            cmd.Parameters.AddWithValue("@totalTimeCrowdControlDealt", rawStats.TotalTimeCrowdControlDealt);
            cmd.Parameters.AddWithValue("@totalUnitsHealed", rawStats.TotalUnitsHealed);
            cmd.Parameters.AddWithValue("@tripleKills", rawStats.TripleKills);
            cmd.Parameters.AddWithValue("@trueDamageDealtPlayer", rawStats.TrueDamageDealtPlayer);
            cmd.Parameters.AddWithValue("@trueDamageDealtToChampions", rawStats.TrueDamageDealtToChampions);
            cmd.Parameters.AddWithValue("@trueDamageTaken", rawStats.TrueDamageTaken);
            cmd.Parameters.AddWithValue("@turretsKilled", rawStats.TurretsKilled);
            cmd.Parameters.AddWithValue("@unrealKills", rawStats.UnrealKills);
            cmd.Parameters.AddWithValue("@victoryPointTotal", rawStats.VictoryPointTotal);
            cmd.Parameters.AddWithValue("@visionWardsBought", rawStats.VisionWardsBought);
            cmd.Parameters.AddWithValue("@wardKilled", rawStats.WardKilled);
            cmd.Parameters.AddWithValue("@wardPlaced", rawStats.WardPlaced);
            cmd.Parameters.AddWithValue("@win", rawStats.Win);
        }

        public override RawStats RecordToDto(MySqlDataReader reader)
        {
            RawStats res = new RawStats();

            // Renseignement des champs
            res.Assists = reader.GetInt32("ASSISTS");
            res.BarracksKilled = reader.GetInt32("BARRACKS_KILLED");
            res.ChampionsKilled = reader.GetInt32("CHAMPIONS_KILLED");
            res.CombatPlayerScore = reader.GetInt32("COMBAT_PLAYER_SCORE");
            res.ConsumablesPurchased = reader.GetInt32("CONSUMABLES_PURCHASED");
            res.DamageDealtPlayer = reader.GetInt32("DAMAGE_DEALT_PLAYER");
            res.DoubleKills = reader.GetInt32("DOUBLE_KILLS");
            res.FirstBlood = reader.GetInt32("FIRST_BLOOD");
            res.Gold = reader.GetInt32("GOLD");
            res.GoldEarned = reader.GetInt32("GOLD_EARNED");
            res.GoldSpent = reader.GetInt32("GOLD_SPENT");
            res.Item0 = reader.GetInt32("ITEM0");
            res.Item1 = reader.GetInt32("ITEM1");
            res.Item2 = reader.GetInt32("ITEM2");
            res.Item3 = reader.GetInt32("ITEM3");
            res.Item4 = reader.GetInt32("ITEM4");
            res.Item5 = reader.GetInt32("ITEM5");
            res.Item6 = reader.GetInt32("ITEM6");
            res.ItemsPurchased = reader.GetInt32("ITEMS_PURCHASED");
            res.KillingSprees = reader.GetInt32("KILLING_SPREES");
            res.LargestCriticalStrike = reader.GetInt32("LARGEST_CRITICAL_STRIKE");
            res.LargestKillingSpree = reader.GetInt32("LARGEST_KILLING_SPREE");
            res.LargestMultiKill = reader.GetInt32("LARGEST_MULTI_KILL");
            res.LegendaryItemsCreated = reader.GetInt32("LEGENDARY_ITEMS_CREATED");
            res.Level = reader.GetInt32("LEVEL");
            res.MagicDamageDealtPlayer = reader.GetInt32("MAGIC_DAMAGE_DEALT_PLAYER");
            res.MagicDamageDealtToChampions = reader.GetInt32("MAGIC_DAMAGE_DEALT_TO_CHAMPIONS");
            res.MagicDamageTaken = reader.GetInt32("MAGIC_DAMAGE_TAKEN");
            res.MinionsDenied = reader.GetInt32("MINIONS_DENIED");
            res.MinionsKilled = reader.GetInt32("MINIONS_KILLED");
            res.NeutralMinionsKilled = reader.GetInt32("NEUTRAL_MINIONS_KILLED");
            res.NeutralMinionsKilledEnemyJungle = reader.GetInt32("NEUTRAL_MINIONS_KILLED_ENEMY_JUNGLE");
            res.NeutralMinionsKilledYourJungle = reader.GetInt32("NEUTRAL_MINIONS_KILLED_YOUR_JUNGLE");
            res.NexusKilled = reader.GetBoolean("NEXUS_KILLED");
            res.NodeCapture = reader.GetInt32("NODE_CAPTURE");
            res.NodeCaptureAssist = reader.GetInt32("NODE_CAPTURE_ASSIST");
            res.NodeNeutralize = reader.GetInt32("NODE_NEUTRALIZE");
            res.NodeNeutralizeAssist = reader.GetInt32("NODE_NEUTRALIZE_ASSIST");
            res.NumDeaths = reader.GetInt32("NUM_DEATHS");
            res.NumItemsBought = reader.GetInt32("NUM_ITEMS_BOUGHT");
            res.ObjectivePlayerScore = reader.GetInt32("OBJECTIVE_PLAYER_SCORE");
            res.PentaKills = reader.GetInt32("PENTA_KILLS");
            res.PhysicalDamageDealtPlayer = reader.GetInt32("PHYSICAL_DAMAGE_DEALT_PLAYER");
            res.PhysicalDamageDealtToChampions = reader.GetInt32("PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS");
            res.PhysicalDamageTaken = reader.GetInt32("PHYSICAL_DAMAGE_TAKEN");
            res.QuadraKills = reader.GetInt32("QUADRA_KILLS");
            res.SightWardsBought = reader.GetInt32("SIGHT_WARDS_BOUGHT");
            res.Spell1Cast = reader.GetInt32("SPELL1_CAST");
            res.Spell2Cast = reader.GetInt32("SPELL2_CAST");
            res.Spell3Cast = reader.GetInt32("SPELL3_CAST");
            res.Spell4Cast = reader.GetInt32("SPELL4_CAST");
            res.SummonSpell1Cast = reader.GetInt32("SUMMON_SPELL1_CAST");
            res.SummonSpell2Cast = reader.GetInt32("SUMMON_SPELL2_CAST");
            res.SuperMonsterKilled = reader.GetInt32("SUPER_MONSTER_KILLED");
            res.Team = reader.GetInt32("TEAM");
            res.TeamObjective = reader.GetInt32("TEAM_OBJECTIVE");
            res.TimePlayed = reader.GetInt32("TIME_PLAYED");
            res.TotalDamageDealt = reader.GetInt32("TOTAL_DAMAGE_DEALT");
            res.TotalDamageDealtToChampions = reader.GetInt32("TOTAL_DAMAGE_DEALT_TO_CHAMPIONS");
            res.TotalDamageTaken = reader.GetInt32("TOTAL_DAMAGE_TAKEN");
            res.TotalHeal = reader.GetInt32("TOTAL_HEAL");
            res.TotalPlayerScore = reader.GetInt32("TOTAL_PLAYER_SCORE");
            res.TotalScoreRank = reader.GetInt32("TOTAL_SCORE_RANK");
            res.TotalTimeCrowdControlDealt = reader.GetInt32("TOTAL_TIME_CROWD_CONTROL_DEALT");
            res.TotalUnitsHealed = reader.GetInt32("TOTAL_UNITS_HEALED");
            res.TripleKills = reader.GetInt32("TRIPLE_KILLS");
            res.TrueDamageDealtPlayer = reader.GetInt32("TRUE_DAMAGE_DEALT_PLAYER");
            res.TrueDamageDealtToChampions = reader.GetInt32("TRUE_DAMAGE_DEALT_TO_CHAMPIONS");
            res.TrueDamageTaken = reader.GetInt32("TRUE_DAMAGE_TAKEN");
            res.TurretsKilled = reader.GetInt32("TURRETS_KILLED");
            res.UnrealKills = reader.GetInt32("UNREAL_KILLS");
            res.VictoryPointTotal = reader.GetInt32("VICTORY_POINT_TOTAL");
            res.VisionWardsBought = reader.GetInt32("VISION_WARDS_BOUGHT");
            res.WardKilled = reader.GetInt32("WARD_KILLED");
            res.WardPlaced = reader.GetInt32("WARD_PLACED");
            res.Win = reader.GetBoolean("WIN");

            return res;
        }
    }
}
