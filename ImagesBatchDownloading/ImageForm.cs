using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Net;
using System.Text.RegularExpressions;

using System.Collections;
using System.IO;



namespace ImagesBatchDownloading
{
    public partial class ImageForm : Form
    {
        //一次自动编号(图片重命名用)
        private static int fileIndex = 1;

        private static ManualResetEvent allDone = new ManualResetEvent(false);

        private string _ImageType = "jpg|jpeg|png|ico|bmp|gif";

        private string dir = string.Empty;

        /// <summary>
        /// 下载图片类型 
        /// </summary>
        public string ImageType
        {
            get
            {
                return _ImageType;
            }
            set
            {
                _ImageType = value;
            }
        }

        public ImageForm()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        static extern bool QueryPerformanceCounter(ref long count);

        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        static extern bool QueryPerformanceFrequency(ref long count);


        /// <summary>
        /// 根据网址分析并下载
        /// 搜索规则：
        ///     1.支持完整路径搜索 如:http: http://www.baidu.com/img/logo.gif
        ///     2.支持当前网址短路径搜索 如 /img/logo.gif 和 img/logo.gif
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnalyzeAndDownload_Click(object sender, EventArgs e)
        {
            //网页路径
            string url = this.tbURL.Text.Trim();
            //保存路径
            string savePath = this.tbSavePath.Text.Trim();

            if (string.IsNullOrEmpty(savePath) || string.IsNullOrEmpty(url))
            {
                MessageBox.Show("保存路径或网址不能为空！！");
                return;
            }

            Match match = Regex.Match(url, @"^http(s)?://+([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                MessageBox.Show("网址格式不对！请输入完成的网址，如 http://www.baidu.com ");
                return;
            }

            this.lbShow.Items.Clear();
            toolStripStatusLabel1.Text = "正在分析...";
            toolStripStatusLabel2.Text = " | 分析耗时:0";
            toolStripStatusLabel3.Text = " | 共 0 张图片";
            toolStripStatusLabel4.Text = " | 下载耗时:0";
            btnAnalyzeAndDownloadByURI.Enabled = false;
            Application.DoEvents();

            //输出路径
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            if (radioButton1.Checked)
                AnalyzeAndDownload(url, savePath);              //同步分析下载
            else
                AsyncAnalyzeAndDownload(url, savePath);         //异步分析下载
        }

        #region 同步分析下载

        /// <summary>
        /// 同步分析下载
        /// </summary>
        private void AnalyzeAndDownload(string url,string savePath)
        {

            #region 计时

            long count = 0;
            long count1 = 0;
            long freq = 0;
            double result = 0;

            QueryPerformanceFrequency(ref freq);
            QueryPerformanceCounter(ref count);

            #endregion

            //需要测试的模块
            List<string> list = URIAnalyze(url);

            #region 计时

            QueryPerformanceCounter(ref count1);
            count = count1 - count;
            result = (double)(count) / (double)freq;

            #endregion

            this.lbShow.Items.AddRange(list.ToArray());
            toolStripStatusLabel1.Text = "分析完毕！正在下载...";
            toolStripStatusLabel2.Text = string.Format(" | 分析耗时:{0}秒", result);
            toolStripStatusLabel3.Text = string.Format(" | 共 {0} 张图片", list.Count);
            Application.DoEvents();

            #region 计时

            count = 0;
            count1 = 0;
            freq = 0;
            result = 0;

            QueryPerformanceFrequency(ref freq);
            QueryPerformanceCounter(ref count);

            #endregion

            //下载数据
            DownLoad(list, savePath);

            #region 计时

            QueryPerformanceCounter(ref count1);
            count = count1 - count;
            result = (double)(count) / (double)freq;

            #endregion

            toolStripStatusLabel1.Text = "下载完毕！";
            toolStripStatusLabel4.Text = string.Format(" | 下载耗时:{0}秒", result);
            btnAnalyzeAndDownloadByURI.Enabled = true;
        }

