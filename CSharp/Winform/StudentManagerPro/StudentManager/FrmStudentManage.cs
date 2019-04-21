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
            //��ʼ���༶������
            this.cboClass.DataSource = objClassService.GetAllClasses();
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";
        }
        //���հ༶��ѯ
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��༶��", "��ʾ");
                return;
            }
            this.dgvStudentList.AutoGenerateColumns = false;    //����ʾδ��װ������
            //ִ�в�ѯ��������
            list = objStuService.GetStudentByClass(this.cboClass.Text);
            this.dgvStudentList.DataSource = list;
            new Common.DataGridViewStyle().DgvStyle1(this.dgvStudentList);

            //�ñ��⳹�׾��У���������ť��Ӱ��
            foreach (DataGridViewColumn item in this.dgvStudentList.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            ////����ָ���еĸ�����ʾ
            //this.dgvStudentList.Rows[2].DefaultCellStyle.BackColor = Color.Blue;
            //this.dgvStudentList.Rows[3].DefaultCellStyle.BackColor = Color.Blue;
            //this.dgvStudentList.Rows[4].DefaultCellStyle.BackColor = Color.Blue;
            //this.dgvStudentList.Rows[5].DefaultCellStyle.BackColor = Color.Blue;

            //this.dgvStudentList.Rows[2].DefaultCellStyle.ForeColor = Color.White;
            //this.dgvStudentList.Rows[3].DefaultCellStyle.ForeColor = Color.White;
            //this.dgvStudentList.Rows[4].DefaultCellStyle.ForeColor = Color.White;
            //this.dgvStudentList.Rows[5].DefaultCellStyle.ForeColor = Color.White;
        }
        //����ѧ�Ų�ѯ
        private void btnQueryById_Click(object sender, EventArgs e)
        {
            if (this.txtStudentId.Text.Trim().Length == 0)
            {
                MessageBox.Show("������ѧ�ţ�", "��ʾ��Ϣ");
                this.txtStudentId.Focus();
                return;
            }
            if (!Common.DataValidate.IsInteger(this.txtStudentId.Text.Trim()))
            {
                MessageBox.Show("ѧ�ű�������������", "��ʾ��Ϣ");
                this.txtStudentId.SelectAll();
                this.txtStudentId.Focus();
                return;
            }
            StudentExt objStudent = objStuService.GetStudentById(this.txtStudentId.Text.Trim());
            if (objStudent == null)
            {
                MessageBox.Show("ѧԱ��Ϣ�����ڣ�", "��ʾ��Ϣ");
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
        //˫��ѡ�е�ѧԱ������ʾ��ϸ��Ϣ
        private void dgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvStudentList.CurrentRow != null)
            {
                string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
                this.txtStudentId.Text = studentId;
                btnQueryById_Click(null, null);
            }
        }
        //�޸�ѧԱ����
        private void btnEidt_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0)
            {
                MessageBox.Show("û���κ���Ҫ�޸ĵ�ѧԱ��Ϣ��", "��ʾ");
                return;
            }
            if (this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("��ѡ����Ҫ�޸ĵ�ѧԱ��Ϣ��", "��ʾ");
                return;
            }
            //��ȡѧ��
            string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            StudentExt objStudent = objStuService.GetStudentById(studentId); //����ѧ�Ż�ȡѧԱ����
            //��ʾ�޸�ѧԱ��Ϣ����
            FrmEditStudent objEditStudent = new FrmEditStudent(objStudent);
            objEditStudent.ShowDialog();
            btnQuery_Click(null, null);   //ͬ��ˢ����ʾ
        }
        //ɾ��ѧԱ����
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0)
            {
                MessageBox.Show("û���κ���Ҫɾ����ѧԱ��", "��ʾ");
                return;
            }
            if (this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("��ѡ����Ҫɾ����ѧԱ��", "��ʾ");
                return;
            }
            //ɾ��ȷ��
            DialogResult result = MessageBox.Show("ȷʵҪɾ����", "ɾ��ȷ��", MessageBoxButtons.OKCancel,
                 MessageBoxIcon.Question);
            if (result == DialogResult.Cancel) return;
            //��ȡѧ�Ų����ú�ִ̨��ɾ��
            string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            try
            {
                if (objStuService.DeleteStudentById(studentId) == 1)
                    btnQuery_Click(null, null);  //ͬ��ˢ����ʾ
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ʾ��Ϣ");
            }
        }
        //��������
        private void btnNameDESC_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0) return;
            list.Sort(new NameDESC());
            //this.dgvStudentList.DataSource = null;
            //this.dgvStudentList.DataSource = list;
            this.dgvStudentList.Refresh();
        }
        //ѧ�Ž���
        private void btnStuIdDESC_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0) return;
            list.Sort(new StuIdDESC());
            this.dgvStudentList.Refresh();
        }
        //����к�
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Common.DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList, e);
        }
        //����к���һ������
        //private void dgvStudentList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        //{
        //    e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        //}

        #endregion

        //��ӡ��ǰѧԱ��Ϣ
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //���û���б���ʾ������ʾ��ӡ
            if (this.dgvStudentList.RowCount == 0 || this.dgvStudentList.CurrentRow == null) return;
            //��ȡ��ǰ�е�ѧ��
            string stuId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            //����ѧ�Ż�ȡѧԱ����
            StudentExt student = objStuService.GetStudentById(stuId);
            //����excelģ��ʵ�ִ�ӡԤ��
            ExcelPrint.PrintStudent printStudent = new ExcelPrint.PrintStudent();
            printStudent.ExecPrint(student);
        }

        //�ر�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    #region ʵ������
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