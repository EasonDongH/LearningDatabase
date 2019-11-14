namespace UseChartDemo
{
    partial class FrmChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChart));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPie = new System.Windows.Forms.ToolStripButton();
            this.btnColumn = new System.Windows.Forms.ToolStripButton();
            this.btnLine = new System.Windows.Forms.ToolStripButton();
            this.btnBar = new System.Windows.Forms.ToolStripButton();
            this.btnDoughnut = new System.Windows.Forms.ToolStripButton();
            this.btnSpline = new System.Windows.Forms.ToolStripButton();
            this.btnSplineArea = new System.Windows.Forms.ToolStripButton();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPie,
            this.btnColumn,
            this.btnLine,
            this.btnBar,
            this.btnDoughnut,
            this.btnSpline,
            this.btnSplineArea});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(864, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPie
            // 
            this.btnPie.Image = ((System.Drawing.Image)(resources.GetObject("btnPie.Image")));
            this.btnPie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPie.Name = "btnPie";
            this.btnPie.Size = new System.Drawing.Size(64, 22);
            this.btnPie.Text = "饼形图";
            this.btnPie.Click += new System.EventHandler(this.btnPie_Click);
            // 
            // btnColumn
            // 
            this.btnColumn.Image = ((System.Drawing.Image)(resources.GetObject("btnColumn.Image")));
            this.btnColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColumn.Name = "btnColumn";
            this.btnColumn.Size = new System.Drawing.Size(64, 22);
            this.btnColumn.Text = "柱状图";
            this.btnColumn.Click += new System.EventHandler(this.btnColumn_Click);
            // 
            // btnLine
            // 
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(64, 22);
            this.btnLine.Text = "折线图";
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnBar
            // 
            this.btnBar.Image = ((System.Drawing.Image)(resources.GetObject("btnBar.Image")));
            this.btnBar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBar.Name = "btnBar";
            this.btnBar.Size = new System.Drawing.Size(64, 22);
            this.btnBar.Text = "横条图";
            this.btnBar.Click += new System.EventHandler(this.btnBar_Click);
            // 
            // btnDoughnut
            // 
            this.btnDoughnut.Image = ((System.Drawing.Image)(resources.GetObject("btnDoughnut.Image")));
            this.btnDoughnut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDoughnut.Name = "btnDoughnut";
            this.btnDoughnut.Size = new System.Drawing.Size(64, 22);
            this.btnDoughnut.Text = "圆环图";
            this.btnDoughnut.Click += new System.EventHandler(this.btnDoughnut_Click);
            // 
            // btnSpline
            // 
            this.btnSpline.Image = ((System.Drawing.Image)(resources.GetObject("btnSpline.Image")));
            this.btnSpline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSpline.Name = "btnSpline";
            this.btnSpline.Size = new System.Drawing.Size(64, 22);
            this.btnSpline.Text = "样条图";
            this.btnSpline.Click += new System.EventHandler(this.btnSpline_Click);
            // 
            // btnSplineArea
            // 
            this.btnSplineArea.Image = ((System.Drawing.Image)(resources.GetObject("btnSplineArea.Image")));
            this.btnSplineArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplineArea.Name = "btnSplineArea";
            this.btnSplineArea.Size = new System.Drawing.Size(88, 22);
            this.btnSplineArea.Text = "样条面积图";
            this.btnSplineArea.Click += new System.EventHandler(this.btnSplineArea_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 57);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(840, 425);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // FrmChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 509);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C#中数据图表的使用";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPie;
        private System.Windows.Forms.ToolStripButton btnColumn;
        private System.Windows.Forms.ToolStripButton btnLine;
        private System.Windows.Forms.ToolStripButton btnBar;
        private System.Windows.Forms.ToolStripButton btnDoughnut;
        private System.Windows.Forms.ToolStripButton btnSpline;
        private System.Windows.Forms.ToolStripButton btnSplineArea;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

