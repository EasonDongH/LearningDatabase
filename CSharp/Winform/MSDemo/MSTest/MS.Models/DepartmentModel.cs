using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

namespace MS.Models
{
    [Serializable]
    [Table("ms_department")]
    public class DepartmentModel
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }
        [Column("DepartmentNo")]
        public string DepartmentNo { get; set; }
        [Column("DepartmentName")]
        public string DepartmentName { get; set; }
        [Column("Remarks")]
        public string Remarks { get; set; }

        private const int departmentNoDBLength = 50;
        private const int departmentNameDBLength = 20;
        private const int remarksDBLength = 100;

        [NotMapped,IgnoreInsert,IgnoreSelect,IgnoreUpdate]
        public static int DepartmentNoValidLength { get { return departmentNoDBLength; } }
        [NotMapped, IgnoreInsert, IgnoreSelect, IgnoreUpdate]
        public static int DepartmentNameValidLength { get { return departmentNameDBLength; } }
        [NotMapped, IgnoreInsert, IgnoreSelect, IgnoreUpdate]
        public static int RemarksValidLength { get { return remarksDBLength; } }

        public static bool CheckDepartmentNoIsValid(string input)
        {
            return input.Length <= departmentNoDBLength;
        }
        
        public static bool CheckDepartmentNameIsValid(string input)
        {
            return input.Length <= departmentNameDBLength;
        }

        public static bool CheckRemarksIsValid(string input)
        {
            return input.Length <= remarksDBLength;
        }

        
    }
}
