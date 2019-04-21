using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //IMultiPrinter objPrinter = new HPPrinter();
            //// 无论HPPrinter怎么变化，这里的调用不变
            //objPrinter.Print("打印内容……");
            //objPrinter.Copy("复印内容……");

            Print(new HPPrinter());
            Print(new CanonPrinter());
        }

        static void Print(IMultiPrinter printer)
        {
            printer.Print("123");
            printer.Copy("456");
        }
    }
}
