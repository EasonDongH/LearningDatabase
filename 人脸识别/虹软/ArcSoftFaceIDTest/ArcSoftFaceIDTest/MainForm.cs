using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Base;

namespace ArcSoftFaceIDTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void btnDetectFace_Click(object sender, EventArgs e)
        {
            FaceDetectForm frm = new FaceDetectForm();
            frm.ShowDialog();
        }
    }
}
