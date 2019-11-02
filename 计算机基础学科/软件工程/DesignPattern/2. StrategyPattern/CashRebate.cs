using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.StrategyPattern
{
    class CashRebate:SalesPromotion
    {
        public double MoneyRebate { get; set; }
        public CashRebate(double moneyRebate)
        {
            this.MoneyRebate = moneyRebate;
        }
        public override double ShouldPay(double totalPrice)
        {
            return totalPrice * this.MoneyRebate;
        }
    }
}
