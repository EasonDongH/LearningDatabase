using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.PrototypePattern
{
    class Resume : ICloneable
    {
        public string Name { get; private set; }
        public string Sex { get; private set; }
        public string Age { get; private set; }
        public WorkExperience workExperience { get; private set; }

        public Resume(string name)
        {
            this.Name = name;
            this.workExperience = new WorkExperience();
        }

        private Resume(WorkExperience experience)
        {
            this.workExperience = (WorkExperience)experience.Clone();
        }

        public void SetPersonInfo(string sex, string age)
        {
            this.Sex = sex;
            this.Age = age;
        }

        public void SetWorkExperience(string workDate, string company)
        {
            workExperience.WorkDate = workDate;
            workExperience.Company = company;
        }

        public void Display()
        {
            Console.WriteLine("{0} {1} {2}",this.Name,this.Sex,this.Age);
            Console.WriteLine("工作经历：{0} {1}",workExperience.WorkDate, workExperience.Company);
        }

        public object Clone()
        {
           // return (object)this.MemberwiseClone();
           // 深复刻
            Resume resume = new Resume(this.workExperience);
            resume.Name = this.Name;
            resume.Age = this.Age;
            resume.Sex = this.Sex;
            return resume;
        }
    }
}
