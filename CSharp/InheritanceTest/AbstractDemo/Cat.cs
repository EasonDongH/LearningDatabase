using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDemo
{
    class Cat:Animal
    {
        public void Dancing()
        {
            Console.WriteLine("我正在跳舞！");
        }
        //注意：Have方法与其它子类有区别，因此不能直接写在父类中
        public void Have1()
        {
            Console.WriteLine("人家正在嚼"+base.Favorite);
        }

        public override void Have2()
        {
            Console.WriteLine("人家正在嚼" + base.Favorite);
        }

        public override void Have3()
        {
            Console.WriteLine("人家正在嚼" + base.Favorite); 
        }
    }
}
