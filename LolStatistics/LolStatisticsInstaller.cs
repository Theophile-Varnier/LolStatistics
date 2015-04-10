using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace LolStatistics
{
    [RunInstaller(true)]
    public partial class LolStatisticsInstaller : System.Configuration.Install.Installer
    {
        public LolStatisticsInstaller()
        {
            InitializeComponent();
        }
    }
}
