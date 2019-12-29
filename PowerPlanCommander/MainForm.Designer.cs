namespace PowerPlanCommander
{
    partial class frMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbPowerPlan = new System.Windows.Forms.Label();
            this.cblPowerPlan = new System.Windows.Forms.ComboBox();
            this.edAvailProcs = new System.Windows.Forms.ComboBox();
            this.edSelectedProcs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btAddRunning = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.edServiceStatus = new System.Windows.Forms.TextBox();
            this.btApply = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.edInterval = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbDelimiter = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.edPopularProcesses = new System.Windows.Forms.ComboBox();
            this.btAddPopular = new System.Windows.Forms.Button();
            this.restartServiceWorker = new System.ComponentModel.BackgroundWorker();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.edInterval)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPowerPlan
            // 
            this.lbPowerPlan.AutoSize = true;
            this.lbPowerPlan.Location = new System.Drawing.Point(56, 58);
            this.lbPowerPlan.Name = "lbPowerPlan";
            this.lbPowerPlan.Size = new System.Drawing.Size(64, 13);
            this.lbPowerPlan.TabIndex = 0;
            this.lbPowerPlan.Text = "Power Plan:";
            // 
            // cblPowerPlan
            // 
            this.cblPowerPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cblPowerPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cblPowerPlan.FormattingEnabled = true;
            this.cblPowerPlan.Location = new System.Drawing.Point(126, 55);
            this.cblPowerPlan.Name = "cblPowerPlan";
            this.cblPowerPlan.Size = new System.Drawing.Size(356, 21);
            this.cblPowerPlan.TabIndex = 2;
            // 
            // edAvailProcs
            // 
            this.edAvailProcs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edAvailProcs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edAvailProcs.FormattingEnabled = true;
            this.edAvailProcs.Location = new System.Drawing.Point(125, 147);
            this.edAvailProcs.Name = "edAvailProcs";
            this.edAvailProcs.Size = new System.Drawing.Size(303, 21);
            this.edAvailProcs.TabIndex = 4;
            // 
            // edSelectedProcs
            // 
            this.edSelectedProcs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edSelectedProcs.Location = new System.Drawing.Point(125, 203);
            this.edSelectedProcs.Name = "edSelectedProcs";
            this.edSelectedProcs.Size = new System.Drawing.Size(356, 20);
            this.edSelectedProcs.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Running Processes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Selected Processes:";
            // 
            // btAddRunning
            // 
            this.btAddRunning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddRunning.Location = new System.Drawing.Point(437, 147);
            this.btAddRunning.Name = "btAddRunning";
            this.btAddRunning.Size = new System.Drawing.Size(44, 23);
            this.btAddRunning.TabIndex = 8;
            this.btAddRunning.Text = "Add";
            this.btAddRunning.UseVisualStyleBackColor = true;
            this.btAddRunning.Click += new System.EventHandler(this.btAddRunning_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Service Status:";
            // 
            // edServiceStatus
            // 
            this.edServiceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edServiceStatus.Location = new System.Drawing.Point(126, 29);
            this.edServiceStatus.Name = "edServiceStatus";
            this.edServiceStatus.ReadOnly = true;
            this.edServiceStatus.Size = new System.Drawing.Size(356, 20);
            this.edServiceStatus.TabIndex = 10;
            // 
            // btApply
            // 
            this.btApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btApply.Location = new System.Drawing.Point(389, 254);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(93, 28);
            this.btApply.TabIndex = 11;
            this.btApply.Text = "Apply";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.BtApply_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Scanning Interval:";
            // 
            // edInterval
            // 
            this.edInterval.Location = new System.Drawing.Point(125, 259);
            this.edInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.edInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edInterval.Name = "edInterval";
            this.edInterval.Size = new System.Drawing.Size(85, 20);
            this.edInterval.TabIndex = 14;
            this.edInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "seconds";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 293);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(510, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // lbDelimiter
            // 
            this.lbDelimiter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDelimiter.Location = new System.Drawing.Point(21, 85);
            this.lbDelimiter.Name = "lbDelimiter";
            this.lbDelimiter.Size = new System.Drawing.Size(462, 2);
            this.lbDelimiter.TabIndex = 18;
            this.lbDelimiter.Text = "label6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Popular Processes:";
            // 
            // edPopularProcesses
            // 
            this.edPopularProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edPopularProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edPopularProcesses.FormattingEnabled = true;
            this.edPopularProcesses.Location = new System.Drawing.Point(125, 120);
            this.edPopularProcesses.Name = "edPopularProcesses";
            this.edPopularProcesses.Size = new System.Drawing.Size(303, 21);
            this.edPopularProcesses.TabIndex = 20;
            // 
            // btAddPopular
            // 
            this.btAddPopular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddPopular.Location = new System.Drawing.Point(437, 118);
            this.btAddPopular.Name = "btAddPopular";
            this.btAddPopular.Size = new System.Drawing.Size(44, 23);
            this.btAddPopular.TabIndex = 21;
            this.btAddPopular.Text = "Add";
            this.btAddPopular.UseVisualStyleBackColor = true;
            this.btAddPopular.Click += new System.EventHandler(this.btAddPopular_Click);
            // 
            // restartServiceWorker
            // 
            this.restartServiceWorker.WorkerReportsProgress = true;
            this.restartServiceWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RestartServiceWorker_DoWork);
            this.restartServiceWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.RestartServiceWorker_ProgressChanged);
            this.restartServiceWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RestartServiceWorker_RunWorkerCompleted);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(510, 24);
            this.mainMenuStrip.TabIndex = 22;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // frMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 315);
            this.Controls.Add(this.btAddPopular);
            this.Controls.Add(this.edPopularProcesses);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbDelimiter);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.edServiceStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btAddRunning);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edSelectedProcs);
            this.Controls.Add(this.edAvailProcs);
            this.Controls.Add(this.cblPowerPlan);
            this.Controls.Add(this.lbPowerPlan);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "frMain";
            this.Text = "Power Plan Selector";
            this.Load += new System.EventHandler(this.FrMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edInterval)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPowerPlan;
        private System.Windows.Forms.ComboBox cblPowerPlan;
        private System.Windows.Forms.ComboBox edAvailProcs;
        private System.Windows.Forms.TextBox edSelectedProcs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btAddRunning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edServiceStatus;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown edInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label lbDelimiter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox edPopularProcesses;
        private System.Windows.Forms.Button btAddPopular;
        private System.ComponentModel.BackgroundWorker restartServiceWorker;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

