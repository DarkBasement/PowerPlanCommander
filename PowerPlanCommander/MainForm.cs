using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPlanCommander
{
    public partial class frMain : Form
    {
        public frMain()
        {
            InitializeComponent();
        }

        private class PowerPlanInfo
        {
            public string Name { get; }
            public Guid Guid { get; }

            public PowerPlanInfo(Tuple<Guid, string> info) :this(info.Item2, info.Item1)
            {
            }
            public PowerPlanInfo (string name, Guid guid)
            {
                this.Name = name;
                this.Guid = guid;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ServiceController service = new ServiceController(WinUtils.Constants.ServiceName);
            try
            {
                this.edServiceStatus.Text = service.Status.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                service.Dispose();
            }

            LoadPowerPlans();
            LoadRunningProcesses();

            // now, load settings
            LoadServiceInfo();

            LoadPopularApps();
        }

        private void RestartServiceWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.edServiceStatus.Text = e.UserState as string;
        }

        private void RestartServiceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.UseWaitCursor = false;
            this.Enabled = true;

            if (e.Error == null)
                this.toolStripStatusLabel1.Text = "New settings applied.";
            else
                MessageBox.Show(this, e.Error.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RestartServiceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.RestartService();
        }

        private void LoadPopularApps()
        {
            using (var reader = new System.IO.StreamReader("PopularApps.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var record = reader.ReadLine();
                    var recordInfo = record.Split(',');
                    if (recordInfo.Length == 2) {
                        var title = recordInfo[0].Trim(' ', '\"', '\n');
                        var internalName = recordInfo[1].Trim(' ', '\"', '\n');
                        if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(internalName))
                        {
                            this.edPopularProcesses.Items.Add(new GeneralProcessInfo(title, internalName));
                            continue;
                        }
                    }

                    this.toolStripStatusLabel1.Text = "Error loading popular applications.";
                    return;
                }
            }
        }

        private void BtApply_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Empty;

            var powerPlan = this.cblPowerPlan.SelectedItem as PowerPlanInfo;
            if (powerPlan == null)
            {
                MessageBox.Show(this, "Please, select a power plan to be selected when the app starts.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cblPowerPlan.Focus();
                return;
            }

            RegistryKey key = null;

            try
            {
                key = Registry.LocalMachine.CreateSubKey(WinUtils.Constants.ServiceParametersRegistryKey);
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show(this, "Cannot save to registry. You must run the app as Admin.\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch(System.Security.SecurityException ex)
            {
                MessageBox.Show(this, "Cannot save to registry. You must run the app as Admin.\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (key != null)
            {
                key.SetValue("PowerPlanGuid", powerPlan.Guid);
                key.SetValue("PowerPlan", powerPlan.Name);
                key.SetValue("TimerInterval", this.edInterval.Value);
                key.SetValue("ProcessNames", this.edSelectedProcs.Text);
                key.Close();
            }
            else
            {
                MessageBox.Show(this, "Cannot Apply: Cannot save to registry.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.UseWaitCursor = true;
            this.Enabled = false;

            this.restartServiceWorker.RunWorkerAsync();
        }

        private void RestartService()
        {
            // restart the service
            ServiceController service = new ServiceController(WinUtils.Constants.ServiceName);
            try
            {
                if (service.Status == ServiceControllerStatus.Running)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(5));
                }
                if (service.Status != ServiceControllerStatus.Stopped)
                    throw new ApplicationException("Cannot stop the service.");
                this.restartServiceWorker.ReportProgress(50, service.Status.ToString());
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(5));
                if (service.Status != ServiceControllerStatus.Running)
                    throw new ApplicationException("Cannot start the service.");
                this.restartServiceWorker.ReportProgress(100, service.Status.ToString());
            }
            finally
            {
                service.Dispose();
            }
        }

        //private void ReadDataTest()
        //{
        //    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\PowerPlan\Parameters");

        //    if (key != null)
        //    {
        //        try
        //        {
        //            var obj = key.GetValue("PowerPlanGuid");
        //            if (obj is string)
        //            {
        //                var powerPlanGuid = new Guid((string)obj);
        //            }
        //        }
        //        finally
        //        {
        //            key.Close();
        //        }
        //    }
        //}

        private void LoadPowerPlans()
        {
            this.cblPowerPlan.Items.Clear();

            foreach (var planInfo in Utils.PowerEnumerator.GetAllPowerPlans())
            {
                this.cblPowerPlan.Items.Add(new PowerPlanInfo(planInfo));
            }
        }

        private class ProcessListEqualityComparer : IEqualityComparer<System.Diagnostics.Process>
        {
            public bool Equals(Process x, Process y)
            {
                return x.ProcessName == y.ProcessName && x.MainWindowTitle == y.MainWindowTitle;
            }

            public int GetHashCode(Process obj)
            {
                return (obj.ProcessName + obj.MainWindowTitle).GetHashCode();
            }
        }

        private class ProcessListComparer : IComparer<System.Diagnostics.Process>
        {
            public int Compare(Process x, Process y)
            {
                // priority to those with MainWindowTitle
                if (!string.IsNullOrEmpty(x.MainWindowTitle))
                {
                    if (string.IsNullOrEmpty(y.MainWindowTitle))
                        return -1;
                }
                else if (!string.IsNullOrEmpty(y.MainWindowTitle))
                    return 1;

                int r = string.CompareOrdinal(x.ProcessName, y.ProcessName);
                if (r == 0)
                    r = string.CompareOrdinal(x.MainWindowTitle, y.MainWindowTitle);

                return r;
            }
        }

        private class GeneralProcessInfo
        {
            public string Caption { get; private set; }
            public string Title { get; private set; }
            public string InternalName { get; private set; }

            public GeneralProcessInfo (string title, string internalName)
            {
                this.Title = title;
                this.InternalName = internalName;

                if (string.IsNullOrEmpty(title))
                    this.Caption = internalName;
                else
                    this.Caption = string.Format("{0} ({1})", title, internalName);
            }

            public override string ToString()
            {
                return this.Caption;
            }
        }

        private void LoadRunningProcesses()
        {
            this.edAvailProcs.Items.Clear();
            var processes = System.Diagnostics.Process.GetProcesses();
            Array.Sort<Process>(processes, new ProcessListComparer());

            foreach (var process in processes.Distinct(new ProcessListEqualityComparer()))
                this.edAvailProcs.Items.Add(new GeneralProcessInfo(process.MainWindowTitle, process.ProcessName));
        }

        private void LoadServiceInfo()
        {
            Guid powerPlanGuid = Guid.Empty;
            RegistryKey key = Registry.LocalMachine.OpenSubKey(WinUtils.Constants.ServiceParametersRegistryKey);

            if (key != null)
            {
                var obj = key.GetValue("PowerPlanGuid");
                if (obj is string)
                {
                    powerPlanGuid = new Guid((string)obj);
                    foreach (PowerPlanInfo item in this.cblPowerPlan.Items)
                    {
                        if (item.Guid == powerPlanGuid)
                        {
                            this.cblPowerPlan.SelectedItem = item;
                            powerPlanGuid = Guid.Empty;
                            break;
                        }
                    }

                    if (powerPlanGuid != Guid.Empty)
                        MessageBox.Show(this, "No Power Plan found. Select a new one!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                obj = key.GetValue("TimerInterval");
                if (obj is Int32)
                    edInterval.Value = (Int32)obj;

                obj = key.GetValue("ProcessNames");
                if (obj is string)
                {
                    this.edSelectedProcs.Text = (string)obj;
                }

                key.Close();

                this.toolStripStatusLabel1.Text = "Registry values read.";
            }
            else
            {
                this.toolStripStatusLabel1.Text = "Cannot read registry or registry values not set.";
                // MessageBox.Show(this, "Cannot read registry.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btAddRunning_Click(object sender, EventArgs e)
        {
            GeneralProcessInfo processInfo = this.edAvailProcs.SelectedItem as GeneralProcessInfo;

            if (processInfo != null)
            {
                if (this.edSelectedProcs.Text.Trim().Length > 0)
                    this.edSelectedProcs.Text += ",";

                this.edSelectedProcs.Text += processInfo.InternalName.Trim();
            }
        }

        private void FrMain_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = new Size(this.Size.Width * 5, this.Height);
        }

        private void btAddPopular_Click(object sender, EventArgs e)
        {
            var selectedPopular = this.edPopularProcesses.SelectedItem as GeneralProcessInfo;

            if (selectedPopular != null)
            {
                if (this.edSelectedProcs.Text.Trim().Length > 0)
                    this.edSelectedProcs.Text += ",";
                this.edSelectedProcs.Text += selectedPopular.InternalName;
            }
        }
    }
}
