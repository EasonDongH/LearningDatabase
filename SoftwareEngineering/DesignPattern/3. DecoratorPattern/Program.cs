using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Person xc = new Person("小菜");
            Console.WriteLine("第一种打扮：");
            Sneakers pqx = new Sneakers();
            Trouser kk = new Trouser();
            TShirts dtx = new TShirts();

            pqx.Decorate(xc);
            kk.Decorate(pqx);
            dtx.Decorate(kk);
            dtx.Show();

            Console.Read();
        }
    }

    class Person
    {
        public Person() { }

        private string name;
        public Person(string name)
        {
            this.name = name;
        }

        public virtual void Show()
        {
            Console.WriteLine("装扮的{0}", name);
        }
    }

    class Finery : Person
    {
        protected Person component;
        public void Decorate(Person component)
        {
            this.component = component;
        }
        public override void Show()
        {
            if (component != null)
                component.Show();
        }
    }

    class TShirts : Finery
    {
        public override void Show()
        {
            Console.Write("T恤    ");
            base.Show();
        }
    }

    class Sneakers : Finery
    {
        public override void Show()
        {
            Console.Write("球鞋    ");
            base.Show();
        }
    }

    class Trouser : Finery
    {
        public override void Show()
        {
            Console.Write("裤子    ");
            base.Show();
        }
    }
}