        /// <summary>
        /// 根据URI分析网站
        /// </summary>
        /// <param name="uriString"></param>
        /// <returns></returns>
        protected List<string> URIAnalyze(string uriString)
        {
            WebClient wClient = null;
            try
            {
                string dnDir = string.Empty;
                string domainName = string.Empty;

                //获得域名 http://www.sina.com/
                Match match = Regex.Match(uriString, @"((http(s)?://)?)+[\w-.]+[^/]", RegexOptions.IgnoreCase);
                domainName = match.Value;

                //获得域名最深层目录 http://www.sina.com/mail/
                if (domainName.Equals(uriString))
                    dnDir = domainName;
                else
                    dnDir = uriString.Substring(0, uriString.LastIndexOf('/'));

                dnDir += '/';

                List<string> list = new List<string>();
                wClient = new WebClient();
                wClient.Credentials = CredentialCache.DefaultCredentials;
                //获得远程服务器返回的数据
                string pageData = Encoding.Default.GetString(wClient.DownloadData(uriString));

                //匹配全路径
                match = Regex.Match(pageData, @"((http(s)?://)?)+(((/?)+[\w-.]+(/))*)+[\w-./]+\.+(" + ImageType + ")", RegexOptions.IgnoreCase);

                while (match.Success)
                {
                    string item = match.Value;
                    //短路径处理
                    if (item.IndexOf("http://") == -1 && item.IndexOf("https://") == -1)
                        item = (item[0] == '/' ? domainName : dnDir) + item;
                    //过滤掉完全一样
                    if (!list.Contains(item))
                        list.Add(item);
                    match = match.NextMatch();
                }
                return list;
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wClient.Dispose();
            }
            
            return new List<string>();
        }

        /// <summary>
        /// 下载并保存图片
        /// </summary>
        /// <param name="imagesUrlList"></param>
        public void DownLoad(List<string> imagesUrlList, string Dir)
        {
            //判断文件夹是否存在
            if (!Directory.Exists(Dir))
                Directory.CreateDirectory(Dir);

            int i = fileIndex;
            foreach (string item in imagesUrlList)
            {
                try
                {
                    HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(item);
                    using (Stream stream = hwr.GetResponse().GetResponseStream())
                    {
                        Image img = Image.FromStream(stream);
                        img.Save(Dir + "/" + i.ToString() + item.Substring(item.LastIndexOf('.')));
                        stream.Close();
                        ++i;
                    }
                }
                catch (Exception)
                {
                    //出错继续执行下一个下载
                    continue;
                }
            }
            fileIndex = i;
        }

        #endregion

        #region 异步分析下载

        long count;
        long count1;
        long freq;
        double result;

        long ccount = 0;
        long ccount1 = 0;
        long cfreq = 0 ;
        double cresult = 0;

        string uriString = string.Empty;
        string savePath = string.Empty;

        bool isAnalyzeComplete = false;
        
        List<string> imgUrlList = new List<string>();

        public delegate void AsyncEventHandler();

        /// <summary>
        /// 异步分析下载
        /// </summary>
        private void AsyncAnalyzeAndDownload(string url, string savePath)
        {
            this.uriString = url;
            this.savePath = savePath;

            #region 分析计时开始

            count = 0;
            count1 = 0;
            freq = 0;
            result = 0;

            QueryPerformanceFrequency(ref freq);
            QueryPerformanceCounter(ref count);

            #endregion

            using (WebClient wClient = new WebClient())
            {
                AutoResetEvent waiter = new AutoResetEvent(false);
                wClient.Credentials = CredentialCache.DefaultCredentials;
                wClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(AsyncURIAnalyze);
                wClient.DownloadDataAsync(new Uri(uriString), waiter);
                //waiter.WaitOne();     //阻止当前线程，直到收到信号
            }
                
        }

