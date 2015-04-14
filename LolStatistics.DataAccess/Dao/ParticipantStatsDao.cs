using System.Data.Common;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.Stats;
using MySql.Data.MySqlClient;
using System;

namespace LolStatistics.DataAccess.Dao
{
    /// <summary>
    /// Dao associée aux statistiques
    /// </summary>
    public class ParticipantStatsDao : BaseDao<ParticipantStats>
    {
        /// <summary>
        /// Insert une série de statistiques en base
        /// </summary>
        /// <param name="participantStats">Les statistiques à insérer</param>
        public void Insert(ParticipantStats participantStats, DbConnection conn, DbTransaction tran)
        {
            const string cmd = "INSERT INTO PARTICIPANT_STATS("
            + "PARTICIPANT_ID, ASSISTS, CHAMP_LEVEL, COMBAT_PLAYER_SCORE, DEATHS, "
            + "DOUBLE_KILLS, FIRST_BLOOD_ASSIST, FIRST_BLOOD_KILL, FIRST_INHIBITOR_ASSIST, FIRST_INHIBITOR_KILL, "
            + "FIRST_TOWER_ASSIST, FIRST_TOWER_KILL, GOLD_EARNED, GOLD_SPENT, INHIBITOR_KILLS, "
            + "ITEM0, ITEM1, ITEM2, ITEM3, ITEM4, "
            + "ITEM5, ITEM6, KILLING_SPREES, KILLS, LARGEST_CRITICAL_STRIKE, "
            + "LARGEST_KILLING_SPREE, LARGEST_MULTI_KILL, MAGIC_DAMAGE_DEALT, MAGIC_DAMAGE_DEALT_TO_CHAMPIONS, MAGIC_DAMAGE_TAKEN, "
            + "MINIONS_KILLED, NEUTRAL_MINIONS_KILLED, NEUTRAL_MINIONS_KILLED_ENEMY_JUNGLE, NEUTRAL_MINIONS_KILLED_TEAM_JUNGLE, NODE_CAPTURE, "
            + "NODE_CAPTURE_ASSIST, NODE_NEUTRALIZE, NODE_NEUTRALIZE_ASSIST, OBJECTIVE_PLAYER_SCORE, PENTA_KILLS, "
            + "PHYSICAL_DAMAGE_DEALT, PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS, PHYSICAL_DAMAGE_TAKEN, QUADRA_KILLS, SIGHT_WARDS_BOUGHT_IN_GAME, "
            + "TEAM_OBJECTIVE, TOTAL_DAMAGE_DEALT, TOTAL_DAMAGE_DEALT_TO_CHAMPIONS, TOTAL_DAMAGE_TAKEN, TOTAL_HEAL, "
            + "TOTAL_PLAYER_SCORE, TOTAL_SCORE_RANK, TOTAL_TIME_CROWD_CONTROL_DEALT, TOTAL_UNITS_HEALED, TOWER_KILLS, "
            + "TRIPLE_KILLS, TRUE_DAMAGE_DEALT, TRUE_DAMAGE_DEALT_TO_CHAMPIONS, TRUE_DAMAGE_TAKEN, UNREAL_KILLS, "
            + "VISION_WARDS_BOUGHT_IN_GAME, WARDS_KILLED, WARDS_PLACED, WINNER) VALUES("
            + "@participantId, @assists, @champLevel, @combatPlayerScore, @deaths, "
            + "@doubleKills, @firstBloodAssist, @firstBloodKill, @firstInhibitorAssist, @firstInhibitorKill, "
            + "@firstTowerAssist, @firstTowerKill, @goldEarned, @goldSpent, @inhibitorKills, "
            + "@item0, @item1, @item2, @item3, @item4, "
            + "@item5, @item6, @killingSprees, @kills, @largestCriticalStrike, "
            + "@largestKillingSpree, @largestMultiKill, @magicDamageDealt, @magicDamageDealtToChampions, @magicDamageTaken, "
            + "@minionsKilled, @neutralMinionsKilled, @neutralMinionsKilledEnemyJungle, @neutralMinionsKilledTeamJungle, @nodeCapture, "
            + "@nodeCaptureAssist, @nodeNeutralize, @nodeNeutralizeAssist, @objectivePlayerScore, @pentaKills, "
            + "@physicalDamageDealt, @physicalDamageDealtToChampions, @physicalDamageTaken, @quadraKills, @sightWardsBoughtInGame, "
            + "@teamObjective, @totalDamageDealt, @totalDamageDealtToChampions, @totalDamageTaken, @totalHeal, "
            + "@totalPlayerScore, @totalScoreRank, @totalTimeCrowdControlDealt, @totalUnitsHealed, @towerKills, "
            + "@tripleKills, @trueDamageDealt, @trueDamageDealtToChampions, @trueDamageTaken, @unrealKills, "
            + "@visionWardsBoughtInGame, @wardsKilled, @wardsPlaced, @winner)";

                // Exécution de la requête
                ExecuteNonQuery(cmd, conn, participantStats, addParameters, tran);
        }

