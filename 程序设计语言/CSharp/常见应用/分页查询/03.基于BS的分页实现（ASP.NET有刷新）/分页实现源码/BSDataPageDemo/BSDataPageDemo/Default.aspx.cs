using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;

namespace BSDataPageDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //禁用所有按钮
                this.btnFirst.Enabled = false;
                this.btnPre.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnGoTo.Enabled = false;
            }
        }
        //提交查询方法
        private void Query(int currentPageNo)
        {
            int pageSize = Convert.ToInt32(this.ddlPageSize.SelectedValue);//每页显示的条数
            int currentPage = currentPageNo;//当前页码          
            int records = 0;//记录总数
            int pages = 0;//总页数
            //提交查询
            List<Student> list = new StudentManager().GetPagedData(pageSize,
                 Convert.ToDateTime(this.txtBirthday.Text.Trim()), currentPage, out records, out pages);
          
            //绑定数据
            this.dlStuList.DataSource = list;
            this.dlStuList.DataBind();
            this.PagesCount.Text = pages.ToString();
            this.hfPagesCount.Value = pages.ToString();//保存在隐藏域中，用于前台js判断
            this.RecordsCount.Text = records.ToString();
            this.CurrentPage.Text = currentPageNo.ToString();
            if (list.Count == 0)
            {
                this.ltaMsg.Visible = true;
                this.CurrentPage.Text = "0";
                this.btnGoTo.Enabled = false;
            }
            else
            {
                this.ltaMsg.Visible = false;
                this.btnGoTo.Enabled = true;
            }
            //禁用所有按钮
            this.btnFirst.Enabled = false;
            this.btnPre.Enabled = false;
            this.btnNext.Enabled = false;
            this.btnLast.Enabled = false;
        }
        //提交查询
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            this.Query(1);
            if (Convert.ToInt32(this.PagesCount.Text ) > 1)
            {
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
            }
        }
        //第一页
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            btnQuery_Click(null, null);
        }
        //上一页
        protected void btnPre_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(this.CurrentPage.Text.Trim()) - 1;
            this.Query(currentPage);
            if (currentPage > 1)
            {
                this.btnFirst.Enabled = true; ;
                this.btnPre.Enabled = true;               
            }
            this.btnNext.Enabled = true;
            this.btnLast.Enabled = true;
        }
        //下一页
        protected void btnNext_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(this.CurrentPage.Text.Trim()) + 1;
            this.Query(currentPage);
           
            this.btnFirst.Enabled = true; ;
            this.btnPre.Enabled = true;       
            if (currentPage <Convert .ToInt32 (this.PagesCount .Text ))
            {
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
            }       
        }
        //最后页
        protected void btnLast_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(this.PagesCount.Text.Trim());
            this.Query(currentPage);

            this.btnFirst.Enabled = true;
            this.btnPre.Enabled = true;
        }
        //跳转到
        protected void btnGoTo_Click(object sender, EventArgs e)
        {          
            int currentPage = Convert.ToInt32(this.txtGoTo.Text.Trim());
            this.Query(currentPage);
            this.CurrentPage.Text = currentPage.ToString();

            if (currentPage > 1)
            {
                this.btnFirst.Enabled = true; ;
                this.btnPre.Enabled = true;
            }
            if (currentPage < Convert.ToInt32(this.PagesCount.Text.Trim()))
            {
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
            }

        }
    }
}