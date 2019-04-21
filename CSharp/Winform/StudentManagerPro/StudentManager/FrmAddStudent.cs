using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Models;
using DAL;
using MyVideo;
using Common;

namespace StudentManager
{
    public partial class FrmAddStudent : Form
    {
        //�������ݷ��ʶ���
        private StudentClassService objClassService = new StudentClassService();
        private StudentService objStudentService = new StudentService();
        private List<Student> stuList = new List<Student>();
        private Video objVideo;

        public FrmAddStudent()
        {
            InitializeComponent();
            //��ʼ���༶������
            this.cboClassName.DataSource = objClassService.GetAllClasses();
            this.cboClassName.DisplayMember = "ClassName";//�������������ʾ�ı�
            this.cboClassName.ValueMember = "ClassId";//������������ʾ�ı���Ӧ��value

            this.KeyPreview = true;//���ô�����ռ��̰����¼�


            this.dgvStudentList.AutoGenerateColumns = false;
        }
        //�����ѧԱ
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region  ��֤����

            if (this.txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("ѧ����������Ϊ�գ�", "��ʾ��Ϣ");
                this.txtStudentName.Focus();
                return;
            }
            if (this.txtCardNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("���ڿ��Ų���Ϊ�գ�", "��ʾ��Ϣ");
                this.txtCardNo.Focus();
                return;
            }
            //��֤�Ա�
            if (!this.rdoFemale.Checked && !this.rdoMale.Checked)
            {
                MessageBox.Show("��ѡ��ѧ���Ա�", "��ʾ��Ϣ");
                return;
            }
            //��֤�༶
            if (this.cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��༶��", "��ʾ��Ϣ");
                return;
            }
            //��֤����
            int age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;
            if (age > 35 && age < 18)
            {
                MessageBox.Show("���������28-35��֮�䣡", "��ʾ��Ϣ");
                return;
            }
            //��֤���֤���Ƿ����Ҫ��
            if (!Common.DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("���֤�Ų�����Ҫ��", "��֤��ʾ");
                this.txtStudentIdNo.Focus();
                return;
            }


            // if (!this.txtStudentIdNo.Text.Trim().Contains(Convert.ToDateTime(this.dtpBirthday.Text).ToString("yyyyMMdd")))
            if (!this.txtStudentIdNo.Text.Trim().Contains(this.dtpBirthday.Value.ToString("yyyyMMdd")))
            {
                MessageBox.Show("���֤�źͳ������ڲ�ƥ�䣡", "��֤��ʾ");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            //��֤���֤���Ƿ��ظ�
            if (objStudentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("���֤�Ų��ܺ�����ѧԱ���֤���ظ���", "��֤��ʾ");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            //��֤�����Ƿ��ظ�
            if (objStudentService.IsCardNoExisted(this.txtCardNo.Text.Trim()))
            {
                MessageBox.Show("��ǰ�����Ѿ����ڣ�", "��֤��ʾ");
                this.txtCardNo.Focus();
                this.txtCardNo.SelectAll();
                return;
            }
            #endregion

            #region ��װѧ������
            Student objStudent = new Student()
            {
                StudentName = this.txtStudentName.Text.Trim(),
                Gender = this.rdoMale.Checked ? "��" : "Ů",
                Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
                StudentIdNo = this.txtStudentIdNo.Text.Trim(),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                ClassName = this.cboClassName.Text,
                StudentAddress = this.txtAddress.Text.Trim() == "" ? "��ַ����" : this.txtAddress.Text.Trim(),
                CardNo = this.txtCardNo.Text.Trim(),
                ClassId = Convert.ToInt32(this.cboClassName.SelectedValue),//��ȡѡ��༶��ӦclassId
                Age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year,
                StuImage = this.pbStu.Image != null ? new SerializeObjectToString().SerializeObject(this.pbStu.Image) : ""
            };
            #endregion
            #region ���ú�̨���ݷ��ʷ�����Ӷ���
            try
            {
                int studentId = objStudentService.AddStudent(objStudent);
                if (studentId > 1)
                {
                    //ͬ����ʾ��ӵ�ѧԱ
                    objStudent.StudentId = studentId;
                    this.stuList.Add(objStudent);
                    this.dgvStudentList.DataSource = null;
                    this.dgvStudentList.DataSource = this.stuList;
                    //ѯ���Ƿ�������
                    DialogResult result = MessageBox.Show("��ѧԱ��ӳɹ�!�Ƿ������ӣ�", "��ʾ��Ϣ",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)//����û��������Ϣ
                    {
                        foreach (Control item in this.gbstuinfo.Controls)
                        {
                            if (item is TextBox) item.Text = "";
                        }
                        this.cboClassName.SelectedIndex = -1;
                        this.rdoFemale.Checked = false;
                        this.rdoMale.Checked = false;
                        this.txtStudentName.Focus();
                        this.pbStu.Image = null;
                    }
                    else this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        //����к�
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Common.DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList, e);
        }
        //�رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmAddStudent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)//����ESC���رմ���
            {
                this.Close();
            }

        }
        //ѡ������Ƭ
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog objFileDialog = new OpenFileDialog();
            DialogResult result = objFileDialog.ShowDialog();
            if (result == DialogResult.OK)
                this.pbStu.Image = Image.FromFile(objFileDialog.FileName);
        }
        //��������ͷ
        private void btnStartVideo_Click(object sender, EventArgs e)
        {
            try
            {
                objVideo = new Video(pbVideo.Handle, this.pbVideo.Left, this.pbVideo.Top, this.pbVideo.Width, (short)this.pbVideo.Height);
                objVideo.OpenVideo();
                this.btnStartVideo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("����ͷ����ʧ�ܣ�" + ex.Message, "��ʾ��Ϣ");
            }
        }
        //����
        private void btnTake_Click(object sender, EventArgs e)
        {
            if (objVideo == null)
                MessageBox.Show("������������ͷ��", "������ʾ");
            else
                this.pbStu.Image = objVideo.CatchVideo();
        }
        //�����Ƭ
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.pbStu.Image = null;

        }


    }
}