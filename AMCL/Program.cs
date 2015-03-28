using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AMCL
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            Mutex mutex = new Mutex(true, Application.ProductName, out createdNew);
            if (createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AMCL());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("该程序已经在运行！");
                Application.Exit();
            }
        }
    }
}
