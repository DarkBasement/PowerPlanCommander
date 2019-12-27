namespace UI_TEST
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.edOriginal = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.edNewPlan = new System.Windows.Forms.TextBox();
            this.btRestore = new System.Windows.Forms.Button();
            this.btEnumerateProcesses = new System.Windows.Forms.Button();
            this.lbxAllProcesses = new System.Windows.Forms.ListBox();
            this.lbFindProc = new System.Windows.Forms.Button();
            this.edFindProc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.btStartTimer = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Set a Plan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Original:";
            // 
            // edOriginal
            // 
            this.edOriginal.Location = new System.Drawing.Point(181, 100);
            this.edOriginal.Name = "edOriginal";
            this.edOriginal.ReadOnly = true;
            this.edOriginal.Size = new System.Drawing.Size(100, 20);
            this.edOriginal.TabIndex = 2;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(181, 145);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(99, 26);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.BtSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "New:";
            // 
            // edNewPlan
            // 
            this.edNewPlan.Location = new System.Drawing.Point(383, 100);
            this.edNewPlan.Name = "edNewPlan";
            this.edNewPlan.Size = new System.Drawing.Size(96, 20);
            this.edNewPlan.TabIndex = 5;
            this.edNewPlan.Text = "low cpu";
            // 
            // btRestore
            // 
            this.btRestore.Location = new System.Drawing.Point(578, 145);
            this.btRestore.Name = "btRestore";
            this.btRestore.Size = new System.Drawing.Size(99, 27);
            this.btRestore.TabIndex = 6;
            this.btRestore.Text = "Restore";
            this.btRestore.UseVisualStyleBackColor = true;
            this.btRestore.Click += new System.EventHandler(this.BtRestore_Click);
            // 
            // btEnumerateProcesses
            // 
            this.btEnumerateProcesses.Location = new System.Drawing.Point(12, 282);
            this.btEnumerateProcesses.Name = "btEnumerateProcesses";
            this.btEnumerateProcesses.Size = new System.Drawing.Size(99, 26);
            this.btEnumerateProcesses.TabIndex = 7;
            this.btEnumerateProcesses.Text = "All Procs";
            this.btEnumerateProcesses.UseVisualStyleBackColor = true;
            this.btEnumerateProcesses.Click += new System.EventHandler(this.BtEnumerateProcesses_Click);
            // 
            // lbxAllProcesses
            // 
            this.lbxAllProcesses.FormattingEnabled = true;
            this.lbxAllProcesses.Location = new System.Drawing.Point(123, 282);
            this.lbxAllProcesses.Name = "lbxAllProcesses";
            this.lbxAllProcesses.Size = new System.Drawing.Size(254, 160);
            this.lbxAllProcesses.TabIndex = 8;
            // 
            // lbFindProc
            // 
            this.lbFindProc.Location = new System.Drawing.Point(496, 288);
            this.lbFindProc.Name = "lbFindProc";
            this.lbFindProc.Size = new System.Drawing.Size(75, 20);
            this.lbFindProc.TabIndex = 9;
            this.lbFindProc.Text = "Find";
            this.lbFindProc.UseVisualStyleBackColor = true;
            this.lbFindProc.Click += new System.EventHandler(this.LbFindProc_Click);
            // 
            // edFindProc
            // 
            this.edFindProc.Location = new System.Drawing.Point(577, 288);
            this.edFindProc.Name = "edFindProc";
            this.edFindProc.Size = new System.Drawing.Size(100, 20);
            this.edFindProc.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Result:";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(575, 340);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(57, 13);
            this.lbResult.TabIndex = 12;
            this.lbResult.Text = "Not Found";
            // 
            // btStartTimer
            // 
            this.btStartTimer.Location = new System.Drawing.Point(496, 388);
            this.btStartTimer.Name = "btStartTimer";
            this.btStartTimer.Size = new System.Drawing.Size(75, 23);
            this.btStartTimer.TabIndex = 13;
            this.btStartTimer.Text = "Start";
            this.btStartTimer.UseVisualStyleBackColor = true;
            this.btStartTimer.Click += new System.EventHandler(this.BtStartTimer_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btStartTimer);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edFindProc);
            this.Controls.Add(this.lbFindProc);
            this.Controls.Add(this.lbxAllProcesses);
            this.Controls.Add(this.btEnumerateProcesses);
            this.Controls.Add(this.btRestore);
            this.Controls.Add(this.edNewPlan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.edOriginal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edOriginal;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edNewPlan;
        private System.Windows.Forms.Button btRestore;
        private System.Windows.Forms.Button btEnumerateProcesses;
        private System.Windows.Forms.ListBox lbxAllProcesses;
        private System.Windows.Forms.Button lbFindProc;
        private System.Windows.Forms.TextBox edFindProc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Button btStartTimer;
        private System.Windows.Forms.Timer timer1;
    }
}

