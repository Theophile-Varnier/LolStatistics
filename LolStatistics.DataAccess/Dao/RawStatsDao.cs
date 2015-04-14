using System.Data.Common;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.Stats;
using MySql.Data.MySqlClient;

namespace LolStatistics.DataAccess.Dao
{
    /// <summary>
    /// Dao associée aux statistiques
    /// </summary>
    public class RawStatsDao : BaseDao<RawStats>
    {
        /// <summary>
        /// Insert une ligne de statistiques en base
        /// </summary>
        /// <param name="rawStats">Les stats à insérer</param>
        /// <param name="conn">La connexion à utiliser</param>
        public void Insert(RawStats rawStats, DbConnection conn, DbTransaction tran)
        {
            const string cmd = "INSERT INTO RAW_STATS("
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
            // cmd.AddWithValue("@gameId", gameId);

            // Exécution de la requête
            ExecuteNonQuery(cmd, conn, rawStats, addParameters, tran);
        }

        /// <summary>
        /// Récupère les statistiques d'une partie
        /// </summary>
        /// <param name="id">L'id de la partie</param>
        /// <returns></returns>
        public RawStats GetByGameId(string id, DbConnection conn)
        {
            const string cmd = "SELECT * FROM RAW_STATS WHERE GAME_ID = @gameId";

            return ExecuteReader(cmd, conn, id, ((c, o) => c.AddWithValue("@gameId", o)))[0];
        }

