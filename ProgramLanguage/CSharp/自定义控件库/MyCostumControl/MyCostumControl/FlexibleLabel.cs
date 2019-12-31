using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCostumControl
{
    public partial class FlexibleLabel : UserControl
    {
        public FlexibleLabel()
        {
            InitializeComponent();
        }

        public Label LableType { get; set; }

        public void AddText(string text) 
        {
            foreach (var item in text)
            {
                Label lbl = new Label();
                Padding p = new System.Windows.Forms.Padding();
                p.All = 0;
                lbl.Margin = p;
                lbl.BackColor = Color.Aquamarine;
                lbl.AutoSize = true;
                //lbl.ForeColor = this.LableType.ForeColor;
                lbl.Text = item.ToString();
                this.flowLayoutPanel1.Controls.Add(lbl);
            }
            
        }

        public void ClearText()
        {

        }
    }
}
