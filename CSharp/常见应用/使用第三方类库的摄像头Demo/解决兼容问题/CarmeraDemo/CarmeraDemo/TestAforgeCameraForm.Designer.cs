namespace CarmeraDemo
{
    partial class TestAforgeCameraForm
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
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboResolutionList = new System.Windows.Forms.ComboBox();
            this.lblResolution = new System.Windows.Forms.Label();
            this.cboCameraTypeList = new System.Windows.Forms.ComboBox();
            this.lblCaremaType = new System.Windows.Forms.Label();
            this.btnCloseCarema = new System.Windows.Forms.Button();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.btnStartCamera = new System.Windows.Forms.Button();
            this.btnTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.Location = new System.Drawing.Point(19, 12);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(628, 445);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.Text = "videoSourcePlayer1";
            this.videoSourcePlayer.VideoSource = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(680, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(634, 445);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // cboResolutionList
            // 
            this.cboResolutionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResolutionList.FormattingEnabled = true;
            this.cboResolutionList.Location = new System.Drawing.Point(404, 478);
            this.cboResolutionList.Margin = new System.Windows.Forms.Padding(4);
            this.cboResolutionList.Name = "cboResolutionList";
            this.cboResolutionList.Size = new System.Drawing.Size(160, 23);
            this.cboResolutionList.TabIndex = 11;
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(308, 483);
            this.lblResolution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(97, 15);
            this.lblResolution.TabIndex = 9;
            this.lblResolution.Text = "可用分辨率：";
            // 
            // cboCameraTypeList
            // 
            this.cboCameraTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCameraTypeList.FormattingEnabled = true;
            this.cboCameraTypeList.Location = new System.Drawing.Point(124, 478);
            this.cboCameraTypeList.Margin = new System.Windows.Forms.Padding(4);
            this.cboCameraTypeList.Name = "cboCameraTypeList";
            this.cboCameraTypeList.Size = new System.Drawing.Size(160, 23);
            this.cboCameraTypeList.TabIndex = 12;
            // 
            // lblCaremaType
            // 
            this.lblCaremaType.AutoSize = true;
            this.lblCaremaType.Location = new System.Drawing.Point(16, 483);
            this.lblCaremaType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCaremaType.Name = "lblCaremaType";
            this.lblCaremaType.Size = new System.Drawing.Size(97, 15);
            this.lblCaremaType.TabIndex = 10;
            this.lblCaremaType.Text = "摄像头选择：";
            // 
            // btnCloseCarema
            // 
            this.btnCloseCarema.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseCarema.Location = new System.Drawing.Point(1157, 467);
            this.btnCloseCarema.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseCarema.Name = "btnCloseCarema";
            this.btnCloseCarema.Size = new System.Drawing.Size(157, 49);
            this.btnCloseCarema.TabIndex = 5;
            this.btnCloseCarema.Text = "关闭摄像头";
            this.btnCloseCarema.UseVisualStyleBackColor = true;
            this.btnCloseCarema.Click += new System.EventHandler(this.btnCloseCarema_Click);
            // 
            // btnClearImage
            // 
            this.btnClearImage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearImage.Location = new System.Drawing.Point(968, 467);
            this.btnClearImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(157, 49);
            this.btnClearImage.TabIndex = 6;
            this.btnClearImage.Text = "清除图片";
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // btnStartCamera
            // 
            this.btnStartCamera.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartCamera.Location = new System.Drawing.Point(589, 464);
            this.btnStartCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartCamera.Name = "btnStartCamera";
            this.btnStartCamera.Size = new System.Drawing.Size(157, 54);
            this.btnStartCamera.TabIndex = 7;
            this.btnStartCamera.Text = "  开启摄像头";
            this.btnStartCamera.UseVisualStyleBackColor = true;
            this.btnStartCamera.Click += new System.EventHandler(this.btn_StartCamera_Click);
            // 
            // btnTask
            // 
            this.btnTask.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTask.Location = new System.Drawing.Point(779, 464);
            this.btnTask.Margin = new System.Windows.Forms.Padding(4);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(157, 52);
            this.btnTask.TabIndex = 8;
            this.btnTask.Text = "  拍    照";
            this.btnTask.UseVisualStyleBackColor = true;
            this.btnTask.Click += new System.EventHandler(this.btnTask_Click);
            // 
            // TestAforgeCameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 542);
            this.Controls.Add(this.cboResolutionList);
            this.Controls.Add(this.lblResolution);
            this.Controls.Add(this.cboCameraTypeList);
            this.Controls.Add(this.lblCaremaType);
            this.Controls.Add(this.btnCloseCarema);
            this.Controls.Add(this.btnClearImage);
            this.Controls.Add(this.btnStartCamera);
            this.Controls.Add(this.btnTask);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.videoSourcePlayer);
            this.Name = "TestAforgeCameraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestAforgeCameraForm";
            this.Load += new System.EventHandler(this.TestAforgeCameraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cboResolutionList;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.ComboBox cboCameraTypeList;
        private System.Windows.Forms.Label lblCaremaType;
        private System.Windows.Forms.Button btnCloseCarema;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Button btnStartCamera;
        private System.Windows.Forms.Button btnTask;
    }
}