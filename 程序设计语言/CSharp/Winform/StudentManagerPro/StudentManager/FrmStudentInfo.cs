using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Models.Ext;
using DAL;
using Common;

namespace StudentManager
{
    public partial class FrmStudentInfo : Form
    {
        public FrmStudentInfo()
        {
            InitializeComponent();
        }
        public FrmStudentInfo(StudentExt objStudent)
            : this()
        {
            //显示学员信息
            this.lblStudentName.Text = objStudent.StudentName;
            this.lblStudentIdNo.Text = objStudent.StudentIdNo.ToString();
            this.lblPhoneNumber.Text = objStudent.PhoneNumber;
            this.lblBirthday.Text = objStudent.Birthday.ToShortDateString();
            this.lblAddress.Text = objStudent.StudentAddress;
            this.lblClass.Text = objStudent.ClassName;
            this.lblGender.Text = objStudent.Gender;
            this.lblCardNo.Text = objStudent.CardNo;
            //显示照片
            this.pbStu.Image = objStudent.StuImage.Length != 0 ?
              (Image)new SerializeObjectToString().DeserializeObject(objStudent.StuImage) : Image.FromFile("default.png"); ;
        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}