namespace NewbInjector
{
    partial class ProcessForm
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
            this.lbProcess = new System.Windows.Forms.ListBox();
            this.bSelect = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbProcess
            // 
            this.lbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProcess.FormattingEnabled = true;
            this.lbProcess.IntegralHeight = false;
            this.lbProcess.Location = new System.Drawing.Point(9, 10);
            this.lbProcess.Name = "lbProcess";
            this.lbProcess.ScrollAlwaysVisible = true;
            this.lbProcess.Size = new System.Drawing.Size(180, 137);
            this.lbProcess.TabIndex = 0;
            this.lbProcess.SelectedIndexChanged += new System.EventHandler(this.lbProcess_SelectedIndexChanged);
            // 
            // bSelect
            // 
            this.bSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bSelect.Enabled = false;
            this.bSelect.Location = new System.Drawing.Point(8, 156);
            this.bSelect.Name = "bSelect";
            this.bSelect.Size = new System.Drawing.Size(85, 32);
            this.bSelect.TabIndex = 1;
            this.bSelect.Text = "Select";
            this.bSelect.UseVisualStyleBackColor = true;
            this.bSelect.Click += new System.EventHandler(this.bSelect_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bCancel.Location = new System.Drawing.Point(105, 156);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(85, 32);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 195);
            this.ControlBox = false;
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSelect);
            this.Controls.Add(this.lbProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProcessForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Select Process";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ProcessForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbProcess;
        private System.Windows.Forms.Button bSelect;
        private System.Windows.Forms.Button bCancel;
    }
}