using System;
using System.Windows.Forms;

namespace BIG.VMS.PRESENT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string todayInPath = Application.StartupPath + "\\IMAGES\\" + DateTime.Now.Year + "_" + DateTime.Now.Month.ToString().PadLeft(2, '0')+"\\"+ DateTime.Now.Day+"\\IN\\";
            string todayOutPath = Application.StartupPath + "\\IMAGES\\" + DateTime.Now.Year + "_" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "\\" + DateTime.Now.Day + "\\OUT\\";
            System.IO.Directory.CreateDirectory(todayInPath);
            System.IO.Directory.CreateDirectory(todayOutPath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogOn());
        }
    }
}
