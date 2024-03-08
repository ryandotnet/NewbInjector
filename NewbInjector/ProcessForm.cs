using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace NewbInjector
{
    public partial class ProcessForm : Form
    {
        MainForm mainForm;

        public ProcessForm(MainForm mForm)
        {
            InitializeComponent();
            mainForm = mForm;
        }

        private void ProcessForm_Load(object sender, EventArgs e)
        {
            foreach (Process process in Proc.processList)
            {
                lbProcess.Items.Add(process.ProcessName + " - " + process.Id);
            }
        }

        private void lbProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            bSelect.Enabled = true;
        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            mainForm.updateProcess(Proc.processList[lbProcess.SelectedIndex].ProcessName);
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
