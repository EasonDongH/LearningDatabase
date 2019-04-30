using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryModeDemo
{
    class CrystalReport : IReport
    {
        void IReport.StartPrint()
        {
            Console.WriteLine("Crystal报表：打印一开始……");
        }
    }
}
