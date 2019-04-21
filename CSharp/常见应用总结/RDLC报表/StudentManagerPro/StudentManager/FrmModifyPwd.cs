using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DAL;


namespace StudentManager
{
    public partial class FrmModifyPwd : Form
    {
        public FrmModifyPwd()
        {
            InitializeComponent();
        }
        //修改密码
        private void btnModify_Click(object sender, EventArgs e)
        {
            #region 密码验证
            if (this.txtOldPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入原密码！", "提示信息");
                this.txtOldPwd.Focus();
                return;
            }
            if (this.txtOldPwd.Text.Trim() != Program.currentAdmin.LoginPwd)
            {
                MessageBox.Show("请输入的原密码不正确！", "提示信息");
                this.txtOldPwd.Focus();
                this.txtOldPwd.SelectAll();
                return;
            }
            if (this.txtNewPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入不少于6位的新密码！", "提示信息");
                this.txtNewPwd.Focus();
                return;
            }
            if (this.txtNewPwd.Text.Trim().Length < 6)
            {
                MessageBox.Show("新密码长度不能少于6位！", "提示信息");
                this.txtNewPwd.Focus();
                return;
            }
            if (this.txtNewPwdConfirm.Text.Trim().Length == 0)
            {
                MessageBox.Show("请再次输入新密码！", "提示信息");
                this.txtNewPwdConfirm.Focus();
                return;
            }
            if (this.txtNewPwdConfirm.Text.Trim() != this.txtNewPwd.Text.Trim())
            {
                MessageBox.Show("两次输入的新密码不一致！", "提示信息");
                return;
            }
            #endregion
            //修改密码
            try
            {
                Admin objAdmin = new Admin()
                {
                    LoginId = Program.currentAdmin.LoginId,
                    LoginPwd = this.txtNewPwd.Text.Trim()
                };
                if (new AdminService().ModifyPwd(objAdmin) == 1)
                {
                    MessageBox.Show("密码修改成功，请妥善保管！", "成功提示");
                    //同时修改当前保存的用户密码
                    Program.currentAdmin.LoginPwd = this.txtNewPwd.Text.Trim();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
