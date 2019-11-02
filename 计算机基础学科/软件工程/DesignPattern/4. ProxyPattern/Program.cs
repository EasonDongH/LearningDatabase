using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolGirl girl = new SchoolGirl();
            girl.Name = "娇娇";
            Proxy daili = new Proxy(girl);

            daili.GiveDolls();
            daili.GiveChocolate();
            daili.GiveFlowers();

            Console.Read();
        }
    }

    interface IGiveGift
    {
        void GiveDolls();
        void GiveFlowers();
        void GiveChocolate();
    }
    // 目标
    class SchoolGirl
    {
        public string Name { get; set; }
    }

    // 实际者
    class Pursuit : IGiveGift
    {
        SchoolGirl mm;
        public Pursuit(SchoolGirl mm)
        {
            this.mm = mm;
        }
        public void GiveChocolate()
        {
            Console.WriteLine(mm.Name + "，送你巧克力");
        }

        public void GiveDolls()
        {
            Console.WriteLine(mm.Name + "，送你洋娃娃");
        }

        public void GiveFlowers()
        {
            Console.WriteLine(mm.Name + "，送你鲜花");
        }
    }

    // 代理者
    class Proxy : IGiveGift
    {
        Pursuit gg;
        public Proxy(SchoolGirl mm)
        {
            gg = new Pursuit(mm);
        }
        public void GiveChocolate()
        {
            gg.GiveChocolate();
        }

        public void GiveDolls()
        {
            gg.GiveDolls();
        }

        public void GiveFlowers()
        {
            gg.GiveFlowers();
        }
    }
}
