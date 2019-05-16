using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.StrategyPattern
{
    abstract class SalesPromotion
    {
        public abstract double ShouldPay(double totalPrice);
    }
}
