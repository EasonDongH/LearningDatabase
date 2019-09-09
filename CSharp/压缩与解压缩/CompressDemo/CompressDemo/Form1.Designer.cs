namespace CompressDemo
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnRarMultiPartArchive = new System.Windows.Forms.Button();
            this.btnRarCompress = new System.Windows.Forms.Button();
            this.btnSharpCompressDeCompress = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPackage = new System.Windows.Forms.TextBox();
            this.lblPackage = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAutoDecompress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 232);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(159, 147);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 147);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 26);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(11, 187);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 26);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(159, 187);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 26);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnRarMultiPartArchive
            // 
            this.btnRarMultiPartArchive.Location = new System.Drawing.Point(159, 103);
            this.btnRarMultiPartArchive.Margin = new System.Windows.Forms.Padding(2);
            this.btnRarMultiPartArchive.Name = "btnRarMultiPartArchive";
            this.btnRarMultiPartArchive.Size = new System.Drawing.Size(88, 26);
            this.btnRarMultiPartArchive.TabIndex = 5;
            this.btnRarMultiPartArchive.Text = "rar分卷压缩";
            this.btnRarMultiPartArchive.UseVisualStyleBackColor = true;
            this.btnRarMultiPartArchive.Click += new System.EventHandler(this.btnRarMultiPartArchive_Click);
            // 
            // btnRarCompress
            // 
            this.btnRarCompress.Location = new System.Drawing.Point(9, 103);
            this.btnRarCompress.Margin = new System.Windows.Forms.Padding(2);
            this.btnRarCompress.Name = "btnRarCompress";
            this.btnRarCompress.Size = new System.Drawing.Size(88, 26);
            this.btnRarCompress.TabIndex = 6;
            this.btnRarCompress.Text = "rar压缩";
            this.btnRarCompress.UseVisualStyleBackColor = true;
            this.btnRarCompress.Click += new System.EventHandler(this.btnRarCompress_Click);
            // 
            // btnSharpCompressDeCompress
            // 
            this.btnSharpCompressDeCompress.Location = new System.Drawing.Point(9, 67);
            this.btnSharpCompressDeCompress.Name = "btnSharpCompressDeCompress";
            this.btnSharpCompressDeCompress.Size = new System.Drawing.Size(157, 31);
            this.btnSharpCompressDeCompress.TabIndex = 7;
            this.btnSharpCompressDeCompress.Text = "SharpCompress解压";
            this.btnSharpCompressDeCompress.UseVisualStyleBackColor = true;
            this.btnSharpCompressDeCompress.Click += new System.EventHandler(this.btnSharpCompressDeCompress_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "压缩包路径：";
            // 
            // txtPackage
            // 
            this.txtPackage.Location = new System.Drawing.Point(97, 7);
            this.txtPackage.Name = "txtPackage";
            this.txtPackage.Size = new System.Drawing.Size(308, 21);
            this.txtPackage.TabIndex = 9;
            // 
            // lblPackage
            // 
            this.lblPackage.AutoSize = true;
            this.lblPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPackage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPackage.Location = new System.Drawing.Point(411, 7);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new System.Drawing.Size(24, 23);
            this.lblPackage.TabIndex = 10;
            this.lblPackage.Text = "...";
            this.lblPackage.Click += new System.EventHandler(this.lblPackage_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFile.Location = new System.Drawing.Point(411, 40);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(24, 23);
            this.lblFile.TabIndex = 13;
            this.lblFile.Text = "...";
            this.lblFile.Click += new System.EventHandler(this.lblFile_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(97, 40);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(308, 21);
            this.txtFilePath.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "文件路径：";
            // 
            // btnAutoDecompress
            // 
            this.btnAutoDecompress.Location = new System.Drawing.Point(287, 67);
            this.btnAutoDecompress.Name = "btnAutoDecompress";
            this.btnAutoDecompress.Size = new System.Drawing.Size(118, 31);
            this.btnAutoDecompress.TabIndex = 14;
            this.btnAutoDecompress.Text = "自行判断解压方式";
            this.btnAutoDecompress.UseVisualStyleBackColor = true;
            this.btnAutoDecompress.Click += new System.EventHandler(this.btnAutoDecompress_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 288);
            this.Controls.Add(this.btnAutoDecompress);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPackage);
            this.Controls.Add(this.txtPackage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSharpCompressDeCompress);
            this.Controls.Add(this.btnRarCompress);
            this.Controls.Add(this.btnRarMultiPartArchive);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnRarMultiPartArchive;
        private System.Windows.Forms.Button btnRarCompress;
        private System.Windows.Forms.Button btnSharpCompressDeCompress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPackage;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAutoDecompress;
    }
}

