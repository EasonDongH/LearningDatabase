using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using Models;

namespace StudentManager
{
    public partial class FrmScoreManage : Form
    {
        private ScoreListService objScoreService = new ScoreListService();
        public FrmScoreManage()
        {
            InitializeComponent();
            //�Ͽ��¼�
            this.cboClass.SelectedIndexChanged -=
                new EventHandler(this.cboClass_SelectedIndexChanged);
            //��ʼ���༶������
            this.cboClass.DataSource = new StudentClassService().GetAllClasses();
            this.cboClass.DisplayMember = "ClassName";//�������������ʾ�ı�
            this.cboClass.ValueMember = "ClassId";//������������ʾ�ı���Ӧ��value 
            this.cboClass.SelectedIndex = -1;
            //�ҽ��¼�
            this.cboClass.SelectedIndexChanged +=
                new EventHandler(this.cboClass_SelectedIndexChanged);
        }
        //���ݰ༶��ѯ      
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("������ѡ��Ҫ��ѯ�İ༶", "��ѯ��ʾ");
                return;
            }
            this.dgvScoreList.AutoGenerateColumns = false;
            this.dgvScoreList.DataSource = objScoreService.GetSCoreList(this.cboClass.Text.Trim());
            new Common.DataGridViewStyle().DgvStyle1(this.dgvScoreList);

            //ͬ����ʾ�༶������Ϣ
            this.gbStat.Text = "[" + this.cboClass.Text.Trim() + "]���Գɼ�ͳ��";
            Dictionary<string, string> dic =
                objScoreService.GetScoreInfoByClassId(this.cboClass.SelectedValue.ToString());
            this.lblAttendCount.Text = dic["stuCount"];
            this.lblCSharpAvg.Text = dic["avgCSharp"];
            this.lblDBAvg.Text = dic["avgDB"];
            this.lblCount.Text = dic["absentCount"];
            //��ʾȱ����Ա����
            List<string> list =
                objScoreService.GetAbsentListByClassId(this.cboClass.SelectedValue.ToString());
            this.lblList.Items.Clear();
            if (list.Count == 0) this.lblList.Items.Add("û��ȱ��");
            else
            {
                lblList.Items.AddRange(list.ToArray());
                //   lblList.DataSource = list;
            }

        }
        //�ر�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //ͳ��ȫУ���Գɼ�
        private void btnStat_Click(object sender, EventArgs e)
        {
            this.gbStat.Text = "ȫУ���Գɼ�ͳ��";
            this.dgvScoreList.AutoGenerateColumns = false;
            this.dgvScoreList.DataSource = objScoreService.GetSCoreList("");
            new Common.DataGridViewStyle().DgvStyle1(this.dgvScoreList);
            //��ѯ����ʾ�ɼ�ͳ��
            Dictionary<string, string> dic = objScoreService.GetScoreInfo();
            this.lblAttendCount.Text = dic["stuCount"];
            this.lblCSharpAvg.Text = dic["avgCSharp"];
            this.lblDBAvg.Text = dic["avgDB"];
            this.lblCount.Text = dic["absectCount"];
            //��ʾȱ����Ա����
            List<string> list = objScoreService.GetAbsentList();
            lblList.Items.Clear();
            lblList.Items.AddRange(list.ToArray());
        }

        private void dgvScoreList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Common.DataGridViewStyle.DgvRowPostPaint(this.dgvScoreList, e);
        }



        //ѡ���ѡ��ı䴦��
        private void dgvScoreList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvScoreList.IsCurrentCellDirty) //�����жϵ�Ԫ���ֵ�Ƿ���δ�ύ�ĸ���
            {
                this.dgvScoreList.CommitEdit(DataGridViewDataErrorContexts.Commit);//�ύ�޸�

                //��ʾ�޸ĺ��ֵ��true/false�����Խ��޸ĺ��״̬���µ����ݿ��...
                string ss = this.dgvScoreList.CurrentCell.EditedFormattedValue.ToString();
                MessageBox.Show(ss);
            }
        }
        //�����������
        private void dgvScoreList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.Value is Student)
            {
                e.Value = (e.Value as Student).StudentId;
            }
            if (e.ColumnIndex == 1 && e.Value is Student)
            {
                e.Value = (e.Value as Student).StudentName;
            }
            if (e.ColumnIndex == 2 && e.Value is Student)
            {
                e.Value = (e.Value as Student).Gender ;
            }
            if (e.ColumnIndex == 4 && e.Value is ScoreList)
            {
                e.Value = (e.Value as ScoreList).CSharp;
            }
            if (e.ColumnIndex == 5 && e.Value is ScoreList)
            {
                e.Value = (e.Value as ScoreList).SQLServerDB;
            }
        }


    }
}