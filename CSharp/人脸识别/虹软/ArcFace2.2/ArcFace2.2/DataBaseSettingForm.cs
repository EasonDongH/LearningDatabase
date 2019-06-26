using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArcFace2._2
{
    public enum DataBaseSettingState
    {
        Add, Modify, Delete, Query
    }

    public partial class DataBaseSettingForm : Form
    {
        private string connString = "server={0};database={1};user id={2};password={3};charset=utf8;Allow User Variables=True";
        private DataBaseSettingState current_State;

        public DataBaseSettingForm(DataBaseSettingState state)
        {
            InitializeComponent();

            this.current_State = state;
        }

        private void tsbtn_Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool IsValid()
        {
            this.ep_Reminder.Clear();
            if (this.txt_Server.Text.Trim() == string.Empty)
            {
                this.ep_Reminder.SetError(this.txt_Server, "库服务器IP不能为空");
                return false;
            }
            if (this.txt_DbName.Text.Trim() == string.Empty)
            {
                this.ep_Reminder.SetError(this.txt_DbName, "数据库名称不能为空");
                return false;
            }
            if (this.txt_UserId.Text.Trim() == string.Empty)
            {
                this.ep_Reminder.SetError(this.txt_UserId, "用户名不能为空");
                return false;
            }
            if (this.txt_Psw.Text.Trim() == string.Empty)
            {
                this.ep_Reminder.SetError(this.txt_Psw, "密码不能为空");
            }
            return true;
        }

        private void OnSave()
        {
            string server, dbName, userId, psw;
            server = this.txt_Server.Text.Trim();
            dbName = this.txt_DbName.Text.Trim();
            userId = this.txt_UserId.Text.Trim();
            psw = this.txt_Psw.Text.Trim();

            ArcFace.DBUtil.MySQLHelper.ConnString = string.Format(this.connString, server, dbName, userId, psw);
        }

        private void tsbtn_Save_Click(object sender, EventArgs e)
        {
            if (!IsValid())
                return;
            OnSave();
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tsbtn_TestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();

                using(ArcFace.DBUtil.MySQLHelper.Conn)
                {
                    MessageBox.Show("连接成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("连接异常！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