        /// <summary>
        /// 异步分析
        /// </summary>
        protected void AsyncURIAnalyze(Object sender, DownloadDataCompletedEventArgs e)
        {
            AutoResetEvent waiter = (AutoResetEvent)e.UserState;
            try
            {
                if (!e.Cancelled && e.Error == null)
                {
                    
                    string dnDir = string.Empty;
                    string domainName = string.Empty;
                    string uri = uriString;

                    //获得域名 http://www.sina.com/
                    Match match = Regex.Match(uri, @"((http(s)?://)?)+[\w-.]+[^/]");//, RegexOptions.IgnoreCase
                    domainName = match.Value;

                    //获得域名最深层目录 http://www.sina.com/mail/
                    if (domainName.Equals(uri))
                        dnDir = domainName;
                    else
                        dnDir = uri.Substring(0, uri.LastIndexOf('/'));

                    dnDir += '/';
                    
                    //获取数据
                    string pageData = Encoding.UTF8.GetString(e.Result);
                    List<string> urlList = new List<string>();

                    //匹配全路径
                    match = Regex.Match(pageData, @"((http(s)?://)?)+(((/?)+[\w-.]+(/))*)+[\w-./]+\.+(" + ImageType + ")"); //, RegexOptions.IgnoreCase
                    while (match.Success)
                    {
                        string item = match.Value;
                        //短路径处理
                        if (item.IndexOf("http://") == -1 && item.IndexOf("https://") == -1)
                            item = (item[0] == '/' ? domainName : dnDir) + item;

                        if (!urlList.Contains(item))
                        {
                            urlList.Add(item);
                            imgUrlList.Add(item);

                            //实时显示分析结果
                            AddlbShowItem(item);

                            //边分析边下载
                            WebRequest hwr = WebRequest.Create(item);
                            hwr.BeginGetResponse(new AsyncCallback(AsyncDownLoad), hwr);
                            //hwr.Timeout = "0x30D40";        //默认 0x186a0 -> 100000 0x30D40 -> 200000
                            //hwr.Method = "POST";
                            //hwr.ContentType = "application/x-www-form-urlencoded";
                            //hwr.MaximumAutomaticRedirections = 3;
                            //hwr.Accept ="image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                            //hwr.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*";
                            //IAsyncResult iar = hwr.BeginGetResponse(new AsyncCallback(AsyncDownLoad), hwr);
                            //iar.AsyncWaitHandle.WaitOne();
                        }
                        match = match.NextMatch();
                    }
                }
            }
            finally
            {
                waiter.Set();

                #region 分析计时结束

                QueryPerformanceCounter(ref count1);
                count = count1 - count;
                result = (double)(count) / (double)freq;

                toolStripStatusLabel1.Text = "分析完毕！";
                toolStripStatusLabel2.Text = string.Format(" | 分析耗时:{0}秒", result);
                Application.DoEvents();

                #endregion

                //分析完毕
                isAnalyzeComplete = true;
            }
        }

        #region 实时显示分析和下载结果

        delegate void SetTextCallback(string text);

        /// <summary>
        ///实时显示分析结果
        /// </summary>
        /// <param name="item"></param>
        private void AddlbShowItem(string item)
        {
            if (this.lbShow.InvokeRequired)
                this.Invoke(new SetTextCallback(AddlbShowItem), new object[] { item });
            else
            {
                this.lbShow.Items.Add(item);
                toolStripStatusLabel3.Text = string.Format(" | 共 {0} 张图片", this.lbShow.Items.Count);
                Application.DoEvents();
            }
        }

        delegate void SetDownloadCallback(int indexItem);

        /// <summary>
        ///实时显示分析结果
        /// </summary>
        /// <param name="item"></param>
        private void SetlbShowItem(int indexItem)
        {
            if (this.lbShow.InvokeRequired)
                this.Invoke(new SetDownloadCallback(SetlbShowItem), new object[] { indexItem });
            else
            {
                this.lbShow.Items[indexItem] = "√  " + this.lbShow.Items[indexItem];
                //是否分析完毕
                if (isAnalyzeComplete)
                {
                    if (imgUrlList.Count == 0)
                    {
                        #region 下载计时结束

                        QueryPerformanceCounter(ref ccount1);
                        ccount = ccount1 - ccount;
                        cresult = (double)(ccount) / (double)cfreq;

                        #endregion

                        toolStripStatusLabel1.Text = "下载完毕！";
                        toolStripStatusLabel4.Text = string.Format(" | 下载耗时:{0}秒", cresult);
                        btnAnalyzeAndDownloadByURI.Enabled = true;
                    }
                    else
                    {
                        //多次读性能优于多次写
                        if (!"正在下载...".Equals(toolStripStatusLabel1.Text))
                            toolStripStatusLabel1.Text = "正在下载...";
                    }
                }
                else
                {
                    if (!"正在分析 | 正在下载...".Equals(toolStripStatusLabel1.Text))
                        toolStripStatusLabel1.Text = "正在分析 | 正在下载...";
                }
                Application.DoEvents();
            }
        }

