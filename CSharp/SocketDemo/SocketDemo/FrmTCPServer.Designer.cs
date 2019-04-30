namespace SocketDemo
{
    partial class FrmTCPServer
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ServerIP = new System.Windows.Forms.TextBox();
            this.txt_ServerPort = new System.Windows.Forms.TextBox();
            this.btn_StartServer = new System.Windows.Forms.Button();
            this.btn_StopServer = new System.Windows.Forms.Button();
            this.lb_OnlineClientList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_Info = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtb_ServerSend = new System.Windows.Forms.RichTextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_SelectFile = new System.Windows.Forms.Button();
            this.txt_FilePath = new System.Windows.Forms.TextBox();
            this.btnOpenClient = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "服务器Port：";
            // 
            // txt_ServerIP
            // 
            this.txt_ServerIP.Location = new System.Drawing.Point(108, 16);
            this.txt_ServerIP.Name = "txt_ServerIP";
            this.txt_ServerIP.Size = new System.Drawing.Size(163, 25);
            this.txt_ServerIP.TabIndex = 2;
            this.txt_ServerIP.Text = "192.168.0.54";
            // 
            // txt_ServerPort
            // 
            this.txt_ServerPort.Location = new System.Drawing.Point(108, 59);
            this.txt_ServerPort.Name = "txt_ServerPort";
            this.txt_ServerPort.Size = new System.Drawing.Size(163, 25);
            this.txt_ServerPort.TabIndex = 3;
            this.txt_ServerPort.Text = "8080";
            // 
            // btn_StartServer
            // 
            this.btn_StartServer.Location = new System.Drawing.Point(15, 117);
            this.btn_StartServer.Name = "btn_StartServer";
            this.btn_StartServer.Size = new System.Drawing.Size(110, 40);
            this.btn_StartServer.TabIndex = 4;
            this.btn_StartServer.Text = "启动服务";
            this.btn_StartServer.UseVisualStyleBackColor = true;
            this.btn_StartServer.Click += new System.EventHandler(this.Btn_StartServer_Click);
            // 
            // btn_StopServer
            // 
            this.btn_StopServer.Location = new System.Drawing.Point(161, 117);
            this.btn_StopServer.Name = "btn_StopServer";
            this.btn_StopServer.Size = new System.Drawing.Size(110, 40);
            this.btn_StopServer.TabIndex = 5;
            this.btn_StopServer.Text = "关闭服务";
            this.btn_StopServer.UseVisualStyleBackColor = true;
            this.btn_StopServer.Click += new System.EventHandler(this.Btn_StopServer_Click);
            // 
            // lb_OnlineClientList
            // 
            this.lb_OnlineClientList.FormattingEnabled = true;
            this.lb_OnlineClientList.ItemHeight = 15;
            this.lb_OnlineClientList.Location = new System.Drawing.Point(15, 202);
            this.lb_OnlineClientList.Name = "lb_OnlineClientList";
            this.lb_OnlineClientList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_OnlineClientList.Size = new System.Drawing.Size(256, 274);
            this.lb_OnlineClientList.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "客户端连接列表：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_Info);
            this.groupBox1.Location = new System.Drawing.Point(292, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 334);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // rtb_Info
            // 
            this.rtb_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Info.Location = new System.Drawing.Point(3, 21);
            this.rtb_Info.Name = "rtb_Info";
            this.rtb_Info.ReadOnly = true;
            this.rtb_Info.Size = new System.Drawing.Size(391, 310);
            this.rtb_Info.TabIndex = 0;
            this.rtb_Info.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtb_ServerSend);
            this.groupBox2.Location = new System.Drawing.Point(292, 347);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 129);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务器发送";
            // 
            // rtb_ServerSend
            // 
            this.rtb_ServerSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_ServerSend.Location = new System.Drawing.Point(3, 21);
            this.rtb_ServerSend.Name = "rtb_ServerSend";
            this.rtb_ServerSend.Size = new System.Drawing.Size(391, 105);
            this.rtb_ServerSend.TabIndex = 0;
            this.rtb_ServerSend.Text = "";
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(579, 483);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(110, 40);
            this.btn_Send.TabIndex = 10;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // btn_SelectFile
            // 
            this.btn_SelectFile.Location = new System.Drawing.Point(161, 483);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Size = new System.Drawing.Size(110, 40);
            this.btn_SelectFile.TabIndex = 11;
            this.btn_SelectFile.Text = "选择文件";
            this.btn_SelectFile.UseVisualStyleBackColor = true;
            this.btn_SelectFile.Click += new System.EventHandler(this.Btn_SelectFile_Click);
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Location = new System.Drawing.Point(292, 493);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.ReadOnly = true;
            this.txt_FilePath.Size = new System.Drawing.Size(279, 25);
            this.txt_FilePath.TabIndex = 12;
            // 
            // btnOpenClient
            // 
            this.btnOpenClient.Location = new System.Drawing.Point(15, 483);
            this.btnOpenClient.Name = "btnOpenClient";
            this.btnOpenClient.Size = new System.Drawing.Size(110, 40);
            this.btnOpenClient.TabIndex = 14;
            this.btnOpenClient.Text = "打开客户端";
            this.btnOpenClient.UseVisualStyleBackColor = true;
            this.btnOpenClient.Click += new System.EventHandler(this.BtnOpenClient_Click);
            // 
            // FrmTCPServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 535);
            this.Controls.Add(this.btnOpenClient);
            this.Controls.Add(this.txt_FilePath);
            this.Controls.Add(this.btn_SelectFile);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_OnlineClientList);
            this.Controls.Add(this.btn_StopServer);
            this.Controls.Add(this.btn_StartServer);
            this.Controls.Add(this.txt_ServerPort);
            this.Controls.Add(this.txt_ServerIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmTCPServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTCPServer_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ServerIP;
        private System.Windows.Forms.TextBox txt_ServerPort;
        private System.Windows.Forms.Button btn_StartServer;
        private System.Windows.Forms.Button btn_StopServer;
        private System.Windows.Forms.ListBox lb_OnlineClientList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtb_Info;
        private System.Windows.Forms.RichTextBox rtb_ServerSend;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_SelectFile;
        private System.Windows.Forms.TextBox txt_FilePath;
        private System.Windows.Forms.Button btnOpenClient;
    }
}

