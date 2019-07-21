namespace ArcSoftFaceIDTest
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
            this.btnAnalysisFace = new System.Windows.Forms.Button();
            this.btnSearchFace = new System.Windows.Forms.Button();
            this.btnDetectFace = new System.Windows.Forms.Button();
            this.btnSaveFace = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pb_CurrentFace = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CurrentFace)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAnalysisFace);
            this.panel1.Controls.Add(this.btnSearchFace);
            this.panel1.Controls.Add(this.btnDetectFace);
            this.panel1.Controls.Add(this.btnSaveFace);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1141, 76);
            this.panel1.TabIndex = 0;
            // 
            // btnAnalysisFace
            // 
            this.btnAnalysisFace.Location = new System.Drawing.Point(255, 12);
            this.btnAnalysisFace.Name = "btnAnalysisFace";
            this.btnAnalysisFace.Size = new System.Drawing.Size(120, 50);
            this.btnAnalysisFace.TabIndex = 3;
            this.btnAnalysisFace.Text = "解析人脸";
            this.btnAnalysisFace.UseVisualStyleBackColor = true;
            this.btnAnalysisFace.Click += new System.EventHandler(this.btnAnalysisFace_Click);
            // 
            // btnSearchFace
            // 
            this.btnSearchFace.Location = new System.Drawing.Point(381, 12);
            this.btnSearchFace.Name = "btnSearchFace";
            this.btnSearchFace.Size = new System.Drawing.Size(120, 50);
            this.btnSearchFace.TabIndex = 2;
            this.btnSearchFace.Text = "搜索人脸";
            this.btnSearchFace.UseVisualStyleBackColor = true;
            this.btnSearchFace.Click += new System.EventHandler(this.btnSearchFace_Click);
            // 
            // btnDetectFace
            // 
            this.btnDetectFace.Location = new System.Drawing.Point(3, 12);
            this.btnDetectFace.Name = "btnDetectFace";
            this.btnDetectFace.Size = new System.Drawing.Size(120, 50);
            this.btnDetectFace.TabIndex = 0;
            this.btnDetectFace.Text = "人脸检测";
            this.btnDetectFace.UseVisualStyleBackColor = true;
            this.btnDetectFace.Click += new System.EventHandler(this.btnDetectFace_Click);
            // 
            // btnSaveFace
            // 
            this.btnSaveFace.Location = new System.Drawing.Point(129, 12);
            this.btnSaveFace.Name = "btnSaveFace";
            this.btnSaveFace.Size = new System.Drawing.Size(120, 50);
            this.btnSaveFace.TabIndex = 1;
            this.btnSaveFace.Text = "保存人脸";
            this.btnSaveFace.UseVisualStyleBackColor = true;
            this.btnSaveFace.Click += new System.EventHandler(this.btnSaveFace_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtbInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 528);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1141, 189);
            this.panel2.TabIndex = 1;
            // 
            // rtbInfo
            // 
            this.rtbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbInfo.Location = new System.Drawing.Point(0, 0);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.ReadOnly = true;
            this.rtbInfo.Size = new System.Drawing.Size(1141, 189);
            this.rtbInfo.TabIndex = 0;
            this.rtbInfo.Text = "";
            this.rtbInfo.TextChanged += new System.EventHandler(this.rtbInfo_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pb_CurrentFace);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(578, 452);
            this.panel3.TabIndex = 2;
            // 
            // pb_CurrentFace
            // 
            this.pb_CurrentFace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_CurrentFace.Location = new System.Drawing.Point(0, 0);
            this.pb_CurrentFace.Name = "pb_CurrentFace";
            this.pb_CurrentFace.Size = new System.Drawing.Size(576, 450);
            this.pb_CurrentFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_CurrentFace.TabIndex = 0;
            this.pb_CurrentFace.TabStop = false;
            this.pb_CurrentFace.Click += new System.EventHandler(this.btnDetectFace_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(578, 76);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(563, 452);
            this.panel4.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 717);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_CurrentFace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.PictureBox pb_CurrentFace;
        private System.Windows.Forms.Button btnDetectFace;
        private System.Windows.Forms.Button btnSaveFace;
        private System.Windows.Forms.Button btnAnalysisFace;
        private System.Windows.Forms.Button btnSearchFace;


    }
}

