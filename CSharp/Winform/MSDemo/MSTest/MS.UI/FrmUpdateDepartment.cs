using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MS.Base;
using MS.Models;
using MS.BLL;

namespace MS.UI
{
    public partial class FrmUpdateDepartment : Form
    {
        private OperateMode currentOperateMode;
        private DepartmentModel global_Department = null;
        private DepartmentBLL objDepartmentBLL = new DepartmentBLL();

        private void Init()
        {
            this.txt_DepartmentNo.MaxLength = DepartmentModel.DepartmentNoValidLength;
            this.txt_DepartmentName.MaxLength = DepartmentModel.DepartmentNameValidLength;
            this.rtb_Remarks.MaxLength = DepartmentModel.RemarksValidLength;

            if (this.currentOperateMode == OperateMode.Add)
            {
                this.Text = "添加部门";
            }
            else if (this.currentOperateMode == OperateMode.Modify)
            {
                this.Text = "修改部门信息";
            }

            if (this.global_Department  != null)
            {
                this.txt_DepartmentNo.Text = this.global_Department.DepartmentNo;
                this.txt_DepartmentName.Text = this.global_Department.DepartmentName;
                this.rtb_Remarks.Text = this.global_Department.Remarks;
            }
        }

        public FrmUpdateDepartment(OperateMode opm, DepartmentModel department=null)
        {
            InitializeComponent();

            this.currentOperateMode = opm;
            this.global_Department = department;

            Init();
        }

        /// <summary>
        /// 检查输入数据是否有效
        /// </summary>
        /// <returns>非null：数据有效 null：数据无效</returns>
        private DepartmentModel CheckDataIsValid(DepartmentModel dp)
        {
            this.ep_Reminder.Clear();
            string departmentNo = this.txt_DepartmentNo.Text.Trim();
            string departmentName = this.txt_DepartmentName.Text.Trim();
            // 验证部门编号：非空且不存在
            if (departmentNo == string.Empty)
            {
                this.ep_Reminder.SetError(this.txt_DepartmentNo, "部门编号不能为空");
                return null;
            }
            bool isExist = true;
            try
            {
                isExist = this.objDepartmentBLL.CheckDepartmentNoIsExist(departmentNo, dp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误！错误详情：" + ex.Message);
                return null;
            }
            if (isExist)
            {
                this.ep_Reminder.SetError(this.txt_DepartmentNo, "该部门编号已存在");
                return null;
            }
            // 验证部门名称：非空
            if (departmentName == string.Empty)
            {
                this.ep_Reminder.SetError(this.txt_DepartmentName, "部门名称不能为空");
                return null;
            }
            DepartmentModel department = new DepartmentModel()
            {
                DepartmentNo = departmentNo,
                DepartmentName = departmentName,
                Remarks = this.rtb_Remarks.Text.Trim()
            };

            return department;
        }

        private void tsbtn_Save_Click(object sender, EventArgs e)
        {
            DepartmentModel department = CheckDataIsValid(this.global_Department);
            if (department == null)
                return;
            if (this.currentOperateMode == OperateMode.Modify && this.global_Department != null)
                department.Id = this.global_Department.Id;
            if (this.objDepartmentBLL.UpdateDepartment(this.currentOperateMode, department))
            {
                MessageBox.Show("保存成功！", "提示");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("保存失败！", "提示");
                this.DialogResult = DialogResult.No;
            }
            this.Close();
        }

        private void tsbtn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
