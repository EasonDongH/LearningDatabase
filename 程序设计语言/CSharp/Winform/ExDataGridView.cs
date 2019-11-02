using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Test
{
    public partial class ExDataGridView : DataGridView
    {
        private bool showRowHeaderNumbers = true;

        public ExDataGridView()
        {
            this.EnableHeadersVisualStyles = false;
            this.BorderStyle = BorderStyle.None;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            this.RowHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            RowPostPaint += new DataGridViewRowPostPaintEventHandler(DataGridViewEx_RowPostPaint);
            InitGridStyle(this);
        }

        /// <summary>
        /// 是否显示行号
        /// </summary>
        [Description("是否显示行号"), DefaultValue(true)]
        public bool ShowRowHeaderNumbers
        {
            get { return showRowHeaderNumbers; }
            set
            {
                showRowHeaderNumbers = value;
                if (showRowHeaderNumbers)
                    Invalidate();
            }
        }

        void DataGridViewEx_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (showRowHeaderNumbers && RowHeadersVisible && RowHeadersWidth >= 8)
            {
                string title = (e.RowIndex + 1).ToString();
                Brush bru = new SolidBrush(this.RowHeadersDefaultCellStyle.ForeColor);
                e.Graphics.DrawString(title, DefaultCellStyle.Font,
                    bru, e.RowBounds.Location.X + RowHeadersWidth / 2 - 4, e.RowBounds.Location.Y + 4);
            }
        }

        private void InitGridStyle(DataGridView dv)
        {
            dv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(242, 244, 246);
            dv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(67, 87, 113);
            dv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 228, 211);
            dv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(84, 100, 121);
            dv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            Font font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dv.DefaultCellStyle.BackColor = Color.FromArgb(242, 244, 246);
            dv.DefaultCellStyle.ForeColor = Color.FromArgb(67, 87, 113);
            dv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 228, 211);
            dv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(84, 100, 121);
            dv.DefaultCellStyle.Font = font;

            dv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(242, 244, 246);
            dv.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(67, 87, 113);
            dv.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 228, 211);
            dv.RowHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(84, 100, 121);
            dv.RowHeadersDefaultCellStyle.Font = font;

            dv.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(242, 244, 246);
            dv.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(67, 87, 113);
            dv.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 228, 211);
            dv.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(84, 100, 121);
            dv.RowTemplate.DefaultCellStyle.Font = font;
        }
    }
}
