using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MSTest
{
    public class DALFactory
    {
        private static readonly string DALName = System.Configuration.ConfigurationManager.AppSettings["DALName"].ToString();

        public static T CreateService<T>(string serviceName) where T : class
        {
            T tmp = (T)Assembly.Load(DALName).CreateInstance(DALName+"."+serviceName);
            return tmp;
        }
    }
}