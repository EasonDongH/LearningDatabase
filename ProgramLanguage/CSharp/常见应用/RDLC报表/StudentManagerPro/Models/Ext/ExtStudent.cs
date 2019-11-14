using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class ExtStudent
    {
        public Student ObjStudent { get; set; }

        public ScoreList  ObjScore { get; set; }
        public string ClassName { get; set; }
        public string CSharp { get; set; }
        public string SQLServerDB { get; set; }
        public DateTime DTime { get; set; }//签到时间

        public bool cc { get; set; }
    }
}
