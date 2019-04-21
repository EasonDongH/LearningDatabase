using System.Configuration;
using System.Reflection;

namespace SimpleFactoryModeDemo
{
    class Factory
    {
        static IReport report = null;

        // 通过配置文件来选择报表类型
        static string reportType = ConfigurationManager.AppSettings["ReportType"].ToString();

        public IReport ChooseReport()
        {
            switch (reportType)
            {
                case "ExcelReport":
                    report = new ExcelReport(); break;
                case "WordReport":
                    report = new WordReport(); break;
                case "CrystalReport":
                    report = new CrystalReport();break;
            }

            return report;
        }

        // 使用反射动态创建接口实现类
        public IReport GetReport()
        {
            report = (IReport)Assembly.Load("SimpleFactoryModeDemo").CreateInstance("SimpleFactoryModeDemo." + reportType);
            return report;
        }
    }
}
