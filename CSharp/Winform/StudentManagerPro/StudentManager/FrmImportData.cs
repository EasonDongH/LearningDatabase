using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;

namespace StudentManager
{
    public partial class FrmImportData : Form
    {
        private List<Student> list = null;

        public FrmImportData()
        {
            InitializeComponent();
        }
        private void btnChoseExcel_Click(object sender, EventArgs e)
        {
            //打开文件
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = openFile.FileName;//获取文件路径
                list = new DAL.Helper.ImportDataFromExcel().GetStudentByExcel(path);
                //显示数据
                this.dgvStudentList.DataSource = null;
                this.dgvStudentList.AutoGenerateColumns = false;
                this.dgvStudentList.DataSource = list;
            }
        }
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Common.DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList, e);
        }
        //保存到数据库
        private void btnSaveToDB_Click(object sender, EventArgs e)
        {
            if (list == null || list.Count == 0)
            {
                MessageBox.Show("目前没有要导入的数据！", "导入提示");
                return;
            }
            try
            {
                if (new DAL.Helper.ImportDataFromExcel().Import(this.list))
                {
                    MessageBox.Show("数据导入成功！", "导入提示");
                    this.dgvStudentList.DataSource = null;
                    this.list.Clear();
                }
                else
                {
                    MessageBox.Show("数据导入失败！", "导入提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据导入失败！具体原因：" + ex.Message, "导入提示");
            }
        }
    }
}
