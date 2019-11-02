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

namespace UpdatePro
{
    public partial class FrmUpdateMain : Form
    {
        private UpdateManage updateManage;

        public FrmUpdateMain()
        {
            InitializeComponent();
            this.updateManage = new UpdateManage(ShowDownloadProgress);

            foreach (var item in updateManage.UpdateInfo.RemoteUpdateFiles)
            {
                string[] data = new string[] { item.FileName, item.FileSize, "0%" };
                this.lvUpdateFile.Items.Add(new ListViewItem(data));
            }
        }

        private void ShowDownloadProgress(int fileIndex, int percent)
        {
            this.lvUpdateFile.Items[fileIndex+1].SubItems[2].Text = percent + "%";
            this.progressBar1.Value = percent;
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            this.updateManage.DownloadFile();
        }
    }
}
