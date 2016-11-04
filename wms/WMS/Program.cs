using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    static class Program
    {
        private static System.Threading.Mutex Run;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                bool noRun = false;
                Run = new System.Threading.Mutex(true, System.Diagnostics.Process.GetCurrentProcess().ProcessName, out noRun);
                //检测是否已经运行
                if (!noRun)
                {
                    MessageBox.Show("本程序已经在运行了，请不要重复运行!", "重复运行");
                    Application.Exit();
                }
                else
                {
                    Run.ReleaseMutex();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Login.FrmLogin());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
    }
}
