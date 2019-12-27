using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class ProcessExplorer
    {
        public static bool IsRunning(string processName)
        {
            var processes = System.Diagnostics.Process.GetProcessesByName(processName);
            return processes != null && processes.Any();
        }

    }
}
