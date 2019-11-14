using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//添加需要的命名空间
using System.Windows.Forms.DataVisualization.Charting;

namespace UseChartDemo
{
    /// <summary>
    /// 高级图表设置类
    /// </summary>
    public class SuperChart
    {
        //当前要使用的图表控件对象
        private Chart chart = null;
        public SuperChart(Chart chart)
        {
            this.chart = chart;
        }

        /// <summary>
        /// 绘制图表的通用方法
        /// </summary>
        /// <param name="chartType">图表显示的类型</param>
        /// <param name="dataList">图表所需要的数据</param>
        public void ShowChart(SeriesChartType chartType, List<ChartData> dataList)
        {
            //【1】清除所有的图表序列
            this.chart.Series.Clear();

            //【2】创建一个图表序列对象（一个图表，可以添加多个图表序列，也就是绘图对象）
            Series series1 = new Series();
            series1.ChartType = chartType;//设置图表序列对象显示的类型
            this.chart.Series.Add(series1);//添加到图表序列集合

            //【3】设置当前图表序列的各种属性值
            for (int i = 0; i < dataList.Count ; i++)
            {
                //3.1 获取数据对象的两个值
                string text = dataList[i].Text;
                double value = dataList[i].Value;

                //3.2 使用x和y的值将DataPoint对象添加进去
                series1.Points.AddXY(text, value);

                //3.3 设置数据点显示内容
                series1.Points[i].LabelToolTip = value.ToString();//鼠标放到标签上面的提示
                series1.Points[i].ToolTip = value.ToString();//图形上面的提示

                //3.4 根据图形样式设置显示的形式和内容
                if (chartType == SeriesChartType.Pie)
                {
                    // series1.Points[i].Label = "#AXISLABEL(#VAL)";//设置标签显示的内容=X轴内容+value
                    series1.Points[i].Label = "#AXISLABEL(#PERCENT)";//X轴+百分比
                                                                     // series1.Points[i].Label = "#AXISLABEL(#VAL)(#PERCENT)";
                    series1["PieLabelStyle"] = "Outside"; //在外侧显示Lable
                                                          // series1["PieLabelStyle"] = "Inside";
                    series1["PieLineColor"] = "Black";//绘制连线
                }
                else if (chartType == SeriesChartType.Doughnut)//圆环图
                {
                    series1.Points[i].Label = "#AXISLABEL   (#PERCENT)";
                    series1["PieLabelStyle"] = "Inside";
                }
                else //如果是其他图形，显示百分比或数值
                {
                    series1.Points[i].Label = "(#PERCENT)";
                }
                if (chartType != SeriesChartType.Pie)
                {
                    series1.Points[i].AxisLabel = string.Format("{0} {1}", text, value);
                }
            }
            //【4】设置图表绘图区域的X和Y坐标值（Y：表示具体要显示的数值之间的间隔）
            this.chart.ChartAreas[0].AxisY.Interval = 10;//也可以设置成20
            this.chart.ChartAreas[0].AxisX.Interval = 1; //一般都设置为1
        }
    }
}
