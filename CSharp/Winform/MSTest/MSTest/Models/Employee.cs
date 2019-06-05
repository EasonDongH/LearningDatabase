using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTest
{
    [Serializable]
    public class Employee
    {
        public string Id { get; set; } = string.Empty;
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSex { get; set; }
        public string  EmployeeBirth { get; set; }
        public bool IsJob { get; set; }
        public string Remarks { get; set; }
    }
}
