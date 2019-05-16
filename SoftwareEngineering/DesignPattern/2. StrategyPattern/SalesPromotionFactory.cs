using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.StrategyPattern
{
    class SalesPromotionFactory
    {
        public static SalesPromotion GetSalesPromotion(string type)
        {
            SalesPromotion promotion = null;
            switch (type)
            {
                case "正常":
                    promotion = new CashNormal();break;
                case "打折":
                    promotion = new CashRebate(0.8); break;
                case "满减":
                    promotion = new CashReturn(300,50); break;
            }
            return promotion;
        }
    }
}
