using log4net;
using LolStatistics.Log;
using LolStatistics.Process;
using Quartz;
using System.Threading.Tasks;

namespace LolStatistics.Jobs
{
    /// <summary>
    /// Classe chargée de récupérer les historiques de parties
    /// Mise à jour une fois toutes les 2h
    /// </summary>
    public class HistoryJob : IJob
    {
        private static readonly ILog logger = Logger.GetLogger(typeof(HistoryJob));

        private GameHistoryManager gameHistoryManager;
        private RankedGameHistoryManager rankedGameHistoryManager;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public HistoryJob()
        {
            gameHistoryManager = new GameHistoryManager();
            rankedGameHistoryManager = new RankedGameHistoryManager();
        }

        /// <summary>
        /// Exécution du Job
        /// </summary>
        /// <param name="context">Le contexte d'exécution du Job</param>
        public void Execute(IJobExecutionContext context)
        {
            logger.Info("Lancement de la récupération des parties");

            // Tâche de récupération des games ranked
            Task rankedTask = new Task(rankedGameHistoryManager.Execute);
            Task gameTask = new Task(gameHistoryManager.Execute);
            rankedTask.Start();
            gameTask.Start();

            Task.WaitAll(rankedTask, gameTask);
            logger.Info("Fin de la récupération des parties");
        }
    }
}
