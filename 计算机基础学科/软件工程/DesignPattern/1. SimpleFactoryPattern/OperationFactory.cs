using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SimpleFactoryPattern
{
    class OperationFactory
    {
        public static  Operation GetOperation(string type)
        {
            Operation operation = null;
            switch (type)
            {
                case "+":
                    operation = new Add(); break;
                case "-":
                    operation = new Sub(); break;
                case "*":
                    operation = new Multi(); break;
                case "/":
                    operation = new Division(); break;
            }
            return operation;
        }
    }
}
