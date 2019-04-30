namespace SocketDemo
{
    partial class FrmTCPClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_FilePath = new System.Windows.Forms.TextBox();
            this.btn_SelectFile = new System.Windows.Forms.Button();
            this.btn_Send = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtb_ClientSend = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_Info = new System.Windows.Forms.RichTextBox();
            this.btn_DisConnect = new System.Windows.Forms.Button();
            this.btn_ConnectServer = new System.Windows.Forms.Button();
            this.txt_ServerPort = new System.Windows.Forms.TextBox();
            this.txt_ServerIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Location = new System.Drawing.Point(136, 460);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.ReadOnly = true;
            this.txt_FilePath.Size = new System.Drawing.Size(163, 25);
            this.txt_FilePath.TabIndex = 25;
            // 
            // btn_SelectFile
            // 
            this.btn_SelectFile.Location = new System.Drawing.Point(20, 450);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Size = new System.Drawing.Size(110, 40);
            this.btn_SelectFile.TabIndex = 7;
            this.btn_SelectFile.Text = "选择文件";
            this.btn_SelectFile.UseVisualStyleBackColor = true;
            this.btn_SelectFile.Click += new System.EventHandler(this.Btn_SelectFile_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(307, 450);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(110, 40);
            this.btn_Send.TabIndex = 6;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtb_ClientSend);
            this.groupBox2.Location = new System.Drawing.Point(20, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 149);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "客户端发送";
            // 
            // rtb_ClientSend
            // 
            this.rtb_ClientSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_ClientSend.Location = new System.Drawing.Point(3, 21);
            this.rtb_ClientSend.Name = "rtb_ClientSend";
            this.rtb_ClientSend.Size = new System.Drawing.Size(391, 125);
            this.rtb_ClientSend.TabIndex = 0;
            this.rtb_ClientSend.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_Info);
            this.groupBox1.Location = new System.Drawing.Point(23, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 194);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // rtb_Info
            // 
            this.rtb_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Info.Location = new System.Drawing.Point(3, 21);
            this.rtb_Info.Name = "rtb_Info";
            this.rtb_Info.ReadOnly = true;
            this.rtb_Info.Size = new System.Drawing.Size(391, 170);
            this.rtb_Info.TabIndex = 0;
            this.rtb_Info.Text = "";
            // 
            // btn_DisConnect
            // 
            this.btn_DisConnect.Location = new System.Drawing.Point(307, 52);
            this.btn_DisConnect.Name = "btn_DisConnect";
            this.btn_DisConnect.Size = new System.Drawing.Size(110, 40);
            this.btn_DisConnect.TabIndex = 5;
            this.btn_DisConnect.Text = "断开服务";
            this.btn_DisConnect.UseVisualStyleBackColor = true;
            this.btn_DisConnect.Click += new System.EventHandler(this.Btn_DisConnect_Click);
            // 
            // btn_ConnectServer
            // 
            this.btn_ConnectServer.Location = new System.Drawing.Point(307, 9);
            this.btn_ConnectServer.Name = "btn_ConnectServer";
            this.btn_ConnectServer.Size = new System.Drawing.Size(110, 40);
            this.btn_ConnectServer.TabIndex = 4;
            this.btn_ConnectServer.Text = "连接服务";
            this.btn_ConnectServer.UseVisualStyleBackColor = true;
            this.btn_ConnectServer.Click += new System.EventHandler(this.Btn_ConnectServer_Click);
            // 
            // txt_ServerPort
            // 
            this.txt_ServerPort.Location = new System.Drawing.Point(113, 62);
            this.txt_ServerPort.Name = "txt_ServerPort";
            this.txt_ServerPort.Size = new System.Drawing.Size(163, 25);
            this.txt_ServerPort.TabIndex = 16;
            this.txt_ServerPort.Text = "8080";
            // 
            // txt_ServerIP
            // 
            this.txt_ServerIP.Location = new System.Drawing.Point(113, 19);
            this.txt_ServerIP.Name = "txt_ServerIP";
            this.txt_ServerIP.Size = new System.Drawing.Size(163, 25);
            this.txt_ServerIP.TabIndex = 15;
            this.txt_ServerIP.Text = "192.168.0.54";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "服务器Port：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "服务器IP：";
            // 
            // FrmTCPClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 495);
            this.Controls.Add(this.txt_FilePath);
            this.Controls.Add(this.btn_SelectFile);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_DisConnect);
            this.Controls.Add(this.btn_ConnectServer);
            this.Controls.Add(this.txt_ServerPort);
            this.Controls.Add(this.txt_ServerIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmTCPClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTCPClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTCPClient_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_FilePath;
        private System.Windows.Forms.Button btn_SelectFile;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtb_ClientSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtb_Info;
        private System.Windows.Forms.Button btn_DisConnect;
        private System.Windows.Forms.Button btn_ConnectServer;
        private System.Windows.Forms.TextBox txt_ServerPort;
        private System.Windows.Forms.TextBox txt_ServerIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}