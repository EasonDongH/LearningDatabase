using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceTest
{
    class Animal
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Favorite { get; set; }

        protected int Cnt { get; set; }

        public void Introduce()
        {
            Console.WriteLine(string.Format("大家好，我是{0}，我的颜色是{1}，我喜欢{2}！",Name,Color,Favorite));
        }
    }
}
