using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceTest
{
    class Program
    {
        // 使用继承，解决Demo中重复代码问题
        static void Main(string[] args)
        {
            Cat cat = new Cat() { Name = "咪咪", Color = "灰色", Favorite = "小鱼干" };
            Dog dog = new Dog() { Name = "旺旺", Color = "黄色", Favorite = "骨头" };

            //dog.Cnt = 5;

            System.Console.WriteLine("请介绍自己：");
            cat.Introduce();
            dog.Introduce();
            System.Console.WriteLine();
            System.Console.WriteLine("请表演节目：");
            cat.Dancing();
            dog.Race();
        }
    }
}
