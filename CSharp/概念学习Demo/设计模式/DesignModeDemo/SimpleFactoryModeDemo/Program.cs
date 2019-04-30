using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryModeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //需要改变报表（已存在），就需要改程序
            //IReport report = new ExcelReport();
            //report.StartPrint();

            // 解决了变化报表类型，需要修改程序的问题
            //IReport report = new Factory().ChooseReport();
            //report.StartPrint();
            // 但是，如果需要增加报表类型（未存在），还需要去修改Factory中的switch语句

            // 使用反射，解决了新增报表类型还需要修改switch的问题
            IReport report = new Factory().GetReport();
            report.StartPrint();

            Console.Read();
        }
    }
}
