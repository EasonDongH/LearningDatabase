using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.StrategyPattern
{
    class CashReturn:SalesPromotion
    {
        public double MoneyCondition { get; set; }
        public double MoneyReturn { get; set; }

        public CashReturn(double moneyCondition, double moneyReturn)
        {
            this.MoneyCondition = moneyCondition;
            this.MoneyReturn = moneyReturn;
        }
        public override double ShouldPay(double totalPrice)
        {
            if (totalPrice >= this.MoneyCondition)
                totalPrice -= this.MoneyReturn;
            return totalPrice;
        }
    }
}
