using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FTP.Base;
using FTP.Model;
using System.IO;

namespace FTPDemo
{
    public partial class MainForm : Form
    {
        private FtpClient _ftp = null;
        private DateTime _begin;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            EnableWhenInit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.lvServerFile.Items.Clear();
            this._ftp = null;
            EnableWhenInit();
        }

        private void lblOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            DownloadFile();
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            UploadFile();
        }

        private void lvServerFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FileType type = (FileType)this.lvServerFile.FocusedItem.Tag;
            if (type == FileType.FILE)
                return;
            string path = this.lvServerFile.FocusedItem.SubItems[2].Text.ToString() + "/" + this.lvServerFile.FocusedItem.SubItems[1].Text.ToString();
            RefreshListView(path);
        }

        private void lvServerFile_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (this._ftp == null)
                return;
            string path = this.lvServerFile.Columns[1].Tag as string;
            RefreshListView(path);
        }

        private bool IsValid()
        {
            if (this.txtServerIP.Text.Trim() == string.Empty)
            {
                MessageBox.Show("服务器IP不能为空！");
                return false;
            }
            return true;
        }

        private void Login()
        {
            try
            {
                if (IsValid() == false)
                    return;
                this._ftp = new FtpClient(this.txtServerIP.Text.Trim(), this.txtServerUser.Text.Trim(), this.txtServerPassword.Text.Trim());
                this._ftp.CompleteDownload = CompleteDownload;
                this._ftp.FailDownload = FailDownload;
                this._ftp.CompleteUpload = CompleteUpload;
                this._ftp.FailUpload = FailUpload;
                this.lvServerFile.Columns[0].Tag = this.lvServerFile.Columns[1].Tag = string.Empty;
                RefreshListView(string.Empty);
                EnableWhenLogin();
            }
            catch (Exception ex)
            {
                this._ftp = null;
                MessageBox.Show(ex.Message);
            }
        }

        private void EnableWhenInit()
        {
            this.btnLogin.Enabled = true;
            this.txtServerIP.Enabled = this.txtServerPassword.Enabled = this.txtServerUser.Enabled = true;
            this.btnDownloadFile.Enabled = this.btnQuit.Enabled = this.btnUploadFile.Enabled = false;
        }

        private void EnableWhenLogin()
        {
            this.btnLogin.Enabled = false;
            this.txtServerIP.Enabled = this.txtServerPassword.Enabled = this.txtServerUser.Enabled = false;
            this.btnDownloadFile.Enabled = this.btnQuit.Enabled = this.btnUploadFile.Enabled = true;
        }

        private void OpenFile()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtLocalPath.Text = fbd.SelectedPath;
            }
        }

        private void DownloadFile()
        {
            if (IsValid() == false)
                return;
            var select = GetFocusedItem();
            if (select == null)
            {
                MessageBox.Show("请选择要下载的文件！");
                return;
            }
            if (this.txtLocalPath.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请选择下载文件保存路径！");
                return;
            }
            FileType type = (FileType)select.Tag;
            if (type == FileType.FOLDER)
            {
                MessageBox.Show("暂不支持文件夹下载！");
                return;
            }
            this._begin = DateTime.Now;
            this._ftp.Download(this.txtLocalPath.Text.Trim(), this.lvServerFile.FocusedItem.SubItems[2].Text.ToString(), this.lvServerFile.FocusedItem.SubItems[1].Text.ToString());
        }

        private void UploadFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            try
            {
                string relativePath = this.lvServerFile.Columns[0].Tag as string;
                this._begin = DateTime.Now;
                this._ftp.Upload(relativePath, ofd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CompleteDownload()
        {
            this.BeginInvoke(new MethodInvoker(delegate
                {
                    AppendText("下载完成！耗时：" + DateTime.Now.Subtract(this._begin).TotalSeconds + "秒");
                }));
        }

        private void CompleteUpload()
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                AppendText("上传完成！耗时：" + DateTime.Now.Subtract(this._begin).TotalSeconds + "秒");
                string relativePath = this.lvServerFile.Columns[0].Tag as string;
                RefreshListView(relativePath);
            }));
        }

        private void FailDownload(string ex)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                AppendText("下载失败！失败信息：" + ex);
            }));
        }

        private void FailUpload(string ex)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                AppendText("上传失败！失败信息：" + ex);
            }));
        }

        private ListViewItem GetFocusedItem()
        {
            return this.lvServerFile.FocusedItem;
        }

        private void AppendText(string info)
        {
            this.rtbInfo.Text += string.Format("【{0}】{1}\n", DateTime.Now.ToShortTimeString(), info);
        }

        private void RefreshListView(string relativePath)
        {
            if (relativePath == null)
                return;
            List<FtpFileModel> files = this._ftp.GetFilesDetailList(relativePath);
            ShowFTPFileInfo(files);
        }

        private void ShowFTPFileInfo(List<FtpFileModel> files)
        {
            this.lvServerFile.Items.Clear();
            if (files.Count != 0)
            {
                // 列头数据绑定：0-当前相对路径 1-当前路径的父节点路径
                this.lvServerFile.Columns[0].Tag = files[0].ParentPath;
                this.lvServerFile.Columns[1].Tag = files[0].ParentPath != string.Empty ? files[0].ParentPath.Substring(0, files[0].ParentPath.LastIndexOf('/')) : string.Empty;
            }
            foreach (var item in files)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = item.FileType;
                lvi.SubItems.AddRange(new string[]{
                        item.FileName, item.ParentPath
                    });
                lvi.ImageIndex = (int)item.FileType;
                this.lvServerFile.Items.Add(lvi);
            }
        }
    }
}
