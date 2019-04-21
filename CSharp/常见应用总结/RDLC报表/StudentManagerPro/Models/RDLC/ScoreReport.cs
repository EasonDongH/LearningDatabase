using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 报表专用的成绩实体类
    /// </summary>
    public class ScoreReport:Student
    {
        public int CSharp { get; set; }
        public int SQLServerDB { get; set; }

    }
}
