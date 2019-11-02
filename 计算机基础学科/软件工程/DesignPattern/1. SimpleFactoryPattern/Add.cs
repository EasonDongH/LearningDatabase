using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SimpleFactoryPattern
{
    class Add : Operation
    {
        public override double GetResult(double n1, double n2)
        {
            return n1 + n2;
        }
    }
}
