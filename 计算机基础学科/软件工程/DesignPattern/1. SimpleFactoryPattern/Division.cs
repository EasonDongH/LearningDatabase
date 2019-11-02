using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SimpleFactoryPattern
{
    class Division : Operation
    {
        public override double GetResult(double n1, double n2)
        {
            try
            {
                if (n2 == 0)
                    throw new Exception("除数不能为空");
                return n1 / n2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
