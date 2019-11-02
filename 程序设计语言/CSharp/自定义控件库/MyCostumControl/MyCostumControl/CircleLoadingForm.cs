using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCostumControl
{
    public partial class CircleLoadingForm : Form
    {
        public CircleLoadingForm()
        {
            InitializeComponent();
        }

        public void Start()
        {
            this.CenterToScreen();
            this.ShowDialog();
        }

        public void Stop()
        {
            this.Close();
        }
    }
}
