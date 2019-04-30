using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    class HPPrinter : IMultiPrinter
    {
        // 接口的实现可以任意变化，调用方式不变
        string IMultiPrinter.PrinterBrand { get; } = "HP-Q1234";

        void IMultiPrinter.Copy(string info)
        {
            Console.WriteLine("惠普：正在拷贝……" + info);
        }

        void IMultiPrinter.Print(string info)
        {
            Console.WriteLine("惠普：正在打印……" + info);
        }
    }
}
