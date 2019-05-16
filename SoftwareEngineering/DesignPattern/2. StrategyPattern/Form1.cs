using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2.StrategyPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.cboWay.SelectedIndex = 0;
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            double totalPrice = double.Parse(this.txtTotalPrice.Text.Trim());

            // 【1】 使用简单工厂：需要耦合SalesPromotion、SalesPromotionFactory
            //SalesPromotion promotion = SalesPromotionFactory.GetSalesPromotion(this.cboWay.SelectedItem.ToString());
            //totalPrice = promotion.ShouldPay(totalPrice);

            // 【2】使用策略模式：仅耦合CashContext
            CashContext cashContext = new CashContext(this.cboWay.SelectedItem.ToString());
            totalPrice = cashContext.GetResult(totalPrice);

            this.lblResult.Text = totalPrice.ToString();
        }
    }
}
