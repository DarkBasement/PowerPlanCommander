using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_TEST
{
    public partial class Form1 : Form
    {
        private Utils.PowerPlanRuler ruler;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Utils.PowerEnumerator.SetCurrentPowerPlan(this.edNewPlan.Text);
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            var currentPlan = Utils.PowerEnumerator.GetCurrentPlan();
            this.edOriginal.Text = currentPlan.Item2;
        }

        private void BtRestore_Click(object sender, EventArgs e)
        {
            Utils.PowerEnumerator.SetCurrentPowerPlan(this.edOriginal.Text);
        }

        private void BtEnumerateProcesses_Click(object sender, EventArgs e)
        {
            this.lbxAllProcesses.Items.Clear();

            var processes = System.Diagnostics.Process.GetProcesses();
            foreach (var process in processes)
            {
                this.lbxAllProcesses.Items.Add(process.ProcessName);
            }
        }

        private void LbFindProc_Click(object sender, EventArgs e)
        {
            this.lbResult.Text = Utils.ProcessExplorer.IsRunning(this.edFindProc.Text) ? "Found!" : "Not Found.";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.ruler != null)
                this.ruler.Monitor();
        }

        private void BtStartTimer_Click(object sender, EventArgs e)
        {
            if (this.timer1.Enabled)
            {
                this.ruler.Finish();
                this.ruler = null;
                this.timer1.Enabled = false;
                this.btStartTimer.Text = "Start";
            }
            else
            {
                var powerPlans = Utils.PowerEnumerator.GetAllPowerPlans();
                Guid planGuid = powerPlans.FirstOrDefault(info => info.Item2 == this.edNewPlan.Text).Item1;
                this.ruler = new Utils.PowerPlanRuler(planGuid, new List<string>(this.edFindProc.Text.Split(',')));
                this.timer1.Enabled = true;
                this.btStartTimer.Text = "Stop";
            }
        }
    }
}