        /// <summary>
        /// Map un objet depuis un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement à mapper</param>
        /// <returns></returns>
        public override ParticipantStats RecordToDto(DbDataReader reader)
        {
            ParticipantStats res = new ParticipantStats
            {
                ParticipantId = reader.GetString("PARTICIPANT_ID"),
                Assists = reader.GetInt64("ASSISTS"),
                ChampLevel = reader.GetInt64("CHAMP_LEVEL"),
                CombatPlayerScore = reader.GetInt64("COMBAT_PLAYER_SCORE"),
                Deaths = reader.GetInt64("DEATHS"),
                DoubleKills = reader.GetInt64("DOUBLE_KILLS"),
                FirstBloodAssist = reader.GetBoolean("FIRST_BLOOD_ASSIST"),
                FirstBloodKill = reader.GetBoolean("FIRST_BLOOD_KILL"),
                FirstInhibitorAssist = reader.GetBoolean("FIRST_INHIBITOR_ASSIST"),
                FirstInhibitorKill = reader.GetBoolean("FIRST_INHIBITOR_KILL"),
                FirstTowerAssist = reader.GetBoolean("FIRST_TOWER_ASSIST"),
                FirstTowerKill = reader.GetBoolean("FIRST_TOWER_KILL"),
                GoldEarned = reader.GetInt64("GOLD_EARNED"),
                GoldSpent = reader.GetInt64("GOLD_SPENT"),
                InhibitorKills = reader.GetInt64("INHIBITOR_KILLS"),
                Item0 = reader.GetInt64("ITEM0"),
                Item1 = reader.GetInt64("ITEM1"),
                Item2 = reader.GetInt64("ITEM2"),
                Item3 = reader.GetInt64("ITEM3"),
                Item4 = reader.GetInt64("ITEM4"),
                Item5 = reader.GetInt64("ITEM5"),
                Item6 = reader.GetInt64("ITEM6"),
                KillingSprees = reader.GetInt64("KILLING_SPREES"),
                Kills = reader.GetInt64("KILLS"),
                LargestCriticalStrike = reader.GetInt64("LARGEST_CRITICAL_STRIKE"),
                LargestKillingSpree = reader.GetInt64("LARGEST_KILLING_SPREE"),
                LargestMultiKill = reader.GetInt64("LARGEST_MULTI_KILL"),
                MagicDamageDealt = reader.GetInt64("MAGIC_DAMAGE_DEALT"),
                MagicDamageDealtToChampions = reader.GetInt64("MAGIC_DAMAGE_DEALT_TO_CHAMPIONS"),
                MagicDamageTaken = reader.GetInt64("MAGIC_DAMAGE_TAKEN"),
                MinionsKilled = reader.GetInt64("MINIONS_KILLED"),
                NeutralMinionsKilled = reader.GetInt64("NEUTRAL_MINIONS_KILLED"),
                NeutralMinionsKilledEnemyJungle = reader.GetInt64("NEUTRAL_MINIONS_KILLED_ENEMY_JUNGLE"),
                NeutralMinionsKilledTeamJungle = reader.GetInt64("NEUTRAL_MINIONS_KILLED_TEAM_JUNGLE"),
                NodeCapture = reader.GetInt64("NODE_CAPTURE"),
                NodeCaptureAssist = reader.GetInt64("NODE_CAPTURE_ASSIST"),
                NodeNeutralize = reader.GetInt64("NODE_NEUTRALIZE"),
                NodeNeutralizeAssist = reader.GetInt64("NODE_NEUTRALIZE_ASSIST"),
                ObjectivePlayerScore = reader.GetInt64("OBJECTIVE_PLAYER_SCORE"),
                PentaKills = reader.GetInt64("PENTA_KILLS"),
                PhysicalDamageDealt = reader.GetInt64("PHYSICAL_DAMAGE_DEALT"),
                PhysicalDamageDealtToChampions = reader.GetInt64("PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS"),
                PhysicalDamageTaken = reader.GetInt64("PHYSICAL_DAMAGE_TAKEN"),
                QuadraKills = reader.GetInt64("QUADRA_KILLS"),
                SightWardsBoughtInGame = reader.GetInt64("SIGHT_WARDS_BOUGHT_IN_GAME"),
                TeamObjective = reader.GetInt64("TEAM_OBJECTIVE"),
                TotalDamageDealt = reader.GetInt64("TOTAL_DAMAGE_DEALT"),
                TotalDamageDealtToChampions = reader.GetInt64("TOTAL_DAMAGE_DEALT_TO_CHAMPIONS"),
                TotalDamageTaken = reader.GetInt64("TOTAL_DAMAGE_TAKEN"),
                TotalHeal = reader.GetInt64("TOTAL_HEAL"),
                TotalPlayerScore = reader.GetInt64("TOTAL_PLAYER_SCORE"),
                TotalScoreRank = reader.GetInt64("TOTAL_SCORE_RANK"),
                TotalTimeCrowdControlDealt = reader.GetInt64("TOTAL_TIME_CROWD_CONTROL_DEALT"),
                TotalUnitsHealed = reader.GetInt64("TOTAL_UNITS_HEALED"),
                TowerKills = reader.GetInt64("TOWER_KILLS"),
                TripleKills = reader.GetInt64("TRIPLE_KILLS"),
                TrueDamageDealt = reader.GetInt64("TRUE_DAMAGE_DEALT"),
                TrueDamageDealtToChampions = reader.GetInt64("TRUE_DAMAGE_DEALT_TO_CHAMPIONS"),
                TrueDamageTaken = reader.GetInt64("TRUE_DAMAGE_TAKEN"),
                UnrealKills = reader.GetInt64("UNREAL_KILLS"),
                VisionWardsBoughtInGame = reader.GetInt64("VISION_WARDS_BOUGHT_IN_GAME"),
                WardsKilled = reader.GetInt64("WARDS_KILLED"),
                WardsPlaced = reader.GetInt64("WARDS_PLACED"),
                Winner = reader.GetBoolean("WINNER")
            };

            // Renseignement des champs

            return res;

        }

