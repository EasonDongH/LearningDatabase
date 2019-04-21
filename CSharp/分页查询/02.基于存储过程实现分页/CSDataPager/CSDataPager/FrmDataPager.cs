using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSDataPager
{
    public partial class FrmDataPager : Form
    {  
        //创建数据分页类对象
        private SqlDataPager objPager = new SqlDataPager();
       
        //构造函数
        public FrmDataPager()
        {
            InitializeComponent();
            this.dtpBirthday.Text = "1988-1-1";
            //设置默认显示条数
            this.cboRecordList.SelectedIndex = 1;
            //设置数据列表的显示样式
            this.dgvLogList.AutoGenerateColumns = false;
            //禁用所有按钮
            this.btnFirst.Enabled = false;
            this.btnNext.Enabled = false;
            this.btnPre.Enabled = false;
            this.btnLast.Enabled = false;
            this.btnToPage.Enabled = false;
        }
        //执行查询的公共方法
        private void Query()
        {
            //开启所有按钮
            this.btnFirst.Enabled = true;
            this.btnNext.Enabled = true;
            this.btnPre.Enabled = true;
            this.btnLast.Enabled = true;         
            //设置每页显示条数
            objPager.PageSize = Convert.ToInt32(this.cboRecordList.Text.Trim());
            //执行查询
            this.dgvLogList.DataSource = objPager.GetPagedData(this.dtpBirthday.Text);
            //显示记录总数
            this.lblRecordsCount.Text = objPager.RecordsCount.ToString();
            //显示页数和页码
            this.lblPageCount.Text = objPager.TotalPages.ToString();
            if (this.lblPageCount.Text == "0")
            {
                this.lblCurrentPageIndex.Text = "0";
            }
            else
            {
                this.lblCurrentPageIndex.Text = objPager.CurrentPageIndex.ToString();
            }
            if (this.lblPageCount.Text == "0" || this.lblPageCount.Text == "1")
            {
                //禁用所有按钮
                this.btnFirst.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnPre.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnToPage.Enabled = false;
            }
            else
            {
                this.btnToPage.Enabled = true;
            }
        }
        //提交查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            objPager.CurrentPageIndex = 1;
            Query();
            this.btnPre.Enabled = false;
            this.btnFirst.Enabled = false;
        }
        //第1页
        private void btnFirst_Click(object sender, EventArgs e)
        {
            objPager.CurrentPageIndex = 1;
            Query();
            this.btnPre.Enabled = false;
            this.btnFirst.Enabled = false;
        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            objPager.CurrentPageIndex += 1;
            Query();
            if (objPager.CurrentPageIndex == objPager.TotalPages)
            {
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
        }
        //上一页
        private void btnPre_Click(object sender, EventArgs e)
        {
            objPager.CurrentPageIndex -= 1;
            Query();
            if (objPager.CurrentPageIndex == 1)
            {
                this.btnPre.Enabled = false;
                this.btnFirst.Enabled = false;
            }
        }
        //最后一页
        private void btnLast_Click(object sender, EventArgs e)
        {
            objPager.CurrentPageIndex = objPager.TotalPages;
            Query();
            this.btnLast.Enabled = false;
            this.btnNext.Enabled = false;
        }
        //跳转到
        private void btnToPage_Click(object sender, EventArgs e)
        {
            if (this.txtToPage.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入要跳转的页码！", "信息提示");
                this.txtToPage.Focus();
                return;
            }
            int pageIndex = Convert.ToInt32(this.txtToPage.Text.Trim());
            if (pageIndex > objPager.TotalPages)
            {
                MessageBox.Show("跳转的页数不能大于数据总页数！", "信息提示");
                this.txtToPage.Focus();
                this.txtToPage.SelectAll();
                return;
            }
            objPager.CurrentPageIndex = pageIndex;
            Query();
            if (objPager.CurrentPageIndex == 1)
            {
                this.btnPre.Enabled = false;
                this.btnFirst.Enabled = false;
            }
            else if (objPager.CurrentPageIndex == objPager.TotalPages)
            {
                this.btnLast.Enabled = false;
                this.btnNext.Enabled = false;
            }
        }      
        //关闭窗口
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
