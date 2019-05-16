using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.StrategyPattern
{
    class CashContext
    {
        private  SalesPromotion promotion = null;
        public CashContext(string type)
        {
            switch (type)
            {
                case "正常":
                    promotion = new CashNormal(); break;
                case "打折":
                    promotion = new CashRebate(0.8); break;
                case "满减":
                    promotion = new CashReturn(300, 50); break;
            }
        }
        public  double GetResult(double totalPrice)
        {
            return promotion.ShouldPay(totalPrice);
        }
    }
}
