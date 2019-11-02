using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DAL;
using Models.Ext;
using Models;


namespace StudentManager
{
    public partial class FrmStudentManage : Form
    {

        private StudentClassService objClassService = new StudentClassService();
        private StudentService objStuService = new StudentService();
        private List<StudentExt> list = null;

        #region
        public FrmStudentManage()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClass.DataSource = objClassService.GetAllClasses();
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";
        }
        //按照班级查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("请选则班级！", "提示");
                return;
            }
            this.dgvStudentList.AutoGenerateColumns = false;    //不显示未封装的属性
            //执行查询并绑定数据
            list = objStuService.GetStudentByClass(this.cboClass.Text);
            this.dgvStudentList.DataSource = list;
            new Common.DataGridViewStyle().DgvStyle1(this.dgvStudentList);

            //让标题彻底居中，消除排序按钮的影响
            foreach (DataGridViewColumn item in this.dgvStudentList.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            ////增加指定行的高亮显示
            //this.dgvStudentList.Rows[2].DefaultCellStyle.BackColor = Color.Blue;
            //this.dgvStudentList.Rows[3].DefaultCellStyle.BackColor = Color.Blue;
            //this.dgvStudentList.Rows[4].DefaultCellStyle.BackColor = Color.Blue;
            //this.dgvStudentList.Rows[5].DefaultCellStyle.BackColor = Color.Blue;

            //this.dgvStudentList.Rows[2].DefaultCellStyle.ForeColor = Color.White;
            //this.dgvStudentList.Rows[3].DefaultCellStyle.ForeColor = Color.White;
            //this.dgvStudentList.Rows[4].DefaultCellStyle.ForeColor = Color.White;
            //this.dgvStudentList.Rows[5].DefaultCellStyle.ForeColor = Color.White;
        }
        //根据学号查询
        private void btnQueryById_Click(object sender, EventArgs e)
        {
            if (this.txtStudentId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入学号！", "提示信息");
                this.txtStudentId.Focus();
                return;
            }
            if (!Common.DataValidate.IsInteger(this.txtStudentId.Text.Trim()))
            {
                MessageBox.Show("学号必须是正整数！", "提示信息");
                this.txtStudentId.SelectAll();
                this.txtStudentId.Focus();
                return;
            }
            StudentExt objStudent = objStuService.GetStudentById(this.txtStudentId.Text.Trim());
            if (objStudent == null)
            {
                MessageBox.Show("学员信息不存在！", "提示信息");
                this.txtStudentId.Focus();
            }
            else
            {
                FrmStudentInfo objStuInfo = new FrmStudentInfo(objStudent);
                objStuInfo.Show();
            }
        }
        private void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtStudentId.Text.Trim().Length != 0 && e.KeyValue == 13)
                btnQueryById_Click(null, null);
        }
        //双击选中的学员对象并显示详细信息
        private void dgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvStudentList.CurrentRow != null)
            {
                string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
                this.txtStudentId.Text = studentId;
                btnQueryById_Click(null, null);
            }
        }
        //修改学员对象
        private void btnEidt_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0)
            {
                MessageBox.Show("没有任何需要修改的学员信息！", "提示");
                return;
            }
            if (this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("请选中需要修改的学员信息！", "提示");
                return;
            }
            //获取学号
            string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            StudentExt objStudent = objStuService.GetStudentById(studentId); //根据学号获取学员对象
            //显示修改学员信息窗口
            FrmEditStudent objEditStudent = new FrmEditStudent(objStudent);
            objEditStudent.ShowDialog();
            btnQuery_Click(null, null);   //同步刷新显示
        }
        //删除学员对象
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0)
            {
                MessageBox.Show("没有任何需要删除的学员！", "提示");
                return;
            }
            if (this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("请选中需要删除的学员！", "提示");
                return;
            }
            //删除确认
            DialogResult result = MessageBox.Show("确实要删除吗？", "删除确认", MessageBoxButtons.OKCancel,
                 MessageBoxIcon.Question);
            if (result == DialogResult.Cancel) return;
            //获取学号并调用后台执行删除
            string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            try
            {
                if (objStuService.DeleteStudentById(studentId) == 1)
                    btnQuery_Click(null, null);  //同步刷新显示
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示信息");
            }
        }
        //姓名降序
        private void btnNameDESC_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0) return;
            list.Sort(new NameDESC());
            //this.dgvStudentList.DataSource = null;
            //this.dgvStudentList.DataSource = list;
            this.dgvStudentList.Refresh();
        }
        //学号降序
        private void btnStuIdDESC_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0) return;
            list.Sort(new StuIdDESC());
            this.dgvStudentList.Refresh();
        }
        //添加行号
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Common.DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList, e);
        }
        //添加行号另一个方法
        //private void dgvStudentList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        //{
        //    e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        //}

        #endregion

        //打印当前学员信息
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //如果没有列表显示，则不显示打印
            if (this.dgvStudentList.RowCount == 0 || this.dgvStudentList.CurrentRow == null) return;
            //获取当前行的学号
            string stuId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            //根据学号获取学员对象
            StudentExt student = objStuService.GetStudentById(stuId);
            //调用excel模块实现打印预览
            ExcelPrint.PrintStudent printStudent = new ExcelPrint.PrintStudent();
            printStudent.ExecPrint(student);
        }

        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    #region 实现排序
    class NameDESC : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return y.StudentName.CompareTo(x.StudentName);
        }
    }
    class StuIdDESC : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return y.StudentId.CompareTo(x.StudentId);
        }
    }
    #endregion
}