        /// <summary>
        /// Méthode d'ajout des paramètres pour la requête d'insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle on ajoute les paramètres</param>
        /// <param name="obj">L'objet qui contient les informations</param>
        private void addParameters(Command cmd, object obj)
        {
            RawStats rawStats = obj as RawStats;

            if (rawStats == null) return;

            cmd.AddWithValue("@gameId", rawStats.GameId);
            cmd.AddWithValue("@assists", rawStats.Assists);
            cmd.AddWithValue("@barracksKilled", rawStats.BarracksKilled);
            cmd.AddWithValue("@championsKilled", rawStats.ChampionsKilled);
            cmd.AddWithValue("@combatPlayerScore", rawStats.CombatPlayerScore);
            cmd.AddWithValue("@consumablesPurchased", rawStats.ConsumablesPurchased);
            cmd.AddWithValue("@damageDealtPlayer", rawStats.DamageDealtPlayer);
            cmd.AddWithValue("@doubleKills", rawStats.DoubleKills);
            cmd.AddWithValue("@firstBlood", rawStats.FirstBlood);
            cmd.AddWithValue("@gold", rawStats.Gold);
            cmd.AddWithValue("@goldEarned", rawStats.GoldEarned);
            cmd.AddWithValue("@goldSpent", rawStats.GoldSpent);
            cmd.AddWithValue("@item0", rawStats.Item0);
            cmd.AddWithValue("@item1", rawStats.Item1);
            cmd.AddWithValue("@item2", rawStats.Item2);
            cmd.AddWithValue("@item3", rawStats.Item3);
            cmd.AddWithValue("@item4", rawStats.Item4);
            cmd.AddWithValue("@item5", rawStats.Item5);
            cmd.AddWithValue("@item6", rawStats.Item6);
            cmd.AddWithValue("@itemsPurchased", rawStats.ItemsPurchased);
            cmd.AddWithValue("@killingSprees", rawStats.KillingSprees);
            cmd.AddWithValue("@largestCriticalStrike", rawStats.LargestCriticalStrike);
            cmd.AddWithValue("@largestKillingSpree", rawStats.LargestKillingSpree);
            cmd.AddWithValue("@largestMultiKill", rawStats.LargestMultiKill);
            cmd.AddWithValue("@legendaryItemsCreated", rawStats.LegendaryItemsCreated);
            cmd.AddWithValue("@level", rawStats.Level);
            cmd.AddWithValue("@magicDamageDealtPlayer", rawStats.MagicDamageDealtPlayer);
            cmd.AddWithValue("@magicDamageDealtToChampions", rawStats.MagicDamageDealtToChampions);
            cmd.AddWithValue("@magicDamageTaken", rawStats.MagicDamageTaken);
            cmd.AddWithValue("@minionsDenied", rawStats.MinionsDenied);
            cmd.AddWithValue("@minionsKilled", rawStats.MinionsKilled);
            cmd.AddWithValue("@neutralMinionsKilled", rawStats.NeutralMinionsKilled);
            cmd.AddWithValue("@neutralMinionsKilledEnemyJungle", rawStats.NeutralMinionsKilledEnemyJungle);
            cmd.AddWithValue("@neutralMinionsKilledYourJungle", rawStats.NeutralMinionsKilledYourJungle);
            cmd.AddWithValue("@nexusKilled", rawStats.NexusKilled);
            cmd.AddWithValue("@nodeCapture", rawStats.NodeCapture);
            cmd.AddWithValue("@nodeCaptureAssist", rawStats.NodeCaptureAssist);
            cmd.AddWithValue("@nodeNeutralize", rawStats.NodeNeutralize);
            cmd.AddWithValue("@nodeNeutralizeAssist", rawStats.NodeNeutralizeAssist);
            cmd.AddWithValue("@numDeaths", rawStats.NumDeaths);
            cmd.AddWithValue("@numItemsBought", rawStats.NumItemsBought);
            cmd.AddWithValue("@objectivePlayerScore", rawStats.ObjectivePlayerScore);
            cmd.AddWithValue("@pentaKills", rawStats.PentaKills);
            cmd.AddWithValue("@physicalDamageDealtPlayer", rawStats.PhysicalDamageDealtPlayer);
            cmd.AddWithValue("@physicalDamageDealtToChampions", rawStats.PhysicalDamageDealtToChampions);
            cmd.AddWithValue("@physicalDamageTaken", rawStats.PhysicalDamageTaken);
            cmd.AddWithValue("@quadraKills", rawStats.QuadraKills);
            cmd.AddWithValue("@sightWardsBought", rawStats.SightWardsBought);
            cmd.AddWithValue("@spell1Cast", rawStats.Spell1Cast);
            cmd.AddWithValue("@spell2Cast", rawStats.Spell2Cast);
            cmd.AddWithValue("@spell3Cast", rawStats.Spell3Cast);
            cmd.AddWithValue("@spell4Cast", rawStats.Spell4Cast);
            cmd.AddWithValue("@summonSpell1Cast", rawStats.SummonSpell1Cast);
            cmd.AddWithValue("@summonSpell2Cast", rawStats.SummonSpell2Cast);
            cmd.AddWithValue("@superMonsterKilled", rawStats.SuperMonsterKilled);
            cmd.AddWithValue("@team", rawStats.Team);
            cmd.AddWithValue("@teamObjective", rawStats.TeamObjective);
            cmd.AddWithValue("@timePlayed", rawStats.TimePlayed);
            cmd.AddWithValue("@totalDamageDealt", rawStats.TotalDamageDealt);
            cmd.AddWithValue("@totalDamageDealtToChampions", rawStats.TotalDamageDealtToChampions);
            cmd.AddWithValue("@totalDamageTaken", rawStats.TotalDamageTaken);
            cmd.AddWithValue("@totalHeal", rawStats.TotalHeal);
            cmd.AddWithValue("@totalPlayerScore", rawStats.TotalPlayerScore);
            cmd.AddWithValue("@totalScoreRank", rawStats.TotalScoreRank);
            cmd.AddWithValue("@totalTimeCrowdControlDealt", rawStats.TotalTimeCrowdControlDealt);
            cmd.AddWithValue("@totalUnitsHealed", rawStats.TotalUnitsHealed);
            cmd.AddWithValue("@tripleKills", rawStats.TripleKills);
            cmd.AddWithValue("@trueDamageDealtPlayer", rawStats.TrueDamageDealtPlayer);
            cmd.AddWithValue("@trueDamageDealtToChampions", rawStats.TrueDamageDealtToChampions);
            cmd.AddWithValue("@trueDamageTaken", rawStats.TrueDamageTaken);
            cmd.AddWithValue("@turretsKilled", rawStats.TurretsKilled);
            cmd.AddWithValue("@unrealKills", rawStats.UnrealKills);
            cmd.AddWithValue("@victoryPointTotal", rawStats.VictoryPointTotal);
            cmd.AddWithValue("@visionWardsBought", rawStats.VisionWardsBought);
            cmd.AddWithValue("@wardKilled", rawStats.WardKilled);
            cmd.AddWithValue("@wardPlaced", rawStats.WardPlaced);
            cmd.AddWithValue("@win", rawStats.Win);
        }

