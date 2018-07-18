namespace ImagesBatchDownloading
{
    partial class ImageForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tbSavePath = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAnalyzeAndDownloadByURI = new System.Windows.Forms.Button();
            this.ssState = new System.Windows.Forms.StatusStrip();
            this.tsslState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbShow = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ch_ImageType1 = new System.Windows.Forms.CheckBox();
            this.ch_ImageType2 = new System.Windows.Forms.CheckBox();
            this.ch_ImageType3 = new System.Windows.Forms.CheckBox();
            this.ch_ImageType4 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ShowWorkingState = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.保存路径SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开发文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.ssState.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "html";
            this.openFileDialog1.Filter = "网页，全部(*.html;*.htm)|*.html;*.htm|文本文件(*.txt)|*.txt|Css样式文件(*.css)|*.css|Js文件(*.js" +
                ")|*.js|Web档案，单一文件(*.mht)|*.mht";
            this.openFileDialog1.Multiselect = true;
            // 
            // tbSavePath
            // 
            this.tbSavePath.Location = new System.Drawing.Point(85, 34);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.ReadOnly = true;
            this.tbSavePath.Size = new System.Drawing.Size(269, 21);
            this.tbSavePath.TabIndex = 999;
            this.tbSavePath.Text = "E:\\images";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(405, 31);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "指定输出地址";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "根据网址：";
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(85, 70);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(427, 21);
            this.tbURL.TabIndex = 0;
            this.tbURL.Text = "http://www.sina.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "保存路径：";
            // 
            // btnAnalyzeAndDownloadByURI
            // 
            this.btnAnalyzeAndDownloadByURI.Location = new System.Drawing.Point(405, 130);
            this.btnAnalyzeAndDownloadByURI.Name = "btnAnalyzeAndDownloadByURI";
            this.btnAnalyzeAndDownloadByURI.Size = new System.Drawing.Size(138, 28);
            this.btnAnalyzeAndDownloadByURI.TabIndex = 3;
            this.btnAnalyzeAndDownloadByURI.Text = "下载图片";
            this.btnAnalyzeAndDownloadByURI.UseVisualStyleBackColor = true;
            this.btnAnalyzeAndDownloadByURI.Click += new System.EventHandler(this.btnAnalyzeAndDownload_Click);
            // 
            // ssState
            // 
            this.ssState.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslState,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.ssState.Location = new System.Drawing.Point(0, 398);
            this.ssState.Name = "ssState";
            this.ssState.Size = new System.Drawing.Size(564, 22);
            this.ssState.TabIndex = 4;
            this.ssState.Text = "statusStrip1";
            // 
            // tsslState
            // 
            this.tsslState.Name = "tsslState";
            this.tsslState.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel1.Text = "等待分析  ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(101, 17);
            this.toolStripStatusLabel2.Text = " | 分析耗时:0   ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(101, 17);
            this.toolStripStatusLabel3.Text = " | 共 0 张图片  ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(101, 17);
            this.toolStripStatusLabel4.Text = " | 下载耗时:0   ";
            // 
            // lbShow
            // 
            this.lbShow.CausesValidation = false;
            this.lbShow.FormattingEnabled = true;
            this.lbShow.HorizontalScrollbar = true;
            this.lbShow.ItemHeight = 12;
            this.lbShow.Location = new System.Drawing.Point(16, 164);
            this.lbShow.Name = "lbShow";
            this.lbShow.ScrollAlwaysVisible = true;
            this.lbShow.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbShow.Size = new System.Drawing.Size(527, 220);
            this.lbShow.TabIndex = 5;
            // 
            // ch_ImageType1
            // 
            this.ch_ImageType1.AutoSize = true;
            this.ch_ImageType1.Checked = true;
            this.ch_ImageType1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_ImageType1.Location = new System.Drawing.Point(85, 109);
            this.ch_ImageType1.Name = "ch_ImageType1";
            this.ch_ImageType1.Size = new System.Drawing.Size(72, 16);
            this.ch_ImageType1.TabIndex = 1001;
            this.ch_ImageType1.Text = "jpg|jpeg";
            this.ch_ImageType1.UseVisualStyleBackColor = true;
            this.ch_ImageType1.CheckedChanged += new System.EventHandler(this.ch_ImageType1_CheckedChanged);
            // 
            // ch_ImageType2
            // 
            this.ch_ImageType2.AutoSize = true;
            this.ch_ImageType2.Checked = true;
            this.ch_ImageType2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_ImageType2.Location = new System.Drawing.Point(163, 109);
            this.ch_ImageType2.Name = "ch_ImageType2";
            this.ch_ImageType2.Size = new System.Drawing.Size(42, 16);
            this.ch_ImageType2.TabIndex = 1002;
            this.ch_ImageType2.Text = "bmp";
            this.ch_ImageType2.UseVisualStyleBackColor = true;
            this.ch_ImageType2.CheckedChanged += new System.EventHandler(this.ch_ImageType2_CheckedChanged);
            // 
            // ch_ImageType3
            // 
            this.ch_ImageType3.AutoSize = true;
            this.ch_ImageType3.Checked = true;
            this.ch_ImageType3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_ImageType3.Location = new System.Drawing.Point(212, 109);
            this.ch_ImageType3.Name = "ch_ImageType3";
            this.ch_ImageType3.Size = new System.Drawing.Size(42, 16);
            this.ch_ImageType3.TabIndex = 1003;
            this.ch_ImageType3.Text = "gif";
            this.ch_ImageType3.UseVisualStyleBackColor = true;
            this.ch_ImageType3.CheckedChanged += new System.EventHandler(this.ch_ImageType3_CheckedChanged);
            // 
            // ch_ImageType4
            // 
            this.ch_ImageType4.AutoSize = true;
            this.ch_ImageType4.Checked = true;
            this.ch_ImageType4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_ImageType4.Location = new System.Drawing.Point(262, 109);
            this.ch_ImageType4.Name = "ch_ImageType4";
            this.ch_ImageType4.Size = new System.Drawing.Size(42, 16);
            this.ch_ImageType4.TabIndex = 1004;
            this.ch_ImageType4.Text = "ico";
            this.ch_ImageType4.UseVisualStyleBackColor = true;
            this.ch_ImageType4.CheckedChanged += new System.EventHandler(this.ch_ImageType4_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "图片类型：";
            // 
            // ShowWorkingState
            // 
            this.ShowWorkingState.AutoSize = true;
            this.ShowWorkingState.Location = new System.Drawing.Point(24, 377);
            this.ShowWorkingState.Name = "ShowWorkingState";
            this.ShowWorkingState.Size = new System.Drawing.Size(0, 12);
            this.ShowWorkingState.TabIndex = 1006;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(564, 25);
            this.toolStrip1.TabIndex = 1007;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存路径SToolStripMenuItem,
            this.开发文件FToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(60, 22);
            this.toolStripDropDownButton1.Text = "文件(F)";
            // 
            // 保存路径SToolStripMenuItem
            // 
            this.保存路径SToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.保存路径SToolStripMenuItem.Name = "保存路径SToolStripMenuItem";
            this.保存路径SToolStripMenuItem.ShortcutKeyDisplayString = "(S)";
            this.保存路径SToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存路径SToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.保存路径SToolStripMenuItem.Text = "保存路径";
            this.保存路径SToolStripMenuItem.ToolTipText = "指定下载输出路径";
            this.保存路径SToolStripMenuItem.Click += new System.EventHandler(this.保存路径SToolStripMenuItem_Click);
            // 
            // 开发文件FToolStripMenuItem
            // 
            this.开发文件FToolStripMenuItem.Name = "开发文件FToolStripMenuItem";
            this.开发文件FToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.开发文件FToolStripMenuItem.Text = "打开文件(O)";
            this.开发文件FToolStripMenuItem.Click += new System.EventHandler(this.开发文件FToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(33, 22);
            this.toolStripButton1.Text = "关于";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(313, 109);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(42, 16);
            this.checkBox1.TabIndex = 1004;
            this.checkBox1.Text = "png";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.ch_ImageType4_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1008;
            this.label2.Text = "下载类型：";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(85, 140);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 1009;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "同步";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(138, 140);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 1009;
            this.radioButton2.Text = "异步";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(564, 420);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ShowWorkingState);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ch_ImageType4);
            this.Controls.Add(this.ch_ImageType3);
            this.Controls.Add(this.ch_ImageType2);
            this.Controls.Add(this.ch_ImageType1);
            this.Controls.Add(this.lbShow);
            this.Controls.Add(this.ssState);
            this.Controls.Add(this.btnAnalyzeAndDownloadByURI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbSavePath);
            this.Controls.Add(this.tbURL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "笨笨图片批量抓取下载 V0.2 beta";
            this.Load += new System.EventHandler(this.ImageForm_Load);
            this.ssState.ResumeLayout(false);
            this.ssState.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox tbSavePath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAnalyzeAndDownloadByURI;
        private System.Windows.Forms.StatusStrip ssState;
        private System.Windows.Forms.ToolStripStatusLabel tsslState;
        private System.Windows.Forms.ListBox lbShow;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.CheckBox ch_ImageType1;
        private System.Windows.Forms.CheckBox ch_ImageType2;
        private System.Windows.Forms.CheckBox ch_ImageType3;
        private System.Windows.Forms.CheckBox ch_ImageType4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Label ShowWorkingState;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem 开发文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存路径SToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

