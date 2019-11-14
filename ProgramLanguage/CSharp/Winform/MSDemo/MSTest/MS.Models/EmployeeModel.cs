using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

namespace MS.Models
{
    [Serializable]
    [Table("ms_employee")]
    public class EmployeeModel
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }
        [Column("DepartmentId")]
        public string DepartmentId { get; set; }
        [IgnoreInsert,IgnoreSelect,IgnoreUpdate]
        public string DepartmentName { get; set; }
        [Column("EmployeeNo")]
        public string EmployeeNo { get; set; }
        [Column("EmployeeName")]
        public string EmployeeName { get; set; }
        [Column("EmployeeSex")]
        public string EmployeeSex { get; set; }

        private string _employeeBirth = string.Empty;
        [Column("EmployeeBirth")]
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
        [Column("IsJob")]
        public bool IsJob { get; set; }
        [Column("Remarks")]
        public string Remarks { get; set; }
        [NotMapped, IgnoreInsert, IgnoreSelect, IgnoreUpdate]
        public DepartmentModel CorrespondingDepartment { get; set; }

        private const int employeeNoDBLength = 10;
        private const int employeeNameDBLength = 20;
        private const int remarksDBLength = 100;

        [NotMapped, IgnoreInsert,IgnoreSelect,IgnoreUpdate]
        public static int EmployeeNoValidLength { get { return employeeNoDBLength; } }
        [NotMapped, IgnoreInsert, IgnoreSelect, IgnoreUpdate]
        public static int EmployeeNameValidLength { get { return employeeNameDBLength; } }
        [NotMapped, IgnoreInsert, IgnoreSelect, IgnoreUpdate]
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
    }
}
