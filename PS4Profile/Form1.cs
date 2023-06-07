using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace PS4Profile
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public static string path;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ipbox.Text = IniConfig.Newini.Read("PS4 IP", "IP");
            this.portbox.Text = IniConfig.Newini.Read("PS4 port", "port");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\" + "json\\online" + ".json");
            sw.WriteLine(label1.Text +  textBox1.Text +  label9.Text);
            sw.WriteLine(label2.Text +  textBox2.Text +  label10.Text);
            sw.WriteLine(label3.Text +  textBox3.Text +  label11.Text);
            sw.WriteLine(label4.Text +  textBox4.Text + label12.Text);

            sw.WriteLine(label_trophy.Text);

            sw.Close();
            StreamReader sr = new StreamReader(Application.StartupPath + "\\" + "json\\online" + ".json");
            sr.Close();
            MessageBox.Show(" Done");
                
            }
            catch
            {
                MessageBox.Show("Failed");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"json");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (ipbox.Text == "IP Here" | string.IsNullOrEmpty(ipbox.Text))
            {
                Interaction.MsgBox("Please enter a IP", MsgBoxStyle.Critical);
            }
            else
            {
                System.Diagnostics.Process.Start("explorer.exe", "ftp://" + ipbox.Text + ":" + portbox.Text + "/system_data/priv/cache/profile");
            }

        }

        private void ipbox__Click(object sender, EventArgs e)
        {
            ipbox.Clear();

        }

        private void portbox_Click(object sender, EventArgs e)
        {
            portbox.Clear();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            try
            {
                if (ipbox.Text == "")
                {
                    MessageBox.Show("Enter a valid IP address");
                }
                else
                {
                    IniConfig.Newini.Write("PS4 IP", "ip", ipbox.Text);
                    IniConfig.Newini.Write("PS4 PORT", "port", portbox.Text);
                    MessageBox.Show("IP: " + ipbox.Text + "\n" + "port: " + portbox.Text);
                    //this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error al cambiar la ip");
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Process.Start(@"avatar\0");
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Process.Start(@"avatar\1");
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Process.Start(@"avatar\2");
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Process.Start(@"avatar\3");
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Process.Start(@"avatar\4");
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Process.Start(@"avatar\5");
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Process.Start(@"avatar\6");
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            Process.Start(@"avatar\7");
        }
    }
}
