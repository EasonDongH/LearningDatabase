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
    public partial class FrmUpdateEmployee : Form
    {
        private Employee global_Employee = null;
        private DempartmentManager objDempartmentManager = new DempartmentManager();
        private EmployeeManager objEmployeeManager = new EmployeeManager();
        public FrmUpdateEmployee()
        {
            InitializeComponent();

            var departments = this.objDempartmentManager.GetDepartments();
            this.cbo_DepartmentName.DataSource = departments;
            this.cbo_DepartmentName.DisplayMember = "DepartmentName";
            this.cbo_DepartmentName.ValueMember = "Id";

            if (departments.Count > 0)
                this.cbo_DepartmentName.SelectedIndex = 0;
            this.cbo_IsJob.SelectedIndex = this.cbo_Sex.SelectedIndex = 0;

            this.Text = "添加员工";
            this.btn_Confim.Click += this.btn_AddConfim_Click;
        }

        public FrmUpdateEmployee(Employee employee):this()
        {
            this.global_Employee = employee;
            this.txt_EmployeeNo.Text = employee.EmployeeNo;
            this.txt_EmployeeName.Text = employee.EmployeeName;
            this.cbo_DepartmentName.Text = employee.DepartmentName;
            this.cbo_IsJob.Text = employee.IsJob? "是":"否";
            this.cbo_Sex.Text = employee.EmployeeSex;
            this.dtp_birth.Text = Convert.ToDateTime(employee.EmployeeBirth).ToShortDateString();
            this.rtb_Remarks.Text = employee.Remarks;

            this.Text = "修改员工信息";
            this.btn_Confim.Click -= this.btn_AddConfim_Click;
            this.btn_Confim.Click += this.btn_ModifyConfim_Click;
        }

        private void btn_AddConfim_Click(object sender, EventArgs e)
        {
            string employeeNo = this.txt_EmployeeNo.Text.Trim();
            string employeeName = this.txt_EmployeeName.Text.Trim();
            this.ep_Remind.Clear();
            if (employeeNo == string.Empty)
            {
                this.ep_Remind.SetError(this.txt_EmployeeNo, "员工编号不能为空！");
                return;
            }
            try
            {
                if (this.objEmployeeManager.CheckEmployeeNoIsExist(employeeNo))
                {
                    this.ep_Remind.SetError(this.txt_EmployeeNo, "员工编号已存在！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误！错误详情：" + ex.Message);
                return;
            }
            Employee employee = new Employee()
            {
                DepartmentId = this.cbo_DepartmentName.SelectedValue.ToString(),
                EmployeeNo = employeeNo,
                EmployeeName = employeeName,
                EmployeeSex = this.cbo_Sex.Text,
                EmployeeBirth = Convert.ToDateTime(this.dtp_birth.Value).ToString("yyyy-MM-dd"),
                IsJob = this.cbo_IsJob.SelectedIndex == 0 ? true : false,
                Remarks = this.rtb_Remarks.Text.Trim()
            };
            try
            {
                if (this.objEmployeeManager.AddEmployee(employee))
                {
                    this.DialogResult = DialogResult.Yes;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_ModifyConfim_Click(object sender, EventArgs e)
        {
            string employeeNo = this.txt_EmployeeNo.Text.Trim();
            string employeeName = this.txt_EmployeeName.Text.Trim();
            this.ep_Remind.Clear();
            if (employeeNo == string.Empty)
            {
                this.ep_Remind.SetError(this.txt_EmployeeNo, "员工编号不能为空！");
                return;
            }
            try
            {
                if (this.objEmployeeManager.CheckEmployeeNoIsExist(employeeNo, this.global_Employee.Id))
                {
                    this.ep_Remind.SetError(this.txt_EmployeeNo, "员工编号已存在！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误！错误详情："+ex.Message);
                return;
            }
           
            if (employeeName == string.Empty)
            {
                this.ep_Remind.SetError(this.txt_EmployeeName, "员工姓名不能为空！");
                return;
            }
            Employee employee = new Employee
            {
                Id = this.global_Employee.Id,
                DepartmentId = this.cbo_DepartmentName.SelectedValue.ToString(),
                DepartmentName = this.cbo_DepartmentName.Text,
                EmployeeNo = employeeNo,
                EmployeeName = employeeName,
                EmployeeBirth = Convert.ToDateTime(this.dtp_birth.Text).ToString("yyyy-MM-dd"),
                IsJob = this.cbo_IsJob.Text=="是",
                EmployeeSex = this.cbo_Sex.Text,
                Remarks = this.rtb_Remarks.Text.Trim()
            };
            try
            {
                if (this.objEmployeeManager.ModfiyEmployeeInfo(employee))
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误！错误详情："+ex.Message);
                return;
            }
            
            this.Close();
        }
    }
}
