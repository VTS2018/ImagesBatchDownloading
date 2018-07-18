using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ImagesBatchDownloading
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ImageForm imgForm = new ImageForm();
            imgForm.StartPosition = FormStartPosition.CenterScreen;
            //设置窗口的最大化最小化
            //imgForm.WindowState=FormWindowState.Normal/Maximized/Minimized
            //是否最顶层的窗口
            //imgForm.TopMost = true;
            imgForm.TopLevel = true;
            imgForm.SizeGripStyle = SizeGripStyle.Hide;
            Application.Run(imgForm);
        }
    }
}