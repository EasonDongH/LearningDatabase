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
    public partial class FrmUserLogin : Form
    {
        public FrmUserLogin()
        {
            InitializeComponent();
        }


        //登录
        private void btnLogin_Click(object sender, EventArgs e)
        {
            #region 数据验证
            //【1】数据验证
            if (this.txtLoginId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入登录账号！", "提示信息");
                this.txtLoginId.Focus();
                return;
            }
            if (!Common.DataValidate.IsInteger(this.txtLoginId.Text.Trim()))
            {
                MessageBox.Show("登录账号必须是整数！", "提示信息");
                this.txtLoginId.Focus();
                return;
            }
            if (this.txLoginPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入登录密码！", "提示信息");
                this.txLoginPwd.Focus();
                return;
            }
            #endregion
            //封装用户信息对象
            Admin objAdmin = new Admin()
            {
                LoginId = Convert.ToInt32(this.txtLoginId.Text.Trim()),
                LoginPwd = this.txLoginPwd.Text.Trim()
            };
            //Admin objAdmin = new Admin();
            //objAdmin .LoginId=Convert.ToInt32(this.txtUserAccount.Text.Trim());
            //objAdmin.LoginPwd =  this.txtUserPwd.Text.Trim();
            //调用后台登录方法
            try
            {
                Program.currentAdmin = new AdminService().AdminLogin(objAdmin);
                if (Program.currentAdmin != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示信息");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作异常");
            }
        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region 改善用户体验
        private void txtLoginId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txLoginPwd.Focus();
                this.txLoginPwd.SelectAll();
            }
        }
        private void txtLoginPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnLogin_Click(null, null);
            }
        }
        #endregion
    }
}
