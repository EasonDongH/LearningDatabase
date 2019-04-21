using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryModeDemo
{
    class ExcelReport : IReport
    {
        void IReport.StartPrint()
        {
            Console.WriteLine("Excel报表：打印已开始……");
        }
    }
}
