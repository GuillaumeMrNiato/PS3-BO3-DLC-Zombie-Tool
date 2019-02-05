using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS3Lib;
using Microsoft.VisualBasic;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace Simple_projet
{
    public partial class Form1 : Form
    {
        static PS3API PS3 = new PS3API();
        //Change Round = 0x174A2AF
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://paypal.me/MrNiato/5");
        }

        private void firefoxRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
        }

        private void firefoxRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }
        public static string get_player_name(uint client)
        {
            string getnames = PS3.Extension.ReadString(0x18CA098 + client * 0x61E0);
            return getnames;
        }
        private void firefoxButton4_Click(object sender, EventArgs e)
        {
            Players.Items.Clear();
            for (uint i = 0; i < 0x04; i++)
            {
                Players.Items.Add(get_player_name(i));
            }
        }

        private void giveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C4418 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x01, 0x01, 0x01, 0x01 });
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C4418 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x00, 0x10, 0x10, 0x00 });
            }
        }

        private void firefoxButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PS3.ConnectTarget())
                {
                    MessageBox.Show("Playstation 3 Connected !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An Error As Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error As Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void firefoxButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (PS3.AttachProcess())
                {
                    MessageBox.Show("Process Attached !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An Error As Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error As Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void giveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C4862 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x18C4826 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x18BC8C2 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x18C486A + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x18C4864 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x7f, 0xff, 0xff, 0xff });
            }
        }

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C4862 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x18C4826 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x18BC8C2 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x18C486A + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x18C4864 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x00, 0x00, 0xff, 0x00 });
            }
        }

        private void maxPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA19D + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x7f, 0xff, 0xff, 0xff });
            }
        }

        private void giveToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA0E0 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x3f, 0xff });
            }
        }

        private void removeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA0E0 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x3f, 0x80 });
            }
        }

        private void giveToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA00F + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x01 });
            }
        }

        private void removeToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA00F + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x02 });
            }
        }

        private void giveToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C4415 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x01 });
            }
        }

        private void removeToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C4415 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x00 });
            }
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void fuzzyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void removeToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA1E7 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x00 });
            }
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA1E7 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x03 });
            }
        }

        private void giveToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA0CD + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0xff, 0x00, 0x64, 0x00 });
            }
        }

        private void removeToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA0CD + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x00, 0x00, 0x64, 0x00 });
            }
        }

        private void defaultWeaponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x01 });
            }
        }

        private void vsperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x02 });
            }
        }

        private void vMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x04 });
            }
        }

        private void kudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x06 });
            }
        }

        private void pharoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x08 });
            }
        }

        private void bowWrathOfTheAncientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void kreegakaleetLuGosataahmToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void wrathOfTheAncientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x76 });
            }
        }

        private void kreegakaleetLuGosataahmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x79 });
            }
        }

        private void kreeahoahmNalAhmhogarocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x7D });
            }
        }

        private void kreeahoahmNalAhmahmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x83 });
            }
        }

        private void kreeaholoLuKreemasaleetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x89 });
            }
        }

        private void deathMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x95 });
            }
        }

        private void portersX2RayGunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x96 });
            }
        }

        private void bootlegerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void manOWarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void firefoxCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (firefoxCheckBox1.Checked)
            {
                PS3.SetMemory(0x18C4418, new byte[] { 0x01, 0x01, 0x01, 0x01 });
                PS3.SetMemory(0x18C4418 + 0x61E0, new byte[] { 0x01, 0x01, 0x01, 0x01 });
                PS3.SetMemory(0x18C4418 + 0x61E0 + 0x61E0, new byte[] { 0x01, 0x01, 0x01, 0x01 });
                PS3.SetMemory(0x18C4418 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0x01, 0x01, 0x01, 0x01 });
            }
            else
            {
                PS3.SetMemory(0x18C4418, new byte[] { 0x00, 0x10, 0x10, 0x00 });
                PS3.SetMemory(0x18C4418 + 0x61E0, new byte[] { 0x00, 0x10, 0x10, 0x00 });
                PS3.SetMemory(0x18C4418 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x10, 0x10, 0x00 });
                PS3.SetMemory(0x18C4418 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x10, 0x10, 0x00 });
            }
        }

        private void firefoxCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (firefoxCheckBox2.Checked)
            {
                PS3.SetMemory(0x18BC8C2, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18BC8C2 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18BC8C2 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18BC8C2 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                //
                PS3.SetMemory(0x18C4862, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4862 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4862 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4862 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                //
                PS3.SetMemory(0x18C4826, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4826 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4826 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4826 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                //
                PS3.SetMemory(0x18C486A, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C486A + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C486A + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C486A + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                //
                PS3.SetMemory(0x18C4864, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4864 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4864 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4864 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
            }
            else
            {
                PS3.SetMemory(0x18BC8C2, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18BC8C2 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18BC8C2 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18BC8C2 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                //
                PS3.SetMemory(0x18C4862, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4862 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4862 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4862 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                //
                PS3.SetMemory(0x18C4826, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4826 + 0x61E0, new byte[] {  0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4826 + 0x61E0 + 0x61E0, new byte[] {  0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4826 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] {  0x00, 0x00, 0x00, 0x00 });
                //
                PS3.SetMemory(0x18C486A, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C486A + 0x61E0, new byte[] {  0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C486A + 0x61E0 + 0x61E0, new byte[] {  0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C486A + 0x61E0 + 0x61E0 + 0x61E0, new byte[] {  0x00, 0x00, 0x00, 0x00 });
                //
                PS3.SetMemory(0x18C4864, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4864 + 0x61E0, new byte[] {  0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4864 + 0x61E0 + 0x61E0, new byte[] {  0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4864 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] {  0x00, 0x00, 0x00, 0x00 });
            }
        }

        private void firefoxCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (firefoxCheckBox3.Checked)
            {
                PS3.SetMemory(0x18CA19D, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18CA19D + 0x61E0, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18CA19D + 0x61E0 + 0x61E0, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18CA19D + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0x7f, 0xff, 0xff, 0xff });
            }
            else
            {
                PS3.SetMemory(0x18CA19D, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18CA19D + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18CA19D + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18CA19D + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x01 });
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x02 });
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x03 });
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x04 });
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x05 });
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x06 });
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x07 });
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x08 });
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x09 });
            }
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x0A });
            }
        }

        private void darkMetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x11 });
            }
        }

        private void girlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x0C });
            }
        }

        private void fireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x02 });
            }
        }

        private void defaultToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x00 });
            }
        }

        private void sendModdedInGameStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA1B2 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x18CA1BE + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x18CA19E + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0xff, 0xff, 0xff, 0xff });
            }
        }
        public string method_30(int int_1)
        {
            byte[] buffer = new byte[0x10];
            PS3.GetMemory(0x1AEE380 + 0x3334 + ((uint)(int_1 * 0x3900)), buffer);
            return Encoding.ASCII.GetString(buffer).Replace("\0", "");
        }
        private void changeNameInGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("Set a new name here :", "Change Name By MrNiato", method_30(Players.SelectedIndex), -1, -1);
            byte[] bytes = Encoding.ASCII.GetBytes(str + "\0");
            PS3.SetMemory(0x18CA0fc + ((uint)(Players.SelectedIndex * 0x61E0)), bytes);
            PS3.SetMemory((0x18CA19b + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x00 });
            Thread.Sleep(1000);
            PS3.SetMemory((0x18CA19b + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x01 });
        }
        public static void SavePosition(int ClientInt)
        {
            byte[] bytes = PS3.Extension.ReadBytes(0x18C42E8 + 0x30 + ((uint)(ClientInt * 0x61d8)), 14);
            System.IO.File.WriteAllBytes("Position.txt", bytes);
        }
        public static void TeleportAllToPosition(int ClientInt)
        {
            byte[] input = System.IO.File.ReadAllBytes("Position.txt");
            for (uint i = 0; i < 11; i++)
            {
                uint offset = 0x18C42E8 + 0x30 + (0x61d8 * i);
                PS3.Extension.WriteBytes(offset, input);
            }
        }
        private void teleportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeleportAllToPosition(Players.SelectedIndex);
        }

        private void save1erToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePosition(Players.SelectedIndex);
        }
    }
}
