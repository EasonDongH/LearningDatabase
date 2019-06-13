using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MS.BLL;
using MS.Base;
using MS.Models;

namespace MS.UI
{
    public partial class FrmEmployeeQuery : Form
    {
        private EmployeeBLL objEmployeeBLL = new EmployeeBLL();

        public FrmEmployeeQuery()
        {
            InitializeComponent();

            this.cbo_EmployeeQueryMode.SelectedIndex = 0;
            this.dgv_EmployeeInfo.AutoGenerateColumns = false;
        }

        private void tsbtn_AddEmployee_Click(object sender, EventArgs e)
        {
            FrmUpdateEmployee frm = new FrmUpdateEmployee(OperateMode.Add);
            if (DialogResult.OK == frm.ShowDialog())
            {
                this.dgv_EmployeeInfo.DataSource = null;
                this.dgv_EmployeeInfo.DataSource = this.objEmployeeBLL.GetEmployees();
            }
        }

        private void tsbtn_ModifyEmployee_Click(object sender, EventArgs e)
        {
            var currentRow = this.dgv_EmployeeInfo.CurrentRow;
            if (currentRow == null)
            {
                MessageBox.Show("请选中需要修改的数据！", "修改提示");
                return;
            }
            string no = currentRow.Cells["EmployeeNo"].Value.ToString();

            EmployeeModel employee = this.objEmployeeBLL.GetSpecifyEmployeeByEmployeeNo(no);
            FrmUpdateEmployee frm = new FrmUpdateEmployee(OperateMode.Modify, employee);
            if (DialogResult.OK == frm.ShowDialog())
            {
                this.dgv_EmployeeInfo.DataSource = null;
                this.dgv_EmployeeInfo.DataSource = this.objEmployeeBLL.GetEmployees();
            }
        }

        private void tsbtn_DeleteEmployee_Click(object sender, EventArgs e)
        {
            var currentRow = this.dgv_EmployeeInfo.CurrentRow;
            if (currentRow == null)
            {
                MessageBox.Show("请选中需要删除的数据！", "删除提示");
                return;
            }
            string name = currentRow.Cells["EmployeeName"].Value.ToString();
            if (DialogResult.OK != MessageBox.Show(string.Format("确认删除【员工名称：{0}】吗？", name), "删除提示", MessageBoxButtons.OKCancel))
                return;
            string no = currentRow.Cells["EmployeeNo"].Value.ToString();

            if (this.objEmployeeBLL.DeleteEmployeeByNo(no))
            {
                MessageBox.Show("删除成功！", "删除提示");
                this.dgv_EmployeeInfo.DataSource = null;
                this.dgv_EmployeeInfo.DataSource = this.objEmployeeBLL.GetEmployees();
            }
            else
            {
                MessageBox.Show("删除失败！", "删除提示");
            }
        }

        private void tsbtn_QueryEmployee_Click(object sender, EventArgs e)
        {
            this.ep_Reminder.Clear();
            int queryMode = this.cbo_EmployeeQueryMode.SelectedIndex;
            string queryCondition = this.txt_QueryCondition.Text.Trim();
            if (queryMode != 0 && queryCondition == string.Empty)
            {
                this.ep_Reminder.SetError(this.txt_QueryCondition, "查询条件不能为空");
                return;
            }
            this.dgv_EmployeeInfo.DataSource = null;
            this.dgv_EmployeeInfo.DataSource = this.objEmployeeBLL.GetEmployees(queryMode, queryCondition);
        }

        #region 查询模式切换事件

        private void cbo_EmployeeQueryMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ep_Reminder.Clear();
            bool toClear = false;
            switch (this.cbo_EmployeeQueryMode.SelectedIndex)
            {
                case 0:
                    toClear = true;
                    break;
                case 1:
                    this.txt_QueryCondition.MaxLength = EmployeeModel.EmployeeNoValidLength;
                    toClear = !EmployeeModel.CheckEmployeeNoIsValid(this.txt_QueryCondition.Text.Trim());
                    break;
                case 2:
                    this.txt_QueryCondition.MaxLength = EmployeeModel.EmployeeNameValidLength;
                    toClear = !EmployeeModel.CheckEmployeeNameIsValid(this.txt_QueryCondition.Text.Trim());
                    break;
            }
            if (toClear)
                this.txt_QueryCondition.Text = string.Empty;
        }
        #endregion
    }
}
