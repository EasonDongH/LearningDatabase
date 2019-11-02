using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.StrategyPattern
{
    class CashNormal:SalesPromotion
    {
        public override double ShouldPay(double totalPrice)
        {
            return totalPrice;
        }
    }
}
