using LolStatistics.Process;
using System.Collections.Generic;

namespace LolStatistics.Jobs
{
    /// <summary>
    /// Classe chargée de récupérer les historiques de parties
    /// Mise à jour une fois toutes les 2h
    /// </summary>
    public class HistoryJob : AbstractJob
    {
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public HistoryJob()
        {
            managers = new List<IManager>
            {
                new GameHistoryManager(),
                new RankedGameHistoryManager()
            };
        }
    }
}