        /// <summary>
        /// Map un objet depuis un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement à mapper</param>
        /// <returns>L'objet mappé</returns>
        public override RawStats RecordToDto(DbDataReader reader)
        {
            RawStats res = new RawStats
            {
                Assists = reader.GetInt32("ASSISTS"),
                BarracksKilled = reader.GetInt32("BARRACKS_KILLED"),
                ChampionsKilled = reader.GetInt32("CHAMPIONS_KILLED"),
                CombatPlayerScore = reader.GetInt32("COMBAT_PLAYER_SCORE"),
                ConsumablesPurchased = reader.GetInt32("CONSUMABLES_PURCHASED"),
                DamageDealtPlayer = reader.GetInt32("DAMAGE_DEALT_PLAYER"),
                DoubleKills = reader.GetInt32("DOUBLE_KILLS"),
                FirstBlood = reader.GetInt32("FIRST_BLOOD"),
                Gold = reader.GetInt32("GOLD"),
                GoldEarned = reader.GetInt32("GOLD_EARNED"),
                GoldSpent = reader.GetInt32("GOLD_SPENT"),
                Item0 = reader.GetInt32("ITEM0"),
                Item1 = reader.GetInt32("ITEM1"),
                Item2 = reader.GetInt32("ITEM2"),
                Item3 = reader.GetInt32("ITEM3"),
                Item4 = reader.GetInt32("ITEM4"),
                Item5 = reader.GetInt32("ITEM5"),
                Item6 = reader.GetInt32("ITEM6"),
                ItemsPurchased = reader.GetInt32("ITEMS_PURCHASED"),
                KillingSprees = reader.GetInt32("KILLING_SPREES"),
                LargestCriticalStrike = reader.GetInt32("LARGEST_CRITICAL_STRIKE"),
                LargestKillingSpree = reader.GetInt32("LARGEST_KILLING_SPREE"),
                LargestMultiKill = reader.GetInt32("LARGEST_MULTI_KILL"),
                LegendaryItemsCreated = reader.GetInt32("LEGENDARY_ITEMS_CREATED"),
                Level = reader.GetInt32("LEVEL"),
                MagicDamageDealtPlayer = reader.GetInt32("MAGIC_DAMAGE_DEALT_PLAYER"),
                MagicDamageDealtToChampions = reader.GetInt32("MAGIC_DAMAGE_DEALT_TO_CHAMPIONS"),
                MagicDamageTaken = reader.GetInt32("MAGIC_DAMAGE_TAKEN"),
                MinionsDenied = reader.GetInt32("MINIONS_DENIED"),
                MinionsKilled = reader.GetInt32("MINIONS_KILLED"),
                NeutralMinionsKilled = reader.GetInt32("NEUTRAL_MINIONS_KILLED"),
                NeutralMinionsKilledEnemyJungle = reader.GetInt32("NEUTRAL_MINIONS_KILLED_ENEMY_JUNGLE"),
                NeutralMinionsKilledYourJungle = reader.GetInt32("NEUTRAL_MINIONS_KILLED_YOUR_JUNGLE"),
                NexusKilled = reader.GetBoolean("NEXUS_KILLED"),
                NodeCapture = reader.GetInt32("NODE_CAPTURE"),
                NodeCaptureAssist = reader.GetInt32("NODE_CAPTURE_ASSIST"),
                NodeNeutralize = reader.GetInt32("NODE_NEUTRALIZE"),
                NodeNeutralizeAssist = reader.GetInt32("NODE_NEUTRALIZE_ASSIST"),
                NumDeaths = reader.GetInt32("NUM_DEATHS"),
                NumItemsBought = reader.GetInt32("NUM_ITEMS_BOUGHT"),
                ObjectivePlayerScore = reader.GetInt32("OBJECTIVE_PLAYER_SCORE"),
                PentaKills = reader.GetInt32("PENTA_KILLS"),
                PhysicalDamageDealtPlayer = reader.GetInt32("PHYSICAL_DAMAGE_DEALT_PLAYER"),
                PhysicalDamageDealtToChampions = reader.GetInt32("PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS"),
                PhysicalDamageTaken = reader.GetInt32("PHYSICAL_DAMAGE_TAKEN"),
                QuadraKills = reader.GetInt32("QUADRA_KILLS"),
                SightWardsBought = reader.GetInt32("SIGHT_WARDS_BOUGHT"),
                Spell1Cast = reader.GetInt32("SPELL1_CAST"),
                Spell2Cast = reader.GetInt32("SPELL2_CAST"),
                Spell3Cast = reader.GetInt32("SPELL3_CAST"),
                Spell4Cast = reader.GetInt32("SPELL4_CAST"),
                SummonSpell1Cast = reader.GetInt32("SUMMON_SPELL1_CAST"),
                SummonSpell2Cast = reader.GetInt32("SUMMON_SPELL2_CAST"),
                SuperMonsterKilled = reader.GetInt32("SUPER_MONSTER_KILLED"),
                Team = reader.GetInt32("TEAM"),
                TeamObjective = reader.GetInt32("TEAM_OBJECTIVE"),
                TimePlayed = reader.GetInt32("TIME_PLAYED"),
                TotalDamageDealt = reader.GetInt32("TOTAL_DAMAGE_DEALT"),
                TotalDamageDealtToChampions = reader.GetInt32("TOTAL_DAMAGE_DEALT_TO_CHAMPIONS"),
                TotalDamageTaken = reader.GetInt32("TOTAL_DAMAGE_TAKEN"),
                TotalHeal = reader.GetInt32("TOTAL_HEAL"),
                TotalPlayerScore = reader.GetInt32("TOTAL_PLAYER_SCORE"),
                TotalScoreRank = reader.GetInt32("TOTAL_SCORE_RANK"),
                TotalTimeCrowdControlDealt = reader.GetInt32("TOTAL_TIME_CROWD_CONTROL_DEALT"),
                TotalUnitsHealed = reader.GetInt32("TOTAL_UNITS_HEALED"),
                TripleKills = reader.GetInt32("TRIPLE_KILLS"),
                TrueDamageDealtPlayer = reader.GetInt32("TRUE_DAMAGE_DEALT_PLAYER"),
                TrueDamageDealtToChampions = reader.GetInt32("TRUE_DAMAGE_DEALT_TO_CHAMPIONS"),
                TrueDamageTaken = reader.GetInt32("TRUE_DAMAGE_TAKEN"),
                TurretsKilled = reader.GetInt32("TURRETS_KILLED"),
                UnrealKills = reader.GetInt32("UNREAL_KILLS"),
                VictoryPointTotal = reader.GetInt32("VICTORY_POINT_TOTAL"),
                VisionWardsBought = reader.GetInt32("VISION_WARDS_BOUGHT"),
                WardKilled = reader.GetInt32("WARD_KILLED"),
                WardPlaced = reader.GetInt32("WARD_PLACED"),
                Win = reader.GetBoolean("WIN")
            };

            return res;
        }
    }
}
