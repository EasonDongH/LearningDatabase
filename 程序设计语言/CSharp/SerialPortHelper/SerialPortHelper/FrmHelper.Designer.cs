namespace SerialPortHelperDemo
{
    partial class FrmHelper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHelper));
            this.btnOperatePort = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.ckb16Receive = new System.Windows.Forms.CheckBox();
            this.ckb16Send = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReceiver = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboStopBit = new System.Windows.Forms.ComboBox();
            this.cboDataBit = new System.Windows.Forms.ComboBox();
            this.cboCheckBit = new System.Windows.Forms.ComboBox();
            this.cboBaudRrate = new System.Windows.Forms.ComboBox();
            this.cboCOMList = new System.Windows.Forms.ComboBox();
            this.lblStatusShow = new System.Windows.Forms.Label();
            this.lblSerialPortStatus = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOperatePort
            // 
            this.btnOperatePort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOperatePort.ImageIndex = 1;
            this.btnOperatePort.ImageList = this.imageList;
            this.btnOperatePort.Location = new System.Drawing.Point(151, 323);
            this.btnOperatePort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOperatePort.Name = "btnOperatePort";
            this.btnOperatePort.Size = new System.Drawing.Size(115, 40);
            this.btnOperatePort.TabIndex = 53;
            this.btnOperatePort.Text = "打开端口";
            this.btnOperatePort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOperatePort.UseVisualStyleBackColor = true;
            this.btnOperatePort.Click += new System.EventHandler(this.btnOperatePort_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "lklLoginExit.ico");
            this.imageList.Images.SetKeyName(1, "open.ico");
            // 
            // ckb16Receive
            // 
            this.ckb16Receive.AutoSize = true;
            this.ckb16Receive.Location = new System.Drawing.Point(624, 347);
            this.ckb16Receive.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckb16Receive.Name = "ckb16Receive";
            this.ckb16Receive.Size = new System.Drawing.Size(254, 19);
            this.ckb16Receive.TabIndex = 42;
            this.ckb16Receive.Text = "十六进制接收【接收后直接转换】";
            this.ckb16Receive.UseVisualStyleBackColor = true;
            // 
            // ckb16Send
            // 
            this.ckb16Send.AutoSize = true;
            this.ckb16Send.Location = new System.Drawing.Point(624, 315);
            this.ckb16Send.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckb16Send.Name = "ckb16Send";
            this.ckb16Send.Size = new System.Drawing.Size(254, 19);
            this.ckb16Send.TabIndex = 41;
            this.ckb16Send.Text = "十六进制发送【发送前需要校验】";
            this.ckb16Send.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(464, 325);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(121, 37);
            this.btnClear.TabIndex = 34;
            this.btnClear.Text = "清空数据 ";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.txtSender);
            this.GroupBox3.Location = new System.Drawing.Point(311, 190);
            this.GroupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupBox3.Size = new System.Drawing.Size(604, 93);
            this.GroupBox3.TabIndex = 31;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "发送数据【可以是中文字符】";
            // 
            // txtSender
            // 
            this.txtSender.Location = new System.Drawing.Point(24, 32);
            this.txtSender.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSender.Multiline = true;
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(560, 42);
            this.txtSender.TabIndex = 55;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtReceiver);
            this.GroupBox2.Location = new System.Drawing.Point(311, 23);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupBox2.Size = new System.Drawing.Size(604, 158);
            this.GroupBox2.TabIndex = 30;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "接收数据";
            // 
            // txtReceiver
            // 
            this.txtReceiver.Location = new System.Drawing.Point(24, 22);
            this.txtReceiver.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtReceiver.Multiline = true;
            this.txtReceiver.Name = "txtReceiver";
            this.txtReceiver.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceiver.Size = new System.Drawing.Size(560, 121);
            this.txtReceiver.TabIndex = 55;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.cboStopBit);
            this.GroupBox1.Controls.Add(this.cboDataBit);
            this.GroupBox1.Controls.Add(this.cboCheckBit);
            this.GroupBox1.Controls.Add(this.cboBaudRrate);
            this.GroupBox1.Controls.Add(this.cboCOMList);
            this.GroupBox1.Location = new System.Drawing.Point(16, 27);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupBox1.Size = new System.Drawing.Size(267, 257);
            this.GroupBox1.TabIndex = 29;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "串口设置";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(40, 205);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(52, 15);
            this.Label5.TabIndex = 14;
            this.Label5.Text = "停止位";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(40, 162);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(52, 15);
            this.Label4.TabIndex = 13;
            this.Label4.Text = "数据位";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(40, 117);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(52, 15);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "校验位";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(40, 77);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(52, 15);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "波特率";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(24, 35);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(67, 15);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "端口选择";
            // 
            // cboStopBit
            // 
            this.cboStopBit.FormattingEnabled = true;
            this.cboStopBit.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cboStopBit.Location = new System.Drawing.Point(117, 202);
            this.cboStopBit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboStopBit.Name = "cboStopBit";
            this.cboStopBit.Size = new System.Drawing.Size(118, 23);
            this.cboStopBit.TabIndex = 5;
            this.cboStopBit.SelectedIndexChanged += new System.EventHandler(this.cboStopBit_SelectedIndexChanged);
            // 
            // cboDataBit
            // 
            this.cboDataBit.FormattingEnabled = true;
            this.cboDataBit.Items.AddRange(new object[] {
            "6",
            "7",
            "8"});
            this.cboDataBit.Location = new System.Drawing.Point(117, 158);
            this.cboDataBit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboDataBit.Name = "cboDataBit";
            this.cboDataBit.Size = new System.Drawing.Size(118, 23);
            this.cboDataBit.TabIndex = 4;
            this.cboDataBit.SelectedIndexChanged += new System.EventHandler(this.cboDataBit_SelectedIndexChanged);
            // 
            // cboCheckBit
            // 
            this.cboCheckBit.FormattingEnabled = true;
            this.cboCheckBit.Items.AddRange(new object[] {
            "NONE",
            "0DD",
            "EVEN"});
            this.cboCheckBit.Location = new System.Drawing.Point(117, 117);
            this.cboCheckBit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboCheckBit.Name = "cboCheckBit";
            this.cboCheckBit.Size = new System.Drawing.Size(118, 23);
            this.cboCheckBit.TabIndex = 3;
            this.cboCheckBit.SelectedIndexChanged += new System.EventHandler(this.cboCheckBit_SelectedIndexChanged);
            // 
            // cboBaudRrate
            // 
            this.cboBaudRrate.FormattingEnabled = true;
            this.cboBaudRrate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.cboBaudRrate.Location = new System.Drawing.Point(117, 73);
            this.cboBaudRrate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboBaudRrate.Name = "cboBaudRrate";
            this.cboBaudRrate.Size = new System.Drawing.Size(118, 23);
            this.cboBaudRrate.TabIndex = 2;
            this.cboBaudRrate.SelectedIndexChanged += new System.EventHandler(this.cboBaudRrate_SelectedIndexChanged);
            // 
            // cboCOMList
            // 
            this.cboCOMList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCOMList.FormattingEnabled = true;
            this.cboCOMList.Location = new System.Drawing.Point(117, 32);
            this.cboCOMList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboCOMList.Name = "cboCOMList";
            this.cboCOMList.Size = new System.Drawing.Size(118, 23);
            this.cboCOMList.TabIndex = 1;
            this.cboCOMList.SelectedIndexChanged += new System.EventHandler(this.cboCOMList_SelectedIndexChanged);
            // 
            // lblStatusShow
            // 
            this.lblStatusShow.BackColor = System.Drawing.Color.Red;
            this.lblStatusShow.Location = new System.Drawing.Point(25, 333);
            this.lblStatusShow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusShow.Name = "lblStatusShow";
            this.lblStatusShow.Size = new System.Drawing.Size(23, 22);
            this.lblStatusShow.TabIndex = 54;
            // 
            // lblSerialPortStatus
            // 
            this.lblSerialPortStatus.AutoSize = true;
            this.lblSerialPortStatus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSerialPortStatus.Location = new System.Drawing.Point(56, 337);
            this.lblSerialPortStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSerialPortStatus.Name = "lblSerialPortStatus";
            this.lblSerialPortStatus.Size = new System.Drawing.Size(82, 15);
            this.lblSerialPortStatus.TabIndex = 10;
            this.lblSerialPortStatus.Text = "串口未打开";
            // 
            // btnSend
            // 
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.Location = new System.Drawing.Point(311, 323);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(121, 40);
            this.btnSend.TabIndex = 35;
            this.btnSend.Text = "发送数据 ";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // FrmHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(936, 393);
            this.Controls.Add(this.lblStatusShow);
            this.Controls.Add(this.ckb16Receive);
            this.Controls.Add(this.btnOperatePort);
            this.Controls.Add(this.lblSerialPortStatus);
            this.Controls.Add(this.ckb16Send);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FrmHelper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口调试助手";
            this.Load += new System.EventHandler(this.FrmHelper_Load);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnOperatePort;
        internal System.Windows.Forms.CheckBox ckb16Receive;
        internal System.Windows.Forms.CheckBox ckb16Send;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label lblSerialPortStatus;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cboStopBit;
        internal System.Windows.Forms.ComboBox cboDataBit;
        internal System.Windows.Forms.ComboBox cboCheckBit;
        internal System.Windows.Forms.ComboBox cboBaudRrate;
        internal System.Windows.Forms.ComboBox cboCOMList;
        private System.Windows.Forms.TextBox txtReceiver;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label lblStatusShow;
        internal System.Windows.Forms.Button btnSend;
    }
}

