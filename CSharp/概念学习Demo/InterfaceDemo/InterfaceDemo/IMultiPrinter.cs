using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    interface IMultiPrinter
    {
        string PrinterBrand { get;  }
        void Print(string info);
        void Copy(string info);
    }
}
