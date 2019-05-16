using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1.SimpleFactoryPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.cboOperator.SelectedIndex = 0;
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            double n1, n2;
            n1 = double.Parse(this.txtNum1.Text.Trim());
            n2 = double.Parse(this.txtNum2.Text.Trim());
            Operation operation = OperationFactory.GetOperation(this.cboOperator.SelectedItem.ToString());
            try
            {
                this.lblResult.Text = operation.GetResult(n1, n2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
