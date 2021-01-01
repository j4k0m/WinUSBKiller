using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WUSBKiller
{
    public partial class Form1 : Form
    {
        [DllImport(@"WUSBKillerLib.dll")]
        public static extern int CreateSymlink(string drv, string target, bool random);
        public static int clicks = 0;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Win USB Killer, User \"" + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "\"";

        }

        private void Form1_Load(object sender, EventArgs e){


            this.MaximizeBox = false;
        
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                TargetBox.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                TargetBox.Enabled = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            switch (clicks)
            {
                case 0:
                    clicks++;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    TargetBox.Enabled = false;
                    Drives.Enabled = true;
                    HideVolumesBox.Enabled = true;
                    FormatBox.Enabled = true;
                    progressBar1.Value = 100;
                    Drives.Items.Clear();
                    Drives.ResetText();
                    foreach (var drive in DriveInfo.GetDrives())
                    {
                        
                        if (drive.DriveType == DriveType.Removable && drive.IsReady && drive.DriveFormat == "NTFS")
                        {
                                Drives.Items.Add(drive.Name);

                        }

                    }
                    if(Drives.Items.Count != 0)
                    {
                        //handle the exception if no drives are available
                        Drives.SelectedIndex = 0;
                    }

                    break;
                case 1:
                    //do a check if there's a selected drive or not
                    if (string.IsNullOrEmpty(Drives.Text))
                    {
                        MessageBox.Show("Select a valid drive to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var drv = new DriveInfo(Drives.Text);
                    if (!drv.IsReady)
                    {
                        MessageBox.Show("The drive doesn't seems to be ready, Are you sure it's write-able","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if(drv.DriveFormat != "NTFS")
                    {
                        MessageBox.Show("Non NTFS drives aren't supported for the moment, format it and try again","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if(drv.DriveType == DriveType.Fixed)
                    {
                        var result = MessageBox.Show("This is a fixed drive, are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(result == DialogResult.No)
                        {
                            return;
                        }
                    
                    }
                    int res = CreateSymlink(Drives.Text, TargetBox.Text, radioButton1.Checked);
                    
                    if (res != 0)
                    {
                        MessageBox.Show("Failed to create symbolic link, error code : " + res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        progressBar2.Value = 100;
                        MessageBox.Show("Done !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }



                    clicks++;
                    Drives.Enabled = false;
                    HideVolumesBox.Enabled = false;
                    FormatBox.Enabled = false;
                    NextButton.Text = "Exit";
                    
                    break;
                case 2:
                    Application.Exit();
                    break;
            }
                
        }

        private void HideVolumesBox_CheckedChanged(object sender, EventArgs e)
        {
            //this event determine wheither all drives must be shown or no
            if (HideVolumesBox.Checked)
            {
                Drives.Items.Clear();
                Drives.ResetText();
                foreach (var drive in DriveInfo.GetDrives())
                {
                    Drives.Items.Add(drive.Name);
                }
            }
            else
            {
                Drives.Items.Clear();
                Drives.ResetText();
                foreach (var drive in DriveInfo.GetDrives())
                {

                    if (drive.DriveType == DriveType.Removable && drive.IsReady && drive.DriveFormat == "NTFS")
                    {
                       Drives.Items.Add(drive.Name);

                    }

                }
            }
            if (Drives.Items.Count != 0)
            {
                //handle the exception if no drives are available
                Drives.SelectedIndex = 0;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e){}

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("This was developped by Abdelhamid Naceri" +
                "\nThis tool was given to you under MIT License" +
                "\nI am not responsible for any bad usage for this tool","About", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }
    }
}
//to do : Format to NTFS