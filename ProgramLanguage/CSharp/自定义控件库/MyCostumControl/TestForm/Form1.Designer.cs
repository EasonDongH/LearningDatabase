namespace TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.circleLoading1 = new MyCostumControl.CircleLoading();
            this.exGroupGox1 = new MyCostumControl.ExGroupGox();
            this.exTabControl1 = new MyCostumControl.ExTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.exDataGridView1 = new MyCostumControl.ExDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "填充数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(532, 290);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "开始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(532, 319);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "停止";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // circleLoading1
            // 
            this.circleLoading1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.circleLoading1.CircleColor = System.Drawing.Color.Red;
            this.circleLoading1.CircleSize = 0.8F;
            this.circleLoading1.Location = new System.Drawing.Point(621, 290);
            this.circleLoading1.Name = "circleLoading1";
            this.circleLoading1.Size = new System.Drawing.Size(87, 87);
            this.circleLoading1.TabIndex = 7;
            // 
            // exGroupGox1
            // 
            this.exGroupGox1.BackColor = System.Drawing.Color.White;
            this.exGroupGox1.Border = true;
            this.exGroupGox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(213)))), ((int)(((byte)(243)))));
            this.exGroupGox1.ButtonVisible = false;
            this.exGroupGox1.Caption = "标题";
            this.exGroupGox1.CaptionAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exGroupGox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.exGroupGox1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exGroupGox1.CaptionHeight = 23;
            this.exGroupGox1.CaptionLinearGradientColorEnd = System.Drawing.Color.LightSteelBlue;
            this.exGroupGox1.CaptionLinearGradientColorStart = System.Drawing.Color.AliceBlue;
            this.exGroupGox1.CaptionOpacity = 50;
            this.exGroupGox1.CaptionTransparent = false;
            this.exGroupGox1.CaptionUseLinearGradient = false;
            this.exGroupGox1.CollapseImage = ((System.Drawing.Image)(resources.GetObject("exGroupGox1.CollapseImage")));
            this.exGroupGox1.ContentBackColor = System.Drawing.Color.White;
            this.exGroupGox1.DockMenuStyle = false;
            this.exGroupGox1.ExpandImage = ((System.Drawing.Image)(resources.GetObject("exGroupGox1.ExpandImage")));
            this.exGroupGox1.Location = new System.Drawing.Point(376, 41);
            this.exGroupGox1.Name = "exGroupGox1";
            this.exGroupGox1.Opacity = 50;
            this.exGroupGox1.Size = new System.Drawing.Size(485, 243);
            this.exGroupGox1.TabIndex = 3;
            this.exGroupGox1.Text = "exGroupGox1";
            this.exGroupGox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exGroupGox1.Transparent = false;
            // 
            // exTabControl1
            // 
            this.exTabControl1.ActivedTabTextColor = System.Drawing.Color.Black;
            this.exTabControl1.CloseImage = null;
            this.exTabControl1.Controls.Add(this.tabPage1);
            this.exTabControl1.Controls.Add(this.tabPage2);
            this.exTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.exTabControl1.EnableTabBkColorLinear = true;
            this.exTabControl1.HotTrack = true;
            this.exTabControl1.ItemSize = new System.Drawing.Size(80, 80);
            this.exTabControl1.Location = new System.Drawing.Point(12, 197);
            this.exTabControl1.Name = "exTabControl1";
            this.exTabControl1.Padding = new System.Drawing.Point(20, 0);
            this.exTabControl1.SelectedIndex = 0;
            this.exTabControl1.ShowToolTips = true;
            this.exTabControl1.Size = new System.Drawing.Size(358, 333);
            this.exTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.exTabControl1.TabBackColor = System.Drawing.SystemColors.Control;
            this.exTabControl1.TabBkColorLinearEnd = System.Drawing.Color.LightSteelBlue;
            this.exTabControl1.TabBkColorLinearStart = System.Drawing.Color.WhiteSmoke;
            this.exTabControl1.TabBkLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.exTabControl1.TabBorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.exTabControl1.TabIndex = 2;
            this.exTabControl1.TabTextColor = System.Drawing.Color.White;
            this.exTabControl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exTabControl1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 84);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(350, 245);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 84);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(350, 245);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // exDataGridView1
            // 
            this.exDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(87)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(228)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(100)))), ((int)(((byte)(121)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.exDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.exDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(87)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(228)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(100)))), ((int)(((byte)(121)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.exDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.exDataGridView1.EnableHeadersVisualStyles = false;
            this.exDataGridView1.Location = new System.Drawing.Point(12, 41);
            this.exDataGridView1.Name = "exDataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(87)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(228)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(100)))), ((int)(((byte)(121)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.exDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.exDataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.exDataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exDataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(87)))), ((int)(((byte)(113)))));
            this.exDataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(228)))), ((int)(((byte)(211)))));
            this.exDataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(100)))), ((int)(((byte)(121)))));
            this.exDataGridView1.RowTemplate.Height = 23;
            this.exDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.exDataGridView1.Size = new System.Drawing.Size(358, 150);
            this.exDataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Column1";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Column2";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Column3";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 542);
            this.Controls.Add(this.circleLoading1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.exGroupGox1);
            this.Controls.Add(this.exTabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exDataGridView1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.exTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyCostumControl.ExDataGridView exDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button button1;
        private MyCostumControl.ExTabControl exTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MyCostumControl.ExGroupGox exGroupGox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private MyCostumControl.CircleLoading circleLoading1;
    }
}

