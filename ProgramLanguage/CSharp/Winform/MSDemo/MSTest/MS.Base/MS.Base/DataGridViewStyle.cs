
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MS.Base
{
    /// <summary>
    /// 设置DataGridView的样式
    /// </summary>
    public class DataGridViewStyle
    {      
        public static void DgvStyle(DataGridView dgv)
        {
            //禁止当前默认的视觉样式:屏蔽对dgc直接进行的属性设置
            dgv.EnableHeadersVisualStyles = false;

            //奇数行的背景色
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0xf0)))), ((int)(((byte)(0xe9)))), ((int)(((byte)(0xd9)))));
            //默认的行样式
            dgv.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //行的边框样式
            dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //未显示数据时的背景色
            dgv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;

            //数据网格颜色
            dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0xe1)))), ((int)(((byte)(0xdd)))), ((int)(((byte)(0xdc)))));

            //列标题的高度
            dgv.ColumnHeadersHeight = 35;
            //列标题的边框样式
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //列标题的字体颜色
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0x4a)))), ((int)(((byte)(0x51)))), ((int)(((byte)(0x5c)))));
            //列标题的背景颜色
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
          
            //所有数据字体的颜色
            int RowsCount = dgv.Columns.Count;
            for (int i = 0; i < RowsCount; i++)
            {
                dgv.Columns[i].DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0x4a)))), ((int)(((byte)(0x51)))), ((int)(((byte)(0x5c)))));
            }
        }

        /// <summary>
        /// 给DataGridView添加行号
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="e"></param>
        public static void DgvRowPostPaint(DataGridView dgv, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //添加行号 
                SolidBrush v_SolidBrush = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);
                int v_LineNo = 0;
                v_LineNo = e.RowIndex + 1;
                string v_Line = v_LineNo.ToString();
                e.Graphics.DrawString(v_Line, e.InheritedRowStyle.Font, v_SolidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加行号时发生错误，错误信息：" + ex.Message, "操作失败");
            }
        }

    }
}
