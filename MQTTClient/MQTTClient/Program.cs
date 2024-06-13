using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
//必须要引用的文件
using System.IO;
using log4net;
using log4net.Config;
using log4net.Repository;


namespace MQTTClient
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);
        // 消息函数
        [DllImport("user32.dll", EntryPoint = "PostMessageA")]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string strclassName, string strWindowName);
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MAXIMIZE = 0xF030;//窗体最大化消息
        public const int SC_NOMAL = 0xF120;//窗体还原消息
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            string strSysPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory);

            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName("EMS");//获取指定的进程名   
            if (myProcesses.Length > 0) //如果可以获取到知道的进程名则说明已经启动
            {
                //IntPtr hWnd = myProcesses[0].MainWindowHandle;//获得EMS的句柄 
                //SendMessage(hWnd, WM_SYSCOMMAND, SC_NOMAL, 0);
                //SetForegroundWindow(hWnd);
                //SendMessage(hWnd, WM_SYSCOMMAND, SC_NOMAL, 0);
            }
            else if (File.Exists(strSysPath + "EMS.exe"))
                Process.Start(strSysPath + "EMS.exe");

            if (!CheckAppExists())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            //else
            //{ 
            //    Process[] process = Process.GetProcessesByName("EMS");//在所有已启动的进程中查找需要的进程；
            //    if (process.Length > 0)//如果查找到
            //    {
            //        IntPtr hWnd = process[0].MainWindowHandle;//获得EMS的句柄 
            //                                                  // WindowAsync(hWnd, 9);// 9就是SW_RESTORE标志，表示还原窗体
            //        SendMessage(hWnd, WM_SYSCOMMAND, SC_NOMAL, 0);
            //        SetForegroundWindow(hWnd);
            //        SendMessage(hWnd, WM_SYSCOMMAND, SC_NOMAL, 0);
            //    }  
            //}
        }
        //判断是否重复打开
        public static bool CheckAppExists()
        {
            string name = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //获取指定的进程名   
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName(name);
            if (myProcesses.Length > 1) //如果可以获取到知道的进程名则说明已经启动
            {
                //MessageBox.Show("警告:程序正在运行中! 请不要重复打开程序!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Process[] process = Process.GetProcessesByName(name);//在所有已启动的进程中查找需要的进程；
                if (process.Length > 0)//如果查找到
                { 
                    IntPtr hWnd = process[0].MainWindowHandle; 
                    // wWindowAsync(hWnd, 9);// 9就是SW_RESTORE标志，表示还原窗体
                    SendMessage(hWnd, WM_SYSCOMMAND, SC_NOMAL, 0);
                    SetForegroundWindow(hWnd);
                }
                Application.Exit();//关闭系统
                return true;
            }
            return false;
        }

    }
}
