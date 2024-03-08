using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace NewbInjector
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Newb\\Injector\\"));

            if (!File.Exists(Injector.helperPath))
            {
                File.WriteAllBytes(Injector.helperPath, Properties.Resources.Win32Helper);
            }

            if (!File.Exists(Config.cfgPath))
            {
                File.WriteAllText(Config.cfgPath, Properties.Resources.config);
            }

            if (Config.readXML("Process") != "null")
            {
                tbProcess.Text = Config.readXML("Process");
            }

            if (Config.readXML("DLL") != "null")
            {
                tbDLL.Text = Config.readXML("DLL");
            }

            if (Config.readXML("Path") != "null")
            {
                Injector.dllPath = Config.readXML("Path");

                Bitness.getBitness(Injector.dllPath);
                lDLLBitness.Text = Bitness.dllBitness;
            }

            if (Config.readXML("AutoInject") == "true")
            {
                cbAutoInject.Checked = true;
            }

            else if (Config.readXML("AutoInject") == "false")
            {
                cbAutoInject.Checked = false;
            }

            if (Config.readXML("AutoClose") == "true")
            {
                cbAutoClose.Checked = true;
            }

            else if (Config.readXML("AutoClose") == "false")
            {
                cbAutoClose.Checked = false;
            }

            ActiveControl = bInject;
        }

        private void bGetDLL_Click(object sender, EventArgs e)
        {
            OpenFileDialog browser = new OpenFileDialog();

            browser.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            browser.Title = "Select DLL File to Inject";
            browser.Filter = "DLL Files (*.dll)|*.dll";
            browser.FilterIndex = 1;
            browser.RestoreDirectory = true;

            DialogResult browseResult = browser.ShowDialog();

            if (browseResult == DialogResult.OK)
            {
                Injector.dllPath = browser.FileName;
                tbDLL.Text = browser.SafeFileName;

                Bitness.getBitness(Injector.dllPath);
                lDLLBitness.Text = Bitness.dllBitness;

                Config.writeXML(browser.FileName, "Path");
                Config.writeXML(browser.SafeFileName, "DLL");
            }

            else if (browseResult == DialogResult.Cancel || browseResult == DialogResult.Abort)
            {
                return;
            }
        }

        private void bGetProcess_Click(object sender, EventArgs e)
        {
            Proc.getProcesses();
            ProcessForm newForm = new ProcessForm(this);
            newForm.Location = new Point(this.Location.X + 214, this.Location.Y);
            newForm.Size = new Size(214, 234);
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.ShowDialog();

        }

        private void bInject_Click(object sender, EventArgs e)
        {
            Injector.processID = Process.GetProcessesByName(tbProcess.Text)[0].Id;

            if (!Proc.procIDs.Contains(Injector.processID))
            {
                Injector.Inject();

                if (cbAutoClose.Checked)
                {
                    Close();
                }

                else
                {
                    MessageBox.Show("Successfully Injected!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public bool checkBitness()
        {
            if (lProcessBitness.Text == "" || lDLLBitness.Text == "")
            {
                bInject.Enabled = false;

                lProcessBitness.ForeColor = Color.Black;
                lDLLBitness.ForeColor = Color.Black;

                return false;
            }

            else if (lProcessBitness.Text.Equals(lDLLBitness.Text))
            {
                bInject.Enabled = true;

                lProcessBitness.ForeColor = Color.Green;
                lDLLBitness.ForeColor = Color.Green;

                return true;
            }

            else
            {
                bInject.Enabled = false;

                lProcessBitness.ForeColor = Color.Red;
                lDLLBitness.ForeColor = Color.Red;

                return false;
            }
        }

        private void tbDLL_TextChanged(object sender, EventArgs e)
        {
            Proc.procIDs.Clear();
        }

        public void updateProcess(string procName)
        {
            tbProcess.Text = procName;
        }

        private void tUpdate_Tick(object sender, EventArgs e)
        {
            if (tbProcess.Text.Any() && Proc.checkProcess(tbProcess.Text) == true)
            {
                Process process = Process.GetProcessesByName(tbProcess.Text)[0];

                try
                {
                    Bitness.getProcBitness(process);
                }

                catch (Win32Exception)
                {
                    tbProcess.Text = "";
                    MessageBox.Show("You can't Inject into a System Process!", "Insufficient Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Injector.processID = process.Id;

                lProcessBitness.Text = Bitness.procBitness;

                Config.writeXML(tbProcess.Text, "Process");

                if (cbAutoInject.Checked && !Proc.procIDs.Contains(process.Id))
                {
                    if (checkBitness() == true)
                    {
                        Proc.procIDs.Add(process.Id);

                        Injector.Inject();

                        if (cbAutoClose.Checked)
                        {
                            Close();
                        }

                        else
                        {
                            MessageBox.Show("Successfully Injected!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

            else if (Proc.checkProcess(tbProcess.Text) == false)
            {
                lProcessBitness.Text = "";
            }

            checkBitness();
        }

        private void cbAutoInject_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoInject.Checked)
            {
                Config.writeXML("true", "AutoInject");
            }

            else
            {
                Config.writeXML("false", "AutoInject");
            }
        }

        private void cbAutoClose_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoClose.Checked)
            {
                Config.writeXML("true", "AutoClose");
            }

            else
            {
                Config.writeXML("false", "AutoClose");
            }
        }
    }
}
