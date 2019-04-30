using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDemo
{
    class Dog:Animal
    {
        public void Race()
        {
            base.Cnt = 5;
            Console.WriteLine("我正在奔跑！");
        }
        //注意：Have方法与其它子类有区别，因此不能直接写在父类中
        public void Have1()
        {
            Console.WriteLine("俺正在啃"+base.Favorite);
        }

        public override void Have2()
        {
            Console.WriteLine("俺正在啃" + base.Favorite);
        }

        //方法覆盖
        public new void Introduce()
        {
            Console.WriteLine(string.Format("My name is {0}, my color is {1},my favorite is {2}.",base.Name,base.Color,base.Favorite));
        }
    }
}
