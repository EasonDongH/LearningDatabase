using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Reflection;

namespace MS.UI
{
    public partial class FrmMain : Form
    {
        private static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public FrmMain()
        {
            InitializeComponent();

            this.tc_Main.DrawMode = TabDrawMode.OwnerDrawFixed;

            this.btn_DepartmentQuery_Click(null,null);
        }

        /// <summary>
        /// 判断选项卡是否已打开
        /// </summary>
        /// <param name="page_Tag"></param>
        /// <returns>-1：未打开；>=0：已打开，且返回值即为选项卡的Index</returns>
        private int CheckTabPageIsOpen(string page_Tag)
        {
            for (int i = 0; i < this.tc_Main.TabCount; ++i)
            {
                if (this.tc_Main.TabPages[i].Tag.ToString() == page_Tag)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 添加新选项卡
        /// </summary>
        /// <param name="frm">需要打开的窗体</param>
        /// <param name="frmText">窗体显示的标题</param>
        /// <param name="pageTag">唯一区分窗体的标记</param>
        private void AddTabPage(Form frm, string frmText, string pageTag)
        {
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            TabPage page = new TabPage();
            page.Text = frmText+ "  "; // 为了标题与关闭框之间有空隙，在标题后面添加两个空格
            page.Controls.Add(frm);
            page.Tag = pageTag;
            tc_Main.TabPages.Add(page);
            this.tc_Main.SelectedIndex = this.tc_Main.TabCount - 1;
            frm.Show();
        }

        private void btn_DepartmentQuery_Click(object sender, EventArgs e)
        {
            string pageTag = "FrmDepartmentQuery";
            int check_Result = CheckTabPageIsOpen(pageTag);
            if (check_Result >= 0)
            {
                this.tc_Main.SelectedIndex = check_Result;
            }
            else
            {
                AddTabPage(new FrmDepartmentQuery(), "部门管理", pageTag);
            }
        }

        private void btn_EmployeeQuery_Click(object sender, EventArgs e)
        {
            string pageTag = "FrmEmployeeQuery";
            int check_Result = CheckTabPageIsOpen(pageTag);
            if (check_Result >= 0)
            {
                this.tc_Main.SelectedIndex = check_Result;
            }
            else
            {
                AddTabPage(new FrmEmployeeQuery(), "员工管理", "FrmEmployeeQuery");
            }
        }

        #region 选择项卡相关
        /// <summary>
        /// 重绘TabPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tc_Main_DrawItem(object sender, DrawItemEventArgs e)
        {
            // 必须设置：this.tc_Main.DrawMode = TabDrawMode.OwnerDrawFixed;
            try
            {
                Rectangle myTabRect = this.tc_Main.GetTabRect(e.Index);
                int CLOSE_SIZE = 10;
                //先添加TabPage属性  
                e.Graphics.DrawString(this.tc_Main.TabPages[e.Index].Text, this.Font, SystemBrushes.ActiveCaptionText, myTabRect.X + 3, myTabRect.Y + 3);

                //再画一个矩形框
                using (Pen p = new Pen(Color.Black))//自动释放资源
                {
                    myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 3);// x：left y：top
                    myTabRect.Width = CLOSE_SIZE;
                    myTabRect.Height = CLOSE_SIZE;
                    e.Graphics.DrawRectangle(p, myTabRect);
                }

                //画关闭符号
                using (Pen objpen = new Pen(Color.Black))
                {
                    //"/"线
                    Point p1 = new Point(myTabRect.X + 3, myTabRect.Y + 3);
                    Point p2 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + myTabRect.Height - 3);
                    e.Graphics.DrawLine(objpen, p1, p2);

                    //"\"线
                    Point p3 = new Point(myTabRect.X + 3, myTabRect.Y + myTabRect.Height - 3);
                    Point p4 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + 3);
                    e.Graphics.DrawLine(objpen, p3, p4);
                }

                e.Graphics.Dispose();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

        }
        /// <summary>
        /// TabPage关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tc_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X, y = e.Y;

                int CLOSE_SIZE = 10;

                //计算关闭区域  
                Rectangle myTabRect = this.tc_Main.GetTabRect(this.tc_Main.SelectedIndex);

                myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                myTabRect.Width = CLOSE_SIZE;
                myTabRect.Height = CLOSE_SIZE;

                //如果鼠标在区域内就关闭选项卡  
                bool isClose = x > myTabRect.X && x < myTabRect.Right
 && y > myTabRect.Y && y < myTabRect.Bottom;

                if (isClose == true)
                {
                    this.tc_Main.TabPages.Remove(this.tc_Main.SelectedTab);
                }
            }
        }
        #endregion
    }
}
