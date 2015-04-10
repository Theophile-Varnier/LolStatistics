using LolStatistics.Model;
using LolStatistics.Model.Dto;
using System.Collections.Generic;
using System.Reflection;

namespace LolStatistics.DataAccess.Repositories
{
    public static class ParticipantRepository
    {
        public static ParticipantDto Map(Participant source)
        {
            ParticipantDto res = new ParticipantDto
            {
                MatchId = source.MatchId,
                ChampionId = source.ChampionId,
                Spell1Id = source.Spell1Id,
                Spell2Id = source.Spell2Id,
                Lane = source.Timeline.Lane,
                Role = source.Timeline.Role,
                HighestAchievedSeasonTier = source.HighestAchievedSeasonTier,
                ParticipantId = source.ParticipantId
            };

            res.TimelineDatas = new List<ParticipantTimelineData>();
            IList<PropertyInfo> properties = source.Timeline.TimelineDatas;
            foreach (PropertyInfo property in properties)
            {
                ParticipantTimelineData baseData = source.Timeline.GetType().GetProperty(property.Name).GetValue(source.Timeline) as ParticipantTimelineData;
                res.TimelineDatas.Add(new ParticipantTimelineData
                {
                    ParticipantId = source.ParticipantId,
                    Name = property.Name,
                    ZeroToTen = baseData.ZeroToTen,
                    TenToTwenty = baseData.TenToTwenty,
                    TwentyToThirty = baseData.TwentyToThirty,
                    ThirtyToEnd = baseData.ThirtyToEnd
                });
            }

            return res;
        }
    }
}