        /// <summary>
        /// Méthode d'ajout des paramètres pour la requête d'insertion
        /// </summary>
        /// <param name="cmd">La commande à laquelle on ajoute les paramètres</param>
        /// <param name="obj">L'objet qui contient les informations</param>
        private void addParameters(DbCommand cmd, Object obj)
        {
            ParticipantStats participantStats = obj as ParticipantStats;

            // Ajout des paramètres
            cmd.AddWithValue("@participantId", participantStats.ParticipantId);
            cmd.AddWithValue("@assists", participantStats.Assists);
            cmd.AddWithValue("@champLevel", participantStats.ChampLevel);
            cmd.AddWithValue("@combatPlayerScore", participantStats.CombatPlayerScore);
            cmd.AddWithValue("@deaths", participantStats.Deaths);
            cmd.AddWithValue("@doubleKills", participantStats.DoubleKills);
            cmd.AddWithValue("@firstBloodAssist", participantStats.FirstBloodAssist);
            cmd.AddWithValue("@firstBloodKill", participantStats.FirstBloodKill);
            cmd.AddWithValue("@firstInhibitorAssist", participantStats.FirstInhibitorAssist);
            cmd.AddWithValue("@firstInhibitorKill", participantStats.FirstInhibitorKill);
            cmd.AddWithValue("@firstTowerAssist", participantStats.FirstTowerAssist);
            cmd.AddWithValue("@firstTowerKill", participantStats.FirstTowerKill);
            cmd.AddWithValue("@goldEarned", participantStats.GoldEarned);
            cmd.AddWithValue("@goldSpent", participantStats.GoldSpent);
            cmd.AddWithValue("@inhibitorKills", participantStats.InhibitorKills);
            cmd.AddWithValue("@item0", participantStats.Item0);
            cmd.AddWithValue("@item1", participantStats.Item1);
            cmd.AddWithValue("@item2", participantStats.Item2);
            cmd.AddWithValue("@item3", participantStats.Item3);
            cmd.AddWithValue("@item4", participantStats.Item4);
            cmd.AddWithValue("@item5", participantStats.Item5);
            cmd.AddWithValue("@item6", participantStats.Item6);
            cmd.AddWithValue("@killingSprees", participantStats.KillingSprees);
            cmd.AddWithValue("@kills", participantStats.Kills);
            cmd.AddWithValue("@largestCriticalStrike", participantStats.LargestCriticalStrike);
            cmd.AddWithValue("@largestKillingSpree", participantStats.LargestKillingSpree);
            cmd.AddWithValue("@largestMultiKill", participantStats.LargestMultiKill);
            cmd.AddWithValue("@magicDamageDealt", participantStats.MagicDamageDealt);
            cmd.AddWithValue("@magicDamageDealtToChampions", participantStats.MagicDamageDealtToChampions);
            cmd.AddWithValue("@magicDamageTaken", participantStats.MagicDamageTaken);
            cmd.AddWithValue("@minionsKilled", participantStats.MinionsKilled);
            cmd.AddWithValue("@neutralMinionsKilled", participantStats.NeutralMinionsKilled);
            cmd.AddWithValue("@neutralMinionsKilledEnemyJungle", participantStats.NeutralMinionsKilledEnemyJungle);
            cmd.AddWithValue("@neutralMinionsKilledTeamJungle", participantStats.NeutralMinionsKilledTeamJungle);
            cmd.AddWithValue("@nodeCapture", participantStats.NodeCapture);
            cmd.AddWithValue("@nodeCaptureAssist", participantStats.NodeCaptureAssist);
            cmd.AddWithValue("@nodeNeutralize", participantStats.NodeNeutralize);
            cmd.AddWithValue("@nodeNeutralizeAssist", participantStats.NodeNeutralizeAssist);
            cmd.AddWithValue("@objectivePlayerScore", participantStats.ObjectivePlayerScore);
            cmd.AddWithValue("@pentaKills", participantStats.PentaKills);
            cmd.AddWithValue("@physicalDamageDealt", participantStats.PhysicalDamageDealt);
            cmd.AddWithValue("@physicalDamageDealtToChampions", participantStats.PhysicalDamageDealtToChampions);
            cmd.AddWithValue("@physicalDamageTaken", participantStats.PhysicalDamageTaken);
            cmd.AddWithValue("@quadraKills", participantStats.QuadraKills);
            cmd.AddWithValue("@sightWardsBoughtInGame", participantStats.SightWardsBoughtInGame);
            cmd.AddWithValue("@teamObjective", participantStats.TeamObjective);
            cmd.AddWithValue("@totalDamageDealt", participantStats.TotalDamageDealt);
            cmd.AddWithValue("@totalDamageDealtToChampions", participantStats.TotalDamageDealtToChampions);
            cmd.AddWithValue("@totalDamageTaken", participantStats.TotalDamageTaken);
            cmd.AddWithValue("@totalHeal", participantStats.TotalHeal);
            cmd.AddWithValue("@totalPlayerScore", participantStats.TotalPlayerScore);
            cmd.AddWithValue("@totalScoreRank", participantStats.TotalScoreRank);
            cmd.AddWithValue("@totalTimeCrowdControlDealt", participantStats.TotalTimeCrowdControlDealt);
            cmd.AddWithValue("@totalUnitsHealed", participantStats.TotalUnitsHealed);
            cmd.AddWithValue("@towerKills", participantStats.TowerKills);
            cmd.AddWithValue("@tripleKills", participantStats.TripleKills);
            cmd.AddWithValue("@trueDamageDealt", participantStats.TrueDamageDealt);
            cmd.AddWithValue("@trueDamageDealtToChampions", participantStats.TrueDamageDealtToChampions);
            cmd.AddWithValue("@trueDamageTaken", participantStats.TrueDamageTaken);
            cmd.AddWithValue("@unrealKills", participantStats.UnrealKills);
            cmd.AddWithValue("@visionWardsBoughtInGame", participantStats.VisionWardsBoughtInGame);
            cmd.AddWithValue("@wardsKilled", participantStats.WardsKilled);
            cmd.AddWithValue("@wardsPlaced", participantStats.WardsPlaced);
            cmd.AddWithValue("@winner", participantStats.Winner);

        }
    }
}
