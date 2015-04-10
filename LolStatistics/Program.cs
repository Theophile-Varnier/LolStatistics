using System.ServiceProcess;

namespace LolStatistics
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {

#if DEBUG
            LolStatisticsService service = new LolStatisticsService();
            service.TestService(args);
#else            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new LolStatisticsService() 
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
