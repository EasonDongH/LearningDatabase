using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Models;

namespace MSTest
{
    public partial class FrmDepartmentManage : Form
    {
        private List<Department> global_Departments = null;
        private DempartmentManager objDempartmentManager = new DempartmentManager();

        public FrmDepartmentManage()
        {
            InitializeComponent();

            this.cbo_DepartmentQueryMode.SelectedIndex = 0;
            this.dgv_DepartmentInfo.AutoGenerateColumns = false;
            try
            {
                this.global_Departments = objDempartmentManager.GetDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误！错误信息：" + ex.Message);
            }

            this.btn_ModifyConfim.Click += this.btn_ModifyConfim_Click;
            this.btn_AddConfim.Click += this.btn_AddConfim_Click;
            this.dgv_DepartmentInfo.DataSource = this.global_Departments;
            AdjustDepartmentInfoControlState(true, false);
            ClearDepartmentInfoControl();
        }

        private void FrmDepartmentManage_Load(object sender, EventArgs e)
        {
            this.dgv_DepartmentInfo.ClearSelection();// dgv默认不选中行，必须放在load事件
        }

        private void btn_QueryDepartmentInfo_Click(object sender, EventArgs e)
        {
            this.ep_Remind.Clear();
            string condition = this.txt_QueryCondition.Text.Trim();
            List<Department> departments = this.objDempartmentManager.GetDepartments(condition, this.cbo_DepartmentQueryMode.SelectedIndex);
            this.dgv_DepartmentInfo.DataSource = null;
            this.dgv_DepartmentInfo.DataSource = departments;
        }

        private void btn_AddDepartment_Click(object sender, EventArgs e)
        {
            this.ep_Remind.Clear();
            this.lbl_AddRemind.Visible = true;
            this.lbl_ModifyRemind.Visible = false;
            this.txt_DepartmentNo.Focus();
            AdjustDepartmentInfoControlState(false, true);
            ClearDepartmentInfoControl();

            this.btn_AddConfim.Visible = true;
            this.btn_ModifyConfim.Visible = false;
        }

        private void btn_ModifyDepartmentInfo_Click(object sender, EventArgs e)
        {
            this.ep_Remind.Clear();
            if (this.dgv_DepartmentInfo.CurrentRow == null)
                return;

            var department = (from d in this.global_Departments
                              where d.DepartmentNo == this.dgv_DepartmentInfo.CurrentRow.Cells["DepartmentNo"].Value.ToString()
                              select d).FirstOrDefault();
            this.txt_DepartmentNo.Text = department.DepartmentNo;
            this.txt_DepartmentName.Text = department.DepartmentName;
            this.rtb_Remarks.Text = department.Remarks;
            AdjustDepartmentInfoControlState(false, true);
            this.lbl_AddRemind.Visible = false;
            this.lbl_ModifyRemind.Visible = true;
            this.txt_DepartmentNo.Focus();

            this.btn_AddConfim.Visible = false;
            this.btn_ModifyConfim.Visible = true;
        }

        private void btn_DeleteDepartment_Click(object sender, EventArgs e)
        {
            this.ep_Remind.Clear();
            if (this.dgv_DepartmentInfo.CurrentRow == null)
                return;

            string departmentNo = this.dgv_DepartmentInfo.CurrentRow.Cells["DepartmentNo"].Value.ToString();
            this.lbl_AddRemind.Visible = false;
            this.lbl_ModifyRemind.Visible = false;
            if (DialogResult.Yes != MessageBox.Show("确认删除吗？", "提示", MessageBoxButtons.YesNo))
                return;
            try
            {
                if (objDempartmentManager.DeleteDepartmentByNo(departmentNo))
                {
                    this.dgv_DepartmentInfo.DataSource = null;
                    this.global_Departments = objDempartmentManager.GetDepartments();
                    this.dgv_DepartmentInfo.DataSource = this.global_Departments;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误！错误信息：" + ex.Message);
                return;
            }
        }

        private void dgv_DepartmentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ep_Remind.Clear();
            this.lbl_AddRemind.Visible = false;
            this.lbl_ModifyRemind.Visible = false;
            AdjustDepartmentInfoControlState(true, false);

            if (this.dgv_DepartmentInfo.CurrentRow == null)
                return;
            var department = (from d in this.global_Departments
                              where d.DepartmentNo == this.dgv_DepartmentInfo.CurrentRow.Cells["DepartmentNo"].Value.ToString()
                              select d).FirstOrDefault();
            this.txt_DepartmentNo.Text = department.DepartmentNo;
            this.txt_DepartmentName.Text = department.DepartmentName;
            this.rtb_Remarks.Text = department.Remarks;
        }

