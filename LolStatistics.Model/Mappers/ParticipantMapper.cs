﻿using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using LolStatistics.Model.Dto;
using LolStatistics.Model.Participant;

namespace LolStatistics.Model.Mappers
{
    /// <summary>
    /// Mapper entre les classes "Participant" et "ParticipantDto"
    /// </summary>
    public static class ParticipantMapper
    {
        /// <summary>
        /// Participant -> ParticipantDto
        /// </summary>
        /// <param name="source">Le participant à mapper</param>
        /// <returns></returns>
        public static ParticipantDto Map(Participant.Participant source)
        {
            // Champs communs
            ParticipantDto res = new ParticipantDto
            {
                MatchId = source.MatchId,
                ParticipantId = source.ParticipantId,
                ChampionId = source.ChampionId,
                Spell1Id = source.Spell1Id,
                Spell2Id = source.Spell2Id,
                HighestAchievedSeasonTier = source.HighestAchievedSeasonTier,
                TeamId = source.TeamId,
                TimelineDatas = new List<ParticipantTimelineData>()
            };
            if (source.Timeline != null)
            {
                res.Lane = source.Timeline.Lane;
                res.Role = source.Timeline.Role;

                // Le web service renvoie les timelines sous forme d'objets séparés
                // Mais la persistance en base se fait sous forme de liste pour éviter d'enregistrer trop de null
                // D'où cette conversion
                IList<PropertyInfo> properties = source.Timeline.TimelineDatas;
                foreach (PropertyInfo property in properties)
                {
                    ParticipantTimelineData baseData = source.Timeline.GetType().GetProperty(property.Name).GetValue(source.Timeline) as ParticipantTimelineData;
                    if (baseData != null)
                    {
                        res.TimelineDatas.Add(new ParticipantTimelineData
                        {
                            ParticipantId = source.ParticipantId,
                            MatchId = source.MatchId,
                            Name = property.Name,
                            ZeroToTen = baseData.ZeroToTen,
                            TenToTwenty = baseData.TenToTwenty,
                            TwentyToThirty = baseData.TwentyToThirty,
                            ThirtyToEnd = baseData.ThirtyToEnd
                        });
                    }
                }
            }

            return res;
        }

        public static Participant.Participant UnMap(ParticipantDto source)
        {
            Participant.Participant res = new Participant.Participant
            {
                MatchId = source.MatchId,
                ParticipantId = source.ParticipantId,
                ChampionId = source.ChampionId,
                Spell1Id = source.Spell1Id,
                Spell2Id = source.Spell2Id,
                HighestAchievedSeasonTier = source.HighestAchievedSeasonTier,
                TeamId = source.TeamId,
                Timeline = new ParticipantTimeline
                {
                    Lane = source.Lane,
                    Role = source.Role
                }
            };

            IList<PropertyInfo> properties = res.Timeline.TimelineDatas;
            foreach (PropertyInfo property in properties)
            {
                res.Timeline.GetType().GetProperty(property.Name).SetValue(res.Timeline, source.TimelineDatas.FirstOrDefault(t => t.Name == property.Name));
            }

            return res;
        }
    }
}
