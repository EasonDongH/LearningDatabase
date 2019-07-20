namespace ArcSoftFaceIDTest
{
    partial class FaceDetectForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceDetectForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCamera = new System.Windows.Forms.Panel();
            this.panelFace = new System.Windows.Forms.Panel();
            this.panelMultiFace = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbDetectMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageBox = new Emgu.CV.UI.ImageBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelCamera.SuspendLayout();
            this.panelFace.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.panelCamera);
            this.panel1.Controls.Add(this.panelMultiFace);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1119, 665);
            this.panel1.TabIndex = 0;
            // 
            // panelCamera
            // 
            this.panelCamera.Controls.Add(this.panelFace);
            this.panelCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCamera.Location = new System.Drawing.Point(0, 60);
            this.panelCamera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelCamera.Name = "panelCamera";
            this.panelCamera.Size = new System.Drawing.Size(838, 605);
            this.panelCamera.TabIndex = 2;
            // 
            // panelFace
            // 
            this.panelFace.Controls.Add(this.imageBox);
            this.panelFace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFace.Location = new System.Drawing.Point(0, 0);
            this.panelFace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelFace.Name = "panelFace";
            this.panelFace.Size = new System.Drawing.Size(838, 605);
            this.panelFace.TabIndex = 1;
            // 
            // panelMultiFace
            // 
            this.panelMultiFace.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMultiFace.Location = new System.Drawing.Point(838, 60);
            this.panelMultiFace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMultiFace.Name = "panelMultiFace";
            this.panelMultiFace.Size = new System.Drawing.Size(281, 605);
            this.panelMultiFace.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Azure;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.cmbDetectMode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1119, 60);
            this.panel2.TabIndex = 0;
            // 
            // cmbDetectMode
            // 
            this.cmbDetectMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetectMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDetectMode.FormattingEnabled = true;
            this.cmbDetectMode.Items.AddRange(new object[] {
            "图片",
            "视频流"});
            this.cmbDetectMode.Location = new System.Drawing.Point(96, 17);
            this.cmbDetectMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDetectMode.Name = "cmbDetectMode";
            this.cmbDetectMode.Size = new System.Drawing.Size(136, 28);
            this.cmbDetectMode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "检测模式：";
            // 
            // imageBox
            // 
            this.imageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.imageBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imageBox.BackgroundImage")));
            this.imageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox.Location = new System.Drawing.Point(0, 0);
            this.imageBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(838, 605);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox.TabIndex = 16;
            this.imageBox.TabStop = false;
            this.imageBox.Click += new System.EventHandler(this.imageBox_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1028, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(91, 60);
            this.panel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "保存";
            // 
            // FaceDetectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 665);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FaceDetectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人脸检测";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FaceDetectForm_FormClosing);
            this.Load += new System.EventHandler(this.FaceDetectForm_Load);
            this.panel1.ResumeLayout(false);
            this.panelCamera.ResumeLayout(false);
            this.panelFace.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMultiFace;
        private System.Windows.Forms.Panel panelCamera;
        private System.Windows.Forms.Panel panelFace;
        private System.Windows.Forms.ComboBox cmbDetectMode;
        private System.Windows.Forms.Label label2;
        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
    }
}