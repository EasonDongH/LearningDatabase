using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using log4net;
using MS.Base;
using MS.Models;
using MS.BLL;

namespace MS.UI
{
    public partial class FrmUpdateEmployee : Form
    {
        private OperateMode currentOperateMode;
        private EmployeeModel global_Employee = null;
        private DepartmentBLL objDepartmentBLL = new DepartmentBLL();
        private EmployeeBLL objEmployeeBLL = new EmployeeBLL();
        private static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private void Init()
        {
            List<DepartmentModel> departments = null;
            departments = this.objDepartmentBLL.GetDepartments();
            this.cbo_DepartmentName.DataSource = departments;
            this.cbo_DepartmentName.DisplayMember = "DepartmentName";
            this.cbo_DepartmentName.ValueMember = "Id";
            if (departments.Count > 0)
                this.cbo_DepartmentName.SelectedIndex = 0;

            this.txt_EmployeeNo.MaxLength = EmployeeModel.EmployeeNoValidLength;
            this.txt_EmployeeName.MaxLength = EmployeeModel.EmployeeNameValidLength;
            this.rtb_Remarks.MaxLength = EmployeeModel.RemarksValidLength;

            if (this.currentOperateMode == OperateMode.Add)
            {
                this.Text = "添加员工";
                this.cb_InJob.Checked = this.rb_Male.Checked = true;
            }
            else if (this.currentOperateMode == OperateMode.Modify)
            {
                this.Text = "修改员工信息";
            }

            if (this.global_Employee != null)
            {
                this.txt_EmployeeNo.Text = this.global_Employee.EmployeeNo;
                this.txt_EmployeeName.Text = this.global_Employee.EmployeeName;
                this.cbo_DepartmentName.Text = this.global_Employee.DepartmentName;
                this.dtp_Birth.Text = Convert.ToDateTime(this.global_Employee.EmployeeBirth).ToShortDateString();
                this.cb_InJob.Checked = this.global_Employee.IsJob;
                this.rb_Male.Checked = this.global_Employee.EmployeeSex == "男" ? true : false;
                this.rtb_Remarks.Text = this.global_Employee.Remarks;
            }
        }

        public FrmUpdateEmployee(OperateMode opm, EmployeeModel employee = null)
        {
            InitializeComponent();//我去额为全额

            this.currentOperateMode = opm;
            this.global_Employee = employee;

            Init();
        }

        private EmployeeModel CheckDataIsValid(EmployeeModel ep)
        {
            string employeeNo = this.txt_EmployeeNo.Text.Trim();
            string employeeName = this.txt_EmployeeName.Text.Trim();
            this.ep_Reminder.Clear();
            if (employeeNo == string.Empty)
            {
                this.ep_Reminder.SetError(this.txt_EmployeeNo, "员工编号不能为空！");
                return null;
            }
            bool isExist = true;
            try
            {
                isExist = this.objEmployeeBLL.CheckEmployeeNoIsExist(employeeNo, ep);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误！错误详情：" + ex.Message);
                return null;
            }
            if (isExist)
            {
                this.ep_Reminder.SetError(this.txt_EmployeeNo, "该员工编号已存在");
                return null;
            }
            // 验证部门名称：非空
            if (employeeName == string.Empty)
            {
                this.ep_Reminder.SetError(this.txt_EmployeeName, "员工名称不能为空");
                return null;
            }
            EmployeeModel employee = new EmployeeModel()
            {
                DepartmentId = this.cbo_DepartmentName.SelectedValue.ToString(),
                EmployeeNo = employeeNo,
                EmployeeName = employeeName,
                EmployeeSex = this.rb_Male.Checked ? "男" : "女",
                EmployeeBirth = Convert.ToDateTime(this.dtp_Birth.Value).ToString("yyyy-MM-dd"),
                IsJob = this.cb_InJob.Checked,
                Remarks = this.rtb_Remarks.Text.Trim()
            };
            return employee;
        }

        private void tsbtn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeModel employee = CheckDataIsValid(this.global_Employee);
                if (employee == null)
                    return;
                if (this.currentOperateMode == OperateMode.Modify && this.global_Employee != null)
                    employee.Id = this.global_Employee.Id;
                if (this.objEmployeeBLL.UpdateEmployee(this.currentOperateMode, employee))
                {
                    MessageBox.Show("保存成功！", "提示");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("保存失败！", "提示");
                    this.DialogResult = DialogResult.No;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存异常，窗体即将关闭！","异常提示");
                log.Error(ex);
            }
            
            this.Close();
        }

        private void tsbtn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
