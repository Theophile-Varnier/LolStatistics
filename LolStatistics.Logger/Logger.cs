using System;
using log4net;
using log4net.Config;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace LolStatistics.Log
{
    /// <summary>
    /// Classe statique pour récupérer un logger
    /// </summary>
    public static class Logger
    {
        public static ILog GetLogger(Type typeofCaller)
        {
            return LogManager.GetLogger(typeofCaller);
        }
    }
}
