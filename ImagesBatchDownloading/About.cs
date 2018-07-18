using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ImagesBatchDownloading
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 点击超链接打开网页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //打开博客地址
            Process.Start(linkLabel1.Text);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //建立QQ临时会话
            Process.Start("tencent://message/?uin=36408253");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //复制MSN到剪切板
            DataObject m_data = new DataObject();
            m_data.SetData(DataFormats.Text, true, "tangjun_msn@hotmail.com");
            Clipboard.SetDataObject(m_data, true);
            MessageBox.Show("MSN:tangjun_msn@hotmail.com复制成功！");
            //建立MSN临时会话
            Process.Start("msnim:chat?contact=tangjun_msn@hotmail.com");
        }
    }
}