using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AMCL
{
    static class Program
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll")]//返回值：如果窗口原来可见，返回值为非零；如果函数原来被隐藏，返回值为零。
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]//前台显示窗口
        private static extern bool SetForegroundWindow(IntPtr hWnd);
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
                IntPtr hWnd = FindWindow(null, Application.ProductName);
                ShowWindowAsync(hWnd, 1);
                SetForegroundWindow(hWnd);
                Application.Exit();
            }
        }
    }
}
