using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace StudentManager
{
    public partial class FrmAttendanceQuery : Form
    {
        private AttendanceService objAService = new AttendanceService();

        public FrmAttendanceQuery()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //查询考勤结果
            DateTime dt1 = Convert.ToDateTime(this.dtpTime.Text);
            DateTime dt2 = dt1.AddDays(1.0);
            this.dgvStudentList.AutoGenerateColumns = false;
            this.dgvStudentList.DataSource = objAService.GetStuByDate(dt1, dt2, this.txtName.Text.Trim());
            new Common.DataGridViewStyle().DgvStyle3(this.dgvStudentList);


            //获取考勤的学员总数
            this.lblCount.Text = objAService.GetAllStudents();
            //显示实际的出勤人数
            this.lblReal.Text = objAService.GetAttendStudents(Convert.ToDateTime(this.dtpTime.Text), false);
            //显示缺勤人数
            this.lblAbsenceCount.Text = (Convert.ToInt32(this.lblCount.Text.Trim()) - Convert.ToInt32(this.lblReal.Text.Trim())).ToString();
        }
        //添加行号
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Common.DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
