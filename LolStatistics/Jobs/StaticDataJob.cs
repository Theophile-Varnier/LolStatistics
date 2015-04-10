using LolStatistics.Process;
using System.Collections.Generic;

namespace LolStatistics.Jobs
{
    /// <summary>
    /// Classe chargée de récupérer les données statiques du jeu
    /// Mise à jour une fois par jour
    /// </summary>
    public class StaticDataJob : AbstractJob
    {
        public StaticDataJob()
        {
            managers = new List<IManager>
            {
                new ChampionManager()
            };
        }
    }
}
