using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Models
{
    [Serializable]
    public class EmployeeModel
    {
        private const int employeeNoDBLength = 10;
        private const int employeeNameDBLength = 20;
        private const int remarksDBLength = 100;

        public static int EmployeeNoValidLength { get { return employeeNoDBLength; } }
        public static int EmployeeNameValidLength { get { return employeeNameDBLength; } }
        public static int RemarksValidLength { get { return remarksDBLength; } }

        public static bool CheckEmployeeNoIsValid(string input)
        {
            return input.Length <= employeeNoDBLength;
        }

        public static bool CheckEmployeeNameIsValid(string input)
        {
            return input.Length <= employeeNameDBLength;
        }

        public static bool CheckRemarksIsValid(string input)
        {
            return input.Length <= remarksDBLength;
        }

        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSex { get; set; }

        private string _employeeBirth = string.Empty;
        public string EmployeeBirth
        {
            get
            {
                return this._employeeBirth;
            }
            set
            {
                this._employeeBirth = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
            }
        }
        public bool IsJob { get; set; }
        public string Remarks { get; set; }
    }
}
