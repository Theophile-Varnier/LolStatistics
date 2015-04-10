using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace LolStatistics
{
    public static class Logger
    {
        public static ILog GetLogger(Type typeofCaller)
        {
            return LogManager.GetLogger(typeofCaller);
        }
    }
}