        #endregion

        /// <summary>
        /// 异步接受数据
        /// </summary>
        /// <param name="asyncResult"></param>
        public  void AsyncDownLoad(IAsyncResult asyncResult)  
        {
            #region 下载计时开始

            if (cfreq == 0)
            {
                QueryPerformanceFrequency(ref cfreq);
                QueryPerformanceCounter(ref ccount);
            }

            #endregion

            WebRequest request = (WebRequest)asyncResult.AsyncState;
            string url = request.RequestUri.ToString();
            try
            {
                WebResponse response = request.EndGetResponse(asyncResult);
                using (Stream stream = response.GetResponseStream())
                {
                    Image img = Image.FromStream(stream);
                    string[] tmpUrl = url.Split('.');
                    img.Save(string.Concat(savePath, "/", DateTime.Now.ToString("yyyyMMddHHmmssfff"), ".", tmpUrl[tmpUrl.Length - 1]));
                    img.Dispose();
                    stream.Close();
                }
                allDone.Set();

                //从未下载的列表中删除已经下载的图片
                imgUrlList.Remove(url);

                //更新列表框
                int indexItem = this.lbShow.Items.IndexOf(url);
                if (indexItem >= 0 && indexItem <= this.lbShow.Items.Count)
                    SetlbShowItem(indexItem);
            }
            catch (Exception)
            {
                imgUrlList.Remove(url);
            }
        }

        #endregion

        /// <summary>
        /// 获得图片类型
        /// </summary>
        /// <returns></returns>
        private void CheckImagesType(CheckBox cbox)
        {
            string ImageType = _ImageType + '|';

            ImageType = cbox.Checked ? string.Concat(ImageType, cbox.Text) : ImageType.Replace(cbox.Text + '|', string.Empty);

            if ('|'.Equals(ImageType[ImageType.Length - 1]))
                ImageType = ImageType.Remove(ImageType.Length - 1, 1);

            _ImageType = ImageType;
        }

        #region 页面事件

