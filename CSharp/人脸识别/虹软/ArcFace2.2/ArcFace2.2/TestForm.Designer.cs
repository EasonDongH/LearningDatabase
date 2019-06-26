namespace ArcFace2._2
{
    partial class TestForm
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
            this.btn_SelectPicture = new System.Windows.Forms.Button();
            this.pb_Image = new System.Windows.Forms.PictureBox();
            this.btn_SaveFeature = new System.Windows.Forms.Button();
            this.btn_SearchDB = new System.Windows.Forms.Button();
            this.nud_SimilarValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_WaitRemind = new System.Windows.Forms.Label();
            this.timer_WaitRemind = new System.Windows.Forms.Timer(this.components);
            this.lbl_TimeCost = new System.Windows.Forms.Label();
            this.btn_DetectFace = new System.Windows.Forms.Button();
            this.flp_FaceImg = new System.Windows.Forms.FlowLayoutPanel();
            this.pb_DBImg = new System.Windows.Forms.PictureBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_ClearDBData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SimilarValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_DBImg)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_SelectPicture
            // 
            this.btn_SelectPicture.Location = new System.Drawing.Point(10, 322);
            this.btn_SelectPicture.Name = "btn_SelectPicture";
            this.btn_SelectPicture.Size = new System.Drawing.Size(100, 40);
            this.btn_SelectPicture.TabIndex = 0;
            this.btn_SelectPicture.Text = "选择图片";
            this.btn_SelectPicture.UseVisualStyleBackColor = true;
            this.btn_SelectPicture.Click += new System.EventHandler(this.btn_SelectPicture_Click);
            // 
            // pb_Image
            // 
            this.pb_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Image.Location = new System.Drawing.Point(12, 12);
            this.pb_Image.Name = "pb_Image";
            this.pb_Image.Size = new System.Drawing.Size(262, 287);
            this.pb_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Image.TabIndex = 1;
            this.pb_Image.TabStop = false;
            // 
            // btn_SaveFeature
            // 
            this.btn_SaveFeature.Location = new System.Drawing.Point(230, 322);
            this.btn_SaveFeature.Name = "btn_SaveFeature";
            this.btn_SaveFeature.Size = new System.Drawing.Size(100, 40);
            this.btn_SaveFeature.TabIndex = 2;
            this.btn_SaveFeature.Text = "保存特征值";
            this.btn_SaveFeature.UseVisualStyleBackColor = true;
            this.btn_SaveFeature.Click += new System.EventHandler(this.btn_SaveFeature_Click);
            // 
            // btn_SearchDB
            // 
            this.btn_SearchDB.Location = new System.Drawing.Point(462, 322);
            this.btn_SearchDB.Name = "btn_SearchDB";
            this.btn_SearchDB.Size = new System.Drawing.Size(100, 40);
            this.btn_SearchDB.TabIndex = 5;
            this.btn_SearchDB.Text = "搜索数据库";
            this.btn_SearchDB.UseVisualStyleBackColor = true;
            this.btn_SearchDB.Click += new System.EventHandler(this.btn_SearchDB_Click);
            // 
            // nud_SimilarValue
            // 
            this.nud_SimilarValue.DecimalPlaces = 2;
            this.nud_SimilarValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_SimilarValue.Location = new System.Drawing.Point(401, 334);
            this.nud_SimilarValue.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_SimilarValue.Name = "nud_SimilarValue";
            this.nud_SimilarValue.Size = new System.Drawing.Size(55, 21);
            this.nud_SimilarValue.TabIndex = 6;
            this.nud_SimilarValue.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "相似度：";
            // 
            // lbl_WaitRemind
            // 
            this.lbl_WaitRemind.AutoSize = true;
            this.lbl_WaitRemind.Location = new System.Drawing.Point(568, 336);
            this.lbl_WaitRemind.Name = "lbl_WaitRemind";
            this.lbl_WaitRemind.Size = new System.Drawing.Size(41, 12);
            this.lbl_WaitRemind.TabIndex = 8;
            this.lbl_WaitRemind.Text = "查询中";
            this.lbl_WaitRemind.Visible = false;
            // 
            // timer_WaitRemind
            // 
            this.timer_WaitRemind.Interval = 250;
            this.timer_WaitRemind.Tick += new System.EventHandler(this.timer_WaitRemind_Tick);
            // 
            // lbl_TimeCost
            // 
            this.lbl_TimeCost.AutoSize = true;
            this.lbl_TimeCost.Location = new System.Drawing.Point(568, 336);
            this.lbl_TimeCost.Name = "lbl_TimeCost";
            this.lbl_TimeCost.Size = new System.Drawing.Size(41, 12);
            this.lbl_TimeCost.TabIndex = 9;
            this.lbl_TimeCost.Text = "耗时：";
            this.lbl_TimeCost.Visible = false;
            // 
            // btn_DetectFace
            // 
            this.btn_DetectFace.Location = new System.Drawing.Point(120, 322);
            this.btn_DetectFace.Name = "btn_DetectFace";
            this.btn_DetectFace.Size = new System.Drawing.Size(100, 40);
            this.btn_DetectFace.TabIndex = 10;
            this.btn_DetectFace.Text = "识别人脸";
            this.btn_DetectFace.UseVisualStyleBackColor = true;
            this.btn_DetectFace.Click += new System.EventHandler(this.btn_DetectFace_Click);
            // 
            // flp_FaceImg
            // 
            this.flp_FaceImg.AutoScroll = true;
            this.flp_FaceImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flp_FaceImg.Location = new System.Drawing.Point(292, 12);
            this.flp_FaceImg.Name = "flp_FaceImg";
            this.flp_FaceImg.Size = new System.Drawing.Size(262, 287);
            this.flp_FaceImg.TabIndex = 11;
            // 
            // pb_DBImg
            // 
            this.pb_DBImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_DBImg.Location = new System.Drawing.Point(572, 12);
            this.pb_DBImg.Name = "pb_DBImg";
            this.pb_DBImg.Size = new System.Drawing.Size(262, 287);
            this.pb_DBImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_DBImg.TabIndex = 12;
            this.pb_DBImg.TabStop = false;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(734, 322);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(100, 40);
            this.btn_Clear.TabIndex = 13;
            this.btn_Clear.Text = "清空";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_ClearDBData
            // 
            this.btn_ClearDBData.Location = new System.Drawing.Point(10, 368);
            this.btn_ClearDBData.Name = "btn_ClearDBData";
            this.btn_ClearDBData.Size = new System.Drawing.Size(100, 40);
            this.btn_ClearDBData.TabIndex = 14;
            this.btn_ClearDBData.Text = "数据库置零";
            this.btn_ClearDBData.UseVisualStyleBackColor = true;
            this.btn_ClearDBData.Click += new System.EventHandler(this.btn_ClearDBData_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 464);
            this.Controls.Add(this.btn_ClearDBData);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.pb_DBImg);
            this.Controls.Add(this.flp_FaceImg);
            this.Controls.Add(this.btn_DetectFace);
            this.Controls.Add(this.lbl_TimeCost);
            this.Controls.Add(this.lbl_WaitRemind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_SimilarValue);
            this.Controls.Add(this.btn_SearchDB);
            this.Controls.Add(this.btn_SaveFeature);
            this.Controls.Add(this.pb_Image);
            this.Controls.Add(this.btn_SelectPicture);
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试窗口";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SimilarValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_DBImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SelectPicture;
        private System.Windows.Forms.PictureBox pb_Image;
        private System.Windows.Forms.Button btn_SaveFeature;
        private System.Windows.Forms.Button btn_SearchDB;
        private System.Windows.Forms.NumericUpDown nud_SimilarValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_WaitRemind;
        private System.Windows.Forms.Timer timer_WaitRemind;
        private System.Windows.Forms.Label lbl_TimeCost;
        private System.Windows.Forms.Button btn_DetectFace;
        private System.Windows.Forms.FlowLayoutPanel flp_FaceImg;
        private System.Windows.Forms.PictureBox pb_DBImg;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_ClearDBData;
    }
}