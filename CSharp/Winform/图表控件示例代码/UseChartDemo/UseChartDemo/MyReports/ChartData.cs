using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseChartDemo
{
    /// <summary>
    /// Chart数据实体类
    /// </summary>
    public class ChartData
    {
        public ChartData() { }
        public ChartData(string text, double value)
        {
            this.Text = text;
            this.Value = value;
        }
        /// <summary>
        /// 显示的文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 显示的值
        /// </summary>
        public double  Value { get; set; }
    }
}
