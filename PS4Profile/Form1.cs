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


            string[] lines = File.ReadAllLines(@"ID.txt");
            comboBoxID.DataSource = lines;

            //
            StreamReader sr = new StreamReader(Application.StartupPath + "\\" + "ID" + ".txt");
            idBox.Text = sr.ReadLine();
            id2Box.Text = sr.ReadLine();
            id3Box.Text = sr.ReadLine();
            id4Box.Text = sr.ReadLine();
            id5Box.Text = sr.ReadLine();
            id6Box.Text = sr.ReadLine();
            id7Box.Text = sr.ReadLine();
            sr.Close();

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
            MessageBox.Show(" Done");
                payloadStatus.ForeColor = Color.FromArgb(18, 157, 0);
                payloadStatus.Text = "Save json. ";
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

        private void idBox_Click(object sender, EventArgs e)
        {
        
        }

        //
        public void sendcheatsjson()
        {
            bool overwrite = false;
            try
            {
                var di = new DirectoryInfo(Application.StartupPath + "/json");

                var ftp = new FTP("", "");
                foreach (FileInfo fi in di.EnumerateFiles("*.json"))
                {
                    if (File.Exists("ftp://" + ipbox.Text + ":" + portbox.Text + "/system_data/priv/cache/profile/" + comboBoxID.Text + "/" + fi.Name) & overwrite == true)
                    {
                        ftp.UploadFile(fi.FullName, "ftp://" + ipbox.Text + ":" + portbox.Text + "/system_data/priv/cache/profile/" + comboBoxID.Text + "/" + fi.Name);
                    }
                    else if (File.Exists("ftp://" + ipbox.Text + ":" + portbox.Text + "/system_data/priv/cache/profile/" + comboBoxID.Text + "/" + fi.Name) & overwrite == false)
                    {
                    }

                    else
                    {
                        ftp.UploadFile(fi.FullName, "ftp://" + ipbox.Text + ":" + portbox.Text + "/system_data/priv/cache/profile/" + comboBoxID.Text + "/" + fi.Name);
                    }
                }


                Interaction.MsgBox("Test! ", MsgBoxStyle.Exclamation);
                payloadStatus.ForeColor = Color.FromArgb(18, 157, 0);
                payloadStatus.Text = "Successful. ";
                UseWaitCursor = false;
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var overwrite = MessageBox.Show("Are you sure you want to send the file? \nonline.json to ID (" + comboBoxID.Text + ") ", "json Sender", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            try
            {

                if (overwrite == DialogResult.No)
                {

                }
                else if (ipbox.Text == "IP Here" | string.IsNullOrEmpty(ipbox.Text))
                {
                    Interaction.MsgBox("Please enter a IP", MsgBoxStyle.Critical);
                }
                else
                {
                    Properties.MySettingsProperty.Settings.IP = ipbox.Text;
                    UseWaitCursor = true;
                    sendcheatsjson();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
        }
        //idSaves
        private void idSaves_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\" + "ID" + ".txt");
                sw.WriteLine(idBox.Text);
                sw.WriteLine(id2Box.Text);
                sw.WriteLine(id3Box.Text);
                sw.WriteLine(id4Box.Text);
                sw.WriteLine(id5Box.Text);
                sw.WriteLine(id6Box.Text);
                sw.WriteLine(id7Box.Text);
                sw.Close();
                MessageBox.Show("Save All ID \n 1.(" + idBox.Text + ") 2.(" + id2Box.Text + ") 3.(" + id3Box.Text + 
                    ") 4.(" + id4Box.Text + ") \n 5.(" + id5Box.Text + ") 6.(" + id6Box.Text + ") 7.(" + id7Box.Text + ")", "Save All ID");
                string[] lines = File.ReadAllLines(@"ID.txt");
                Update();
                Refresh();
                comboBoxID.DataSource = lines;
                payloadStatus.ForeColor = Color.FromArgb(18, 157, 0);
                payloadStatus.Text = "Save All ID. ";


            }
            catch
            {
                MessageBox.Show("Failed");
            }
        }
        //
        public void sendcheatsavatar()
        {
            bool overwrite = false;
            try
            {
                var di = new DirectoryInfo(Application.StartupPath + "/avatar/" + comboBoxAvatar.Text);

                var ftp = new FTP("", "");
                foreach (FileInfo fi in di.EnumerateFiles("*"))
                {
                    if (File.Exists("ftp://" + ipbox.Text + ":" + portbox.Text + "/system_data/priv/cache/profile/" + comboBoxID.Text + "/" + fi.Name) & overwrite == true)
                    {
                        ftp.UploadFile(fi.FullName, "ftp://" + ipbox.Text + ":" + portbox.Text + "/system_data/priv/cache/profile/" + comboBoxID.Text + "/" + fi.Name);
                    }
                    else if (File.Exists("ftp://" + ipbox.Text + ":" + portbox.Text + "/system_data/priv/cache/profile/" + comboBoxID.Text + "/" + fi.Name) & overwrite == false)
                    {
                    }

                    else
                    {
                        ftp.UploadFile(fi.FullName, "ftp://" + ipbox.Text + ":" + portbox.Text + "/system_data/priv/cache/profile/" + comboBoxID.Text + "/" + fi.Name);
                    }
                }


                Interaction.MsgBox("Test! ", MsgBoxStyle.Exclamation);
                payloadStatus.ForeColor = Color.FromArgb(18, 157, 0);
                payloadStatus.Text = "Successful. ";
                UseWaitCursor = false;
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
        }
        private void sendAvarat_icon_Click(object sender, EventArgs e)
        {
            var overwrite = MessageBox.Show("Are you sure to change the ID (" + comboBoxID.Text + ") avatar Sender", "Avatar",  MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            try
            {

                if (overwrite == DialogResult.No)
                {

                }
                else if (ipbox.Text == "IP Here" | string.IsNullOrEmpty(ipbox.Text))
                {
                    Interaction.MsgBox("Please enter a IP", MsgBoxStyle.Critical);
                }
                else
                {
                    Properties.MySettingsProperty.Settings.IP = ipbox.Text;
                    UseWaitCursor = true;
                    sendcheatsavatar();

                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
        }
    }
}
