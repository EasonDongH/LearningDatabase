namespace VoiceBoxDemo
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbRecord = new System.Windows.Forms.RichTextBox();
            this.panelCompound = new System.Windows.Forms.Panel();
            this.btnLoopTest = new System.Windows.Forms.Button();
            this.btnFillText = new System.Windows.Forms.Button();
            this.btnStopAll = new System.Windows.Forms.Button();
            this.btnStopCurrent = new System.Windows.Forms.Button();
            this.btnRestoreCompound = new System.Windows.Forms.Button();
            this.btnPauseCompound = new System.Windows.Forms.Button();
            this.btn4KText = new System.Windows.Forms.Button();
            this.btnEmergencyIntercut = new System.Windows.Forms.Button();
            this.btnCommonIntercut = new System.Windows.Forms.Button();
            this.btnQueueCompoud = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTestText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.btnRefreshPort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOperatePort = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.looptimer = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelCompound.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(12, 7, 12, 14);
            this.panelMain.Size = new System.Drawing.Size(556, 498);
            this.panelMain.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panelCompound);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(12, 136);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(532, 348);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.rtbRecord);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 141);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(532, 207);
            this.panel5.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "播放记录：";
            // 
            // rtbRecord
            // 
            this.rtbRecord.Location = new System.Drawing.Point(3, 23);
            this.rtbRecord.Name = "rtbRecord";
            this.rtbRecord.ReadOnly = true;
            this.rtbRecord.Size = new System.Drawing.Size(526, 181);
            this.rtbRecord.TabIndex = 0;
            this.rtbRecord.Text = "";
            this.rtbRecord.TextChanged += new System.EventHandler(this.rtbRecord_TextChanged);
            // 
            // panelCompound
            // 
            this.panelCompound.Controls.Add(this.btnLoopTest);
            this.panelCompound.Controls.Add(this.btnFillText);
            this.panelCompound.Controls.Add(this.btnStopAll);
            this.panelCompound.Controls.Add(this.btnStopCurrent);
            this.panelCompound.Controls.Add(this.btnRestoreCompound);
            this.panelCompound.Controls.Add(this.btnPauseCompound);
            this.panelCompound.Controls.Add(this.btn4KText);
            this.panelCompound.Controls.Add(this.btnEmergencyIntercut);
            this.panelCompound.Controls.Add(this.btnCommonIntercut);
            this.panelCompound.Controls.Add(this.btnQueueCompoud);
            this.panelCompound.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCompound.Location = new System.Drawing.Point(0, 66);
            this.panelCompound.Name = "panelCompound";
            this.panelCompound.Size = new System.Drawing.Size(532, 75);
            this.panelCompound.TabIndex = 1;
            // 
            // btnLoopTest
            // 
            this.btnLoopTest.Location = new System.Drawing.Point(155, 38);
            this.btnLoopTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoopTest.Name = "btnLoopTest";
            this.btnLoopTest.Size = new System.Drawing.Size(70, 30);
            this.btnLoopTest.TabIndex = 16;
            this.btnLoopTest.Text = "循环测试";
            this.btnLoopTest.UseVisualStyleBackColor = true;
            this.btnLoopTest.Click += new System.EventHandler(this.btnLoopTest_Click);
            // 
            // btnFillText
            // 
            this.btnFillText.Location = new System.Drawing.Point(3, 38);
            this.btnFillText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFillText.Name = "btnFillText";
            this.btnFillText.Size = new System.Drawing.Size(70, 30);
            this.btnFillText.TabIndex = 15;
            this.btnFillText.Text = "填充文本";
            this.btnFillText.UseVisualStyleBackColor = true;
            this.btnFillText.Click += new System.EventHandler(this.btnFillText_Click);
            // 
            // btnStopAll
            // 
            this.btnStopAll.Location = new System.Drawing.Point(459, 4);
            this.btnStopAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.Size = new System.Drawing.Size(70, 30);
            this.btnStopAll.TabIndex = 14;
            this.btnStopAll.Text = "取消所有";
            this.btnStopAll.UseVisualStyleBackColor = true;
            this.btnStopAll.Click += new System.EventHandler(this.btnStopAll_Click);
            // 
            // btnStopCurrent
            // 
            this.btnStopCurrent.Location = new System.Drawing.Point(383, 4);
            this.btnStopCurrent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStopCurrent.Name = "btnStopCurrent";
            this.btnStopCurrent.Size = new System.Drawing.Size(70, 30);
            this.btnStopCurrent.TabIndex = 13;
            this.btnStopCurrent.Text = "取消当前";
            this.btnStopCurrent.UseVisualStyleBackColor = true;
            this.btnStopCurrent.Click += new System.EventHandler(this.btnStopCurrent_Click);
            // 
            // btnRestoreCompound
            // 
            this.btnRestoreCompound.Location = new System.Drawing.Point(307, 4);
            this.btnRestoreCompound.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRestoreCompound.Name = "btnRestoreCompound";
            this.btnRestoreCompound.Size = new System.Drawing.Size(70, 30);
            this.btnRestoreCompound.TabIndex = 12;
            this.btnRestoreCompound.Text = "恢复暂停";
            this.btnRestoreCompound.UseVisualStyleBackColor = true;
            this.btnRestoreCompound.Click += new System.EventHandler(this.btnRestoreCompound_Click);
            // 
            // btnPauseCompound
            // 
            this.btnPauseCompound.Location = new System.Drawing.Point(231, 4);
            this.btnPauseCompound.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPauseCompound.Name = "btnPauseCompound";
            this.btnPauseCompound.Size = new System.Drawing.Size(70, 30);
            this.btnPauseCompound.TabIndex = 11;
            this.btnPauseCompound.Text = "暂停当前";
            this.btnPauseCompound.UseVisualStyleBackColor = true;
            this.btnPauseCompound.Click += new System.EventHandler(this.btnPauseCompound_Click);
            // 
            // btn4KText
            // 
            this.btn4KText.Location = new System.Drawing.Point(79, 38);
            this.btn4KText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn4KText.Name = "btn4KText";
            this.btn4KText.Size = new System.Drawing.Size(70, 30);
            this.btn4KText.TabIndex = 10;
            this.btn4KText.Text = "超4K文本";
            this.btn4KText.UseVisualStyleBackColor = true;
            this.btn4KText.Click += new System.EventHandler(this.btn4KText_Click);
            // 
            // btnEmergencyIntercut
            // 
            this.btnEmergencyIntercut.Location = new System.Drawing.Point(155, 4);
            this.btnEmergencyIntercut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmergencyIntercut.Name = "btnEmergencyIntercut";
            this.btnEmergencyIntercut.Size = new System.Drawing.Size(70, 30);
            this.btnEmergencyIntercut.TabIndex = 9;
            this.btnEmergencyIntercut.Text = "紧急插播";
            this.btnEmergencyIntercut.UseVisualStyleBackColor = true;
            this.btnEmergencyIntercut.Click += new System.EventHandler(this.btnEmergencyIntercut_Click);
            this.btnEmergencyIntercut.MouseHover += new System.EventHandler(this.btnEmergencyIntercut_MouseHover);
            // 
            // btnCommonIntercut
            // 
            this.btnCommonIntercut.Location = new System.Drawing.Point(79, 4);
            this.btnCommonIntercut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCommonIntercut.Name = "btnCommonIntercut";
            this.btnCommonIntercut.Size = new System.Drawing.Size(70, 30);
            this.btnCommonIntercut.TabIndex = 8;
            this.btnCommonIntercut.Text = "普通插播";
            this.btnCommonIntercut.UseVisualStyleBackColor = true;
            this.btnCommonIntercut.Click += new System.EventHandler(this.btnCommonIntercut_Click);
            this.btnCommonIntercut.MouseHover += new System.EventHandler(this.btnCommonIntercut_MouseHover);
            // 
            // btnQueueCompoud
            // 
            this.btnQueueCompoud.Location = new System.Drawing.Point(3, 4);
            this.btnQueueCompoud.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQueueCompoud.Name = "btnQueueCompoud";
            this.btnQueueCompoud.Size = new System.Drawing.Size(70, 30);
            this.btnQueueCompoud.TabIndex = 7;
            this.btnQueueCompoud.Text = "排队播放";
            this.btnQueueCompoud.UseVisualStyleBackColor = true;
            this.btnQueueCompoud.Click += new System.EventHandler(this.btnCompoudText_Click);
            this.btnQueueCompoud.MouseHover += new System.EventHandler(this.btnQueueCompoud_MouseHover);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTestText);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(532, 66);
            this.panel3.TabIndex = 0;
            // 
            // txtTestText
            // 
            this.txtTestText.Location = new System.Drawing.Point(3, 24);
            this.txtTestText.Multiline = true;
            this.txtTestText.Name = "txtTestText";
            this.txtTestText.Size = new System.Drawing.Size(526, 39);
            this.txtTestText.TabIndex = 8;
            this.txtTestText.Text = "这是测试文本，长度不是太长";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "测试文本：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 129);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(199, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 120);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "语音盒配置";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSerialPort);
            this.groupBox1.Controls.Add(this.btnRefreshPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOperatePort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbBaudRate);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 122);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口配置";
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(68, 18);
            this.cmbSerialPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(107, 25);
            this.cmbSerialPort.TabIndex = 0;
            // 
            // btnRefreshPort
            // 
            this.btnRefreshPort.Location = new System.Drawing.Point(29, 84);
            this.btnRefreshPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefreshPort.Name = "btnRefreshPort";
            this.btnRefreshPort.Size = new System.Drawing.Size(70, 30);
            this.btnRefreshPort.TabIndex = 6;
            this.btnRefreshPort.Text = "刷新串口";
            this.btnRefreshPort.UseVisualStyleBackColor = true;
            this.btnRefreshPort.Click += new System.EventHandler(this.btnRefreshPort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口：";
            // 
            // btnOperatePort
            // 
            this.btnOperatePort.Location = new System.Drawing.Point(105, 84);
            this.btnOperatePort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOperatePort.Name = "btnOperatePort";
            this.btnOperatePort.Size = new System.Drawing.Size(70, 30);
            this.btnOperatePort.TabIndex = 5;
            this.btnOperatePort.Text = "打开串口";
            this.btnOperatePort.UseVisualStyleBackColor = true;
            this.btnOperatePort.Click += new System.EventHandler(this.btnOperatePort_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "波特率：";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "57600",
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(68, 51);
            this.cmbBaudRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(107, 25);
            this.cmbBaudRate.TabIndex = 2;
            // 
            // looptimer
            // 
            this.looptimer.Interval = 2000;
            this.looptimer.Tick += new System.EventHandler(this.looptimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(556, 498);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "讯飞语音盒Demo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelCompound.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSerialPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefreshPort;
        private System.Windows.Forms.Button btnOperatePort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTestText;
        private System.Windows.Forms.Panel panelCompound;
        private System.Windows.Forms.Button btnQueueCompoud;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbRecord;
        private System.Windows.Forms.Button btnCommonIntercut;
        private System.Windows.Forms.Button btnEmergencyIntercut;
        private System.Windows.Forms.Button btn4KText;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Button btnStopCurrent;
        private System.Windows.Forms.Button btnRestoreCompound;
        private System.Windows.Forms.Button btnPauseCompound;
        private System.Windows.Forms.Button btnStopAll;
        private System.Windows.Forms.Button btnFillText;
        private System.Windows.Forms.Button btnLoopTest;
        private System.Windows.Forms.Timer looptimer;
    }
}

