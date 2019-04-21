using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
}
