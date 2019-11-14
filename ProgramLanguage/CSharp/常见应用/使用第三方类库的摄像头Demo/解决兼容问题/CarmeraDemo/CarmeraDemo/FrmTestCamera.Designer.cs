namespace CarmeraDemo
{
    partial class FrmTestCamera
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
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.cameraControl = new Camera_NET.CameraControl();
            this.btnTask = new System.Windows.Forms.Button();
            this.lblCaremaType = new System.Windows.Forms.Label();
            this.cboCameraTypeList = new System.Windows.Forms.ComboBox();
            this.lblResolution = new System.Windows.Forms.Label();
            this.cboResolutionList = new System.Windows.Forms.ComboBox();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.btnStartTask = new System.Windows.Forms.Button();
            this.btnCloseCarema = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(495, 21);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(491, 359);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            // 
            // cameraControl
            // 
            this.cameraControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cameraControl.DirectShowLogFilepath = "";
            this.cameraControl.Location = new System.Drawing.Point(12, 21);
            this.cameraControl.Name = "cameraControl";
            this.cameraControl.Size = new System.Drawing.Size(477, 359);
            this.cameraControl.TabIndex = 0;
            // 
            // btnTask
            // 
            this.btnTask.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTask.Location = new System.Drawing.Point(584, 394);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(118, 42);
            this.btnTask.TabIndex = 1;
            this.btnTask.Text = "  拍    照";
            this.btnTask.UseVisualStyleBackColor = true;
            this.btnTask.Click += new System.EventHandler(this.btnTask_Click);
            // 
            // lblCaremaType
            // 
            this.lblCaremaType.AutoSize = true;
            this.lblCaremaType.Location = new System.Drawing.Point(12, 409);
            this.lblCaremaType.Name = "lblCaremaType";
            this.lblCaremaType.Size = new System.Drawing.Size(77, 12);
            this.lblCaremaType.TabIndex = 2;
            this.lblCaremaType.Text = "摄像头选择：";
            // 
            // cboCameraTypeList
            // 
            this.cboCameraTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCameraTypeList.FormattingEnabled = true;
            this.cboCameraTypeList.Location = new System.Drawing.Point(93, 405);
            this.cboCameraTypeList.Name = "cboCameraTypeList";
            this.cboCameraTypeList.Size = new System.Drawing.Size(121, 20);
            this.cboCameraTypeList.TabIndex = 3;
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(231, 409);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(77, 12);
            this.lblResolution.TabIndex = 2;
            this.lblResolution.Text = "可用分辨率：";
            // 
            // cboResolutionList
            // 
            this.cboResolutionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResolutionList.FormattingEnabled = true;
            this.cboResolutionList.Location = new System.Drawing.Point(303, 405);
            this.cboResolutionList.Name = "cboResolutionList";
            this.cboResolutionList.Size = new System.Drawing.Size(121, 20);
            this.cboResolutionList.TabIndex = 3;
            this.cboResolutionList.SelectedIndexChanged += new System.EventHandler(this.comboBoxResolutionList_SelectedIndexChanged);
            // 
            // btnClearImage
            // 
            this.btnClearImage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearImage.Location = new System.Drawing.Point(726, 396);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(118, 39);
            this.btnClearImage.TabIndex = 1;
            this.btnClearImage.Text = "清除图片";
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // btnStartTask
            // 
            this.btnStartTask.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartTask.Location = new System.Drawing.Point(442, 394);
            this.btnStartTask.Name = "btnStartTask";
            this.btnStartTask.Size = new System.Drawing.Size(118, 43);
            this.btnStartTask.TabIndex = 1;
            this.btnStartTask.Text = "  开启摄像头";
            this.btnStartTask.UseVisualStyleBackColor = true;
            this.btnStartTask.Click += new System.EventHandler(this.btnStartTask_Click);
            // 
            // btnCloseCarema
            // 
            this.btnCloseCarema.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseCarema.Location = new System.Drawing.Point(868, 396);
            this.btnCloseCarema.Name = "btnCloseCarema";
            this.btnCloseCarema.Size = new System.Drawing.Size(118, 39);
            this.btnCloseCarema.TabIndex = 1;
            this.btnCloseCarema.Text = "关闭摄像头";
            this.btnCloseCarema.UseVisualStyleBackColor = true;
            this.btnCloseCarema.Click += new System.EventHandler(this.btnCloseCarema_Click);
            // 
            // FrmTestCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 458);
            this.Controls.Add(this.cameraControl);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.cboResolutionList);
            this.Controls.Add(this.lblResolution);
            this.Controls.Add(this.cboCameraTypeList);
            this.Controls.Add(this.lblCaremaType);
            this.Controls.Add(this.btnCloseCarema);
            this.Controls.Add(this.btnClearImage);
            this.Controls.Add(this.btnStartTask);
            this.Controls.Add(this.btnTask);
            this.Name = "FrmTestCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通用摄像头操作类库的使用";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbImage;
        private Camera_NET.CameraControl cameraControl;
        private System.Windows.Forms.Button btnTask;
        private System.Windows.Forms.Label lblCaremaType;
        private System.Windows.Forms.ComboBox cboCameraTypeList;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.ComboBox cboResolutionList;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Button btnStartTask;
        private System.Windows.Forms.Button btnCloseCarema;
    }
}

