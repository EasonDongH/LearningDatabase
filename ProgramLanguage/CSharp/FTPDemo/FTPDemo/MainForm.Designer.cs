namespace FTPDemo
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelMain = new System.Windows.Forms.Panel();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.groupbox = new System.Windows.Forms.GroupBox();
            this.lvServerFile = new System.Windows.Forms.ListView();
            this.Icon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.displayname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.lblOpenFile = new System.Windows.Forms.Label();
            this.txtLocalPath = new System.Windows.Forms.TextBox();
            this.btnDownloadFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtServerPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtServerUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.groupbox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.rtbInfo);
            this.panelMain.Controls.Add(this.groupbox);
            this.panelMain.Controls.Add(this.groupBox2);
            this.panelMain.Controls.Add(this.groupBox1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(12, 7, 12, 14);
            this.panelMain.Size = new System.Drawing.Size(669, 436);
            this.panelMain.TabIndex = 0;
            // 
            // rtbInfo
            // 
            this.rtbInfo.Location = new System.Drawing.Point(18, 316);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.ReadOnly = true;
            this.rtbInfo.Size = new System.Drawing.Size(638, 101);
            this.rtbInfo.TabIndex = 6;
            this.rtbInfo.TabStop = false;
            this.rtbInfo.Text = "";
            // 
            // groupbox
            // 
            this.groupbox.Controls.Add(this.lvServerFile);
            this.groupbox.Location = new System.Drawing.Point(322, 10);
            this.groupbox.Name = "groupbox";
            this.groupbox.Size = new System.Drawing.Size(334, 294);
            this.groupbox.TabIndex = 5;
            this.groupbox.TabStop = false;
            this.groupbox.Text = "服务器文件";
            // 
            // lvServerFile
            // 
            this.lvServerFile.AutoArrange = false;
            this.lvServerFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Icon,
            this.displayname});
            this.lvServerFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvServerFile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvServerFile.FullRowSelect = true;
            this.lvServerFile.GridLines = true;
            this.lvServerFile.Location = new System.Drawing.Point(3, 19);
            this.lvServerFile.MultiSelect = false;
            this.lvServerFile.Name = "lvServerFile";
            this.lvServerFile.Size = new System.Drawing.Size(328, 272);
            this.lvServerFile.SmallImageList = this.imageList1;
            this.lvServerFile.TabIndex = 20;
            this.lvServerFile.UseCompatibleStateImageBehavior = false;
            this.lvServerFile.View = System.Windows.Forms.View.Details;
            this.lvServerFile.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvServerFile_ColumnClick);
            this.lvServerFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvServerFile_MouseDoubleClick);
            // 
            // Icon
            // 
            this.Icon.Text = "";
            this.Icon.Width = 35;
            // 
            // displayname
            // 
            this.displayname.Text = "返回上层目录";
            this.displayname.Width = 293;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "文件.png");
            this.imageList1.Images.SetKeyName(1, "文件夹.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUploadFile);
            this.groupBox2.Controls.Add(this.lblOpenFile);
            this.groupBox2.Controls.Add(this.txtLocalPath);
            this.groupBox2.Controls.Add(this.btnDownloadFile);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(18, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 145);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "本地";
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Location = new System.Drawing.Point(89, 52);
            this.btnUploadFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(77, 31);
            this.btnUploadFile.TabIndex = 12;
            this.btnUploadFile.Text = "上传文件";
            this.btnUploadFile.UseVisualStyleBackColor = true;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // lblOpenFile
            // 
            this.lblOpenFile.AutoSize = true;
            this.lblOpenFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOpenFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOpenFile.Location = new System.Drawing.Point(263, 22);
            this.lblOpenFile.Name = "lblOpenFile";
            this.lblOpenFile.Size = new System.Drawing.Size(24, 23);
            this.lblOpenFile.TabIndex = 11;
            this.lblOpenFile.Text = "...";
            this.lblOpenFile.Click += new System.EventHandler(this.lblOpenFile_Click);
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.Location = new System.Drawing.Point(72, 22);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(185, 23);
            this.txtLocalPath.TabIndex = 10;
            this.txtLocalPath.Text = "TempFile\\";
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Location = new System.Drawing.Point(6, 52);
            this.btnDownloadFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(77, 31);
            this.btnDownloadFile.TabIndex = 0;
            this.btnDownloadFile.Text = "下载文件";
            this.btnDownloadFile.UseVisualStyleBackColor = true;
            this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "文件路径：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnQuit);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.txtServerPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtServerIP);
            this.groupBox1.Controls.Add(this.txtServerUser);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(18, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 147);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器";
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(114, 107);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(77, 31);
            this.btnQuit.TabIndex = 14;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(31, 107);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(77, 31);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtServerPassword
            // 
            this.txtServerPassword.Location = new System.Drawing.Point(55, 77);
            this.txtServerPassword.Name = "txtServerPassword";
            this.txtServerPassword.Size = new System.Drawing.Size(136, 23);
            this.txtServerPassword.TabIndex = 8;
            this.txtServerPassword.Text = "123456";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "密码：";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(55, 19);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(136, 23);
            this.txtServerIP.TabIndex = 2;
            this.txtServerIP.Text = "192.168.1.11";
            // 
            // txtServerUser
            // 
            this.txtServerUser.Location = new System.Drawing.Point(55, 48);
            this.txtServerUser.Name = "txtServerUser";
            this.txtServerUser.Size = new System.Drawing.Size(136, 23);
            this.txtServerUser.TabIndex = 6;
            this.txtServerUser.Text = "ftptest";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "用户名：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 436);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(685, 475);
            this.MinimumSize = new System.Drawing.Size(685, 475);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelMain.ResumeLayout(false);
            this.groupbox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.Label lblOpenFile;
        private System.Windows.Forms.TextBox txtLocalPath;
        private System.Windows.Forms.Button btnDownloadFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtServerPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TextBox txtServerUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupbox;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.ListView lvServerFile;
        private System.Windows.Forms.ColumnHeader Icon;
        private System.Windows.Forms.ColumnHeader displayname;
        private System.Windows.Forms.ImageList imageList1;
    }
}

