using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    class CanonPrinter : IMultiPrinter
    {
        string IMultiPrinter.PrinterBrand => throw new NotImplementedException();

        void IMultiPrinter.Copy(string info)
        {
            Console.WriteLine("佳能：正在拷贝……"+info);
        }

        void IMultiPrinter.Print(string info)
        {
            Console.WriteLine("佳能：正在打印……" + info);
        }
    }
}
