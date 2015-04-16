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
        public void Insert(ParticipantStats participantStats)
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
                ExecuteNonQuery(cmd, participantStats, addParameters);
        }

        /// <summary>
        /// Map un objet depuis un enregistrement
        /// </summary>
        /// <param name="reader">L'enregistrement à mapper</param>
        /// <returns></returns>
        public override ParticipantStats RecordToDto(MySqlDataReader reader)
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
        private void addParameters(MySqlCommand cmd, Object obj)
        {
            ParticipantStats participantStats = obj as ParticipantStats;

            // Ajout des paramètres
            cmd.Parameters.AddWithValue("@participantId", participantStats.ParticipantId);
            cmd.Parameters.AddWithValue("@assists", participantStats.Assists);
            cmd.Parameters.AddWithValue("@champLevel", participantStats.ChampLevel);
            cmd.Parameters.AddWithValue("@combatPlayerScore", participantStats.CombatPlayerScore);
            cmd.Parameters.AddWithValue("@deaths", participantStats.Deaths);
            cmd.Parameters.AddWithValue("@doubleKills", participantStats.DoubleKills);
            cmd.Parameters.AddWithValue("@firstBloodAssist", participantStats.FirstBloodAssist);
            cmd.Parameters.AddWithValue("@firstBloodKill", participantStats.FirstBloodKill);
            cmd.Parameters.AddWithValue("@firstInhibitorAssist", participantStats.FirstInhibitorAssist);
            cmd.Parameters.AddWithValue("@firstInhibitorKill", participantStats.FirstInhibitorKill);
            cmd.Parameters.AddWithValue("@firstTowerAssist", participantStats.FirstTowerAssist);
            cmd.Parameters.AddWithValue("@firstTowerKill", participantStats.FirstTowerKill);
            cmd.Parameters.AddWithValue("@goldEarned", participantStats.GoldEarned);
            cmd.Parameters.AddWithValue("@goldSpent", participantStats.GoldSpent);
            cmd.Parameters.AddWithValue("@inhibitorKills", participantStats.InhibitorKills);
            cmd.Parameters.AddWithValue("@item0", participantStats.Item0);
            cmd.Parameters.AddWithValue("@item1", participantStats.Item1);
            cmd.Parameters.AddWithValue("@item2", participantStats.Item2);
            cmd.Parameters.AddWithValue("@item3", participantStats.Item3);
            cmd.Parameters.AddWithValue("@item4", participantStats.Item4);
            cmd.Parameters.AddWithValue("@item5", participantStats.Item5);
            cmd.Parameters.AddWithValue("@item6", participantStats.Item6);
            cmd.Parameters.AddWithValue("@killingSprees", participantStats.KillingSprees);
            cmd.Parameters.AddWithValue("@kills", participantStats.Kills);
            cmd.Parameters.AddWithValue("@largestCriticalStrike", participantStats.LargestCriticalStrike);
            cmd.Parameters.AddWithValue("@largestKillingSpree", participantStats.LargestKillingSpree);
            cmd.Parameters.AddWithValue("@largestMultiKill", participantStats.LargestMultiKill);
            cmd.Parameters.AddWithValue("@magicDamageDealt", participantStats.MagicDamageDealt);
            cmd.Parameters.AddWithValue("@magicDamageDealtToChampions", participantStats.MagicDamageDealtToChampions);
            cmd.Parameters.AddWithValue("@magicDamageTaken", participantStats.MagicDamageTaken);
            cmd.Parameters.AddWithValue("@minionsKilled", participantStats.MinionsKilled);
            cmd.Parameters.AddWithValue("@neutralMinionsKilled", participantStats.NeutralMinionsKilled);
            cmd.Parameters.AddWithValue("@neutralMinionsKilledEnemyJungle", participantStats.NeutralMinionsKilledEnemyJungle);
            cmd.Parameters.AddWithValue("@neutralMinionsKilledTeamJungle", participantStats.NeutralMinionsKilledTeamJungle);
            cmd.Parameters.AddWithValue("@nodeCapture", participantStats.NodeCapture);
            cmd.Parameters.AddWithValue("@nodeCaptureAssist", participantStats.NodeCaptureAssist);
            cmd.Parameters.AddWithValue("@nodeNeutralize", participantStats.NodeNeutralize);
            cmd.Parameters.AddWithValue("@nodeNeutralizeAssist", participantStats.NodeNeutralizeAssist);
            cmd.Parameters.AddWithValue("@objectivePlayerScore", participantStats.ObjectivePlayerScore);
            cmd.Parameters.AddWithValue("@pentaKills", participantStats.PentaKills);
            cmd.Parameters.AddWithValue("@physicalDamageDealt", participantStats.PhysicalDamageDealt);
            cmd.Parameters.AddWithValue("@physicalDamageDealtToChampions", participantStats.PhysicalDamageDealtToChampions);
            cmd.Parameters.AddWithValue("@physicalDamageTaken", participantStats.PhysicalDamageTaken);
            cmd.Parameters.AddWithValue("@quadraKills", participantStats.QuadraKills);
            cmd.Parameters.AddWithValue("@sightWardsBoughtInGame", participantStats.SightWardsBoughtInGame);
            cmd.Parameters.AddWithValue("@teamObjective", participantStats.TeamObjective);
            cmd.Parameters.AddWithValue("@totalDamageDealt", participantStats.TotalDamageDealt);
            cmd.Parameters.AddWithValue("@totalDamageDealtToChampions", participantStats.TotalDamageDealtToChampions);
            cmd.Parameters.AddWithValue("@totalDamageTaken", participantStats.TotalDamageTaken);
            cmd.Parameters.AddWithValue("@totalHeal", participantStats.TotalHeal);
            cmd.Parameters.AddWithValue("@totalPlayerScore", participantStats.TotalPlayerScore);
            cmd.Parameters.AddWithValue("@totalScoreRank", participantStats.TotalScoreRank);
            cmd.Parameters.AddWithValue("@totalTimeCrowdControlDealt", participantStats.TotalTimeCrowdControlDealt);
            cmd.Parameters.AddWithValue("@totalUnitsHealed", participantStats.TotalUnitsHealed);
            cmd.Parameters.AddWithValue("@towerKills", participantStats.TowerKills);
            cmd.Parameters.AddWithValue("@tripleKills", participantStats.TripleKills);
            cmd.Parameters.AddWithValue("@trueDamageDealt", participantStats.TrueDamageDealt);
            cmd.Parameters.AddWithValue("@trueDamageDealtToChampions", participantStats.TrueDamageDealtToChampions);
            cmd.Parameters.AddWithValue("@trueDamageTaken", participantStats.TrueDamageTaken);
            cmd.Parameters.AddWithValue("@unrealKills", participantStats.UnrealKills);
            cmd.Parameters.AddWithValue("@visionWardsBoughtInGame", participantStats.VisionWardsBoughtInGame);
            cmd.Parameters.AddWithValue("@wardsKilled", participantStats.WardsKilled);
            cmd.Parameters.AddWithValue("@wardsPlaced", participantStats.WardsPlaced);
            cmd.Parameters.AddWithValue("@winner", participantStats.Winner);

        }
    }
}
