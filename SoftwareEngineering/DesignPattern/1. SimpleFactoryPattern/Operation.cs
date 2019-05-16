using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SimpleFactoryPattern
{
    abstract class Operation
    {
        public abstract double GetResult(double n1, double n2);
    }
}
