using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//引用命名空间
using System.Windows.Forms.DataVisualization.Charting;

namespace UseChartDemo
{
    public partial class FrmChart : Form
    {
        private SuperChart superChart = null;
        private List<ChartData> dataList = new List<ChartData>();//用来保存数据的集合
        public FrmChart()
        {
            InitializeComponent();

            //初始化自定义图表设置对象
            superChart = new SuperChart(this.chart1);
            Init();//实际开发中，可以从数据库或其他数据源查询
        }
        private void Init()
        {
            //创建一个随机数用来生成数据
            Random random = new Random();
            dataList.Add(new ChartData("北京", random.Next(100)));
            dataList.Add(new ChartData("上海", random.Next(100)));
            dataList.Add(new ChartData("天津", random.Next(100)));
            dataList.Add(new ChartData("深圳", random.Next(100)));
            dataList.Add(new ChartData("南京", random.Next(100)));
        }


        //显示饼形图
        private void btnPie_Click(object sender, EventArgs e)
        {
            this.superChart.ShowChart(SeriesChartType.Pie, dataList);
        }
        //显示柱状图
        private void btnColumn_Click(object sender, EventArgs e)
        {
            this.superChart.ShowChart(SeriesChartType.Column, dataList);
        }
        //折线图
        private void btnLine_Click(object sender, EventArgs e)
        {
            this.superChart.ShowChart(SeriesChartType.Line, dataList);
        }
        //横条图
        private void btnBar_Click(object sender, EventArgs e)
        {
            this.superChart.ShowChart(SeriesChartType.Bar, dataList);
        }
        //圆环图
        private void btnDoughnut_Click(object sender, EventArgs e)
        {
            this.superChart.ShowChart(SeriesChartType.Doughnut, dataList);
        }
        //样条图
        private void btnSpline_Click(object sender, EventArgs e)
        {
            this.superChart.ShowChart(SeriesChartType.Spline, dataList);
        }
        //样条面积图
        private void btnSplineArea_Click(object sender, EventArgs e)
        {
            this.superChart.ShowChart(SeriesChartType.SplineArea, dataList);
        }
    }
}
