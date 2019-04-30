using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryModeDemo
{
    class WordReport : IReport
    {
        void IReport.StartPrint()
        {
            Console.WriteLine("Word报表：打印一开始……");
        }
    }
}
