using System.Globalization;
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
        /// <summary>
        /// Récupère l'ensemble des teams auxquelles appartient un invocateur
        /// </summary>
        /// <param name="summoner"></param>
        /// <returns></returns>
        public IList<RankedTeam> GetRankedTeamsForSummoner(Summoner summoner)
        {
            // On regarde si l'information n'est pas contenue dans le cache de l'application
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

            // Sinon on va la récupérer à l'aide d'un web service
            WebServiceConsumer<JObject> webServiceConsumer = new WebServiceConsumer<JObject>(ConfigurationManager.AppSettings["BaseUri"], ConfigurationManager.AppSettings["RankedTeamApi"]);
            Dictionary<string, string> parametres = new Dictionary<string, string> { { "summonerIds", summoner.Id.ToString(CultureInfo.InvariantCulture) } };
            var res = webServiceConsumer.Consume(parametres);
            // Impossible de désérialiser la liste directement, on doit passer par un JObject
            rt = JsonConvert.DeserializeObject<List<RankedTeam>>(res.GetValue(summoner.Id.ToString()).ToString());

            foreach (RankedTeam team in rt)
            {
                // On ajoute les informations récupérées au cache
                LolStatisticsCache.AddTeamForSummoner(summoner.Name, team.Name);
                LolStatisticsCache.AddTeam(team.Name, team);
            }
            return rt;
        }
    }
}