        /// <summary>
        /// 点击打开文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            //选中并确定
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lbShow.Items.Clear();
                lbShow.Items.AddRange(openFileDialog1.FileNames);
            }
        }

        /// <summary>
        /// 图片保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //选中并确定
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                tbSavePath.Text = folderBrowserDialog1.SelectedPath;
            else
                tbSavePath.Text = "";
        }

        /// <summary>
        /// About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            About about = new About();
            //窗体居中
            about.StartPosition = FormStartPosition.CenterScreen;
            about.Show();
        }

        private void 保存路径SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void 开发文件FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOpen_Click(sender, e);
        }

        /// <summary>
        /// gif图片格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ch_ImageType3_CheckedChanged(object sender, EventArgs e)
        {
            CheckImagesType(ch_ImageType3);
        }

        /// <summary>
        /// bmp图片格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ch_ImageType2_CheckedChanged(object sender, EventArgs e)
        {
            CheckImagesType(ch_ImageType2);
        }

        /// <summary>
        /// jpg|jpeg图片格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ch_ImageType1_CheckedChanged(object sender, EventArgs e)
        {
            CheckImagesType(ch_ImageType1);
        }

        /// <summary>
        /// ico图片格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ch_ImageType4_CheckedChanged(object sender, EventArgs e)
        {
            CheckImagesType(ch_ImageType4);
        }

        #endregion

        private void ImageForm_Load(object sender, EventArgs e)
        {
            //this.MaximumSize = this.MinimumSize;
        }

        #region 未完成的部分 先注释

        /*
        /// <summary>
        /// 短路径图片搜索
        ///     1.本地已经存在的图片则不拷贝了
        /// </summary>
        /// <returns></returns>
        private List<string> DomainName(string data, string successValue, string uriString)
        {
            List<string> list = new List<string>();

            Match match = Regex.Match(successValue, @"http(s)?://+[\w-.]+/?", RegexOptions.IgnoreCase);
            //获得域名 http://www.sina.com/
            string domainName = string.Empty;
            //是否匹配
            if (match.Success)
            {
                //获得域名最深层目录 http://www.sina.com/mail/
                string dnDir = string.Empty;
                domainName = match.Value;
                match = Regex.Match(successValue, @"http(s)?://[\w-]+\.+[\w-.]+((/?)+[\w-]+/)*", RegexOptions.IgnoreCase);
                dnDir = match.Value;

                //获得文件名
                FileInfo file = new FileInfo(uriString);
                //剪除已经存在的图片
                string dirfilename = file.Name.Substring(0, file.Name.LastIndexOf(".")) + ".files";

                match = Regex.Match(data, @"(((/?)+[\w-.]+/)*)+[\w-]+\.+(jpg|jpeg|bmp|gif|ico)", RegexOptions.IgnoreCase);
                while (match.Success)
                {
                    string item = match.Value;
                    if (!dirfilename.Equals(item))
                    {
                        item = (item[0] == '/' ? domainName : dnDir) + item;
                        //过滤掉完全一样
                        if (!list.Contains(item)) list.Add(item);
                    }
                    match = match.NextMatch();
                }
            }
            return list;
        }


        /// <summary>
        /// 根据文件抓取图片
        /// </summary>
        /// <param name="uriString"></param>
        /// <returns></returns>
        protected List<string> FileAnalyze(string uriString)
        {
            string pageData;
            StreamReader sr = null;
            pageData = string.Empty;

            //取得数据
            try
            {
                sr = new StreamReader(uriString, Encoding.UTF8);
                pageData = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                ShowWorkingState.Text = string.Format("分析出错！出错文件：[{0}] 错误描述：[{1}]", uriString, ex.Message);
                throw;
            }
            finally
            {
                sr.Close();
            }

            List<string> list = new List<string>();

            //匹配是否有页面的网址
            Match match = Regex.Match(pageData, @"<!-- (saved from url=\(+[\w]+\)|This document saved from )+http(s)?://([\w-]+\.)+[\w-]+((/[\w- ./?%&=]*)?)+[\w_ ]+-->", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                list.AddRange(DomainName(pageData, match.Value, uriString));
            }
            //匹配全路径
            match = Regex.Match(pageData, @"http(s)?://+(((/?)+[\w-.]+(/))*)+[\w-./]+\.+(jpg|jpeg|png|ico|bmp|gif)", RegexOptions.IgnoreCase);

            while (match.Success)
            {
                //过滤掉完全一样
                if (!list.Contains(match.Value)) list.Add(match.Value);
                match = match.NextMatch();
            }

            return list;
        }

        /// <summary>
        /// !!!本方法有待完善，正则表达式在工具里面测试通过，但是这里确通不过！
        /// 根据文件分析并下载
        /// 支持文件格式：*.txt|*.htm|*.html|*.css|*.js|*.mht
        /// 搜索规则：
        ///     1.被搜索的网页文件中如下标示链接，将被模拟成网页地址来处理
        ///         a.<!-- saved from url=(0029)http://www.baidu.com/s?wd=asd -->   //IE
        ///         b.<!-- This document saved from http://www.baidu.com/ -->       //Opera
        ///         //c.火狐好像没有这样的标志
        ///     2.没有如上情况的只找完整链接地址图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnalyzeAndDownloadByFiles_Click(object sender, EventArgs e)
        {
            //文件地址
            ListBox.ObjectCollection files = lbShow.Items;
            //保存路径
            string savePath = this.tbSavePath.Text.Trim();

            if (string.IsNullOrEmpty(savePath) || files.Count == 0)
            {
                MessageBox.Show("保存路径或待分析的文件列表不能为空！！");
                return;
            }
            //获得文件列表
            string[] fileList = new string[lbShow.Items.Count];
            lbShow.Items.CopyTo(fileList, 0);

            this.lbShow.Items.Clear();
            toolStripStatusLabel1.Text = "正在分析...";
            toolStripStatusLabel2.Text = "分析耗时:0";
            toolStripStatusLabel3.Text = "下载耗时:0";
            toolStripStatusLabel4.Text = "下载耗时:0";
            btnAnalyzeAndDownloadByURI.Enabled = false;
            Application.DoEvents();

            #region 分析

            long count = 0;
            long count1 = 0;
            long freq = 0;
            double result = 0;

            QueryPerformanceFrequency(ref freq);
            QueryPerformanceCounter(ref count);

            //需要测试的模块
            List<string> list = new List<string>();
            foreach (object item in fileList)
            {
                if (File.Exists(item.ToString()))
                {
                    ShowWorkingState.Text = string.Format("正在分析[{0}]。", item);
                    Application.DoEvents();
                    list.AddRange(FileAnalyze(item.ToString()));
                }
                else
                {
                    ShowWorkingState.Text = string.Format("文件[{0}]不存在！", item);
                    Application.DoEvents();
                }
            }

            QueryPerformanceCounter(ref count1);
            count = count1 - count;
            result = (double)(count) / (double)freq;

            #endregion

            this.lbShow.Items.AddRange(list.ToArray());
            toolStripStatusLabel1.Text = "分析完毕正在下载...";
            toolStripStatusLabel2.Text = string.Format("分析耗时:{0}秒", result);
            toolStripStatusLabel3.Text = string.Format("共 {0} 张图片", list.Count);
            Application.DoEvents();

            #region 下载

            count = 0;
            count1 = 0;
            freq = 0;
            result = 0;

            QueryPerformanceFrequency(ref freq);
            QueryPerformanceCounter(ref count);

            //foreach (object var in collection_to_loop)
            //{
            //    if (!Directory.Exists(uriString))
            //    {
            //        MessageBox.Show("文件不存在！！");
            //    }
            //    //下载数据
            //    DownLoad(list, tbSavePath.Text);
            //}

            QueryPerformanceCounter(ref count1);
            count = count1 - count;
            result = (double)(count) / (double)freq;

            #endregion

            toolStripStatusLabel1.Text = "下载完毕!!";
            toolStripStatusLabel4.Text = string.Format("下载耗时:{0}秒", result);
            btnAnalyzeAndDownloadByURI.Enabled = true;
        }
        */

        #endregion

        //------------------------------------------------测试用

        ///// <summary>
        ///// 根据网址分析图片路径
        ///// </summary>
        ///// <param name="pageURL"></param>
        //protected List<string> URIAnalyze(string uriString)
        //{
        //    Match match = Regex.Match(uriString, @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase);
        //    if (match.Success)
        //    {
        //        WebClient wClient = null;
        //        try
        //        {
        //            string dnDir = string.Empty;
        //            string domainName = string.Empty;

        //            //获得域名最深层目录 http://www.sina.com/mail/
        //            dnDir = uriString.Substring(0, uriString.LastIndexOf('/') + 1);
        //            //获得域名 http://www.sina.com/
        //            match = Regex.Match(uriString, @"http(s)?://+[\w-.]+[^/]", RegexOptions.IgnoreCase);
        //            domainName = match.Value;

        //            List<string> list = new List<string>();
        //            wClient = new WebClient();
        //            wClient.Credentials = CredentialCache.DefaultCredentials;
        //            //获得远程服务器返回的数据
        //            string pageData = Encoding.Default.GetString(wClient.DownloadData(uriString));

        //            //匹配全路径
        //            match = Regex.Match(pageData, @"((http(s)?://)?)+(((/?)+[\w-.]+(/))*)+[\w-./]+\.+(" + ImageType + ")", RegexOptions.IgnoreCase);

        //            while (match.Success)
        //            {
        //                string item = match.Value;
        //                //短路径处理
        //                if (item.IndexOf("http://") == -1 && item.IndexOf("https://") == -1)
        //                    item = (item[0] == '/' ? domainName : dnDir) + item;
        //                //过滤掉完全一样
        //                if (!list.Contains(item))
        //                    list.Add(item);
        //                match = match.NextMatch();
        //            }
        //            return list;
        //        }
        //        catch (WebException ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //        finally
        //        {
        //            wClient.Dispose();
        //        }
        //    }
        //    return new List<string>();
        //}

        //private void btnTest_Click(object sender, EventArgs e)
        //{
        //    Match match = Regex.Match("", @"(((/?)+[\w-.]+/)*)+[\w-]+\.+(jpg|jpeg|bmp|gif|ico)", RegexOptions.IgnoreCase);
        //}


    }
}