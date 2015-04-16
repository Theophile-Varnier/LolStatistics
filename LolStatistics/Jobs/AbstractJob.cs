using log4net;
using LolStatistics.Log;
using LolStatistics.Process;
using Quartz;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolStatistics.Jobs
{
    /// <summary>
    /// Classe abstraite représentant les jobs
    /// </summary>
    public abstract class AbstractJob : IJob
    {
        private static readonly ILog logger = Logger.GetLogger(typeof(AbstractJob));

        protected IList<IManager> managers;

        /// <summary>
        /// Exécution du job
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            logger.Info(string.Format("Démarrage du job {0}", GetType()));
            Task[] managerTasks = managers.Select(m => Task.Factory.StartNew(m.Execute)).ToArray();
            Task.WaitAll(managerTasks);
            logger.Info(string.Format("Fin du traitement du job {0}", GetType()));
        }
    }
}
