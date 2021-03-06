﻿using log4net;
using LolStatistics.DataAccess.Cache;
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
            logger.Info("Démarrage du service LolStatistics.");

            LolCache.Init();

            scheduler = StdSchedulerFactory.GetDefaultScheduler();

            // Initialisation du job de récupération des champions
            CreateStaticDataJob();

            // Initialisation du job de récupération des historiques
            CreateGamesJob();

            scheduler.Start();
        }

        private void CreateStaticDataJob()
        {
            logger.Info("Démarrage du service LolStatistics.");
            IJobDetail championJob = JobBuilder.Create<StaticDataJob>()
                .WithIdentity("staticDataJob", "group 1")
                .Build();

            ITrigger championTrigger = TriggerBuilder.Create()
                .WithIdentity("staticDataTrigger", "group 1")
                .StartNow()
                //.WithSimpleSchedule(x => x
                //.WithIntervalInHours(2)
                //.RepeatForever())
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(01, 00))
                .Build();

            scheduler.ScheduleJob(championJob, championTrigger);
        }

        private void CreateGamesJob()
        {
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
