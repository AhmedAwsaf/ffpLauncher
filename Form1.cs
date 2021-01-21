using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ffpv2
{
    public partial class Form1 : Form
    {
        string Main;

        //processes//
        Process Server = new Process();
        System.Diagnostics.ProcessStartInfo StartInfoSer = new System.Diagnostics.ProcessStartInfo();
        Process Client = new Process();
        System.Diagnostics.ProcessStartInfo StartInfoCli = new System.Diagnostics.ProcessStartInfo();
        Process Qbank = new Process();
        System.Diagnostics.ProcessStartInfo StartInfoQba = new System.Diagnostics.ProcessStartInfo();
        Process Mongod = new Process();
        System.Diagnostics.ProcessStartInfo StartInfoMon = new System.Diagnostics.ProcessStartInfo();
        //processes end//
        public Form1()
        {
            InitializeComponent();
            this.Main = System.IO.Directory.GetCurrentDirectory();
            throwterm("Directory Set " + this.Main);
        }

        //terminal//
        public void throwterm(string con)
        {
            textBox1.AppendText(">>>"+con +"\r\n");
        }
        //terminal end//
        //MainSwitch//
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox1.AppendText(">>>mongod On\r\n");

                StartInfoMon.FileName = "cmd";
                StartInfoMon.UseShellExecute = false;
                StartInfoMon.RedirectStandardInput = true;
                StartInfoMon.WindowStyle = ProcessWindowStyle.Hidden;
                StartInfoMon.Arguments = "/C cd " + this.Main + " && cd server && mongod";

                Mongod.StartInfo = StartInfoMon;
                Mongod.Start();

                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
            }
            else
            {
                Mongod.StandardInput.Write("^C^C");
                Mongod.Close();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }
        //MainSwitch end//
        //server//
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.AppendText(">>>Server On\r\n");
                label1.Visible = true;

                StartInfoSer.FileName = "cmd";
                StartInfoSer.UseShellExecute = false;
                StartInfoSer.RedirectStandardInput = true;
                StartInfoSer.WindowStyle = ProcessWindowStyle.Hidden;
                StartInfoSer.Arguments = "/C cd " + this.Main + " && cd server && npm start";

                throwterm("Accessed Server Folder");

                Server.StartInfo = StartInfoSer;
                Server.Start();
            }
            else
            {
                textBox1.AppendText(">>>Server Off\r\n");
                label1.Visible = false;

                Server.StandardInput.Write("^C^C");
                Server.Close();
                //Server.WaitForExit();
                //if (Server.HasExited == false)
                //{
                //    Server.Kill();
                //}
                
            }
        }
        //server end//
        //client//
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox1.AppendText(">>>Client On\r\n");
                label2.Visible = true;

                StartInfoCli.FileName = "cmd";
                StartInfoCli.UseShellExecute = false;
                StartInfoCli.RedirectStandardInput = true;
                StartInfoCli.WindowStyle = ProcessWindowStyle.Hidden;
                StartInfoCli.Arguments = "/C cd " + this.Main + " && cd client && ng serve --host";

                throwterm("Accessed Client Folder");

                Client.StartInfo = StartInfoSer;
                Client.Start();
            }
            else
            {
                textBox1.AppendText(">>>Client Off\r\n");
                label2.Visible = false;

                Client.StandardInput.Write("^C^C");
                Client.Close();
            }
        }
        //client end//
        //qbank//
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox1.AppendText(">>>Qbank On\r\n");
                label3.Visible = true;

                StartInfoQba.FileName = "cmd";
                StartInfoQba.UseShellExecute = false;
                StartInfoQba.RedirectStandardInput = true;
                StartInfoQba.WindowStyle = ProcessWindowStyle.Hidden;
                StartInfoQba.Arguments = "/C cd " + this.Main + " && cd qbank && npm start";

                throwterm("Accessed Qbank Folder");

                Qbank.StartInfo = StartInfoSer;
                Qbank.Start();
            }
            else
            {
                textBox1.AppendText(">>>Qbank Off\r\n");
                label3.Visible = false;

                Qbank.StandardInput.Write("^C^C");
                Qbank.Close();
            }
        }
        //qbank end//

        //fileOverride//
        private void button2_Click(object sender, EventArgs e)
        {
            var folderdiag = new FolderBrowserDialog();
            DialogResult result = folderdiag.ShowDialog();
            this.Main = folderdiag.SelectedPath;
            throwterm("File directoy override to " + this.Main);
        }

        
        //fileOverride end//
    }
}
