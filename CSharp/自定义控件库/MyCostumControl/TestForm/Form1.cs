using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<dgv> list = new List<dgv>() { 
                new dgv(){Column1=1,Column2=2,Column3=3},
                new dgv(){Column1=4,Column2=5,Column3=6},
                new dgv(){Column1=7,Column2=8,Column3=9}
            };

            this.exDataGridView1.DataSource = list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.circleLoading1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.circleLoading1.Stop();
        }
    }

    class dgv
    {
        public int Column1 { get; set; }

        public int Column2 { get; set; }

        public int Column3 { get; set; }
    }
}
