using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 需求：Cat与Dog都有自己的Have方法，且需要将两个对象添加在一个集合中（子类自动转化为父类）
            // 先不使用抽象类。为区别，命名为Have1
            Console.WriteLine("不使用抽象类：");
            Cat cat1 = new Cat() { Name="咪咪",Color="灰色",Favorite="小鱼干"};
            Dog dog1 = new Dog() { Name = "旺旺", Color = "黄色", Favorite = "肉骨头" };
            List<Animal> animals = new List<Animal>() { cat1, dog1 };
            foreach (Animal animal in animals)
            {
                //注意：这里必须判断，否则会出现类型转换异常
                //有N个子类，就需要N次判断，不符合“开闭原则”
                if (animal is Cat)
                    ((Cat)animal).Have1();
                else if (animal is Dog)
                    ((Dog)animal).Have1();
            }
            // 问题：在取出父类集合中元素时，必须判断当前对象是哪个子类，否则无法准确地转换对象类型
            Console.WriteLine();
            // 使用抽象类。为区别，命名为Have2
            Console.WriteLine("使用抽象类：");
            Cat cat2 = new Cat() { Name = "咪咪", Color = "灰色", Favorite = "小鱼干" };
            Dog dog2 = new Dog() { Name = "旺旺", Color = "黄色", Favorite = "肉骨头" };
            List<Animal> animals2 = new List<Animal>() { cat1, dog1 };
            foreach (Animal animal in animals2)
            {
                animal.Have2();
            }

            Console.WriteLine();
            // 使用虚方法。为区别，命名为Have3
            Console.WriteLine("使用虚方法：");
            Cat cat3= new Cat() { Name = "咪咪", Color = "灰色", Favorite = "小鱼干" };
            Dog dog3= new Dog() { Name = "旺旺", Color = "黄色", Favorite = "肉骨头" };
            List<Animal> animals3= new List<Animal>() { cat1, dog1 };
            foreach (Animal animal in animals3)
            {
                animal.Have3();
            }

            Console.WriteLine();
            // 方法覆盖
            Cat cat4 = new Cat() { Name = "咪咪", Color = "灰色", Favorite = "小鱼干" };
            Dog dog4 = new Dog() { Name = "旺旺", Color = "黄色", Favorite = "肉骨头" };
            cat4.Introduce();
            dog4.Introduce();
        }
    }
}
