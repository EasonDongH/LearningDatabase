using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceTest
{
    class Dog:Animal
    {
        public void Race()
        {
            base.Cnt = 5;
            Console.WriteLine("我正在奔跑！");
        }
    }
}
