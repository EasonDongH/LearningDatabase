using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DapperDAL
{
    internal class MySQLHelper
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ToString();

        public static string ConnectionString
        {
            get { return connString; }
        }
    }
}