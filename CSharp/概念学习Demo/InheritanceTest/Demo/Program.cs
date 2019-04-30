namespace Demo
{
    class Program
    {
        /*
        需求：玩具猫、玩具狗等，同时具有姓名、颜色、喜爱的属性，都会介绍自己，分别：猫会跳舞、狗会奔跑

        问题：在Dog.cs与Cat.cs中存在重复代码
         */
        static void Main(string[] args)
        {
            Cat cat = new Cat() { Name = "咪咪", Color = "灰色", Favorite = "小鱼干" };
            Dog dog = new Dog() { Name = "旺旺", Color = "黄色", Favorite = "骨头" };

            System.Console.WriteLine("请介绍自己：");
            cat.Introduce();
            dog.Introduce();
            System.Console.WriteLine();
            System.Console.WriteLine("请表演节目：");
            cat.Dancing();
            dog.Rance();
        }
    }
}
