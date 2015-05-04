using LolStatistics.Web.Models.WebServices;
using LolStatistics.WebServiceConsumers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace LolStatistics.Web.Services
{
    public class RankedTeamService
    {
        public IList<RankedTeam> GetRankedTeamsForSummoner(Summoner summoner)
        {
            List<string> teamNames = LolStatisticsCache.GetTeamsForSummoner(summoner.Name);
            List<RankedTeam> rt = new List<RankedTeam>();
            if (teamNames != null)
            {
                foreach (string teamName in teamNames)
                {
                    rt.Add(LolStatisticsCache.GetTeam(teamName));
                }
                return rt;
            }
            WebServiceConsumer<JObject> webServiceConsumer = new WebServiceConsumer<JObject>(ConfigurationManager.AppSettings["BaseUri"], ConfigurationManager.AppSettings["RankedTeamApi"]);
            Dictionary<string, string> parametres = new Dictionary<string, string> { { "summonerIds", summoner.Id.ToString() } };
            var res = webServiceConsumer.Consume(parametres);
            rt = JsonConvert.DeserializeObject<List<RankedTeam>>(res.GetValue(summoner.Id.ToString()).ToString());
            foreach (RankedTeam team in rt)
            {
                LolStatisticsCache.AddTeamForSummoner(summoner.Name, team.Name);
                LolStatisticsCache.AddTeam(team.Name, team);
            }
            return rt;
        }
    }
}