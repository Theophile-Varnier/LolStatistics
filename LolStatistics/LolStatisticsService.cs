using log4net;
using LolStatistics.Jobs;
using LolStatistics.Log;
using Quartz;
using Quartz.Impl;
using System.ServiceProcess;

namespace LolStatistics
{
    public partial class LolStatisticsService : ServiceBase
    {
        private static readonly ILog logger = Logger.GetLogger(typeof(LolStatisticsService));

        private IScheduler scheduler;

        public LolStatisticsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler();

            // Initialisation du job de récupération des champions
            CreateChampionsJob();

            // Initialisation du job de récupération des historiques
            CreateGamesJob();

            scheduler.Start();
        }

        private void CreateChampionsJob()
        {
            logger.Info("Démarrage du service LolStatistics.");
            IJobDetail championJob = JobBuilder.Create<ChampionsJob>()
                .WithIdentity("championJob", "group 1")
                .Build();

            ITrigger championTrigger = TriggerBuilder.Create()
                .WithIdentity("championTrigger", "group 1")
                .StartNow()
                .WithSimpleSchedule(x => x
                .WithIntervalInHours(2)
                //.WithIntervalInMinutes(1)
                .RepeatForever())
                .Build();

            scheduler.ScheduleJob(championJob, championTrigger);
        }

        private void CreateGamesJob()
        {
            logger.Info("Démarrage du service LolStatistics.");
            IJobDetail historyJob = JobBuilder.Create<HistoryJob>()
                .WithIdentity("historyJob", "group 2")
                .Build();

            ITrigger historyTrigger = TriggerBuilder.Create()
                .WithIdentity("historyTrigger", "group 2")
                .StartNow()
                .WithSimpleSchedule(x => x
                .WithIntervalInHours(2)
                //.WithIntervalInMinutes(1)
                .RepeatForever())
                .Build();

            scheduler.ScheduleJob(historyJob, historyTrigger);
        }
        

        protected override void OnStop()
        {
            logger.Info("Arrêt du service LolStatistics.");
            scheduler.Shutdown();
        }

        internal void TestService(string[] args)
        {
            OnStart(args);
            //OnStop();
        }
    }
}
