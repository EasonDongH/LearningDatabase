using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MS.Base;
using MS.BLL;
using MS.Models;

namespace MS.UI
{
    public partial class FrmDepartmentQuery : Form
    {
        private DepartmentBLL objDepartmentBLL = new DepartmentBLL();

        public FrmDepartmentQuery()
        {
            InitializeComponent();

            this.cbo_DepartmentQueryMode.SelectedIndex = 0;
            this.dgv_DepartmentInfo.AutoGenerateColumns = false;
        }

        private void tsbtn_AddDepartment_Click(object sender, EventArgs e)
        {
            FrmUpdateDepartment frm = new FrmUpdateDepartment(OperateMode.Add);
            if (DialogResult.OK == frm.ShowDialog())
            {
                this.dgv_DepartmentInfo.DataSource = null;
                this.dgv_DepartmentInfo.DataSource = this.objDepartmentBLL.GetDepartments();
            }
        }

        private void tsbtn_QueryDepartment_Click(object sender, EventArgs e)
        {
            this.ep_Reminder.Clear();
            int queryMode = this.cbo_DepartmentQueryMode.SelectedIndex;
            string queryCondition = this.txt_QueryCondition.Text.Trim();
            if (queryMode != 0 && queryCondition == string.Empty)
            {
                this.ep_Reminder.SetError(this.txt_QueryCondition, "查询条件不能为空");
                return;
            }
            this.dgv_DepartmentInfo.DataSource = null;
            this.dgv_DepartmentInfo.DataSource = this.objDepartmentBLL.GetDepartments(queryMode, queryCondition);
        }

        private void tsbtn_DeleteDepartment_Click(object sender, EventArgs e)
        {
            var currentRow = this.dgv_DepartmentInfo.CurrentRow;
            if (currentRow == null)
            {
                MessageBox.Show("请选中需要删除的数据！", "删除提示");
                return;
            }
            string name = currentRow.Cells["DepartmentName"].Value.ToString();
            if (DialogResult.OK != MessageBox.Show(string.Format("确认删除【部门名称：{0}】吗？", name), "删除提示", MessageBoxButtons.OKCancel))
                return;
            string no = currentRow.Cells["DepartmentNo"].Value.ToString();

            if (this.objDepartmentBLL.DeleteDepartmentByNo(no))
            {
                MessageBox.Show("删除成功！", "删除提示");
                this.dgv_DepartmentInfo.DataSource = null;
                this.dgv_DepartmentInfo.DataSource = this.objDepartmentBLL.GetDepartments();
            }
            else
            {
                MessageBox.Show("删除失败！", "删除提示");
            }
        }

        private void tsbtn_ModifyDepartment_Click(object sender, EventArgs e)
        {
            var currentRow = this.dgv_DepartmentInfo.CurrentRow;
            if (currentRow == null)
            {
                MessageBox.Show("请选中需要修改的数据！", "修改提示");
                return;
            }
            string no = currentRow.Cells["DepartmentNo"].Value.ToString();

            DepartmentModel department = this.objDepartmentBLL.GetSpecifyDepartmentByDepartmentNo(no);
            FrmUpdateDepartment frm = new FrmUpdateDepartment(OperateMode.Modify, department);
            if (DialogResult.OK == frm.ShowDialog())
            {
                this.dgv_DepartmentInfo.DataSource = null;
                this.dgv_DepartmentInfo.DataSource = this.objDepartmentBLL.GetDepartments();
            }
        }

        #region 查询模式切换

        private void cbo_DepartmentQueryMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ep_Reminder.Clear();
            bool toClear = false;
            int inputLength = this.txt_QueryCondition.Text.Trim().Length;
            switch (this.cbo_DepartmentQueryMode.SelectedIndex)
            {
                case 0:
                    toClear = true;
                    break;
                case 1:
                    this.txt_QueryCondition.MaxLength = DepartmentModel.DepartmentNoValidLength;
                    toClear = !DepartmentModel.CheckDepartmentNoIsValid(this.txt_QueryCondition.Text.Trim());
                    break;
                case 2:
                    this.txt_QueryCondition.MaxLength = DepartmentModel.DepartmentNameValidLength;
                    toClear = !DepartmentModel.CheckDepartmentNameIsValid(this.txt_QueryCondition.Text.Trim());
                    break;
            }
            if (toClear)
                this.txt_QueryCondition.Text = string.Empty;
        }
        #endregion
    }
}
