using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DAL;
using Models;

namespace StudentManager
{
    public partial class FrmScoreReport : Form
    {
        private StudentClassService classService = new StudentClassService();
        private ScoreReportService reportService = new ScoreReportService();

        public FrmScoreReport()
        {
            InitializeComponent();

            //初始化班级下拉框
            this.cboClass.DataSource = classService.GetAllClasses();
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";
        }
        //查询并预览
        private void btnQuery_Click(object sender, EventArgs e)
        {
            //根据班级查询
            List<ScoreReport> scoreList = reportService.GetSCoreList(this.cboClass.Text);

            //设置报表视图属性
            // this.reportViewer.LocalReport.DisplayName = "学员成绩表";
            this.reportViewer.LocalReport.DataSources.Clear();

            //添加数据集，为成绩集合绑定数据
            this.reportViewer.LocalReport.DataSources.Add
                (new Microsoft.Reporting.WinForms.ReportDataSource("ScoreDataSet", scoreList));

            //显示
            this.reportViewer.LocalReport.Refresh();
            this.reportViewer.RefreshReport();  
        }
    }
}
