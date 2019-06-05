using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSTest
{
    public partial class FrmEmployeeManage : Form
    {
        private EmployeeManager objEmployeeManager = new EmployeeManager();

        public FrmEmployeeManage()
        {
            InitializeComponent();

            this.cbo_EmployeeQueryMode.SelectedIndex = 0;
            this.dgv_EmployeeInfo.AutoGenerateColumns = false;
            try
            {
                this.dgv_EmployeeInfo.DataSource = objEmployeeManager.GetEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误！错误信息：" + ex.Message);
            }
        }

        private void btn_QueryEmployeeInfo_Click(object sender, EventArgs e)
        {
            string condition = this.txt_QueryCondition.Text.Trim();
            List<Employee> query_Result = this.objEmployeeManager.GetEmployees(condition,this.cbo_EmployeeQueryMode.SelectedIndex);
            this.dgv_EmployeeInfo.DataSource = null;
            this.dgv_EmployeeInfo.DataSource = query_Result;
        }

        private void btn_AddEmployee_Click(object sender, EventArgs e)
        {
            FrmUpdateEmployee frm = new FrmUpdateEmployee();
            if (DialogResult.Yes == frm.ShowDialog())
            {
                this.dgv_EmployeeInfo.DataSource = null;
                this.dgv_EmployeeInfo.DataSource = this.objEmployeeManager.GetEmployees();
            }
        }

        private void btn_DeleteEmployee_Click(object sender, EventArgs e)
        {
            if (this.dgv_EmployeeInfo.CurrentRow == null)
                return;
            string eno = this.dgv_EmployeeInfo.CurrentRow.Cells["EmployeeNo"].Value.ToString();
            if (DialogResult.Yes != MessageBox.Show("确认删除吗？", "提示", MessageBoxButtons.YesNo))
                return;
            try
            {
                if (this.objEmployeeManager.DeleteEmployeeByNo(eno))
                {
                    this.dgv_EmployeeInfo.DataSource = null;
                    this.dgv_EmployeeInfo.DataSource = this.objEmployeeManager.GetEmployees();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误！错误详情：" + ex.Message);
            }
        }

        private void btn_ModifyEmployeeInfo_Click(object sender, EventArgs e)
        {
            if (this.dgv_EmployeeInfo.CurrentRow == null)
                return;
            string employeeNo = this.dgv_EmployeeInfo.CurrentRow.Cells["EmployeeNo"].Value.ToString();
            var tmpEmployee = this.objEmployeeManager.GetSpecifyEmployeeByEmployeeNo(employeeNo);
            FrmUpdateEmployee frm = new FrmUpdateEmployee(tmpEmployee);
            if (DialogResult.Yes == frm.ShowDialog())
            {
                this.dgv_EmployeeInfo.DataSource = null;
                this.dgv_EmployeeInfo.DataSource = this.objEmployeeManager.GetEmployees();
            }
        }
    }
}
