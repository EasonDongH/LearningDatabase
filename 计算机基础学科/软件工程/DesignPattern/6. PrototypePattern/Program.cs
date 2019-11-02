using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Resume a = new Resume("大鸟");
            a.SetPersonInfo("男","29");
            a.SetWorkExperience("2008-2010","X公司");

            Resume b = (Resume)a.Clone();
            b.SetWorkExperience("2009-2011","Y公司");

            Resume c = (Resume)a.Clone();
            c.SetPersonInfo("男","24");
            c.SetWorkExperience("2011-2015","Z公司");

            a.Display();
            b.Display();
            c.Display();

            Console.Read();
        }
    }
}
