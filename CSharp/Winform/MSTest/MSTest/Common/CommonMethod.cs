using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTest
{
    public class CommonMethod
    {
        public static string GetGUID()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}
