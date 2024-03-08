namespace NewbInjector
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bGetDLL = new System.Windows.Forms.Button();
            this.bInject = new System.Windows.Forms.Button();
            this.bGetProcess = new System.Windows.Forms.Button();
            this.cbAutoInject = new System.Windows.Forms.CheckBox();
            this.cbAutoClose = new System.Windows.Forms.CheckBox();
            this.tbProcess = new System.Windows.Forms.TextBox();
            this.tbDLL = new System.Windows.Forms.TextBox();
            this.lProcess = new System.Windows.Forms.Label();
            this.lDLL = new System.Windows.Forms.Label();
            this.lProcessBitness = new System.Windows.Forms.Label();
            this.lDLLBitness = new System.Windows.Forms.Label();
            this.tUpdate = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // bGetDLL
            // 
            this.bGetDLL.Location = new System.Drawing.Point(115, 90);
            this.bGetDLL.Name = "bGetDLL";
            this.bGetDLL.Size = new System.Drawing.Size(75, 22);
            this.bGetDLL.TabIndex = 0;
            this.bGetDLL.Text = "Browse";
            this.bGetDLL.UseVisualStyleBackColor = true;
            this.bGetDLL.Click += new System.EventHandler(this.bGetDLL_Click);
            // 
            // bInject
            // 
            this.bInject.Enabled = false;
            this.bInject.Location = new System.Drawing.Point(91, 144);
            this.bInject.Name = "bInject";
            this.bInject.Size = new System.Drawing.Size(99, 39);
            this.bInject.TabIndex = 1;
            this.bInject.Text = "Inject";
            this.bInject.UseVisualStyleBackColor = true;
            this.bInject.Click += new System.EventHandler(this.bInject_Click);
            // 
            // bGetProcess
            // 
            this.bGetProcess.Location = new System.Drawing.Point(115, 22);
            this.bGetProcess.Name = "bGetProcess";
            this.bGetProcess.Size = new System.Drawing.Size(75, 22);
            this.bGetProcess.TabIndex = 2;
            this.bGetProcess.Text = "Browse";
            this.bGetProcess.UseVisualStyleBackColor = true;
            this.bGetProcess.Click += new System.EventHandler(this.bGetProcess_Click);
            // 
            // cbAutoInject
            // 
            this.cbAutoInject.AutoSize = true;
            this.cbAutoInject.Location = new System.Drawing.Point(8, 144);
            this.cbAutoInject.Name = "cbAutoInject";
            this.cbAutoInject.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAutoInject.Size = new System.Drawing.Size(77, 17);
            this.cbAutoInject.TabIndex = 4;
            this.cbAutoInject.Text = "Auto Inject";
            this.cbAutoInject.UseVisualStyleBackColor = true;
            this.cbAutoInject.CheckedChanged += new System.EventHandler(this.cbAutoInject_CheckedChanged);
            // 
            // cbAutoClose
            // 
            this.cbAutoClose.AutoSize = true;
            this.cbAutoClose.Location = new System.Drawing.Point(8, 167);
            this.cbAutoClose.Name = "cbAutoClose";
            this.cbAutoClose.Size = new System.Drawing.Size(77, 17);
            this.cbAutoClose.TabIndex = 5;
            this.cbAutoClose.Text = "Auto Close";
            this.cbAutoClose.UseVisualStyleBackColor = true;
            this.cbAutoClose.CheckedChanged += new System.EventHandler(this.cbAutoClose_CheckedChanged);
            // 
            // tbProcess
            // 
            this.tbProcess.Location = new System.Drawing.Point(8, 23);
            this.tbProcess.Name = "tbProcess";
            this.tbProcess.Size = new System.Drawing.Size(100, 20);
            this.tbProcess.TabIndex = 6;
            this.tbProcess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDLL
            // 
            this.tbDLL.BackColor = System.Drawing.SystemColors.Window;
            this.tbDLL.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbDLL.Location = new System.Drawing.Point(8, 91);
            this.tbDLL.Name = "tbDLL";
            this.tbDLL.ReadOnly = true;
            this.tbDLL.ShortcutsEnabled = false;
            this.tbDLL.Size = new System.Drawing.Size(100, 20);
            this.tbDLL.TabIndex = 7;
            this.tbDLL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbDLL.WordWrap = false;
            this.tbDLL.TextChanged += new System.EventHandler(this.tbDLL_TextChanged);
            // 
            // lProcess
            // 
            this.lProcess.Location = new System.Drawing.Point(8, 5);
            this.lProcess.Name = "lProcess";
            this.lProcess.Size = new System.Drawing.Size(101, 18);
            this.lProcess.TabIndex = 8;
            this.lProcess.Text = "Process Name";
            this.lProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lDLL
            // 
            this.lDLL.Location = new System.Drawing.Point(8, 76);
            this.lDLL.Name = "lDLL";
            this.lDLL.Size = new System.Drawing.Size(101, 13);
            this.lDLL.TabIndex = 9;
            this.lDLL.Text = "DLL Name";
            this.lDLL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lProcessBitness
            // 
            this.lProcessBitness.Location = new System.Drawing.Point(8, 46);
            this.lProcessBitness.Name = "lProcessBitness";
            this.lProcessBitness.Size = new System.Drawing.Size(100, 11);
            this.lProcessBitness.TabIndex = 10;
            this.lProcessBitness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lDLLBitness
            // 
            this.lDLLBitness.Location = new System.Drawing.Point(9, 114);
            this.lDLLBitness.Name = "lDLLBitness";
            this.lDLLBitness.Size = new System.Drawing.Size(100, 11);
            this.lDLLBitness.TabIndex = 11;
            this.lDLLBitness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tUpdate
            // 
            this.tUpdate.Enabled = true;
            this.tUpdate.Interval = 1000;
            this.tUpdate.Tick += new System.EventHandler(this.tUpdate_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 195);
            this.Controls.Add(this.lDLLBitness);
            this.Controls.Add(this.lProcessBitness);
            this.Controls.Add(this.lDLL);
            this.Controls.Add(this.lProcess);
            this.Controls.Add(this.tbDLL);
            this.Controls.Add(this.tbProcess);
            this.Controls.Add(this.cbAutoClose);
            this.Controls.Add(this.cbAutoInject);
            this.Controls.Add(this.bGetProcess);
            this.Controls.Add(this.bInject);
            this.Controls.Add(this.bGetDLL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Newb Injector";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bGetDLL;
        private System.Windows.Forms.Button bInject;
        private System.Windows.Forms.Button bGetProcess;
        private System.Windows.Forms.CheckBox cbAutoInject;
        private System.Windows.Forms.CheckBox cbAutoClose;
        private System.Windows.Forms.TextBox tbDLL;
        private System.Windows.Forms.Label lProcess;
        private System.Windows.Forms.Label lDLL;
        private System.Windows.Forms.Label lProcessBitness;
        private System.Windows.Forms.Label lDLLBitness;
        private System.Windows.Forms.Timer tUpdate;
        private System.Windows.Forms.TextBox tbProcess;
    }
}

