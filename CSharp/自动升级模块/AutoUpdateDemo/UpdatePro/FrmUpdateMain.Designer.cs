namespace UpdatePro
{
    partial class FrmUpdateMain
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "",
            "",
            ""}, -1);
            this.lvUpdateFile = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DownloadPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStart = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lvUpdateFile
            // 
            this.lvUpdateFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.FileSize,
            this.DownloadPercent});
            this.lvUpdateFile.GridLines = true;
            this.lvUpdateFile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvUpdateFile.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvUpdateFile.Location = new System.Drawing.Point(100, 43);
            this.lvUpdateFile.Name = "lvUpdateFile";
            this.lvUpdateFile.Scrollable = false;
            this.lvUpdateFile.Size = new System.Drawing.Size(442, 217);
            this.lvUpdateFile.TabIndex = 0;
            this.lvUpdateFile.UseCompatibleStateImageBehavior = false;
            this.lvUpdateFile.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            this.FileName.Text = "文件名";
            this.FileName.Width = 150;
            // 
            // FileSize
            // 
            this.FileSize.Text = "文件大小";
            this.FileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FileSize.Width = 82;
            // 
            // DownloadPercent
            // 
            this.DownloadPercent.Text = "下载进度";
            this.DownloadPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DownloadPercent.Width = 77;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(100, 311);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(113, 39);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(100, 266);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(442, 26);
            this.progressBar1.TabIndex = 4;
            // 
            // FrmUpdateMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lvUpdateFile);
            this.Name = "FrmUpdateMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUpdateMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvUpdateFile;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader FileSize;
        private System.Windows.Forms.ColumnHeader DownloadPercent;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}