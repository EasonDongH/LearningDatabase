using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Cat
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Favorite { get; set; }

        public void Introduce()
        {
            Console.WriteLine(string.Format("大家好，我是{0}，我的颜色是{1}，我喜欢{2}！", Name, Color, Favorite));
        }

        public void Dancing()
        {
            Console.WriteLine("我正在跳舞！");
        }
    }
}
