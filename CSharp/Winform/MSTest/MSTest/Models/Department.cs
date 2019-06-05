using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTest
{
    [Serializable]
    public class Department
    {
        public string Id { get; set; } = string.Empty;
        public string DepartmentNo { get; set; }
        public string DepartmentName { get; set; }
        public string Remarks { get; set; }
    }
}
