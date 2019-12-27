namespace PowerPlanService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PowerPlanServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.PowerPlanServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // PowerPlanServiceProcessInstaller
            // 
            this.PowerPlanServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.PowerPlanServiceProcessInstaller.Password = null;
            this.PowerPlanServiceProcessInstaller.Username = null;
            // 
            // PowerPlanServiceInstaller
            // 
            this.PowerPlanServiceInstaller.Description = "Selects chosen power plans on current conditions.";
            this.PowerPlanServiceInstaller.DisplayName = "Power Plan Commander";
            this.PowerPlanServiceInstaller.ServiceName = "PowerPlanCommander";
            this.PowerPlanServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.PowerPlanServiceProcessInstaller,
            this.PowerPlanServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller PowerPlanServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller PowerPlanServiceInstaller;
    }
}