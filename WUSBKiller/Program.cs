using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WUSBKiller
{
    static class Program
    {
        [DllImport(@"WUSBKillerLib.dll")]
        public static extern int RunAsSystem();
      
        [STAThread]
        static void Main()
        {
            //remove // for debuging 
            ///*
            if (!(
                new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)
                ))
            {
                //I'll do that so no kids will run this tool as Invoker and expect it to work
                MessageBox.Show("Error", "This tool need Administrative Privileges to work, Run as admin and try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //check if the current user is the SYTEM account if not run as SYSTEM
            //it's required to do that so we can modify files in "%drv%\System Volume Information"
            //
            if (user != @"NT AUTHORITY\SYSTEM")
            {
                RunAsSystem();
                return;
            }
            //*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
