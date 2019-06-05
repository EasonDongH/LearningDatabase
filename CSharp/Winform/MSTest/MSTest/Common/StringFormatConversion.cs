using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTest
{
    public class StringFormatConversion
    {
        public static string UTF16ToUTF8(string str)
        {
            byte[] utf16bytes = Encoding.Unicode.GetBytes(str);
            byte[] utf8bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, utf16bytes);
            return Encoding.UTF8.GetString(utf8bytes);
        }
    }
}
