using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PowerPlanService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);

            var installDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var startInfo = new ProcessStartInfo(Path.Combine(installDir, "PowerPlanCommander.exe"));
            startInfo.WorkingDirectory = installDir;
            Process.Start(startInfo);
        }
    }
}
