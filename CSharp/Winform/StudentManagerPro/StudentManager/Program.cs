using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Models;

using System.Diagnostics;


namespace StudentManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ////禁止启动多个项目进程
            //Process[] processArrary = Process.GetProcesses();//获取所有进程
            //int currentCount = 0;//当前进程的总数
            //foreach (Process item in processArrary)
            //{
            //    if (item.ProcessName == Process.GetCurrentProcess().ProcessName)
            //    {
            //        currentCount += 1;
            //    }
            //}
            //if (currentCount > 1)
            //{
            //    Application.Exit();
            //    return;
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //创建登录窗体
            FrmUserLogin objUserLogin = new FrmUserLogin();
            DialogResult result = objUserLogin.ShowDialog();

            //根据窗体返回值判断用户登录是否成功
            if (result == DialogResult.OK)
                Application.Run(new FrmMain());
            else
                Application.Exit();
        }
        //声明用户信息的全局变量
        public static Admin currentAdmin = null;
    }
}
