using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Ext
{
    /// <summary>
    /// 学员信息扩展实体
    /// </summary>
    public class StudentExt : Student
    {
        public string ClassName { get; set; }
        public string CSharp { get; set; }
        public string SQLServerDB { get; set; }
        public DateTime DTime { get; set; }//签到时间

        public bool cc { get; set; }
    }
}
