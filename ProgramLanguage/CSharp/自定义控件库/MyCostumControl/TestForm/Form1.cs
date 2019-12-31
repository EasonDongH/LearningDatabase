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

       
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.flexibleLabel1.AddText("123456");
        }
    }

    class dgv
    {
        public int Column1 { get; set; }

        public int Column2 { get; set; }

        public int Column3 { get; set; }
    }
}