        /// <summary>
        /// 检查输入数据是否有效
        /// </summary>
        /// <returns>非null：数据有效 null：数据无效</returns>
        private Department CheckDataIsValid(Department dp)
        {
            this.ep_Remind.Clear();
            string departmentNo = this.txt_DepartmentNo.Text.Trim();
            string departmentName = this.txt_DepartmentName.Text.Trim();
            // 验证部门编号：非空且不存在
            if (departmentNo == string.Empty)
            {
                this.ep_Remind.SetError(this.txt_DepartmentNo, "部门编号不能为空！");
                return null;
            }
            bool isExist = true;
            try
            {
                isExist = objDempartmentManager.CheckDepartmentNoIsExist(departmentNo, dp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误！错误详情：" + ex.Message);
                return null;
            }
            if (isExist)
            {
                this.ep_Remind.SetError(this.txt_DepartmentNo, "该部门编号已存在！");
                return null;
            }
            // 验证部门名称：非空
            if (departmentName == string.Empty)
            {
                this.ep_Remind.SetError(this.txt_DepartmentName, "部门名称不能为空！");
                return null;
            }
            Department department = new Department()
            {
                DepartmentNo = departmentNo,
                DepartmentName = departmentName,
                Remarks = this.rtb_Remarks.Text.Trim()
            };

            return department;
        }

        private void AdjustDepartmentInfoControlState(bool txt_IsReadOnly, bool btn_IsEnable)
        {
            foreach (Control c in this.gb_DepartmentInfo.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).ReadOnly = txt_IsReadOnly;
                else if (c is RichTextBox)
                    ((RichTextBox)c).ReadOnly = txt_IsReadOnly;
                else if (c is Button)
                    ((Button)c).Enabled = btn_IsEnable;
            }
        }

        private void ClearDepartmentInfoControl()
        {
            this.txt_DepartmentNo.Text = string.Empty;
            this.txt_DepartmentName.Text = string.Empty;
            this.rtb_Remarks.Text = string.Empty;
        }

        private void btn_AddConfim_Click(object sender, EventArgs e)
        {
            Department department = CheckDataIsValid(null);
            if (department == null)
                return;
            bool operate_Result = false;
            try
            {
                operate_Result = objDempartmentManager.AddDepartment(department);
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败！失败原因：" + ex.Message);
            }

            AdjustDepartmentInfoControlState(true, false);
            this.global_Departments = objDempartmentManager.GetDepartments();
            this.dgv_DepartmentInfo.DataSource = null;
            this.dgv_DepartmentInfo.DataSource = this.global_Departments;
        }

        private void btn_ModifyConfim_Click(object sender, EventArgs e)
        {
            var source = (from d in this.global_Departments
                          where d.DepartmentNo == this.dgv_DepartmentInfo.CurrentRow.Cells["DepartmentNo"].Value.ToString()
                          select d).FirstOrDefault();
            if (source == null)
                return;
            Department dest = CheckDataIsValid(source);
            if (dest == null)
                return;
            dest.Id = source.Id;
            bool operate_Result = false;
            try
            {
                operate_Result = objDempartmentManager.ModifyDepartmentInfo(dest);
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败！失败原因：" + ex.Message);
            }

            AdjustDepartmentInfoControlState(true, false);
            this.lbl_AddRemind.Visible = this.lbl_ModifyRemind.Visible = false;
            this.global_Departments = objDempartmentManager.GetDepartments();
            this.dgv_DepartmentInfo.DataSource = null;
            this.dgv_DepartmentInfo.DataSource = this.global_Departments;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            AdjustDepartmentInfoControlState(true, false);
            ClearDepartmentInfoControl();
            this.lbl_AddRemind.Visible = this.lbl_ModifyRemind.Visible = false;
        }

    }
}
