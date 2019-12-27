using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class PowerPlanRuler
    {
        private Guid powerPlan;
        private List<string> processNames;
        private Guid originalPowerPlan;

        public PowerPlanRuler(Guid powerPlanGuid, List<string> processNames)
        {
            this.powerPlan = powerPlanGuid;
            this.processNames = processNames;
        }

        public class NotificationEventArgs : EventArgs
        {
            public string Message
            {
                get;
                private set;
            }
            public NotificationEventArgs(string message)
            {
                this.Message = message;
            }
        }

        public event EventHandler<NotificationEventArgs> NotificationMessage;

        protected void OnNotificationMessage(string message)
        {
            if (NotificationMessage != null)
                this.NotificationMessage(this, new NotificationEventArgs(message));
        }

        public void Monitor()
        {
            bool isRunning = false;
            foreach (var process in this.processNames)
            {
                if (ProcessExplorer.IsRunning(process))
                {
                    isRunning = true;
                    break;
                }
            }

            this.OnNotificationMessage("Running = " + isRunning);

            this.Update(isRunning);
        }

        private void Update(bool isRunning)
        {
            if (isRunning)
            {
                if (originalPowerPlan == Guid.Empty)
                {
                    this.OnNotificationMessage("Saving the original power plan");
                    originalPowerPlan = PowerEnumerator.GetCurrentPlan().Item1;

                    this.OnNotificationMessage("Setting new power plan.");
                    PowerEnumerator.SetCurrentPowerPlan(this.powerPlan);
                }
            }
            else
            {
                if (originalPowerPlan != Guid.Empty)
                {
                    this.OnNotificationMessage("Restoring original power plan");
                    PowerEnumerator.SetCurrentPowerPlan(originalPowerPlan);
                    originalPowerPlan = Guid.Empty;
                }
            }
        }

        public void Finish()
        {
            this.Update(false);
        }
    }
}
