using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace PowerPlanService
{
    public partial class PowerPlanCommanderService : ServiceBase
    {
        private System.Timers.Timer cpuCheckTimer;
        private int eventId = 1;
        private int timerInterval = 30;
        private PowerPlanRuler ruler;

        public PowerPlanCommanderService()
        {
            InitializeComponent();

            this.evLog = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("PowerPlanSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "PowerPlanSource", "PowerPlanLog");
            }
            evLog.Source = "PowerPlanSource";
            evLog.Log = "PowerPlanLog";
        }

        protected override void OnStart(string[] args)
        {
            this.evLog.WriteEntry("Starting...");

            Guid powerPlanGuid = Guid.Empty;
            List<string> processNames = null;

            RegistryKey key = Registry.LocalMachine.OpenSubKey(WinUtils.Constants.ServiceParametersRegistryKey);

            if (key != null)
            {
                var obj = key.GetValue("PowerPlanGuid");
                if (obj is string)
                    powerPlanGuid = new Guid((string)obj);

                if (obj == null)
                  this.evLog.WriteEntry("Using default limits...");
                else
                {
                    // this.evLog.WriteEntry("data type is " + obj.GetType().ToString());
                }

                obj = key.GetValue("TimerInterval");
                if (obj is Int32)
                    timerInterval = (Int32)obj;

                if (obj == null)
                    this.evLog.WriteEntry("Using default limits...");
                else
                {
                    // this.evLog.WriteEntry("data type is " + obj.GetType().ToString());
                }

                obj = key.GetValue("ProcessNames");
                if (obj is string)
                {
                    var processNamesFlat = (string)obj;
                    processNames = new List<string>(processNamesFlat.Split(','));
                }

                if (obj == null)
                    this.evLog.WriteEntry("Using default limits...");
                else
                {
                    // this.evLog.WriteEntry("data type is " + obj.GetType().ToString());
                }

                key.Close();

                this.evLog.WriteEntry("Registry data read.");
            }
            else
                this.evLog.WriteEntry("Registry key not found!");

            if (processNames == null)
            {
                this.evLog.WriteEntry("No process names!");
            }
            else
            {
                this.ruler = new PowerPlanRuler(powerPlanGuid, processNames);
                this.ruler.NotificationMessage += Ruler_NotificationMessage;

                this.cpuCheckTimer = new System.Timers.Timer();
                this.cpuCheckTimer.Interval = timerInterval * 1000;
                this.cpuCheckTimer.Elapsed += CpuCheckTimer_Elapsed;
                this.cpuCheckTimer.Start();
            }

            this.evLog.WriteEntry("Started");
        }

        private void Ruler_NotificationMessage(object sender, PowerPlanRuler.NotificationEventArgs e)
        {
            evLog.WriteEntry(e.Message, EventLogEntryType.Information, eventId++);
        }

        private void CpuCheckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //evLog.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
            ruler.Monitor();
            
        }

        protected override void OnStop()
        {

            if (this.ruler != null)
                this.ruler.Finish();

            this.evLog.WriteEntry("Stopped");
        }

        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);
        }
    }
}
