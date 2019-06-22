using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.PrototypePattern
{
    class WorkExperience : ICloneable
    {
        public string WorkDate { get; set; }
        public string Company { get; set; }
        public object Clone()
        {
            // 浅复刻
            return (object)this.MemberwiseClone();
        }
    }
}
