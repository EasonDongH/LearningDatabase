using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactory factory = new UndergraduateFactory();// 要改为“志愿者”仅修改这里就可以了
            LeiFeng leiFeng = factory.CreateLeiFeng();

            leiFeng.BuyRice();
            leiFeng.Sweep();
            leiFeng.Wash();

            Console.Read();
        }
    }
}
