namespace ArcSoft_Face2._2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pb_MatchedFace = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.panel_Info = new System.Windows.Forms.Panel();
            this.rtb_Info = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_MatchFace = new System.Windows.Forms.Button();
            this.btn_EnterFace = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_Main.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_MatchedFace)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel_Info.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(13, 6, 13, 12);
            this.panel1.Size = new System.Drawing.Size(1358, 621);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel_Main);
            this.panel2.Controls.Add(this.panel_Info);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(13, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1332, 603);
            this.panel2.TabIndex = 0;
            // 
            // panel_Main
            // 
            this.panel_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Main.Controls.Add(this.groupBox2);
            this.panel_Main.Controls.Add(this.groupBox1);
            this.panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Main.Location = new System.Drawing.Point(153, 0);
            this.panel_Main.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(1179, 478);
            this.panel_Main.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pb_MatchedFace);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(599, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(578, 476);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据库人脸";
            // 
            // pb_MatchedFace
            // 
            this.pb_MatchedFace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_MatchedFace.Location = new System.Drawing.Point(4, 22);
            this.pb_MatchedFace.Margin = new System.Windows.Forms.Padding(4);
            this.pb_MatchedFace.Name = "pb_MatchedFace";
            this.pb_MatchedFace.Size = new System.Drawing.Size(570, 450);
            this.pb_MatchedFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_MatchedFace.TabIndex = 0;
            this.pb_MatchedFace.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.videoSourcePlayer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(599, 476);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入人脸";
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoSourcePlayer.Location = new System.Drawing.Point(4, 22);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(591, 450);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.Text = "videoSourcePlayer1";
            this.videoSourcePlayer.VideoSource = null;
            // 
            // panel_Info
            // 
            this.panel_Info.Controls.Add(this.rtb_Info);
            this.panel_Info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Info.Location = new System.Drawing.Point(153, 478);
            this.panel_Info.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(1179, 125);
            this.panel_Info.TabIndex = 1;
            // 
            // rtb_Info
            // 
            this.rtb_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Info.Location = new System.Drawing.Point(0, 0);
            this.rtb_Info.Margin = new System.Windows.Forms.Padding(4);
            this.rtb_Info.Name = "rtb_Info";
            this.rtb_Info.ReadOnly = true;
            this.rtb_Info.Size = new System.Drawing.Size(1179, 125);
            this.rtb_Info.TabIndex = 0;
            this.rtb_Info.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_MatchFace);
            this.panel3.Controls.Add(this.btn_EnterFace);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(153, 603);
            this.panel3.TabIndex = 0;
            // 
            // btn_MatchFace
            // 
            this.btn_MatchFace.Location = new System.Drawing.Point(17, 59);
            this.btn_MatchFace.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MatchFace.Name = "btn_MatchFace";
            this.btn_MatchFace.Size = new System.Drawing.Size(117, 42);
            this.btn_MatchFace.TabIndex = 1;
            this.btn_MatchFace.Text = "匹配";
            this.btn_MatchFace.UseVisualStyleBackColor = true;
            // 
            // btn_EnterFace
            // 
            this.btn_EnterFace.Location = new System.Drawing.Point(17, 9);
            this.btn_EnterFace.Margin = new System.Windows.Forms.Padding(4);
            this.btn_EnterFace.Name = "btn_EnterFace";
            this.btn_EnterFace.Size = new System.Drawing.Size(117, 42);
            this.btn_EnterFace.TabIndex = 0;
            this.btn_EnterFace.Text = "录入";
            this.btn_EnterFace.UseVisualStyleBackColor = true;
            this.btn_EnterFace.Click += new System.EventHandler(this.btn_EnterFace_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 621);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel_Main.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_MatchedFace)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel_Info.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_EnterFace;
        private System.Windows.Forms.Button btn_MatchFace;
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.Panel panel_Info;
        private System.Windows.Forms.RichTextBox rtb_Info;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pb_MatchedFace;
        private System.Windows.Forms.GroupBox groupBox1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
    }
}

