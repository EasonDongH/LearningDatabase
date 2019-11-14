using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FTP.Base;

namespace FTPServer
{
    public partial class MainForm : Form
    {
        private FtpServer _ftpServer = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            EnableWhenInit();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void lblOpenFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtServerRootDirectory.Text = fbd.SelectedPath;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (this.txtUserName.Text.Trim() == string.Empty || this.txtUserPwd.Text.Trim() == string.Empty)
            {
                MessageBox.Show("用户名或密码不能为空！");
                return;
            }
            this._ftpServer.AddUser(this.txtUserName.Text.Trim(), this.txtUserPwd.Text.Trim());
            ListViewItem lvi = new ListViewItem();
            lvi.Text = this.txtUserName.Text.Trim();
            lvi.SubItems.AddRange(new string[]{this.txtUserPwd.Text.Trim()});
            this.lvUsers.Items.Add(lvi);
        }

        private void StartServer()
        {
            if (this.txtServerIP.Text.Trim() == string.Empty || this.txtServerPort.Text.Trim() == string.Empty)
            {
                MessageBox.Show("FTP服务器IP或端口不能为空！");
                return;
            }
            if (this.txtServerRootDirectory.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请选择服务器文件根目录！");
                return;
            }
            if (System.IO.Directory.Exists(this.txtServerRootDirectory.Text.Trim()) == false)
            {
                MessageBox.Show("填写的目录不存在！");
                return;
            }
            try
            {
                this._ftpServer = new FtpServer(this.txtServerIP.Text.Trim(), Convert.ToInt32(this.txtServerPort.Text.Trim()), this.txtServerRootDirectory.Text.Trim());
                this._ftpServer.Start();
                EnableWhenStartServer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StopServer()
        {
            this._ftpServer.Stop();
            this._ftpServer = null;
            EnableWhenInit();
        }

        private void EnableWhenInit()
        {
            this.btnStartServer.Enabled = true;
            this.btnAddUser.Enabled = this.btnStopServer.Enabled = false;
        }

        private void EnableWhenStartServer()
        {
            this.btnStartServer.Enabled = false;
            this.btnAddUser.Enabled = this.btnStopServer.Enabled = true;
        }
    }
}
